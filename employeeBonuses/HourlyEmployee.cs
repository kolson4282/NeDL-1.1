namespace Bonuses
{
    class HourlyEmployee : Employee
    {

        private double rate;
        public double Rate
        {
            get { return rate; }
            set { rate = value; }
        }

        public HourlyEmployee(string fname, string lname, double empRate) : base(fname, lname, "hourly")
        {
            rate = empRate;
        }

        public override double CalculateBonus()
        {
            return Rate * 40;
        }

        //Don't need the ToString as calling the base ToString will use this CalculateBonus
    }
}