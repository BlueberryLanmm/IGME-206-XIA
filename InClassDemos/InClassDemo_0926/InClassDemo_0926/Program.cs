namespace InClassDemo_0926
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Try to get some numbers, parse them, and do math
            try
            {
                Console.Write("Enter a number: ");
                int n = int.Parse(Console.ReadLine());

                Console.Write("Enter another number: ");
                int d = int.Parse(Console.ReadLine());

                Console.WriteLine(n + "/" + d + " = " + (n / d));
            }
            // If we couldn't parse a number, a FormatException is thrown
            catch (FormatException e)
            {
                Console.WriteLine("Hey, that wasn't a whole number!");
                Console.WriteLine(e.Message);
            }
            // Catch anything other than format exceptions (e.g. divide by 0) 
            // MUST be last
            catch (Exception e)
            {
                Console.WriteLine("Something else went wrong: " + e.Message);
            }

        }


    }
}
