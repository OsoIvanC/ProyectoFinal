using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationControlle : MonoBehaviour
{
    Animator animator;
    Enemy enemy;

    bool canAttack;
    private void Awake()
    {
        canAttack = true;
        animator = GetComponent<Animator>();
        enemy = GetComponentInParent<Enemy>();     
    }

    private void Update()
    {
        animator.SetFloat("Speed",enemy.GetAgent.velocity.normalized.magnitude);

        //Debug.Log(Vector3.Distance(transform.position, enemy.GetAgent.steeringTarget));

        if (Vector3.Distance(enemy.transform.position, enemy.GetAgent.steeringTarget) < enemy.GetAgent.stoppingDistance && canAttack)
        {
            StartCoroutine(AttackC());
        }
    }


    IEnumerator AttackC()
    {
        canAttack = false;

        Debug.Log("Animation Attacking");
        animator.SetTrigger("Punch");


        yield return new WaitForSeconds(0.867f + enemy.GetAttackRate);
        canAttack = true;
    }

}
