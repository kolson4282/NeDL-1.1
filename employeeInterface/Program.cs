
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
        employees.Add(new SalaryEmployee("Last4", "First4", 50000));
        employees.Add(new SalaryEmployee("Last5", "First5", 100000));

        PrintList(employees);
    }

    static void PrintList(List<Employee> list)
    {
        foreach (Employee e in list)
        {
            Console.WriteLine(e);
        }
    }
}