# Standardized Workflow for AI Benchmark Tests

This document defines the exact procedure to follow for every AI benchmark test run. **Consistency is essential** for fair comparisons across AI tools (Cursor, GPT, Claude, Gemini, Codex).

---

## Pre-Run Checklist

- [ ] Unity project at baseline (FlashlightSystem folder empty; for subsequent runs, delete scripts in `Prototype-Of-Capstone/Assets/Scripts/BenchmarkTasks/FlashlightSystem/` first)
- [ ] Benchmark task specification ready (FlashlightSystem.md)
- [ ] Results log template ready
- [ ] Timer ready for tracking time to working solution
- [ ] Screen recording or note-taking method ready (optional but recommended)

---

## Workflow Steps

### Step 1: AI Interview Phase

**Purpose**: Allow the AI to ask clarification questions before implementation.

**Procedure**:
1. Present the full benchmark task specification to the AI (paste `BENCHMARK_TASKS/FlashlightSystem.md` or equivalent).
2. Ask: *"Do you have any clarification questions before we proceed with planning?"*
3. Document every question the AI asks and your answer in the format below.
4. Do not proceed to planning until the AI indicates it has no further questions (or after a reasonable number of exchanges).

**Record**:
```
Q1: [AI question]
A1: [Your answer]

Q2: [AI question]
A2: [Your answer]

...
```

---

### Step 2: Context Onboarding

**Purpose**: Give the AI full context about the project state and constraints.

**Procedure**:
1. Provide the Unity project structure (under `Prototype-Of-Capstone/`):
   ```
   Prototype-Of-Capstone/Assets/
   ├── Scripts/BenchmarkTasks/FlashlightSystem/  (empty for baseline runs)
   ├── Scenes/BenchmarkScene.unity
   ├── Prefabs/
   └── Materials/
   ```
2. Describe the baseline scene:
   - Main Camera, Directional Light, Ground (Plane), Player (Capsule at 0,1,0)
   - No existing gameplay scripts
3. State constraints:
   - Unity 6 (6000.x LTS)
   - URP (Universal Render Pipeline)
   - Target: Windows standalone
   - Input: Legacy Input Manager (unless AI specifies otherwise)
4. Provide links if relevant:
   - [Unity Light Component](https://docs.unity3d.com/ScriptReference/Light.html)
   - [Unity AudioSource](https://docs.unity3d.com/ScriptReference/AudioSource.html)
   - [Unity UI](https://docs.unity3d.com/Packages/com.unity.ugui@1.0/manual/index.html)

**Record**: Note what context you provided. Any deviations from this standard context must be documented.

---

### Step 3: Planning Phase

**Purpose**: Get a plan-first approach. Review and approve before implementation.

**Procedure**:
1. Ask the AI: *"Please create an implementation plan for the flashlight system. Include: (1) components/scripts you will create, (2) how they interact, (3) key design decisions."*
2. Review the plan for:
   - Completeness (covers all functional requirements)
   - Unity best practices (component-based, Inspector-friendly)
   - No obvious red flags (magic numbers, tight coupling)
3. Ask follow-up questions if the plan is unclear or incomplete.
4. Confirm the plan: *"I approve this plan. Please proceed with implementation."*
5. Document the approved plan (copy or summarize).

**Record**:
```
Approved Plan:
[Paste or summarize the AI's plan]

Design decisions:
- [Key decision 1]
- [Key decision 2]
...
```

---

### Step 4: Implementation Phase

**Purpose**: AI generates code; you integrate it into the project.

**Procedure**:
1. Ask the AI to generate the implementation (scripts, prefab setup instructions).
2. Create/copy files into the Unity project as instructed.
3. Perform any manual setup in Unity (adding components to GameObjects, creating UI, etc.) as the AI directs.
4. Document:
   - Files created
   - Any integration steps you had to figure out yourself
   - Any errors on first compile
5. **Start the timer** when you first receive code; **stop the timer** when the solution works in Play mode (or when you abandon the run).

**Record**:
```
Files generated:
- [Script 1]
- [Script 2]
...

Integration steps taken:
- [Step 1]
- [Step 2]
...

Compile errors on first attempt: [Yes/No - describe if yes]
```

---

### Step 5: Testing Phase

**Purpose**: Verify functionality and count iterations to fix issues.

**Procedure**:
1. Enter Play mode in Unity.
2. Test each functional requirement from the benchmark spec:
   - [ ] Toggle on/off with F key
   - [ ] Light activates/deactivates
   - [ ] Battery drains when on
   - [ ] Battery recharges when off
   - [ ] Auto-off at 0% battery
   - [ ] UI updates
   - [ ] Audio plays (if clips assigned)
3. Document any bugs, missing features, or crashes.
4. If issues exist, return to the AI with a bug report. Count each fix cycle as one **iteration**.
5. Repeat until all requirements pass or you reach a stopping point (e.g., max 5 iterations).

**Record**:
```
Iterations to fix: [number]

Issues found:
1. [Issue] - Fixed in iteration [N]
2. [Issue] - Not fixed / Workaround: [description]
...
```

---

### Step 6: Evaluation Phase

**Purpose**: Apply the scoring rubric and document findings.

**Procedure**:
1. Review the generated code against the rubric (see `RUBRIC.md`).
2. Score each category.
3. Fill in the results log (see `RESULTS_LOG.md` or `results_log.csv`).
4. Add notes on:
   - Unity-specific issues encountered
   - Notable patterns (good or bad)
   - Comparison to other AI tools (if you have prior runs)

**Record**: Complete the results log entry for this run.

---

## Post-Run

- Save a copy of the generated code (or tag the project state) for reference.
- Take screenshots of the working solution for the prototype summary.
- Reset the project to baseline before the next AI test run.

---

## Deviations

If you must deviate from this workflow (e.g., different input system, different Unity version), **document the deviation** in the results log. Deviations reduce comparability across runs.
