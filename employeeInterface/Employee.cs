class Employee : IRate
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Type { get; set; }

    public Employee()
    {
        FirstName = "";
        LastName = "";
        Type = "";
    }

    public Employee(string lName, string fName, string type)
    {
        FirstName = fName;
        LastName = lName;
        Type = type;
    }
    public virtual void SetRate(double rate)
    {

    }

    public override string ToString()
    {
        return $"Employee: {LastName}, {FirstName} | Type: {Type}";
    }
}