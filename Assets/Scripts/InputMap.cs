//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Config/InputMap.inputactions
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

namespace MirrorYou.Input
{
    public partial class @InputMap: IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @InputMap()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMap"",
    ""maps"": [
        {
            ""name"": ""Gamepad"",
            ""id"": ""13537dd1-2852-4c51-9f1b-2f646ac3427a"",
            ""actions"": [
                {
                    ""name"": ""LeftAnalog"",
                    ""type"": ""Value"",
                    ""id"": ""fff95085-f59c-4ef2-9eb0-12196b9588fe"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""RightAnalog"",
                    ""type"": ""Value"",
                    ""id"": ""d3a4385e-79e3-4d0a-bd75-29beac09d4ec"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""DPad"",
                    ""type"": ""Value"",
                    ""id"": ""40c4cf53-6f8e-42a4-8a5b-61929c30c0cb"",
                    ""expectedControlType"": ""Dpad"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""FaceButtonUp"",
                    ""type"": ""Button"",
                    ""id"": ""dc631d1f-7e98-41dd-9d5a-02cf3601a3e7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""FaceButtonRight"",
                    ""type"": ""Button"",
                    ""id"": ""f461fa4d-50d2-449b-9e96-f6a492bee9ed"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""FaceButtonDown"",
                    ""type"": ""Button"",
                    ""id"": ""b17161e6-1e39-4b4d-a60c-3fe12ccc94b0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""FaceButtonLeft"",
                    ""type"": ""Button"",
                    ""id"": ""db43792b-e24c-421e-ae5d-c515bb3e1889"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ShoulderLeft"",
                    ""type"": ""Button"",
                    ""id"": ""31a60d6f-bcbc-4e0d-9294-a75ef0fbece2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ShoulderRight"",
                    ""type"": ""Button"",
                    ""id"": ""e3f7e81e-c411-4171-8d96-a855ae3aca53"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TriggerLeft"",
                    ""type"": ""Button"",
                    ""id"": ""f5d5b4b3-1367-495d-96c0-063b3ca185f9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TriggerRight"",
                    ""type"": ""Button"",
                    ""id"": ""6169b2d6-93c4-4920-9674-f593b458935a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4fada763-8f6a-4611-bd33-4a77e9b2d972"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2"",
                    ""groups"": ""Controller"",
                    ""action"": ""LeftAnalog"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5540d8f5-46d8-484c-8dc5-b7077cf363ea"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""FaceButtonUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""de412610-4ea4-445c-8fdd-c9d654c7979c"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""FaceButtonRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2b5245c3-0da4-42df-b6ab-d33c25f28926"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""FaceButtonDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c67d302f-b671-4b39-83f2-36d48249b77b"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""FaceButtonLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2ef67cb5-1e60-47de-9fd2-2fb2b7b6808b"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShoulderLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e78d5cda-7733-4230-b4fc-26aedae55c17"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShoulderRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dd1a3d0f-892b-401e-b321-77740353499e"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TriggerLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""40768f5b-9cdf-4a06-87e0-69280fb96d71"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TriggerRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""e1685778-fec5-46fc-a321-c0fcdf9e55d7"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DPad"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""932baade-cd32-44c7-a80f-6ad411bfdacd"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DPad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2dbdcb96-575c-437b-a438-1f6fe647936f"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DPad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""87d7b72c-a6fc-4b08-bfa7-233a0aaa705a"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DPad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""9f569c33-0bc9-447f-ad46-f6c5c49ee3c0"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DPad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""008d3a1f-ea8b-43e8-9b86-43e894afabd8"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2"",
                    ""groups"": ""Controller"",
                    ""action"": ""RightAnalog"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Controller"",
            ""bindingGroup"": ""Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<XInputController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // Gamepad
            m_Gamepad = asset.FindActionMap("Gamepad", throwIfNotFound: true);
            m_Gamepad_LeftAnalog = m_Gamepad.FindAction("LeftAnalog", throwIfNotFound: true);
            m_Gamepad_RightAnalog = m_Gamepad.FindAction("RightAnalog", throwIfNotFound: true);
            m_Gamepad_DPad = m_Gamepad.FindAction("DPad", throwIfNotFound: true);
            m_Gamepad_FaceButtonUp = m_Gamepad.FindAction("FaceButtonUp", throwIfNotFound: true);
            m_Gamepad_FaceButtonRight = m_Gamepad.FindAction("FaceButtonRight", throwIfNotFound: true);
            m_Gamepad_FaceButtonDown = m_Gamepad.FindAction("FaceButtonDown", throwIfNotFound: true);
            m_Gamepad_FaceButtonLeft = m_Gamepad.FindAction("FaceButtonLeft", throwIfNotFound: true);
            m_Gamepad_ShoulderLeft = m_Gamepad.FindAction("ShoulderLeft", throwIfNotFound: true);
            m_Gamepad_ShoulderRight = m_Gamepad.FindAction("ShoulderRight", throwIfNotFound: true);
            m_Gamepad_TriggerLeft = m_Gamepad.FindAction("TriggerLeft", throwIfNotFound: true);
            m_Gamepad_TriggerRight = m_Gamepad.FindAction("TriggerRight", throwIfNotFound: true);
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

        // Gamepad
        private readonly InputActionMap m_Gamepad;
        private List<IGamepadActions> m_GamepadActionsCallbackInterfaces = new List<IGamepadActions>();
        private readonly InputAction m_Gamepad_LeftAnalog;
        private readonly InputAction m_Gamepad_RightAnalog;
        private readonly InputAction m_Gamepad_DPad;
        private readonly InputAction m_Gamepad_FaceButtonUp;
        private readonly InputAction m_Gamepad_FaceButtonRight;
        private readonly InputAction m_Gamepad_FaceButtonDown;
        private readonly InputAction m_Gamepad_FaceButtonLeft;
        private readonly InputAction m_Gamepad_ShoulderLeft;
        private readonly InputAction m_Gamepad_ShoulderRight;
        private readonly InputAction m_Gamepad_TriggerLeft;
        private readonly InputAction m_Gamepad_TriggerRight;
        public struct GamepadActions
        {
            private @InputMap m_Wrapper;
            public GamepadActions(@InputMap wrapper) { m_Wrapper = wrapper; }
            public InputAction @LeftAnalog => m_Wrapper.m_Gamepad_LeftAnalog;
            public InputAction @RightAnalog => m_Wrapper.m_Gamepad_RightAnalog;
            public InputAction @DPad => m_Wrapper.m_Gamepad_DPad;
            public InputAction @FaceButtonUp => m_Wrapper.m_Gamepad_FaceButtonUp;
            public InputAction @FaceButtonRight => m_Wrapper.m_Gamepad_FaceButtonRight;
            public InputAction @FaceButtonDown => m_Wrapper.m_Gamepad_FaceButtonDown;
            public InputAction @FaceButtonLeft => m_Wrapper.m_Gamepad_FaceButtonLeft;
            public InputAction @ShoulderLeft => m_Wrapper.m_Gamepad_ShoulderLeft;
            public InputAction @ShoulderRight => m_Wrapper.m_Gamepad_ShoulderRight;
            public InputAction @TriggerLeft => m_Wrapper.m_Gamepad_TriggerLeft;
            public InputAction @TriggerRight => m_Wrapper.m_Gamepad_TriggerRight;
            public InputActionMap Get() { return m_Wrapper.m_Gamepad; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(GamepadActions set) { return set.Get(); }
            public void AddCallbacks(IGamepadActions instance)
            {
                if (instance == null || m_Wrapper.m_GamepadActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_GamepadActionsCallbackInterfaces.Add(instance);
                @LeftAnalog.started += instance.OnLeftAnalog;
                @LeftAnalog.performed += instance.OnLeftAnalog;
                @LeftAnalog.canceled += instance.OnLeftAnalog;
                @RightAnalog.started += instance.OnRightAnalog;
                @RightAnalog.performed += instance.OnRightAnalog;
                @RightAnalog.canceled += instance.OnRightAnalog;
                @DPad.started += instance.OnDPad;
                @DPad.performed += instance.OnDPad;
                @DPad.canceled += instance.OnDPad;
                @FaceButtonUp.started += instance.OnFaceButtonUp;
                @FaceButtonUp.performed += instance.OnFaceButtonUp;
                @FaceButtonUp.canceled += instance.OnFaceButtonUp;
                @FaceButtonRight.started += instance.OnFaceButtonRight;
                @FaceButtonRight.performed += instance.OnFaceButtonRight;
                @FaceButtonRight.canceled += instance.OnFaceButtonRight;
                @FaceButtonDown.started += instance.OnFaceButtonDown;
                @FaceButtonDown.performed += instance.OnFaceButtonDown;
                @FaceButtonDown.canceled += instance.OnFaceButtonDown;
                @FaceButtonLeft.started += instance.OnFaceButtonLeft;
                @FaceButtonLeft.performed += instance.OnFaceButtonLeft;
                @FaceButtonLeft.canceled += instance.OnFaceButtonLeft;
                @ShoulderLeft.started += instance.OnShoulderLeft;
                @ShoulderLeft.performed += instance.OnShoulderLeft;
                @ShoulderLeft.canceled += instance.OnShoulderLeft;
                @ShoulderRight.started += instance.OnShoulderRight;
                @ShoulderRight.performed += instance.OnShoulderRight;
                @ShoulderRight.canceled += instance.OnShoulderRight;
                @TriggerLeft.started += instance.OnTriggerLeft;
                @TriggerLeft.performed += instance.OnTriggerLeft;
                @TriggerLeft.canceled += instance.OnTriggerLeft;
                @TriggerRight.started += instance.OnTriggerRight;
                @TriggerRight.performed += instance.OnTriggerRight;
                @TriggerRight.canceled += instance.OnTriggerRight;
            }

            private void UnregisterCallbacks(IGamepadActions instance)
            {
                @LeftAnalog.started -= instance.OnLeftAnalog;
                @LeftAnalog.performed -= instance.OnLeftAnalog;
                @LeftAnalog.canceled -= instance.OnLeftAnalog;
                @RightAnalog.started -= instance.OnRightAnalog;
                @RightAnalog.performed -= instance.OnRightAnalog;
                @RightAnalog.canceled -= instance.OnRightAnalog;
                @DPad.started -= instance.OnDPad;
                @DPad.performed -= instance.OnDPad;
                @DPad.canceled -= instance.OnDPad;
                @FaceButtonUp.started -= instance.OnFaceButtonUp;
                @FaceButtonUp.performed -= instance.OnFaceButtonUp;
                @FaceButtonUp.canceled -= instance.OnFaceButtonUp;
                @FaceButtonRight.started -= instance.OnFaceButtonRight;
                @FaceButtonRight.performed -= instance.OnFaceButtonRight;
                @FaceButtonRight.canceled -= instance.OnFaceButtonRight;
                @FaceButtonDown.started -= instance.OnFaceButtonDown;
                @FaceButtonDown.performed -= instance.OnFaceButtonDown;
                @FaceButtonDown.canceled -= instance.OnFaceButtonDown;
                @FaceButtonLeft.started -= instance.OnFaceButtonLeft;
                @FaceButtonLeft.performed -= instance.OnFaceButtonLeft;
                @FaceButtonLeft.canceled -= instance.OnFaceButtonLeft;
                @ShoulderLeft.started -= instance.OnShoulderLeft;
                @ShoulderLeft.performed -= instance.OnShoulderLeft;
                @ShoulderLeft.canceled -= instance.OnShoulderLeft;
                @ShoulderRight.started -= instance.OnShoulderRight;
                @ShoulderRight.performed -= instance.OnShoulderRight;
                @ShoulderRight.canceled -= instance.OnShoulderRight;
                @TriggerLeft.started -= instance.OnTriggerLeft;
                @TriggerLeft.performed -= instance.OnTriggerLeft;
                @TriggerLeft.canceled -= instance.OnTriggerLeft;
                @TriggerRight.started -= instance.OnTriggerRight;
                @TriggerRight.performed -= instance.OnTriggerRight;
                @TriggerRight.canceled -= instance.OnTriggerRight;
            }

            public void RemoveCallbacks(IGamepadActions instance)
            {
                if (m_Wrapper.m_GamepadActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IGamepadActions instance)
            {
                foreach (var item in m_Wrapper.m_GamepadActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_GamepadActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public GamepadActions @Gamepad => new GamepadActions(this);
        private int m_ControllerSchemeIndex = -1;
        public InputControlScheme ControllerScheme
        {
            get
            {
                if (m_ControllerSchemeIndex == -1) m_ControllerSchemeIndex = asset.FindControlSchemeIndex("Controller");
                return asset.controlSchemes[m_ControllerSchemeIndex];
            }
        }
        public interface IGamepadActions
        {
            void OnLeftAnalog(InputAction.CallbackContext context);
            void OnRightAnalog(InputAction.CallbackContext context);
            void OnDPad(InputAction.CallbackContext context);
            void OnFaceButtonUp(InputAction.CallbackContext context);
            void OnFaceButtonRight(InputAction.CallbackContext context);
            void OnFaceButtonDown(InputAction.CallbackContext context);
            void OnFaceButtonLeft(InputAction.CallbackContext context);
            void OnShoulderLeft(InputAction.CallbackContext context);
            void OnShoulderRight(InputAction.CallbackContext context);
            void OnTriggerLeft(InputAction.CallbackContext context);
            void OnTriggerRight(InputAction.CallbackContext context);
        }
    }
}
