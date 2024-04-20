using UnityEngine;
using UnityEngine.InputSystem;

namespace MirrorYou.Input
{
    public class PlayerInputTest : MonoBehaviour
    {
        private Material sphereMat;
        private PlayerInput playerInput;

        private void Awake()
        {
            sphereMat = GetComponent<MeshRenderer>().materials[0];
            playerInput = GetComponent<PlayerInput>();
            playerInput.onActionTriggered += PlayerInput_onActionTriggered;
        }

        private void PlayerInput_onActionTriggered(InputAction.CallbackContext obj)
        {
            Debug.Log($"Player({playerInput.playerIndex}):{obj.ReadValueAsObject()}");
        }
    }
}