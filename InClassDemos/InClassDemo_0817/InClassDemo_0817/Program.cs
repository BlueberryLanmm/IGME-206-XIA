namespace InClassDemo_0817
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SwitchCases();
        }

        static void SwitchCases()
        {
            int number = 0;

            switch (number)
            {

                case <1:
                case 2:
                    Console.WriteLine("Below 3");
                    break;

                case 0:

                case 10:
                    Console.WriteLine("Ten!");
                    break;

                default:
                    Console.WriteLine("Other");
                    break;
            }


        }
    }
}
