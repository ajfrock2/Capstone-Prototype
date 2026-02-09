# Circular Tilt Maze: Design Only (7 Rings)

This file describes only the maze layout. The maze is a flat disc with 7 circular rings, each with a single hole to move to the next ring. The outermost ring has the exit gap (no other exit holes).

## Angle Reference
- **Angle zero**: `0 deg`
- **Angle direction**: increases counterclockwise

## Ring Radii (7 rings)
Circular wall boundaries at these radii.
- **R1**: `1.0`
- **R2**: `2.0`
- **R3**: `3.2`
- **R4**: `4.6`
- **R5**: `6.2`
- **R6**: `8.0`
- **R7 (outer wall)**: `10.0`

## Exit
- **Exit gap**: in outer wall (R7) at angle `250 deg`, gap width `28 deg`

## Ring Holes (gaps in each circular wall)
Each ring has exactly one gap to the next ring. Inner ring gaps are `24 deg` wide; exit gap is `28 deg`.
- **R1 hole**: centered at `30 deg`, gap `24 deg` (from `18 deg` to `42 deg`)
- **R2 hole**: centered at `120 deg`, gap `24 deg` (from `108 deg` to `132 deg`)
- **R3 hole**: centered at `210 deg`, gap `24 deg` (from `198 deg` to `222 deg`)
- **R4 hole**: centered at `300 deg`, gap `24 deg` (from `288 deg` to `312 deg`)
- **R5 hole**: centered at `30 deg`, gap `24 deg` (from `18 deg` to `42 deg`)
- **R6 hole**: centered at `140 deg`, gap `24 deg` (from `128 deg` to `152 deg`)
- **R7 exit gap**: centered at `250 deg`, gap `28 deg` (from `236 deg` to `264 deg`)

## Radial Walls (barriers between rings)
Radial walls are straight barriers at a fixed angle, spanning the ring range shown. No wall spans more than one ring interval.

1. **Wall A**: angle `200 deg`, span `R1 -> R2`
2. **Wall B**: angle `300 deg`, span `R1 -> R2`
3. **Wall C**: angle `20 deg`, span `R2 -> R3`
4. **Wall D**: angle `330 deg`, span `R2 -> R3`
5. **Wall E**: angle `60 deg`, span `R3 -> R4`
6. **Wall F**: angle `150 deg`, span `R3 -> R4`
7. **Wall G**: angle `90 deg`, span `R4 -> R5`
8. **Wall H**: angle `180 deg`, span `R4 -> R5`
9. **Wall I**: angle `200 deg`, span `R5 -> R6`
10. **Wall J**: angle `310 deg`, span `R5 -> R6`
11. **Wall K**: angle `20 deg`, span `R6 -> R7`
12. **Wall L**: angle `320 deg`, span `R6 -> R7`

## Intended Path (high level)
1. Center to **R1 hole** at `30 deg`.
2. Navigate ring 2 around **Wall A/B** to **R2 hole** at `120 deg`.
3. Navigate ring 3 around **Wall C/D** to **R3 hole** at `210 deg`.
4. Navigate ring 4 around **Wall E/F** to **R4 hole** at `300 deg`.
5. Navigate ring 5 around **Wall G/H** to **R5 hole** at `30 deg`.
6. Navigate ring 6 around **Wall I/J** to **R6 hole** at `140 deg`.
7. Reach outer ring and exit at **R7 gap** at `250 deg`.

## Build Notes
- Build each ring wall as a set of short arc segments (e.g., 10 deg per segment) except where the gap exists.
