using System;

namespace InchesToFeet
{
    class Progam
    {
        static void Main(string[] args)
        {
            int input = -1;

            // Get user input
            do
            {
                Console.WriteLine("Enter Seconds");
                input = Convert.ToInt32(Console.ReadLine());
                if (input <= 0)
                {
                    Console.WriteLine("Please enter a positive whole number");
                }
            } while (input <= 0);

            // Calculate days, hours, minutes, seconds
            int minutes = input / 60;
            int seconds = input % 60;
            int hours = minutes / 60;
            minutes = minutes % 60;
            int days = hours / 24;
            hours = hours % 24;

            // Construct message to print out
            string message = input + ((input > 1) ? " seconds : " : " second : ");
            if (days != 0)
            {
                message += days + " day";
                message += (days > 1) ? "s " : " ";

            }

            if (hours != 0)
            {
                message += hours + " hour";
                message += (hours > 1) ? "s " : " ";
            }

            if (minutes != 0)
            {
                message += minutes + " minute";
                message += (minutes > 1) ? "s " : " ";
            }

            if (seconds != 0)
            {
                message += seconds + " second";
                if (seconds > 1)
                {
                    message += "s";
                }
            }

            Console.WriteLine(message);
        }
    }
}