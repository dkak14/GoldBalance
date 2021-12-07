// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Axis"",
            ""id"": ""6014b9de-15c0-4488-9ac2-74ceabe743d9"",
            ""actions"": [
                {
                    ""name"": ""Horizontal"",
                    ""type"": ""Button"",
                    ""id"": ""936ee3a1-0df2-4946-8284-16d396efb2d7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Vertical"",
                    ""type"": ""Button"",
                    ""id"": ""f9d7d03a-1045-4a10-8896-5790b32de661"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""f5f80960-46aa-4735-83e0-5816c338f092"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""a0a82892-bfe9-4545-bde2-ab172682adc2"",
                    ""path"": ""<Keyboard>/#(a)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""87debaba-cd92-4fef-a921-1b0a43d5c403"",
                    ""path"": ""<Keyboard>/#(d)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""5b6f0634-71a8-4b32-bedf-3856a89e04f8"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""cd99524c-88b5-4830-af64-d4a286dc196c"",
                    ""path"": ""<Keyboard>/#(s)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""6e07ac61-2004-4738-9e2c-c72d9bfde67b"",
                    ""path"": ""<Keyboard>/#(w)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Mouse"",
            ""id"": ""efd07c67-5325-435e-8d34-6605657da7d9"",
            ""actions"": [
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""a5a2a5a4-9ffa-4224-94bc-bafa55f091c3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""dcdbb226-30b4-48e6-9852-b51e33ff2290"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Middle"",
                    ""type"": ""Button"",
                    ""id"": ""105ccec4-db94-4e8d-ba24-406ecb3e4914"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""79c48d4f-7183-4e37-82f6-95df47e55aa7"",
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
                    ""id"": ""f8e8ae6c-f5c9-4467-bc6a-77271a82784c"",
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
                    ""id"": ""5d98c232-10f9-4627-a16e-6588632e9cc7"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Middle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""KeyBoard"",
            ""id"": ""7f289152-9334-471b-9feb-e2979cc98131"",
            ""actions"": [
                {
                    ""name"": ""Space"",
                    ""type"": ""Button"",
                    ""id"": ""4d03aa10-48c3-4ec6-8a75-6735cacf2c83"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""K"",
                    ""type"": ""Button"",
                    ""id"": ""7aa1b964-4dbe-4cb1-9bbc-37610bd6f713"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""L"",
                    ""type"": ""Button"",
                    ""id"": ""fcaf1eac-1e12-4c0d-8347-cd17915e7e70"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""1"",
                    ""type"": ""Button"",
                    ""id"": ""5659fc7c-7390-4099-81a7-25d64b5d945d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""2"",
                    ""type"": ""Button"",
                    ""id"": ""49fc31ee-1fb8-4d83-b9cf-1a29282337d7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""F"",
                    ""type"": ""Button"",
                    ""id"": ""6feeb2bd-fc73-4826-b9f7-725c01c813af"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""R"",
                    ""type"": ""Button"",
                    ""id"": ""06523324-55a6-46ae-9bf0-0ab56ac99ebf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Q"",
                    ""type"": ""Button"",
                    ""id"": ""aa6cabf5-f794-415a-9bb5-232db5bbd9b1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""S"",
                    ""type"": ""Button"",
                    ""id"": ""1b8f81eb-0ace-4b90-83cb-1ae929c05662"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""W"",
                    ""type"": ""Button"",
                    ""id"": ""89b11f0b-52d1-4042-b163-f471bf2a3216"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2c94ad76-befb-4302-b8ec-9eccb9d7cb08"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Space"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""31f2e568-8419-4d6d-8734-11661105c806"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""K"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""76853797-42bf-4dc1-94e8-8e8e15a590b6"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""L"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a0df30db-aacd-446b-903e-6ec7507730ef"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""36f04730-9ef6-464b-8e41-9e387a585783"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d2dd14cb-7d47-4f36-bf5c-5d1ad02235bb"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""F"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2c396cfd-4fd9-403e-9335-277f6cb3e8e0"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""R"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""265f143a-0b28-4047-8234-2552922d9595"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Q"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""67252a4d-d342-4a79-849d-d55a2dce55aa"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""S"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f4afd018-4793-44db-82b5-65b1def51c22"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""W"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Axis
        m_Axis = asset.FindActionMap("Axis", throwIfNotFound: true);
        m_Axis_Horizontal = m_Axis.FindAction("Horizontal", throwIfNotFound: true);
        m_Axis_Vertical = m_Axis.FindAction("Vertical", throwIfNotFound: true);
        // Mouse
        m_Mouse = asset.FindActionMap("Mouse", throwIfNotFound: true);
        m_Mouse_Left = m_Mouse.FindAction("Left", throwIfNotFound: true);
        m_Mouse_Right = m_Mouse.FindAction("Right", throwIfNotFound: true);
        m_Mouse_Middle = m_Mouse.FindAction("Middle", throwIfNotFound: true);
        // KeyBoard
        m_KeyBoard = asset.FindActionMap("KeyBoard", throwIfNotFound: true);
        m_KeyBoard_Space = m_KeyBoard.FindAction("Space", throwIfNotFound: true);
        m_KeyBoard_K = m_KeyBoard.FindAction("K", throwIfNotFound: true);
        m_KeyBoard_L = m_KeyBoard.FindAction("L", throwIfNotFound: true);
        m_KeyBoard__1 = m_KeyBoard.FindAction("1", throwIfNotFound: true);
        m_KeyBoard__2 = m_KeyBoard.FindAction("2", throwIfNotFound: true);
        m_KeyBoard_F = m_KeyBoard.FindAction("F", throwIfNotFound: true);
        m_KeyBoard_R = m_KeyBoard.FindAction("R", throwIfNotFound: true);
        m_KeyBoard_Q = m_KeyBoard.FindAction("Q", throwIfNotFound: true);
        m_KeyBoard_S = m_KeyBoard.FindAction("S", throwIfNotFound: true);
        m_KeyBoard_W = m_KeyBoard.FindAction("W", throwIfNotFound: true);
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

    // Axis
    private readonly InputActionMap m_Axis;
    private IAxisActions m_AxisActionsCallbackInterface;
    private readonly InputAction m_Axis_Horizontal;
    private readonly InputAction m_Axis_Vertical;
    public struct AxisActions
    {
        private @PlayerInput m_Wrapper;
        public AxisActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Horizontal => m_Wrapper.m_Axis_Horizontal;
        public InputAction @Vertical => m_Wrapper.m_Axis_Vertical;
        public InputActionMap Get() { return m_Wrapper.m_Axis; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AxisActions set) { return set.Get(); }
        public void SetCallbacks(IAxisActions instance)
        {
            if (m_Wrapper.m_AxisActionsCallbackInterface != null)
            {
                @Horizontal.started -= m_Wrapper.m_AxisActionsCallbackInterface.OnHorizontal;
                @Horizontal.performed -= m_Wrapper.m_AxisActionsCallbackInterface.OnHorizontal;
                @Horizontal.canceled -= m_Wrapper.m_AxisActionsCallbackInterface.OnHorizontal;
                @Vertical.started -= m_Wrapper.m_AxisActionsCallbackInterface.OnVertical;
                @Vertical.performed -= m_Wrapper.m_AxisActionsCallbackInterface.OnVertical;
                @Vertical.canceled -= m_Wrapper.m_AxisActionsCallbackInterface.OnVertical;
            }
            m_Wrapper.m_AxisActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Horizontal.started += instance.OnHorizontal;
                @Horizontal.performed += instance.OnHorizontal;
                @Horizontal.canceled += instance.OnHorizontal;
                @Vertical.started += instance.OnVertical;
                @Vertical.performed += instance.OnVertical;
                @Vertical.canceled += instance.OnVertical;
            }
        }
    }
    public AxisActions @Axis => new AxisActions(this);

    // Mouse
    private readonly InputActionMap m_Mouse;
    private IMouseActions m_MouseActionsCallbackInterface;
    private readonly InputAction m_Mouse_Left;
    private readonly InputAction m_Mouse_Right;
    private readonly InputAction m_Mouse_Middle;
    public struct MouseActions
    {
        private @PlayerInput m_Wrapper;
        public MouseActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
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

    // KeyBoard
    private readonly InputActionMap m_KeyBoard;
    private IKeyBoardActions m_KeyBoardActionsCallbackInterface;
    private readonly InputAction m_KeyBoard_Space;
    private readonly InputAction m_KeyBoard_K;
    private readonly InputAction m_KeyBoard_L;
    private readonly InputAction m_KeyBoard__1;
    private readonly InputAction m_KeyBoard__2;
    private readonly InputAction m_KeyBoard_F;
    private readonly InputAction m_KeyBoard_R;
    private readonly InputAction m_KeyBoard_Q;
    private readonly InputAction m_KeyBoard_S;
    private readonly InputAction m_KeyBoard_W;
    public struct KeyBoardActions
    {
        private @PlayerInput m_Wrapper;
        public KeyBoardActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Space => m_Wrapper.m_KeyBoard_Space;
        public InputAction @K => m_Wrapper.m_KeyBoard_K;
        public InputAction @L => m_Wrapper.m_KeyBoard_L;
        public InputAction @_1 => m_Wrapper.m_KeyBoard__1;
        public InputAction @_2 => m_Wrapper.m_KeyBoard__2;
        public InputAction @F => m_Wrapper.m_KeyBoard_F;
        public InputAction @R => m_Wrapper.m_KeyBoard_R;
        public InputAction @Q => m_Wrapper.m_KeyBoard_Q;
        public InputAction @S => m_Wrapper.m_KeyBoard_S;
        public InputAction @W => m_Wrapper.m_KeyBoard_W;
        public InputActionMap Get() { return m_Wrapper.m_KeyBoard; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KeyBoardActions set) { return set.Get(); }
        public void SetCallbacks(IKeyBoardActions instance)
        {
            if (m_Wrapper.m_KeyBoardActionsCallbackInterface != null)
            {
                @Space.started -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnSpace;
                @Space.performed -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnSpace;
                @Space.canceled -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnSpace;
                @K.started -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnK;
                @K.performed -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnK;
                @K.canceled -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnK;
                @L.started -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnL;
                @L.performed -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnL;
                @L.canceled -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnL;
                @_1.started -= m_Wrapper.m_KeyBoardActionsCallbackInterface.On_1;
                @_1.performed -= m_Wrapper.m_KeyBoardActionsCallbackInterface.On_1;
                @_1.canceled -= m_Wrapper.m_KeyBoardActionsCallbackInterface.On_1;
                @_2.started -= m_Wrapper.m_KeyBoardActionsCallbackInterface.On_2;
                @_2.performed -= m_Wrapper.m_KeyBoardActionsCallbackInterface.On_2;
                @_2.canceled -= m_Wrapper.m_KeyBoardActionsCallbackInterface.On_2;
                @F.started -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnF;
                @F.performed -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnF;
                @F.canceled -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnF;
                @R.started -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnR;
                @R.performed -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnR;
                @R.canceled -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnR;
                @Q.started -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnQ;
                @Q.performed -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnQ;
                @Q.canceled -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnQ;
                @S.started -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnS;
                @S.performed -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnS;
                @S.canceled -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnS;
                @W.started -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnW;
                @W.performed -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnW;
                @W.canceled -= m_Wrapper.m_KeyBoardActionsCallbackInterface.OnW;
            }
            m_Wrapper.m_KeyBoardActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Space.started += instance.OnSpace;
                @Space.performed += instance.OnSpace;
                @Space.canceled += instance.OnSpace;
                @K.started += instance.OnK;
                @K.performed += instance.OnK;
                @K.canceled += instance.OnK;
                @L.started += instance.OnL;
                @L.performed += instance.OnL;
                @L.canceled += instance.OnL;
                @_1.started += instance.On_1;
                @_1.performed += instance.On_1;
                @_1.canceled += instance.On_1;
                @_2.started += instance.On_2;
                @_2.performed += instance.On_2;
                @_2.canceled += instance.On_2;
                @F.started += instance.OnF;
                @F.performed += instance.OnF;
                @F.canceled += instance.OnF;
                @R.started += instance.OnR;
                @R.performed += instance.OnR;
                @R.canceled += instance.OnR;
                @Q.started += instance.OnQ;
                @Q.performed += instance.OnQ;
                @Q.canceled += instance.OnQ;
                @S.started += instance.OnS;
                @S.performed += instance.OnS;
                @S.canceled += instance.OnS;
                @W.started += instance.OnW;
                @W.performed += instance.OnW;
                @W.canceled += instance.OnW;
            }
        }
    }
    public KeyBoardActions @KeyBoard => new KeyBoardActions(this);
    public interface IAxisActions
    {
        void OnHorizontal(InputAction.CallbackContext context);
        void OnVertical(InputAction.CallbackContext context);
    }
    public interface IMouseActions
    {
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnMiddle(InputAction.CallbackContext context);
    }
    public interface IKeyBoardActions
    {
        void OnSpace(InputAction.CallbackContext context);
        void OnK(InputAction.CallbackContext context);
        void OnL(InputAction.CallbackContext context);
        void On_1(InputAction.CallbackContext context);
        void On_2(InputAction.CallbackContext context);
        void OnF(InputAction.CallbackContext context);
        void OnR(InputAction.CallbackContext context);
        void OnQ(InputAction.CallbackContext context);
        void OnS(InputAction.CallbackContext context);
        void OnW(InputAction.CallbackContext context);
    }
}
