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
    class Weapon : Item
    {
        // NO additional fields or properties are permitted.
        private double weight;
        private int damage;

        /// <summary>
        /// Return how much damage this weapon can do
        /// </summary>
        public int Damage { get { return damage; } }

        /// <summary>
        /// Return the weight of this weapon
        /// </summary>
        public override double Weight
        {
            get { return weight; }
        }

        /// <summary>
        /// Initializing a new instance of Weapon class
        /// inherent from the Item class.
        /// </summary>
        /// <param name="name">The name of this weapon</param>
        /// <param name="damage">The damage this weapon can do</param>
        /// <param name="weight">The weight of this weapon</param>
        public Weapon (string name, int damage, double weight)
            : base (name)
        {
            this.weight = weight;
            this.damage = damage;
        }

        /// <summary>
        /// Return a string of this weapon's info
        /// by adding damage info to the ToString method of Item class
        /// </summary>
        public override string ToString()
        {
            return base.ToString() + String.Format(", {0} damage", damage);
        }
    }
}
