# Flashlight System — Setup Instructions

## Scene Setup (Manual Steps in Unity)

1. **Player GameObject**
   - Select the Player (Capsule) in the hierarchy
   - Add Component → `FlashlightBattery`
   - Add Component → `FlashlightController`
   - Add Component → `AudioSource` (optional, for sounds)
   - Add Component → `Light` (as child, or add to Player):
     - Create empty child: Right-click Player → Create Empty, name it "FlashlightLight"
     - Add Light component to FlashlightLight
     - Set Type: Spot
     - Set Range: 15–20
     - Set Spot Angle: 60
     - Position: (0, 0.5, 0.5) or similar so it points forward
     - Rotation: Point forward (e.g., X = -20 to angle down slightly)
   - Assign the Light to FlashlightController's `_flashlight` field
   - Assign AudioSource to FlashlightController's `_audioSource` field (if using sounds)

2. **UI Canvas**
   - GameObject → UI → Canvas (creates Canvas + EventSystem)
   - On Canvas: Add child → UI → Image (name: BatteryBackground)
   - Add child to BatteryBackground → UI → Image (name: BatteryFill)
     - On BatteryFill: Set Image Type = Filled, Fill Method = Horizontal
     - Set Color to green (or desired)
     - Anchor to bottom-right of screen
   - Optionally: Add UI → Text for percentage display
   - Add `FlashlightUI` component to Canvas (or a child)
   - Assign BatteryFill (Image) to `_batteryFillImage`
   - Assign Text to `_batteryText` (if using)
   - FlashlightUI will find FlashlightBattery automatically if not assigned

3. **Audio (Optional)**
   - Assign AudioClips to FlashlightController for On/Off/LowBattery sounds
   - If no clips assigned, no errors—audio is skipped gracefully

## Quick Test

- Enter Play mode
- Press **F** to toggle flashlight
- Verify battery drains when on, recharges when off
- Verify UI updates
- Verify auto-off at 0% battery
