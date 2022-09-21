using System;
using System.IO;

//Start with a menu
//  Load into array
//  Store array into a file
//  Create new records
//  Read all records
//  Update a record
//  Delete a record

namespace files
{
    class Program
    {
        static void Main()
        {
            string input;
            string[] names = new string[20];
            string fileName = "names.txt";
            do
            {
                input = GetMenuOption();

                switch (input)
                {
                    case "L":
                        names = LoadData(fileName);
                        break;
                    case "S":
                        SaveData(names, fileName);
                        break;
                    case "C":
                        CreateNewRecord(names);
                        break;
                    case "R":
                        PrintData(names);
                        break;
                    case "U":
                        UpdateRecord(names);
                        break;
                    case "D":
                        DeleteRecord(names);
                        break;
                    case "Q":
                        Console.WriteLine("Good Bye!");
                        break;
                }
            } while (input != "Q");
        }

        static string GetMenuOption()
        {
            string input;
            do
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("L: Load data from the file.");
                Console.WriteLine("S: Save the data back into the file.");
                Console.WriteLine("C: Create a new record.");
                Console.WriteLine("R: Read all records");
                Console.WriteLine("U: Update a record");
                Console.WriteLine("D: Delete a record");
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
            return input == "L" || input == "S" || input == "C" || input == "R" || input == "U" || input == "D" || input == "Q";
        }

        static bool IsEmpty(string[] data)
        {
            //if all of the enteries in the data are null or "", return true so as not to try to do things to an empty array. 
            foreach (string s in data)
            {
                if (s != null && s != "")
                {
                    return false;
                }
            }
            return true;
        }

        static string[] LoadData(string fileName)
        {
            string[] data = new string[20];
            try
            {
                int index = 0;
                using (StreamReader sr = File.OpenText(fileName))
                {
                    string? s = "";
                    //read the file line by line and assign to an index in data. 
                    while ((s = sr.ReadLine()) != null)
                    {
                        data[index] = s;
                        index++;
                    }
                }
                PrintData(data);

            }
            catch (Exception e)
            {
                Console.WriteLine("Could not load data.");
                Console.WriteLine(e.Message);
            }
            return data;
        }

        static void SaveData(string[] data, string fileName)
        {
            //don't save if it's empty so as not to overwrite a file that might have data in it. 
            if (IsEmpty(data))
            {
                Console.WriteLine("Your file will be empty. Are you sure you want to save? (y/n)");
                string answer = Console.ReadLine()!.ToUpper();
                if (answer == "y")
                {
                    File.WriteAllText(fileName, "");
                }
                return;
            }

            File.WriteAllLines(fileName, data);
        }

        static void PrintData(string[] data)
        {
            if (IsEmpty(data))
            {
                Console.WriteLine("Array is empty. Try Loading data in.");
                return;
            }

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] != null && data[i] != "")
                {
                    //printing the indcex with the name to make updating easier. 
                    Console.WriteLine(i + ". " + data[i]);
                }
            }

        }

        static int CreateNewRecord(string[] data)
        {
            Console.Write("Enter a name: ");
            string input = Console.ReadLine()!;
            //put the new name in the first empty index of the array. 
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == null || data[i] == "")
                {
                    data[i] = input;
                    return 0;
                }
            }
            Console.WriteLine("Unable to add the new name. You can only have 20 names in the array");
            return 1;
        }

        static void UpdateRecord(string[] data)
        {
            PrintData(data);
            int index;
            do
            {
                Console.WriteLine("Enter the index of the name you need to update: ");
                index = Convert.ToInt32(Console.ReadLine());
                if (index < 0 || index > data.Length)
                {
                    Console.WriteLine("Invalid index");
                }
            } while (index < 0 || index > data.Length);

            string name;
            do
            {
                Console.WriteLine("What should the name be?");
                name = Console.ReadLine()!;
                if (name == "")
                {
                    Console.WriteLine("You didn't type in a name. Please try again.");
                }
            } while (name == "");

            data[index] = name;
        }

        static void DeleteRecord(string[] data)
        {
            PrintData(data);
            Console.WriteLine("Enter the name of the person you want to delete.");
            string name = Console.ReadLine()!;

            //change the first name in the array that matches the entered name to "" and then move that to the end of the array. 
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == name)
                {
                    data[i] = "";
                    MoveEmptyToEnd(data);
                    return;
                }
            }

            Console.WriteLine($"{name} was not found.");
        }

        static void MoveEmptyToEnd(string[] data)
        {
            int[] nonEmptyIndexes = new int[data.Length];
            Array.Fill(nonEmptyIndexes, -1);
            int index = 0;
            //Get a list of all of the indexes that have data in them. 
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] != null && data[i] != "")
                {
                    nonEmptyIndexes[index] = i;
                    index++;
                }

            }

            string[] newData = new string[data.Length];
            int newIndex = 0;
            //create a new array with the data in the the beginning and nothing at the other indexes
            foreach (int i in nonEmptyIndexes)
            {
                if (i >= 0)
                {
                    newData[newIndex] = data[i];
                    newIndex++;
                }
            }

            //copy newData over to Data index by index so as to update the original array. 
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = newData[i];
            }
        }
    }
}