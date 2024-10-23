using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6_CritterFarm.CritterTypes
{
    internal class Dog : Critter
    {
        /// <summary>
        /// Constructor. Initialize an instance of Dog class,
        /// inherited from the Critter class.
        /// </summary>
        /// <param name="name">The name of the critter</param>
        /// <param name="hungerLevel">The initial hunger level of the critter</param>
        /// <param name="boredomLevel">The initial boredom level of the critter</param>
        public Dog(string name, int hungerLevel, int boredomLevel)
            : base(name, CritterType.Dog, hungerLevel, boredomLevel)
        {
        }

        /// <summary>
        /// Constructor. Initialize an instance of Dog class, based on the 
        /// constructor with 3 parameters. Create critters with default hunger 
        /// level and boredom level.
        /// </summary>
        /// <param name="name">The name of the critter</param>
        public Dog(string name)
            : this(name, 5, 5)
        {
        }

        /// <summary>
        /// Call to calculate irritation level of this critter, 
        /// then determine its mood.
        /// </summary>
        protected override void UpdateMood()
        {
            //Calculate dog irritation level.
            int irritationLevel = Hunger + Boredom;

            //determine mood with irritation level.
            if (irritationLevel > 25)
            {
                mood = CritterMood.Angry;
            }
            else if (irritationLevel > 15)
            {
                mood = CritterMood.Frustrated;
            }
            else
            {
                mood = CritterMood.Happy;
            }
        }
    }
}
