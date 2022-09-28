namespace RestaurantInheritance;

class Restaurant
{
    private string name;
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    private int rating;
    public int Rating
    {
        get { return rating; }
        set { rating = value; }
    }

    public Restaurant()
    {
        name = "";
        rating = 0;
    }
    public Restaurant(string newName, int newRating)
    {
        name = newName;
        rating = newRating;
    }

    public override string ToString()
    {
        return $"{name} : {rating} out of 5 stars.";
    }
}