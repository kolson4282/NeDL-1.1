using System;

// Keith Olson
// 9/15/22
// This program will ask the user for a base and 2 integers for bounds for an exponent and return the result of the base raised to the range of exponents. 
// base will be a real number, and exponents will be integers.

//1. Get base and exponent from the user. Validate this is correct. Get this through method GetUserInput.
//2. Loop through all the numbers between the lower and upper bound and calculate the power using a Power method and display the results.
//3. Prompt user to continue. If yes, repeat.



namespace power
{
    class Program
    {
        static void Main(string[] args)
        {
            string cont = "Y";
            double baseNumber;
            int lowerExp, upperExp;
            do
            {
                //Get the baseNumber and exponents from the user using GetUserInput methods
                baseNumber = GetUserDouble($"Enter a base number: ");
                lowerExp = GetUserInt($"Enter a lower bound for the exponent: ");
                upperExp = GetUserInt($"Enter an upper bound for the exponent greater than {lowerExp}: ", lowerExp + 1);

                // loop from lowerExp to upperExp and find the powers of the base to that exponent.
                PrintSequentialPowers(baseNumber, lowerExp, upperExp);
            } while (ShouldContinue("Would you like to continue?(Y/N) ", cont));
        }

        static int GetUserInt(string prompt, int lowerValue = int.MinValue)
        {
            //get integer input from a user and ensure that it is valid.
            int input = 0; //will be the int that the user enters. Must be greater than or equal to lowerValue
            do
            {
                Console.Write(prompt);//print prompt passed into the method
                input = Convert.ToInt32(Console.ReadLine());//Read the user input
                if (input < lowerValue)
                {
                    Console.WriteLine($"Enter a value greater than or equal to {lowerValue}");
                }
            } while (input < lowerValue);
            return input;
        }

        static double GetUserDouble(string prompt, double lowerValue = double.MinValue)
        {
            //get integer input from a user and ensure that it is valid.
            double input = 0; //will be the int that the user enters. Must be greater than or equal to lowerValue
            do
            {
                Console.Write(prompt);//print prompt passed into the method
                input = Convert.ToDouble(Console.ReadLine());//Read the user input
                if (input < lowerValue)
                {
                    Console.WriteLine($"Enter a value greater than or equal to {lowerValue}");
                }
            } while (input < lowerValue);
            return input;
        }

        static bool ShouldContinue(string prompt, string testString)
        {
            //this method displays a prompt and then checks if the user input is equal to a test string
            Console.Write(prompt);//print prompt passed into the method
            string input = Console.ReadLine()!.ToUpper();//Read the user input.
            Console.WriteLine();
            return (input == testString.ToUpper());
        }

        static void PrintSequentialPowers(double baseNumber, int minExp, int maxExp)
        {
            // loop from lowerExp to upperExp and find the powers of the base to that exponent.
            for (int i = minExp; i <= maxExp; i++)
            {
                double result = Power(baseNumber, i);

                //display the result to the user. 
                Console.WriteLine($"{baseNumber} ^ {i} is {result}");
            }
        }

        static double Power(double baseNumber, int exponent)
        {
            // Power method:
            // 1. Get the base and exponent.
            // 2. If exponent is negative. Find the reciprical of the base and invert the exponent.
            // 3. Calculate the power using a for loop.
            // 4. Return the result.
            //using a double to get larger numbers. Int maxes out at 2^32
            double result = 1; //start with 1 because we will be using multiplication.
            if (exponent < 1)
            {
                baseNumber = 1 / baseNumber;
                exponent = -1 * exponent;
            }

            //loop through exponent number of times
            for (int i = 1; i <= exponent; i++)
            {
                //multiply the result by the base number
                result *= baseNumber;
            }
            return result;
        }
    }
}