using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour 
{
    [SerializeField] float health;
    [SerializeField] Transform target;
    [SerializeField] float gravity;

    CharacterController controller;

    Vector3 velocity;
    NavMeshAgent agent;

    public NavMeshAgent GetAgent { get => agent; }

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        agent.SetDestination(target.position);
        //Gravity();
        Debug.Log(agent.velocity.normalized.magnitude);
    
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
