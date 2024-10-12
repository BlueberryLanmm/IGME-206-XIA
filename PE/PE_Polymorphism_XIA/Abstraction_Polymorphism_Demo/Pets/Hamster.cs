using System;

namespace Abstraction_Polymorphism_Demo.Pets
{
    internal class Hamster : Pet
    {
        // The parameterized Hamster constructor just needs to
        // pass the parameters plus it's fixed type to the 
        // parent constructor
        public Hamster(string name, DateTime birthday)
            : base(name, birthday, "hamster")
        {
        }

        // We also want to override Speak so that this Dog can talk!
        public override void Speak()
        {
            Console.WriteLine(this.Name + " says SQUEAKS.");
        }

        // Hamsters sometimes like to run in a roller
        public void RunRoller(int loops)
        {
            for (int i = 0; i < loops; i++)
            {
                Console.Write("PATTERING! ");
            }
            Console.WriteLine();
        }
    }
}
