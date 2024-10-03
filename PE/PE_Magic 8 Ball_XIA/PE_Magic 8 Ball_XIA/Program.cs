using System.Security.Cryptography;

namespace PE_Magic_8_Ball_XIA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Declaring variables
            string owner;
            string userInput;


            //Print a greeting
            Console.WriteLine("Welcome to Magic 8 Ball Simulator!");

            //Prompt the user for owner name input
            owner = GetPromptedInput(" > Who owns this ball?");

            //Instantiate the MagicEightBall object
            MagicEightBall magicEightBall = new MagicEightBall(owner);


            //Use a loop to keep prompting user choices
            do
            {
                Console.WriteLine("\nWhat would you like to do?");

                //prompt user choices input
                userInput = GetPromptedInput(
                    "You can 'shake' the ball, get a 'report', or 'quit':")
                    .ToLower();

                switch (userInput)
                {
                    case "shake":
                        //Print a random response whatever the question is
                        //Call ShakeBall() method in MagicEightBall and print out
                        GetPromptedInput(" > What is your question?");
                        Console.WriteLine(" > The Magic 8 ball says: {0}", 
                            magicEightBall.ShakeBall());
                        break;

                    case "report":
                        //Call Report() method in MagicEightBall and print out
                        Console.WriteLine(" > {0}", 
                            magicEightBall.Report());
                        break;

                    case "quit":
                        //print goodbye
                        Console.WriteLine(" > Goodbye!");
                        break;

                    default:
                        //print invalid information
                        Console.WriteLine(" > I do not recongnize that response.");
                        break;
                }
            }
            //Check if the user input is "quit"
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
