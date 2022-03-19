using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using OsoScripts.Player;

namespace OsoScripts.Player
{
    
    public enum PlayerState
    {
        IDLE,
        ATTACKING,
        FIRING,
        DASHING,
        WALKING,
        DEATH
    }
    public class PlayerController : MonoBehaviour
    {
        PlayerActions actions;
        Vector2 movement;
        Animator animator;

        [SerializeField]
        PlayerState state;
        [SerializeField]
        float speed;
        [SerializeField]
        float angleRot;

        [SerializeField]
        float turnSpeed;

        float turnSmooth;

        void Awake()
        {
            movement = Vector2.zero;

            actions = new PlayerActions();
            animator = GetComponent<Animator>();

            actions.Movement.WALK.performed += ctx => movement = ctx.ReadValue<Vector2>();
            actions.Movement.WALK.canceled += _ => movement = Vector2.zero;
        }

        private void Update()
        {
            Movement(movement);
        }

        void Movement(Vector2 direction)
        {
            if(direction == Vector2.zero)
            {
                state = PlayerState.IDLE;
                animator.SetTrigger("IDLE");
            }
            else
            {
                state = PlayerState.WALKING;

                Vector3 movDir = new Vector3(direction.x, 0, direction.y);

                Quaternion targetRotation = Quaternion.LookRotation(movDir);
                targetRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, angleRot * Time.deltaTime);

                transform.rotation = targetRotation;
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
                animator.SetTrigger("WALKING");
            }

        }
        private void OnEnable()
        {
            actions.Enable();
        }

        private void OnDisable()
        {
            actions.Disable();
        }
    }

}
