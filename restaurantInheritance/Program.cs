using System;

//All restaurants should have a name and rating.
//Carryout restaurant - address
//Delivery - Phone
//Sitdown - Hours of Operation

//each should have 2 constructors. One with nothing passed and one passing everything needed.

namespace RestaurantInheritance;

class Program
{
    static void Main(string[] args)
    {
        //Test each constructor for the three classes we did. 
        Carryout emptyC = new Carryout();
        Carryout c = new Carryout("Sonic", 2, "123 s main st");
        // Console.WriteLine(c);

        Sitdown emptyS = new Sitdown();
        Sitdown s = new Sitdown("Chilis", 3, "9 - 5");
        // Console.WriteLine(s);

        Delivery emptyD = new Delivery();
        Delivery d = new Delivery("Papa Johns", 4, "555-123-4567");
        // Console.WriteLine(d);

        Restaurant[] list = { c, s, d, emptyC, emptyS, emptyD };
        foreach (Restaurant r in list)
        {
            Console.WriteLine(r);
        }
    }
}
