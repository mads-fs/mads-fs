using UnityEngine;
using UnityEngine.InputSystem;

namespace MirrorYou.Input
{
    public class InputGlobal : MonoBehaviour
    {
        public Transform[] SpawnPoints;
        public static InputMap InputActions { get { return inputActions; } }
        private static InputMap inputActions;

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
    }
}