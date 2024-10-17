using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_5_The_Farmstead
{
    internal class Crop
    {
        private string name;
        private double cost;
        private int growthTime;
        private int daysLeft;

        /// <summary>
        /// Initializes a new instance of a Crop class
        /// </summary>
        /// <param name="name">The crop name.</param>
        /// <param name="cost">The cost of the crop.</param>
        /// <param name="growthTime">The growth time of the crop.</param>
        public Crop(string name, double cost, int growthTime)
        {
            this.name = name;
            this.cost = cost;
            this.growthTime = growthTime;

            daysLeft = growthTime;
        }

        /// <summary>
        /// Initializes a new instance of the Crop class as a copy of another crop.
        /// </summary>
        /// <param name="other">The crop to copy.</param>
        public Crop(Crop other)
            : this(other.name, other.cost, other.growthTime)
        {
        }

        /// <summary>
        /// Return the crop name.
        /// </summary>
        public string Name
        {
            get { return name; }
        }

        /// <summary>
        /// Return the crop cost.
        /// </summary>
        public double Cost
        {
            get { return cost; }
        }

        /// <summary>
        /// Return the total growth time of the crop.
        /// </summary>
        public int GrowthTime
        {
            get { return growthTime; }
        }

        /// <summary>
        /// Return number of days left before harvest.
        /// </summary>
        public int DaysLeft
        { 
            get { return daysLeft; } 
        }

        /// <summary>
        /// Return the selling price.
        /// </summary>
        public double SellingPrice
        { 
            get { return cost * growthTime; } 
        }

        /// <summary>
        /// Return a bool indicatin if the crop is ready for harvest.
        /// </summary>
        public bool CanHarvest
        { 
            get { return (daysLeft <= 0); } 
        }


        /// <summary>
        /// Decrements the days left.
        /// </summary>
        public void DayPassed()
        {
            this.daysLeft -= 1;
        }

        /// <summary>
        /// Returns a string describing the crop status.
        /// </summary>
        /// <returns>The crop status.</returns>
        public override string ToString()
        {
            //Print the sell price if ready for harvest
            if (this.CanHarvest)
            {
                return String.Format("{0} ready to harvest for {1:C2}",
                    Name, SellingPrice);
            }
            //Print the days left if not ready for harvest
            else
            {
                return String.Format("{0} has {1} days left to harvest",
                    Name, DaysLeft);
            }
        }
    }
}
