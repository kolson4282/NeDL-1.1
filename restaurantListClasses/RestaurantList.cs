namespace RestaurantList;

class RestaurantList
{

    private Restaurant[] list;
    private int length;
    public int Length
    {
        get { return length; }
    }

    public RestaurantList()
    {
        //Default Constructor. Default to a length of 25
        list = new Restaurant[25];
        length = 25;
    }

    public RestaurantList(int arrLength)
    {
        //Customizable length if you want to create an array of a different length. 
        list = new Restaurant[arrLength];
        length = arrLength;
    }

    public void AddRestaurant(Restaurant restaurant)
    {

        //Add a new restaurant review to the list.
        if (isFull())
        {
            //if the array is full. Don't try to create a new record
            throw new IndexOutOfRangeException("Cannot add any more entries");
        }

        //put the new review in the first empty spot in the array. 
        for (int i = 0; i < Length; i++)
        {
            if (list[i] == null)
            {
                list[i] = restaurant;
                return;
            }
        }
    }

    private bool isFull()
    {
        //Check if the array is full. Used when creating to ensure we don't create a new record if we don't have space.
        for (int i = 0; i < Length; i++)
        {
            if (list[i] == null)
            {
                return false;
            }
        }
        return true;
    }

    public void Print()
    {
        //Prints the list out in a user friendly format.
        for (int i = 0; i < Length; i++)
        {
            if (list[i] != null) //don't print if the line is empty
            {
                Console.WriteLine($"{list[i].Name} : {list[i].Rating} out of 5 stars");
            }
        }
    }

    public string ToFileString()
    {
        //Create the string that will get saved to a file with the name of the restaurant on one line and the rating on the next.
        string file = "";
        foreach (Restaurant r in list)
        {
            if (r != null)
            {
                file += r.Name + "\n" + r.Rating + "\n";
            }
        }
        return file;
    }

    public Restaurant? Find(string name)
    {
        foreach (Restaurant r in list)
        {
            if (r != null)
            {
                if (r.Name == name)
                {
                    return r;
                }
            }
        }
        return null;
    }
}