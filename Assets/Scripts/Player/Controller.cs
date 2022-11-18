using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Stats
{

    [SerializeField]
    float maxHealth;
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
   
    public float MaxHealth { get { return maxHealth; } }
    public float Health { get { return health; } set { health = value; } }
    public float AttackDamage { get { return attackDamage; } }
    public float AttackSpeed { get { return attackSpeed; } }
    public float MovementSpeed { get { return movementSpeed; } }
    public float SmoothRotValue { get { return smoothRotValue; } }
    public float Gravity { get { return gravity; } }
    public bool CanAttack {get { return canAttack; } set { canAttack = value; } }
    public bool CanRoll { get { return canRoll; } set { canRoll = value; } }
    

    public void Init()
    {
        this.health = this.maxHealth;
        this.canAttack = true;
        this.canRoll = true;
    }

  
}


[RequireComponent(typeof(CharacterController))]
public class Controller : MonoBehaviour, IController
{
    [SerializeField]
    Stats myStats;

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
        Weapon Melee;
    [SerializeField]
        Weapon Range;

    void Awake()
    {

        myStats.Init();

        _inputActions = new PlayerActions();

        controller = GetComponent<CharacterController>();

        animations = GetComponentInChildren<ControllerAnimations>();

        isRolling = false;

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


        initCenterCollider = controller.center;
        initHeight = controller.height; 
    
    }

 

    private void Update()
    {
        Move();
        Gravity();
        Rotate();
        RollAction();
    

          Debug.DrawRay(transform.position + Vector3.up, transform.forward, Color.red);
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
        Debug.Log("AttackInit");

        if (!myStats.CanAttack) return;

        if (isRolling) return;

        isAttacking = true;

        //if(isRolling) return;

        myStats.CanAttack = false;
        
        animations.PlayAnimTrigger("Attack");
        
        //StartCoroutine(IAttack());
    }

    public void AttackReset()
    {
        myStats.CanAttack = true;

        isAttacking=false;

        Debug.Log("CAN ATTACK");
    }
    public void Death()
    {
        Destroy(this.gameObject);
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
       GameObject bullet = GunManager.instance.GetPooledBullet();

        
       if (bullet == null) return;

       
        //bullet.transform.SetParent(GunManager.instance.barrelPos);

       bullet.transform.position = GunManager.instance.barrelPos.position;
        
       bullet.transform.forward = -GunManager.instance.barrelPos.forward;
       //bullet.transform.localRotation = Quaternion.Euler(90, 45, 0);


       bullet.SetActive(true);

    }

    public void TakeDamage(float value)
    {
        myStats.Health -= value;

        if (myStats.Health <= 0)
            Death();
    }

   
}
