/***
 * YUXUAN XIA
 * 
 * HW 4 - The Arena
 * Write-up: https://docs.google.com/document/d/15Rl0oXwNXdGze8p5HcrZ8n4y78oiubW5pbkJei2YTPI/edit?usp=sharing
 *
 * Primary upgrades:
 *  1. Random Enemy placement
 *  2. Enemy Customization
 *  
 * Optional extra upgrades:
 *  3. Custumize Console Interface
 *  4. Combat Randomness
 *  
 * Known Bugs:
 * No known bugs.
 * 
 * Other notes:
 * 
 */
using System.Reflection.Metadata;

namespace HW4_Arena
{
    /// <summary>
    /// Primary class for the console app. Main() will be run on program launch. Other helper methods are
    /// also defined that Main() will need. It's your job to finish them!
    /// 
    /// Do NOT change anything except where explicitly marked with a TODO comment!
    /// See the comments through this program AND read the assignment write-up for details.
    /// </summary>
    internal class Program
    {
        // *** These constants are defined for you to make your code more readable AND help ensure it works
        //     with the code given to you. Do NOT change these!

        // Constants for the tile types
        private const char Empty = ' ';
        private const char Wall = '#';
        private const char Enemy = 'E';
        private const char Player = '@';
        private const char PlayerStart = '0';
        private const char Exit = '1';

        // Constants for directions
        private const char Up = 'w';
        private const char Down = 's';
        private const char Left = 'a';
        private const char Right = 'd';

        // Player stat indices
        private const int Strength = 0;
        private const int Dexterity = 1;
        private const int Constitution = 2;
        private const int Health = 3;

        // Possible fight outcomes
        private const int Win = 0;
        private const int Lose = 1;
        private const int Run = 2;
        private const int Draw = 3;

        // *** Other constants
        // TODO: It's okay to tweak these numbers a bit to balance your game and/or add new ones.
        // (But don't delete what is here. Main needs some of them!)
        const int EnemySpacing = 6;
        const int MaxPoints = 50;
        const int HealthMult = 5;
        const int DamageMult = 5;
        const int EnemyAttack = 5;
        const int EnemyMaxHealth = 50;

        /// <summary>
        /// DO NOT CHANGE ANY CODE IN MAIN!!!
        /// 
        /// But it's definitely worth reading it to get an understanding of 
        /// how/when your methods will be called.
        /// 
        /// AND it's okay to *temporarily* comment out chunks of code until 
        /// you're ready for them to run to make it easier to test other things.
        /// </summary>
        static void Main(string[] args)
        {
            // ** SETUP **
            // Player's name
            string name;

            // Stats - to make it easier to pass these around between methods, all 4 stats are
            // in a single array with elements in the order [Strength, Dexterity, Constitution, Health]
            // Constants are defined above to help with this.
            int[] stats = new int[4];

            // Define the variable to refer to the final arena
            char[,] arena;

            // Track the player's location as [row, col] (NOT x, y)
            int[] playerLoc = {1, 1};

            // Is the game still running?
            bool stillPlaying = true;

            // How many enemies are left?
            int numEnemies;

            // ** GET PLAYER STATS & BUILD ARENA **
            // Welcome & get stats 
            name = GetPlayerInfo(stats);

            // Build & print the Arena
            arena = BuildArena(out numEnemies);

            // ** GAME LOOP **
            while (stillPlaying)
            {
                // ** PRINT EVERYTHING **

                // Clear the console and then print the arena
                Console.Clear();
                PrintArena(arena, playerLoc);
                Console.WriteLine(
                    $"\n{name}, your stats are: " +
                    $"Strength {stats[Strength]}, " +
                    $"Dexterity {stats[Dexterity]}, " +
                    $"Constitution {stats[Constitution]}, " +
                    $"Health {stats[Health]}");

                // ** DETECT MOVEMENT **

                // Get the desired direction
                char direction = SmartConsole.GetPromptedChoice(
                        $"\n Where would you like to go? {Up}/{Left}/{Down}/{Right} >",
                        new char[] { Up, Left, Down, Right });
                Console.WriteLine();

                // Figure out what is there, but don't move yet
                int[] nextLoc = { playerLoc[0], playerLoc[1] };
                switch (direction)
                {
                    case Up:
                        nextLoc[0]--; // row--
                        break;

                    case Down:
                        nextLoc[0]++; // row++
                        break;

                    case Left:
                        nextLoc[1]--; // col --
                        break;

                    case Right:
                        nextLoc[1]++; // col ++
                        break;
                }

                // ** TAKE ACTION **
                // Act based on what is in the next location (row, col)
                switch(arena[nextLoc[0], nextLoc[1]])
                {
                    // Do nothing. We're stuck.
                    case Wall:
                        Console.WriteLine("\n You can't go there...");
                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                        break;

                    // Move to that spot
                    case Empty:
                        playerLoc = nextLoc;
                        break;

                    // Launch a new fight and determine how to proceed based on the result
                    case Enemy:
                        switch(Fight(stats))
                        {
                            // Take over the enemy's spot if we win
                            case Win:
                                playerLoc = nextLoc;
                                arena[playerLoc[0], playerLoc[1]] = Empty;
                                numEnemies--;
                                break;

                            // A loss or draw is game over
                            case Lose:
                            case Draw:
                                stillPlaying = false;
                                break;

                            // Run back to the start and regain half health
                            case Run:
                                Console.WriteLine("You retreat to the starting area of the arena to heal up.");
                                playerLoc = new int[] { 1, 1 };
                                stats[Health] += (stats[Constitution] * HealthMult)/2;
                                stats[Health] = Math.Clamp(stats[Health], 0, stats[Constitution] * HealthMult); // cap at max health
                                break;
                        }
                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                        break;

                    case Exit:
                        if(numEnemies > 0)
                        {
                            Console.WriteLine("You must defeat all enemies before you can escape.");
                        }
                        else
                        {
                            Console.WriteLine("You made it to the exit! Congratulations!");
                            stillPlaying = false;
                        }
                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                        break;
                }
            }

        }

        /// <summary>
        /// Given a reference to the player's current stats, launch a new fight
        /// </summary>
        /// <param name="stats">A reference to an int[] containing [Strength, Dexterity, Constitution, Health]</param>
        /// <returns>The result of the fight using an int code. See the constants at the top of Program.cs</returns>
        private static int Fight(int[] stats)
        {
            // TODO: Implement the Fight method
            // ~~~~ YOUR CODE STARTS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            //A random number generator for enemy customization and combat randomness
            Random rng = new Random();

            //Customized enemy information
            double[] enemyHealthMult = {0.5, 0.75, 1.0, 1.25, 1.5};
            string[] enemyName = { "Bulbasaur", "Charmander", "Cubone", "Eevee", "Poliwhirl" };

            //An array for a randomized extra damage multiplier
            double[] randDamageMult = { 0.8, 0.9, 1.0, 1.1, 1.2 };
            //Store the actual damage made temporarily
            int realDamage;

            //the current health of encountered enemy
            int enemyHealth = (int)
                (EnemyMaxHealth *
                enemyHealthMult[rng.Next(enemyHealthMult.Length)]);

            //the current enemy
            string currentEnemy = enemyName[rng.Next(enemyName.Length)];


            //Print the alert of entering a conmbat
            Console.WriteLine($"An angry {currentEnemy} attacks you!");

            do
            {
                //Print our the current health of player and enemy
                Console.WriteLine(
                    "Your current health is {0}, the {1}'s health is {2}",
                    stats[Health],
                    currentEnemy,
                    enemyHealth);

                //Prompt the use for action input and check the result
                switch (SmartConsole.GetPromptedInput(
                    "\nWhat would you like to do? Attack/Run >"))
                {
                    case "Attack":
                        //Calculate the real damage dealed by the player
                        realDamage = (int)
                            (stats[Strength] * DamageMult * 
                            randDamageMult[rng.Next(randDamageMult.Length)]);
                        //Print damage information and calculate health points
                        Console.WriteLine("You swing at the {0} doing {1} damage.",
                            currentEnemy,
                            realDamage);
                        enemyHealth -= realDamage;

                        //Check if the enemy's attack misses
                        //If it does not miss
                        if (rng.Next(100) + 1 > stats[Dexterity])
                        {
                            //Calculate the real damage dealed by the enemy
                            realDamage = (int)
                                (EnemyAttack * 
                                randDamageMult[rng.Next(randDamageMult.Length)]);
                            //Print damage information and calculate health points
                            Console.WriteLine("The {0} charges at you for {1} damage!",
                                currentEnemy,
                                realDamage);
                            stats[Health] -= realDamage;
                        }
                        //If it misses
                        else
                        {
                            Console.WriteLine(
                                $"You successfully dodged the {currentEnemy}'s attack!");
                        }

                        break;

                    case "Run":
                        Console.WriteLine("You retreat to the starting area of the arena to heal up.");
                        return Run;

                    //If the player input invalid information
                    default:
                        //Apply the enemy attack calculation in case "Attack",
                        //but do not allow the player to dodge it.

                        //Print the attacked information
                        Console.WriteLine("Command not recognized. Oh no! LOOK OUT!!");

                        //Calculate the real damage dealed by the enemy
                        realDamage = (int)
                            (EnemyAttack *
                            randDamageMult[rng.Next(randDamageMult.Length)]);
                        //Print damage information and calculate health points
                        Console.WriteLine("The {0} charges at you for {1} damage!",
                            currentEnemy,
                            realDamage);
                        stats[Health] -= realDamage;

                        break;
                }
            }
            while (enemyHealth > 0 && stats[Health] > 0);


            //After exiting the loop, check the health point and return the result.
            if (stats[Health] < 0)
            {
                //if the player dies and the enemy dies
                if (enemyHealth < 0)
                {
                    return Draw;
                }
                //if the player dies and the enemy lives
                else
                {
                    return Lose;
                }
            }
            //if the player lives
            else
            {
                return Win;
            }

            // ~~~~ YOUR CODE STOPS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        }


        /// <summary>
        /// Get the player's name & stats. Stats are loaded into the provided array and
        /// the name is returned.
        /// </summary>
        /// <param name="statsArray">A reference int[4] array that this method will put data into</param>
        /// <returns>The player's name</returns>
        private static string GetPlayerInfo(int[] statsArray)
        {
            // TODO: Implement the GetPlayerInfo method
            // ~~~~ YOUR CODE STARTS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            //A string to store name temporarily before returning
            string name;
            //A string array to store names of stats that need attributing points
            string[] statsName = {"Strength", "Dexterity", "Constitution"};

            //Calculate how many points are left
            int leftPoints = MaxPoints;

            //Print the welcom info and prompt name input
            name = SmartConsole.GetPromptedInput("Welcome, please enter your name: >");

            //Prompt stats input
            Console.WriteLine(
                $"\nHello {name}, I'll need a bit more information from you before we can start.");
            Console.WriteLine(
                $"You have {MaxPoints} points to build your character and three attributes to allocate them to.");

            for (int i = 0; i < statsName.Length; i++)
            {
                //Use GetValidIntergerInput to prompt stat input.
                //The max value is calculated by leftPoints minus number of left stats,
                //to make sure every left stat has a minimum 1 point.
                statsArray[i] = SmartConsole.GetValidIntegerInput(
                        $"\nHow many points would you like to allocate to {statsName[i]}? >",
                        1,
                        leftPoints - statsName.Length + (i + 1));

                //calculate current left points
                leftPoints -= statsArray[i];

                //Print information of left points
                if (i == Constitution)
                {
                    Console.WriteLine($"You left {leftPoints} points unused.\n");
                }
                else
                {
                    Console.WriteLine($"You have {leftPoints} points remaining.");
                }
            }

            statsArray[Health] = statsArray[Constitution] * HealthMult;

            return name;

            // ~~~~ YOUR CODE STOPS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        }


        /// <summary>
        /// Given a reference to a 2d array variable (that will be null to start):
        /// - Prompt for the desired size and initialize the array
        /// - Put walls along all borders
        /// - Evenly space enemies every few tiles (vert & hor)
        /// - Put empty cells everywhere else
        /// - Place the player start in the top left
        /// - Place an exit in the bottom right
        /// </summary>
        /// <param name="numEnemies">An out param to store the total number of enemies created</param>
        /// <returns>A reference to the final 2d arena</returns>
        private static char[,] BuildArena(out int numEnemies)
        {
            // Start by setting numEnemies to 0. Increment this whenever you create
            // an enemy and the out param will work just fine. :)
            numEnemies = 0;

            // TODO: Implement the BuildArena method
            // ~~~~ YOUR CODE STARTS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            //Store the width and height temporarily
            int width;
            int height;

            //Store userInput temporarily
            string userInput;

            //The arena to return
            char[,] arena;

            //Mark if the enemy positions are random
            bool isRandom;

            //Random number generator for randomly placed enemies.
            Random rng = new Random();


            //Prompt for valid width and height input
            width = SmartConsole.GetValidIntegerInput(
                "How wide should the arena be? (Enter a value from 10 to 50) >",
                10, 50);
            height = SmartConsole.GetValidIntegerInput(
                "How tall should the arena be? (Enter a value from 10 to 50) >",
                10, 50);

            
            //Ask the user if they would like randomly placed enemies
            do
            {
                userInput = SmartConsole.GetPromptedInput(
                    "\nDo you want the enemies to be randomly placed? <y>/<n>? >");

                //If yes, generate a random enemy number and break the loop
                if (userInput == "y")
                {
                    isRandom = true;
                    numEnemies = rng.Next(1, 11);
                    break;
                }
                //If no, break the loop
                else if (userInput == "n")
                {
                    isRandom = false;
                    break;
                }
                //Prompt again if input is invalid
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }
            while (true);


            //Prompt for customizing the arena's color
            do
            {
                userInput = SmartConsole.GetPromptedInput(
                    "\nWhat color is the arena? " +
                    "\n\t[Y]ellow " +
                    "\n\t[R]ed" +
                    "\n\t[G]reen" +
                    "\n\t[B]lue" +
                    "\n\t[D]efault" +
                    "\n >").
                    ToLower();

                switch (userInput)
                {
                    case "y":
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        break;
                    case "r":
                        Console.BackgroundColor = ConsoleColor.Red;
                        break;
                    case "g":
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        break;
                    case "b":
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        break;
                    case "d":
                        break;
                    default:
                        Console.WriteLine("That's not a choice. Choose again!");
                        break;
                }
            }
            while (
            userInput != "y" &&
            userInput != "r" &&
            userInput != "b" &&
            userInput != "g" &&
            userInput != "d");


            //Initialize the arena
            arena = new char[height, width];

            //Determine character in every position
            for (int i = 0; i < arena.GetLength(0); i++)
            {
                for (int j = 0; j < arena.GetLength(1); j++)
                {
                    //Wall
                    if (i == 0 || i == arena.GetLength(0) - 1 ||
                        j == 0 || j == arena.GetLength(1) - 1)
                    {
                        arena[i, j] = Wall;
                    }
                    //Player start
                    else if(i == 1 && j == 1)
                    {
                        arena[i, j] = PlayerStart;
                    }
                    //Exit
                    else if(
                        i == arena.GetLength(0) - 2 && 
                        j == arena.GetLength(1) - 2)
                    {
                        arena[i, j] = Exit;
                    }
                    //Evenly placed enemy
                    else if( 
                        isRandom == false && 
                        i != 0 && i % EnemySpacing == 0 &&
                        j != 0 && j % EnemySpacing == 0)
                    {
                        arena[i, j] = Enemy;
                        numEnemies++;
                    }
                    //Empty
                    else
                    {
                        arena[i, j] = Empty;
                    }
                }
            }

            //If enemies positons are random,
            //replace some empty space with enemies.
            if (isRandom == true)
            {
                for (int i = 0; i < numEnemies; i++)
                {
                    //randomize a position
                    int column = rng.Next(width);
                    int row = rng.Next(height);

                    //If it's empty, replace it
                    if (arena[row, column] == Empty)
                    {
                        arena[row, column] = Enemy;
                    }
                    //If it's not, reduce the count
                    else
                    {
                        i--;
                    }
                }
            }

            // ~~~~ YOUR CODE STOPS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            // All done
            return arena;
        }

        /// <summary>
        /// Given a reference to a 2d arena and the player's current location, 
        /// print every character using the correct colors.
        /// </summary>
        /// <param name="arena">A reference to the arena to print. This could be ANY size.</param>
        /// <param name="playerLoc">The player's location in a 1d array with element [row, col]</param>
        private static void PrintArena(char[,] arena, int[] playerLoc)
        {
            // TODO: Implement the PrintArena method
            // ~~~~ YOUR CODE STARTS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            for (int i = 0; i < arena.GetLength(0); i++)
            {
                for (int j = 0; j < arena.GetLength(1); j++)
                {
                    //If it's player, print the player
                    if (playerLoc[0] == i && playerLoc[1] == j)
                    {
                        Console.Write(Player);
                    }
                    //If it's not, change color according to the character
                    else
                    {
                        switch (arena[i, j])
                        {
                            case Wall:
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(arena[i,j]);
                                Console.ForegroundColor = ConsoleColor.White;
                                break;

                            case PlayerStart:
                            case Exit:
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write(arena[i,j]);
                                Console.ForegroundColor = ConsoleColor.White; 
                                break;

                            case Enemy:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(arena[i,j]);
                                Console.ForegroundColor = ConsoleColor.White;
                                break;

                            default:
                                Console.Write(arena[i, j]);
                                break;
                        }
                    }
                }

                //Change to a new line at line ends.
                Console.WriteLine();
            }

            // ~~~~ YOUR CODE STOPS HERE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        }
    }
}