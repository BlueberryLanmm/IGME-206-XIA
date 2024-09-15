namespace PE_String_Formatting_XIA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //declare the const template for player's stats update.
            const string StatsUpdateTemplate = "{0}, you now have {1} health and {2:C} remaining.";

            //declare the stats variables
            string name;
            string title;
            string nameWithTitle;
            int health;
            double wallet;
            //declare the action variables
            string playerAction;
            int actionHealthReq;
            string item;
            double itemCost;



            //Player input & greeting
            //get the player's name, title and wallet balance
            Console.Write("What is your name brave adventurer? ");
            name = Console.ReadLine();
            Console.Write("What is your title? ");
            title = Console.ReadLine();
            Console.Write("How much money are you carrying? $");
            wallet = double.Parse(Console.ReadLine());

            //combine the player's name and title
            nameWithTitle = String.Format("{0} the {1}", name, title);

            //print the greeting information
            Console.WriteLine("Welcome {0}!", nameWithTitle);



            //The player's action
            //Ask about the player's action and the health required for it
            Console.Write("\nWhat do you want to do next? ");
            playerAction = Console.ReadLine();
            Console.Write("How much health does it take to do this? ");
            actionHealthReq = int.Parse(Console.ReadLine());

            //confirm the action and print out the adjusted health point
            Console.WriteLine("\nOkay, let's see you {0}!", playerAction);
            health = 100 - actionHealthReq;
            Console.WriteLine(StatsUpdateTemplate, nameWithTitle, health, wallet);



            //The player buys something
            //Ask about items the player want to buy and its cost
            Console.Write("\nWhat do you want to buy? ");
            item = Console.ReadLine();
            Console.Write("How much does it normally cost? $");
            itemCost = double.Parse(Console.ReadLine());

            //confirm the buying, calculate the actual cost
            Console.WriteLine("\nYou bought {0} for {1:C}!", item, itemCost * 1.1);
            //calculate and print out the remaining balance
            wallet -= itemCost * 1.1;
            Console.WriteLine(StatsUpdateTemplate, nameWithTitle, health, wallet);
        }
    }
}
