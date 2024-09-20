namespace PE_If_s___Switches
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /********************************************************************
             * Question #1
             ********************************************************************/
            //print question
            Console.Write("\nWhat is 5 * 9? ");

            //check if the input equals to the answer
            if (int.Parse(Console.ReadLine()) == 5 * 9)
            {
                Console.WriteLine("That's correct!");
            }
            else
            {
                Console.WriteLine("Nope :(");
            }


            /********************************************************************
             * Question #2
             ********************************************************************/
            //declare the 3 input
            int number1;
            int number2;
            int number3;

            //print question
            Console.WriteLine("\n\nEnter 3 whole numbers in *ascending* order:");
            //ask for 3 integer input
            Console.Write("1: ");
            number1 = int.Parse(Console.ReadLine().Trim());
            Console.Write("2: ");
            number2 = int.Parse(Console.ReadLine().Trim());
            Console.Write("3: ");
            number3 = int.Parse(Console.ReadLine().Trim());

            //check if it's the correct order
            if (number1 < number2 && number2 < number3)
            {
                Console.WriteLine("That's correct!");
            }
            //check if it's a descending order
            else if (number1 > number2 && number2 > number3)
            {
                Console.WriteLine("That's backwards!");
            }
            //neither of the above
            else
            {
                Console.WriteLine("What?");
            }


            /********************************************************************
             * Question #3
             ********************************************************************/
            //declare the user input variable
            string userInput;

            //Print the question
            Console.WriteLine("\n\nThe Visual Studio version used in IGME-206 class is...");
            Console.WriteLine("\ta. Visual Studio 2019\n" +
                "\tb. Visual Studio 2020\n" +
                "\tc. Visual Studio 2021\n" +
                "\td. Visual Studio 2022");
            //ask for the user input
            Console.Write("\n> ");
            userInput = Console.ReadLine().ToLower().Trim();

            //check cases
            switch (userInput)
            {
                //use fall through cases for the wrong anser
                case "a":
                case "b":
                case "c":
                    Console.WriteLine("Sorry. That's wrong. We are using Visual Studio 2022.");
                    break;

                //the correct answer case
                case "d":
                    Console.WriteLine("Correct!");
                    break;

                //default case
                default:
                    Console.WriteLine("That's not an option!");
                    break;
            }
        }
    }
}
