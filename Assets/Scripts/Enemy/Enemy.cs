using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour 
{
    [SerializeField] float health;
    [SerializeField] Transform target;
    [SerializeField] Transform attackPoint;
    [SerializeField] float damage;
    [SerializeField] float attackRadius;
    [SerializeField] LayerMask mask;
    [SerializeField] float attackRate;

    bool canAttack;
    NavMeshAgent agent;

    public NavMeshAgent GetAgent { get { return agent; } }
    public float GetAttackRate { get { return attackRate; } }


    void OnDrawGizmosSelected()
    {
        // Draw a red sphere at the transform's position
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }

    private void Awake()
    {
        canAttack = true;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {

        if (agent.steeringTarget != null)
           agent.SetDestination(target.position);

       if(Vector3.Distance(transform.position,agent.steeringTarget) < agent.stoppingDistance && canAttack)
        {

            Debug.Log("Attack");
            StartCoroutine( AttackC());
        }
        
    }

    public void TakeDamage(float value)
    {
        health -= value;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator AttackC()
    {
        canAttack = false;
        //Debug.Log("Attacking");
        
        yield return new WaitForSeconds(0.867f + attackRate);
        canAttack = true;
    }

    public void EnemyAttack()
    {
        Collider[] targets = Physics.OverlapSphere(attackPoint.position, attackRadius, mask);

        if(targets.Length <= 0)
            return;

        targets[0].GetComponent<PlayerManager>().TakeDamage(damage);
    }
  
}
