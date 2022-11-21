using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy:MonoBehaviour
{
    NavMeshAgent agent;

    [SerializeField]
    float attackRange;

    [SerializeField]
    Transform player;

    [SerializeField]
    LayerMask layerMask;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void CheckAttack()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        Debug.DrawRay(transform.position + new Vector3(0, 0.5f, 0), fwd * attackRange,Color.red);

        if (Physics.Raycast(transform.position + new Vector3(0, 0.5f, 0) , fwd , attackRange, layerMask))
            Debug.Log("Melee Attacking");
            
    }

    private void LateUpdate()
    {
        CheckAttack();
    }

}
