# Unity Implementation & Scene Setup Findings

## Hierarchy (Concise)
- MazeScene
- MazeRoot (empty)
- MazeRotator (empty, rotates around world Z)
- MazeParent (all maze geometry under this)
- OuterCylinder (mesh + collider)
- InnerCylinder (mesh + collider)
- MazeRings (empty)
- Ring_01 (mesh + collider)
- Ring_02 (mesh + collider)
- Ring_03 (mesh + collider)
- Ring_04 (mesh + collider)
- Ring_05 (mesh + collider)
- Dividers (empty)
- Divider_01 ... Divider_16 (mesh + collider)
- ExitHole (trigger)
- BallRoot (empty)
- BallSpawner (empty)
- Ball (sphere + rigidbody + collider)

## Scripts and Responsibilities
- MazeRotator
- Reads Legacy Input Manager axes.
- Rotates MazeRotator around world Z.
- Exposes rotation speed, smoothing, and optional clamp.
- MazeBuilder
- Builds or positions maze geometry deterministically.
- Ensures rings/dividers/outer cylinder align to constants.
- Exposes all tunables for layout.
- BallSpawner
- Spawns the ball at a defined start transform.
- Optionally respawns on reset.
- ExitTrigger
- Trigger on the exit hole.
- Detects ball exit and signals completion.

## Scene Setup Checklist
1. Create `MazeScene.unity` and add an empty `MazeRoot`.
2. Add `MazeRotator` under `MazeRoot`. This is the rotating parent.
3. Add `MazeParent` under `MazeRotator` and place all maze geometry under it.
4. Create `OuterCylinder`, `InnerCylinder`, `Ring_01..Ring_05`, and `Divider_01..Divider_16`.
5. Add mesh renderers and mesh colliders to all maze geometry.
6. Add `ExitHole` as a child of `OuterCylinder` and give it a trigger collider.
7. Add `BallRoot` under `MazeRoot`, then `BallSpawner` and `Ball`.
8. Add `Rigidbody` and `SphereCollider` to `Ball`.
9. Add scripts:
10. `MazeRotator` on `MazeRotator`.
11. `MazeBuilder` on `MazeParent` (or a dedicated `MazeBuilder` object).
12. `BallSpawner` on `BallSpawner`.
13. `ExitTrigger` on `ExitHole`.
14. Wire references in the inspector (ball prefab, spawn point, exit target).
15. Confirm Legacy Input Manager axes are configured and match script inputs.

## Collider and Rigidbody Notes
- Maze geometry should use non-trigger colliders.
- Exit hole uses a trigger collider sized to the opening.
- Ball uses a dynamic `Rigidbody` with continuous collision detection.
- Ensure the ball’s rigidbody interpolation is enabled to reduce jitter.
- Freeze ball rotation only if needed; otherwise allow natural roll.
