using System;

namespace Total
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            do
            {
                Console.WriteLine("Enter the number of numbers you want to sum");
                n = Convert.ToInt32(Console.ReadLine());
                if (n < 2 || n > 10)
                {
                    Console.WriteLine("Number must be between 2 and 10");
                }
            } while (n < 2 || n > 10);

            int total = 0;
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Enter a number to add");
                total += Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("Total is {0}", total);
        }
    }
}