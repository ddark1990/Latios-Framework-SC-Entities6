# Latios Framework — Survival Chaos fork (Entities 6)

**Upstream:** [Dreaming381/Latios-Framework](https://github.com/Dreaming381/Latios-Framework) v0.15.4  
**Fork owner:** [ddark1990](https://github.com/ddark1990)  
**Target:** Unity **6000.5** + Entities / NetCode / Collections **6.5**

## Why this fork exists

Upstream Latios **0.15.x** targets **Entities 1.4** and states that **Entities 6.4+ is not supported**.  
Survival Chaos runs on **Unity 6000.5** with **builtin Entities 6.5** (cannot re-pin to 1.4).  
This fork ports Latios for that stack.

**Status:** experimental / in progress. NetCode + Kinemation are the high-risk areas.

## Package install (UPM)

```
https://github.com/ddark1990/Latios-Framework-SC-Entities6.git
```

Or pin a commit:

```json
"com.latios.latiosframework": "https://github.com/ddark1990/Latios-Framework-SC-Entities6.git#main"
```

Local (Survival Chaos):

```json
"com.latios.latiosframework": "file:_ParkedPackages/com.latios.latiosframework-sc"
```

## Defines (typical)

- `LATIOS_TRANSFORMS_UNITY` — Unity transforms + NetCode
- `LATIOS_ADDON_MECANIM_V2` — MecanimV2 add-on (project Plugins)

## License

Same as upstream: **Unity Companion License** (derivative of Unity ECS packages).  
See `LICENSE.md` and `THIRD PARTY NOTICES.md`.

## Docs

- `SC-FORK.md` — fork notes  
- Survival Chaos: `docs/LATIOS-ACTIVATE.md`
