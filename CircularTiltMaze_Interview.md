# Circular Tilt Maze - Interview Log

## Q&A

Q1: Which rotation axis do you want? Options: world Y (yaw like a turntable) or local X (tilt forward/back).
A1: The camera is looking down the z axis, so that is the rotation we will want to be rotating.

Q2: Do you prefer a physical hole (gap in the floor mesh) or a trigger volume at the exit?
A2: A physical hole so that the ball could be removed would be best.

Q3: For the maze layout, do you want me to generate walls procedurally at runtime or place a fixed layout via code-created wall segments?
A3: We will want a predefined path/plan so it will be the same every time it is run.

Q4: Do you want the maze floor to be a single mesh/cylinder with walls on top, or a flat plane with walls arranged in a circular pattern?
A4: We basically want it to be like were are lokking at a super short glass ylinder from the top, and it is super wide. So we have a that, and the actual maze design would go isnide of that cylihnder.

Q5: Should the ball be constrained only by colliders (e.g., low wall height) or should I add a physics constraint to keep it on the maze surface?
A5: I think the ball shoudl only use gravity, adn by rotating the maze and it clolliding with moves or there not being ealls, the ball moves.

Q6: Any preference on wall count/ring count for the “simple maze” as long as it is solvable?
A6: No, but the maze shoudl be solvable within 2 minutes for a first time user, so it bascially juss shouldnt be super big.

Q7: Do you want a reset key (“R”) even though it’s “nice to have,” or should I skip it?
A7: Not necessary since there shoudl never be a need for rest, the maze shoudl not have a state where the player gets tuck and is no longer able to complete it.

Q8: Any camera positioning constraints, or can I place the maze at world origin and assume the existing camera can see it?
A8: You will want to place the maze in relation to the maze. The camera is looking down the z axis. You'll be ebale to see the exact location of objects in teh escene during the next woirflow phase.

Q9: Should the start/exit positions be expressed in world space or local maze space (so they rotate with the maze)?
A9: Rotate witht eh maze, ideally the solution has it so when the maze is complet and the ball reaches the end, the whole is at the bottom.

Q10: Should the maze rotation be applied to the maze parent transform that includes walls + floor + exit, or just the floor/walls?
A10: The parent and everything should move, the hole, the walls within the maze, and the outer walls that keep the maze in place.

Q11: When you say “camera is looking down the z axis,” do you mean the camera is looking along -Z toward the origin (typical Unity forward), and you want the maze to rotate around the Z axis (roll)?
A11: The position of the camera is -z and it is looking back towards the origin.

Q12: The maze should be a short, wide cylinder (walls around the perimeter). Should the floor be a flat disk at y=0 with walls on top, and the ball rolling on that floor?
A12: No. We want a cylinder super short but very wide. And the camera is looking towards the top of it, so the cylinder is rotated from its originally position, this way when the z axis is rotating, it donet really even look like the outer stuff is rotating, mainly the inner maze parts are. This also means there is no "floor"; the maze walls within the cylinder are the things stopping the balls gravity.

Q13: For “hole at the bottom,” do you mean bottom of the maze in screen space or world-space -Y?
A13: Yes there should be a hole so that when the ball reaches the end it kinds just pops out and will follow gravity going down towards -y. A single circular hole in the side of the cylinder.

Q14: Any preferred approximate maze radius and wall height, or should I choose reasonable defaults and expose them as serialized fields?
A14: Maybe 5 meters in radius. Lets start with that, and probably keep it at the origin in terms of x and z. The camera is position around -10 on the z so i think this will be good.

Q15: Do you want the camera left exactly as-is (no camera adjustments), and I should place the maze at world origin unless that conflicts with visibility?
A15: I think the camera position is fine, but if you want to move it you could.

Q16: Confirm rotation axis: you want the maze to rotate around world Z (roll), correct?
A16: Yes, only the rotation z should be changing assuming we keep the current camera pos.

Q17: Since there’s no floor, do you want the internal maze walls to be vertical “fins” that the ball collides with while gravity pulls it downward, or should I include a thin disk floor but keep the cylinder rotated so it still “looks” like a top-down maze? (No floor at all will make the ball immediately fall unless it’s supported by some surface.)
A17: It looks like a top down maze from the camera’s perspective, but it’s turned on its side, and gravity is what is moving the ball. And what prevents the ball from moving is the maze inner walls.
