using System;

namespace FahrenheitToCelsius
{
    class Progam
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter yards to convert");
            double yards = Convert.ToDouble(Console.ReadLine());
            double feet = yards * 3;

            Console.WriteLine("{0} yards : {1} feet", yards, feet);
        }
    }
}