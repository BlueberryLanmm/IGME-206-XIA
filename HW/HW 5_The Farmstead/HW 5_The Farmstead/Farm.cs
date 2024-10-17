using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_5_The_Farmstead
{
    internal class Farm
    {
        //Declare constant for readablity
        //For weather checking
        private const double Blight = 0.05;
        private const double Rain = 0.25;

        //For the check of fields in specific status
        private const int Empty = 0;
        private const int Planted = 1;


        private string name;
        private double currentMoney;
        private double dailyCost;

        private Crop[] cropList;
        private Crop[] currentCrop;

        private Random rng;

        private int daysPast;


        /// <summary>
        /// Call to initialize a new instance of Farm class
        /// </summary>
        /// <param name="name">Name of the farm.</param>
        /// <param name="cropList">The list of available crops.</param>
        /// <param name="fields">The number of fields.</param>
        /// <param name="startMoney">The money at the beginning</param>
        /// <param name="dailyCost">The farm's daily cost.</param>
        public Farm(
            string name, 
            Crop[] cropList, 
            int fields, 
            double startMoney, 
            double dailyCost)
        {
            this.name = name;
            this.currentMoney = startMoney;
            this.dailyCost = dailyCost;

            this.cropList = cropList;
            this.currentCrop = new Crop[fields];

            rng = new Random();

            daysPast = 0;
        }

        /// <summary>
        /// Return the name of the farm
        /// </summary>
        public string Name
        {
            get { return name; } 
        }

        /// <summary>
        /// Return the current money
        /// </summary>
        public double Money
        {
            get { return currentMoney; } 
        }


        /// <summary>
        /// Return the string of all fields information.
        /// </summary>
        private string FieldTable()
        {
            string output = string.Empty;

            for (int i = 0; i < currentCrop.Length; i++)
            {
                output += $" - Field {i + 1}: ";

                if (currentCrop[i] != null)
                {
                    output += currentCrop[i].ToString() + "\n";
                }
                else
                {
                    output += "Empty\n";
                }
            }

            return output;
        }

        /// <summary>
        /// Return the string of a list of available crops.
        /// </summary>
        private string CropsTable()
        {
            string output = string.Empty;

            for (int i = 0; i < cropList.Length; i++)
            {
                output += String.Format($"  {i + 1}. {cropList[i].Name}\n");
            }

            return output;
        }

        /// <summary>
        /// Call to check the number of fields that is
        /// empty or planted.
        /// </summary>
        /// <param name="status">'Empty' or 'Planted' fields to check</param>
        /// <returns>Return the number of desired fields</returns>
        private int CheckField(int status)
        {
            int emptyFields = 0;

            //Count the empty fields
            for (int i = 0; i < currentCrop.Length; i++)
            {
                if (currentCrop[i] == null)
                {
                    emptyFields++;
                }
            }

            //If number of empty fields is needed
            if (status == Empty)
            {
                return emptyFields;
            }
            //If number of planted fields is needed
            else if (status == Planted)
            {
                return currentCrop.Length - emptyFields;
            }

            //Return 0 by default
            return 0;
        }


        /// <summary>
        /// Call to pass a game, weather condition may influence
        /// the day's result.
        /// </summary>
        public void DayPassed()
        {
            double randomNumber = rng.NextDouble();

            //Decrementing the farm's money by the daily cost
            currentMoney -= dailyCost;

            //Check the random number range for every field
            for (int i = 0; i < currentCrop.Length; i++)
            {

                if (randomNumber < Blight)
                {
                    //Set all fields to null
                    currentCrop[i] = null;
                }
                //If it's within Rain range and is not null
                else if (randomNumber < Rain && currentCrop[i] != null)
                {
                    //Call an extra DayPassed() for every crop
                    currentCrop[i].DayPassed();
                    currentCrop[i].DayPassed();
                }
                //If the weather is fine, call DayPassed() for every crop
                else if (currentCrop[i] != null) 
                {
                    currentCrop[i].DayPassed();
                }
            }


            //Print the message accordingly
            if (randomNumber < Blight)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(
                    "Blight has struck the farm!\n" +
                    "All our crops are dead! :(");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (randomNumber < Rain)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(
                    "I rained. Crops grew faster today. :)");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }


        public void Harvest()
        {
            int select;

            //If there is no planted field,
            //print the message and exit the method
            if (CheckField(Planted) <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have to plant something first!");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            //Prompt the user to select a field to harvest
            //Minus 1 and store.
            select = SmartConsole.GetValidNumericInput(
                "\nSelect a field to harvest:\n" + this.FieldTable() + ">",
                1, currentCrop.Length)
                - 1;

            //If the selected is empty
            if (currentCrop[select] == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have to plant something in field #{0} first!",
                    select + 1);
                Console.ForegroundColor = ConsoleColor.White;
            }
            //Else if it is ready to harvest
            else if (currentCrop[select].CanHarvest)
            {
                currentMoney += currentCrop[select].SellingPrice;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Sold {0} for {1:C2}",
                    currentCrop[select].Name,
                    currentCrop[select].SellingPrice);
                Console.ForegroundColor = ConsoleColor.White;

                currentCrop[select] = null;
            }
            //Else if it is not ready to harvest
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The {0} is not ready to harvest!",
                    currentCrop[select]);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }


        public void Plant()
        {
            int select;

            //If there is no empty field
            //Print a message and exit the method.
            if (CheckField(Empty) <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Unable to plant right now. Harvest something first.");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            //Prompt the user to select a crop to plant
            //Minus 1 and store.
            select = SmartConsole.GetValidNumericInput(
                "\nSelect a crop to plant:\n" + this.CropsTable() + ">",
                1, cropList.Length)
                - 1;

            if (currentMoney < cropList[select].Cost)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"No enough money for the {cropList[select].Name}!");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            //Search the first empty field and plant the crop
            for (int i = 0; i < currentCrop.Length; i++)
            {
                if (currentCrop[i] == null)
                {
                    currentCrop[i] = cropList[select];

                    currentMoney -= cropList[select].SellingPrice;

                    Console.ForegroundColor= ConsoleColor.Green;
                    Console.WriteLine($"{cropList[select].Name} planted in field #{i + 1}.");
                    Console.ForegroundColor = ConsoleColor.White;

                    //Break the loop if successfully planted.
                    break;
                }
            }
        }


        /// <summary>
        /// Call to print all the information in the game,
        /// calculate and print out the potential income for the day.
        /// </summary>
        public void PrintStatus()
        {
            //Calculate the potential income for selling all
            //crops ready for harvest.
            double potentialIncome = 0;

            for (int i = 0; i < currentCrop.Length; i++)
            {
                if (currentCrop[i] != null && currentCrop[i].CanHarvest)
                {
                    potentialIncome += currentCrop[i].SellingPrice;
                }
            }

            //Print out all the information before a day
            //Print the farm name and current money
            Console.WriteLine("\nDay {0} at {1} with {2:C2} on hand.",
                ++daysPast, name, currentMoney);
            //Print the potential income
            Console.WriteLine(
                "We have {0:C2} potential earning's from the fields ready to harvest.",
                potentialIncome);

            //Print the field status
            Console.WriteLine(this.FieldTable());
        }

    }
}
