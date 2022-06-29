using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeHandler : MonoBehaviour
{
    [SerializeField]
    Animator animator;


    [SerializeField]
    bool canAttack;

    private void Start()
    {
        canAttack = true;
        InputHandler._instance.actions.Interactions.Attack.performed += _ => Attack();
    }

    void Attack()
    {
        if (!canAttack)
            return;

        StartCoroutine(AttackC());
    }

    IEnumerator AttackC()
    {
        canAttack = false;
        animator.SetLayerWeight(1, 1);


        yield return new WaitForSeconds(0.867f);

        animator.SetLayerWeight(1, 0);
        canAttack = true;
    }

}
