using MirrorYou.Data;
using UnityEngine;

namespace MirrorYou.Extensions
{
    public static class DataExtensions
    {
        public static Vector2 GetShapeScaleVector(ShapeScale value)
        {
            return value switch
            {
                ShapeScale.XYShrink => new(0.5f, 0.5f),
                ShapeScale.XShrinkYGrow => new(0.5f, 1.5f),
                ShapeScale.XGrowYShrink => new(1.5f, 0.5f),
                ShapeScale.XYGrow => new(1.5f, 1.5f),
                _ => -Vector2.one,
            };
        }
    }
}