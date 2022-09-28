namespace RestaurantInheritance;

class Sitdown : Restaurant
{
    private string hours;
    public string Hours
    {
        get { return hours; }
        set { hours = value; }
    }

    public Sitdown() : base()
    {
        hours = "";
    }

    public Sitdown(string name, int rating, string newHours) : base(name, rating)
    {
        hours = newHours;
    }

    public override string ToString()
    {
        return base.ToString() + $" Hours: {Hours}";
    }
}