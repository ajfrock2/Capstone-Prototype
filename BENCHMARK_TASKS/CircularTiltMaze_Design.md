# Circular Tilt Maze: Design Only

This file describes only the maze layout. The maze is a flat disc with 6 circular rings, each with a single hole to move to the next ring. The outermost ring has the exit gap (no other exit holes).

## Angle Reference
- **Angle zero**: `0 deg`
- **Angle direction**: increases counterclockwise

## Ring Radii (6 rings)
Circular wall boundaries at these radii.
- **R1**: `1.0`
- **R2**: `2.0`
- **R3**: `3.2`
- **R4**: `4.6`
- **R5**: `6.2`
- **R6 (outer wall)**: `8.0`

## Exit
- **Exit gap**: in outer wall (R6) at angle `330 deg`, gap width `28 deg`

## Ring Holes (gaps in each circular wall)
Each ring has exactly one gap to the next ring. Inner ring gaps are `24 deg` wide; exit gap is `28 deg`.
- **R1 hole**: centered at `30 deg`, gap `24 deg` (from `18 deg` to `42 deg`)
- **R2 hole**: centered at `150 deg`, gap `24 deg` (from `138 deg` to `162 deg`)
- **R3 hole**: centered at `270 deg`, gap `24 deg` (from `258 deg` to `282 deg`)
- **R4 hole**: centered at `60 deg`, gap `24 deg` (from `48 deg` to `72 deg`)
- **R5 hole**: centered at `210 deg`, gap `24 deg` (from `198 deg` to `222 deg`)
- **R6 exit gap**: centered at `330 deg`, gap `28 deg` (from `316 deg` to `344 deg`)

## Radial Walls (barriers between rings)
Radial walls are straight barriers at a fixed angle, spanning the ring range shown. No wall spans more than one ring interval.

1. **Wall A**: angle `90 deg`, span `R1 -> R2`
2. **Wall B**: angle `210 deg`, span `R1 -> R2`
3. **Wall C**: angle `120 deg`, span `R2 -> R3`
4. **Wall D**: angle `240 deg`, span `R2 -> R3`
5. **Wall E**: angle `300 deg`, span `R3 -> R4`
6. **Wall F**: angle `30 deg`, span `R3 -> R4`
7. **Wall G**: angle `150 deg`, span `R4 -> R5`
8. **Wall H**: angle `330 deg`, span `R4 -> R5`
9. **Wall I**: angle `260 deg`, span `R5 -> R6`
10. **Wall J**: angle `20 deg`, span `R5 -> R6`

## Intended Path (high level)
1. Center to **R1 hole** at `30 deg`.
2. Navigate ring 2 around **Wall A/B** to **R2 hole** at `150 deg`.
3. Navigate ring 3 around **Wall C/D** to **R3 hole** at `270 deg`.
4. Navigate ring 4 around **Wall E/F** to **R4 hole** at `60 deg`.
5. Navigate ring 5 around **Wall G/H** to **R5 hole** at `210 deg`.
6. Reach outer ring and exit at **R6 gap** at `330 deg`.

## Build Notes
- Build each ring wall as a set of short arc segments (e.g., 10 deg per segment) except where the gap exists.
