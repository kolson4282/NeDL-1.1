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
            input = GetMenuOption();

            switch (input[0])
            {
                case 'O':
                    list = LoadData(fileName);
                    break;
                case 'S':
                    // SaveToFile(fileName, reviews);
                    break;
                case 'C':
                    // CreateNewRecord(reviews);
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
            }
        } while (input != "Q");
    }

    static string GetMenuOption()
    {
        //Get Menu Options
        string input;
        do
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("O: Open the list of restaurants from the file.");
            Console.WriteLine("S: Save the reviews back into the file. (This will overwrite what is already in the file)");
            Console.WriteLine("C: Create a new review.");
            Console.WriteLine("R: Read all restaurant reviews");
            Console.WriteLine("U: Update a review");
            Console.WriteLine("D: Delete a review");
            Console.WriteLine("Q: Quit");
            input = Console.ReadLine()!.ToUpper(); //guarantees that the input is uppercase
            if (!IsValid(input))
            {
                Console.WriteLine("That was an invalid choice. Please try again.");
            }
        } while (!IsValid(input));
        return input;
    }

    static bool IsValid(string input)
    {
        //check if the first character of the input is a valid option. Only checking the first character to allow the user more flexibility on what to enter.
        return input[0] == 'O' || input[0] == 'S' || input[0] == 'C' || input[0] == 'R' || input[0] == 'U' || input[0] == 'D' || input[0] == 'Q';
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
}