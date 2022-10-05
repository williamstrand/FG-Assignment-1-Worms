// GENERATED AUTOMATICALLY FROM 'Assets/Controls/Controls.inputactions'

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
            ""name"": ""Game"",
            ""id"": ""26c699fa-011f-4714-9c44-2223983b8d2c"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""08b04e9d-e1e0-404c-a57d-1b66bfc103df"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""c8369d47-287c-4cb4-9383-2c0680787c86"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Debug"",
                    ""type"": ""Button"",
                    ""id"": ""578202ca-3be5-4ebc-8773-cc6523fc4d8e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire Down"",
                    ""type"": ""Button"",
                    ""id"": ""dd40e338-7bbf-4b45-9bf1-2007d38aacf0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire Up"",
                    ""type"": ""Button"",
                    ""id"": ""8489a44f-a9bc-4298-b82a-da02db1719a4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Mode Change"",
                    ""type"": ""Button"",
                    ""id"": ""a5130940-efb7-4aa5-8203-fd82b6720ee2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""End Turn"",
                    ""type"": ""Button"",
                    ""id"": ""545407bd-5a73-4b69-b53c-e93be67cbe3e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Switch Weapon"",
                    ""type"": ""Button"",
                    ""id"": ""c55860a3-da4a-4b1f-bcdb-5c899792e457"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""d77c6aba-5274-49bb-bc4a-a9966548353f"",
                    ""path"": ""2DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1c83f6f1-d75b-4049-9294-4088376a7ed6"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""621810e6-05d2-4758-9f4e-1f56aa6012dd"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b816109c-2117-42e5-bcc6-81064841ef01"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a12f463c-5024-40ec-a198-a97354152dd1"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""209b721c-19b3-4fb0-8dd9-88c96f3e5e13"",
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
                    ""id"": ""6d79f03d-84cb-4fa1-b42f-c56581320bc9"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Debug"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a05949a3-6d6e-4b1b-8781-11ac74af05d9"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7896013c-bd6b-4dc3-8a76-a0d71dff26ed"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mode Change"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ffa23d0a-a3f8-4dae-9da1-ddb9ba1a042b"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a1d15c3d-3fe1-40f9-87f6-5f8b8b0d9e59"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""End Turn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5c3bcf13-eded-46dc-b2fd-290dbcbd09a0"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Switch Weapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Game
        m_Game = asset.FindActionMap("Game", throwIfNotFound: true);
        m_Game_Move = m_Game.FindAction("Move", throwIfNotFound: true);
        m_Game_Jump = m_Game.FindAction("Jump", throwIfNotFound: true);
        m_Game_Debug = m_Game.FindAction("Debug", throwIfNotFound: true);
        m_Game_FireDown = m_Game.FindAction("Fire Down", throwIfNotFound: true);
        m_Game_FireUp = m_Game.FindAction("Fire Up", throwIfNotFound: true);
        m_Game_ModeChange = m_Game.FindAction("Mode Change", throwIfNotFound: true);
        m_Game_EndTurn = m_Game.FindAction("End Turn", throwIfNotFound: true);
        m_Game_SwitchWeapon = m_Game.FindAction("Switch Weapon", throwIfNotFound: true);
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

    // Game
    private readonly InputActionMap m_Game;
    private IGameActions m_GameActionsCallbackInterface;
    private readonly InputAction m_Game_Move;
    private readonly InputAction m_Game_Jump;
    private readonly InputAction m_Game_Debug;
    private readonly InputAction m_Game_FireDown;
    private readonly InputAction m_Game_FireUp;
    private readonly InputAction m_Game_ModeChange;
    private readonly InputAction m_Game_EndTurn;
    private readonly InputAction m_Game_SwitchWeapon;
    public struct GameActions
    {
        private @Controls m_Wrapper;
        public GameActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Game_Move;
        public InputAction @Jump => m_Wrapper.m_Game_Jump;
        public InputAction @Debug => m_Wrapper.m_Game_Debug;
        public InputAction @FireDown => m_Wrapper.m_Game_FireDown;
        public InputAction @FireUp => m_Wrapper.m_Game_FireUp;
        public InputAction @ModeChange => m_Wrapper.m_Game_ModeChange;
        public InputAction @EndTurn => m_Wrapper.m_Game_EndTurn;
        public InputAction @SwitchWeapon => m_Wrapper.m_Game_SwitchWeapon;
        public InputActionMap Get() { return m_Wrapper.m_Game; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameActions set) { return set.Get(); }
        public void SetCallbacks(IGameActions instance)
        {
            if (m_Wrapper.m_GameActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GameActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_GameActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnJump;
                @Debug.started -= m_Wrapper.m_GameActionsCallbackInterface.OnDebug;
                @Debug.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnDebug;
                @Debug.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnDebug;
                @FireDown.started -= m_Wrapper.m_GameActionsCallbackInterface.OnFireDown;
                @FireDown.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnFireDown;
                @FireDown.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnFireDown;
                @FireUp.started -= m_Wrapper.m_GameActionsCallbackInterface.OnFireUp;
                @FireUp.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnFireUp;
                @FireUp.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnFireUp;
                @ModeChange.started -= m_Wrapper.m_GameActionsCallbackInterface.OnModeChange;
                @ModeChange.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnModeChange;
                @ModeChange.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnModeChange;
                @EndTurn.started -= m_Wrapper.m_GameActionsCallbackInterface.OnEndTurn;
                @EndTurn.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnEndTurn;
                @EndTurn.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnEndTurn;
                @SwitchWeapon.started -= m_Wrapper.m_GameActionsCallbackInterface.OnSwitchWeapon;
                @SwitchWeapon.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnSwitchWeapon;
                @SwitchWeapon.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnSwitchWeapon;
            }
            m_Wrapper.m_GameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Debug.started += instance.OnDebug;
                @Debug.performed += instance.OnDebug;
                @Debug.canceled += instance.OnDebug;
                @FireDown.started += instance.OnFireDown;
                @FireDown.performed += instance.OnFireDown;
                @FireDown.canceled += instance.OnFireDown;
                @FireUp.started += instance.OnFireUp;
                @FireUp.performed += instance.OnFireUp;
                @FireUp.canceled += instance.OnFireUp;
                @ModeChange.started += instance.OnModeChange;
                @ModeChange.performed += instance.OnModeChange;
                @ModeChange.canceled += instance.OnModeChange;
                @EndTurn.started += instance.OnEndTurn;
                @EndTurn.performed += instance.OnEndTurn;
                @EndTurn.canceled += instance.OnEndTurn;
                @SwitchWeapon.started += instance.OnSwitchWeapon;
                @SwitchWeapon.performed += instance.OnSwitchWeapon;
                @SwitchWeapon.canceled += instance.OnSwitchWeapon;
            }
        }
    }
    public GameActions @Game => new GameActions(this);
    public interface IGameActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnDebug(InputAction.CallbackContext context);
        void OnFireDown(InputAction.CallbackContext context);
        void OnFireUp(InputAction.CallbackContext context);
        void OnModeChange(InputAction.CallbackContext context);
        void OnEndTurn(InputAction.CallbackContext context);
        void OnSwitchWeapon(InputAction.CallbackContext context);
    }
}
