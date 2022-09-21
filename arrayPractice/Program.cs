using System;

// get 10 values from the user (int) between 0-100
// find the max, min and average.
// Count how many students are below and above or equal to the average

namespace arrayPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] grades = new int[10];
            int max = -1, min = 101, total = 0;

            //Get 10 values from the user
            //for loop
            for (int i = 0; i < 10; i++)
            {
                //ask the user for the numbers and add them to an array.
                int input;
                do
                {
                    Console.Write($"Enter grade number {i + 1}: ");
                    input = Convert.ToInt32(Console.ReadLine());
                    if (input < 0 || input > 100)
                    {
                        Console.WriteLine("grades must be between 0 and 100");
                    }
                } while (input < 0 || input > 100);
                if (input > max)
                {
                    max = input;
                }
                if (input < min)
                {
                    min = input;
                }
                total += input;
                grades[i] = input;
            }

            //find maximum
            // int max = grades[0];
            // foreach (int i in grades)
            // {
            //     if (i > max)
            //     {
            //         max = i;
            //     }
            // }

            Console.WriteLine("Max: " + max);

            //find min
            // int min = grades[0];
            // foreach (int i in grades)
            // {
            //     if (i < min)
            //     {
            //         min = i;
            //     }
            // }

            Console.WriteLine("Min: " + min);

            //find average
            // int total = 0;
            // foreach (int i in grades)
            // {
            //     total += i;
            // }
            int average = total / 10;

            Console.WriteLine("Average: " + average);

            //count number below and above or equal to the average. 
            int underAverage = 0, aboveAverage = 0;
            foreach (int i in grades)
            {
                if (i < average)
                {
                    underAverage++;
                }
                else
                {
                    aboveAverage++;
                }
            }

            Console.WriteLine($"Number under average: {underAverage}. Number above or equal to average: {aboveAverage}");
        }
    }
}