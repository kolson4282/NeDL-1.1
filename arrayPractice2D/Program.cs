using System;

namespace arrayPractice2D
{
    class Program
    {
        static void Main(string[] args)
        {
            const int numOfStudents = 5, numOfGrades = 6;
            int[,] grades = new int[numOfStudents, numOfGrades];
            //get all of the grades and fill in the grades array
            for (int i = 0; i < numOfStudents; i++)
            {
                for (int j = 0; j < numOfGrades; j++)
                {
                    int input;
                    do
                    {
                        Console.Write($"Enter grade number {j + 1} for student {i + 1}: ");
                        input = Convert.ToInt32(Console.ReadLine());
                        if (input < 0 || input > 100)
                        {
                            Console.WriteLine("Grades must be between 0 and 100");
                        }
                    } while (input < 0 || input > 100);
                    grades[i, j] = input;
                }
            }

            double[] averages = new double[numOfStudents];
            double classMax = -1;
            double classMin = 101;
            //calculate the average and the min and max average
            for (int i = 0; i < numOfStudents; i++)
            {
                int total = 0;
                for (int j = 0; j < numOfGrades; j++)
                {
                    total += grades[i, j];
                }
                averages[i] = total / numOfGrades;
                if (averages[i] > classMax)
                {
                    classMax = averages[i];
                }
                if (averages[i] < classMin)
                {
                    classMin = averages[i];
                }
            }

            //Print the results
            double classTotal = 0;
            for (int i = 0; i < numOfStudents; i++)
            {
                Console.WriteLine($"The average for student {i + 1} is {averages[i]}");
                classTotal += averages[i];
            }
            double classAverage = classTotal / numOfStudents;
            Console.WriteLine($"The max average is {classMax} and the minimum average is {classMin}. The average for the class is {classAverage}");
        }
    }
}
