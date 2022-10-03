namespace abstractEmployee
{
    abstract class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Type { get; set; }

        public Employee()
        {
            FirstName = LastName = Type = "";
        }

        public Employee(string lname, string fname, string type)
        {
            LastName = lname;
            FirstName = fname;
            Type = type;
        }

        public abstract double CalculateBonus();
        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} | Type: {Type}";
        }

    }
}