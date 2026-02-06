# Scoring Rubric for AI-Generated Unity Code

This rubric converts subjective evaluation into structured scores. Use it for every benchmark test run to ensure consistent, comparable results.

**Total: 100 points**

---

## 1. Code Quality (20 points)

Evaluates cleanliness, readability, and configuration.

| Score | Criteria |
|-------|----------|
| **18–20** | No magic numbers; all tunables in serialized fields or config; clear naming; well-organized; helpful comments where needed |
| **14–17** | Minor magic numbers (1–2); mostly good naming; reasonable organization |
| **10–13** | Several magic numbers; inconsistent naming; hard to follow in places |
| **5–9** | Many magic numbers; poor naming; disorganized |
| **0–4** | Unreadable; no configuration; no structure |

**Signals to look for**:
- Good: `[SerializeField] private float depletionRate = 5f;`
- Bad: `battery -= 0.05f * Time.deltaTime;` (0.05f is magic number)
- Good: `FlashlightController`, `BatteryManager` (clear names)
- Bad: `Script1`, `Manager`, `Thing` (vague names)

---

## 2. Unity Best Practices (20 points)

Evaluates proper use of Unity's architecture and conventions.

| Score | Criteria |
|-------|----------|
| **18–20** | Correct lifecycle (Awake/Start/Update); component-based; prefab-friendly; Inspector-friendly (tooltips, ranges); proper use of GetComponent |
| **14–17** | Minor lifecycle issues; mostly component-based; usable in Inspector |
| **10–13** | Awake/Start/Update misuse; some monolithic design; limited Inspector use |
| **5–9** | Wrong lifecycle; tightly coupled; not prefab-friendly |
| **0–4** | Anti-patterns; breaks Unity conventions; not reusable |

**Signals to look for**:
- Good: Serialized fields for references; `[Range(0, 100)]` for percentages
- Bad: Finding objects by name in Update; hardcoded paths
- Good: Light/AudioSource as separate components, script coordinates them
- Bad: Everything in one 500-line script with no separation

---

## 3. Maintainability (20 points)

Evaluates how easy it is to extend, modify, and understand.

| Score | Criteria |
|-------|----------|
| **18–20** | Easy to add features; no duplication; clear separation of concerns; logical flow |
| **14–17** | Mostly extensible; minimal duplication; reasonable separation |
| **10–13** | Some duplication; mixed concerns; moderate complexity |
| **5–9** | Significant duplication; tangled logic; hard to extend |
| **0–4** | Spaghetti code; impossible to modify without breaking things |

**Signals to look for**:
- Good: Battery logic in one place; UI reads from Battery component
- Bad: Battery logic duplicated in multiple scripts
- Good: Adding a "battery upgrade" would require minimal changes
- Bad: Adding any feature would require rewriting large sections

---

## 4. Architectural Consistency (15 points)

Evaluates consistency of style, patterns, and organization.

| Score | Criteria |
|-------|----------|
| **13–15** | Consistent style throughout; logical file/folder structure; appropriate Unity patterns; no conflicting approaches |
| **10–12** | Mostly consistent; reasonable structure; few inconsistencies |
| **6–9** | Mixed styles; unclear structure; some conflicting patterns |
| **3–5** | Inconsistent; confusing structure; multiple conflicting patterns |
| **0–2** | Chaotic; no discernible structure; contradictory patterns |

**Signals to look for**:
- Good: All scripts use same naming (PascalCase for public, _camelCase for private)
- Bad: Some scripts use different conventions
- Good: Clear folder structure (FlashlightSystem/ contains all related scripts)
- Bad: Scripts scattered; unrelated code mixed in

---

## 5. Error Accumulation Risk (15 points)

Evaluates potential for bugs, edge cases, and long-term instability.

| Score | Criteria |
|-------|----------|
| **13–15** | No obvious bugs; null checks where needed; no leak risks (events, coroutines); reasonable performance |
| **10–12** | Minor edge cases; mostly safe; low leak risk |
| **6–9** | Some edge cases unhandled; potential null refs; possible leaks |
| **3–5** | Multiple edge cases; null ref risks; leak risks; performance concerns |
| **0–2** | Crashes; obvious memory leaks; severe performance issues |

**Signals to look for**:
- Good: `if (audioSource != null && clip != null) audioSource.PlayOneShot(clip);`
- Bad: `audioSource.PlayOneShot(onSound);` (no null check)
- Good: Coroutines stopped in OnDisable; events unsubscribed
- Bad: Subscribing to events without unsubscribing; coroutines that never stop

---

## 6. Developer Intervention Required (10 points)

Evaluates how much work the developer had to do to get a working solution.

| Score | Criteria |
|-------|----------|
| **9–10** | 0–1 iterations to fix; fast time to solution; code is self-explanatory |
| **7–8** | 2 iterations; reasonable time; mostly clear |
| **5–6** | 3 iterations; moderate time; some clarification needed |
| **3–4** | 4+ iterations; long time; significant debugging |
| **0–2** | Many iterations; never fully worked; required major rewrites |

**Scoring guide**:
- **Iterations to fix**: 0 = 3 pts, 1 = 2 pts, 2 = 1 pt, 3+ = 0 pts (out of 3)
- **Time to solution**: <15 min = 3 pts, 15–30 min = 2 pts, 30–60 min = 1 pt, >60 min = 0 pts (out of 3)
- **Clarity**: Self-explanatory = 4 pts, needed some explanation = 2 pts, required deep debugging = 0 pts (out of 4)

---

## Summary Table

| Category | Max Points |
|----------|------------|
| Code Quality | 20 |
| Unity Best Practices | 20 |
| Maintainability | 20 |
| Architectural Consistency | 15 |
| Error Accumulation Risk | 15 |
| Developer Intervention Required | 10 |
| **Total** | **100** |

---

## Usage Notes

1. **Score immediately after testing** while the code is fresh.
2. **Document specific examples** for each category in the results log (helps justify scores and compare across runs).
3. **Be consistent** across AI tools—use the same standards for all.
4. **When in doubt**, use the lower end of the range to avoid inflation.
