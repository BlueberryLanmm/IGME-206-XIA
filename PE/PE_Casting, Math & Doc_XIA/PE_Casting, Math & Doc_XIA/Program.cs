namespace PE_Casting__Math___Doc_XIA
{
    internal class Program
    {
        //Edited on 09/13/2024 for PE_Input & Parsing
        static void Main(string[] args)
        {
            //Declare the varibles
            string playerName = "Yuxuan";

            int totalGameHour = 274;
            int pointOneX = -13;
            int pointOneY = 51;
            int pointTwoX = 17;
            int pointTwoY = 28;

            double numberA = 7.9;
            double numberB = 2.25;
            double degree = 60;
            double radianDegree = degree * Math.PI / 180;

            //Declare the string variable to store user input
            string userInput;



            //print the addition part
            Console.WriteLine("--- ADDITION ---");

            //get the 2 numbers
            Console.Write("What is the first number? ");
            userInput = Console.ReadLine();
            numberA = double.Parse(userInput);
            Console.Write("What is the second number? ");
            userInput = Console.ReadLine();
            numberB = double.Parse(userInput);

            //calculate addition of numberA and numberB
            double sumOfDoubles = numberA + numberB;
            Console.WriteLine("{0} + {1} = {2}", numberA, numberB, sumOfDoubles);

            //calculate addition of the whole number portions
            Console.WriteLine("Now I'll add just the whole number parts.");
            int sumOfWholeNumbers = (int)numberA + (int)numberB;
            Console.WriteLine("{0} + {1} = {2}\n", (int)numberA, (int)numberB, sumOfWholeNumbers);



            //print the division and modulus part
            Console.WriteLine("--- DIVISION and MODULUS ---");

            //get the player's name and the game hours
            Console.Write("What is that player's name? ");
            playerName = Console.ReadLine().Trim();
            Console.Write("How many hours have they logged? ");
            userInput = Console.ReadLine();
            totalGameHour = int.Parse(userInput);

            Console.WriteLine("{0} has played a game for {1} hours.", playerName, totalGameHour);
            Console.WriteLine("They have played for {0} days and {1} hours.\n",
                (totalGameHour / 24), (totalGameHour % 24));



            //print the sine and cosine part
            Console.WriteLine("--- SINE and COSINE ---");

            //get an angle in degrees:
            Console.Write("Enter an angle in degrees: ");
            userInput = Console.ReadLine();
            degree = double.Parse(userInput);
            //calculate and print the degrees in radians
            radianDegree = degree * Math.PI / 180;
            Console.WriteLine("{0} degrees is {1} radians.", degree, radianDegree);

            //calculate the sine and cosine.
            Console.WriteLine("The sine is {0}", Math.Sin(radianDegree));
            Console.WriteLine("The cosine is {0}\n", Math.Cos(radianDegree));



            //print the distance and rounding part
            Console.WriteLine("--- DISTANCE and ROUNDING ---");

            //get the points' coordinate
            Console.Write("Enter Point 1 X: ");
            userInput = Console.ReadLine();
            pointOneX = int.Parse(userInput);
            Console.Write("Enter Point 1 Y: ");
            userInput = Console.ReadLine();
            pointOneY = int.Parse(userInput);
            Console.Write("Enter Point 2 X: ");
            userInput = Console.ReadLine();
            pointTwoX = int.Parse(userInput);
            Console.Write("Enter Point 2 Y: ");
            userInput = Console.ReadLine();
            pointTwoY = int.Parse(userInput);

            Console.WriteLine("Point One: ({0}, {1})", pointOneX, pointOneY);
            Console.WriteLine("Point Two: ({0}, {1})", pointTwoX, pointTwoY);
            //calculate the distance
            double distance = Math.Sqrt(
                (Math.Pow(pointOneX - pointTwoX, 2)) +
                (Math.Pow(pointOneY - pointTwoY, 2)));
            Console.WriteLine("The distance between these points is {0}.", distance);

            //print the round part
            Console.Write("The distance is {0},", distance);
            Console.Write("which is approximately {0} units, ", Math.Round(distance));
            Console.WriteLine("or {0} to be more precise.", Math.Round(distance, 3));
        }
    }
}
