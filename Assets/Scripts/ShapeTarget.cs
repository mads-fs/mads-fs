using System;
using UnityEngine;

namespace MirrorYou.Data
{
    [Serializable]
    public struct ShapeTarget
    {
        [Range(0f, 1f)]
        public float Roughness;
        [Range(0f, 1f)]
        public float Morph;
        public ShapeColor ShapeColor;
        public ShapeScale ShapeScale;
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
        XShrink,
        XGrow,
        YShrink,
        YGrow,
        XYShrink,
        XYGrow
    }
}