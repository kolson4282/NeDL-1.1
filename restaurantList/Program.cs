using System;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            string[,] reviews = new string[25, 2];
            string fileName = "reviews.txt";
            do
            {
                input = GetMenuOption();

                switch (input[0])
                {
                    case 'O':
                        reviews = LoadData(fileName);
                        break;
                    case 'S':
                        SaveToFile(fileName, reviews);
                        break;
                    case 'C':
                        CreateNewRecord(reviews);
                        break;
                    case 'R':
                        PrintData(reviews);
                        break;
                    case 'U':
                        UpdateRecord(reviews);
                        break;
                    case 'D':
                        DeleteRecord(reviews);
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

        static string[,] LoadData(string fileName)
        {
            //Load from file
            string[,] data = new string[25, 2];
            try
            {
                int index = 0;
                using (StreamReader sr = File.OpenText(fileName))
                {
                    string? restaurant = "";
                    string? review = "";
                    //read the file line by line and assign to an index in data. 
                    while ((restaurant = sr.ReadLine()) != null && (review = sr.ReadLine()) != null) //protects against having a restaurant in the file without a review
                    {
                        data[index, 0] = restaurant;
                        data[index, 1] = review;
                        index++;
                    }
                }
                Console.WriteLine($"Successfully loaded from file {fileName}");
                PrintData(data);

            }
            catch (IndexOutOfRangeException)
            {
                //catching an index exception to see if there are too many lines in the file. We still load the first 25 if there is.
                //NOTE: if you save the file after this, only the first 25 lines will be saved, and anything else will be deleted from the file. 
                Console.WriteLine("There were too many lines in your file. Only loading the first 25\n");
                PrintData(data);
            }
            catch (Exception e)
            {
                //any other exception we don't want to return any data. 
                Console.WriteLine("Could not load data.");
                Console.WriteLine(e.Message);
                data = new string[25, 2];
            }
            return data;
        }

        //Save to File
        static void SaveToFile(string fileName, string[,] data)
        {
            //don't save if it's empty so as not to overwrite a file that might have data in it. 
            if (isEmpty(data))
            {
                Console.WriteLine("Your file will be empty. Are you sure you want to save? (y/n)");
                string answer = Console.ReadLine()!.ToUpper();
                if (answer != "y" && answer != "Y")
                {
                    Console.WriteLine("Did not write to the file");
                    return;
                }
            }
            using StreamWriter sr = new(fileName);

            for (int i = 0; i < data.GetLength(0); i++)
            {
                if (data[i, 0] != null && data[i, 0] != "")
                {
                    //Wrting two lines for every piece of data. 
                    sr.WriteLine(data[i, 0]);
                    sr.WriteLine(data[i, 1]);
                }
            }

            Console.WriteLine($"Successfully wrote to file {fileName}");

        }

        static bool isEmpty(string[,] data)
        {
            // Check if the array is empty. Only checking the restaurant names as it's assumed if the restaurant is there, so is the review. 
            for (int i = 0; i < data.GetLength(0); i++)
            {
                if (data[i, 0] != null && data[i, 0] != "")
                {
                    return false;
                }
            }
            return true;
        }

        static void PrintData(string[,] data)
        {
            //Read from array - Print Array
            if (isEmpty(data))
            {
                Console.WriteLine("No data available. Try Loading from a file or create new reviews.");
            }
            for (int i = 0; i < data.GetLength(0); i++)
            {
                if (data[i, 0] != null && data[i, 0] != "") //don't print if the line is empty
                {
                    Console.WriteLine($"{data[i, 0]} : {data[i, 1]} out of 5 stars");
                }
            }
        }

        static bool isFull(string[,] data)
        {
            //Check if the array is full. Used when creating to ensure we don't create a new record if we don't have space.
            for (int i = 0; i < data.GetLength(0); i++)
            {
                if (data[i, 0] == null || data[i, 0] == "")
                {
                    return false;
                }
            }
            return true;
        }

        static void CreateNewRecord(string[,] data)
        {
            //Create new restaurant Review
            if (isFull(data))
            {
                //if the array is full. Don't try to create a new record
                Console.WriteLine($"Unable to add the new review. You can only have {data.GetLength(0)} restaurants in the array");
                return;
            }

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

            string rating = GetValidStarRating("Enter a rating between 0 and 5: ");

            //put the new review in the first empty spot in the array. 
            for (int i = 0; i < data.GetLength(0); i++)
            {
                if (data[i, 0] == null || data[i, 0] == "")
                {
                    data[i, 0] = restaurant;
                    data[i, 1] = rating;
                    return;
                }
            }
        }

        static string GetValidStarRating(string prompt)
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
            return rating.ToString();
        }

        static void UpdateRecord(string[,] data)
        {
            //Update a rating
            if (isEmpty(data))
            {
                Console.WriteLine("Nothing in the list to update.");
                return;
            }

            PrintData(data);
            string input;
            Console.Write("Enter the name of the restaurant you would like to update: ");
            input = Console.ReadLine()!;
            for (int i = 0; i < data.GetLength(0); i++)
            {
                //find the first instance of the restaurant to be updated and update it. If there are more than one instances, update the first. 
                if ((data[i, 0] != null && data[i, 0] != "") && data[i, 0].ToUpper() == input.ToUpper())
                {
                    string rating = GetValidStarRating($"Current review is {data[i, 1]}. What would you like to change it to (0-5 stars): ");
                    data[i, 1] = rating;
                    return;
                }
            }
            Console.WriteLine($"Didn't find the record {input}. Please try again");
        }

        static void DeleteRecord(string[,] data)
        {
            //Delete a restaurant
            if (isEmpty(data))
            {
                Console.WriteLine("Nothing in the list to delete.");
                return;
            }

            PrintData(data);
            string input;
            Console.Write("Enter the name of the restaurant you would like to delete: ");
            input = Console.ReadLine()!;
            bool found = false;
            for (int i = 0; i < data.GetLength(0); i++)
            {
                if (found)
                {
                    //if a record was found and deleted. Move everything else up one space.
                    if (data[i, 0] != null && data[i, 0] != "")
                    {
                        data[i - 1, 0] = data[i, 0];
                        data[i - 1, 1] = data[i, 1];
                    }
                    else
                    {
                        data[i - 1, 0] = data[i - 1, 1] = "";
                    }
                }
                //find the first instance of the restaurant to be deleted and delete it. If there are more than one instances, delete the first. 
                if ((data[i, 0] != null && data[i, 0] != "") && data[i, 0].ToUpper() == input.ToUpper())
                {
                    //if record is found. Set it to ""
                    data[i, 0] = "";
                    data[i, 1] = "";
                    found = true;
                }

            }
            if (!found)
            {
                Console.WriteLine($"Didn't find the record {input}. Please try again");
            }
        }
    }
}