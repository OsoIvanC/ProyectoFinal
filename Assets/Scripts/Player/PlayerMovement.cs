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

    Vector3 velocity;    
    CharacterController controller;
    Camera cam;
    private void Awake()
    {
        cam = Camera.main;
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
        Rotate();
        Gravity();
    }

    private void Move()
    {
        var targetVector = new Vector3(InputHandler._instance._inputVector.x,0, InputHandler._instance._inputVector.y);
        controller.Move(targetVector * movementSpeed * Time.deltaTime);
    }

    private void Rotate()
    {
        Ray ray = cam.ScreenPointToRay(InputHandler._instance._mousePosition);

        if(Physics.Raycast(ray,out RaycastHit hitInfo,maxDistance:500f))
        {
            var target = hitInfo.point;
            target.y = gfxTransform.position.y;
            gfxTransform.LookAt(target);

            //gfxTransform.eulerAngles = new Vector3(gfxTransform.eulerAngles.x, (Mathf.Round(gfxTransform.eulerAngles.y / angleClamp) * angleClamp), gfxTransform.eulerAngles.z);

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
