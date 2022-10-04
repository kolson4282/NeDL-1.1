
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

    }//End Main

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
    }//End GetMenuOption

    static void Search(List<Employee> employees)
    {
        //searches for all employees that contain the string typed in and prints them out. 
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
    }//End of search
    static void AddEmployee(List<Employee> employees)
    {
        //Adds a new employee to the list.
        Console.WriteLine("What is the last name of the employee you would like to add?");
        string lName = Console.ReadLine()!;
        Console.WriteLine("What is the first name of the employee you would like to add?");
        string fName = Console.ReadLine()!;
        Console.WriteLine("What is the type of the employee you would like to add?");
        string type = Console.ReadLine()!.ToUpper();

        switch (type)
        {
            case "S":
                Console.WriteLine("What is the yearly salary of this employee?");
                double salary = Convert.ToDouble(Console.ReadLine());
                employees.Add(new SalaryEmployee(lName, fName, salary));
                break;
            case "H":
                Console.WriteLine("What is the Hourly Rate of this employee?");
                double rate = Convert.ToDouble(Console.ReadLine());
                employees.Add(new HourlyEmployee(lName, fName, rate));
                break;
            default:
                employees.Add(new Employee(lName, fName, type));
                break;
        }

    }//End of add
    static void UpdateEmployee(List<Employee> employees)
    {
        //Updates an employee that is specified by the user. Can update Name, Rate or Type. 
        Console.WriteLine("What is the last name of the employee you would like to update?");
        string name = Console.ReadLine()!;
        bool found = false;
        for (int i = 0; i < employees.Count; i++)
        {
            Employee e = employees[i];
            if (e.LastName.ToUpper().Contains(name.ToUpper()))
            {
                Console.WriteLine(e);
                found = true;
                Console.WriteLine("Is this the employee you would like to update? (Y/N)");
                string input = Console.ReadLine()!.ToUpper();
                if (input == "N")
                {
                    continue;
                }
                Console.WriteLine("What would you like to update?");
                Console.WriteLine("1: First Name");
                Console.WriteLine("2: LastName");
                Console.WriteLine("3: Type");
                Console.WriteLine("4: Rate");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("What would you like to update the first name to?");
                        e.FirstName = Console.ReadLine()!;
                        break;
                    case 2:
                        Console.WriteLine("What would you like to update the last name to?");
                        e.LastName = Console.ReadLine()!;
                        break;
                    case 3:
                        Console.WriteLine("What type of employee would you like to change this to?");
                        string type = Console.ReadLine()!;
                        switch (type)
                        {
                            case "S":
                                Console.WriteLine("What is the yearly salary of this employee?");
                                double salary = Convert.ToDouble(Console.ReadLine());
                                employees[i] = new SalaryEmployee(e.LastName, e.FirstName, salary);
                                break;
                            case "H":
                                Console.WriteLine("What is the Hourly Rate of this employee?");
                                double rate = Convert.ToDouble(Console.ReadLine());
                                employees[i] = new HourlyEmployee(e.LastName, e.FirstName, rate);
                                break;
                            default:
                                employees[i] = new Employee(e.LastName, e.FirstName, type);
                                break;
                        }
                        break;
                    case 4:
                        Console.WriteLine("What rate would you like to update to?");
                        e.SetRate(Convert.ToDouble(Console.ReadLine()));
                        break;
                }
                return;
            }
        }
        if (!found)
        {
            Console.WriteLine($"No employee found containing {name} in their last name");
        }
        else
        {
            Console.WriteLine("Did not update any records");
        }
    }//End of update
    static void DeleteEmployee(List<Employee> employees)
    {
        //Deletes an employee specified. Asks the user for confirmation before deleting.
        Console.WriteLine("What is the last name of the employee you would like to delete?");
        string name = Console.ReadLine()!;
        bool found = false;
        for (int i = 0; i < employees.Count; i++)
        {
            Employee e = employees[i];
            if (e.LastName.ToUpper().Contains(name.ToUpper()))
            {
                Console.WriteLine(e);
                found = true;
                Console.WriteLine("Is this the employee you would like to delete? (Y/N)");
                string input = Console.ReadLine()!.ToUpper();
                if (input == "N")
                {
                    continue;
                }
                employees.Remove(e);
                Console.WriteLine("Successfully Deleted");
                return;
            }
        }
        if (!found)
        {
            Console.WriteLine($"No employee found containing {name} in their last name");
        }
        else
        {
            Console.WriteLine("No records deleted");
        }
    } //End of Delete

    static void PrintList(List<Employee> employees)
    {
        foreach (Employee e in employees)
        {
            Console.WriteLine(e);
        }
    }//End of PrintList
}// End of class