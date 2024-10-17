//Name: Yuxuan Xia
//
//Note: No known bugs.
//      No bonus task is down in this HW.
//      Some required properties/constructors were not reference.

using System.Runtime.CompilerServices;

namespace HW_5_The_Farmstead
{
    internal class Program
    {
        //For indicating the switch choice
        private const int Plant = 0;
        private const int Harvest = 1;
        private const int DoNothing = 2;
        private const int Quit = 3;

        static void Main(string[] args)
        {
            Farm myFarm;
            int choice = -1;

            //Print the welcome message.
            Console.WriteLine("Welcome to Farmstead, your virtual farming adventure!");

            //Initialize the farm.
            myFarm = GetFarm();


            //The main game loop, keep prompting for choice 
            //until the game ends.
            while (choice != 3 && myFarm.Money > 0)
            {
                myFarm.PrintStatus();

                switch (choice = SmartConsole.GetValidNumericInput(
                    "  1. Plant crops\n" +
                    "  2. Harvest and sell produce\n" +
                    "  3. Do nothing today\n" +
                    "  4. Quit\n>", Plant + 1, Quit + 1)
                    - 1)
                {
                    case Plant:
                        myFarm.Plant();
                        myFarm.DayPassed();
                        break;

                    case Harvest:
                        myFarm.Harvest();
                        myFarm.DayPassed();
                        break;

                    case DoNothing:
                        myFarm.DayPassed();
                        break;

                    case Quit:
                        myFarm.DayPassed();
                        break;
                }
            }

            //Print the result depending on whether there is money left.
            if (myFarm.Money > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nYou quit with {0:C2} in the bank!", myFarm.Money);
                Console.ForegroundColor= ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n{0} ran out of money!", myFarm.Name);
                Console.ForegroundColor= ConsoleColor.White;
            }
        }

        /// <summary>
        /// Call to get a new Farm object with prompted information.
        /// </summary>
        /// <returns>Return the new instance of Farm class</returns>
        static public Farm GetFarm()
        {
            string name;
            int fields;
            double startMoney;
            double dailyCost;

            Crop[] cropList;
            string cropName;
            double cropCost;
            int growthTime;

            //Print the initialization information 
            Console.WriteLine(" Start your farming journey by defining the crops avabilable" +
                " and naming your farm.");

            //Get the available crops number
            cropList = new Crop[SmartConsole.GetValidNumericInput(
                "\nHow many types of crops do you want to define?",
                1, 5)];

            //Create a new instance of Crop class for each crop
            for (int i = 0; i < cropList.Length; i++)
            {
                Console.WriteLine($"\nDefine crop type #{i + 1}");

                cropName = SmartConsole.GetPromptedInput(" Name:");
                cropCost = SmartConsole.GetValidNumericInput(" Cost:", 1, 500);
                growthTime = SmartConsole.GetValidNumericInput(" Days until harvest:", 1, 10);

                cropList[i] = new Crop(cropName, cropCost, growthTime);
            }

            //Prompt input for other information
            name = SmartConsole.GetPromptedInput("\nPlease name your farm:");

            fields = SmartConsole.GetValidNumericInput(
                "\nHow many fields are available for planting?", 1, 5);

            startMoney = SmartConsole.GetValidNumericInput(
                "\nHow much money are you starting with?", 1, 1000);

            dailyCost = SmartConsole.GetValidNumericInput(
                "\nWhat is the daily maintenance cost?", 1, 50);

            //Print a message and return the new instance of class Farm
            Console.WriteLine($"\n ***{name}, ready for a fruitful season! ***");

            return new Farm(name, cropList, fields, startMoney, dailyCost);
        }
    }
}
