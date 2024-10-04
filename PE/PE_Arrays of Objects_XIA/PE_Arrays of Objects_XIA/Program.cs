namespace PE_Arrays_of_Objects_XIA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int amount = 0;
            Deck deck = new Deck();

            //Call Print() method of Deck to print all the cards in the deck
            deck.Print();

            //Use a while loop to check if the input is valid
            while (!int.TryParse(
                GetPromptedInput("\nEnter a number of cards to deal (1-52)"), 
                out amount) ||
                amount <= 0 ||
                amount > 52)
            {
                Console.WriteLine("Invalid input. Please try again.");
            }

            //Call Deal() method of Deck to randomly print out
            //cards of specific number.
            deck.Deal(amount);
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
