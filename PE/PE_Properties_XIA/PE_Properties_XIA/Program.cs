namespace PE_Properties_XIA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Declare variables
            string title;
            string author;
            int pages = 0;
            string owner;

            //An variable to temporarily store user input
            string userInput;


            //Print the welcome info
            Console.WriteLine("Welcome to Book Simulator 2020.\n");

            //Prompt user to input the book information
            title = GetPromptedInput("What is the book's title?");
            author = GetPromptedInput("Who is the book's author?");

            //If the number of pages are invalid, prompt input again
            while (!int.TryParse(
                GetPromptedInput("How many pages does it have?"), 
                out pages) || pages <= 0)
            {
                Console.WriteLine("Invalid Input. Please enter again.");
            }

            owner = GetPromptedInput("Who is the book's current owner?");


            //Instantiate the book with the inputs
            Book book = new Book(title, author, pages, owner);

            //Use a do/while loop to keep prompting user choice
            do
            {
                userInput = GetPromptedInput("\nWhat would you like to do?").ToLower();

                //Use a switch case to respond to different user inputs
                switch (userInput)
                {                   
                    case "title":
                        //Print the title
                        Console.WriteLine("The title is {0}.", book.Title); 
                        break;

                    case "author":
                        //Print the author
                        Console.WriteLine("The author is {0}.", book.Author);
                        break;

                    case "pages":
                        //Print the number of pages
                        Console.WriteLine("The book has {0} pages.", book.NumberOfPages);
                        break;

                    case "owner":
                        //Ask if the user want to change the owner
                        userInput = GetPromptedInput(
                            "Would you like to change the owner (yes/no)?");

                        if (userInput == "yes")
                        {
                            userInput = GetPromptedInput("Who is the new owner?");

                            //If the new owner input is not empty, make it the new owner
                            book.Owner = userInput;

                            //Print out current owner.
                            Console.WriteLine("The new owner is {0}.", book.Owner);
                        }
                        else if(userInput == "no")
                        {
                            //Print out current owner without changing anything
                            Console.WriteLine("Ok. {0} is still the owner.", book.Owner);
                        }
                        break;

                    case "read":
                        //Add to total read times and print the current read time
                        book.TotalTimes++;
                        Console.WriteLine("The total times read is {0}.", book.TotalTimes);
                        break;

                    case "print":
                        //Call the Book.Print() method to print the book information
                        book.Print();
                        break;

                    case "done":
                        //Print "Goodbye!" and then end the loop with the while condition
                        Console.WriteLine("Goodbye!");
                        break;

                    default:
                        //Print invalid information if input is none of the above
                        Console.WriteLine("Invalid input. Please enter again.");
                        break;
                }
            }
            while (userInput != "done");

        }


        /// <summary>
        /// Input helper written by Prof. Mesh
        /// Uses the given string to prompt the user for input and set
        /// the color to cyan while they type.
        /// </summary>
        /// <param name="prompt">What to print before waiting for input</param>
        /// <returns>A trimmed version of what the user entered</returns>
        public static string GetPromptedInput(string prompt)
        {
            // Always print in white
            Console.ForegroundColor = ConsoleColor.White;

            // Print the prompt
            Console.Write(prompt + " ");

            // Switch color and get user input (trim too)
            Console.ForegroundColor = ConsoleColor.Cyan;
            string response = Console.ReadLine().Trim();

            // Switch back to white and then return response.
            Console.ForegroundColor = ConsoleColor.White;
            return response;
        }
    }
}
