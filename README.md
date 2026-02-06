# Unity AI Benchmark Testbed

A controlled environment for testing AI-generated Unity code as part of the **Agentic Coding Technique Evaluation** capstone project.

## Purpose

This project serves as a benchmark lab—not a game. It provides a clean, minimal baseline for evaluating how different AI tools (Cursor, GPT, Claude, Gemini, Codex) perform when generating Unity gameplay code.

## Setup Instructions

### 1. Open the Unity Project

1. Open **Unity Hub**
2. Click **Add** or **Open**
3. Navigate to this repository and select the `Prototype-Of-Capstone` folder
4. The project will open (requires **Unity 6** / 6000.x LTS)

### 2. Project Structure

The Unity project is located at `Prototype-Of-Capstone/`. Its `Assets` folder is structured as:

```
Prototype-Of-Capstone/Assets/
├── Scripts/
│   └── BenchmarkTasks/
│       └── FlashlightSystem/    (empty for baseline runs; contains implementation after FL-001)
├── Scenes/
│   └── BenchmarkScene.unity
├── Prefabs/
└── Materials/
```

### 3. Baseline Scene

`BenchmarkScene.unity` is included in `Prototype-Of-Capstone/Assets/Scenes/` with Ground, Player, Main Camera, and Directional Light. No setup required.

### 4. Baseline State

This prototype includes the completed FL-001 implementation (Flashlight System) in `FlashlightSystem/`. For subsequent benchmark runs with other AI tools, reset to baseline by deleting the scripts in `FlashlightSystem/` before starting.

## Benchmark Tasks

The primary benchmark task for the prototype is the **Flashlight System**. See `BENCHMARK_TASKS/FlashlightSystem.md` for the full specification.

## Usage

1. For first run: baseline is ready. For subsequent runs: reset to baseline (empty FlashlightSystem folder, clean scene)
2. Provide the AI with the benchmark task specification
3. Follow the standardized workflow (see `WORKFLOW.md`)
4. Record results in the results log

## Project Constraints

- **Unity Version**: Unity 6 (6000.x LTS)
- **Input**: Standard Input Manager or New Input System (specify in task)
- **Rendering**: URP (Universal Render Pipeline)
- **Target**: Windows/Mac standalone (no mobile or WebGL required for prototype)
