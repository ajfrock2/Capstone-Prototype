# FL-001 — Flashlight System Implementation Plan

**Test**: FL-001 (Cursor, first AI run)  
**Benchmark Task**: Flashlight System  
**Status**: Approved — Pre-Implementation

---

## 1. Components/Scripts to Create

| Script | Responsibility | Lives On |
|--------|----------------|----------|
| **FlashlightController.cs** | Input (F key), toggles light on/off, triggers audio (or Debug.Log), coordinates with BatteryManager for min-level check and auto-off | Flashlight GameObject |
| **BatteryManager.cs** | Tracks battery level (0–1), depletion when on / recharge when off, thresholds, low-battery warning | Flashlight GameObject |
| **FlashlightUI.cs** | Reads battery level, updates UI (Slider fill or Text) | Canvas UI GameObject |

---

## 2. How They Interact

- **FlashlightController** reads F key input. When pressed and battery allows, toggles on/off. Tells BatteryManager when flashlight is active (for depletion vs recharge). Handles auto-off when battery hits 0. Triggers on/off/low-battery audio or Debug.Log.
- **BatteryManager** holds current level, depletion/recharge rates, thresholds. In Update, depletes or recharges based on active state. Fires low-battery warning (once per entry). Exposes CurrentLevel for UI.
- **FlashlightUI** finds BatteryManager, updates UI element each frame with current level.

---

## 3. Key Design Decisions

| Decision | Choice | Rationale |
|----------|--------|-----------|
| **Input** | Legacy Input Manager | Simple; no package dependencies; `Input.GetKeyDown(KeyCode.F)` |
| **Light attachment** | Child of Main Camera | First-person; light follows view |
| **Battery representation** | 0–1 float internally, display as % | Simple math, Inspector-friendly |
| **Script count** | 3 scripts | Separation of concerns, maintainability |
| **Audio when no clips** | Debug.Log for on/off/low-battery | Prototype has no audio assets; no null refs |
| **Low-battery warning** | Once per "entry" below threshold | Avoids spam |
| **Configuration** | `[SerializeField]` with `[Range()]` | No magic numbers; Inspector-tuning |

---

## 4. GameObject / Scene Structure

**Hierarchy:**
```
Main Camera
└── Flashlight (empty GameObject)
    ├── Light (Spot, points forward)
    ├── AudioSource
    ├── FlashlightController
    └── BatteryManager

Canvas (Screen Space - Overlay)
└── BatteryPanel (Anchor: bottom-right)
    ├── Background (Image)
    ├── Fill (Image, Type: Filled, or Slider)
    └── FlashlightUI (script)
```

---

## 5. Serialized Fields (No Magic Numbers)

**BatteryManager:**
- `depletionRate` — % per second when on (e.g., 0.15)
- `rechargeRate` — % per second when off (e.g., 0.1)
- `lowBatteryThreshold` — % below which to warn (e.g., 0.2)
- `minBatteryToTurnOn` — % required to turn on (e.g., 0.05)

**FlashlightController:**
- References: `Light`, `AudioSource`
- Optional: `onClip`, `offClip`, `lowBatteryClip` (null = Debug.Log)

**FlashlightUI:**
- `batteryImage` (Image with Fill) or `batterySlider` (Slider) or `batteryText` (Text)

---

## 6. Manual Setup (Post-Script Creation)

1. Create **Flashlight** child of Main Camera
2. Add **Light** (Spot), orient forward, set intensity/range/angle
3. Add **AudioSource**
4. Add **FlashlightController** and **BatteryManager** scripts
5. Create **Canvas** (Screen Space - Overlay)
6. Add battery bar (Image with Fill or Slider) anchored bottom-right
7. Add **FlashlightUI**, assign UI element reference

---

## 7. Prototype-Specific Clarifications (From Interview)

- **First-person**: Light attaches to Main Camera (not Player)
- **Input**: AI chose Legacy Input Manager
- **Iterations**: 1 attempt only (no bug-fix cycles for prototype)
- **Audio**: No clips in project; use Debug.Log when clips are null
- **Script location**: `Prototype-Of-Capstone/Assets/Scripts/BenchmarkTasks/FlashlightSystem/`

---

## 8. Success Criteria (Must Pass)

1. Compiles without errors
2. Runs in Play mode without crashes
3. F key toggles light on/off
4. Battery drains when on, recharges when off
5. Auto-off when battery reaches 0%
6. UI shows battery level and updates in real time
7. Audio/Debug.Log: on/off/low-battery triggers work; no errors when clips are null
