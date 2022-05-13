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
        var _input =  new Vector3(InputHandler._instance._inputVector.x,0, InputHandler._instance._inputVector.y) ;

        if (_input.magnitude > 1.0f)
            _input = _input.normalized;

        _input = transform.InverseTransformDirection(_input);

        animator.SetFloat("X", _input.x,0.05f,Time.deltaTime);
        animator.SetFloat("Y", _input.z,0.05f, Time.deltaTime);
    }

    
}
