/*************  Plan  *************/
//Step #1:
//          Use Random Class to generate a random number.
//          Store the number in an int variable and print it out.
//Step #2:
//          Use a for loop to prompt use input..
//          The for loop is controled by a int(counting) and bool(correct input).
//Step #3:
//          In the for loop, use an if statement to check if the input is invalid.
//          If invalid, reduce the guess time count and print out invalid comment.
//          In the else statement, check whether the answer is correct.
//Step #4:
//          When exiting the for loop, print an conclusion 
//          according to whether the answer is correct.
//Reference:
//          Input helper written by Prof.Mesh is included.


namespace PE_Guessing_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //variables declaration
            int randNum;
            int guessCount = 0;
            int userGuess = 0;

            bool isCorrect = false;
            bool isInputValid = true;

            Random rng = new Random();


            //generate random number
            randNum = rng.Next(101);

            Console.WriteLine(randNum);


            //prompt user input in a for loop
            //if guessCount >= 8 or the user input is correct, exit the loop
            for (guessCount = 0; guessCount < 8 && !isCorrect; guessCount++)
            {
                //if tryParse() succeeds, give the user input to userGuess
                isInputValid = int.TryParse(
                    GetPromptedInput(
                        String.Format("\nTurn #{0}: Guess a number between 0 and 100 (inclusive):", 
                        guessCount + 1))
                    , out userGuess);

                //if the input can be parsed, or the number is out of range,
                //reduce guessCount so that it remains unchanged in the next loop
                if (!isInputValid || userGuess < 0 || userGuess > 100)
                {
                    Console.WriteLine("Invalid guess - try again.");
                    guessCount--;
                }
                //if the input is good, check if it's correct
                else
                {
                    isCorrect = (userGuess == randNum);

                    //check if the user guess is too low or too high
                    if (userGuess < randNum)
                    {
                        Console.WriteLine("Too low.");
                    }
                    else if (userGuess > randNum)
                    {
                        Console.WriteLine("Too high.");
                    }
                }
            }

            //after exiting the loop, check if the user has got the correct number
            if (isCorrect)
            {
                Console.WriteLine("\nCorrect! You won in {0} turns.", guessCount);
            }
            else
            {
                Console.WriteLine("\nYou ran out of turns. The number was {0}.", randNum);
            }
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
