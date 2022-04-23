using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using OsoScripts.Base;
using OsoScripts.Player;

namespace OsoScripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Player Stats")]
        public UnitStats myStats;
        [SerializeField]
        float teleportDistance;
        [SerializeField]
        bool shooting;
        
        [Header("Gun Info")]
        [SerializeField]
        GameObject bulletPrefab;
        [SerializeField]
        Transform barrelPosition;

        CharacterController controller;
        PlayerActions playerActions;
       
        
        Vector3 velocity;
        //Vector3 _input;
        Vector3 mousePos;
        Vector2 moveVector;

        [Header("Extras")]
        [SerializeField]
        float turnSpeed = 360;
        float nextFire;
        [SerializeField]
        Animator animator;

        [Header("Camera")]
        [SerializeField]
        Transform cameraTransform;
        

        [SerializeField]
        Vector3 offset;

        [SerializeField]
        GameObject cube;
        void Awake()
        {
            nextFire = -1f;
            controller = GetComponent<CharacterController>();
            playerActions = new PlayerActions();

            //WALK ACTION
            playerActions.Movement.WALK.performed += ctx => moveVector = ctx.ReadValue<Vector2>().normalized;
            playerActions.Movement.WALK.canceled += _ => moveVector = Vector2.zero;

            //TELEPORT ACTION
            playerActions.Movement.DASH.performed += _ => Teleport();
            
            //SHOOT ACTION
            playerActions.Interactions.Shoot.performed += _ => shooting = true;
            playerActions.Interactions.Shoot.canceled += _ => shooting = false;

            //LOOK ACTION
           

        }

        private void Update()
        {
            Move();
            //Look();
            //Shoot();
            LookMouse();
            Gravity();
        }

        private void LateUpdate()
        {
            CameraFollow();
        }
        void Move()
        {
            float x = moveVector.x;
            float z = moveVector.y;

            Vector3 m = new Vector3();

            if(x > 0)
            {
                m = transform.right;
            }
            if (x < 0)
            {
                m = -transform.right;
            }
            if(z > 0)
            {
                m = transform.forward;
            }
            if(z < 0)
            {
                m = -transform.forward;
                
            }

            animator.SetFloat("X",x);
            animator.SetFloat("Y",z);

            controller.Move( m.normalized * myStats.movementSpeed * Time.deltaTime);
        }

        void Look()
        {

            //if (_input == Vector3.zero)
                //return;
          
            
            //var rot = Quaternion.LookRotation(_input.ToIso(), Vector3.up);

            //transform.rotation = Quaternion.RotateTowards(transform.rotation,rot,turnSpeed * Time.deltaTime);

        }

        void LookMouse()
        {
           
            
            Ray ray = Camera.main.ScreenPointToRay(playerActions.Movement.LOOK.ReadValue<Vector2>());
            RaycastHit hit;


            if (Physics.Raycast(ray, out hit))
            {
                mousePos = new Vector3(hit.point.x, 0, hit.point.z);
            }

            Vector3 mPos = new Vector3(transform.position.x, 0, transform.position.z);
            Vector3 rotPos = mousePos - mPos;
            var rot = Quaternion.LookRotation(rotPos);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, turnSpeed * Time.deltaTime);

        }
        void Gravity()
        {
            if(controller.isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }
            
            velocity.y += myStats.gravity * Time.deltaTime;

            
            controller.Move(velocity * Time.deltaTime);
        }

        void CameraFollow()
        {
            cameraTransform.position = new Vector3(transform.position.x, 0, transform.position.z) + offset;
        }

        void Teleport()
        {
            Debug.Log("Teleport");
            controller.Move(transform.forward * teleportDistance);
        }

        void Shoot()
        {
            if (!shooting)
                return;

            if (Time.time > nextFire)
            {
               nextFire = Time.time + 1 / myStats.attackRate;
               Instantiate(bulletPrefab, barrelPosition.position, barrelPosition.rotation);
               //Instanciar
            }
        }
        private void OnEnable()
        {
            playerActions.Movement.Enable();
            playerActions.Interactions.Enable();
        }

        private void OnDisable()
        {
            playerActions.Movement.Disable();
            playerActions.Interactions.Disable();
        }

    }
}
