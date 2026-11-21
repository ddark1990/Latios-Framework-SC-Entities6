using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace Latios
{
    /// <summary>
    /// SC Entities 6 fork: the members upstream injects into Unity.Mathematics through the MathematicsExpansion asmref.
    /// From Unity 6000.5 Unity.Mathematics is an engine module behind type forwarders, so partial injection cannot compile;
    /// each body below is upstream 0.15.4's, so results match upstream.
    /// </summary>
    public static class LatiosMathCompat
    {
        /// <summary>Returns b if c is true, a otherwise.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Select(bool a, bool b, bool c) => a ^ ((a ^ b) & c);

        /// <summary>Returns b if c is true, a otherwise.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 Select(bool2 a, bool2 b, bool c) => a ^ ((a ^ b) & c);

        /// <summary>Returns b if c is true, a otherwise.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 Select(bool3 a, bool3 b, bool c) => a ^ ((a ^ b) & c);

        /// <summary>Returns b if c is true, a otherwise.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 Select(bool4 a, bool4 b, bool c) => a ^ ((a ^ b) & c);

        /// <summary>Per component, returns b where c is true, a otherwise.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 Select(bool2 a, bool2 b, bool2 c) => a ^ ((a ^ b) & c);

        /// <summary>Per component, returns b where c is true, a otherwise.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 Select(bool3 a, bool3 b, bool3 c) => a ^ ((a ^ b) & c);

        /// <summary>Per component, returns b where c is true, a otherwise.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 Select(bool4 a, bool4 b, bool4 c) => a ^ ((a ^ b) & c);

        /// <summary>The vector rotated by the inverse of an assumed-normalized rotation.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 InverseRotateFast(quaternion normalizedRotation, float3 vector)
        {
            return math.rotate(math.conjugate(normalizedRotation), vector);
        }

        /// <summary>The second rotation rotated by the inverse of the assumed-normalized first.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quaternion InverseRotateFast(quaternion normalizedRotation, quaternion rotationToBeRotated)
        {
            return math.mul(math.conjugate(normalizedRotation), rotationToBeRotated);
        }

        /// <summary>A translation, rotation and scale matrix without the constant bottom row.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x4 Float3x4TRS(float3 translation, quaternion rotation, float3 scale)
        {
            float3x3 r = new float3x3(rotation);
            return new float3x4(r.c0 * scale.x, r.c1 * scale.y, r.c2 * scale.z, translation);
        }

        /// <summary>A scale matrix without the constant bottom row.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3x4 Float3x4Scale(float3 scale)
        {
            return new float3x4(new float3(scale.x, 0f, 0f), new float3(0f, scale.y, 0f), new float3(0f, 0f, scale.z), float3.zero);
        }

        /// <summary>The identity matrix without the constant bottom row. A property rather than a static field, so Burst never needs a static constructor.</summary>
        public static float3x4 Float3x4Identity
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new float3x4(new float3(1f, 0f, 0f), new float3(0f, 1f, 0f), new float3(0f, 0f, 1f), float3.zero);
        }
    }
}
