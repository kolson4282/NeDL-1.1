using System;

namespace average
{

    class Program
    {

        //This program will take in three integers and return the average and sum of them.
        static void Main(string[] args)
        {
            //take in 3 numbers
            Console.Write("Enter the first number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the second number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the third number: ");
            int num3 = Convert.ToInt32(Console.ReadLine());

            //Find the sum and average
            int sum = num1 + num2 + num3;
            double average = Math.Round(sum / 3.0, 3);

            Console.WriteLine("The average of {0} {1} and {2}, is {3}, and the sum is {4}", num1, num2, num3, average, sum);
            Console.ReadKey();
        }
    }
}