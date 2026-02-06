# FL-001 — First AI Tool — Instructions for User

Run the Flashlight System benchmark with a **first AI tool** (Cursor, GPT, Claude, Gemini, or Codex).

## Before You Start

1. **Verify the Unity project baseline**:
   - FlashlightSystem folder is empty (`Prototype-Of-Capstone/Assets/Scripts/BenchmarkTasks/FlashlightSystem/`)
   - Scene has only: Main Camera, Directional Light, Ground, Player
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

1. Update `RESULTS_LOG.md` with the FL-001 row
2. Update `results_log.csv` with the FL-001 row
3. Create `FL-001_[AITool].md` in TEST_RUNS/ with full details
4. Take screenshots for the prototype summary

## Tips

- Use a **new chat/session** for the AI (don't mix contexts)
- **Time** the run (from first code received to working solution)
- **Count** every bug-fix cycle as an iteration
- Be **consistent** with the rubric for future comparisons
