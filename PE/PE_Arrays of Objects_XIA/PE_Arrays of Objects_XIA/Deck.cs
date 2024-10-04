using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_Arrays_of_Objects_XIA
{
    internal class Deck
    {
        //Declare fields
        private Random rng;
        private Card[] cards;

        private string[] suits;

        /// <summary>
        /// Constructor
        /// </summary>
        public Deck()
        {
            rng = new Random();
            cards = new Card[52];

            suits = new string[4];

            suits[0] = "Hearts";
            suits[1] = "Spades";
            suits[2] = "Dianmonds";
            suits[3] = "Clubs";

            //Use nested loop to give value and suit for each card
            //Loop through suits first, then values.
            for (int i = 0; i < suits.Length; i++)
            {
                for (int j = 0; j < 13; j++)
                {                    
                    cards[i * 13 + j] = new Card(j + 1, suits[i]);
                }
            }
        }

        /// <summary>
        /// Print out all cards in the deck with a title
        /// </summary>
        public void Print()
        {
            Console.WriteLine("Your deck:");

            for (int i = 0; i < cards.Length; i++)
            {
                Console.Write(" - ");
                cards[i].Print();
                //Add a blank line after printing every card
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Print out specific amount of random cards
        /// </summary>
        /// <param name="amount">the number of cards to pick</param>
        public void Deal (int amount)
        {
            Console.WriteLine("\nYour hand:");

            for (int i = 0; i < amount; i++)
            {
                Console.Write(" - ");
                cards[rng.Next(0, cards.Length)].Print();
                //Add ablank line after printing every card
                Console.WriteLine();
            }
        }

    }
}
