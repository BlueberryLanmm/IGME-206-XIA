//****************************************************************
// DO NOT modify anything in this file *EXCEPT* where marked
// explicitly with TODO comments!
//****************************************************************
namespace GDP_Exam_1
{
    /// <summary>
    /// A standalone class to hold Item object instances
    /// </summary>
    class Inventory
    {
        // NO additional fields are permitted.
        private List<Item> items = new List<Item>();

        /// <summary>
        /// Return the number of items within the
        /// inventory's list. Nothing can be changed.
        /// </summary>
        public int NumberItems
        {
            // TODO: Complete the property
            get 
            {
                return 0; // REPLACE
            }
        }

        /// <summary>
        /// TODO: Complete the AddItem method to add a provided Item reference
        /// into the inventory list
        /// </summary>
        public void AddItem(Item itemToAdd)
        {
        }

        /// <summary>
        /// TODO: Complete the PrintSummary method to print the number of items
        /// in the inventory and then a summary of each item.
        /// </summary>
        public void PrintSummary()
        {
        }


        /// <summary>
        /// TODO: Complete the CalculateTotalWeight method to return the total
        /// weight of all items in the inventory
        /// </summary>
        private double CalculateTotalWeight()
        {
            double total = 0;
            return total;
        }

        /// <summary>
        /// TODO: Complete CalculateTotalWeight method to return the total
        /// damage of all weapons in the inventory
        /// </summary>
        private double CalculateTotalDamage()
        {
            double total = 0;
            return total;
        }

        /// <summary>
        /// Loads items from a file line by line
        /// </summary>
        public void LoadItems(string filename)
        {
            StreamReader input = null;

            // TODO: Add exception handling
                input = new StreamReader(filename);
                string line = null;
                while((line = input.ReadLine()) != null)
                {
                    // TODO: For each line, seperate the data and create
                    // new Food or Weapon objects appropriately
                }
            if (input != null)
            {
                input.Close();
            }
        }
    }
}
