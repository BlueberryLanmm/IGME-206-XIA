namespace HW_3_Gradebook_XIA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /********************************************************************
             * Activity 1: Getting the Data
             ********************************************************************/
            //assignment names and grades for Acitivity 1
            int numberOfGrades;
            string[] assignmentName;
            double[] assignmentGrades;

            //store average grade for Activity 2
            double averageGrade = 0;

            //store user input index for Activity 3
            int indexReplaced;

            //store analysis results for Avtivity 5
            int gradeAboveAverage = 0;
            double lowestGrade = 100;
            double highestGrade = 0;
            bool isDuplicated = false;


            //prompt for positive-non-zero number of grades
            Console.Write("How many assignments are you saving? ");
            numberOfGrades = int.Parse(Console.ReadLine().Trim());

            //do the loop if the number input is invalid
            while (numberOfGrades <= 0)
            {
                Console.Write("That is not a valid number. Enter the number of assignments: ");
                numberOfGrades = int.Parse(Console.ReadLine().Trim());
            }

            Console.WriteLine("You are saving {0} assignments", numberOfGrades);

            //initialize the arrays
            assignmentName = new string[numberOfGrades];
            assignmentGrades = new double[numberOfGrades];

            //prompt user input of assignments name and grades
            for (int i = 0; i < numberOfGrades; i++)
            {
                //ask for the assignment name
                Console.Write("\nEnter the name for assignment #{0}: ", i + 1);
                assignmentName[i] = Console.ReadLine().Trim();

                //ask for the assignment grade
                Console.Write("Enter the grade for {0}: ", assignmentName[i]);
                assignmentGrades[i] = double.Parse(Console.ReadLine());

                //if the grade is invalid, keep asking for the grade until get a valid number
                while (assignmentGrades[i] > 100 || assignmentGrades[i] < 0)
                {
                    Console.Write("Grade must be between 0 and 100. Enter grade: ");
                    assignmentGrades[i] = double.Parse(Console.ReadLine());
                }
            }

            //print a conclusion after all input is stored
            Console.WriteLine("\nAll grades are entered!");



            /********************************************************************
             * Activity 2: Grade Average
             ********************************************************************/

            //print out a listing of assignments and grades.
            Console.WriteLine("\nGrade Report:");

            for (int i = 0; i < numberOfGrades; i++)
            {
                Console.WriteLine("{0}. {1}: {2}", 
                    i + 1, assignmentName[i], assignmentGrades[i]);

                averageGrade = (averageGrade * i + assignmentGrades[i]) / (i + 1);
            }

            //add a division line and print the average grade
            Console.WriteLine("- - - - - - - - - - - - - - - - - -");
            Console.WriteLine("Average: {0:F2}", averageGrade);



            /********************************************************************
             * Activity 3: Grade Replacement
             ********************************************************************/
            //Ask the user about which grade to replace
            Console.Write("\nWhich number grade do you want to replace? ");
            indexReplaced = int.Parse(Console.ReadLine()) - 1;

            //use the while loop to keep prompting index input
            while (indexReplaced < 0 || indexReplaced >= numberOfGrades)
            {
                Console.WriteLine("Index must be a number between 1 and {0}. Try again.", numberOfGrades);
                Console.Write("Which number grade do you want to replace? ");
                indexReplaced = int.Parse(Console.ReadLine()) - 1;
            }

            //prompt new grade input for this assignment
            Console.Write("\nWhat is the new grade for {0}? ", assignmentName[indexReplaced]);
            assignmentGrades[indexReplaced] = double.Parse(Console.ReadLine());

            //if the grade is invalid, keep asking for the grade until get a valid number
            while (assignmentGrades[indexReplaced] > 100 || assignmentGrades[indexReplaced] < 0)
            {
                Console.Write("Grade must be between 0 and 100. Enter grade: ");
                assignmentGrades[indexReplaced] = double.Parse(Console.ReadLine());
            }

            //print a conclusion for this replacement
            Console.WriteLine("\nReplacing the grade at index {0} with {1}",
                indexReplaced + 1,
                assignmentGrades[indexReplaced]);



            /********************************************************************
             * Activity 4: Print Final Summary
             ********************************************************************/

            //print out a renewed listing of assignments and grades.
            Console.WriteLine("\nFinal Grade Report:");

            for (int i = 0; i < numberOfGrades; i++)
            {
                Console.WriteLine("{0}. {1}: {2}",
                    i + 1, assignmentName[i], assignmentGrades[i]);

                averageGrade = (averageGrade * i + assignmentGrades[i]) / (i + 1);
            }

            //add a division line and print the average grade
            Console.WriteLine("- - - - - - - - - - - - - - - - - -");
            Console.WriteLine("Average: {0:F2}", averageGrade);



            /********************************************************************
             * Activity 5: Analyze and Report!
             ********************************************************************/
            //use a for loop to analyze the grades
            for (int i = 0; i < numberOfGrades; i++)
            {
                //when a grade is above average, add to gradeAboveAverage
                if (assignmentGrades[i] > averageGrade)
                {
                    gradeAboveAverage++;
                }

                //when a grade is higher than current highest grade,
                //make it the new highest grade.
                if (assignmentGrades[i] > highestGrade)
                {
                    highestGrade = assignmentGrades[i];
                }

                //when a grade is lower than current lowest grade,
                //make it the new lowest grade.
                if (assignmentGrades[i] < lowestGrade)
                {
                    lowestGrade = assignmentGrades[i];
                }

                //Compare this grade to other grades in the array.
                //Exit the loop after going through all the grades
                //or any duplicated grades are found.
                for (int j = i + 1; j < numberOfGrades && !isDuplicated; j++)
                {
                    isDuplicated = (assignmentGrades[i] == assignmentGrades[j]);
                }
            }

            //Print out the analysis results
            Console.WriteLine("\n{0} grades are above average.\n", gradeAboveAverage);
            Console.WriteLine("The highest grade is {0}.", highestGrade);
            Console.WriteLine("The lowest grade is {0}.\n", lowestGrade);
            
            //print the duplicate analysis according to "isDuplicated".
            if (isDuplicated)
            {
                Console.WriteLine("A grade appears more than once in this set of grades.");
            }
            else
            {
                Console.WriteLine("All grades are unique.");
            }
        }
    }
}
