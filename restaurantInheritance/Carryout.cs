namespace RestaurantInheritance;

class Carryout : Restaurant
{
    private string address;
    public string Address
    {
        get { return address; }
        set { address = value; }
    }

    public Carryout() : base()
    {
        address = "";
    }

    public Carryout(string name, int rating, string newAddress) : base(name, rating)
    {
        address = newAddress;
    }

    public override string ToString()
    {
        return base.ToString() + $" Address: {Address}";
    }

}