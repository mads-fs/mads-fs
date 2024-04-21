using System;
using UnityEngine;

namespace MirrorYou.Data
{
    [Serializable]
    public struct ShapeTarget : IEquatable<ShapeTarget>
    {
        [Range(0f, 1f)]
        public float Roughness;
        [Range(0f, 1f)]
        public float Morph;
        public ShapeColor ShapeColor;
        public ShapeScale ShapeScale;

        public readonly bool Equals(ShapeTarget other)
            =>
            Roughness == other.Roughness &&
            Morph == other.Morph &&
            ShapeColor == other.ShapeColor &&
            ShapeScale == other.ShapeScale;
    }

    public enum ShapeColor
    {
        Yellow,
        Red,
        Green,
        Blue
    }

    public enum ShapeScale
    {
        XYShrink,
        XShrinkYGrow,
        XGrowYShrink,
        XYGrow,
    }
}