namespace abstractEmployee
{
    class Program
    {
        public static void Main()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new HourlyEmployee("Olson", "Keith", 15.00));
            employees.Add(new SalaryEmployee("Olson", "Erin", 100000));

            foreach (Employee e in employees)
            {
                Console.WriteLine(e);
            }
        }
    }
}