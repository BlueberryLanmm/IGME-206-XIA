using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_File_IO_with_Classes_XIA
{
    internal class Player
    {
        private string name;

        private int strength;
        private int health;


        /// <summary>
        /// Constructor. Initialize the player stats with input
        /// </summary>
        /// <param name="name">The player name</param>
        /// <param name="strength">The player strength stat</param>
        /// <param name="health">The player health stat</param>
        public Player(string name, int strength, int health)
        {
            this.name = name;
            this.strength = strength;
            this.health = health;
        }

        /// <summary>
        /// Return the player name
        /// </summary>
        public string Name
        {
            get { return name; }
        }

        /// <summary>
        /// Return the player strength stat
        /// </summary>
        public int Strength
        {
            get { return strength; }
        }

        /// <summary>
        /// Return the player health stat
        /// </summary>
        public int Health
        { 
            get { return health; } 
        }


        /// <summary>
        /// Return all the information of the player in a string.
        /// </summary>
        /// <returns></returns>
        public string ToString()
        {
            return String.Format($"{name}. Strength {strength}. Health {health}.");
        }
    }
}
