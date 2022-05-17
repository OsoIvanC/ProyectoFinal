using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        var targetVector =  new Vector3();
        
        if (InputHandler._instance._inputVector.x > 0)
        {
            targetVector = transform.right;
        }

        if (InputHandler._instance._inputVector.x < 0)
        {
            targetVector = -transform.right;
        }

        if (InputHandler._instance._inputVector.y > 0)
        {
            targetVector = transform.forward;
        }

        if (InputHandler._instance._inputVector.y < 0)
        {
            targetVector = -transform.forward;
        }
        if (InputHandler._instance._inputVector.x == 0 && InputHandler._instance._inputVector.y == 0)
        {
            targetVector = Vector3.zero;
        }



        targetVector = transform.InverseTransformDirection(targetVector);

        animator.SetFloat("X", targetVector.x,0.05f,Time.deltaTime);
        animator.SetFloat("Y", targetVector.z,0.05f, Time.deltaTime);
    }

    
}
