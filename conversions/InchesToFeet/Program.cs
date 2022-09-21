using System;

namespace InchesToFeet
{
    class Progam
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Inches to convert");
            double inches = Convert.ToDouble(Console.ReadLine());
            double feet = inches / 12;

            Console.WriteLine("{0} inches : {1} feet", inches, feet);
        }
    }
}