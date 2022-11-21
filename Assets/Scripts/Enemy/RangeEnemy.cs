using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum State
{
    IDLE,
    ATTACKING
}
public class RangeEnemy : MonoBehaviour
{
    [SerializeField]
    float attackRange;

    [SerializeField]
    LayerMask playerMask;

    [SerializeField]
    State state;

    [SerializeField]
    Transform player;

    private void Awake()
    {
        state = State.IDLE;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
    void CheckAttackRange()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRange,playerMask);
        
        if (hitColliders.Length <= 0)
        {
            state = State.IDLE;
            player = null;
            return;
        }
        else
            state = State.ATTACKING;

        player = hitColliders[0].transform;

        foreach (var hitCollider in hitColliders)
        {
            Debug.Log("Tower Attacking");
        }
    }

    private void LateUpdate()
    {
        CheckAttackRange();
    }
}
