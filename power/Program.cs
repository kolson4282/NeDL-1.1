using System;

// Peter Gillock, Keith Olson, Nithya Varadarajan
// 9/15/22
// This program will ask the user for a base and an exponent and return the value back to the user. 
// All data is integers >= 1
// repeat the process until the user wants to quit. 

//1. Get base and exponent from the user. Validate this is correct. Get this through method GetUserInput.
//2. Calculate the power using a Power method and display the results.
//3. Prompt user to continue. If yes, repeat.



namespace power
{
    class Program
    {
        static void Main(string[] args)
        {

            const int min = 5;

            string varContinue = "Y"; // Should the program continue prompting the user for numbers y/n
            int baseNumber, exponent, result; //baseNumber to the exponent power will give the result. 
            do
            {
                //Get the baseNumber and exponent from the user using GetUserInput method
                baseNumber = GetUserInput($"Enter a base number greater than or equal to {min}: ", min);
                exponent = GetUserInput($"Enter a exponent greater than or equal to {min}: ", min);

                //Calculate the power using the Power method
                result = Power(baseNumber, exponent);

                //display the result to the user. 
                Console.WriteLine($"{baseNumber} to the power of {exponent} is {result}");
                Console.WriteLine();

                //ask the user if they want to continue. 
                Console.Write("Would you like to enter another number? (y/n) : ");
                varContinue = Console.ReadLine()!.ToUpper(); //! is a null forgiving operator. Makes a null value not null. 
                Console.WriteLine();
            } while (varContinue == "Y");
        }

        static int Power(int baseNumber, int exponent)
        {
            // Power method:
            // 1. pass in base and exponent
            // 2. Calculate the power using a for loop.
            // 3. Return the power.
            int result = 1; //start with 1 because we will be using multiplication.

            //loop through exponent number of times
            for (int counter = 1; counter <= exponent; counter++)
            {
                //multiply the result by the base number
                result *= baseNumber;
            }
            return result;
        }

        static int GetUserInput(string prompt, int lowerValue)
        {
            int input; //will be the int that the user enters. Must be greater than or equal to lowerValue
            do
            {
                Console.Write(prompt);//print prompt passed into the method
                input = Convert.ToInt32(Console.ReadLine());//Read the user input
                // Console.WriteLine(input);
                if (input < lowerValue) //if input is not valid, print an error. 
                {
                    Console.WriteLine($"Enter a value greater than or equal to {lowerValue}");
                }
            } while (input < lowerValue);
            return input;
        }
    }
}