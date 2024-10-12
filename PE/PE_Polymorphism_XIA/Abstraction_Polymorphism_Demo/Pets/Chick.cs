using System;

namespace Abstraction_Polymorphism_Demo.Pets
{
    internal class Chick : Pet
    {
        // The parameterized Chick constructor just needs to
        // pass the parameters plus it's fixed type to the 
        // parent constructor
        public Chick(string name, DateTime birthday)
            : base(name, birthday, "chick")
        {
        }

        // We also want to override Speak so that this Chick can talk!
        public override void Speak()
        {
            Console.WriteLine(this.Name + " says CHEEP.");
        }
    }
}
