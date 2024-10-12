using System;

namespace Abstraction_Polymorphism_Demo.Shapes
{
    /// <summary>
    /// Rectangles with length and width
    /// </summary>
    internal class Rectangle : Shape
    {
        //A rectangle needs length and width
        private double length;
        private double width;

        // Create a new rectangle using the base constructor to save the type
        public Rectangle(double length, double width) : base("rectangle")
        {
            this.length = length;
            this.width = width;
        }

        //Implement CalculateArea for the rectangle
        public override double CalculateArea()
        {
            return length * width;
        }

        //Implement the Area property
        public override double Area
        {
            get
            {
                return length * width;
            }
        }
    }
}
