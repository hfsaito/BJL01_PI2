using System;
using UnityEngine;

namespace Assets.App.Common.Scripts.CustomProperties.Vector2WithLimits
{
    public class Vector2WithLimitsAttribute : PropertyAttribute
    {
        public readonly float MinX, MaxX, MinY, MaxY;

        public Vector2WithLimitsAttribute(
            float minX = float.MinValue,
            float maxX = float.MaxValue,
            float minY = float.MinValue,
            float maxY = float.MaxValue
        )
        {
            if (maxX <= minX)
            {
                throw new ArgumentException("Conflict in X limits for Vector2WithLimits attribute");
            }
            if (maxY <= minY)
            {
                throw new ArgumentException("Conflict in Y limits for Vector2WithLimits attribute");
            }

            MinX = minX;
            MaxX = maxX;
            MinY = minY;
            MaxY = maxY;

            // var limits = DefineLimits(minX, maxX);
            // MinX = limits[0];
            // MaxX = limits[1];

            // limits = DefineLimits(minY, maxY);
            // MinY = limits[0];
            // MaxY = limits[1];
        }

        // private const int LIMIT_WITHOUT_MIN_WITHOUT_MAX = 0b00;
        // private const int LIMIT_WITH_MIN_WITHOUT_MAX = 0b10;
        // private const int LIMIT_WITHOUT_MIN_WITH_MAX = 0b01;
        // private const int LIMIT_WITH_MIN_WITH_MAX = 0b11;
        // private float[] DefineLimits(float? inputMin, float? inputMax)
        // {
        //     var hasMinBit = inputMin.HasValue ? LIMIT_WITH_MIN_WITHOUT_MAX : LIMIT_WITHOUT_MIN_WITHOUT_MAX;
        //     var hasMaxBit = inputMax.HasValue ? LIMIT_WITHOUT_MIN_WITH_MAX : LIMIT_WITHOUT_MIN_WITHOUT_MAX;
        //     var limitConfigBit = hasMinBit | hasMaxBit;
        //     switch (limitConfigBit)
        //     {
        //         case LIMIT_WITH_MIN_WITHOUT_MAX:
        //             return new[] { inputMin.Value, 0f };
        //         case LIMIT_WITHOUT_MIN_WITH_MAX:
        //             return new[] { 0f, inputMax.Value };
        //         case LIMIT_WITH_MIN_WITH_MAX:
        //             return new[] { inputMin.Value, inputMax.Value };
        //         default:
        //             return new[] { 0f, 0f };
        //     }
        // }
    }
}