namespace PE_Data_Types___Variables_XIA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Declare and initialize the player name
            string name = "Remy the Frog";

            //Declare and initialize the constant player starting points
            const double StartingPoint = 50;

            //Declare other player stats
            double strength;
            double dexterity;
            double intelligence;
            double health;
            double charisma;

            //Declare the total points
            double totalPoints;


            //the strength equals 23% of the starting point
            strength = StartingPoint * 0.23;

            //the dexterity equals half of the strength;
            dexterity = strength * 0.5;

            //intelligence equals 7
            intelligence = 7;

            //health is the sum of dexterity and intelligence, minus 2
            health = dexterity + intelligence - 2;

            //charisma is equals the left over points
            charisma = StartingPoint - strength - dexterity - intelligence - health;

            //the total points are sum of all stats
            totalPoints = strength + dexterity + intelligence + health + charisma;


            //Print the name with a blank line
            Console.WriteLine("Name: " + name);
            Console.WriteLine();

            //Print the stats with a blank line at the end
            Console.WriteLine("Strength: " + strength);
            Console.WriteLine("Dexterity: " + dexterity);
            Console.WriteLine("Intelligence: " + intelligence);
            Console.WriteLine("Health: " + health);
            Console.WriteLine("Charisma: " + charisma);
            Console.WriteLine();

            //Print the total points
            Console.WriteLine("TOTAL: " + totalPoints);
        }
    }
}
