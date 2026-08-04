# Latios SC fork (Entities 6.5)

- **Upstream base:** Latios Framework 0.15.4 (`776f125…` park)
- **Target:** Unity 6000.5 + Entities / NetCode / Collections **6.5**
- **Why:** Upstream does not support Entities 6.4+; SC cannot re-pin to Entities 1.4 on this editor

## Status

Experimental. NetCode + Kinemation are the hard parts. See `docs/LATIOS-ACTIVATE.md`.

## Do not

- Merge casually into upstream
- Put this folder under `Packages/` by name alone without manifest pin (UPM auto-embeds)

## Manifest

```json
"com.latios.latiosframework": "file:_ParkedPackages/com.latios.latiosframework-sc"
```
