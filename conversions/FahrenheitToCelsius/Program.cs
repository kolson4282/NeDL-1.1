using System;

namespace FahrenheitToCelsius
{
    class Progam
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter degrees fahrenheit to convert");
            double fahrenheit = Convert.ToDouble(Console.ReadLine());

            double celsius = (fahrenheit - 32) * 5 / 9; //This calculates Celsius

            Console.WriteLine("{0} degrees fahrenheit : {1} degrees celsius", fahrenheit, celsius);
            Console.ReadKey();
        }
    }
}