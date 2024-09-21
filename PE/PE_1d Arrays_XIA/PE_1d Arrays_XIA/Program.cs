namespace PE_1d_Arrays_XIA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ VARIABLES ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // Some local variables to support playing with different
            // types of arrays in different ways.
            double[] scores = { 1, 1.23, 2, 2.34, 3, 3.45, 4, 4.56, 5, 5.67, 6, 6.78, 7, 7.89, 8, 8.90, 9, 9.01, 10 };
            double sum;
            double average;
            string name; // Yes, this is an array too! Strings use a char[] under the hood.
            const int MaxNum = 50; // This will always be >5
            int[] fives;



            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ FILL ARRAYS ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // TODO: Use a loop to prompt the user for a name that is at least 5 characters long
            //ask for the first input
            Console.Write("Enter a name with at least 5 letters: ");
            Console.ForegroundColor = ConsoleColor.Green;
            name = Console.ReadLine().Trim();
            Console.ForegroundColor = ConsoleColor.White;

            //enter the loop if the name is less than 5 letters
            while(name.Length < 5)
            {
                Console.WriteLine("That name has {0} letters", name.Length);
                Console.Write("Please enter a name with at least 5 letters: ");

                Console.ForegroundColor = ConsoleColor.Green;
                name = Console.ReadLine().Trim();
                Console.ForegroundColor = ConsoleColor.White;
            }


            // TODO: Figure out how many multiples of 5 there are between 5 and MaxNum (inclusive),
            //       initialize fives to have an array that will hold that many numbers,
            //       then use a loop to fill it
            fives = new int[MaxNum / 5];

            //use for loop to calculate the fives
            for(int i = 0; i < fives.Length; i++)
            {
                fives[i] = 5 * (i + 1);
            }


            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ CALCS ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // TODO: Use a loop to calculate the sum of all values in the scores array.
            //initialize sum
            sum = 0;

            //add every score into sum
            for(int i = 0; i < scores.Length; i++)
            {
                sum += scores[i];
            }

            // TODO: Use the sum and size of the scores array to calculate the average
            average = sum / scores.Length;


            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ OUTPUT ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // TODO: Without using Substring, print out every other character in the name
            //  (Use a loop and access the characters 1 by 1 instead)
            Console.Write("\nNickname: ");

            for(int i = 0; i < name.Length; i += 2)
            {
                Console.Write(name[i]);
            }
            //switch to the next line
            Console.WriteLine();

            // TODO: Print the fives array all on 1 line
            Console.Write("\nFives: ");
            
            //print every element in fives[]
            for (int i = 0; i < fives.Length; i++)
            {
                Console.Write("{0} ", fives[i]);
            }
            //switch to the next line
            Console.WriteLine();

            // TODO: Print out the sum and average of the scores as well as a list of all scores
            // that are divisible by 2
            Console.WriteLine("\nTotal score: {0}", sum);
            Console.WriteLine("Average score: {0}", average);

            Console.Write("\nScores divisible by 2: ");
            //access every score to check if it's divisible by 2
            for (int i = 0; i < scores.Length; i++)
            {
                if (scores[i] % 2 == 0)
                {
                    Console.Write("{0} ", scores[i]);
                }
            }
            Console.WriteLine();

        }
    }
}
