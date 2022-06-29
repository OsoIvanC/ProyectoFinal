using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float movementSpeed;
    [SerializeField]
    Transform gfxTransform;
    [SerializeField]
    float gravity = -9.81f;
    [SerializeField]
    float smoothRotValue;
    public Vector3 direction { get; private set; }
    Vector3 velocity;    
    CharacterController controller;
    Camera cam;

    float hitDistance = 50f;
    private void Awake()
    {
        cam = Camera.main;
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
        //Rotate();
        MouseRotation();
        Gravity();
    }

    private void Move()
    {
        direction =  InputHandler._instance._inputVector.ToIso();

        if (direction.magnitude <= 0)
            return;

        controller.Move(direction * movementSpeed * Time.deltaTime);
        
    }

    private void Rotate()
    {
        if (direction.magnitude <= 0)
            return;

        Quaternion rotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.Slerp(transform.rotation,rotation, Time.deltaTime * smoothRotValue);
      
    }

    void MouseRotation()
    {
        var ray = Camera.main.ScreenPointToRay(InputHandler._instance._mousePosition);

        Plane p = new Plane(Vector3.up, transform.position);

        if(p.Raycast(ray,out float hitDistance))
        {
            var pointToLook = ray.GetPoint(hitDistance);
            //Debug.DrawLine(ray.origin, pointToLook, Color.cyan);
            var rotateTowards = new Vector3(pointToLook.x,transform.position.y, pointToLook.z);
            transform.LookAt(rotateTowards);
        }
    }

    void Gravity()
    {
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
