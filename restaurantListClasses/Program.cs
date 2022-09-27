namespace RestaurantList;
class Program
{
    static void Main(string[] args)
    {

        //create 2-3 objects of type restaurant
        //print them out.
        //maybe make an array...

        Restaurant myRestaurant = new Restaurant();
        Console.WriteLine($"myRestaurants name is {myRestaurant.Name} and the rating is {myRestaurant.Rating}");
        Restaurant McDonalds = new Restaurant("McDonalds", 2);
        Console.WriteLine($"McDonalds name is {McDonalds.Name} and the rating is {McDonalds.Rating}");

        Restaurant[] myRestaurantString = new Restaurant[5];
        myRestaurantString[0] = new Restaurant("Portillos", 4);
        Console.WriteLine($"myRestaurantString[0]s name is {myRestaurantString[0].Name} and the rating is {myRestaurantString[0].Rating}");


    }
}