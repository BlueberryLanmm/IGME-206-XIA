namespace PE_Loops_XIA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*************************************************************
             * Part 1: Try the loops
             ************************************************************/
            //declare a variable to store the printed number
            int number;

            //print out the first list with while
            number = 0;
            while (number < 6)
            {
                Console.WriteLine(number);
                number++;
            }
            //add a blank line
            Console.WriteLine();

            //print out the second list with do/while
            number = 100;
            do
            {
                Console.WriteLine(number);
                number--;
            }
            while (number > 94);
            //add a blank line
            Console.WriteLine();

            //print the third list with for loop
            for(number = 0; number < 30; number += 5)
            {
                Console.WriteLine(number);
            }
            //add a blank line
            Console.WriteLine();


            /*************************************************************
             * Part 2: ASCII Art
             ************************************************************/
            //declare the variables
            int width;
            int height;

            //ask for width and height input
            Console.Write("Enter a width: ");
            width = int.Parse(Console.ReadLine());
            Console.Write("Enter a height: ");
            height = int.Parse(Console.ReadLine());

            //draw the rectangle
            for (int y = 0; y < height; y++) 
            {
                for (int x = 0; x < width; x++)
                {
                    //print an 'O' at row y and column x
                    Console.Write("O");
                }
                //switch to the next line at the end of row y
                Console.WriteLine();
            }
            //add a blank line
            Console.WriteLine();

            //draw the border
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (y == 0 || y == height - 1 || x == 0 || x == width - 1)
                    {
                        //print an 'O' at first row, last row, first column and last column
                        Console.Write("O");
                    }
                    else
                    {
                        //print ' ' elsewhere
                        Console.Write(" ");
                    }
                }
                //switch to the next line at the end of row y
                Console.WriteLine();
            }
        }
    }
}
