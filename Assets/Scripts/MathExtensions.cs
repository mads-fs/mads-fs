using System;

namespace MirrorYou.Extensions
{
    public static class MathExtensions
    {
        /// <summary>
        /// Utility function to map a value from one range onto another.
        /// </summary>
        /// <param name="value">The value to map.</param>
        /// <param name="min">The minimum of the value's current range.</param>
        /// <param name="max">The maximum of the value's current range.</param>
        /// <param name="targetMin">The minimum of the value's target range.</param>
        /// <param name="targetMax">The maximum of the value's target range.</param>
        /// <returns>The value mapped onto the target range.</returns>
        public static float MapValueToNewScale(float value, float min, float max, float targetMin, float targetMax)
            => (value - min) * ((targetMax - targetMin) / (max - min)) + targetMin;

        public static float EaseInOutQuint(float number)
            => number < 0.5f ? 16f * number * number * number * number * number : 1f - (float)Math.Pow(-2f * number + 2f, 5f) / 2f;
    }
}