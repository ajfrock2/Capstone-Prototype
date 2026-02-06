# Benchmark Task: Flashlight System

## Overview

Implement a flashlight system for a first-person or third-person character. The flashlight attaches to the player, can be toggled on/off, has a battery that depletes when active and recharges when off, and provides audio/visual feedback.

This task is designed to reveal AI strengths and weaknesses in:
- Unity component architecture
- Input handling
- UI integration
- Audio integration
- State management
- Configuration (avoiding magic numbers)

---

## Functional Requirements

### 1. Toggle On/Off
- **Input**: Press `F` key to toggle the flashlight on or off
- **Behavior**: When on, the light is visible and active. When off, the light is disabled.
- **Initial state**: Flashlight starts OFF when the scene loads

### 2. Light Component
- Use Unity's built-in **Light** component (Type: Spot recommended)
- Light must be a child of the Player (or follow the player)
- Light activates when flashlight is on, deactivates when off
- Light should point forward (in the direction the player faces)

### 3. Battery System
- **Battery level**: 0–100% (or 0.0–1.0)
- **Depletion**: When flashlight is ON, battery drains over time at a configurable rate
- **Recharge**: When flashlight is OFF, battery recharges over time at a configurable rate
- **Empty battery**: When battery reaches 0%, flashlight automatically turns off and cannot be turned on until it has recharged above a minimum threshold (e.g., 5%)
- **Full battery**: Battery does not exceed 100%

### 4. Audio Feedback
- **On sound**: Play a sound when flashlight is turned on
- **Off sound**: Play a sound when flashlight is turned off
- **Low battery warning**: Play a distinct sound when battery drops below a threshold (e.g., 20%)
  - Should not spam—play once per low-battery entry, or at intervals
- Use Unity's **AudioSource** component
- Audio clips can be placeholder (null checks required—graceful behavior if no clip assigned)

### 5. Visual Battery Indicator
- **UI element**: A simple battery bar or percentage text on screen
- Use Unity **Canvas** and **UI** elements (Image, Slider, or Text)
- Should update in real time as battery drains/recharges
- Position: Corner of screen (e.g., bottom-right)
- Style: Minimal—a filled bar or text is sufficient

---

## Technical Constraints

### Required Unity Components
- **Light** (Spot or Point)
- **AudioSource**
- **Canvas** (Screen Space - Overlay) for UI
- **UI Image** or **Slider** or **Text** for battery display

### Input
- Use **Input Manager** (legacy): `Input.GetKeyDown(KeyCode.F)` or equivalent
- OR use **Input System** (new): If using new Input System, specify in implementation
- Do not use both—pick one for consistency

### Configuration
- **No magic numbers**: All tunable values must be exposed as serialized fields or in a ScriptableObject
  - Depletion rate (e.g., % per second)
  - Recharge rate (e.g., % per second)
  - Low battery threshold (%)
  - Minimum battery to turn on (%)
- Use `[SerializeField]` or `[Range()]` for Inspector tuning

### Code Organization
- Scripts should go in `Assets/Scripts/BenchmarkTasks/FlashlightSystem/`
- Prefer component-based design (e.g., separate `FlashlightController`, `Battery`, `FlashlightUI` if it improves clarity)
- Single monolithic script is acceptable if well-organized

---

## Success Criteria

### Must Pass
1. **Compiles** without errors
2. **Runs** in Play mode without crashes
3. **Toggle**: F key turns light on/off
4. **Battery**: Drains when on, recharges when off
5. **Auto-off**: Flashlight turns off when battery reaches 0%
6. **UI**: Battery level visible and updates
7. **Audio**: On/off sounds play (if clips assigned); no errors if clips are null)

### Nice to Have
- Low battery warning sound
- Smooth battery bar animation
- Configurable via ScriptableObject

---

## Baseline Scene Context

The benchmark scene contains:
- **Main Camera** (tagged MainCamera)
- **Directional Light** (environment lighting)
- **Ground** (Plane at y=0)
- **Player** (Capsule at 0, 1, 0)

The flashlight should attach to the Player. If the player has no movement script, the flashlight can be stationary—focus is on the flashlight system, not player movement.

---

## Out of Scope (Do Not Implement)

- Player movement
- Multiple flashlights
- Flashlight upgrades or power-ups
- Save/load of battery state
- Network sync
- Mobile touch input (keyboard only for prototype)

---

## Clarification Questions (AI Interview Phase)

Before implementing, the AI may ask:
- Preferred input system (Legacy vs New Input System)?
- Should the light be a child of Player or Camera?
- Exact UI layout preferences?
- Any specific coding style or naming conventions?

Document all Q&A for reproducibility.
