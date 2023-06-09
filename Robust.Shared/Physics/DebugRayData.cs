﻿using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Robust.Shared.Maths;

namespace Robust.Shared.Physics
{
    public struct DebugRayData
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DebugRayData(Ray ray, float maxLength, [CanBeNull] RayCastResults? results)
        {
            Ray = ray;
            MaxLength = maxLength;
            Results = results;
        }

        public Ray Ray
        {
            get;
        }

        public RayCastResults? Results { get; }
        public float MaxLength { get; }
    }
}
