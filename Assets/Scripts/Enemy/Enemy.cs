using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy:EnemyController,IController
{
    NavMeshAgent agent;


    [SerializeField]
    float attackRate;

    [SerializeField]
    Transform player;

    [SerializeField]
    LayerMask layerMask;

    Animator animator;

    bool canAttack;
    bool allowAttack;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        animator = GetComponent<Animator>();

        allowAttack = true;
        
        agent.stoppingDistance = stats.attackRange;
    }

    bool CheckAttack()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        Debug.DrawRay(transform.position + new Vector3(0, 0.5f, 0), fwd * stats.attackRange,Color.red);

        if (Physics.Raycast(transform.position + new Vector3(0, 0.5f, 0) , fwd , stats.attackRange, layerMask))
            return true;
        
        return false;
    }

    private void LateUpdate()
    {
       canAttack =  CheckAttack();
    }
   
    public void Attack()
    {
        if (!canAttack)
            return;

        if (allowAttack)
            StartCoroutine(AttackCall());
    }
    IEnumerator AttackCall()
    {
        allowAttack = false;

        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(attackRate);

        allowAttack = true;
    }


    private void Update()
    {
        Move();
        
        Rotate();
    }
    
    public void TakeDamage(float value)
    {
        throw new System.NotImplementedException();
    }

    public void Move()
    {
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

    public void Death()
    {
        throw new System.NotImplementedException();
    }
}
