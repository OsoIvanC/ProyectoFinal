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
        [Header("Input")]
        PlayerActions actions;


        [Header("Player Variables")]
        [SerializeField] 
        PlayerState state;
        [SerializeField]
        float speed;
        [SerializeField]
        float teleportDistance;
        Vector2 movement;


        [Header("Rotation")]
        [SerializeField]
        float angleRot;
        [SerializeField]
        float turnSpeed;
        float turnSmooth;

        void Awake()
        {
            movement = Vector2.zero;

            actions = new PlayerActions();

            actions.Movement.DASH.performed += _ => Teleport();

            actions.Movement.WALK.performed += ctx => movement = ctx.ReadValue<Vector2>();
            actions.Movement.WALK.canceled += _ => movement = Vector2.zero;
        }

        private void Update()
        {
            Movement(movement);
        }

        void Movement(Vector2 direction)
        {
            direction = direction.normalized;

            if(direction.magnitude <= 0)
            {
                state = PlayerState.IDLE;
        
            }
            else
            {
                state = PlayerState.WALKING;

                Vector3 movDir = new Vector3(direction.x, 0, direction.y);

                Quaternion targetRotation = Quaternion.LookRotation(movDir);
                targetRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, angleRot * Time.deltaTime);

                transform.rotation = targetRotation;
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
  
            }

        }
        void Teleport()
        {
            Vector3 teleportVector = transform.forward * teleportDistance;

            transform.position += teleportVector;
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
