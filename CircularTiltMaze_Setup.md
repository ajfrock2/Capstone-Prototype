# Circular Tilt Maze - Setup Instructions

Follow these steps in `MazeScene.unity`.

## 1. Create the Maze Objects
1. Create empty `MazeRoot` at `(0,0,0)`.
2. Create child `MazeRotator` under `MazeRoot` and add `MazeRotator` script.
3. Create child `MazeParent` under `MazeRotator` and add `CircularMazeBuilder` script.
4. Create child `ExitTrigger` under `MazeParent`.
   - Add `BoxCollider` (Is Trigger = true).
   - Add `ExitHoleTrigger` script.
5. In `CircularMazeBuilder`, assign the `ExitTrigger` transform to `Exit Trigger`.

## 2. Create the Ball Spawner
1. Create empty `BallSpawner` in the scene (root or under `MazeRoot`).
2. Add `BallSpawner` script.
3. Assign `MazeParent` to `BallSpawner.mazeSpace`.

## 3. Play Test
1. Enter Play mode.
2. Hold `A` / `D` to rotate the maze around world Z.
3. Ball should roll via physics and exit through the gap.
4. On exit, Console should log: `Maze Complete`.

## Notes
- All tunable values are serialized in the scripts if you need to adjust layout or physics.
- The maze builds automatically on Play (from `CircularMazeBuilder`).
