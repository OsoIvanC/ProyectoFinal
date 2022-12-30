using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Mathematics;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[System.Serializable]
public struct Stats
{

    [SerializeField]
    float maxHealth;
    [SerializeField]
    float health;
    [SerializeField]
    float attackDamage;
    [SerializeField]
    float attackSpeed;
    [SerializeField]
    float movementSpeed;
    [SerializeField]
    float smoothRotValue;
    [SerializeField]
    float gravity;
    [SerializeField]
    bool canAttack ;
    [SerializeField]
    bool canRoll;
    [SerializeField]
    int maxBullets;
    [SerializeField]
    int bullets;
   
    public float MaxHealth { get { return maxHealth; } set { maxHealth = value; } }
    public int MaxBullets { get { return maxBullets; } }
    public int Bullets { get { return bullets; } set{ bullets = value; } }
    public float Health { get { return health; } set { health = value; } }
    public float AttackDamage { get { return attackDamage; } set { attackDamage = value;  } }
    public float AttackSpeed { get { return attackSpeed; } }
    public float MovementSpeed { get { return movementSpeed; } }
    public float SmoothRotValue { get { return smoothRotValue; } }
    public float Gravity { get { return gravity; } }
    public bool CanAttack {get { return canAttack; } set { canAttack = value; } }
    public bool CanRoll { get { return canRoll; } set { canRoll = value; } }
    

    public void Init()
    {
        this.health = this.maxHealth;
        this.bullets = this.maxBullets;
        this.canAttack = true;
        this.canRoll = true;

    }

  
}

[RequireComponent(typeof(CharacterController))]
public class Controller : MonoBehaviour, IController
{
    
    public Stats myStats;

    public static Controller Instance;

    public Stats PlayerStats { get { return myStats; } }

    [SerializeField]
    float attackAnimTime;

    Vector3 _inputVector;
    public Vector3 InputVector { get { return _inputVector; } }

    PlayerActions _inputActions;

    CharacterController controller;

    Vector3 velocity;

    ControllerAnimations animations;

    [SerializeField]
    AnimationClip attackAnim;

    [SerializeField]
    float rollDistance;

    bool isRolling;

    Vector3 initCenterCollider;
    float initHeight;

    [SerializeField]
    Vector3 newCenterCollider;

    [SerializeField]
    float newHeight;

    public bool isAttacking;

    [Header("Armas")]
    [SerializeField]
        public Weapon Melee;
    [SerializeField]
        public Weapon Range;
    [SerializeField]
        GunManager gunManager;

    [Header("UI")]
        public GameObject gameOverPanel;
        [SerializeField]
            GameObject pausePanel;
        [SerializeField]
            TMP_Text scoreText;
        [SerializeField]
            Slider healthBar;
        [SerializeField]
            Image healthBarI;

    [Header("AUDIO")]
    [SerializeField]
        AudioClip shootClip;
    [SerializeField]
        AudioClip swingClip;
    [SerializeField]
        AudioClip deathClip;
    [SerializeField]
        AudioClip rollClip;
    [SerializeField]
        AudioSource source;


    [SerializeField]
        TrailRenderer trailRenderer;


    public static bool pause;
    public static bool isAlive;
    public static int score;
    public static bool canPause;
    void Awake()
    {

        Instance = this;

        myStats.Init();


        healthBar.maxValue = myStats.MaxHealth;

        _inputActions = new PlayerActions();

        controller = GetComponent<CharacterController>();

        animations = GetComponentInChildren<ControllerAnimations>();

        gunManager = GetComponentInChildren<GunManager>();

        gunManager.magazine = myStats.MaxBullets;
        
        source = GetComponent<AudioSource>();

        isRolling = false;

        isAlive = true;

        canPause = true;
        
        score = 0;

        //Cursor.visible = false;

        trailRenderer.enabled = false;

        //MOVE INPUT
        _inputActions.Movement.WALK.performed += ctx => _inputVector = new Vector3(ctx.ReadValue<Vector2>().x, 0, ctx.ReadValue<Vector2>().y);
        _inputActions.Movement.WALK.canceled += _ => _inputVector = Vector3.zero;

        //ATTACK INPUT
        _inputActions.Interactions.Attack.started += _ => Attack();

        //DASH INPUT
        _inputActions.Movement.DASH.performed += _ => RollAnim();


        //WEAPON CHANGE
        _inputActions.Interactions.Melee.performed += _ => WeaponManager.instance.ChangeWeapon(Melee);
        _inputActions.Interactions.Range.performed += _ => WeaponManager.instance.ChangeWeapon(Range);

        //PAUSE 
        _inputActions.Interactions.Pause.performed += _ => Pause();

        //
        _inputActions.Interactions.Swap.performed += ctx => WeaponManager.instance.ScrollWeapon(ctx.ReadValue<Vector2>());

        _inputActions.Interactions.Toogle.performed += _ => WeaponManager.instance.Toogle();


        initCenterCollider = controller.center;
        initHeight = controller.height; 
    
    }


    public void HealthBar()
    {
        healthBar.value = myStats.Health;

        float perc = (myStats.Health / myStats.MaxHealth) * 100;

        if(perc > 75)
            healthBarI.color = Color.green;
        else if(perc <= 75 && perc > 50 )
            healthBarI.color = Color.yellow;
        else if(perc <= 50 && perc > 25)
            healthBarI.color = new Color(255, 165, 0);
        else
            healthBarI.color = Color.red;
    }

    private void Update()
    {

        if (!isAlive)
            return;

        if (pause)
            return;


        Move();
        Gravity();
        Rotate();
        RollAction();
    
        
          //Debug.DrawRay(transform.position + Vector3.up, transform.forward, Color.red);
    }

    private void LateUpdate()
    {
        scoreText.text = $"Score: {score} ";

        HealthBar();
    }

    void Pause()
    {
        if (!canPause)
            return;

        pause = !pause;

        Time.timeScale = pause ? 0 : 1;

        pausePanel.SetActive(pause);
    }

    private void OnEnable()
    {
        _inputActions.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Disable();
    }

    public void Attack()
    {
        //Debug.Log("AttackInit");

        if (!isAlive) return;
        if (!myStats.CanAttack) return;

        if (isRolling) return;

        if (pause)  return;


        trailRenderer.enabled = true;

        isAttacking = true;

        var r = UnityEngine.Random.Range(1, 3);

        source.pitch = r;

        source.PlayOneShot(swingClip);

        //if(isRolling) return;

        myStats.CanAttack = false;
        
        animations.PlayAnimTrigger("Attack");
        
        //StartCoroutine(IAttack());
    }

    public void AttackReset()
    {
        myStats.CanAttack = true;

        trailRenderer.enabled = false;

        isAttacking=false;

        //Debug.Log("CAN ATTACK");
    }
    public void Death()
    {
        animations.PlayAnimTrigger("Die");
        
        isAlive = false;
        canPause = false;

        //GameOver();
        //Destroy(this.gameObject);
    }

    public void Gravity()
    {
        if (controller.isGrounded && velocity.y < 0)
            velocity.y = 0;

        velocity.y += myStats.Gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }

    public void Move()
    {
        
        if (isRolling) return;
        
        attackAnimTime = _inputVector.magnitude <= 0 ? 0.75f : 0.9f ;

        animations.GetAnimator.SetFloat("SpeedMultiplier", _inputVector.magnitude <= 0 ? 1f : 0.90f);

        if (_inputVector.magnitude <= 0)
        {
            myStats.CanRoll = false;
            return;
        }

        myStats.CanRoll = true;
        
        _inputVector.Normalize();

        controller.Move(_inputVector.ToIso() * myStats.MovementSpeed * Time.deltaTime);

    }

    public void RollAnim()
    {
        Debug.Log("Roll Start");
        if (!myStats.CanRoll)
            return;

        myStats.CanRoll = false;
        isRolling = true;

        animations.PlayAnimTrigger("Roll");


        var r = UnityEngine.Random.Range(1, 3);

        source.pitch = r;

        source.PlayOneShot(rollClip);

        //controller.Move(transform.forward * rollDistance * Time.deltaTime);
        controller.center = newCenterCollider;
        controller.height = newHeight;

        //StartCoroutine(RollCounter());
    }

    void RollAction()
    {
        if (!isRolling)
            return;


        //Debug.Log(transform.forward * rollDistance * Time.deltaTime);

        controller.Move(transform.forward * rollDistance * Time.deltaTime);
    }
  
    public void Rotate()
    {

        if (_inputVector.magnitude <= 0)
            return;

        Quaternion rotation = Quaternion.LookRotation(_inputVector.ToIso());

        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * myStats.SmoothRotValue);
    }

    public void RollReset()
    {
        controller.center = initCenterCollider;
        controller.height = initHeight;

        myStats.CanRoll = true;
        isRolling = false;
    }
    public void Shoot()
    {
       GameObject bullet = gunManager.GetPooledBullet();

       if (bullet == null) return;

       if(myStats.Bullets <= 0)
            return ;

        var r = UnityEngine.Random.Range(1, 3);

        source.pitch = r;

        source.PlayOneShot(shootClip);
       
        //bullet.transform.SetParent(GunManager.instance.barrelPos);

       bullet.transform.position = gunManager.barrelPos.position;
        
       bullet.transform.forward = gunManager.barrelPos.forward;
       //bullet.transform.localRotation = Quaternion.Euler(90, 45, 0);


       bullet.SetActive(true);

    }

    public void TakeDamage(float value)
    {
        myStats.Health -= value;

        if (myStats.Health <= 0)
            Death();
    }

    public void ModifyValues(float value)
    {
        myStats.AttackDamage *= value;

        myStats.MaxHealth *= value;

        myStats.Health = myStats.MaxHealth;

        myStats.Bullets = myStats.MaxBullets;

        healthBar.maxValue = myStats.MaxHealth;

    }

    public void AddBullets(int value)
    {
        if (myStats.Bullets + value >= myStats.MaxBullets)
            myStats.Bullets = myStats.MaxBullets;
        else
            myStats.Bullets += value;
    }

    public void AddHealth(int value)
    {
        if (myStats.Health + value >= myStats.MaxHealth)
            myStats.Health = myStats.MaxHealth;
        else
            myStats.Health += value;
    }
}
