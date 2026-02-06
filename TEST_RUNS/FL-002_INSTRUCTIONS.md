# FL-002 — Second AI Tool — Instructions for User

To complete the proof-of-concept, run the **same** Flashlight System benchmark with a **second AI tool** (GPT, Claude, Gemini, or Codex).

## Before You Start

1. **Reset the Unity project** to baseline:
   - Delete or move the scripts in `Assets/Scripts/BenchmarkTasks/FlashlightSystem/` (or create a fresh copy of the project)
   - Ensure the scene has only: Main Camera, Directional Light, Ground, Player
   - No flashlight scripts

2. **Open** `WORKFLOW.md` and follow it step-by-step.

3. **Use** `BENCHMARK_TASKS/FlashlightSystem.md` as the task specification to give the AI.

## Workflow Summary

1. **Interview**: Give the AI the spec; document Q&A
2. **Context**: Provide project structure and scene description
3. **Planning**: Get a plan; review and approve
4. **Implementation**: AI generates code; you integrate
5. **Testing**: Run in Unity; count iterations to fix
6. **Evaluation**: Apply `RUBRIC.md`; fill in results log

## After the Run

1. Update `RESULTS_LOG.md` with the FL-002 row
2. Update `results_log.csv` with the FL-002 row
3. Create `FL-002_[AITool].md` in TEST_RUNS/ with full details (use FL-001_Cursor.md as template)
4. Take screenshots for the prototype summary

## Tips

- Use a **new chat/session** for the second AI (don't mix contexts)
- **Time** the run (from first code received to working solution)
- **Count** every bug-fix cycle as an iteration
- Be **consistent** with the rubric—same standards as FL-001
