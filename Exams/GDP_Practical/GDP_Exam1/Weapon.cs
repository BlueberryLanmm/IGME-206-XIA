//****************************************************************
// DO NOT modify anything in this file *EXCEPT* where marked
// explicitly with TODO comments!
//****************************************************************
namespace GDP_Exam_1
{
    /// <summary>
    /// Inherits from item and adds data & behavior specific for weapons
    /// </summary>
    // TODO: Make this inherit from item
    class Weapon
    {
        // NO additional fields or properties are permitted.
        private double weight;
        private int damage;

        /// <summary>
        /// Return how much damage this weapon can do
        /// </summary>
        public int Damage { get { return damage; } }

        /// <summary>
        /// TODO: Add the Item class's required abstract Weight
        /// property.
        /// </summary>

        /// <summary>
        /// TODO: Add a parameterized constructor using the constructor
        /// calls in Main & the writeup as a guide for what this constructor
        /// must do. Leverage the base class constructor as needed.
        /// </summary>

        /// <summary>
        /// TODO: Override ToString to leverage the base class ToString 
        /// and add on the amount of damage this weapon does.
        /// </summary>
    }
}
