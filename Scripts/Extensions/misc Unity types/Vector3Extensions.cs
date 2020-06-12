﻿using UnityEngine;

namespace JimmysUnityUtilities
{
    public static class Vector3Extensions
    {
        public static Vector3 ClampDimensions(this Vector3 value, Vector3 min, Vector3 max)
        {
            return new Vector3
                (
                Mathf.Clamp(value.x, min.x, max.x),
                Mathf.Clamp(value.y, min.y, max.y),
                Mathf.Clamp(value.z, min.z, max.z)
                );
        }

        public static Vector3 CapRange(this Vector3 value, float maxX, float maxY, float maxZ)
            => CapRange(value, new Vector3(maxX, maxY, maxZ));

        public static Vector3 CapRange(this Vector3 value, Vector3 max)
        {
            return new Vector3
                (
                value.x.CapRange(max.x),
                value.y.CapRange(max.y),
                value.z.CapRange(max.z)
                );
        }

        public static bool IsPrettyCloseToPointingInTheSameDirectionAs(this Vector3 vectorA, Vector3 vectorB, float dotMarginOfError = 0.05f)
            => Vector3.Dot(vectorA, vectorB).IsPrettyCloseTo(1, dotMarginOfError);

        public static bool IsPrettyCloseToPointingInTheOppositeDirectionAs(this Vector3 vectorA, Vector3 vectorB, float dotMarginOfError = 0.05f)
            => Vector3.Dot(vectorA, vectorB).IsPrettyCloseTo(-1, dotMarginOfError);

        public static bool IsPrettyCloseToBeingPerpendicularWith(this Vector3 vectorA, Vector3 vectorB, float dotMarginOfError = 0.05f)
            => Vector3.Dot(vectorA, vectorB).IsPrettyCloseTo(0, dotMarginOfError);

        public static bool IsPrettyCloseToPointingAlongSameAxisAs(this Vector3 vectorA, Vector3 vectorB, float dotMarginOfError = 0.05f)
            => vectorA.IsPrettyCloseToPointingInTheSameDirectionAs(vectorB, dotMarginOfError) || vectorA.IsPrettyCloseToPointingInTheOppositeDirectionAs(vectorB, dotMarginOfError);
    }
}