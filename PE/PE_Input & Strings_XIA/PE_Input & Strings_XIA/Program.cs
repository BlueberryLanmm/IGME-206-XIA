namespace PE_Input___Strings_XIA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Declare strings needed.
            string userName;
            string favoriteColor;
            string petName;
            string favoriteBand;

            //Ask the user's name and print a welcome
            Console.Write("What is your name? ");
            userName = Console.ReadLine().Trim();
            Console.WriteLine("Welcome " +  userName + "!");

            //Ask the user's information
            Console.Write("\nWhat is your favorite color? ");
            favoriteColor = Console.ReadLine().Trim();
            Console.Write("What is your pet's name? ");
            petName = Console.ReadLine().Trim();
            Console.Write("What is your favorite band? ");
            favoriteBand = Console.ReadLine().Trim();

            //Print the length of the user's name
            Console.WriteLine("\nYour name is " + userName.Length + " letters long.");

            //comparing the length of the user's name with the pet's name
            Console.WriteLine("\nIt's " + 
                (userName.Length - petName.Length) + 
                " letters longer than " + petName + "'s name.");

            //make a statement including some of the user's input above
            Console.WriteLine("\nI wonder if " + petName.ToUpper() +
                " and " + favoriteBand.ToUpper() +
                " like " + favoriteColor.ToUpper() + " as much as you do.");

            //print a made-up name combining the user's input above
            Console.WriteLine("\nMaybe I should just call you " +
                userName.ToUpper()[0] +
                favoriteColor.ToLower().Substring(0, 2) +
                petName.ToLower().Substring(0, 2) +
                favoriteBand.ToLower().Substring(0, 2) + "?");
        }
    }
}
