using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public static InputHandler _instance;

    public PlayerActions actions { get; private set; }

    public Vector2 _inputVector { get; private set; }
    public bool _isShooting { get; private set; }

    public Vector2 _mousePosition { get; private set; }

    private void Awake()
    {
        _instance = this;

        actions = new PlayerActions();
        //WALK ACTION
        actions.Movement.WALK.performed += ctx => _inputVector = ctx.ReadValue<Vector2>();
        actions.Movement.WALK.canceled += _ => _inputVector = Vector2.zero;

        //SHOOT ACTION
        //actions.Interactions.Shoot.performed += ctx => _isShooting = ctx.ReadValue<bool>();
        //actions.Interactions.Shoot.canceled += _ => _isShooting = false;

    }

    private void Update()
    {
        _mousePosition = actions.Movement.LOOK.ReadValue<Vector2>();
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
