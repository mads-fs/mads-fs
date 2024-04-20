using MirrorYou.Data;
using MirrorYou.Extensions;
using MirrorYou.Input;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace MirrorYou
{
    public class GameManager : MonoBehaviour
    {
        public Color Yellow = Color.yellow;
        public Color Red = Color.red;
        public Color Green = Color.green;
        public Color Blue = Color.blue;

        public PlayerInputManager InputManager;
        public GameObject ComputerShape;

        public float InputVariance = 0.05f;
        private readonly PlayerInputReader[] playerInputReaders = new PlayerInputReader[2];

        public ShapeTarget[] ShapeTargets;
        private int shapeTargetIndex = 0;

        public float CounterThreshold = 3f;
        public Image CounterCircle;

        private ShapeColor playerShapeColor;
        private ShapeScale playerShapeScale;
        private bool isPlaying;

        private float counter = 0f;

        private void Start()
        {
            InputManager.onPlayerJoined += InputManager_onPlayerJoined;
            if (ShapeTargets.Length > 0)
            {
                ShapeTarget shape = ShapeTargets[shapeTargetIndex];
                ApplyShape(shape, animate: false);
                isPlaying = true;
            }
        }

        private void ApplyShape(ShapeTarget target, bool animate = true)
        {
            if (animate)
            {
                // Animate
            }
            else
            {
                Material mat = ComputerShape.GetComponent<MeshRenderer>().material;
                mat.SetFloat("_Morph", target.Morph);
                mat.SetFloat("_Roughness", target.Roughness);
                switch (target.ShapeColor)
                {
                    case ShapeColor.Yellow: mat.SetColor("_Color", Yellow); break;
                    case ShapeColor.Red: mat.SetColor("_Color", Red); break;
                    case ShapeColor.Green: mat.SetColor("_Color", Green); break;
                    case ShapeColor.Blue: mat.SetColor("_Color", Blue); break;
                }
                Vector2 scale = DataExtensions.GetShapeScaleVector(target.ShapeScale);
                float scaleX = scale.x < 0 ? ComputerShape.transform.localScale.x : scale.x;
                float scaleY = scale.y < 0 ? ComputerShape.transform.localScale.y : scale.y;
                ComputerShape.transform.localScale = new(scaleX, scaleY, ComputerShape.transform.localScale.z);
            }
        }

        private void Update()
        {
            if (isPlaying)
            {
                CounterCircle.fillAmount = MathExtensions.MapValueToNewScale(counter, 0f, CounterThreshold, 0f, 1f);
                if (playerInputReaders[0] != null)
                {
                    playerInputReaders[0].Morph();
                    playerInputReaders[0].Displace();
                    if (CheckProgress())
                    {
                        counter += Time.deltaTime;
                        if(counter >= CounterThreshold)
                        {
                            shapeTargetIndex += 1;
                            if (shapeTargetIndex < ShapeTargets.Length)
                            {
                                counter = 0f;
                                ShapeTarget shape = ShapeTargets[shapeTargetIndex];
                                ApplyShape(shape, animate: false);
                            }
                            else
                            {
                                isPlaying = false;
                            }
                        }
                    }
                    else
                    {
                        Debug.Log("Wrong");
                    }
                }
            }
        }

        private bool CheckProgress()
        {
            if (playerShapeColor != ShapeTargets[shapeTargetIndex].ShapeColor) return false;
            if (playerShapeScale != ShapeTargets[shapeTargetIndex].ShapeScale) return false;
            float leftXDistance = ShapeTargets[shapeTargetIndex].Morph - playerInputReaders[0].SmoothedLeftAnalogHorizontalAxis;
            Debug.Log(leftXDistance);
            if (leftXDistance < 0f || leftXDistance > InputVariance) return false;
            float rightXDistance = ShapeTargets[shapeTargetIndex].Morph - playerInputReaders[0].SmoothedRightAnalogHorizontalAxis;
            if (rightXDistance < 0f || rightXDistance > InputVariance) return false;
            return true;
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