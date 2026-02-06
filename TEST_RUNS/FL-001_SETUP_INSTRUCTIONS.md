# FL-001 — Manual Setup Instructions (Unity Editor)

After the scripts are created, perform these steps in the Unity Editor to complete the flashlight system setup.

---

## 1. Create the Flashlight GameObject

1. In the Hierarchy, select **Main Camera**.
2. Right-click → **Create Empty** (or GameObject → Create Empty).
3. Rename it to **Flashlight**.
4. Ensure it is a child of Main Camera. Reset its Transform: Position (0, 0, 0), Rotation (0, 0, 0), Scale (1, 1, 1).

---

## 2. Add Light Component

1. Select **Flashlight**.
2. Add Component → **Light**.
3. Set:
   - **Type**: Spot
   - **Range**: 10
   - **Spot Angle**: 45
   - **Intensity**: 1
   - **Color**: White (or warm yellow)
4. Leave the Light **disabled** initially (uncheck the component)—the script will enable it when toggled on.

---

## 3. Add AudioSource Component

1. With **Flashlight** selected, Add Component → **Audio Source**.
2. Leave **Play On Awake** unchecked.
3. No audio clips need to be assigned—the script uses Debug.Log when clips are null.

---

## 4. Add Scripts to Flashlight

1. With **Flashlight** selected, Add Component → **Battery Manager**.
2. Add Component → **Flashlight Controller**.
3. The scripts will auto-find Light, AudioSource, and BatteryManager on the same GameObject.
4. Optionally adjust BatteryManager defaults:
   - Depletion Rate: 0.15
   - Recharge Rate: 0.1
   - Low Battery Threshold: 0.2
   - Min Battery To Turn On: 0.05

---

## 5. Create the Battery UI Canvas

1. Right-click in Hierarchy → **UI** → **Canvas**.
2. Ensure Canvas is set to **Screen Space - Overlay**.
3. Add a child: Right-click Canvas → **UI** → **Panel**. Rename to **BatteryPanel**.
4. Set BatteryPanel RectTransform:
   - Anchor: Bottom-right (click anchor presets, hold Alt, click bottom-right).
   - Pivot: (1, 0)
   - Pos X: -80, Pos Y: 40
   - Width: 150, Height: 30

---

## 6. Add Battery Fill (Image Option)

1. Right-click **BatteryPanel** → **UI** → **Image**. Rename to **BatteryFill**.
2. Set BatteryFill RectTransform to stretch within the panel (anchor stretch both axes, left/right/top/bottom = 5).
3. Set Image component:
   * DIDN'T MENTION SELECTING IMAGE SPRITE TO EB BACKGROUND *
   - **Image Type**: Filled
   - **Fill Method**: Horizontal
   - **Fill Origin**: Left
   - **Fill Amount**: 1
   - **Color**: Green (or your preference)

---

## 7. Add FlashlightUI Script

1. Select **BatteryPanel** (or BatteryFill if you prefer the script on the fill object).
2. Add Component → **Flashlight UI**.
3. Drag **BatteryFill** into the **Battery Fill Image** field.

**Alternative: Slider**

- Instead of Image, you can use a **Slider**: Right-click BatteryPanel → UI → Slider. Remove the Handle Slide Area and Background if desired; keep the Fill. Assign the Slider to **Battery Slider** on FlashlightUI.

**Alternative: Text**

- Add a **Text** child, assign it to **Battery Text** on FlashlightUI to show percentage instead.

---

## 8. Verify Hierarchy

```
Main Camera
└── Flashlight
    ├── Light (Spot)
    ├── Audio Source
    ├── Flashlight Controller
    └── Battery Manager

Canvas
└── BatteryPanel
    ├── BatteryFill (Image, Filled)
    └── Flashlight UI (script)
```

---

## 9. Test

1. Enter **Play** mode.
2. Press **F** to toggle the flashlight.
3. Confirm: light on/off, battery drains when on, recharges when off, UI updates, Console shows Debug.Log for on/off/low-battery.
