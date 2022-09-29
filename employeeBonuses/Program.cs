namespace Bonuses
{
    class Program
    {
        static int maxLength = 25;
        static Employee?[] employees = new Employee[maxLength];
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
                        Save("employeeSaved.txt");
                        break;
                    case "C": //Create
                        AddEmployee();
                        break;
                    case "R": //Read
                        Print();
                        break;
                    case "U": //Update
                        Update();
                        break;
                    case "D": //Delete
                        Delete();
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
                //catching an index exception to see if there are too many lines in the file. We still load the first maxLength if there is.
                //NOTE: if you save the file after this, only the first maxLength lines will be saved, and anything else will be deleted from the file. 
                Console.WriteLine($"There were too many lines in your file. Only loading the first {maxLength}\n");
                Print();
            }
            catch (Exception e)
            {
                //any other exception we don't want to return any data. 
                Console.WriteLine("Could not load data.");
                Console.WriteLine(e.Message);
                employees = new Employee[maxLength];
            }
        }

        static void Save(string fileName)
        {
            if (employees[0] == null) //Assuming all null values are at the end. If the first entry is null, the whole array is empty
            {
                Console.WriteLine("Your file will be empty. Are you sure you want to save? (y/n)");
                string answer = Console.ReadLine()!.ToUpper();
                if (answer != "y" && answer != "Y")
                {
                    Console.WriteLine("Did not write to the file");
                    return;
                }
            }
            using StreamWriter sr = new(fileName);

            for (int i = 0; i < employees.GetLength(0); i++)
            {
                if (employees[i] != null)
                {
                    //Wrting four lines for every employee. 
                    sr.WriteLine(employees[i]!.ToFileString());
                }
            }

            Console.WriteLine($"Successfully wrote to file {fileName}");

        }

        static void AddEmployee()
        {
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] == null) //Look for the first empty space in the array. 
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
            Console.WriteLine($"The list is full. You can only list {maxLength} employees"); //This will only print if there is no space in the array. 
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

        static void Update()
        {
            if (employees[0] == null)
            {
                Console.WriteLine("Nothing in the list to update.");
                return;
            }

            Print();
            string firstName;
            Console.WriteLine("Enter the first name of the employee you would like to delete.");
            firstName = Console.ReadLine()!;
            string lastName;
            Console.WriteLine("Enter the last name of the employee you would like to delete.");
            lastName = Console.ReadLine()!;

            for (int i = 0; i < employees.GetLength(0); i++)
            {

                //find the first instance of the restaurant to be deleted and delete it. If there are more than one instances, delete the first. 
                if (employees[i] != null && employees[i]!.FirstName.ToUpper() == firstName.ToUpper() && employees[i]!.LastName.ToUpper() == lastName.ToUpper())
                {
                    //get the information to update the employee to.
                    Console.WriteLine($"Employee {firstName} {lastName} found.");
                    string answer;
                    bool typeChanged = false;
                    do
                    {
                        Console.WriteLine($"This employee is currently {employees[i]!.Type}. Would you like to change this? (Y/N)");
                        answer = Console.ReadLine()!.ToUpper();
                        if (answer != "Y" && answer != "N")
                        {
                            Console.WriteLine("That is an invalid answer. Please enter Y or N");
                        }
                    } while (answer != "Y" && answer != "N");
                    string type = employees[i]!.Type;
                    if (answer == "Y")
                    {
                        Console.WriteLine($"What type would you like to change {firstName} to");
                        type = Console.ReadLine()!.ToLower();
                        typeChanged = true;
                    }
                    //Change type/rate if needed.
                    //If not changing type, change rate/salary if applicable.
                    if (type == "salary")
                    {
                        if (!typeChanged)
                        {
                            Console.WriteLine($"The current yearly salary for {firstName} {lastName} is {((SalaryEmployee)employees[i]!).Salary}");
                        }
                        Console.WriteLine($"What is the new yearly salary for {firstName} {lastName}");
                        double salary = Convert.ToDouble(Console.ReadLine());
                        employees[i] = new SalaryEmployee(employees[i]!.FirstName, employees[i]!.LastName, salary);
                        Console.WriteLine($"Converted {firstName} {lastName} to a new Salaried employee with salary {salary}");
                    }
                    else if (type == "hourly")
                    {
                        if (!typeChanged)
                        {
                            Console.WriteLine($"The current hourly rate for {firstName} {lastName} is {((HourlyEmployee)employees[i]!).Rate}");
                        }
                        Console.WriteLine($"What is the new hourly rate for {firstName} {lastName}");
                        double rate = Convert.ToDouble(Console.ReadLine());
                        employees[i] = new HourlyEmployee(employees[i]!.FirstName, employees[i]!.LastName, rate);
                        Console.WriteLine($"Converted {firstName} {lastName} to a new hourly employee with hourly rate {rate}");
                    }
                    else
                    {
                        if (!typeChanged)
                        {
                            Console.WriteLine($"Nothing to update on {firstName} {lastName}");
                        }
                        else
                        {  //only update the employee if it's been updated.
                            employees[i] = new Employee(employees[i]!.FirstName, employees[i]!.LastName, type);
                            Console.WriteLine($"Updated the type of {firstName} {lastName} to {type}");
                        }
                    }
                    return;
                }
            }
            Console.WriteLine($"Employee {firstName} {lastName} not found.");
        }

        static void Delete()
        {
            //Delete a restaurant
            if (employees[0] == null)
            {
                Console.WriteLine("Nothing in the list to delete.");
                return;
            }

            Print();
            string firstName;
            Console.WriteLine("Enter the first name of the employee you would like to delete.");
            firstName = Console.ReadLine()!;
            string lastName;
            Console.WriteLine("Enter the first name of the employee you would like to delete.");
            lastName = Console.ReadLine()!;
            bool found = false;
            for (int i = 0; i < employees.GetLength(0); i++)
            {
                if (found)
                {
                    //if a record was found and deleted. Move everything else up one space.
                    if (employees[i] != null)
                    {
                        employees[i] = employees[i];
                        employees[i] = employees[i];
                    }
                    else
                    {
                        employees[i] = null;
                    }
                }
                //find the first instance of the employee to be deleted and delete it. If there are more than one instances, delete the first. 
                if (employees[i] != null && employees[i]!.FirstName.ToUpper() == firstName.ToUpper() && employees[i]!.LastName.ToUpper() == lastName.ToUpper())
                {
                    //if record is found. Set it to null
                    employees[i] = null;
                    found = true;
                    Console.WriteLine($"Successfully deleted {firstName} {lastName}");
                }

            }
            if (!found)
            {
                Console.WriteLine($"Didn't find the {firstName} {lastName}. Please try again");
            }
        }
    }//End main class
} //End Namespace