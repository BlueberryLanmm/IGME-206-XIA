namespace PE_If_Statement_XIA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //declare the variable to store user input
            string userInput;

            //get the user input
            Console.Write("What does your pawn sense? ");
            userInput = Console.ReadLine().ToLower().Trim();

            //decide what action to do
            //check if player is down
            if (userInput == "player down")
            {
                Console.WriteLine("Your pawn runs to you and lifts you up.");
            }
            //check if a treasure chest is found
            else if (userInput == "treasure chest")
            {
                Console.WriteLine("Your pawn says: a treasure chest! How lucky we are!");
            }
            //check if the team just won a battle
            else if (userInput == "battle victory") 
            {
                Console.Write("Who is near your pawn? ");
                userInput = Console.ReadLine().ToLower().Trim();

                //decide the pawn's action according to who is near him.
                if (userInput == "player")
                {
                    Console.WriteLine("Your pawn gives you a high-five!");
                }
                else if (userInput == "another pawn")
                {
                    Console.WriteLine("Your pawn celebrates with another pawn.");
                }
                else
                {
                    Console.WriteLine("Your pawn celebrates alone.");
                }
            }
            //if unexpected information is sensed.
            else
            {
                Console.WriteLine("Your pawn walks to you and stays idle.");
            }
        }
    }
}
