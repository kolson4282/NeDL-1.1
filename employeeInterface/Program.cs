
//IRate Interface that has a SetRate(double) method.
//IGetBonus Interface that has a CalculateBonus() method
//Hourly, Salary and Regular emloyees

//List of employees (some of all of them)
//Print the list
//Search for an employee
//Add an employee
//Update an employee (name/type/rate/etc.)
//Delete an employee

class Program
{
    static void Main()
    {
        List<Employee> employees = new List<Employee>();

        //add basic employees to the list
        employees.Add(new Employee("Last1", "First1", "C"));
        employees.Add(new Employee("Last2", "First2", "M"));

        //add Hourly Employees
        employees.Add(new HourlyEmployee("Last3", "First3", 15.00));
        employees.Add(new HourlyEmployee("Last4", "First4", 20.00));

        //add Hourly Employees
        employees.Add(new SalaryEmployee("Last5", "First5", 50000));
        employees.Add(new SalaryEmployee("Last6", "First6", 100000));

        PrintList(employees);

        string input;
        do
        {
            input = GetMenuOption();
            switch (input)
            {
                case "S": //Save
                    Search(employees);
                    break;
                case "C": //Create
                    AddEmployee(employees);
                    break;
                case "R": //Read
                    PrintList(employees);
                    break;
                case "U": //Update
                    UpdateEmployee(employees);
                    break;
                case "D": //Delete
                    DeleteEmployee(employees);
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

    private static void Search(List<Employee> employees)
    {
        Console.WriteLine("What is the last name of the employee you would like to find?");
        string name = Console.ReadLine()!;
        bool found = false;
        foreach (Employee e in employees)
        {
            if (e.LastName.ToUpper().Contains(name.ToUpper()))
            {
                Console.WriteLine(e);
                found = true;
            }
        }
        if (!found)
        {
            Console.WriteLine($"No employee found containing {name} in their last name");
        }
    }
    private static void AddEmployee(List<Employee> employees)
    {
        Console.WriteLine("Adding");
    }
    private static void UpdateEmployee(List<Employee> employees)
    {
        Console.WriteLine("Updating");
    }
    private static void DeleteEmployee(List<Employee> employees)
    {
        Console.WriteLine("Deleteing");
    }

    static string GetMenuOption()
    {
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("R: Print the list of employees");
        Console.WriteLine("S: Search for an employee by Last Name");
        Console.WriteLine("C: Add a new employee");
        Console.WriteLine("U: Update the information for an employee");
        Console.WriteLine("D: Delete an employee");
        Console.WriteLine("Q: Quit");
        string input = Console.ReadLine()!.ToUpper();

        return input;
    }

    static void PrintList(List<Employee> employees)
    {
        foreach (Employee e in employees)
        {
            Console.WriteLine(e);
        }
    }
}