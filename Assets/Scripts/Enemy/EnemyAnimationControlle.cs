using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationControlle : MonoBehaviour
{
    Animator animator;
    Enemy enemy;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        enemy = GetComponentInParent<Enemy>();     
    }

    private void Update()
    {
        animator.SetFloat("Speed",enemy.GetAgent.velocity.normalized.magnitude);
    }

  
}
