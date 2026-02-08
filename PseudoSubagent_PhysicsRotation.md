# Pseudo-Subagent 2: Physics & Rotation Plan

## Goal
Define the physics setup and rotation behavior for the circular tilt maze.

## Context Summary
- Rotation axis: world Z only.
- Input: legacy Input Manager (`Input.GetKey(KeyCode.A/D)`)
- Ball uses Rigidbody + SphereCollider; movement via gravity only.
- Maze is a short wide cylinder; no floor per spec; internal walls constrain ball.
- Exit: physical hole; ball falls out and win message logs.

## What to deliver
1. Recommended Rigidbody settings for the ball (mass, drag, angular drag, collision detection mode).
2. Rotation behavior: how to rotate maze smoothly with A/D, degrees per second, and whether to use Time.deltaTime or fixed update.
3. How to keep the ball constrained to the maze (if necessary) while respecting the no-floor directive.
4. Any Unity physics gotchas (colliders, layers, triggers) relevant here.

## Constraints
- All tunables must be serialized fields.
- Avoid magic numbers in code.

## Output Format
Provide bullet points for each item, with suggested default values and rationale.
