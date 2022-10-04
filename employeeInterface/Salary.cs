class SalaryEmployee : Employee, IGetBonus
{

    public double Salary { get; set; }
    public SalaryEmployee(string lName, string fName, double rate) : base(lName, fName, "S")
    {
        Salary = rate;
    }

    public override void SetRate(double rate)
    {
        Salary = rate;
    }
    public double GetBonus()
    {
        return Salary * .1;
    }

    public override string ToString()
    {
        return base.ToString() + $" | Salary: {Salary} | Bonus: {GetBonus()}";
    }
}