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
        list = new Restaurant[25];
        length = 25;
    }

    public RestaurantList(int arrLength)
    {
        list = new Restaurant[arrLength];
        length = arrLength;
    }

    public void AddRestaurant(Restaurant restaurant)
    {

        //Create new restaurant Review
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
        for (int i = 0; i < Length; i++)
        {
            if (list[i] != null) //don't print if the line is empty
            {
                Console.WriteLine($"{list[i].Name} : {list[i].Rating} out of 5 stars");
            }
        }
    }
}