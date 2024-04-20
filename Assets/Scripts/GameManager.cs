using MirrorYou.Data;
using MirrorYou.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MirrorYou
{
    public class GameManager : MonoBehaviour
    {
        public Color Yellow;
        public Color Red;
        public Color Green;
        public Color Blue;

        public PlayerInputManager InputManager;

        public float InputVariance = 0.2f;
        private readonly PlayerInputReader[] playerInputReaders = new PlayerInputReader[2];

        public ShapeTarget[] ShapeTargets;

        private ShapeColor playerShapeColor;
        private ShapeScale playerShapeScale;

        private void Start()
        {
            InputManager.onPlayerJoined += InputManager_onPlayerJoined;
            if (ShapeTargets.Length > 0)
            {

            }
        }

        private void Update()
        {
            if (playerInputReaders[0] != null)
            {
                playerInputReaders[0].Morph();
                playerInputReaders[0].Displace();
            }
            CheckProgress();
        }

        private void CheckProgress()
        {

        }

        private void InputManager_onPlayerJoined(PlayerInput obj)
        {
            int playerIndex = obj.GetComponent<PlayerInput>().playerIndex;
            playerInputReaders[playerIndex] = obj.GetComponent<PlayerInputReader>();

            // Colors
            playerInputReaders[playerIndex].OnFaceButtonUpPress += GameManager_OnFaceButtonUpPress;
            playerInputReaders[playerIndex].OnFaceButtonRightPress += GameManager_OnFaceButtonRightPress;
            playerInputReaders[playerIndex].OnFaceButtonDownPress += GameManager_OnFaceButtonDownPress;
            playerInputReaders[playerIndex].OnFaceButtonLeftPress += GameManager_OnFaceButtonLeftPress;
            // Scale
            playerInputReaders[playerIndex].OnShoulderLeftButtonPress += GameManager_OnShoulderLeftButtonPress;
            playerInputReaders[playerIndex].OnShoulderRightButtonPress += GameManager_OnShoulderRightButtonPress;
            playerInputReaders[playerIndex].OnTriggerLeftButtonPress += GameManager_OnTriggerLeftButtonPress;
            playerInputReaders[playerIndex].OnTriggerRightButtonPress += GameManager_OnTriggerRightButtonPress;
        }

        // Yellow
        private void GameManager_OnFaceButtonUpPress(int playerIndex)
        {
            playerInputReaders[0].SetColor(Yellow);
            playerShapeColor = ShapeColor.Yellow;
        }

        // Red
        private void GameManager_OnFaceButtonRightPress(int playerIndex)
        {
            playerInputReaders[0].SetColor(Red);
            playerShapeColor = ShapeColor.Red;
        }

        // Green
        private void GameManager_OnFaceButtonDownPress(int playerIndex)
        {
            playerInputReaders[0].SetColor(Green);
            playerShapeColor = ShapeColor.Green;
        }

        // Blue
        private void GameManager_OnFaceButtonLeftPress(int playerIndex)
        {
            playerInputReaders[0].SetColor(Blue);
            playerShapeColor = ShapeColor.Blue;
        }

        // Shrink Y
        private void GameManager_OnShoulderLeftButtonPress(int playerIndex)
        {
            Vector3 scale = playerInputReaders[0].transform.localScale;
            playerInputReaders[0].transform.localScale = new(scale.x, 0.5f, scale.z);
            playerShapeScale = ShapeScale.YShrink;
            CheckXYShrink();
        }

        // Grow Y
        private void GameManager_OnTriggerLeftButtonPress(int playerIndex)
        {
            Vector3 scale = playerInputReaders[0].transform.localScale;
            playerInputReaders[0].transform.localScale = new(scale.x, 1.5f, scale.z);
            playerShapeScale = ShapeScale.YGrow;
            CheckXYGrow();
        }

        // Shrink X
        private void GameManager_OnShoulderRightButtonPress(int playerIndex)
        {
            Vector3 scale = playerInputReaders[0].transform.localScale;
            playerInputReaders[0].transform.localScale = new(0.5f, scale.y, scale.z);
            playerShapeScale = ShapeScale.XShrink;
            CheckXYShrink();
        }

        // Grow-X
        private void GameManager_OnTriggerRightButtonPress(int playerIndex)
        {
            Vector3 scale = playerInputReaders[0].transform.localScale;
            playerInputReaders[0].transform.localScale = new(1.5f, scale.y, scale.z);
            playerShapeScale = ShapeScale.XGrow;
            CheckXYGrow();
        }

        private void CheckXYShrink()
        {
            if (playerInputReaders[0].transform.localScale.x < 1f &&
                playerInputReaders[0].transform.localScale.y < 1f)
            {
                playerShapeScale = ShapeScale.XYShrink;
            }
        }

        private void CheckXYGrow()
        {
            if (playerInputReaders[0].transform.localScale.x > 1f &&
                playerInputReaders[0].transform.localScale.y > 1f)
            {
                playerShapeScale = ShapeScale.XYGrow;
            }
        }
    }
}