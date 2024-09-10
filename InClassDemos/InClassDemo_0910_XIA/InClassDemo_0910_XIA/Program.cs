namespace InClassDemo_0910_XIA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Quick output (and testing special characters)
            Console.WriteLine("Testing string\n");

            //Testing string methods
            Console.Write("Enter a name: ");
            String name = Console.ReadLine();
            name.ToUpper();
            Console.WriteLine(name);
            Console.WriteLine("Lenght is " + name.Length);

            //overwrite the name with the newly uppercase version
            name = name.ToUpper();
            Console.WriteLine("The uppercase name is written as: " + name);

            //Try to access specific character by index
            Console.WriteLine("The first letter of " + name + " is " + name[0]);
            //Use Substring method to access more than one at once
            Console.WriteLine("The first 2 letters of " + name + " are " + name.Substring(0, 2));
            Console.WriteLine("The last 3 letters of " + name + " are " + name.Substring(name.Length - 3));

            name = name.PadLeft(4, '@');
            Console.WriteLine("The changed name is: " + name );

        }
    }
}
