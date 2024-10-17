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
    class Food
    {
        // NO additional fields are permitted.
        private int numServings;
        private double lbsPerServing;

        /// <summary>
        /// TODO: Override the Item class's required abstract Weight
        /// property. The returned weight of a food is:
        ///     number of servings * weight per serving
        /// </summary>

        /// <summary>
        /// TODO: Add a parameterized constructor using the constructor
        /// calls in Main & the writeup as a guide for what this constructor
        /// must do. Leverage the base class constructor as needed.
        /// </summary>

        /// <summary>
        /// Eats a serving of food
        /// </summary>
        public void Eat()
        {
            if(numServings > 0)
            {
                // TODO: Uncomment once Food inherits from item correctly
                //Console.WriteLine("Mmmm I ate a serving of " + this.Name);
                numServings--;
            }
            else
            {
                // TODO: Uncomment once Food inherits from item correctly
                //Console.WriteLine(":( There's no " + Name + " left to eat.");
            }
        }

        /// <summary>
        /// TODO: Override ToString to leverage the base class ToString 
        /// and add on the amount of damage this weapon does.
        /// </summary>

    }
}
