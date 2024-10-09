using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_File_IO_with_Classes_XIA
{
    internal class PlayerManager
    {
        private string filename = "../../../players.txt";

        private List<Player> players = new List<Player>();

        /// <summary>
        /// Constructor
        /// </summary>
        public PlayerManager()
        {

        }

        /// <summary>
        /// Create a new player with input info. Add the player
        /// to the players list, then print out a text info.
        /// </summary>
        /// <param name="name">New player name</param>
        /// <param name="strength">New player strength</param>
        /// <param name="health">New player health</param>
        public void CreatePlayer(string name, int strength, int health)
        {
            players.Add(new Player(name, strength, health));
            Console.WriteLine($"Added {name} to the list.");
        }

        /// <summary>
        /// Load player data from ../../../players.txt file.
        /// </summary>
        public void Load()
        {
            //String variable to store the file info
            string line;

            //Store an array of data after using split method
            string[] data;

            //Clear the players list
            players.Clear();

            //Create a stream reader for file reading
            StreamReader reader = null;

            try
            {
                //Load file from ../../../players.txt file
                reader = new StreamReader(filename);

                //If the last line of the text file is not reached
                while ((line = reader.ReadLine()) != null)
                {
                    //Split the string into data
                    data = line.Split(',');
                    //Create a player with the data
                    CreatePlayer(data[0], int.Parse(data[1]), int.Parse(data[2]));
                }
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }

            //If the file is load succesfully, close it after reading
            if (reader != null)
            {
                reader.Close();

                //If the file is not empty, print out the result
                if (players.Count > 0)
                {
                    Console.WriteLine(
                        "Loaded all data from file.\n" +
                        $"{players.Count} players created.");
                }
                //Else if the file is empty
                else
                {
                    Console.WriteLine("There is no player data to load.");
                }
            }                
        }

        /// <summary>
        /// Save the created players data to ../../../players.txt
        /// </summary>
        public void Save()
        {
            //Create the stream writer to save data
            StreamWriter writer = null;

            try
            {
                writer = new StreamWriter(filename);

                //fill the file by writing each player's stats in each line
                for (int i = 0; i < players.Count; i++)
                {
                    writer.WriteLine(
                        $"{players[i].Name}," +
                        $"{players[i].Strength}," +
                        $"{players[i].Health}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //If the file is load succesfully, close it after writing
            if (writer != null)
            {
                writer.Close();

                //If the file is not empty, print out the result
                if (players.Count > 0)
                {
                    Console.WriteLine(
                        $"Saved {players.Count} players to file players.txt");
                }
                //Else if the file is empty
                else
                {
                    Console.WriteLine("There is no player data yet.");
                }
            }
        }

        /// <summary>
        /// Print the player list, or prompt players info input
        /// if not player is in the list.
        /// </summary>
        public void Print()
        {
            //If players list is not empty
            if (players.Count != 0)
            {
                foreach (Player p in players)
                {
                    Console.WriteLine(p.ToString());
                }
            }
            //If players list is empty
            else
            {
                Console.WriteLine("" +
                    "There are no players yet. " +
                    "Load players data from files.");
            }
        }
    }
}
