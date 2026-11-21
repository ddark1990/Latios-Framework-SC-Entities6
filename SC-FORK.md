# Latios SC fork (Entities 6.6)

- **Upstream base:** Latios Framework 0.15.4 (`776f125…` park)
- **Target:** Unity 6000.6 + Entities / Entities Graphics / Collections **6.6**, Burst **2.0** (built in)
- **Why:** upstream (0.16.6, 2026-11-09) still targets Entities 1.4.8 on Unity 6000.3; Entities 6.x needs this fork
- **Unity 6000.5 / Entities 6.5:** branch `entities-6.5` (what Chaos Tower runs, plus its fixes)

## Verified

Headless batchmode compile on Unity 6000.6.10f1 (2026-11-21), Entities, Entities Graphics, NetCode 6.6.0, URP and
VFX Graph 17.6.0: 0 errors, all 16 Latios assemblies and the asmref injections loaded, in both transform modes
(default QVVS, and `LATIOS_TRANSFORMS_UNITY`). Projects must define `UNITY_BURST_EXPERIMENTAL_ATOMIC_INTRINSICS`.

Not verified: Burst AOT of every job (needs a player build), any runtime behaviour, the MecanimV2 and other add-ons
(they live in the consuming project, not here).

## What differs from upstream 0.15.4

- `Core/Math/LatiosMathCompat.cs` replaces `MathematicsExpansion`: Unity.Mathematics is an engine module behind
  type forwarders from 6000.5, so the asmref cannot inject members. Bodies are upstream's.
- `UnityObjectRef` stores an `EntityId`: `EntityId()` reads it unmanaged (Burst-safe); id comparisons use `EntityId`,
  never a hash. `GetInstanceID` is an error on 6000.5+.
- `ENTITY_STORE_V1` is not required (it breaks Unity.Entities.Editor on 6.x). The Unity.Scenes ForEach injects are
  disabled (`WithStructuralChanges` was removed).
- 6.6: `NativeArray` converts to `ReadOnlySpan` through an `in` operator, so spans of temporaries use `AsReadOnlySpan()`;
  Burst 2 needs `[UnmanagedFunctionPointer(Cdecl)]` on dispatch delegates used from other assemblies.
- Fixes Chaos Tower carried (Editor-only AfterLiveBaking injection, Android arm64 ACL entry points, backwards root
  motion), the root-motion interpolation-mode fix backported from upstream 0.16, no NetCode dependency.

## Open

Entities 6.6 deprecates managed components (warnings now, removal later): BlackboardEntity managed shared
components, SceneManagerSystem `GetComponentObject`, managed struct storage, `PlaybackPolicy.MultiPlayback` in
SyncPointPlaybackSystem, and Kinemation's `RenderMeshArray` path (Entities Graphics 6.6 adds `RenderMeshArrayHost`).
29 warnings in a Unity-transforms build. These need a design port before Unity removes the APIs.

## Do not

- Merge casually into upstream
- Put this folder under `Packages/` by name alone without manifest pin (UPM auto-embeds)

## Manifest

```json
"com.latios.latiosframework": "file:com.latios.latiosframework"
```
