using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;
    PlayerMovement movement;
    

    private void Awake()
    {
        animator = GetComponent<Animator>();
        movement = GetComponentInParent<PlayerMovement>();
    }

    private void Update()
    {
        var direction = InputHandler._instance._inputVector.ToIso();

     
        direction = transform.InverseTransformDirection(direction);

        direction.Normalize();
        animator.SetFloat("X", direction.x,0.05f,Time.deltaTime);
        animator.SetFloat("Z", direction.z,0.05f,Time.deltaTime);
    }

    
}
