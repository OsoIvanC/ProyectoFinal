//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/InputSystem/PlayerActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerActions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerActions"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""4e1e2a98-6843-4a3c-85db-37122f36204d"",
            ""actions"": [
                {
                    ""name"": ""WALK"",
                    ""type"": ""Value"",
                    ""id"": ""4b01a9e6-a3fe-4d04-bce4-938fa9dea9e9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""JUMP"",
                    ""type"": ""Button"",
                    ""id"": ""4e8a0828-f380-48da-b54d-7ba20de8bbb7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""DASH"",
                    ""type"": ""Button"",
                    ""id"": ""5b39485f-256b-457e-b017-b1c4d8574788"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LOOK"",
                    ""type"": ""Value"",
                    ""id"": ""e5055867-5068-45e4-9601-f6b4675a64a3"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""dcf6fd3c-d68f-4e82-8090-6deaeddb5182"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""JUMP"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""142b0a8b-3655-4725-a55f-a72372976ca9"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""DASH"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8a43cffe-20aa-400a-a5b9-8a89ec287708"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""WALK"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""3fcf1b97-52fd-486f-95fe-9741ebe60a56"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WALK"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d4ce51ed-359d-4e15-b0b4-a70ee5d4c2ec"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""WALK"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""7b8b33ec-385f-4ae4-8e12-763b655130ec"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""WALK"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""577982a2-a2a4-47fc-9fea-2e6859f0d76f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""WALK"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""3b7df945-ccdd-40ec-88e0-d70f8dd9e975"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""WALK"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e35533e9-4697-4300-9bf5-131c298d1395"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LOOK"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Interactions"",
            ""id"": ""583e8a9f-08dc-437a-819d-395f425e4822"",
            ""actions"": [
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""5fdce726-4b1e-4727-81de-bd2d3d902099"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""3f6e792a-4062-4a4e-8e5b-ff8fb12addbb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Melee"",
                    ""type"": ""Value"",
                    ""id"": ""eca764ff-ac41-4e2b-8453-0d437eb18dba"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""SingleShot"",
                    ""type"": ""Value"",
                    ""id"": ""0fa2c6c3-f26d-4e45-abb2-45c9ea4d8b65"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Automatic"",
                    ""type"": ""Value"",
                    ""id"": ""097ef72a-0571-426a-a3fa-e5a3299eccd8"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""346b8de5-ac25-425c-8cdc-d8a352e0d058"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c95db619-6f26-45cd-8851-6921eee7b295"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""71328b03-2295-4887-83a2-57c973b94a7d"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Melee"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4161f221-c297-401b-ac64-4b27d61ca989"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SingleShot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f2d85650-5fa5-4fe7-9230-6db70bd0bbea"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Automatic"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Player"",
            ""bindingGroup"": ""Player"",
            ""devices"": []
        }
    ]
}");
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_WALK = m_Movement.FindAction("WALK", throwIfNotFound: true);
        m_Movement_JUMP = m_Movement.FindAction("JUMP", throwIfNotFound: true);
        m_Movement_DASH = m_Movement.FindAction("DASH", throwIfNotFound: true);
        m_Movement_LOOK = m_Movement.FindAction("LOOK", throwIfNotFound: true);
        // Interactions
        m_Interactions = asset.FindActionMap("Interactions", throwIfNotFound: true);
        m_Interactions_Attack = m_Interactions.FindAction("Attack", throwIfNotFound: true);
        m_Interactions_Interact = m_Interactions.FindAction("Interact", throwIfNotFound: true);
        m_Interactions_Melee = m_Interactions.FindAction("Melee", throwIfNotFound: true);
        m_Interactions_SingleShot = m_Interactions.FindAction("SingleShot", throwIfNotFound: true);
        m_Interactions_Automatic = m_Interactions.FindAction("Automatic", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Movement
    private readonly InputActionMap m_Movement;
    private IMovementActions m_MovementActionsCallbackInterface;
    private readonly InputAction m_Movement_WALK;
    private readonly InputAction m_Movement_JUMP;
    private readonly InputAction m_Movement_DASH;
    private readonly InputAction m_Movement_LOOK;
    public struct MovementActions
    {
        private @PlayerActions m_Wrapper;
        public MovementActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @WALK => m_Wrapper.m_Movement_WALK;
        public InputAction @JUMP => m_Wrapper.m_Movement_JUMP;
        public InputAction @DASH => m_Wrapper.m_Movement_DASH;
        public InputAction @LOOK => m_Wrapper.m_Movement_LOOK;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void SetCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterface != null)
            {
                @WALK.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnWALK;
                @WALK.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnWALK;
                @WALK.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnWALK;
                @JUMP.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnJUMP;
                @JUMP.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnJUMP;
                @JUMP.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnJUMP;
                @DASH.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnDASH;
                @DASH.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnDASH;
                @DASH.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnDASH;
                @LOOK.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnLOOK;
                @LOOK.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnLOOK;
                @LOOK.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnLOOK;
            }
            m_Wrapper.m_MovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @WALK.started += instance.OnWALK;
                @WALK.performed += instance.OnWALK;
                @WALK.canceled += instance.OnWALK;
                @JUMP.started += instance.OnJUMP;
                @JUMP.performed += instance.OnJUMP;
                @JUMP.canceled += instance.OnJUMP;
                @DASH.started += instance.OnDASH;
                @DASH.performed += instance.OnDASH;
                @DASH.canceled += instance.OnDASH;
                @LOOK.started += instance.OnLOOK;
                @LOOK.performed += instance.OnLOOK;
                @LOOK.canceled += instance.OnLOOK;
            }
        }
    }
    public MovementActions @Movement => new MovementActions(this);

    // Interactions
    private readonly InputActionMap m_Interactions;
    private IInteractionsActions m_InteractionsActionsCallbackInterface;
    private readonly InputAction m_Interactions_Attack;
    private readonly InputAction m_Interactions_Interact;
    private readonly InputAction m_Interactions_Melee;
    private readonly InputAction m_Interactions_SingleShot;
    private readonly InputAction m_Interactions_Automatic;
    public struct InteractionsActions
    {
        private @PlayerActions m_Wrapper;
        public InteractionsActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Attack => m_Wrapper.m_Interactions_Attack;
        public InputAction @Interact => m_Wrapper.m_Interactions_Interact;
        public InputAction @Melee => m_Wrapper.m_Interactions_Melee;
        public InputAction @SingleShot => m_Wrapper.m_Interactions_SingleShot;
        public InputAction @Automatic => m_Wrapper.m_Interactions_Automatic;
        public InputActionMap Get() { return m_Wrapper.m_Interactions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InteractionsActions set) { return set.Get(); }
        public void SetCallbacks(IInteractionsActions instance)
        {
            if (m_Wrapper.m_InteractionsActionsCallbackInterface != null)
            {
                @Attack.started -= m_Wrapper.m_InteractionsActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_InteractionsActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_InteractionsActionsCallbackInterface.OnAttack;
                @Interact.started -= m_Wrapper.m_InteractionsActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_InteractionsActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_InteractionsActionsCallbackInterface.OnInteract;
                @Melee.started -= m_Wrapper.m_InteractionsActionsCallbackInterface.OnMelee;
                @Melee.performed -= m_Wrapper.m_InteractionsActionsCallbackInterface.OnMelee;
                @Melee.canceled -= m_Wrapper.m_InteractionsActionsCallbackInterface.OnMelee;
                @SingleShot.started -= m_Wrapper.m_InteractionsActionsCallbackInterface.OnSingleShot;
                @SingleShot.performed -= m_Wrapper.m_InteractionsActionsCallbackInterface.OnSingleShot;
                @SingleShot.canceled -= m_Wrapper.m_InteractionsActionsCallbackInterface.OnSingleShot;
                @Automatic.started -= m_Wrapper.m_InteractionsActionsCallbackInterface.OnAutomatic;
                @Automatic.performed -= m_Wrapper.m_InteractionsActionsCallbackInterface.OnAutomatic;
                @Automatic.canceled -= m_Wrapper.m_InteractionsActionsCallbackInterface.OnAutomatic;
            }
            m_Wrapper.m_InteractionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Melee.started += instance.OnMelee;
                @Melee.performed += instance.OnMelee;
                @Melee.canceled += instance.OnMelee;
                @SingleShot.started += instance.OnSingleShot;
                @SingleShot.performed += instance.OnSingleShot;
                @SingleShot.canceled += instance.OnSingleShot;
                @Automatic.started += instance.OnAutomatic;
                @Automatic.performed += instance.OnAutomatic;
                @Automatic.canceled += instance.OnAutomatic;
            }
        }
    }
    public InteractionsActions @Interactions => new InteractionsActions(this);
    private int m_PlayerSchemeIndex = -1;
    public InputControlScheme PlayerScheme
    {
        get
        {
            if (m_PlayerSchemeIndex == -1) m_PlayerSchemeIndex = asset.FindControlSchemeIndex("Player");
            return asset.controlSchemes[m_PlayerSchemeIndex];
        }
    }
    public interface IMovementActions
    {
        void OnWALK(InputAction.CallbackContext context);
        void OnJUMP(InputAction.CallbackContext context);
        void OnDASH(InputAction.CallbackContext context);
        void OnLOOK(InputAction.CallbackContext context);
    }
    public interface IInteractionsActions
    {
        void OnAttack(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnMelee(InputAction.CallbackContext context);
        void OnSingleShot(InputAction.CallbackContext context);
        void OnAutomatic(InputAction.CallbackContext context);
    }
}
