using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MirrorYou.Input
{
    public class PlayerInputReader : MonoBehaviour
    {
        public int XInputSampling = 100;
        public int YInputSampling = 100;

        public event Action<int> OnBackButtonPress = delegate { };
        public event Action<int> OnFaceButtonUpPress = delegate { };
        public event Action<int> OnFaceButtonRightPress = delegate { };
        public event Action<int> OnFaceButtonDownPress = delegate { };
        public event Action<int> OnFaceButtonLeftPress = delegate { };
        public event Action<int> OnShoulderLeftButtonPress = delegate { };
        public event Action<int> OnShoulderRightButtonPress = delegate { };
        public event Action<int> OnTriggerLeftButtonPress = delegate { };
        public event Action<int> OnTriggerRightButtonPress = delegate { };

        private Vector2 leftAnalog;
        public float SmoothedLeftAnalogHorizontalAxis { get { return smoothedLeftAnalog.x; } }
        private Vector2 smoothedLeftAnalog;
        private Vector2 rightAnalog;
        public float SmoothedRightAnalogHorizontalAxis { get { return smoothedRightAnalog.x; } }
        private Vector2 smoothedRightAnalog;
        private Vector2 dpad;

        private int playerIndex;
        private Material quadMat;

        private float[] leftAnalogXInputSmoothing;
        private float[] leftAnalogYInputSmoothing;
        private float[] rightAnalogXInputSmoothing;
        private float[] rightAnalogYInputSmoothing;

        private int leftAnalogXInputSampleIndex = -1;
        private int leftAnalogYInputSampleIndex = -1;
        private int rightAnalogXInputSampleIndex = -1;
        private int rightAnalogYInputSampleIndex = -1;

        private void Start()
        {
            playerIndex = GetComponent<PlayerInput>().playerIndex;
            quadMat = GetComponent<MeshRenderer>().material;
            leftAnalogXInputSmoothing = new float[XInputSampling];
            leftAnalogYInputSmoothing = new float[YInputSampling];
            rightAnalogXInputSmoothing = new float[XInputSampling];
            rightAnalogYInputSmoothing = new float[YInputSampling];
        }

        private void Update()
        {
            leftAnalog = InputGlobal.InputActions.Gamepad.LeftAnalog.ReadValue<Vector2>();
            float sampledLeftX = GetSampledInput(ref leftAnalogXInputSampleIndex, ref leftAnalogXInputSmoothing, leftAnalog.x);
            float sampledLeftY = GetSampledInput(ref leftAnalogYInputSampleIndex, ref leftAnalogYInputSmoothing, leftAnalog.y);
            smoothedLeftAnalog = new(sampledLeftX, sampledLeftY);

            rightAnalog = InputGlobal.InputActions.Gamepad.RightAnalog.ReadValue<Vector2>();
            float sampledRightX = GetSampledInput(ref rightAnalogXInputSampleIndex, ref rightAnalogXInputSmoothing, rightAnalog.x);
            float sampledRightY = GetSampledInput(ref rightAnalogYInputSampleIndex, ref rightAnalogYInputSmoothing, rightAnalog.y);
            smoothedRightAnalog = new(sampledRightX, sampledLeftX);

            dpad = InputGlobal.InputActions.Gamepad.DPad.ReadValue<Vector2>();

            if (InputGlobal.InputActions.Gamepad.FaceButtonUp.IsPressed())
            {
                OnFaceButtonUpPress.Invoke(playerIndex);
            }
            if (InputGlobal.InputActions.Gamepad.FaceButtonRight.IsPressed())
            {
                OnFaceButtonRightPress.Invoke(playerIndex);
            }
            if (InputGlobal.InputActions.Gamepad.FaceButtonDown.IsPressed())
            {
                OnFaceButtonDownPress.Invoke(playerIndex);
            }
            if (InputGlobal.InputActions.Gamepad.FaceButtonLeft.IsPressed())
            {
                OnFaceButtonLeftPress.Invoke(playerIndex);
            }
            if (InputGlobal.InputActions.Gamepad.ShoulderLeft.IsPressed())
            {
                OnShoulderLeftButtonPress.Invoke(playerIndex);
            }
            if (InputGlobal.InputActions.Gamepad.ShoulderRight.IsPressed())
            {
                OnShoulderRightButtonPress.Invoke(playerIndex);
            }
            if (InputGlobal.InputActions.Gamepad.TriggerLeft.IsPressed())
            {
                OnTriggerLeftButtonPress.Invoke(playerIndex);
            }
            if (InputGlobal.InputActions.Gamepad.TriggerRight.IsPressed())
            {
                OnTriggerRightButtonPress.Invoke(playerIndex);
            }
        }

        private float GetSampledInput(ref int sampleIndex, ref float[] samples, float axisValue)
        {
            sampleIndex += 1;
            if (sampleIndex >= samples.Length) sampleIndex = 0;
            samples[sampleIndex] = axisValue;
            return SampleAxis(samples);
        }

        private float SampleAxis(float[] samples)
        {
            float result = 0f;
            for (int i = 0; i < samples.Length; i++)
            {
                result += samples[i];
            }
            result /= samples.Length;
            return result;
        }

        public void SetColor(Color color) => quadMat.color = color;

        public void Morph()
        {
            if (quadMat == null) quadMat = GetComponent<MeshRenderer>().material;
            quadMat.SetFloat("_Morph", Mathf.Abs(smoothedLeftAnalog.x));
        }

        public void Displace()
        {
            if (quadMat == null) quadMat = GetComponent<MeshRenderer>().material;
            quadMat.SetFloat("_Roughness", Mathf.Abs(smoothedRightAnalog.x));
        }
    }
}