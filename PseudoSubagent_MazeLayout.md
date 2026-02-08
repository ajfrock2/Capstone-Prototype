# Pseudo-Subagent 1: Maze Geometry & Layout

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

## What to deliver
1. A simple but solvable layout description using concentric rings and radial walls.
2. Exact positions/angles for wall segments (length, thickness, height).
3. Start and exit positions in maze local space.
4. Any notes on how to build a gap in the outer wall for the exit.
5. Ensure path is completable within ~2 minutes for first-time user.

## Constraints
- All tunables must be exposed as serialized fields (no magic numbers).
- Maze rotates around world Z as a single parent.
- Use Unity physics with Rigidbody for the ball.

## Output Format
Provide a numbered list of wall segments with:
- Ring index (if applicable)
- Angle range (degrees)
- Radius (for ring walls) or length (for radial walls)
- Position and rotation (local)
- Suggested thickness/height
Also include start/exit coordinates.
