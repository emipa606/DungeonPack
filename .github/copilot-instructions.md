# GitHub Copilot Instructions for Dungeon Pack (Continued) Modding Project

## Mod Overview and Purpose

**Mod Name:** Dungeon Pack (Continued)

**Mod Description:**
Dungeon Pack is an adventurous mod for RimWorld that extends gameplay by introducing 10 new custom quest locations. These locations are filled with unique challenges, powerful enemies, bosses, and distinctive loot. The mod offers a departure from traditional faction bases by providing dungeons with varied challenges such as pirate ships, buried cities, and mazes filled with traps. Designed for late-game players seeking difficult content, the mod may also release a less challenging version in the future.

## Key Features and Systems

1. **New Dungeons:**
   - Innovative quest locations with unique scenarios like fighting on a pirate ship or battling invisible ninja monks.
   - Each dungeon offers a distinct challenge and a custom reward.

2. **New Items:**
   - Special relics obtainable through quests, including a mechanoid ally summoner and a cloak for invisibility.
   - Unique items adding new abilities such as phasing and lightning strikes.

3. **Quest System:**
   - Quests initiate through research and are restartable via a quest machine.
   - Integration with Custom Quest Framework for quest management.

## Coding Patterns and Conventions

- **C# Code Structure:**
  - Organize classes based on functionality (e.g., effects, item logic) using namespaces and partial classes when necessary.
  - Utilize clear and consistent naming conventions for classes and method names for readability.
  - Apply object-oriented principles to structure code, ensuring encapsulation and separation of concerns.

- **XML Usage:**
  - Keep XML files organized by content type (e.g., `Buildings.xml`, `Items.xml`).
  - Use clear and descriptive tags for definitions for easy identification and reference.
  - Maintain proper formatting and indentation to enhance clarity.

## XML Integration

Incorporate XML definitions for game entities such as items, buildings, factions, and hediffs. Ensure each definition is unique and corresponds to the content being introduced. Use XML to configure attributes and relationships for new game features.

- Use `ThingDef` for defining new items and objects in the game.
- Employ `HediffDef` to introduce new health conditions or effects.
- Define faction-specific entities with `FactionDef`.

## Harmony Patching

Utilize Harmony to seamlessly integrate and modify existing game functionalities without altering the original codebase:

- Create patch classes for methods you wish to alter or extend.
- Use Harmony annotations such as `Prefix` and `Postfix` to indicate the parts of methods you are patching.
- Ensure compatibility by isolating patches to avoid interference with other mods.

## Suggestions for Copilot

1. **Focus on Data-Driven Design:**
   - Leverage XML for ease of configuration and expansion, minimizing hardcoding in C#.

2. **Collaboration and Documentation:**
   - Encourage thorough commenting in code and XML files to aid understanding and collaboration.

3. **Diagnostic Tools:**
   - Use logging extensively to track the flow of execution and capture errors or inconsistencies.

4. **Optimize with Performance in Mind:**
   - Consider efficiency and performance, especially when handling complex dungeon scenarios and quests.

5. **Test for Compatibility:**
   - Regularly test with other popular mods to ensure compatibility, making adjustments as required.

By adhering to these instructions, Copilot can assist you in maintaining clear and manageable code as well as seamlessly integrating new features into the Dungeon Pack mod.


This `.github/copilot-instructions.md` file is designed to assist developers working on the Dungeon Pack (Continued) mod by providing comprehensive guidelines for coding and integration using best practices in both C# and XML.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).

