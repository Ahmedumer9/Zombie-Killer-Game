# Zombie-Killer-Game
A 2D zombie shooter game built with C# and Windows Forms.

## About

Zombie Killer is a top-down survival shooter where the player fights off waves of zombies. The codebase follows a structured object-oriented architecture, separating game logic into distinct layers for maintainability and extensibility.

## Features

- Real-time zombie spawning and combat
- Collision detection system (player, zombies, pickups,bullets)
- Medkit pickups for health recovery
- Score/wave progression

## Architecture

The project is organized into clear OOP layers:

```
ZombieKiller/
├── GameObjects/   # Player, Zombie, Medkit, and other entities
├── Managers/      # CollisionManager, GameManager, etc.
├── Interfaces/    # Shared contracts for game objects
├── Enums/         # Game state and object type definitions
└── Game/          # Core game loop and form logic
```

## Built With

- C#
- .NET / Windows Forms


