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
                return items.Count;
            }
        }

        /// <summary>
        /// Add a provided Item reference into the inventory list
        /// </summary>
        public void AddItem(Item itemToAdd)
        {
            items.Add(itemToAdd);
        }

        /// <summary>
        /// Print the number of items in the inventory and then a summary of each item.
        /// </summary>
        public void PrintSummary()
        {
            //Print out the total item number.
            Console.WriteLine("The inventory currently has {0} item(s):", NumberItems);

            //Use a foreach loop to print out item lists.
            foreach (Item item in items)
            {
                Console.WriteLine("\t" + item.ToString());
            }

            //Print out the total weight and damage of items in inventory.
            Console.WriteLine("Totao weight: {0}",
                CalculateTotalWeight());
            Console.WriteLine("Total damage from weapon(s): {0}",
                CalculateTotalDamage());
        }


        /// <summary>
        /// Return the total weight of all items in the inventory
        /// </summary>
        private double CalculateTotalWeight()
        {
            double total = 0;

            //Use a foreach loop to add up weight of 
            //all items in the inventory.
            foreach (Item item in items)
            {
                total += item.Weight;
            }

            return total;
        }

        /// <summary>
        /// Return the total damage of all weapons in the inventory
        /// </summary>
        private double CalculateTotalDamage()
        {
            double total = 0;

            //Use a foreach loop to add up damage of 
            //all weapons in the inventory
            foreach (Item item in items)
            {
                //Check if an item is a weapon.
                //Cast it to a Weapon type if it is.
                if (item is Weapon)
                    total += ((Weapon)item).Damage;
            }

            return total;
        }

        /// <summary>
        /// Loads items from a file line by line
        /// </summary>
        public void LoadItems(string filename)
        {
            StreamReader input = null;

            // TODO: Add exception handling
            try
            {
                input = new StreamReader(filename);
                string line = null;
                while ((line = input.ReadLine()) != null)
                {
                    // TODO: For each line, seperate the data and create
                    // new Food or Weapon objects appropriately

                    //Declare a string array to store the data temporarily.
                    string[] data = line.Split('~');

                    //Use a switch statement to check the item type
                    switch (data[0].ToLower())
                    {
                        //If it is a food
                        case "food":
                            this.AddItem(
                                new Food(data[1], int.Parse(data[2]), double.Parse(data[3])));
                            break;

                        //If it is a weapon
                        case "weapon":
                            this.AddItem(
                                new Weapon(data[1], int.Parse(data[2]), double.Parse(data[3])));
                            break;
                    }
                }
            }
            //Print out the exception information when it occurs
            catch (Exception e)
            {
                Console.WriteLine("Uh oh: " + e.Message);
            }

            //If the streamReader file is opened correctly,
            //close it after using.
            if (input != null)
            {
                input.Close();
            }
        }
    }
}
