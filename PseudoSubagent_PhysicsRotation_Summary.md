# Physics & Rotation Summary (Circular Tilt Maze)

## Goal
Define the physics setup and rotation behavior for the circular tilt maze.

## Rigidbody Settings (Ball)
- `mass`: `1.0`
  - Rationale: Keeps gravity behavior intuitive and controllable.
- `drag`: `0.05`
  - Rationale: Slight linear damping to prevent endless micro-rolling.
- `angularDrag`: `0.05`
  - Rationale: Reduces jittery spin on seams.
- `collisionDetection`: `ContinuousDynamic`
  - Rationale: Minimizes tunneling through thin interior walls at speed.
- `interpolation`: `Interpolate`
  - Rationale: Smooths visual motion between physics steps.

## Rotation Behavior (Maze)
- Rotate around **world Z only**, driven by `A/D` input.
- Use a serialized `degreesPerSecond` (suggest `45f`) and apply rotation in `FixedUpdate` with `Time.fixedDeltaTime`.
- Example behavior (conceptual): `Rotate(Vector3.forward * input * degreesPerSecond * Time.fixedDeltaTime, Space.World)`.
- Rationale: Keeps axis locked to world Z and syncs rotation with physics.

## Ball Confinement (No-Floor Directive)
- Maze is a short, wide cylinder with **no bottom collider** so the ball can fall out the exit hole.
- If the ball can escape unintentionally, add a thin interior rim/lip collider near the top edge (not a floor).
- Optionally use layer collision filtering so the ball only collides with maze walls (avoid external scaffolding collisions).

## Physics Gotchas
- Wall colliders must be **non-trigger** and have adequate thickness.
- Ball `Rigidbody` should be **non-kinematic** with gravity enabled.
- Stable `Fixed Timestep` helps reduce jitter and missed collisions.
- If using triggers for win detection, separate layers to keep wall collisions solid.

## Constraints
- All tunables must be serialized fields.
- Avoid magic numbers in code.
