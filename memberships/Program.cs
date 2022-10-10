
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
        private static List<Membership> members = new List<Membership>();
        static void Main()
        {
            //test data until I implement the Create function
            members.Add(new RegularMembership(1, "test@regular.com", .01));
            members.Add(new CorporateMembership(2, "test@corporate.com", .1));
            members.Add(new ExecutiveMembership(3, "test@executive.com", .01, .1));
            members.Add(new NonProfitMembership(4, "test@education.com", .01, "education"));
            members.Add(new NonProfitMembership(5, "test@religious.com", .01, "religious"));
            members.Add(new NonProfitMembership(6, "test@military.com", .01, "military"));

            //figure out which mode to enter.
            //depending on the mode, implement the various functions. 
            string mode;
            do
            {
                Console.WriteLine("Would you like to enter Admin(A) or Transaction(T) mode? (type Q to quit)");
                mode = Console.ReadLine()!.ToUpper();
                string action = "";
                switch (mode)
                {
                    case "A": //Admin Mode
                        action = PerformAdminAction();
                        break;
                    case "T": //Transaction Mode
                        action = PerformTransactionAction();
                        break;
                    case "Q":
                        Console.WriteLine("Goodbye");
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            } while (mode != "Q");

        }

        //Get an admin action
        //Will stay in Admin mode until the user quits out to the mode selection
        private static string PerformAdminAction()
        {
            string answer = "";
            do
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("C: Create a new member");
                Console.WriteLine("R: Read the list of members");
                Console.WriteLine("U: Update a member");
                Console.WriteLine("D: Delete a member");
                Console.WriteLine("Q: Return to mode selection");
                answer = Console.ReadLine()!.ToUpper();
                switch (answer)
                {
                    case "C": //Create
                        Console.WriteLine("Creating...");
                        break;
                    case "R": //Read
                        PrintList();
                        break;
                    case "U": //Update
                        Console.WriteLine("Updating...");
                        break;
                    case "D": //Delete
                        Console.WriteLine("Deleting...");
                        break;
                    case "Q": //Return to Mode selection
                        Console.WriteLine("Returning to Mode Selection");
                        break;
                    default:
                        Console.WriteLine("That is an invalid option. Please try again");
                        break;

                }
            } while (answer != "Q");
            return answer;
        }

        //get a transaction action
        //Will stay in transaction mode until the user quits out to the mode selection
        private static string PerformTransactionAction()
        {
            string answer = "";
            do
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("L: List all members");
                Console.WriteLine("P: Add a Purchase to a membership");
                Console.WriteLine("R: Add a Return to a membership");
                Console.WriteLine("A: Apply the Cashback on a membership");
                Console.WriteLine("Q: Return to mode selection");
                answer = Console.ReadLine()!.ToUpper();
                switch (answer)
                {
                    case "L": //List
                        PrintList();
                        break;
                    case "P": //Purchase
                        Purchase();
                        break;
                    case "R": //Return
                        Return();
                        break;
                    case "A": //Apply cash back
                        Console.WriteLine("Applying Cash Back...");
                        break;
                    case "Q": //Quit to mode selection
                        Console.WriteLine("Returning to Mode Selection");
                        break;
                    default:
                        Console.WriteLine("That is an invalid option. Please try again");
                        break;

                }
            } while (answer != "Q");
            return answer;
        }

        private static Membership? GetMemberByID()
        {
            Console.WriteLine("Please enter the membership ID");
            try
            {
                int id = Convert.ToInt32(Console.ReadLine());
                foreach (Membership member in members)
                {
                    if (member.ID == id)
                    {
                        return member;
                    }
                }
            }
            catch (FormatException)
            {
            }
            Console.WriteLine("Member not found.");
            return null;
        }
        private static void PrintList()
        {
            foreach (Membership member in members)
            {
                Console.WriteLine(member);
            }
        }


        private static void Purchase()
        {
            Membership? member = GetMemberByID();
            if (member == null)
            {
                return;
            }
            double amt = -1;
            do
            {
                Console.WriteLine($"What is the amount of the purchase you would like to add to membership {member.ID}");
                try
                {
                    amt = Convert.ToDouble(Console.ReadLine());
                    if (amt < 0)
                    {
                        Console.WriteLine("Purchase amount must be greater than 0.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Amount must be a numeric value greater than 0");
                }

            } while (amt < 0);
            member.Purchase(amt);
        }

        private static void Return()
        {
            Membership? member = GetMemberByID();
            if (member == null)
            {
                return;
            }
            double amt = -1;
            do
            {
                Console.WriteLine($"What is the amount of the return you would like to remove from membership {member.ID}");
                try
                {
                    amt = Convert.ToDouble(Console.ReadLine());
                    if (amt < 0)
                    {
                        Console.WriteLine("Return amount must be greater than 0.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Amount must be a numeric value greater than 0");
                }

            } while (amt < 0);
            member.Return(amt);
        }
    }
}