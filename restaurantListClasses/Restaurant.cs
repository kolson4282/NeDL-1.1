namespace RestaurantList;

class Restaurant
{
    //name and rating. Default constructor. Constructor with both. 
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
}