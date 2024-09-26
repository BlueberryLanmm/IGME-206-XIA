namespace PE_2D_Arrays_XIA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Init a 2D array of 2 x 4 elements with sequential values
            int[,] integerArray = new int[2, 4];
            Fill2DArray(integerArray, 5);

            // Print values in the array
            Print2DArray(integerArray);
        }

        /// <summary>
        /// Fill the 2D array in order, starting with a start number.
        /// </summary>
        /// <param name="array">A initialized 2D array to be filled in</param>
        /// <param name="startNum">The start number when fill in</param>
        public static void Fill2DArray(int[,] array, int startNum)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0;  j < array.GetLength(1); j++)
                {
                    //calculate the number by adding previous row and column number
                    array[i, j] = startNum + i * array.GetLength(1) + j;
                }
            }
        }

        /// <summary>
        /// Print out a 2D array
        /// </summary>
        /// <param name="array">The initialized 2D array to be printed out</param>
        public static void Print2DArray(int[,] array)
        {
            for(int i = 0;i < array.GetLength(0) + 1; i++)
            {
                for(int j = 0; j < array.GetLength(1) + 1; j++)
                {
                    //the first row of first column
                    if (i == 0 && j == 0)
                    {
                        Console.Write("\t");
                    }
                    //the first row
                    else if (i == 0)
                    {
                        Console.Write("Col {0}\t", j);
                    }
                    //the first column
                    else if (j == 0)
                    {
                        Console.Write("Row {0}\t", i);
                    }
                    //other numbers
                    else
                    {
                        Console.Write("{0}\t", array[i - 1, j - 1]);
                    }
                }

                //change into the next line
                Console.WriteLine();
            }
        }
    }
}
