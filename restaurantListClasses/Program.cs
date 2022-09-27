//Keith Olson 9/27/22
//Restaurant List
//Requirements:
//Load a list of restaurants and their reviews from a file.
//Save the list of restaurants and their reviews to a file.
//Print out the list.
//Add new entries to the list.
//Update entries on the list.
//Delete entries from the list.

namespace RestaurantList;
class Program
{
    static void Main(string[] args)
    {

        string input;
        string fileName = "reviews.txt";
        RestaurantList list = new RestaurantList();
        do
        {
            input = GetMenuOption();//This will always be upper case. To add an additional option, just need to add a case below.

            switch (input[0])
            {
                case 'O':
                    list = LoadData(fileName);
                    break;
                case 'S':
                    // SaveToFile(fileName, reviews);
                    break;
                case 'C':
                    Restaurant r = GetRestaurantFromUser();
                    list.AddRestaurant(r);
                    break;
                case 'R':
                    list.Print();
                    break;
                case 'U':
                    // UpdateRecord(reviews);
                    break;
                case 'D':
                    // DeleteRecord(reviews);
                    break;
                case 'Q':
                    Console.WriteLine("Good Bye!");
                    break;
                default: //if input is not one of these options, then it is invalid. 
                    Console.WriteLine("That is an invalid choice. Please try again.");
                    break;
            }
        } while (input != "Q");
    }

    static string GetMenuOption()
    {
        //Get Menu Options
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("O: Open the list of restaurants from the file.");
        Console.WriteLine("S: Save the reviews back into the file. (This will overwrite what is already in the file)");
        Console.WriteLine("C: Create a new review.");
        Console.WriteLine("R: Read all restaurant reviews");
        Console.WriteLine("U: Update a review");
        Console.WriteLine("D: Delete a review");
        Console.WriteLine("Q: Quit");

        string input = Console.ReadLine()!.ToUpper(); //guarantees that the input is uppercase
        return input;
    }

    static RestaurantList LoadData(string fileName)
    {
        //Load from file
        RestaurantList list = new RestaurantList();
        try
        {
            using (StreamReader sr = File.OpenText(fileName))
            {
                string? restaurant;
                string? review;
                //read the file line by line and assign to an index in data. 
                while ((restaurant = sr.ReadLine()) != null && (review = sr.ReadLine()) != null) //protects against having a restaurant in the file without a review
                {
                    list.AddRestaurant(new Restaurant(restaurant, Convert.ToInt32(review)));
                }
            }
            Console.WriteLine($"Successfully loaded from file {fileName}");
            list.Print();

        }
        catch (IndexOutOfRangeException)
        {
            //catching an index exception to see if there are too many lines in the file. We still load the first 25 if there is.
            //NOTE: if you save the file after this, only the first 25 lines will be saved, and anything else will be deleted from the file. 
            Console.WriteLine($"There were too many lines in your file. Only loading the first {list.Length}\n");
            list.Print();
        }
        catch (Exception e)
        {
            //any other exception we don't want to return any data. 
            Console.WriteLine("Could not load data.");
            Console.WriteLine(e.Message);
            list = new RestaurantList();
        }
        return list;
    }

    static Restaurant GetRestaurantFromUser()
    {
        string restaurant;
        do
        {
            Console.Write("Enter a restaurant: ");
            restaurant = Console.ReadLine()!;
            if (restaurant == "")
            {
                Console.WriteLine("You must enter a name for a restaurant");
            }
        } while (restaurant == "");

        int rating = GetValidStarRating("Enter a rating between 0 and 5: ");

        return new Restaurant(restaurant, rating);
    }

    static int GetValidStarRating(string prompt)
    {
        //Get a valid rating between 0 and 5
        int rating;
        do
        {
            Console.Write(prompt);
            rating = Convert.ToInt32(Console.ReadLine());
            if (rating < 0 || rating > 5)
            {
                Console.WriteLine("Invalid input");
            }
        } while (rating < 0 || rating > 5);
        return rating;
    }
}