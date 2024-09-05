/*
 * Yuxuan Xia
 * PE - Statement & Expressions
 * 
 * Issues (seem to have no influence on running):
 * - Why isn't there a "using system" statement here?
 * - And why is the class shown as the "internal class"?
 */

namespace PE_Statement___Expression_Xia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Name the character with WriteLine(), and add a blank line.
            //Edited 09/03/24: The name label is added.

            Console.WriteLine("Name: Hero");
            Console.WriteLine();

            //Calculate the first stat with "50 * 20 / 100".
            //Concatenate the stat's lable with the outcome.

            Console.WriteLine("Strength: " +
                50 * 20 / 100);

            //Time 50 / 100 with expression of the first stat to get the second stat.
            //Concatenate it with its label.

            Console.WriteLine("Dexterity: " +
                (50 * 20 / 100 *
                 50 / 100));

            //Concatenate the third stat's label with its fix quantity.

            Console.WriteLine("Intelligence: " + 7 );

            //Calculate the fourth stat with expressions of the second and third stat.
            //Concatenate the outcome with the fourth stat's label.

            Console.WriteLine("Health: " + 
                ((50 * 20 / 100 * 50 / 100) +      //2nd stat calculation
                  7 -                              //3rd stat calculation
                  2));                             //minus 2

            //All the rest of the 50 points are for the fifth stat.
            //Concatenate the outcome with its label.

            Console.WriteLine("Charisma: " +
                (50 -                                           //Total points
                    (50 * 20 / 100) -                           //1st stat calculation
                    (50 * 20 / 100 * 50 / 100) -                //2nd stat calculation
                     7 -                                        //3rd stat calculation
                    ((50 * 20 / 100 * 50 /100) + 7 - 2)));      //4th stat calculation

            //Edited 09/03/24: Print the total points after a blank line.
            Console.WriteLine();
            Console.WriteLine("Total: 50");
        }
    }
}
