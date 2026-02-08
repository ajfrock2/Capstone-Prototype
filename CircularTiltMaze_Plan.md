# Circular Tilt Maze - Phase 3 Planning

This document captures the approved implementation plan for the Circular Tilt Maze benchmark task. It consolidates the interview decisions and pseudo-subagent findings into an actionable plan for Phase 4.

---

## 1. Core Decisions (From Interview)
- **Rotation axis**: World Z only.
- **Camera**: Stays at `(0, 1, -10)` looking toward the origin; maze placed at origin.
- **Maze shape**: Short, wide cylinder; appears top-down from the camera. No floor.
- **Movement**: Ball moves only via physics + gravity; no scripted movement.
- **Exit**: Physical hole in outer cylinder wall; ball falls out toward `-Y` and logs completion.
- **Determinism**: Fixed, predefined maze layout (no randomness).
- **Difficulty**: Solvable within ~2 minutes for first-time users.
- **All tunables**: Exposed as serialized fields (no magic numbers).

---

## 2. Scripts to Create (Responsibilities)
1. **`MazeRotator`**
   - Reads `A`/`D` (legacy input) and rotates maze around world Z.
   - Runs in `FixedUpdate` for physics sync.
   - Serialized fields: `rotationSpeedDegPerSec`.

2. **`CircularMazeBuilder`**
   - Builds deterministic maze geometry (outer ring with exit gap, inner rings, radial walls).
   - Serialized fields for radii, wall thickness/height, exit gap angles, layout lists, etc.

3. **`BallSpawner`**
   - Spawns/configures ball at Start position.
   - Applies Rigidbody settings (mass, drag, angular drag, collision mode, interpolation).

4. **`ExitHoleTrigger`**
   - Trigger at exit gap; when ball enters, logs `"Maze Complete"`.

---

## 3. Geometry/Layout Plan (Deterministic)
**Concentric Rings**
- Ring radii: `R0=5.0`, `R1=3.5`, `R2=2.2`, `R3=1.0`
- Gaps:
  - Outer ring: `350°–20°` (exit gap)
  - Ring1: `340°–60°`
  - Ring2: `230°–270°`
  - Ring3: `110°–150°`

**Wall Parameters**
- Inner rings thickness: `0.20`, height: `0.50`
- Outer ring thickness: `0.25`, height: `0.60`

**Radial Walls**
- RW1: angle `60°`, length `1.2` (r=1.0 ? 2.2)
- RW2: angle `200°`, length `1.3` (r=2.2 ? 3.5)
- RW3: angle `300°`, length `1.5` (r=3.5 ? 5.0)
- RW4: angle `100°`, length `1.5` (r=3.5 ? 5.0)

**Start/Exit Positions (local space)**
- Start: radius `0.6`, angle `140°`, `y=0.25` ? `(x=-0.46, y=0.25, z=0.39)`
- Exit: angle `5°`, radius `5.0` ? `(x=4.98, y=0.0, z=0.44)`

---

## 4. Physics Setup
**Ball Rigidbody Defaults**
- `mass = 1.0`
- `drag = 0.05`
- `angularDrag = 0.05`
- `collisionDetection = ContinuousDynamic`
- `interpolation = Interpolate`

**Colliders**
- All maze walls: non-trigger colliders.
- Exit hole: trigger collider sized to the outer gap.

---

## 5. Scene Hierarchy (Planned)
- `MazeRoot`
  - `MazeRotator` (script)
    - `MazeParent`
      - `OuterRing` (segments with exit gap)
      - `Ring_01` … `Ring_03`
      - `RadialWalls` (RW1–RW4)
      - `ExitTrigger`
- `BallRoot`
  - `BallSpawner` (script)
  - `Ball` (Rigidbody + SphereCollider)

---

## 6. Implementation Notes
- All scripts live in: `Assets/Scripts/BenchmarkTasks/CircularTiltMaze/`
- Use `FixedUpdate` for rotation to align with physics.
- Rotate **the parent** so the exit, walls, and outer ring all move together.
- Ensure all numeric values are serialized fields.

---

## 7. Phase 4 Deliverables
- Script files (above) created and ready to paste.
- Unity setup checklist with exact steps for object creation and inspector wiring.

