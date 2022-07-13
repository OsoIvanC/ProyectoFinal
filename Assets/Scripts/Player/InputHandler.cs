using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public static InputHandler _instance;

    public PlayerActions actions { get; private set; }

    public Vector3 _inputVector { get; private set; }
    public bool _isShooting { get; private set; }

    public Vector2 _mousePosition { get; private set; }

    private void Awake()
    {
        _instance = this;

        actions = new PlayerActions();
        //WALK ACTION
        actions.Movement.WALK.performed += ctx => _inputVector = new Vector3(ctx.ReadValue<Vector2>().x,0,ctx.ReadValue<Vector2>().y).normalized;
        actions.Movement.WALK.canceled += _ => _inputVector = Vector2.zero;


        //LOOK ACTION
        actions.Movement.LOOK.performed += ctx => { _mousePosition = ctx.ReadValue<Vector2>(); };

        //SHOOT ACTION
        //actions.Interactions.Shoot.performed += ctx => _isShooting = ctx.ReadValue<bool>();
        //actions.Interactions.Shoot.canceled += _ => _isShooting = false;

    }

    private void OnEnable()
    {
        actions.Interactions.Enable();
        actions.Movement.Enable();
    }

    private void OnDisable()
    {
        actions.Interactions.Disable();
        actions.Movement.Disable();
    }
}
