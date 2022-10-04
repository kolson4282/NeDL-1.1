class HourlyEmployee : Employee, IGetBonus
{
    public double HourlyRate { get; set; }

    public HourlyEmployee(string lName, string fName, double rate) : base(lName, fName, "H")
    {
        HourlyRate = rate;
    }

    public override void SetRate(double rate)
    {
        HourlyRate = rate;
    }
    public double GetBonus()
    {
        return HourlyRate * 80;
    }

    public override string ToString()
    {
        return base.ToString() + $" | Hourly Rate: {HourlyRate} | Bonus: {GetBonus()}";
    }
}