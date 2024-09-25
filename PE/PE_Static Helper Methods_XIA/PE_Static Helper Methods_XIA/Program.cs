namespace PE_Static_Helper_Methods_XIA
{
    internal class Program
    {
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // LEAVE THE REST OF THE CODE ALONE!
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        /// <summary>
        /// Helper written by Prof. Mesh
        /// Check if one number is a factor of another value
        /// </summary>
        /// <param name="factor">The factor to test</param>
        /// <param name="value">The value to check</param>
        /// <returns>True if value can be evenly divided by the factor</returns>
        public static bool IsFactorOf(int factor, int value)
        {
            // Return true if "factor" is smaller than "value"
            // and is evenly divisible into "value"
            return factor < value && value % factor == 0;
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



        static void Main(string[] args)
        {
            // Setup variables
            string name = "";
            int a = 0;
            int b = 0;
            int choice = 0;

            // Get values for name, a, and b using GetPromptedInput and parsing if needed.
            // Fyi, lines that begin with // TODO: will appear in a VS task list for you!
            // https://docs.microsoft.com/en-us/visualstudio/ide/using-the-task-list
            name = GetPromptedInput("What is your name?");
            a = int.Parse(GetPromptedInput("Enter a whole number:"));
            b = int.Parse(GetPromptedInput("Enter another whole number: "));

            // Reformat the name
            name = name[0].ToString().ToUpper() + name.Substring(1, name.Length - 1).ToLower();

            // Print the menu
            Console.WriteLine("\nHello {0}, what would you like to do?\n" +
                "\t1 - Compare numbers\n" +
                "\t2 - Get my secret code\n" +
                "\t3 - Output all info",
                name);
            choice = int.Parse(GetPromptedInput(">"));
            Console.WriteLine();

            // Figure out what to do and do it
            switch (choice)
            {
                // Check numbers
                case 1:
                    CheckNumbers(a, b);
                    break;

                // Get secret code
                case 2:
                    Console.WriteLine("Your secret code is {0}.", GetSecretCode(name, a, b));
                    break;

                // Output all info
                case 3:
                    PrintAllInfo(name, a, b);
                    CheckNumbers(a, b);
                    break;

                // Say goodbye for invalid choices
                default:
                    Console.WriteLine("That wasn't a valid choice. Goodbye.");
                    break;
            }
        }

        /// <summary>
        /// Check if either a is a factor of b or b is a factor of a,
        /// print out different comments after the check.
        /// </summary>
        /// <param name="a">the first number in check</param>
        /// <param name="b">the second number in check</param>
        public static void CheckNumbers(int a, int b)
        {            
            if (IsFactorOf(a, b) || IsFactorOf(b, a))
            {
                Console.WriteLine("{0} & {1} are awesome numbers.", a, b);
            }
            else
            {
                Console.WriteLine("{0} & {1} are okay I guess.", a, b);
            }
        }

        /// <summary>
        /// Use name, a and b to calculate a secret code.
        /// </summary>
        /// <param name="name">The string used in calculation</param>
        /// <param name="a">The first number in calculation</param>
        /// <param name="b">The second number in calculation</param>
        /// <returns>The secret code as an int number</returns>
        public static int GetSecretCode(string name, int a, int b)
        {
            //calculate and cast to a non-negative int
            return (int)((Math.Sqrt(a) + Math.Pow(a, b) - name.Length) - name[0]);
        }

        /// <summary>
        /// Print user name, input numbers and secret code.
        /// </summary>
        /// <param name="name">The name to be print out</param>
        /// <param name="a">The fist input number</param>
        /// <param name="b">The second input number</param>
        public static void PrintAllInfo(string name, int a, int b)
        {
            //print name in upper case
            Console.WriteLine("Your name is {0},", name.ToUpper());
            //print a and b
            Console.WriteLine("\tyour favorite numbers are {0} and {1},", a, b);
            //print secret code
            Console.WriteLine("\tand your secret code is {0}.", GetSecretCode(name, a, b));
        }
    }
}
