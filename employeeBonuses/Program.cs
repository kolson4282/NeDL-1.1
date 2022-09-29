namespace Bonuses
{
    class Program
    {

        static Employee?[] employees = new Employee[25];
        static void Main()
        {
            string input;
            do
            {
                input = GetMenuOption();

                switch (input)
                {
                    case "L": //Load
                        Load("employees.txt");
                        break;
                    case "S": //Save
                        Console.WriteLine("Saving...");
                        break;
                    case "C": //Create
                        AddEmployee();
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

        static void Load(string fileName)
        {
            //Load from file
            try
            {
                int index = 0;
                using (StreamReader sr = File.OpenText(fileName))
                {
                    //read the file line by line and assign to an index in data. 
                    while (!sr.EndOfStream) // while we are not at the end of the file. (basically while there is a next line. Assuming data is correct in the file)
                    {
                        string firstName = sr.ReadLine()!;
                        string lastName = sr.ReadLine()!;
                        string type = sr.ReadLine()!;
                        double rate = Convert.ToDouble(sr.ReadLine());
                        Employee e;

                        switch (type)
                        {
                            case "hourly":
                                e = new HourlyEmployee(firstName, lastName, rate);
                                break;
                            case "salary":
                                e = new SalaryEmployee(firstName, lastName, rate);
                                break;
                            default:
                                e = new Employee(firstName, lastName, type);
                                break;
                        }
                        employees[index] = e;
                        index++;
                    }
                }
                Console.WriteLine($"Successfully loaded from file {fileName}");
                Print();

            }
            catch (IndexOutOfRangeException)
            {
                //catching an index exception to see if there are too many lines in the file. We still load the first 25 if there is.
                //NOTE: if you save the file after this, only the first 25 lines will be saved, and anything else will be deleted from the file. 
                Console.WriteLine("There were too many lines in your file. Only loading the first 25\n");
                Print();
            }
            catch (Exception e)
            {
                //any other exception we don't want to return any data. 
                Console.WriteLine("Could not load data.");
                Console.WriteLine(e.Message);
                employees = new Employee[25];
            }
        }

        static void Print()
        {
            foreach (Employee? employee in employees)
            {
                if (employee != null) //Don't print if the employee is null. 
                {
                    Console.WriteLine(employee);
                }
            }
        }

        static void AddEmployee()
        {
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] == null)
                {
                    Console.WriteLine("What is the first name of the employee you would like to add?");
                    string firstName = Console.ReadLine()!;
                    Console.WriteLine($"What is the last name of {firstName}");
                    string lastName = Console.ReadLine()!;
                    Console.WriteLine($"What type of employee is {firstName} {lastName}");
                    string type = Console.ReadLine()!;

                    if (type.ToLower() == "salary")
                    {
                        Console.WriteLine($"What is the salary for {firstName} {lastName}");
                        double salary = Convert.ToDouble(Console.ReadLine());
                        employees[i] = new SalaryEmployee(firstName, lastName, salary);
                    }
                    else if (type.ToLower() == "hourly")
                    {
                        Console.WriteLine($"What is the hourly rate for {firstName} {lastName}");
                        double rate = Convert.ToDouble(Console.ReadLine());
                        employees[i] = new HourlyEmployee(firstName, lastName, rate);
                    }
                    else
                    {
                        employees[i] = new Employee(firstName, lastName, type);
                    }
                    Console.WriteLine($"{type} employee {firstName} {lastName} successfully added");
                    return;
                }
            }
            Console.WriteLine("The list is full. You can only list 25 employees");
        }
    }
}