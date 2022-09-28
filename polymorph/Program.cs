using System;

namespace Polymorph
{
    class Program
    {
        static void Main(string[] args)
        {
            Restaurant r = new Restaurant();
            Carryout c = new Carryout();

            r.SayMotto();
            c.SayMotto();
        }
    }

}