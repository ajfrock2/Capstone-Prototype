## Workflow/Agent Change Summary

### Files updated
- `WORKFLOW.md`
- `.github/agents/unity-workflow-agent.agent.md`

### What we changed

1. **General alignment pass**
- Synced workflow rules and agent behavior so they match phase-by-phase.
- Added strict phase gating language and consistent checkpoint prompts.
- Fixed wording/clarity issues in implementation timing and records.

2. **Step 1 (AI Interview)**
- Kept exact kickoff question:
  - `"Do you have any clarification questions before we proceed with planning?"`
- Added requirement for assumption-challenging questions:
  - At least **3 irregular but viable** questions.
  - At least **1 odd but viable** alternative-solution question.

3. **Step 2 (Context Onboarding)**
- Added directory-structure anomaly behavior:
  - Agent must ask clarifying questions about unusual/ambiguous/noteworthy folders/files.
  - Agent must explicitly mention noteworthy findings.
  - If none, agent must explicitly state nothing unusual was found.

4. **Step 3 (Planning)**
- Added subagent-oriented planning (recommended for now, not required):
  - Two tracks when possible:
    - **1 conventional track**
    - **1 unorthodox/risky track**
  - Main agent defines research areas for each track.
  - Allow up to **5 subagent pairs concurrently** (10 subagents total).
  - Main agent must **pick one winner approach** before finalizing the plan.
- Kept implementation approval gate unchanged:
  - `"I approve this plan. Please proceed with implementation."`

### Notes
- Only the two files above were modified (as requested).
- Agent file formatting artifact was fixed during edits (clean final state).

### Step 4 Update (Implementation Phase)
- Added support for a task-specific setup guide when manual/user actions are needed.
- Preferred setup guide path:
  - `Prototype-Of-Capstone/Assets/Scripts/BenchmarkTasks/<TaskName>/SETUP_GUIDE.md`
- Guide content expectation:
  - quick overview of remaining setup tasks
  - direct step-by-step instructions to complete them
- Added a hard transition gate:
  - do not move to Testing (Step 5) if manual setup is required and no setup guide exists.
- Added required handoff messaging at end of Implementation:
  - if work remains for the user, agent must state that remaining setup is documented in the setup guide.
