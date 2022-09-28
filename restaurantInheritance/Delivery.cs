namespace RestaurantInheritance;

class Delivery : Restaurant
{
    private string phone;
    public string Phone
    {
        get { return phone; }
        set { phone = value; }
    }

    public Delivery() : base()
    {
        phone = "";
    }

    public Delivery(string name, int rating, string newPhone) : base(name, rating)
    {
        phone = newPhone;
    }

    public override string ToString()
    {
        return base.ToString() + $" Phone: {Phone}";
    }
}