using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6_CritterFarm.CritterTypes
{
    internal class Horse : Critter
    {
        /// <summary>
        /// Constructor. Initialize an instance of Horse class,
        /// inherited from the Critter class.
        /// </summary>
        /// <param name="name">The name of the critter</param>
        /// <param name="hungerLevel">The initial hunger level of the critter</param>
        /// <param name="boredomLevel">The initial boredom level of the critter</param>
        public Horse(string name, int hungerLevel, int boredomLevel)
            : base(name, CritterType.Horse, hungerLevel, boredomLevel)
        {
        }

        /// <summary>
        /// Constructor. Initialize an instance of Horse class, based on the 
        /// constructor with 3 parameters. Create critters with default hunger 
        /// level and boredom level.
        /// </summary>
        /// <param name="name">The name of the critter</param>
        public Horse(string name)
            : this(name, 0, 0)
        {
        }

        /// <summary>
        /// Call to calculate irritation level of this critter, 
        /// then determine its mood.
        /// </summary>
        protected override void UpdateMood()
        {
            //Calculate horse irritation level.
            int irritationLevel = 2 * Hunger + Boredom;

            //determine mood with irritation level.
            if (irritationLevel > GenAngryLvl)
            {
                mood = CritterMood.Angry;
            }
            else if (irritationLevel > GenFrustrationLvl)
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
