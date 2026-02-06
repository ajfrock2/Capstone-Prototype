# Unity AI Benchmark Testbed

A controlled environment for testing AI-generated Unity code as part of the **Agentic Coding Technique Evaluation** capstone project.

## Purpose

This project serves as a benchmark lab—not a game. It provides a clean, minimal baseline for evaluating how different AI tools (Cursor, GPT, Claude, Gemini, Codex) perform when generating Unity gameplay code.

## Setup Instructions

### 1. Create the Unity Project

1. Open **Unity Hub**
2. Click **New Project**
3. Select **Unity 2022 LTS** (or latest LTS available)
4. Choose **3D (Core)** template
5. Name the project `UnityBenchmarkTestbed`
6. Save location: `c:\Users\ajfro\Documents\Capstone\`
7. Click **Create Project**

### 2. Apply This Structure

After Unity creates the project, ensure your `Assets` folder matches this structure:

```
Assets/
├── Scripts/
│   ├── BenchmarkTasks/
│   │   └── FlashlightSystem/    (empty - AI will populate during tests)
│   └── Core/                    (baseline utilities if needed)
├── Scenes/
│   └── BenchmarkScene.unity
├── Prefabs/
└── Materials/
```

### 3. Create or Use the Baseline Scene

A pre-built `BenchmarkScene.unity` is included in `Assets/Scenes/` with Ground, Player, Main Camera, and Directional Light. If starting fresh instead:

1. Create a new scene: **File → New Scene** (Basic 3D template)
2. Save as `BenchmarkScene` in `Assets/Scenes/`
3. Set up the baseline:
   - **Ground**: Create 3D Object → Plane (scale if desired, default is fine)
   - **Player**: Create 3D Object → Capsule (position at 0, 1, 0)
   - **Lighting**: Default Directional Light is sufficient
   - **Camera**: Default Main Camera (position to view the capsule)
4. Remove the default Cube if present
5. Save the scene

### 4. Baseline Requirements

- **No existing gameplay code** — AI starts from scratch
- **Clean hierarchy** — Only: Main Camera, Directional Light, Plane (Ground), Capsule (Player)
- **No scripts** in BenchmarkTasks/FlashlightSystem/ — AI will create these

## Benchmark Tasks

The primary benchmark task for the prototype is the **Flashlight System**. See `../BENCHMARK_TASKS/FlashlightSystem.md` for the full specification.

## Usage

1. Reset to baseline before each AI test run (fresh scene, no benchmark scripts)
2. Provide the AI with the benchmark task specification
3. Follow the standardized workflow (see `WORKFLOW.md`)
4. Record results in the results log

## Project Constraints

- **Unity Version**: 2022 LTS or later
- **Input**: Standard Input Manager or New Input System (specify in task)
- **Rendering**: Built-in Render Pipeline (default)
- **Target**: Windows/Mac standalone (no mobile or WebGL required for prototype)
