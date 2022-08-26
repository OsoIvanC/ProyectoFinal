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
   
    public float MaxHealth { get { return maxHealth; } }
    public float Health { get { return health; } set { health = value; } }
    public float AttackDamage { get { return attackDamage; } }
    public float AttackSpeed { get { return attackSpeed; } }
    public float MovementSpeed { get { return movementSpeed; } }
    public float SmoothRotValue { get { return smoothRotValue; } }
    public float Gravity { get { return gravity; } }
    public bool CanAttack {get { return canAttack; } set { canAttack = value; } }
    

    public void Init()
    {
        this.health = this.maxHealth;
        this.canAttack = true;
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

    void Awake()
    {

        myStats.Init();

        _inputActions = new PlayerActions();

        controller = GetComponent<CharacterController>();

        animations = GetComponentInChildren<ControllerAnimations>();

        //MOVE INPUT
        _inputActions.Movement.WALK.performed += ctx => _inputVector = new Vector3(ctx.ReadValue<Vector2>().x, 0, ctx.ReadValue<Vector2>().y);
        _inputActions.Movement.WALK.canceled += _ => _inputVector = Vector3.zero;

        //ATTACK INPUT
        _inputActions.Interactions.Attack.started += _ => Attack();
    
    }

 

    private void Update()
    {
        Move();
        Gravity();
        Rotate();
    
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

        StartCoroutine(IAttack());
    }

    IEnumerator IAttack()
    {
        myStats.CanAttack = false;
        animations.PlayAnimTrigger("Attack");
        yield return new WaitForSecondsRealtime(attackAnimTime);
        myStats.CanAttack = true;
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
        
        attackAnimTime = _inputVector.magnitude <= 0 ? 0.75f : 0.9f ;

        animations.GetAnimator.SetFloat("SpeedMultiplier", _inputVector.magnitude <= 0 ? 1f : 0.90f);

        if (_inputVector.magnitude <= 0) return;
        _inputVector.Normalize();

        controller.Move(_inputVector.ToIso() * myStats.MovementSpeed * Time.deltaTime);

    }

    public void Roll()
    {

    }

    public void Rotate()
    {

        if (_inputVector.magnitude <= 0)
            return;

        Quaternion rotation = Quaternion.LookRotation(_inputVector.ToIso());

        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * myStats.SmoothRotValue);
    }

    public void Shoot()
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(float value)
    {
        myStats.Health -= value;

        if (myStats.Health <= 0)
            Death();
    }

   
}
