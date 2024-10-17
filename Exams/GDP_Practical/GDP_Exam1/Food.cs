//****************************************************************
// DO NOT modify anything in this file *EXCEPT* where marked
// explicitly with TODO comments!
//****************************************************************
namespace GDP_Exam_1
{
    /// <summary>
    /// Inherits from item and adds data & behavior specific for foods
    /// </summary>
    // TODO: Make this inherit from item
    class Food : Item
    {
        // NO additional fields are permitted.
        private int numServings;
        private double lbsPerServing;

        /// <summary>
        /// The returned weight of a food is:
        ///     number of servings * weight per serving
        /// </summary>
        public override double Weight
        {
            get
            {
                return numServings * lbsPerServing;
            }
        }

        /// <summary>
        /// Initialize a new instance of Food class
        /// inherited from Item class.
        /// </summary>
        /// <param name="name">The name of the food</param>
        /// <param name="numServings">The food's initial number of servings</param>
        /// <param name="lbsPerServing">The food's weight per serving</param>
        public Food(string name, int numServings, double lbsPerServing)
            :base(name) 
        {
            this.numServings = numServings;
            this.lbsPerServing = lbsPerServing;
        }

        /// <summary>
        /// Eats a serving of food
        /// </summary>
        public void Eat()
        {
            //If there are still servings left.
            if(numServings > 0)
            {
                // TODO: Uncomment once Food inherits from item correctly
                Console.WriteLine("Mmmm I ate a serving of " + this.Name);
                numServings--;
            }
            //If there is no left serving.
            else
            {
                // TODO: Uncomment once Food inherits from item correctly
                Console.WriteLine(":( There's no " + Name + " left to eat.");
            }
        }

        /// <summary>
        /// Return a string of this food's info
        /// by adding serving number info to the ToString method of Item class
        /// </summary>
        public override string ToString()
        {
            return base.ToString() + 
                String.Format(" and has {0} servings", numServings);
        }
    }
}
