# Benchmark Task: Circular Tilt Maze

## Overview

Implement a circular tilt-maze puzzle in a 3D Unity scene. The maze is a 2D circular layout (flat), and the player rotates the maze clockwise/counterclockwise on a single axis to guide a ball from a start position to an exit hole. The task focuses on physics interaction, input handling, and clean component design.

This task is designed to reveal AI strengths and weaknesses in:
- Unity physics setup
- Transform rotation and input handling
- Collider configuration for maze walls and holes
- Scene setup instructions
- Configuration (avoiding magic numbers)

---

## Functional Requirements

### 1. Maze Rotation
- **Input**: Press `A` to rotate counterclockwise, `D` to rotate clockwise
- **Axis**: Single axis rotation only (e.g., Yaw around world Y or Pitch around local X; pick one and document)
- **Behavior**: Rotation should be smooth and continuous while the key is held
- **Initial state**: Maze starts at 0 rotation

### 2. Circular 2D Maze Layout
- The maze is a **flat circular layout** (2D solution), not a sphere
- Walls form concentric rings and radial barriers to create a solvable path
- The AI must **generate a simple maze layout** (e.g., by placing walls manually in code or by procedural placement of segments)
- Maze should be navigable: there must be exactly one clear path from start to exit

### 3. Ball Movement
- The ball starts at a defined **Start** position in the maze
- The ball moves via **Unity physics** (Rigidbody + Colliders)
- Gravity causes the ball to roll as the maze is rotated
- Ball must remain constrained to the maze surface (no flying away)

### 4. Exit Hole and Win Condition
- The maze has a single **Exit Hole** where the ball can fall through
- When the ball falls through the exit, the task is considered complete
- On success, log a message to the Console (e.g., `"Maze Complete"`)

---

## Technical Constraints

### Required Unity Components
- **Rigidbody** (ball)
- **Colliders** for maze floor and walls (MeshCollider or BoxCollider)
- **Trigger collider** for exit detection OR physical hole that the ball can fall through

### Input
- Use **Input Manager (legacy)**: `Input.GetKey(KeyCode.A)` / `Input.GetKey(KeyCode.D)`
- Do not use the new Input System

### Configuration
- **No magic numbers**: All tunable values must be exposed as serialized fields
  - Rotation speed (degrees/sec)
  - Ball mass
  - Maze radius
  - Wall height/thickness
  - Start position
  - Exit hole position/size

### Code Organization
- Scripts should go in `Assets/Scripts/BenchmarkTasks/CircularTiltMaze/`
- Prefer component-based design (e.g., `MazeRotator`, `MazeBuilder`, `BallController`, `ExitTrigger`)
- Single monolithic script is acceptable if well-organized

---

## Success Criteria

### Must Pass
1. **Compiles** without errors
2. **Runs** in Play mode without crashes
3. **Rotation**: `A`/`D` rotate the maze smoothly in opposite directions
4. **Ball Physics**: Ball rolls via physics; no scripted movement
5. **Start/Exit**: Ball starts at the start point and can reach the exit
6. **Win Condition**: On exit, a console message confirms completion

### Nice to Have
- Simple procedural maze generation
- Visual gizmos in editor for start/exit
- Reset key to return the ball to start

---

## Baseline Scene Context

The benchmark scene contains:
- **Main Camera** (facing the maze; direction determined by the scene setup)
- **Directional Light**
- **Ground** (Plane at y=0)

You will create the maze and ball GameObjects in the scene. The maze should be positioned so it is clearly visible from the camera.

---

## Out of Scope (Do Not Implement)

- UI elements (timers, score, etc.)
- Multiple mazes or levels
- Save/load systems
- Mobile or touch input
- Audio or particle effects

---

## Clarification Questions (AI Interview Phase)

Before implementing, the AI may ask:
- Which rotation axis is preferred (world Y vs local X)?
- Should the exit be a physical hole or trigger volume?
- Any specific maze layout constraints beyond �solvable�?

Document all Q&A for reproducibility.
