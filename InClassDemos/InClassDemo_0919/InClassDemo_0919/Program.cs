namespace InClassDemo_0919
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int arrayLength = 5;

            int[] x = new int[arrayLength];
            bool[] b = new bool[arrayLength];
            string[] s = new string[arrayLength];

            for (int i = 0; i < arrayLength; i++)
            {
                Console.WriteLine(x[i]);
                Console.WriteLine(b[i]);
                Console.WriteLine(s[i]);    //s[i] = null, not empty string
            }

            for (int i = 0; i < arrayLength; i++)
            {
                Console.WriteLine(x[i]);
                Console.WriteLine(b[i]);
                Console.WriteLine(s[i].Length);    //cannot access the method and properties of null strings.
            }
        }
    }
}
