
//Keith Olson
//10/10/22
//Membership Manager
//1. Admin or Transactions?
// If admin:
// 1. Create
// 2. Read
// 3. Update
// 4. Delete

// If Transaction:
// 1. List memberships
// 2. Purchase
// 3. Return (T)
// 4. Cash Back (A)


namespace memberships
{
    class Program
    {
        static void Main()
        {
            List<Membership> members = new List<Membership>();

            //test data until I implement the Create function
            members.Add(new RegularMembership(1, "test@regular.com", .01));
            members.Add(new CorporateMembership(2, "test@corporate.com", .1));
            members.Add(new ExecutiveMembership(2, "test@executive.com", .01, .1));
            members.Add(new NonProfitMembership(2, "test@education.com", .01, "education"));
            members.Add(new NonProfitMembership(2, "test@religious.com", .01, "religious"));
            members.Add(new NonProfitMembership(2, "test@military.com", .01, "military"));

            //figure out which mode to enter.
            //depending on the mode, implement the various functions. 
            string mode;
            do
            {
                mode = MainMenu();
                string action = "";
                switch (mode)
                {
                    case "A":
                        action = PerformAdminAction(members);
                        break;
                    case "T":
                        action = PerformTransactionAction(members);
                        break;
                }
                Console.WriteLine($"Mode : {mode} | Action: {action}");
            } while (mode != "Q");

            Console.WriteLine("Goodbye");
        }

        //Get the mode from the user
        private static string MainMenu()
        {
            string answer = "";
            do
            {
                Console.WriteLine("Would you like to enter Admin(A) or Transaction(T) mode? (type Q to quit)");
                answer = Console.ReadLine()!.ToUpper();
                if (answer != "A" && answer != "T" && answer != "Q")
                {
                    Console.WriteLine("Please enter A for Admin or T for Transactions");
                }
            } while (answer != "A" && answer != "T" && answer != "Q");
            return answer;
        }

        //Get an admin action
        private static string PerformAdminAction(List<Membership> members)
        {
            string answer = "";
            do
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("C: Create");
                Console.WriteLine("R: Read");
                Console.WriteLine("U: Update");
                Console.WriteLine("D: Delete");
                Console.WriteLine("Q: Return to mode selection");
                answer = Console.ReadLine()!.ToUpper();
                switch (answer)
                {
                    case "C":
                        Console.WriteLine("Creating...");
                        break;
                    case "R":
                        PrintList(members);
                        break;
                    case "U":
                        Console.WriteLine("Updating...");
                        break;
                    case "D":
                        Console.WriteLine("Deleting...");
                        break;
                    case "Q":
                        Console.WriteLine("Returning to Mode Selection");
                        break;
                    default:
                        Console.WriteLine("That is an invalid option. Please try again");
                        break;

                }
            } while (answer != "Q");
            return answer;
        }

        private static void PrintList(List<Membership> members)
        {
            foreach (Membership member in members)
            {
                Console.WriteLine(member);
            }
        }

        //get a transaction action
        private static string PerformTransactionAction(List<Membership> members)
        {
            string answer = "";
            do
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("L: List");
                Console.WriteLine("P: Purchase");
                Console.WriteLine("R: Return");
                Console.WriteLine("A: Apply Cash Back");
                Console.WriteLine("Q: Return to mode selection");
                answer = Console.ReadLine()!.ToUpper();
                switch (answer)
                {
                    case "L":
                        PrintList(members);
                        break;
                    case "P":
                        Console.WriteLine("Purchasing...");
                        break;
                    case "R":
                        Console.WriteLine("Returning...");
                        break;
                    case "A":
                        Console.WriteLine("Applying Cash Back...");
                        break;
                    case "Q":
                        Console.WriteLine("Returning to Mode Selection");
                        break;
                    default:
                        Console.WriteLine("That is an invalid option. Please try again");
                        break;

                }
            } while (answer != "Q");
            return answer;
        }
    }
}