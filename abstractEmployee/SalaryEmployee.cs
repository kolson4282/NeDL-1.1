namespace abstractEmployee
{
    class SalaryEmployee : Employee
    {
        public double Salary { get; set; }

        public SalaryEmployee() : base()
        {
            Salary = 0;
        }
        public SalaryEmployee(string lname, string fname, double salary) : base(lname, fname, "salary")
        {
            Salary = salary;
        }

        public override double CalculateBonus()
        {
            return Salary * .1;
        }

        public override string ToString()
        {
            return base.ToString() + $" | Salary: {Salary} | Bonus: {CalculateBonus()}";
        }
    }
}