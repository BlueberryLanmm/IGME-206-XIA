namespace PE_Statement_Expression_YX
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Print the character's name with WriteLine()

            Console.WriteLine("Hero");

            //Add an extra blank line

            Console.WriteLine();

            //Calculate the first stat by "50 * 20 / 100". Use WriteLine() to print them.

            Console.WriteLine("Strength: " + 50 * 20 / 100);

            //Add a label for the second stat.

            Console.Write("Dexterity: ");

            //Calculate the second stat by calculating "50 * 20 / 100" first,
            //and then times "50 /100" with it.

            Console.WriteLine(
                50 * 20 / 100 *
                50 / 100);

            //Concatenate the third stat's label with its quantity in the WriteLine().

            Console.WriteLine("Intelligence: " + 7);

            //Add a label for the fourth stat.

            Console.Write("Health: ");

            //Calculate the 
        }
    }
}
