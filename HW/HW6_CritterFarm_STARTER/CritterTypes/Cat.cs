using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6_CritterFarm.CritterTypes
{
    internal class Cat : Critter
    {
        /// <summary>
        /// Constructor. Initialize an instance of Cat class,
        /// inherited from the Critter class.
        /// </summary>
        /// <param name="name">The name of the critter</param>
        /// <param name="hungerLevel">The initial hunger level of the critter</param>
        /// <param name="boredomLevel">The initial boredom level of the critter</param>
        public Cat(string name, int hungerLevel, int boredomLevel)
            :base(name, CritterType.Cat, hungerLevel, boredomLevel)
        {
        }

        /// <summary>
        /// Constructor. Initialize an instance of Cat class, based on the 
        /// constructor with 3 parameters. Create critters with default hunger 
        /// level and boredom level.
        /// </summary>
        /// <param name="name">The name of the critter</param>
        public Cat(string name)
            :this(name, 2, 0)
        {
        }

        /// <summary>
        /// Call to calculate irritation level of this critter, 
        /// then determine its mood.
        /// </summary>
        protected override void UpdateMood()
        {
            //Calculate cat irritation level.
            int irritationLevel = Hunger + 2 * Boredom;

            //determine mood with irritation level.
            if (irritationLevel > 25)
            {
                mood = CritterMood.Angry;
            }
            else
            {
                mood = CritterMood.Happy;
            }
        }

        /// <summary>
        /// Call to do special actions of this critter.
        /// </summary>
        public void CauseMischief()
        {
            this.Boredom -= 10;
            this.UpdateMood();

            Console.WriteLine("{0} also gets joy out of randomly causing trouble!",
                name);
        }
    }
}
