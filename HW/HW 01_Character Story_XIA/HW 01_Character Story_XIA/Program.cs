namespace HW_01_Character_Story_XIA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Declaring all the variables
            //2 constant number: max stamina, stamina cost per fish
            const int MaxStamina = 100;
            const int StaminaCostPerFish = 40;
            //The following variables to record character state
            string characterName = "Arthur";
            int currentStamina = MaxStamina;
            int fishTimes = 0;
            double fishOutcome = 0;

            int finalRemainStamina;
            int totalFishTimes;



            //Print the introduction
            Console.WriteLine("==== Welcome to the Fishing Master ====");
            Console.WriteLine();    //Add a blank line
            Console.WriteLine("=== Introduction ===");
            Console.Write("It's a sunny fishing day. ");
            Console.WriteLine("The rookie fisherman " + characterName + " plans to go fishing today!");
            Console.WriteLine();    //Add a blank line

            //Print the character's initial stats
            Console.WriteLine("--- Character Stats ---");
            Console.WriteLine("Max Stamina: " + MaxStamina);
            Console.WriteLine("Current Stamina: " + currentStamina);
            Console.WriteLine("Fishing times: " + fishTimes);
            Console.WriteLine("Fishing outcome: " + fishOutcome);
            Console.WriteLine();    //Add a blank line



            //The action process
            Console.WriteLine("=== Fishing Time! ===");

            //calculate the total fish times and the final remaining stamina
            totalFishTimes = MaxStamina / StaminaCostPerFish;
            finalRemainStamina = MaxStamina % StaminaCostPerFish;
            //print the calculation
            Console.Write(characterName + " plans to use all the stamina for fishing. ");
            Console.WriteLine("He can fish " + totalFishTimes + " times today, remaining stamina: " + finalRemainStamina);
            Console.WriteLine();    //Add a blank line

            //the character catches a 1.5 lbs fish in his first fishing
            Console.WriteLine("First try:");
            Console.WriteLine(characterName + " costs " + StaminaCostPerFish + " stamina and catches a " + 1.5 + " lbs fish! ");
            //calculate and print the stats changes for the first fishing
            fishTimes += 1;
            currentStamina -= StaminaCostPerFish;
            fishOutcome += 1.5;
            Console.Write("He has fished " + fishTimes + " time today. ");
            Console.WriteLine("His remaining stamina is " + currentStamina + ".");
            Console.WriteLine();    //Add a blank line

            //the character catches a 2.8 lbs fish in his second fishing
            Console.WriteLine("Seconde try:");
            Console.WriteLine(characterName + " costs " + StaminaCostPerFish + " stamina and catches a " + 2.8 + " lbs fish!! ");
            //calculate and print the stats changes for the first fishing
            fishTimes = fishTimes + 1;
            currentStamina = currentStamina - StaminaCostPerFish;
            fishOutcome = fishOutcome + 2.8;
            Console.Write("He has fished " + fishTimes + " times today. ");
            Console.WriteLine("His remaining stamina is " + currentStamina + ".");
            Console.WriteLine("There is not enough stamina for more fishing.");
            Console.WriteLine();    //Add a blank line



            //Print the conclusion
            Console.WriteLine("=== Conclusion ===");
            Console.Write(characterName + " spent the whole day fishing and had a fruitful outcome. ");
            Console.WriteLine("He is one step closer to his fishing master dream!");
            Console.WriteLine();    //Add a blank line

            //Print the final character stats
            Console.WriteLine("--- Final Character Stats ---");
            Console.WriteLine("Max Stamina: " + MaxStamina);
            Console.WriteLine("Current Stamina: " + currentStamina);
            Console.WriteLine("Fishing times: " + fishTimes);
            Console.WriteLine("Fishing outcome: " + fishOutcome);
            Console.WriteLine();    //Add a blank line
        }
    }
}
