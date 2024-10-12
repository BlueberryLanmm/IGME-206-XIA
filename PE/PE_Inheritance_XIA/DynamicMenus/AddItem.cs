using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicMenus
{
    internal class AddItem : MenuItem
    {

        // ~~~ FIELDS ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //The sum of all numbers
        private double sum;
        //The number array
        private double[] numbers;

        //Check how many numbers are added
        private int numberAdded;

        //The array of userInput divided by commas
        private string[] userInputs;

        // ~~~ PROPERTIES ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // None specific to this child class

        // ~~~ CONSTRUCTORS ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public AddItem()
            : base("ADD",
                  "Calculate the sum of numbers",
                  "Enter some numbers from -100 to 100, seperated by ',': ")
        {

        }

        // ~~~ OVERRIDES from Object ~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // None specific to this child class

        // ~~~ METHODS ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public override void Run()
        {
            //Use a loop to keep prompting for number input,
            //until get valid numbers.
            do
            {
                //Print prompt info
                Console.Write(actionText);

                //Store the data divided by commas
                userInputs = Console.ReadLine().Trim().Split(',');
                //Make the numbers array the same length as the data
                numbers = new double[userInputs.Length];
                //Initialize the sum
                sum = 0;

                //Parse and add numbers one by one
                for (numberAdded = 0; 
                    numberAdded < userInputs.Length; 
                    numberAdded++)
                {
                    //If any input is invalid, break the for loop
                    //and mark the allAdded as false.
                    if (!double.TryParse(userInputs[numberAdded].Trim(), 
                        out numbers[numberAdded]) ||
                        numbers[numberAdded] < -100 ||
                        numbers[numberAdded] > 100)
                    {
                        Console.WriteLine("Invalid input. Please try again.\n");
                        break;
                    }
                    //If a number is valid, add it to sum
                    else
                    {
                        sum += numbers[numberAdded];
                    }
                }
            }
            //If the for loop did not break,
            //all numbers should be added.
            while (numberAdded != numbers.Length);

            Console.WriteLine($"The sum of all numbers is {sum}.");
        }
    }
}
