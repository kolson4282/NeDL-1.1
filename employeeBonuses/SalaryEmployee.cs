namespace Bonuses
{
    class SalaryEmployee : Employee
    {
        private double salary;
        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        public SalaryEmployee(string fname, string lname, double empSalary) : base(fname, lname, "salary")
        {
            salary = empSalary;
        }

        public override double CalculateBonus()
        {
            return salary * .10;
        }

        public override string ToFileString()
        {
            return $"{FirstName}\n{LastName}\nsalary\n{Salary}";
        }
    }//End Salary
}//End Namespace