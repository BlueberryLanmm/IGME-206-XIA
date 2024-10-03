using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_Magic_8_Ball_XIA
{
    internal class MagicEightBall
    {
        //Declare variables
        private string owener;
        private int timesShaken;

        private String[] responses;

        private Random rng;

        /// <summary>
        /// Constructor. Initialize the variables.
        /// </summary>
        /// <param name="owner">Input the owner of the ball</param>
        public MagicEightBall(string owner)
        {
            owener = owner;
            timesShaken = 0;

            rng = new Random();

            //Adding responses to the ball
            responses = new String[6];

            responses[0] = "It is certain.";
            responses[1] = "As I see it, yes.";
            responses[2] = "Cannot predict now.";
            responses[3] = "Reply hazy, try again.";
            responses[4] = "Don't count on it.";
            responses[5] = "My reply is no.";
        }

        /// <summary>
        /// Give a random respones and add up to the shaken time.
        /// </summary>
        /// <returns>Returns a random string in array responses</returns>
        public string ShakeBall()
        {
            //Add to times shaken
            timesShaken++;

            //get a random int number ranging from 0 to 6
            return responses[rng.Next(7)];
        }

        /// <summary>
        /// Give out information of how many times the ball has been shaken.
        /// </summary>
        /// <returns>Returns the output string commenting on shaken times</returns>
        public string Report()
        {
            //if shaken more than 4 times
            if (timesShaken >= 4)
            {
                return String.Format(
                    "{0} has shaken the ball {1} times. That's a lot of questions",
                    owener, timesShaken);
            }
            //if shaken 1-3 times
            else if (timesShaken >= 1)
            {
                return String.Format(
                    "{0} has shaken the ball {1} times.",
                    owener, timesShaken);
            }
            //if less than 1 (0 time)
            else
            {
                return String.Format(
                    "{0} has not shaken the ball yet.",
                    owener);
            }
        }
    }
}
