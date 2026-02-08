# Pseudo-Subagent 3: Unity Implementation & Scene Setup

## Goal
Draft implementation structure and Unity scene setup steps (objects, hierarchy, components).

## Context Summary
- Maze rotates around world Z as a single parent object.
- Deterministic maze layout; no randomness.
- Exit is a physical hole in the outer cylinder wall.
- Legacy Input Manager only.
- Scripts live under `Assets/Scripts/BenchmarkTasks/CircularTiltMaze/`.

## What to deliver
1. Proposed GameObject hierarchy in the scene.
2. List of scripts and what each does (MazeRotator, Builder, BallSpawner, ExitTrigger, etc.).
3. Steps to place objects in `MazeScene.unity` and wire references.
4. Any additional collider or rigidbody configuration details.

## Constraints
- All tunables exposed via serialized fields.
- No UI, audio, or extra systems.

## Output Format
Provide:
- A concise hierarchy tree.
- A list of scripts with responsibilities.
- A step-by-step setup checklist.
