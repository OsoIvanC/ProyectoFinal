using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour 
{
    [SerializeField] float health;
    [SerializeField] Transform target;
   
    NavMeshAgent agent;

    public NavMeshAgent GetAgent { get => agent; }

    private void Awake()
    {

        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        agent.SetDestination(target.position);
        //Gravity();
        Debug.Log(agent.velocity.magnitude / agent.desiredVelocity.magnitude);
    
    }

    public void TakeDamage(float value)
    {
        health -= value;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
  
}
