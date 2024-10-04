using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_Arrays_of_Objects_XIA
{
    internal class Card
    {
        private int value;
        private string suit;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value">The value of the card</param>
        /// <param name="suit">The suit of the card</param>
        public Card(int value, string suit)
        {
            this.value = value;
            this.suit = suit;
        }

        /// <summary>
        /// Print a card name with its value and suit
        /// </summary>
        public void Print()
        {
            switch (value)
            {
                //Print specific info when value is 1/11/12/13
                case 1:
                    Console.Write("Ace");
                    break;

                case 11:
                    Console.Write("Jack");
                    break;

                case 12:
                    Console.Write("Queen");
                    break;

                case 13:
                    Console.Write("King");
                    break;

                //Print the exact value by default
                default:
                    Console.Write(value);
                    break;
            }

            //Print the suit after the value
            Console.Write(" of {0}", suit);
        }
    }
}
