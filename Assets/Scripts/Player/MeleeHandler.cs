using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeHandler : MonoBehaviour
{
    [SerializeField]
    Animator animator;


    [SerializeField]
    bool canAttack;

    [SerializeField]
    float attackRadius;
    [SerializeField]
    LayerMask mask;
    [SerializeField]
    float damage;
    [SerializeField]
    Transform attackPoint;

    private void Start()
    {
        canAttack = true;
        InputHandler._instance.actions.Interactions.Attack.performed += _ => Attack();
    }

    public void Attack()
    {
        if (!canAttack)
            return;

        StartCoroutine(AttackC());
    }

    IEnumerator AttackC()
    {
        canAttack = false;
        animator.SetTrigger("Punch");
        yield return new WaitForSeconds(0.867f);
        canAttack = true;
    }

    public void PlayerAttack()
    {
        Collider[] targets = Physics.OverlapSphere(attackPoint.position, attackRadius, mask);

        if (targets.Length <= 0)
            return;

        targets[0].GetComponent<Enemy>().TakeDamage(damage);
    }

}
