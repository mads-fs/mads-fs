using MirrorYou.Data;
using MirrorYou.Extensions;
using MirrorYou.Input;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
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

        public float ShapeAnimationTime = 1f;

        public EndScript EndScript;

        [Header("Audio")]
        public AudioSource WaterDropletSfx;
        public AudioSource DingSfx;

        private ShapeColor playerShapeColor;
        private ShapeScale playerShapeScale;
        private bool isPlaying;

        private float counter = 0f;
        private bool isAnimatingComputerShape = false;

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
                if (shapeTargetIndex == 0 || target.Equals(ShapeTargets[0]))
                {
                    counter = 0f;
                    Color colorAlpha = CounterCircle.color;
                    CounterCircle.color = new(colorAlpha.r, colorAlpha.g, colorAlpha.b, 0f);
                    StartCoroutine(DoComputerShapeAnimation(target, target));
                }
                else
                {
                    StartCoroutine(DoCounterCircleFadeAnimation(0f, 1f));
                    StartCoroutine(DoComputerShapeAnimation(ShapeTargets[shapeTargetIndex - 1], target));
                }
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
            if(InputGlobal.InputActions.Gamepad.Restart.IsPressed()) SceneManager.LoadScene(0);
            if (isPlaying)
            {
                CounterCircle.fillAmount = MathExtensions.MapValueToNewScale(counter, 0f, CounterThreshold, 0f, 1f);
                if (playerInputReaders[0] != null)
                {
                    if (!isAnimatingComputerShape)
                    {
                        playerInputReaders[0].Morph();
                        playerInputReaders[0].Displace();
                        if (CheckProgress())
                        {
                            counter += Time.deltaTime;
                            if (counter >= CounterThreshold)
                            {
                                shapeTargetIndex += 1;
                                if (shapeTargetIndex < ShapeTargets.Length)
                                {
                                    ShapeTarget shape = ShapeTargets[shapeTargetIndex];
                                    WaterDropletSfx.Play();
                                    ApplyShape(shape, animate: true);
                                }
                                else
                                {
                                    StartCoroutine(DoCounterCircleFadeAnimation(0f, 1f));
                                    isPlaying = false;
                                    EndScript.Play();
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
        }

        private bool CheckProgress()
        {
            if (playerShapeColor != ShapeTargets[shapeTargetIndex].ShapeColor) return false;
            Debug.Log($"{ShapeTargets[shapeTargetIndex].ShapeScale}");
            if (playerShapeScale != ShapeTargets[shapeTargetIndex].ShapeScale) return false;
            float leftXDistance = Mathf.Abs(ShapeTargets[shapeTargetIndex].Morph - playerInputReaders[0].SmoothedLeftAnalogHorizontalAxis);
            Debug.Log($"l:{leftXDistance}");
            if (leftXDistance < 0f || leftXDistance > InputVariance) return false;
            float rightXDistance = Mathf.Abs(ShapeTargets[shapeTargetIndex].Roughness - playerInputReaders[0].SmoothedRightAnalogHorizontalAxis);
            Debug.Log($"l:{rightXDistance}");
            if (rightXDistance < 0f || rightXDistance > InputVariance) return false;
            if (CounterCircle.color.a < 0.001f) StartCoroutine(DoCounterCircleFadeAnimation(1f, 0.3f));
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
            playerInputReaders[playerIndex].gameObject.transform.localScale = DataExtensions.GetShapeScaleVector(ShapeScale.XYShrink);
        }

        private void GameManager_OnBackButtonPress(int playerIndex)
        {
            Debug.developerConsoleVisible = !Debug.developerConsoleVisible;
        }

        // Yellow
        private void GameManager_OnFaceButtonUpPress(int playerIndex)
        {
            if (isAnimatingComputerShape) return;
            playerInputReaders[0].SetColor(Yellow);
            playerShapeColor = ShapeColor.Yellow;
        }

        // Red
        private void GameManager_OnFaceButtonRightPress(int playerIndex)
        {
            if (isAnimatingComputerShape) return;
            playerInputReaders[0].SetColor(Red);
            playerShapeColor = ShapeColor.Red;
        }

        // Green
        private void GameManager_OnFaceButtonDownPress(int playerIndex)
        {
            if (isAnimatingComputerShape) return;
            playerInputReaders[0].SetColor(Green);
            playerShapeColor = ShapeColor.Green;
        }

        // Blue
        private void GameManager_OnFaceButtonLeftPress(int playerIndex)
        {
            if (isAnimatingComputerShape) return;
            playerInputReaders[0].SetColor(Blue);
            playerShapeColor = ShapeColor.Blue;
        }

        // Shrink Y
        private void GameManager_OnShoulderLeftButtonPress(int playerIndex)
        {
            if (isAnimatingComputerShape) return;
            Vector3 scale = playerInputReaders[0].transform.localScale;
            playerInputReaders[0].transform.localScale = new(scale.x, 0.5f, scale.z);
            CheckXYShapeScale();
        }

        // Grow Y
        private void GameManager_OnTriggerLeftButtonPress(int playerIndex)
        {
            if (isAnimatingComputerShape) return;
            Vector3 scale = playerInputReaders[0].transform.localScale;
            playerInputReaders[0].transform.localScale = new(scale.x, 1.5f, scale.z);
            CheckXYShapeScale();
        }

        // Shrink X
        private void GameManager_OnShoulderRightButtonPress(int playerIndex)
        {
            if (isAnimatingComputerShape) return;
            Vector3 scale = playerInputReaders[0].transform.localScale;
            playerInputReaders[0].transform.localScale = new(0.5f, scale.y, scale.z);
            CheckXYShapeScale();
        }

        // Grow-X
        private void GameManager_OnTriggerRightButtonPress(int playerIndex)
        {
            if (isAnimatingComputerShape) return;
            Vector3 scale = playerInputReaders[0].transform.localScale;
            playerInputReaders[0].transform.localScale = new(1.5f, scale.y, scale.z);
            CheckXYShapeScale();
        }

        private void CheckXYShapeScale()
        {
            Vector2 scale = playerInputReaders[0].transform.localScale;
            if (scale.x == 0.5f && scale.y == 0.5f) { playerShapeScale = ShapeScale.XYShrink; return; }
            if (scale.x == 0.5f && scale.y == 1.5f) { playerShapeScale = ShapeScale.XShrinkYGrow; return; }
            if (scale.x == 1.5f && scale.y == 0.5f) { playerShapeScale = ShapeScale.XGrowYShrink; return; }
            if (scale.x == 1.5f && scale.y == 1.5f) { playerShapeScale = ShapeScale.XYGrow; }
        }

        private IEnumerator DoComputerShapeAnimation(ShapeTarget oldShape, ShapeTarget newShape)
        {
            if (oldShape.Equals(newShape)) yield return null;
            else
            {
                isAnimatingComputerShape = true;
                yield return null;

                float timer = 0f;
                Material mat = ComputerShape.GetComponent<MeshRenderer>().material;
                Color oldColor = mat.GetColor("_Color");
                Color newColor = Red;
                switch (newShape.ShapeColor)
                {
                    case ShapeColor.Yellow: newColor = Yellow; break;
                    case ShapeColor.Red: newColor = Red; break;
                    case ShapeColor.Green: newColor = Green; break;
                    case ShapeColor.Blue: newColor = Blue; break;
                }
                Vector2 oldScale = DataExtensions.GetShapeScaleVector(oldShape.ShapeScale);
                Vector2 newScale = DataExtensions.GetShapeScaleVector(newShape.ShapeScale);
                float scaleX = newScale.x < 0 ? ComputerShape.transform.localScale.x : newScale.x;
                float scaleY = newScale.y < 0 ? ComputerShape.transform.localScale.y : newScale.y;
                newScale = new(scaleX, scaleY);
                while (timer < ShapeAnimationTime * 0.5f)
                {
                    timer += Time.deltaTime;
                    float alpha = MathExtensions.EaseInOutQuint(timer / ShapeAnimationTime);
                    float morph = Mathf.Lerp(oldShape.Morph, newShape.Morph, alpha);
                    float roughness = Mathf.Lerp(oldShape.Roughness, newShape.Roughness, alpha);
                    Color color = Color.Lerp(oldColor, newColor, alpha);
                    Vector2 scale = Vector2.Lerp(oldScale, newScale, alpha);

                    mat.SetFloat("_Morph", morph);
                    mat.SetFloat("_Roughness", roughness);
                    mat.SetColor("_Color", color);

                    ComputerShape.transform.localScale = scale;
                    yield return null;
                }
                timer = ShapeAnimationTime * 0.5f;
                DingSfx.Play();
                while (timer < ShapeAnimationTime)
                {
                    timer += Time.deltaTime;
                    float alpha = MathExtensions.EaseInOutQuint(timer / ShapeAnimationTime);
                    float morph = Mathf.Lerp(oldShape.Morph, newShape.Morph, alpha);
                    float roughness = Mathf.Lerp(oldShape.Roughness, newShape.Roughness, alpha);
                    Color color = Color.Lerp(oldColor, newColor, alpha);
                    Vector2 scale = Vector2.Lerp(oldScale, newScale, alpha);

                    mat.SetFloat("_Morph", morph);
                    mat.SetFloat("_Roughness", roughness);
                    mat.SetColor("_Color", color);

                    ComputerShape.transform.localScale = scale;
                    yield return null;
                }
                mat.SetFloat("_Morph", newShape.Morph);
                mat.SetFloat("_Roughness", newShape.Roughness);
                mat.SetColor("_Color", newColor);
                ComputerShape.transform.localScale = newScale;
            }
            isAnimatingComputerShape = false;
            yield return null;
        }

        private IEnumerator DoCounterCircleFadeAnimation(float targetAlpha, float duration)
        {
            float time = 0f;
            float startAlphaValue = CounterCircle.color.a;
            float endAlphaValue = targetAlpha;

            while (time < duration)
            {
                time += Time.deltaTime;
                float alphaTime = time / duration;
                float newAlphaValue = Mathf.Lerp(startAlphaValue, endAlphaValue, alphaTime);
                CounterCircle.color = new(CounterCircle.color.r, CounterCircle.color.g, CounterCircle.color.b, newAlphaValue);
                yield return null;
            }
            CounterCircle.color = new(CounterCircle.color.r, CounterCircle.color.g, CounterCircle.color.b, endAlphaValue);
            counter = 0f;
            yield return null;
        }
    }
}