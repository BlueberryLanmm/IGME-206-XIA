namespace PE_Lists_XIA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Declare variables
            Random rng = new Random();
            string userInput;
            string stolenItem;
            int whichPlayer;

            Player player1;
            Player player2;

            List<string> stolenItems = new List<string>();


            //Prompt the user for 2 players' name
            userInput = GetPromptedInput("\nEnter Player 1's name:");
            player1 = new Player(userInput);

            userInput = GetPromptedInput("\nEnter Player 2's name:");
            player2 = new Player(userInput);


            //Prompt the user for 5 items
            for (int i = 0; i < 5; i++)
            {
                userInput = GetPromptedInput("\nEnter an item:");
                //Round a random number to be 1 or 2.
                //Determine which player according to it.
                whichPlayer = (int)Math.Round(rng.NextDouble()) + 1;

                //if player 1, add to player 1's inventory
                if (whichPlayer == 1)
                {
                    player1.AddToInventory(userInput);
                }
                //else player 2, add to player 2's inventory
                else
                {
                    player2.AddToInventory(userInput);
                }
            }


            //Print each player's inventory
            player1.PrintInventory();
            player2.PrintInventory();


            //use a loop to keep prompting user choices
            do
            {
                userInput = GetPromptedInput(
                    "\nEnter a command (print, steal, or quit) or an item:");

                switch (userInput)
                {
                    case "print":
                        //Call the PrintInventory method to print
                        //both players inventory
                        player1.PrintInventory();
                        player2.PrintInventory();
                        break;

                    case "steal":
                        //Ask for further info about stolen item
                        whichPlayer = int.Parse(
                            GetPromptedInput("Which player would you like to steal from (1 or 2)?"));

                        //if player 1
                        if (whichPlayer == 1)
                        {
                            //Use userInput to store the number input
                            //Use stolenItem to get the item of that number
                            userInput = GetPromptedInput("Which item # would you like to steal from?");
                            stolenItem = player1.GetItemInSlot(int.Parse(userInput));
                            
                            //if the item # is valid, add it to the stolenItem list
                            if (stolenItem != null)
                            {
                                stolenItems.Add(stolenItem);
                            }
                        }
                        //if player 2
                        else
                        {
                            //Use userInput to store the number input
                            //Use stolenItem to get the item of that number
                            userInput = GetPromptedInput("Which item # would you like to steal from?");
                            stolenItem = player2.GetItemInSlot(int.Parse(userInput));

                            if (stolenItem != null)
                            {
                                stolenItems.Add(stolenItem);
                            }
                        }
                        break;

                    case "quit":
                        //Print out all the stolen items so far
                        Console.WriteLine("You stole {0} item(s):", stolenItems.Count);

                        for (int i = 0; i < stolenItems.Count; i++)
                        {
                            Console.WriteLine("\t{0}", stolenItems[i]);
                        }
                        break;

                    default:
                        //The user input is an item's name,
                        //add it to a random player's inventory

                        whichPlayer = (int)Math.Round(rng.NextDouble()) + 1;

                        //if player 1, add to player 1's inventory
                        if (whichPlayer == 1)
                        {
                            player1.AddToInventory(userInput);
                        }
                        //else player 2, add to player 2's inventory
                        else
                        {
                            player2.AddToInventory(userInput);
                        }
                        break;

                }
            }
            while (userInput != "quit");
        }


        /// <summary>
        /// Input helper written by Prof. Mesh
        /// Uses the given string to prompt the user for input and set
        /// the color to cyan while they type.
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
