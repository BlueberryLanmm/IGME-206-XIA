using System.Net.Quic;

namespace PE_File_IO_with_Classes_XIA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Store the userInput temporarily
            string userInput;

            //Store the input to create a player
            string name;
            int strength;
            int health;

            PlayerManager playerManager = new PlayerManager();

            //Prompting for use input with a loop
            do
            {
                userInput = GetPromptedInput(
                    "\nCreate. Print. Save. Load. Quit. >>").ToLower();

                //use switch statement to address player input
                switch (userInput)
                {
                    //If input "create", prompt for more info to create a player.
                    case "create":
                        name = GetPromptedInput("What is the player's name?");

                        while (!int.TryParse(GetPromptedInput("Player's strength?"), out strength))
                        {
                            Console.WriteLine("Invalid input. Please try again.");
                        }

                        while (!int.TryParse(GetPromptedInput("Player's health?"), out health))
                        {
                            Console.WriteLine("Invalid input. Please try again.");
                        }

                        playerManager.CreatePlayer(name, strength, health);

                        break;

                    //If input "print", call Print() method
                    case "print":
                        playerManager.Print();
                        break;

                    //If input "save", call Save() method
                    case "save":
                        playerManager.Save();
                        break;

                    //If input "load", call Load() method
                    case "load":
                        playerManager.Load();
                        break;

                    //If input "quit", exit the loop
                    case "quit":
                        Console.WriteLine("Goodbye!");
                        break;

                    //If none of the above, prompt for input again.
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }
            }
            while (userInput != "quit");
        }

        /// <summary>
        /// Input helper written by Prof. Mesh
        /// Uses the given string to prompt the user for input and set
        /// the color to cyan while they type.
        /// DO NOT TOUCH THIS METHOD!
        /// </summary>
        /// <param name="prompt">What to print before waiting for input</param>
        /// <returns>A trimmed version of what the user entered</returns>
        public static string GetPromptedInput(string prompt)
        {
            // Always print in white
            Console.ForegroundColor = ConsoleColor.White;

            // Print the prompt
            Console.Write(prompt + " ");

            // Switch color and get user input (trim too)
            Console.ForegroundColor = ConsoleColor.Cyan;
            string response = Console.ReadLine().Trim();

            // Switch back to white and then return response.
            Console.ForegroundColor = ConsoleColor.White;
            return response;
        }
    }
}
