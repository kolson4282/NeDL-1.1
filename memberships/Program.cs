
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
                        action = PerformAdminAction(members);
                        break;
                    case "T": //Transaction Mode
                        action = PerformTransactionAction(members);
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
        private static string PerformAdminAction(List<Membership> members)
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
                        PrintList(members);
                        break;
                    case "U": //Update
                        UpdateMember(members);
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
        private static string PerformTransactionAction(List<Membership> members)
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
                        PrintList(members);
                        break;
                    case "P": //Purchase
                        Purchase(members);
                        break;
                    case "R": //Return
                        Return(members);
                        break;
                    case "A": //Apply cash back
                        ApplyCashBack(members);
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

        private static Membership? GetMemberByID(List<Membership> members)
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

        private static int GetIndexOfMember(List<Membership> members)
        {
            Console.WriteLine("Please enter the membership ID");
            try
            {
                int id = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < members.Count; i++)
                {
                    if (members[i].ID == id)
                    {
                        return i;
                    }
                }
            }
            catch (FormatException)
            {
            }
            Console.WriteLine("Member not found.");
            return -1;
        }
        private static void PrintList(List<Membership> members)
        {
            foreach (Membership member in members)
            {
                Console.WriteLine(member);
            }
        }

        private static void UpdateMember(List<Membership> members)
        {
            int index = GetIndexOfMember(members);
            if (index == -1)
            {
                return;
            }
            Console.WriteLine("What would you like to update?");
            Console.WriteLine("E: Email");
            Console.WriteLine("T: Type");
            string answer = Console.ReadLine()!.ToUpper();
            switch (answer)
            {
                case "E":
                    Console.WriteLine($"What is the new email for member {members[index].ID}");
                    members[index].Email = Console.ReadLine()!;
                    break;
                case "T":
                    Console.WriteLine($"Membership {members[index].ID} is currently type {members[index].Type}.");
                    Console.WriteLine($"What type would you like to change to?");
                    string type = Console.ReadLine()!.ToLower();
                    switch (type)
                    {
                        case "regular":
                            members[index] = new RegularMembership(members[index].ID, members[index].Email, .01);
                            break;
                        case "executive":
                            members[index] = new ExecutiveMembership(members[index].ID, members[index].Email, .01, .1);
                            break;
                        case "non-profit":
                            Console.WriteLine("What is the type of non-profit");
                            string orgType = Console.ReadLine()!.ToLower();
                            members[index] = new NonProfitMembership(members[index].ID, members[index].Email, .01, orgType);
                            break;
                        case "corporate":
                            members[index] = new CorporateMembership(members[index].ID, members[index].Email, .1);
                            break;
                        default:
                            Console.WriteLine("Invalid Option");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid Option");
                    break;
            }
        }

        private static void Purchase(List<Membership> members)
        {
            Membership? member = GetMemberByID(members);
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

        private static void Return(List<Membership> members)
        {
            Membership? member = GetMemberByID(members);
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

        private static void ApplyCashBack(List<Membership> members)
        {
            Membership? member = GetMemberByID(members);
            if (member == null)
            {
                return;
            }
            Console.WriteLine($"Cash-back reward request for membership {member.ID} int the amount of ${member.CashBack()} has been made");
        }
    }
}