namespace Bonuses
{
    class Employee
    {
        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        private string type; //Should be hourly or salary or something else. Always lowercase.
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public Employee()
        {
            firstName = "";
            lastName = "";
            type = "";
        }

        public Employee(string fname, string lname, string emptype)
        {
            firstName = fname;
            lastName = lname;
            type = emptype.ToLower();
        }

        public virtual double CalculateBonus()
        {
            return 0;
        }

        public override string ToString()
        {
            return $"{firstName} {lastName} - {type} - Bonus: {CalculateBonus()}";
        }
    }
}