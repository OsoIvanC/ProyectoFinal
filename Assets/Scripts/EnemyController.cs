using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OsoScripts.Base;
using OsoScripts.Player;

public enum EnmeyState
{
    IDLE,
    FOLLOW,
    ATTACK,
    DIE
}
public class EnemyController : MonoBehaviour
{
    [Header("Stats")]
    public UnitStats stats;

    [SerializeField]
    float turnSpeed;
    [SerializeField]
    EnmeyState myState;

    [SerializeField]
    Transform player;

    [SerializeField]
    LayerMask playerMask;

    CharacterController controller;
    Animator animator;
    Vector3 velocity;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        Look();
        Gravity();
    }

    void Move()
    {
        if (Vector2.Distance(transform.position, player.position) < stats.attackRange + 1)
        {
            Attack();
        }
        controller.Move(transform.forward * stats.movementSpeed * Time.deltaTime);
    }


    void Attack()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, stats.attackRange + 1,playerMask);
        foreach (var hitCollider in hitColliders)
        {
            hitCollider.GetComponent<PlayerController>().myStats.health -= stats.attackDamage;
        }
        animator.SetTrigger("Attack");
    }
    void Look()
    {
        var pPos = new Vector3(player.position.x,0,player.position.z);
        var mPos = new Vector3(transform.position.x, 0, transform.position.z);
        
        var toPlayer = pPos - mPos;

        var rot = Quaternion.LookRotation(toPlayer);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, turnSpeed * Time.deltaTime);

    }

    void Gravity()
    {
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += stats.gravity * Time.deltaTime;


        controller.Move(velocity * Time.deltaTime);
    }

   
}
