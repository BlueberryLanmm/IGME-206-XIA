using Microsoft.VisualBasic;

namespace InClassDemo_0912
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ////TryParse TEST!!!
            //string userInput = Console.ReadLine();

            //if (int.TryParse(userInput, out int result))
            //{
            //    Console.Write("The number you type is: ");
            //    Console.WriteLine(result);
            //}
            //else
            //{
            //    Console.WriteLine("You are not typing integers!");
            //}


            ////String.Format TEST!!!
            //double value = 123.4567; 
            //String s = String.Format("Price is {0}.", value);
            //Console.Write("Via Format: ");
            //Console.WriteLine(s);
            //Console.WriteLine();

            //Console.WriteLine("Now I'm trying to change the value.\n");
            //value *= 3.14;
            //Console.Write("Via Format: ");
            //Console.WriteLine(s);
            //Console.WriteLine();

            //Console.Write("Via WL: ");
            //Console.WriteLine("Price is {0}.", value);
            //Console.WriteLine();


            ////MORE DEMO!!!
            //// Define text we may use a lot up front with our variables.
            //// (or even eventually read the dialog in from a file!)
            //const string IntroTextTemplate = "Welcome {0}! How are you this fine {1}?";
            //string name;

            //// Get the values to plug in later via user input...
            //Console.Write("What is your name?");
            //name = Console.ReadLine().Trim();

            //// or other System methods...
            //// (DayOfWeek is a System defined type that formatting can
            ////  auto-convert to a string)
            //DayOfWeek today = DateTime.Today.DayOfWeek;

            //// Build the full test as we print to the console
            //Console.WriteLine(IntroTextTemplate, name, today);

            //// or build the full text as a string to use later 
            //// (e.g. to save to a file)
            //string text = String.Format(IntroTextTemplate, name, today);

            //// We also don't have to only put variables in for the substitute values
            //// Expressions, property lookups, or other method calls are fine too
            //Console.WriteLine(IntroTextTemplate, name, DateTime.Today.DayOfWeek);


            ////ConsoleColor TEST!!!
            //// If you want to change the whole screen's color,
            //// set it and then CLEAR
            //Console.WriteLine("Testing a new color scheme");
            //Console.WriteLine("Press Enter to continue.");
            //Console.ReadLine();

            //Console.BackgroundColor = ConsoleColor.Cyan;
            //Console.ForegroundColor = ConsoleColor.Black;
            //Console.Clear();

            //Console.WriteLine("Press Enter to continue.");
            //Console.ReadLine();

            //// Reset back to reasonable colors
            //Console.ForegroundColor = ConsoleColor.White;
            //Console.BackgroundColor = ConsoleColor.Black;
            //Console.Clear();
            //Console.WriteLine("That's better!");


            // The variable will hold the value true
            bool comparison = 4 < 10;

            // Much like + or -, we get a result from the
            // relational operators that we can use in
            // other statements or expressions

            Console.WriteLine("4 < 10: {0}", comparison);

        }
    }
}
