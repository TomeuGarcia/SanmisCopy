// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/InputActions/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Land"",
            ""id"": ""2d0b6478-c186-40a2-bf50-b300e6b6a0ac"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""2f31d2a2-4c0c-47ae-934b-991d7a5d2270"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""576a5791-a5c5-4329-851f-c65029af4fa0"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""f4c94320-e578-4b15-aab9-cb0cf713c237"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Formation1"",
                    ""type"": ""Button"",
                    ""id"": ""7f3497e6-8b55-4e85-9daf-7409f5993038"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Formation2"",
                    ""type"": ""Button"",
                    ""id"": ""b6c836fc-0a72-43a5-a2c4-68512127122a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Formation3"",
                    ""type"": ""Button"",
                    ""id"": ""61108fc2-07b8-4190-bacb-f8e63af710ce"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Formation4"",
                    ""type"": ""Button"",
                    ""id"": ""fc218809-ccc4-4aa4-a6cd-d733092844f0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Restart"",
                    ""type"": ""Button"",
                    ""id"": ""4423d919-3085-42e8-b2ca-0a1b64918d0d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""30327b35-bda1-4364-87b0-c6bc7745769a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""f2d92dd3-4475-4a0d-b518-0c7ddf98bca4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""0911ae4a-8d2b-42fe-89d3-9ce07d24cbbd"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a4e7e8f0-f8cb-45ad-b46a-4cc9a6df50af"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ac96b5c9-78fa-4dda-9295-603d0784e97a"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""19a04439-6cba-49d2-bf07-065ddf724a51"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""80ebbe9f-15c3-4482-861c-678f88064b9a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""c161aed0-9cda-4226-817b-5c3651da2b22"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""da202e76-fb33-4dcb-a865-7f367d1cc2f3"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""aa999e18-9330-4789-af3e-39d165caf870"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""078ceb17-1127-4ec1-9d10-2f6b77883d6e"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Formation1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e21924e8-338e-400c-90d0-2407618184e8"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Formation2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a6ccefe0-28cf-4b0b-a790-a182cabb4582"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Formation3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6fe9c478-164b-4315-9dcf-2f4ea9dd569c"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Formation4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""49f4b320-34a8-40dd-abcb-f881b1614fc3"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c67b44e0-bc5a-4723-8bf5-c29c80759005"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d8196383-4dd9-44dd-b871-0fb4e5bc1c6a"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5ad5feef-2f2f-47bf-bf39-e3d4be01b66e"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Desktop"",
            ""bindingGroup"": ""Desktop"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Land
        m_Land = asset.FindActionMap("Land", throwIfNotFound: true);
        m_Land_Jump = m_Land.FindAction("Jump", throwIfNotFound: true);
        m_Land_Move = m_Land.FindAction("Move", throwIfNotFound: true);
        m_Land_Rotate = m_Land.FindAction("Rotate", throwIfNotFound: true);
        m_Land_Formation1 = m_Land.FindAction("Formation1", throwIfNotFound: true);
        m_Land_Formation2 = m_Land.FindAction("Formation2", throwIfNotFound: true);
        m_Land_Formation3 = m_Land.FindAction("Formation3", throwIfNotFound: true);
        m_Land_Formation4 = m_Land.FindAction("Formation4", throwIfNotFound: true);
        m_Land_Restart = m_Land.FindAction("Restart", throwIfNotFound: true);
        m_Land_Cancel = m_Land.FindAction("Cancel", throwIfNotFound: true);
        m_Land_Newaction = m_Land.FindAction("New action", throwIfNotFound: true);
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

    // Land
    private readonly InputActionMap m_Land;
    private ILandActions m_LandActionsCallbackInterface;
    private readonly InputAction m_Land_Jump;
    private readonly InputAction m_Land_Move;
    private readonly InputAction m_Land_Rotate;
    private readonly InputAction m_Land_Formation1;
    private readonly InputAction m_Land_Formation2;
    private readonly InputAction m_Land_Formation3;
    private readonly InputAction m_Land_Formation4;
    private readonly InputAction m_Land_Restart;
    private readonly InputAction m_Land_Cancel;
    private readonly InputAction m_Land_Newaction;
    public struct LandActions
    {
        private @PlayerControls m_Wrapper;
        public LandActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_Land_Jump;
        public InputAction @Move => m_Wrapper.m_Land_Move;
        public InputAction @Rotate => m_Wrapper.m_Land_Rotate;
        public InputAction @Formation1 => m_Wrapper.m_Land_Formation1;
        public InputAction @Formation2 => m_Wrapper.m_Land_Formation2;
        public InputAction @Formation3 => m_Wrapper.m_Land_Formation3;
        public InputAction @Formation4 => m_Wrapper.m_Land_Formation4;
        public InputAction @Restart => m_Wrapper.m_Land_Restart;
        public InputAction @Cancel => m_Wrapper.m_Land_Cancel;
        public InputAction @Newaction => m_Wrapper.m_Land_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_Land; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(LandActions set) { return set.Get(); }
        public void SetCallbacks(ILandActions instance)
        {
            if (m_Wrapper.m_LandActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_LandActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_LandActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_LandActionsCallbackInterface.OnJump;
                @Move.started -= m_Wrapper.m_LandActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_LandActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_LandActionsCallbackInterface.OnMove;
                @Rotate.started -= m_Wrapper.m_LandActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_LandActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_LandActionsCallbackInterface.OnRotate;
                @Formation1.started -= m_Wrapper.m_LandActionsCallbackInterface.OnFormation1;
                @Formation1.performed -= m_Wrapper.m_LandActionsCallbackInterface.OnFormation1;
                @Formation1.canceled -= m_Wrapper.m_LandActionsCallbackInterface.OnFormation1;
                @Formation2.started -= m_Wrapper.m_LandActionsCallbackInterface.OnFormation2;
                @Formation2.performed -= m_Wrapper.m_LandActionsCallbackInterface.OnFormation2;
                @Formation2.canceled -= m_Wrapper.m_LandActionsCallbackInterface.OnFormation2;
                @Formation3.started -= m_Wrapper.m_LandActionsCallbackInterface.OnFormation3;
                @Formation3.performed -= m_Wrapper.m_LandActionsCallbackInterface.OnFormation3;
                @Formation3.canceled -= m_Wrapper.m_LandActionsCallbackInterface.OnFormation3;
                @Formation4.started -= m_Wrapper.m_LandActionsCallbackInterface.OnFormation4;
                @Formation4.performed -= m_Wrapper.m_LandActionsCallbackInterface.OnFormation4;
                @Formation4.canceled -= m_Wrapper.m_LandActionsCallbackInterface.OnFormation4;
                @Restart.started -= m_Wrapper.m_LandActionsCallbackInterface.OnRestart;
                @Restart.performed -= m_Wrapper.m_LandActionsCallbackInterface.OnRestart;
                @Restart.canceled -= m_Wrapper.m_LandActionsCallbackInterface.OnRestart;
                @Cancel.started -= m_Wrapper.m_LandActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_LandActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_LandActionsCallbackInterface.OnCancel;
                @Newaction.started -= m_Wrapper.m_LandActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_LandActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_LandActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_LandActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @Formation1.started += instance.OnFormation1;
                @Formation1.performed += instance.OnFormation1;
                @Formation1.canceled += instance.OnFormation1;
                @Formation2.started += instance.OnFormation2;
                @Formation2.performed += instance.OnFormation2;
                @Formation2.canceled += instance.OnFormation2;
                @Formation3.started += instance.OnFormation3;
                @Formation3.performed += instance.OnFormation3;
                @Formation3.canceled += instance.OnFormation3;
                @Formation4.started += instance.OnFormation4;
                @Formation4.performed += instance.OnFormation4;
                @Formation4.canceled += instance.OnFormation4;
                @Restart.started += instance.OnRestart;
                @Restart.performed += instance.OnRestart;
                @Restart.canceled += instance.OnRestart;
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public LandActions @Land => new LandActions(this);
    private int m_DesktopSchemeIndex = -1;
    public InputControlScheme DesktopScheme
    {
        get
        {
            if (m_DesktopSchemeIndex == -1) m_DesktopSchemeIndex = asset.FindControlSchemeIndex("Desktop");
            return asset.controlSchemes[m_DesktopSchemeIndex];
        }
    }
    public interface ILandActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnFormation1(InputAction.CallbackContext context);
        void OnFormation2(InputAction.CallbackContext context);
        void OnFormation3(InputAction.CallbackContext context);
        void OnFormation4(InputAction.CallbackContext context);
        void OnRestart(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
        void OnNewaction(InputAction.CallbackContext context);
    }
}
