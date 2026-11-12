# Sokoban

**[Play in your browser on Unity Play](https://play.unity.com/en/games/df35f5ab-ebee-4657-8166-fca928bb3b07/sokobanweb)**

Sokoban is a three-level puzzle game built in Unity and C#. Push crates onto goal tiles to clear each level, and pick up optional collectibles to earn stars. If you push a crate into a dead end, restart the level and try a different route.

## Gameplay systems

- Grid-based player movement and crate pushing, with checks for walls and blocked tiles.
- Goal detection, move tracking, and a results screen that awards stars based on collectibles.
- Level progression and resets so players can retry a puzzle.

## Code to explore

- [PlayerController.cs](Assets/Scripts/PlayerController.cs) — movement and crate pushing.
- [LevelManager.cs](Assets/Scripts/LevelManager.cs) — completion checks, scoring, and scene transitions.
