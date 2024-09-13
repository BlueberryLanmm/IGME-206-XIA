namespace PE_Casting__Math___Doc_XIA
{
    internal class Program
    {
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



            //print the addition part
            Console.WriteLine("--- ADDITION ---");
            Console.WriteLine("Number A: " + numberA);
            Console.WriteLine("Number B: " + numberB);

            //calculate addition of numberA and numberB
            double sumOfDoubles = numberA + numberB;
            Console.WriteLine(numberA + " + " + numberB + " = " + sumOfDoubles);

            //calculate addition of the whole number portions
            Console.WriteLine("Now I'll add just the whole number parts.");
            int sumOfWholeNumbers = (int)numberA + (int)numberB;
            Console.WriteLine((int)numberA + " + " + (int)numberB + " = " + sumOfWholeNumbers);
            Console.WriteLine();    //Add a blank line



            //print the division and modulus part
            Console.WriteLine("--- DIVISION and MODULUS ---");
            Console.WriteLine(playerName + " has played a game for " + totalGameHour + " hours.");
            Console.WriteLine("He has played for " +
                (totalGameHour / 24) + " days and " +
                (totalGameHour % 24) + " hours.");
            Console.WriteLine();    //Add a blank line



            //print the sine and cosine part
            Console.WriteLine("--- SINE and COSINE ---");
            Console.WriteLine(degree + " degrees is " + radianDegree + " radians.");
            //calculate the sine and cosine.
            Console.WriteLine("The sine is " + Math.Sin(radianDegree));
            Console.WriteLine("The cosine is " + Math.Cos(radianDegree));
            Console.WriteLine();    //Add a blank line



            //print the distance part
            Console.WriteLine("--- DISTANCE ---");
            Console.WriteLine("Point One: (" + pointOneX + "," + pointOneY + ")");
            Console.WriteLine("Point Two: (" + pointTwoX + "," + pointTwoY + ")");
            //calculate the distance
            double distance = Math.Sqrt(
                (Math.Pow(pointOneX - pointTwoX, 2)) +
                (Math.Pow(pointOneY - pointTwoY, 2)));
            Console.WriteLine("The distance between these points is " + distance);
            Console.WriteLine();    //Add a blank line



            //print the rounding part
            Console.WriteLine("--- ROUNDING ---");
            Console.Write("The distance is " + distance + ", ");
            Console.Write("which is approximately " + Math.Round(distance) + " units, ");
            Console.WriteLine("or " + Math.Round(distance, 3) + " to be more precise.");
        }
    }
}
