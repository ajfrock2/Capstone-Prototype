# Standardized Workflow for AI Benchmark Tests

This document defines the required procedure for every AI benchmark test run. Consistency is essential for fair comparisons across tools (Cursor, GPT, Claude, Gemini, Codex).

---

## Global Rules

- Follow phases in this exact order: 1) AI Interview, 2) Context Onboarding, 3) Planning, 4) Implementation, 5) Testing, 6) Evaluation.
- Do not advance phases without explicit confirmation that the current phase is complete.
- Before moving to the next phase, ask: "Are we done with <Current Phase>?"
- If a deviation is requested (skip/reorder/change), allow it but record it as a deviation for comparability.

---

## Pre-Run Checklist

- [ ] Unity project at baseline (task folder empty; for subsequent runs, delete scripts in `Prototype-Of-Capstone/Assets/Scripts/BenchmarkTasks/<TaskName>/` first)
- [ ] Benchmark task specification ready (`BENCHMARK_TASKS/<TaskName>.md`)
- [ ] Results log template ready
- [ ] Timer ready for tracking time to working solution
- [ ] Screen recording or note-taking method ready (optional but recommended)

---

## Workflow Steps

### Step 1: AI Interview Phase

Purpose: Allow the AI to ask clarification questions before planning and challenge default assumptions.

Procedure:
1. Present the full benchmark task specification to the AI (paste `BENCHMARK_TASKS/<TaskName>.md` or equivalent).
2. Ask exactly: "Do you have any clarification questions before we proceed with planning?"
3. Require assumption-challenge questions:
   - Ask the AI to provide at least 3 irregular but viable questions that could change the implementation direction.
   - Questions should probe hidden constraints, edge cases, tradeoffs, and unconventional approaches.
   - At least 1 question must suggest an odd but viable solution path.
4. Document every AI question and your answer.
5. Do not proceed until the AI indicates there are no further questions (or after a reasonable exchange limit).
6. Ask checkpoint: "Are we done with AI Interview Phase?"

Record:
```text
Q1: [AI question]
A1: [Your answer]

Q2: [AI question]
A2: [Your answer]
```

---

### Step 2: Context Onboarding

Purpose: Provide full project context and constraints.

Procedure:
1. Provide the project structure under `Prototype-Of-Capstone/`:
   ```text
   Prototype-Of-Capstone/Assets/
   |-- Scripts/BenchmarkTasks/<TaskName>/  (empty for baseline runs)
   |-- Scenes/BenchmarkScene.unity
   |-- Prefabs/
   `-- Materials/
   ```
2. Describe the baseline scene:
   - Main Camera, Directional Light, Ground (Plane), Player (Capsule at 0,1,0)
   - No existing gameplay scripts
3. State constraints:
   - Unity 6 (6000.x LTS)
   - URP (Universal Render Pipeline)
   - Target: Windows standalone
   - Input: Legacy Input Manager (unless AI specifies otherwise)
4. Provide relevant links if needed:
   - [Unity Light Component](https://docs.unity3d.com/ScriptReference/Light.html)
   - [Unity AudioSource](https://docs.unity3d.com/ScriptReference/AudioSource.html)
   - [Unity UI](https://docs.unity3d.com/Packages/com.unity.ugui@1.0/manual/index.html)
5. Require directory-structure clarification:
   - Ask clarifying questions about folders/files that appear unusual, ambiguous, duplicated, or out of expected benchmark layout.
   - Explicitly mention any noteworthy structure observations before leaving this phase.
   - If no anomalies are seen, explicitly state that nothing unusual was found.
6. Ask checkpoint: "Are we done with Context Onboarding?"

Record: Note what context you provided. Document any deviations from this standard context.

---

### Step 3: Planning Phase

Purpose: Enforce plan-first implementation with optional parallel subagent exploration.

Procedure:
1. Ask: "Please create an implementation plan for this benchmark task. Include: (1) components/scripts you will create, (2) how they interact, (3) key design decisions."
2. Recommend subagent-assisted research before locking the plan:
   - Launch two tracks when possible: (a) 1 conventional track, (b) 1 unorthodox/risky track.
   - Main agent defines what each track should research.
   - Run up to 5 subagent pairs at one time (10 subagents total) when needed.
3. Main agent compares track outputs and selects one winner approach (no mandatory hybrid merge).
4. Review the winning direction for completeness, Unity best practices, and obvious risks.
5. Ask follow-ups until the plan is clear and complete.
6. Require explicit approval gate before implementation:
   - "I approve this plan. Please proceed with implementation."
7. Document the approved plan.
8. Ask checkpoint: "Are we done with Planning Phase?"

Record:
```text
Planning tracks run:
- Conventional: [summary]
- Unorthodox/Risky: [summary]

Winner selected:
- [which track won and why]

Approved Plan:
[Paste or summarize the AI plan]
```

---

### Step 4: Implementation Phase

Purpose: Generate code and integrate it into the project.

Procedure:
1. Ask the AI to generate implementation code and Unity setup instructions.
2. Create/copy files into the Unity project as instructed.
3. Perform any manual Unity setup steps.
4. Document:
   - Files created
   - Integration steps you had to infer
   - Compile errors on first attempt
5. Timing rule:
   - Start timer when first code is received.
   - Stop timer when the solution works in Play mode, or when the run is abandoned.
6. Ask checkpoint: "Are we done with Implementation Phase?"

Record:
```text
Files generated:
- [Script 1]
- [Script 2]

Integration steps taken:
- [Step 1]
- [Step 2]

Compile errors on first attempt: [Yes/No - describe if yes]
```

---

### Step 5: Testing Phase

Purpose: Verify requirements and measure fix iterations.

Procedure:
1. Enter Play mode in Unity.
2. Test every functional requirement against the benchmark spec.
3. Perform quick end-to-end checks:
   - Core gameplay/system behavior matches spec
   - UI/UX updates correctly (if applicable)
   - Audio/FX triggers correctly (if applicable)
   - No console errors/warnings in Play mode
4. Document bugs, missing features, and crashes.
5. If issues exist, return to AI with a bug report. Count each bug-fix loop as one iteration.
6. Repeat until all requirements pass or stopping criteria are reached (for example, max 5 iterations).
7. Ask checkpoint: "Are we done with Testing Phase?"

Record:
```text
Iterations to fix: [number]

Issues found:
1. [Issue] - Fixed in iteration [N]
2. [Issue] - Not fixed / Workaround: [description]
```

---

### Step 6: Evaluation Phase

Purpose: Apply rubric scoring and capture findings.

Procedure:
1. Review generated code against `RUBRIC.md`.
2. Score each rubric category.
3. Fill in results log (`RESULTS_LOG.md` or `results_log.csv`).
4. Add notes on:
   - Unity-specific issues encountered
   - Notable patterns (good or bad)
   - Comparison to other AI tools (if prior runs exist)
5. Ask checkpoint: "Are we done with Evaluation Phase?"

Record: Complete the results log entry for this run.

---

## Deviation Handling

If workflow deviation is detected, use:
- "This deviates from WORKFLOW.md. Recommended correction: <specific correction>. Do you want to return to the workflow step now?"

If you intentionally continue with a deviation, document it in the results log. Deviations reduce comparability across runs.

---

## Post-Run

- Save generated code (or tag project state) for reference.
- Take screenshots of the working solution for prototype summaries.
- Reset project to baseline before the next AI test run.


