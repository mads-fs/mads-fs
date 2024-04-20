using UnityEngine;
using UnityEngine.InputSystem;

namespace MirrorYou.Input
{
    public class InputTest : MonoBehaviour
    {
        public Transform[] SpawnPoints;
        public bool ReadLeftAnalog = false;
        public bool ReadRightAnalog = false;
        public bool ReadDPad = false;
        public bool ReadFaceButtonUp = false;
        public bool ReadFaceButtonRight = false;
        public bool ReadFaceButtonDown = false;
        public bool ReadFaceButtonLeft = false;
        public bool ReadShoulderLeft = false;
        public bool ReadShoulderRight = false;
        public bool ReadTriggerLeft = false;
        public bool ReadTriggerRight = false;

        private InputMap inputActions;

        private PlayerInputManager playerInputManager;

        private void Awake()
        {
            inputActions = new();
            playerInputManager = GetComponent<PlayerInputManager>();
            playerInputManager.onPlayerJoined += PlayerInputManager_onPlayerJoined;
            inputActions.Gamepad.Enable();
        }

        private void PlayerInputManager_onPlayerJoined(PlayerInput obj)
        {
            obj.gameObject.transform.position = SpawnPoints[playerInputManager.playerCount - 1].position;
        }

        // Update is called once per frame
        void Update()
        {
            if (ReadLeftAnalog) Debug.Log($"LeftAnalog: {inputActions.Gamepad.LeftAnalog.ReadValue<Vector2>()}");
            if (ReadRightAnalog) Debug.Log($"RightAnalog: {inputActions.Gamepad.RightAnalog.ReadValue<Vector2>()}");
            if (ReadDPad) Debug.Log($"DPad: {inputActions.Gamepad.DPad.ReadValue<Vector2>()}");
            if (ReadFaceButtonUp) PrintButtonCall(inputActions.Gamepad.FaceButtonUp);
            if (ReadFaceButtonRight) PrintButtonCall(inputActions.Gamepad.FaceButtonRight);
            if (ReadFaceButtonDown) PrintButtonCall(inputActions.Gamepad.FaceButtonDown);
            if (ReadFaceButtonLeft) PrintButtonCall(inputActions.Gamepad.FaceButtonLeft);
            if (ReadShoulderLeft) PrintButtonCall(inputActions.Gamepad.ShoulderLeft);
            if (ReadShoulderRight) PrintButtonCall(inputActions.Gamepad.ShoulderRight);
            if (ReadTriggerLeft) PrintButtonCall(inputActions.Gamepad.TriggerLeft);
            if (ReadTriggerRight) PrintButtonCall(inputActions.Gamepad.TriggerRight);
        }

        private void PrintButtonCall(UnityEngine.InputSystem.InputAction action)
        {
            Debug.Log($"{action.name}: {action}");
            Debug.Log($"{action.name}(IsPressed): {action.IsPressed()}");
            Debug.Log($"{action.name}(IsInProgress): {action.IsInProgress()}");
            Debug.Log($"{action.name}(triggered): {action.triggered}");
        }
    }
}