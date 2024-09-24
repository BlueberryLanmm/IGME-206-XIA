namespace HW_2_Stats_Analysis_XIA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /**************************************************************************
             * Activity 1: Declare Variables
             **************************************************************************/
            //variables for player 1 stats
            string name1;
            int numberOfPlay1;
            int numberOfWin1;
            int numberOfLost1;
            double totalPlayTime1;

            double winRate1;
            int averagePlayTime1;

            //variables for player 2 stats
            string name2;
            int numberOfPlay2;
            int numberOfWin2;
            int numberOfLost2;
            double totalPlayTime2;

            double winRate2;
            int averagePlayTime2;

            //public variables for validity check
            bool isValid;
            bool isNameEmpty;
            bool isNegative;
            bool isZero;
            bool isSumCorrect;

            /**************************************************************************
             * Activity 2: Collect Base Statistics and Validate Input
             **************************************************************************/
            //print out the program title
            Console.WriteLine("========= STATS ANALYZER =========");

            /***************************
             * Player 1
             ***************************/
            //
            //ask for player 1 stats input
            //
            Console.Write("\nEnter the name for Player 1: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            name1 = Console.ReadLine().Trim();
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Enter the number of games {0} played: ", name1);
            Console.ForegroundColor = ConsoleColor.Blue;
            numberOfPlay1 = int.Parse(Console.ReadLine().Trim());
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Enter the number of game {0} won: ", name1);
            Console.ForegroundColor = ConsoleColor.Blue;
            numberOfWin1 = int.Parse(Console.ReadLine().Trim());
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Enter the number of game {0} lost: ", name1);
            Console.ForegroundColor = ConsoleColor.Blue;
            numberOfLost1 = int.Parse(Console.ReadLine().Trim());
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Enter the total time played by {0} in hours: ", name1);
            Console.ForegroundColor = ConsoleColor.Blue;
            totalPlayTime1 = double.Parse(Console.ReadLine().Trim());
            Console.ForegroundColor = ConsoleColor.White;


            //
            //check for any of the validity errors
            //
            //empty player name
            isNameEmpty = (name1.Length == 0);

            //negative number
            if (numberOfPlay1 < 0)
            {
                isNegative = true;
            }
            else if (totalPlayTime1 < 0)
            {
                isNegative = true;
            }
            else if (numberOfWin1 < 0)
            {
                isNegative = true;
            }
            else if (numberOfLost1 < 0)
            {
                isNegative = true;
            }
            else
            {
                isNegative = false;
            }

            //sum correctness
            isSumCorrect = (numberOfPlay1 == numberOfWin1 + numberOfLost1);

            //zero number
            if (numberOfPlay1 == 0)
            {
                isZero = true;
            }
            else if (totalPlayTime1 == 0)
            {
                isZero = true;
            }
            else
            {
                isZero = false;
            }

            //overall validity
            isValid = !isNameEmpty && !isNegative && !isZero && isSumCorrect;

            //
            //If any, print out error information and stop the program
            //
            //change the foreground color for error printing
            Console.ForegroundColor = ConsoleColor.Red;
            //empty name
            if (isNameEmpty)
            {
                Console.WriteLine("ERROR: Invalid name for player 1.");
            }
            //negative number
            if (isNegative)
            {
                Console.WriteLine("ERROR: Games & total play time must be " +
                    "non-negative numbers!");
            }
            //incorrect sum
            if (!isSumCorrect)
            {
                Console.WriteLine("ERROR: The number of games won and lost " +
                    "does not match the total number of games played!");
            }
            //zero number for play time and games played
            if (isZero)
            {
                Console.WriteLine("ERROR: No stats to calculate for a player " +
                    "with zero games or no play time!!");
            }

            //overall validity
            if (!isValid)
            {
                Console.WriteLine("\nCannot continue with analysis. Goodbye.");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            //Change the forground color back for further printing
            Console.ForegroundColor = ConsoleColor.White;


            /***************************
             * Player 2
             ***************************/
            //
            //ask for player 2 stats input
            //
            Console.Write("\nEnter the name for Player 2: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            name2 = Console.ReadLine().Trim();
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Enter the number of games {0} played: ", name2);
            Console.ForegroundColor = ConsoleColor.Blue;
            numberOfPlay2 = int.Parse(Console.ReadLine().Trim());
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Enter the number of game {0} won: ", name2);
            Console.ForegroundColor = ConsoleColor.Blue;
            numberOfWin2 = int.Parse(Console.ReadLine().Trim());
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Enter the number of game {0} lost: ", name2);
            Console.ForegroundColor = ConsoleColor.Blue;
            numberOfLost2 = int.Parse(Console.ReadLine().Trim());
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("Enter the total time played by {0} in hours: ", name2);
            Console.ForegroundColor = ConsoleColor.Blue;
            totalPlayTime2 = double.Parse(Console.ReadLine().Trim());
            Console.ForegroundColor = ConsoleColor.White;


            //
            //check for any of the validity errors
            //
            //empty player name
            isNameEmpty = (name2.Length == 0);

            //negative number
            if (numberOfPlay2 < 0)
            {
                isNegative = true;
            }
            else if (totalPlayTime2 < 0)
            {
                isNegative = true;
            }
            else if (numberOfWin2 < 0)
            {
                isNegative = true;
            }
            else if (numberOfLost2 < 0)
            {
                isNegative = true;
            }
            else
            {
                isNegative = false;
            }

            //sum correctness
            isSumCorrect = (numberOfPlay2 == numberOfWin2 + numberOfLost2);

            //zero number
            if (numberOfPlay2 == 0)
            {
                isZero = true;
            }
            else if (totalPlayTime2 == 0)
            {
                isZero = true;
            }
            else
            {
                isZero = false;
            }

            //overall validity
            isValid = !isNameEmpty && !isNegative && !isZero && isSumCorrect;

            //
            //If any, print out error information and stop the program
            //
            //change the foreground color for error printing
            Console.ForegroundColor = ConsoleColor.Red;
            //empty name
            if (isNameEmpty)
            {
                Console.WriteLine("ERROR: Invalid name for player 2.");
            }
            //negative number
            if (isNegative)
            {
                Console.WriteLine("ERROR: Games & total play time must be " +
                    "non-negative numbers!");
            }
            //incorrect sum
            if (!isSumCorrect)
            {
                Console.WriteLine("ERROR: The number of games won and lost " +
                    "does not match the total number of games played!");
            }
            //zero number for play time and games played
            if (isZero)
            {
                Console.WriteLine("ERROR: No stats to calculate for a player " +
                    "with zero games or no play time!!");
            }

            //overall validity
            if (!isValid)
            {
                Console.WriteLine("\nCannot continue with analysis. Goodbye.");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            //Change the forground color back for further printing
            Console.ForegroundColor = ConsoleColor.White;


            /**************************************************************************
             * Activity 3: Analyze & Display the Results
             **************************************************************************/
            //calculate average time and win rate
            //player 1
            winRate1 = (double)numberOfWin1 / numberOfPlay1;
            averagePlayTime1 = (int)(totalPlayTime1 / numberOfPlay1 * 60);
            //player 2
            winRate2 = (double)numberOfWin2 / numberOfPlay2;
            averagePlayTime2 = (int)(totalPlayTime2 / numberOfPlay2 * 60);

            //print out the table
            Console.WriteLine("\nSummery Table:");
            //player name
            Console.WriteLine("\t\t\t{0}\t\t{1}",                   name1,              name2);
            //number of games played
            Console.WriteLine("\tGame Played\t{0}\t\t{1}",          numberOfPlay1,      numberOfPlay2);
            //number of games won
            Console.WriteLine("\tGame Won\t{0}\t\t{1}",             numberOfWin1,       numberOfWin2);
            //number of games lost
            Console.WriteLine("\tGame Lost\t{0}\t\t{1}",            numberOfLost1,      numberOfLost2);
            //total game time in hours
            Console.WriteLine("\tTotal Time (h)\t{0:F1}\t\t{1:F1}", totalPlayTime1,     totalPlayTime2);
            //win rate
            Console.WriteLine("\tWin Rate\t{0:P3}\t\t{1:P3}",       winRate1,           winRate2);
            //average game time in minutes
            Console.WriteLine("\tAvg Time (m)\t{0}\t\t{1}",         averagePlayTime1,   averagePlayTime2);

            //compare the 2 players' win rate and print out
            if (winRate1 > winRate2)
            {
                Console.WriteLine("\n{0} has a better win rate!", name1);
            }
            else if (winRate1 < winRate2)
            {
                Console.WriteLine("\n{0} has a better win rate!", name2);
            }
            else
            {
                Console.WriteLine("\nIt's a draw!");
            }

        }
    }
}
