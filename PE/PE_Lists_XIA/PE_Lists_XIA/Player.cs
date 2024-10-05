using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_Lists_XIA
{
    internal class Player
    {
        private string name;
        private List<String> inventory;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Player name</param>
        public Player(string name)
        {
            this.name = name;
            inventory = new List<String>();
        }

        /// <summary>
        /// Return the name of the player
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
        }

        /// <summary>
        /// Add item to inventory list, and print a message
        /// </summary>
        /// <param name="item">The item added</param>
        public void AddToInventory(String item)
        {
            inventory.Add(item);
            Console.WriteLine("Item '{0}' added to {1}'s inventory.", item, name);
        }


        /// <summary>
        /// Remove the item of a specific index,
        /// then return its name.
        /// </summary>
        /// <param name="index">Index of an item</param>
        /// <returns>Return the name of the item</returns>
        public String GetItemInSlot(int index)
        {
            string removedItem;

            if (index >= 0 &&  index < inventory.Count)
            {
                removedItem = inventory[index];
                inventory.RemoveAt(index);

                Console.WriteLine("{0} stolen from slot {1} in {2}'s inventory!", 
                    removedItem, index, name);
                return removedItem;
            }
            else
            {
                Console.WriteLine("{0} was not a valid item #!", index);
                return null;
            }
        }


        /// <summary>
        /// Print the players total inventory
        /// </summary>
        public void PrintInventory()
        {
            //Print a headline
            Console.WriteLine("\n{0}'s Inventory:", name);

            for (int i = 0; i < inventory.Count; i++)
            {
                Console.WriteLine(" - {0}", inventory[i]);
            }
        }
    }
}
