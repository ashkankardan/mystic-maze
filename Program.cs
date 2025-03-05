using System;
using System.Collections.Generic;

namespace EnchantedLabyrinth
{
    class Program
    {
        static void Main(string[] args)
        {
            Room entrance = new Room("You stand at the entrance of an enchanted labyrinth. Paths lead north and east.");
            Room hall = new Room("You enter the Hall of Mirrors. Reflections dance around you. Exits lead south and east.");
            Room garden = new Room("You find yourself in a mystical garden filled with luminous flora. A glittering key lies on a pedestal here. Exits lead west and north.");
            Room chamber = new Room("This is the Chamber of Whispers, where echoes of the past murmur cryptic secrets. Exits lead west and south.");
            Room treasureRoom = new Room("You've discovered the Treasure Room, filled with untold riches! A magical barrier stands before the door. Exits lead west.");

            entrance.Exits["north"] = hall;
            entrance.Exits["east"] = garden;

            hall.Exits["south"] = entrance;
            hall.Exits["east"] = chamber;

            garden.Exits["west"] = entrance;
            garden.Exits["north"] = treasureRoom;

            chamber.Exits["west"] = hall;
            chamber.Exits["south"] = garden;

            treasureRoom.Exits["west"] = garden;

            List<string> inventory = new List<string>();
            Room currentRoom = entrance;
            Random random = new Random();

            Console.WriteLine("Welcome to the Enchanted Labyrinth!");
            Console.WriteLine("Explore the labyrinth by typing commands like 'go north', 'look', 'take key', 'inventory', or 'exit' to quit the game.");

            bool playing = true;
            while (playing)
            {
                Console.WriteLine("\n" + currentRoom.Description);

                if (currentRoom == garden && !inventory.Contains("Mystic Key"))
                {
                    Console.WriteLine("There is a Mystic Key glimmering on a pedestal.");
                }

                if (currentRoom == chamber && random.Next(0, 100) < 50)
                {
                    Console.WriteLine("A ghostly whisper murmurs: 'The key unlocks more than just doors...'");
                }

                Console.Write("\n> ");
                string input = Console.ReadLine().Trim().ToLower();
                string[] parts = input.Split(' ');

                if (parts.Length == 0)
                    continue;

                string command = parts[0];

                switch (command)
                {
                    case "exit":
                        playing = false;
                        Console.WriteLine("Thanks for playing the Enchanted Labyrinth!");
                        break;

                    case "look":
                        Console.WriteLine(currentRoom.Description);
                        if (currentRoom == garden && !inventory.Contains("Mystic Key"))
                        {
                            Console.WriteLine("The Mystic Key catches your eye.");
                        }
                        break;

                    case "inventory":
                        if (inventory.Count == 0)
                            Console.WriteLine("Your inventory is empty.");
                        else
                        {
                            Console.WriteLine("You are carrying:");
                            foreach (var item in inventory)
                            {
                                Console.WriteLine(" - " + item);
                            }
                        }
                        break;

                    case "take":
                        if (parts.Length < 2)
                        {
                            Console.WriteLine("Take what?");
                        }
                        else
                        {
                            string itemRequested = input.Substring(5).Trim();
                            if ((itemRequested == "key" || itemRequested == "mystic key") && currentRoom == garden)
                            {
                                if (!inventory.Contains("Mystic Key"))
                                {
                                    inventory.Add("Mystic Key");
                                    Console.WriteLine("You take the Mystic Key. It feels warm and pulsing with magic.");
                                }
                                else
                                {
                                    Console.WriteLine("You've already taken the key.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("There is no such item here.");
                            }
                        }
                        break;

                    case "go":
                        if (parts.Length < 2)
                        {
                            Console.WriteLine("Go where?");
                        }
                        else
                        {
                            string direction = parts[1];
                            if (currentRoom.Exits.ContainsKey(direction))
                            {
                                Room nextRoom = currentRoom.Exits[direction];
                                if (nextRoom == treasureRoom)
                                {
                                    if (inventory.Contains("Mystic Key"))
                                    {
                                        Console.WriteLine("The Mystic Key glows and dissolves the magical barrier...");
                                        currentRoom = nextRoom;
                                    }
                                    else
                                    {
                                        Console.WriteLine("A magical barrier prevents you from entering. You feel that a key might be needed.");
                                    }
                                }
                                else
                                {
                                    currentRoom = nextRoom;
                                }
                            }
                            else
                            {
                                Console.WriteLine("You can't go that way.");
                            }
                        }
                        break;

                    default:
                        Console.WriteLine("Unknown command. Try 'go', 'look', 'take', 'inventory', or 'exit'.");
                        break;
                }
            }
        }
    }

    class Room
    {
        public string Description { get; set; }
        public Dictionary<string, Room> Exits { get; set; }

        public Room(string description)
        {
            Description = description;
            Exits = new Dictionary<string, Room>();
        }
    }
}
