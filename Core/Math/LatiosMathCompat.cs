using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace Latios
{
    /// <summary>
    /// SC Entities 6 fork: replacements for Latios MathematicsExpansion (asmref into Unity.Mathematics).
    /// Builtin mathematics 1.4 on Unity 6000.5 is a module shim — partial injection is broken.
    /// </summary>
    public static class LatiosMathCompat
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 InverseRotateFast(quaternion normalizedRotation, float3 vector)
        {
            return math.rotate(math.conjugate(normalizedRotation), vector);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quaternion InverseRotateFast(quaternion normalizedRotation, quaternion rotationToBeRotated)
        {
            return math.mul(math.conjugate(normalizedRotation), rotationToBeRotated);
        }

        /// <summary>Build a float3x4 TRS using float4x4.TRS then packing columns.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x4 Float3x4TRS(float3 translation, quaternion rotation, float3 scale)
        {
            float4x4 m = float4x4.TRS(translation, rotation, scale);
            return new float3x4(
                m.c0.xyz,
                m.c1.xyz,
                m.c2.xyz,
                m.c3.xyz);
        }

        public static readonly float3x4 Float3x4Identity = Float3x4TRS(float3.zero, quaternion.identity, new float3(1f));
    }
}

