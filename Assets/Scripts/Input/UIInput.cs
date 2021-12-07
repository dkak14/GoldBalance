// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/UIInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @UIInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @UIInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""UIInput"",
    ""maps"": [
        {
            ""name"": ""KeyBoard"",
            ""id"": ""c28d6092-a0bb-4088-baff-ccdc699f3e94"",
            ""actions"": [
                {
                    ""name"": ""ESC"",
                    ""type"": ""Button"",
                    ""id"": ""041322de-b750-445e-a22f-aca99b3b4f28"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""96171d33-59b0-4a79-9cb0-0af37c803b3a"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ESC"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Mouse"",
            ""id"": ""3a53fc49-3d8c-47bd-9783-db46ae0e05ac"",
            ""actions"": [
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""7f6d9847-2e2a-487c-8598-1a89c7c018e0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""defb752b-1a92-4ae2-a4f8-9326763dbe9a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Middle"",
                    ""type"": ""Button"",
                    ""id"": ""51d44003-20f1-4232-9191-a1d3aa7fc52c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""70a3c67f-d81f-4bdf-b037-3d786d2c3cf3"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8ae4a5e6-4316-4e6d-9dfa-86495472c05b"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5129f922-9225-4325-b193-c3b792a13351"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Middle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // KeyBoard
        m_KeyBoard = asset.FindActionMap("KeyBoard", throwIfNotFound: true);
        m_KeyBoard_ESC = m_KeyBoard.FindAction("ESC", throwIfNotFound: true);
        // Mouse
        m_Mouse = asset.FindActionMap("Mouse", throwIfNotFound: true);
        m_Mouse_Left = m_Mouse.FindAction("Left", throwIfNotFound: true);
        m_Mouse_Right = m_Mouse.FindAction("Right", throwIfNotFound: true);
        m_Mouse_Middle = m_Mouse.FindAction("Middle", throwIfNotFound: true);
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

    // KeyBoard
    private readonly InputActionMap m_KeyBoard;
    private IKeyBoardActions m_KeyBoardActionsCallbackInterface;
    private readonly InputAction m_KeyBoard_ESC;
    public struct KeyBoardActions
    {
        private @UIInput m_Wrapper;
        public KeyBoardActions(@UIInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @ESC => m_Wrapper.m_KeyBoard_ESC;
        public InputActionMap Get() { return m_Wrapper.m_KeyBoard; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KeyBoardActions set) { return set.Get(); }
        public void SetCallbacks(IKeyBoardActions instance)
        {
            if (m_Wrapper.m_KeyBoardActionsCallbackInterface != null)
            {
                @ESC.started -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnESC;
                @ESC.performed -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnESC;
                @ESC.canceled -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnESC;
            }
            m_Wrapper.m_KeyBoardActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ESC.started += instance.OnESC;
                @ESC.performed += instance.OnESC;
                @ESC.canceled += instance.OnESC;
            }
        }
    }
    public KeyBoardActions @KeyBoard => new KeyBoardActions(this);

    // Mouse
    private readonly InputActionMap m_Mouse;
    private IMouseActions m_MouseActionsCallbackInterface;
    private readonly InputAction m_Mouse_Left;
    private readonly InputAction m_Mouse_Right;
    private readonly InputAction m_Mouse_Middle;
    public struct MouseActions
    {
        private @UIInput m_Wrapper;
        public MouseActions(@UIInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Left => m_Wrapper.m_Mouse_Left;
        public InputAction @Right => m_Wrapper.m_Mouse_Right;
        public InputAction @Middle => m_Wrapper.m_Mouse_Middle;
        public InputActionMap Get() { return m_Wrapper.m_Mouse; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MouseActions set) { return set.Get(); }
        public void SetCallbacks(IMouseActions instance)
        {
            if (m_Wrapper.m_MouseActionsCallbackInterface != null)
            {
                @Left.started -= m_Wrapper.m_MouseActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_MouseActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_MouseActionsCallbackInterface.OnLeft;
                @Right.started -= m_Wrapper.m_MouseActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_MouseActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_MouseActionsCallbackInterface.OnRight;
                @Middle.started -= m_Wrapper.m_MouseActionsCallbackInterface.OnMiddle;
                @Middle.performed -= m_Wrapper.m_MouseActionsCallbackInterface.OnMiddle;
                @Middle.canceled -= m_Wrapper.m_MouseActionsCallbackInterface.OnMiddle;
            }
            m_Wrapper.m_MouseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
                @Middle.started += instance.OnMiddle;
                @Middle.performed += instance.OnMiddle;
                @Middle.canceled += instance.OnMiddle;
            }
        }
    }
    public MouseActions @Mouse => new MouseActions(this);
    public interface IKeyBoardActions
    {
        void OnESC(InputAction.CallbackContext context);
    }
    public interface IMouseActions
    {
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnMiddle(InputAction.CallbackContext context);
    }
}
