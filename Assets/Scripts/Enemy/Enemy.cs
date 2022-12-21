using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : EnemyController, IController
{
    NavMeshAgent agent;

    [SerializeField]
    float attackRate;

    [SerializeField]
    Transform player;

    [SerializeField]
    LayerMask layerMask;

    bool isAttacking;

    bool isAlive;

    Animator animator;

    bool canAttack;

    [SerializeField]
    Collider headCollider;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        animator = GetComponent<Animator>();

        canAttack = true;

        player = FindObjectOfType<Controller>().transform;

        agent.stoppingDistance = stats.attackRange;
    }

    private void OnEnable()
    {
        //GetComponent<Collider>().enabled = true;
        isAlive = true;
        GetComponent<NavMeshAgent>().enabled = true;
    }
    void CheckAttack()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        Debug.DrawRay(transform.position + new Vector3(0, 0.5f, 0), fwd * stats.attackRange, Color.red);

        if (Physics.Raycast(transform.position + new Vector3(0, 0.5f, 0), fwd, stats.attackRange, layerMask))
            Attack();
    }

   

    public void Attack()
    {
        if (!canAttack)
            return;

        if(!isAlive)
            return;

        isAttacking = true;

        canAttack = false;

        animator.SetTrigger("Attack");
        
    }

    public void AttackReset()
    {
        canAttack = true;

        isAttacking = false;

        Debug.Log("CAN ATTACK");
    }

    private void Update()
    {

        if (!Controller.isAlive) return;

        if (Controller.pause) return;

        Move();

         Rotate();

         CheckAttack();
    }

    public void TakeDamage(float value)
    {
        stats.health -= value;

        if (stats.health <= 0)
            Death();
    }

    public void Move()
    {
        if (!agent.enabled)
            return;

        //player = FindObjectOfType<Controller>().transform;
        agent.SetDestination(player.position);
    }

    public void Rotate()
    {
        transform.LookAt(player);
    }

    public void Gravity()
    {
        throw new System.NotImplementedException();
    }

    public void Shoot()
    {
        throw new System.NotImplementedException();
    }

    public void TurnOff()
    {
        Controller.score += 10;
        WaveManager.instance.DeleteEnemy(this.gameObject, EnemyType.MELEE);

    }
    public void Death()
    {
        //GetComponent<Collider>().enabled = false;
        isAlive = false;

        GetComponent<NavMeshAgent>().enabled = false;

        
        animator.SetTrigger("Die");

    }

    public void ActivateCollider()
    {
        headCollider.enabled = true;
    }
    public void DeactivateCollider()
    {
        headCollider.enabled = false;
    }

}
