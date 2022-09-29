namespace Bonuses
{
    class Program
    {

        static Employee[] names = new Employee[25];
        static void Main()
        {
            string input;
            do
            {
                input = GetMenuOption();

                switch (input)
                {
                    case "L": //Load
                        Load();
                        break;
                    case "S": //Save
                        Console.WriteLine("Saving...");
                        break;
                    case "C": //Create
                        Console.WriteLine("Creating...");
                        break;
                    case "R": //Read
                        Print();
                        break;
                    case "U": //Update
                        Console.WriteLine("Updating...");
                        break;
                    case "D": //Delete
                        Console.WriteLine("Deleting...");
                        break;
                    case "Q": //Quit
                        Console.WriteLine("Good Bye!");
                        break;
                    default: //All other input will be invalid
                        Console.WriteLine("Invalid Option. Please try again.");
                        break;
                }
            } while (input != "Q");
        }

        static string GetMenuOption()
        {

            Console.WriteLine("What would you like to do?");
            Console.WriteLine("L: Load data from a file");
            Console.WriteLine("S: Store the data into the file");
            Console.WriteLine("C: Add a new employee");
            Console.WriteLine("R: Print the list of employees");
            Console.WriteLine("U: Update the information for an employee");
            Console.WriteLine("D: Delete an employee");
            Console.WriteLine("Q: Quit");
            string input = Console.ReadLine()!.ToUpper();

            return input;
        }

        static void Load()
        {
            names[0] = new HourlyEmployee("John", "Smith", 10);
            names[1] = new SalaryEmployee("Keith", "Olson", 50000);
            names[2] = new Employee("Test", "Test", "other");
        }

        static void Print()
        {
            foreach (Employee employee in names)
            {
                if (employee != null) //Don't print if the employee is null. 
                {
                    Console.WriteLine(employee);
                }
            }
        }
    }
}