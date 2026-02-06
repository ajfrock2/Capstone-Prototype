# Results Log — AI Benchmark Tests

## Instructions

Record one row per test run. Use the rubric (`RUBRIC.md`) for scoring. Keep entries consistent for fair comparison.

---

## Log Format

| Test ID | Date | AI Tool | AI Model/Version | Benchmark Task | Time to Working (min) | Iterations to Fix | Code Quality /20 | Unity Practices /20 | Maintainability /20 | Arch. Consistency /15 | Error Risk /15 | Intervention /10 | Total /100 | Unity-Specific Issues | Notable Patterns | Files Generated |
|---------|------|---------|------------------|----------------|------------------------|-------------------|------------------|---------------------|---------------------|------------------------|----------------|------------------|------------|----------------------|------------------|-----------------|
| FL-001 | 02/05/2026 | Cursor Auto AI | Flashlight System | 30 Min | 2 (User Error not AI Error) | 
| 17/20 | 12/20 | 18/20 | 15/15 | 15/15 | 2/10 | 79/100 | 
| Insisted on using old input system, one setup instruction was missing/unclear | Used GetComponent<> frequently | FlashlightController.cs | BatteryManager.cs | FlashlightUI.cs 

---

## Test Run Details (Expand per run)

### FL-001 — [Cursor Auto AI] — [02/05/2026]

**Interview Q&A:**
- Should Have generated a .md whoops

**Approved Plan Summary:**
- See FL-001_IMPLEMENTATION_PLAN

**Integration Notes:**
- No errors.  

**Issues Found:**
- Setup instructions was missing one tiny step. 

**Rubric Notes:**
- Code Quality: Pretty good. Scripts favored using GetComponent instead of an assignable variable in the inspector (Personally dislike, however left me with not as much work).
- Unity Practices: Great expect for using old input system. (This is something I would put refrence in the common errors, so that the AI can learn to not do this in the future).
- Maintainability: Great, no outstanding future issues.
- Arch. Consistency: Great, code was very consitent in its' styling.
- Error Risk: Functionality exceeded expecations.  Didn't mention that the UI needed a background image for a sprite, minor hiccup.
- Intervention: Left a lot of intervention work for me, had to connect everything manually in Unity and follow 100 lines of setup-instructions. User error from myself made me think it wasn't working, but I read a single part of the instructions wrong so had some issues.

---

## CSV Export Format

For spreadsheet analysis, use this header row:

```
TestID,Date,AITool,AIModelVersion,BenchmarkTask,TimeToWorkingMin,IterationsToFix,CodeQuality,UnityPractices,Maintainability,ArchConsistency,ErrorRisk,Intervention,Total,UnitySpecificIssues,NotablePatterns,FilesGenerated
```
