# Pseudo-Subagent 1: Maze Geometry & Layout (Response)

## Goal
Design a deterministic, solvable circular maze layout and describe exact geometry placement.

## Required Output
Provide a clear, step-by-step layout plan that can be implemented in Unity via code-created wall segments.

## Context Summary
- Unity scene: `MazeScene.unity` has Main Camera at (0,1,-10) looking toward origin; Directional Light; Ground plane.
- Maze: short, wide cylinder, rotated so camera sees it from the top; rotation around world Z.
- No floor (as stated). Internal walls are the barriers; ball moves by gravity.
- Exit: physical hole in the cylinder wall; ball falls out toward -Y; needs win condition.
- Deterministic layout: fixed every run (no randomness).
- Radius ~5m, centered at origin (x/z).

## Step-by-Step Layout Plan
1. Create a `MazeRoot` at local (0,0,0). All walls are children of `MazeRoot`. The entire maze rotates around world Z.
2. Build concentric ring walls at radii `R0=5.0`, `R1=3.5`, `R2=2.2`, `R3=1.0` (meters). Each ring is an arc wall (no floor).
3. Cut gaps in rings to create a spiral path:
   - Outer ring gap for exit: `350°–20°`
   - Ring1 gap: `340°–60°`
   - Ring2 gap: `230°–270°`
   - Ring3 gap: `110°–150°`
4. Add radial walls to block shortcuts and guide the path between ring gaps.
5. Place the ball start inside ring3 and the exit at the outer ring gap center.

## Coordinate Conventions
- Local space: XZ plane is the maze plane, Y up.
- Angles in degrees: 0° = +X, 90° = +Z, 180° = -X, 270° = -Z.
- For radial walls, rotation is `(0, ?, 0)` so the wall length runs along local Z.

## Wall Segments (Numbered)
Suggested default thickness = `0.20`, height = `0.50` for inner rings; outer ring thickness = `0.25`, height = `0.60`.
All ring walls have local position `(0,0,0)` and rotation `(0,0,0)` because the arc is defined by angle range.

1. **Outer Ring (index 0, radius 5.0)**
   - Segment A: angle `20°–180°`, radius `5.0`
   - Segment B: angle `180°–350°`, radius `5.0`
   - Thickness `0.25`, height `0.60`
2. **Ring 1 (index 1, radius 3.5)**
   - Segment A: angle `60°–180°`, radius `3.5`
   - Segment B: angle `180°–340°`, radius `3.5`
   - Thickness `0.20`, height `0.50`
3. **Ring 2 (index 2, radius 2.2)**
   - Segment A: angle `270°–360°`, radius `2.2`
   - Segment B: angle `0°–230°`, radius `2.2`
   - Thickness `0.20`, height `0.50`
4. **Ring 3 (index 3, radius 1.0)**
   - Segment A: angle `150°–360°`, radius `1.0`
   - Segment B: angle `0°–110°`, radius `1.0`
   - Thickness `0.20`, height `0.50`
5. **Radial Wall RW1**
   - Connects ring3 ? ring2
   - Angle `60°`, length `1.2` (from r=1.0 to r=2.2)
   - Position: rmid = 1.6 at 60° ? `(x=0.80, y=0, z=1.39)`
   - Rotation `(0, 60, 0)`, thickness `0.20`, height `0.50`
6. **Radial Wall RW2**
   - Connects ring2 ? ring1
   - Angle `200°`, length `1.3` (from r=2.2 to r=3.5)
   - Position: rmid = 2.85 at 200° ? `(x=-2.68, y=0, z=-0.97)`
   - Rotation `(0, 200, 0)`, thickness `0.20`, height `0.50`
7. **Radial Wall RW3**
   - Connects ring1 ? outer ring
   - Angle `300°`, length `1.5` (from r=3.5 to r=5.0)
   - Position: rmid = 4.25 at 300° ? `(x=2.13, y=0, z=-3.68)`
   - Rotation `(0, 300, 0)`, thickness `0.20`, height `0.60`
8. **Radial Wall RW4**
   - Connects ring1 ? outer ring
   - Angle `100°`, length `1.5` (from r=3.5 to r=5.0)
   - Position: rmid = 4.25 at 100° ? `(x=-0.74, y=0, z=4.19)`
   - Rotation `(0, 100, 0)`, thickness `0.20`, height `0.60`

## Start Position (local)
- Use radius `0.6`, angle `140°`, height `y=0.25`
- `(x=-0.46, y=0.25, z=0.39)`

## Exit Position (local)
- Center of outer gap at angle `5°`, radius `5.0`, height `y=0.0`
- `(x=4.98, y=0.0, z=0.44)`

## Notes on Outer Wall Gap
- The exit gap is `350°–20°`. Do not spawn any outer ring wall segment in that range.
- Optionally add a trigger volume just outside the gap to detect win condition as the ball falls toward `-Y`.

This layout is deterministic, simple, and solvable in under ~2 minutes for a first-time user while still requiring a few controlled tilts. Adjust gap widths and radial wall angles to change difficulty.
