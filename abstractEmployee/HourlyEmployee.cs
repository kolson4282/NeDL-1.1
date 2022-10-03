namespace abstractEmployee
{
    class HourlyEmployee : Employee
    {
        public double Rate { get; set; }

        public HourlyEmployee() : base()
        {
            Rate = 0;
        }
        public HourlyEmployee(string lname, string fname, double rate) : base(lname, fname, "hourly")
        {
            Rate = rate;
        }

        public override double CalculateBonus()
        {
            return Rate * 80;
        }

        public override string ToString()
        {
            return base.ToString() + $" | Hourly Rate: {Rate} | Bonus: {CalculateBonus()}";
        }
    }
}