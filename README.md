# Mystic Maze

Mystic Maze is a creative text-adventure game written in C#. In this game, players explore an enchanted labyrinth filled with mysterious rooms, hidden keys, and magical barriers. Use simple text commands to navigate the maze and uncover its secrets!

## Features

- **Interactive Exploration:** Navigate through different rooms with vivid descriptions.
- **Simple Commands:** Use commands like `go north`, `look`, `take key`, `inventory`, and `exit` to interact with the game.
- **Mystery & Magic:** Discover the Mystic Key and use it to unlock the Treasure Room, all while experiencing ghostly whispers and hidden lore.
- **Self-contained:** A single-file application for simplicity, perfect for learning and customization.

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (preferably .NET 5 or later)

### Installation and Running

1. **Clone the repository:**
   `git clone https://github.com/yourusername/mystic-maze.git`

2. **Navigate to the project directory:**
   `cd mystic-maze`

3. **Compile and run the application:**
   `dotnet run`

Alternatively, you can open the project in Visual Studio as a Console App and run it from there.

## How to Play

- **Move:** Use `go [direction]` (e.g., `go north`) to travel between rooms.
- **Observe:** Use `look` to get a description of your current surroundings.
- **Collect:** If you see a key, type `take key` to add the Mystic Key to your inventory.
- **Inventory:** Use `inventory` to check the items you are carrying.
- **Exit:** Type `exit` at any time to quit the game.

## Code Structure

- **Program.cs:** Contains all the game logic and the Room class. Everything is self-contained in this file for simplicity.

## Customization

Feel free to modify room descriptions, add new rooms or puzzles, and expand the game mechanics. Contributions and enhancements are very welcome!
