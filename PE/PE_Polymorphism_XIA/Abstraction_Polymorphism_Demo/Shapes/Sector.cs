using System;

namespace Abstraction_Polymorphism_Demo.Shapes
{
    /// <summary>
    /// Sectors are determined by radius and angle
    /// </summary>
    internal class Sector : Shape
    {
        //Sectors need a radius and an angle (in radian)
        private double radius;
        private double radian;

        // Create a new sector using the base constructor to save the type
        public Sector(double radius, double degree) : base("sector")
        {
            this.radius = radius;
            radian = Math.PI * degree / 180;
        }

        // Implement CalculateArea for a sector
        public override double CalculateArea()
        {
            return 0.5 * radian * radius * radius;
        }

        // Implement the Area property
        public override double Area
        {
            get
            {
                return 0.5 * radian * radius * radius;
            }
        }
    }
}
