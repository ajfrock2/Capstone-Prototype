# Agentic Coding Technique Evaluation — Full Conversation Summary + Prototype Requirements (Markdown)

## Project Identity
- **Student:** Austin Frock  
- **Mentor:** Michael Guerrero  
- **Capstone Title:** Agentic Coding Technique Evaluation  
- **Core Topic:** Evaluating **agentic, planning-first AI workflows** in **Unity development**.

---

## The Core Problem (Section 1: already written)
AI-assisted development is advancing quickly, but Unity developers (especially students + indie teams) lack:
- consistent guidance on **how to structure AI usage**
- reliable methods for **evaluating AI output beyond surface correctness**

When AI is used without proper context, planning, and workflow structure, it often produces:
- superficially functional code
- subtle quality issues
- architectural inconsistency
- maintainability problems
- **error accumulation over time**

Unity makes this worse because:
- systems are tightly interconnected (input, gameplay, rendering, assets, prefabs)
- “working code” can still be brittle or harmful long-term

The project frames this as **industry-wide** and emphasizes that the goal is not “replace developers,” but **use AI responsibly** with evaluation methods.

---

## Target Audience / Who This Affects
- Students using Unity
- Solo developers
- Small indie teams  
These groups want speed benefits from AI but often lack:
- evaluation frameworks
- best practices for workflow structure
- long-term maintainability awareness

---

## What the Capstone Is Actually Producing (End Goal)
The final deliverable is not “a Unity game.”

The end goal is:
- a set of **structured tests**
- results from multiple runs
- conclusions about what agentic workflow structures perform best in Unity
- an evaluation framework that measures:
  - code quality
  - error accumulation
  - required developer intervention

---

## Key Experimental Logic (Important)
### What stays constant
- The **workflow** stays the same across tests:
  1. AI clarification questions (interview phase)
  2. Context onboarding (artifacts, current state, constraints)
  3. Planning + review cycle (plan-first)
  4. Implementation request (generate code / feature)

### What changes (main variable)
- The **agent structure** (and potentially multiple AI models under the same structure)

### Why this matters
Without keeping workflow constant, comparisons become unreliable because setup differences strongly affect outcomes.

---

## Section 6 (Intended Contribution: already drafted)
Austin’s unique value vs AI tools is:
- Unity-specific engineering judgment
- ability to detect long-term risks early
- ability to identify “working but harmful” code patterns

Austin’s contribution focuses on:
- designing Unity benchmark tasks
- ensuring fair comparisons
- analyzing maintainability and scalability
- evaluating more than “does it compile”

Quality signals Austin wants to track include:
- avoiding magic numbers
- avoiding spaghetti code
- consistent organization
- stable coding style (not shifting patterns constantly)

---

# What the Prototype Should Be (The Big Insight)

## Correct framing
Web students often build a demo website as a prototype.

For this capstone, your project is *evaluation research*, so your prototype should be:

> **A working Unity AI evaluation harness** (a small benchmark lab that lets you run fair tests and collect structured results).

This means your prototype is not a game demo — it is **Version 1 of the testing system**.

---

# Prototype v1 — What You Actually Need

## 1) A Unity benchmark testbed project
A Unity project designed to be a controlled environment for testing AI-generated code.

It should include:
- a simple scene
- clean folder structure
- organized scripts/prefabs
- a stable baseline setup

This is not meant to be a full game — it’s a lab.

---

## 2) 2–3 small Unity benchmark tasks (“test cases”)
These are small, repeatable Unity features that reveal AI strengths/weaknesses quickly.

Good examples:
- player controller (movement + jump)
- enemy patrol → chase → return
- interaction system (raycast + prompt + input)
- door system (lock + key + animation)
- flashlight system (input + audio + battery)

Avoid (scope traps):
- networking
- procedural generation
- full save/load systems
- complex inventory systems

The goal is repeatability and fair comparisons, not feature count.

---

## 3) A standardized workflow document (the experiment rules)
A written step-by-step procedure you follow for every run.

Your workflow structure:
1. AI interviews the developer/team with clarification questions  
2. Context onboarding (project artifacts, markdown, current state)  
3. Planning + review cycle (plan-first, confirm design decisions)  
4. Implementation request (code / feature generation)

This is essential for fairness.

---

## 4) A scoring rubric (evaluation method)
This converts the project from subjective opinion into structured evaluation.

Your rubric should score:
- code quality / cleanliness
- Unity best practices
- maintainability
- architectural consistency
- error accumulation risk
- developer intervention required

This aligns directly with your project scope.

---

## 5) A results log (proof the system produces data)
You need a structured way to record results.

Example columns:
- AI tool/model
- benchmark task
- time to working solution
- number of fixes needed
- quality score(s)
- notes on Unity-specific issues

Even a small spreadsheet/table is enough.

---

## 6) At least ONE proof-of-concept test run (required)
This is the difference between:
- a plan (too theoretical)
- a prototype (rubric-safe)

Minimum viable:
- run **1 benchmark task**
- with **2 AI tools/models**
- using the **same workflow**
- record results in your log + rubric

You do not need full study results yet — just proof the system works.

---

# Why “Outline Only” Is Risky
You had the correct idea that your prototype should resemble the final testing process.

However:
- If your prototype is only an outline and no tests have been run, some instructors may see it as too theoretical.
- The rubric (Section 3 worth 60 points) rewards experimentation and working progress.

So the best version is:
> **Framework + small proof run**, not just framework.

---

# The Most Rubric-Safe Prototype Package
If you want the cleanest and most defensible prototype for grading:

- **Unity benchmark testbed project**
- **2–3 benchmark tasks**
- **standardized workflow document**
- **scoring rubric**
- **results log format**
- **1 small comparison run logged**

This package:
- shows real progress
- shows experimentation
- avoids scope explosion
- directly matches your capstone’s stated goal

---

# Status Snapshot (from your proposal)
## Already completed
- **Section 1:** Understanding of the problem (approved)
- **Section 2:** Motivation (approved)
- **Section 6:** Intended contribution (drafted, strong)
- **Section 7:** Work style (approved)

## Still missing / needs to be created
- **Section 3:** Prototype / research (links/screenshots required)
- **Section 4:** Explanation of prototype or research findings
- **Section 5:** Skillset evidence (you have links; may need more detail)

---

# One-Sentence Summary
Your prototype should be a **mini Unity benchmark lab**: a testbed project + benchmark tasks + workflow rules + rubric + a small proof comparison run, so you can later scale into full structured evaluation results.
