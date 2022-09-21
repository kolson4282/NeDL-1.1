using System;



namespace findmax
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Keith Olson, Matt Slebrch, Noah Anderson - 9/14/22
             Find the maximum of a user specified number of doubles. 
             User with state how many nnumbers they want to supply,
             then supply those number. Program will determine the maximum
             of those numbers */

            //Requirements: 
            //1. No data structures.
            //2. Initial user input must be between 2 and 10 inclusive.
            //3. Secondary user input will be doubles between -100 and 100
            //4. Program will print out the maximum of the user inputed numbers

            // Ask user for int n that will be the number of numbers they want to enter. 
            // Validate that the number is between 2 and 10
            //if not between 2 and 10, present an error and ask again. 
            int n = 0;
            double max = -101;
            double d;
            do
            {
                Console.WriteLine("Please enter the number of numbers you would like to enter");
                n = Convert.ToInt32(Console.ReadLine());
                if (n < 2 || n > 10)
                {
                    Console.WriteLine("Number must be between 2 and 10");
                }
            } while (n < 2 || n > 10);

            //Ask user for n number of doubles from user.
            //for loop n number of times.
            //store each input in a single variable
            for (int i = 0; i < n; i++)
            {
                do
                {
                    Console.WriteLine("Please enter a double between -100 and 100");
                    d = Convert.ToDouble(Console.ReadLine());
                    if (d < -100 || d > 100)
                    {
                        Console.WriteLine("Number must be between -100 and 100");
                    }
                } while (d < -100 || d > 100);

                if (d > max)
                {
                    max = d;
                }
            }

            // Determine largest number from input 
            Console.WriteLine("Your max number is: " + max);
        }
    }
}

