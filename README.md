# Eat Cake: First-Person Survival Game 🍰

https://github.com/user-attachments/assets/3c844bbf-9025-4e66-beaa-864eb7bb3dc9

**Eat Cake** is a stylized, low-poly First-Person game built in Unity. The objective is to navigate a hazardous environment, collect items (cakes), and manage your health. This project demonstrates core gameplay programming, physics-based environmental hazards, and UI state management using C#.

## 🎮 Gameplay & Technical Features

* **Player Controller:** * Custom C# implementation for standard WASD movement and camera look logic.
* **Environmental Hazards & Collision:** * Implemented strict collision detection. If the player's capsule collider touches the walls, it triggers a damage event that dynamically decreases the health bar.
* **Health & UI Systems:** * Real-time UI updates linking physics interactions (wall collisions) directly to the visual health bar.
  * Score tracking system integrated with the UI Canvas, utilizing clean C# architecture to update the screen efficiently when items are collected.
* **Environment Interaction:** * Implemented trigger colliders and Unity's Animator component to create smooth, proximity-based door animations.
* **Collectible System:** * Event-driven architecture handling item collection, which triggers visual/audio feedback and updates the game state.

## 🛠️ Tech Stack
* **Game Engine:** Unity 3D (2022+)
* **Language:** C#
* **Core Systems:** Physics/Colliders (`OnCollisionEnter` / `OnTriggerEnter`), Unity UI Canvas, Animator

## ⚙️ Architecture Highlights
This project focuses on clean technical implementation and physics interactions. By separating the UI logic (Health Bar, Score) from the core player movement and collision scripts, the codebase remains modular. The environmental hazards rely on precise collider setups to ensure seamless gameplay and immediate feedback when the player makes a mistake.
