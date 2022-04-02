// GENERATED AUTOMATICALLY FROM 'Assets/InputMaps/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""MovementPrompts"",
            ""id"": ""c6e7e0f8-4400-4073-b249-d279af5b6ca4"",
            ""actions"": [
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""712d5dd9-2945-46ed-9082-3bc47ec1d39c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""2f0ff09e-1219-4374-82d0-2f1a168fc9c2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""aa836bac-be95-40bf-8463-ac4f561e94ad"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Duck"",
                    ""type"": ""Button"",
                    ""id"": ""fc72640f-8d83-4a04-8c2e-45df5f013c8e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""93d8b61c-cab8-496d-b830-11416f9347d8"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c4665df0-dede-4932-bbf9-8af10d60a8ce"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""32c53b07-6a51-4e12-920f-aedf81804ba7"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3837530f-5f0d-4152-ad5d-893d0f7b2004"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f2f9fdc3-88d6-494a-8720-eb20c13366d0"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""93f107b9-6d77-4af9-8041-4fd87360142f"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""49135315-80c3-49f5-a210-a364d5da0fd5"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e1c6b842-654b-48ae-bd90-60c3fc06e27a"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Duck"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0d8ace68-ad53-403b-bfe0-a3d1e53b421d"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Duck"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // MovementPrompts
        m_MovementPrompts = asset.FindActionMap("MovementPrompts", throwIfNotFound: true);
        m_MovementPrompts_Right = m_MovementPrompts.FindAction("Right", throwIfNotFound: true);
        m_MovementPrompts_Left = m_MovementPrompts.FindAction("Left", throwIfNotFound: true);
        m_MovementPrompts_Jump = m_MovementPrompts.FindAction("Jump", throwIfNotFound: true);
        m_MovementPrompts_Duck = m_MovementPrompts.FindAction("Duck", throwIfNotFound: true);
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

    // MovementPrompts
    private readonly InputActionMap m_MovementPrompts;
    private IMovementPromptsActions m_MovementPromptsActionsCallbackInterface;
    private readonly InputAction m_MovementPrompts_Right;
    private readonly InputAction m_MovementPrompts_Left;
    private readonly InputAction m_MovementPrompts_Jump;
    private readonly InputAction m_MovementPrompts_Duck;
    public struct MovementPromptsActions
    {
        private @Controls m_Wrapper;
        public MovementPromptsActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Right => m_Wrapper.m_MovementPrompts_Right;
        public InputAction @Left => m_Wrapper.m_MovementPrompts_Left;
        public InputAction @Jump => m_Wrapper.m_MovementPrompts_Jump;
        public InputAction @Duck => m_Wrapper.m_MovementPrompts_Duck;
        public InputActionMap Get() { return m_Wrapper.m_MovementPrompts; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementPromptsActions set) { return set.Get(); }
        public void SetCallbacks(IMovementPromptsActions instance)
        {
            if (m_Wrapper.m_MovementPromptsActionsCallbackInterface != null)
            {
                @Right.started -= m_Wrapper.m_MovementPromptsActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_MovementPromptsActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_MovementPromptsActionsCallbackInterface.OnRight;
                @Left.started -= m_Wrapper.m_MovementPromptsActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_MovementPromptsActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_MovementPromptsActionsCallbackInterface.OnLeft;
                @Jump.started -= m_Wrapper.m_MovementPromptsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_MovementPromptsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_MovementPromptsActionsCallbackInterface.OnJump;
                @Duck.started -= m_Wrapper.m_MovementPromptsActionsCallbackInterface.OnDuck;
                @Duck.performed -= m_Wrapper.m_MovementPromptsActionsCallbackInterface.OnDuck;
                @Duck.canceled -= m_Wrapper.m_MovementPromptsActionsCallbackInterface.OnDuck;
            }
            m_Wrapper.m_MovementPromptsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Duck.started += instance.OnDuck;
                @Duck.performed += instance.OnDuck;
                @Duck.canceled += instance.OnDuck;
            }
        }
    }
    public MovementPromptsActions @MovementPrompts => new MovementPromptsActions(this);
    public interface IMovementPromptsActions
    {
        void OnRight(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnDuck(InputAction.CallbackContext context);
    }
}
