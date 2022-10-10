
//Keith Olson
//10/10/22
//Membership Manager

//Regular membership is 2 percent and $50 a year.
//Executive membership is 5 percent/10% and $100 a year.
//Corporate membership is 5 percent and $50 a year.
//NonProfit membership is 5 percent and $25 a year.
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
        private static int lastID = 0;
        static void Main()
        {
            List<Membership> members = new List<Membership>();
            //test data
            members.Add(new RegularMembership(++lastID, "test@regular.com"));
            members.Add(new CorporateMembership(++lastID, "test@corporate.com"));
            members.Add(new ExecutiveMembership(++lastID, "test@executive.com"));
            members.Add(new NonProfitMembership(++lastID, "test@education.com", "education"));
            members.Add(new NonProfitMembership(++lastID, "test@religious.com", "religious"));
            members.Add(new NonProfitMembership(++lastID, "test@military.com", "military"));

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
                        AddMember(members);
                        break;
                    case "R": //Read
                        PrintList(members);
                        break;
                    case "U": //Update
                        UpdateMember(members);
                        break;
                    case "D": //Delete
                        DeleteMember(members);
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

        private static void AddMember(List<Membership> members)
        {
            Console.WriteLine("What is the customers E-mail address?");
            string email = Console.ReadLine()!;
            Console.WriteLine("What type of membership would you like to add?");
            Console.WriteLine("R: Regular");
            Console.WriteLine("E: Executive");
            Console.WriteLine("C: Corporate");
            Console.WriteLine("P: Non Profit");
            string type = Console.ReadLine()!.ToUpper();
            switch (type)
            {
                case "R":
                    RegularMembership rMember = new RegularMembership(++lastID, email);
                    members.Add(rMember);
                    Console.WriteLine($"You saved ${rMember.GetSpecialOffer()}");
                    break;
                case "E":
                    ExecutiveMembership eMember = new ExecutiveMembership(++lastID, email);
                    members.Add(eMember);
                    Console.WriteLine($"You saved ${eMember.GetSpecialOffer()}");
                    break;
                case "P":
                    Console.WriteLine("What is the type of non-profit");
                    string orgType = Console.ReadLine()!.ToLower();
                    members.Add(new NonProfitMembership(++lastID, email, orgType));
                    break;
                case "C":
                    members.Add(new CorporateMembership(++lastID, email));
                    break;
                default:
                    Console.WriteLine("That is an invalid member type");
                    break;
            }

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
                    Console.WriteLine("R: Regular");
                    Console.WriteLine("E: Executive");
                    Console.WriteLine("C: Corporate");
                    Console.WriteLine("P: Non Profit");
                    string type = Console.ReadLine()!.ToUpper();
                    switch (type)
                    {
                        case "R":
                            members[index] = new RegularMembership(members[index].ID, members[index].Email);
                            break;
                        case "E":
                            members[index] = new ExecutiveMembership(members[index].ID, members[index].Email);
                            break;
                        case "P":
                            Console.WriteLine("What is the type of non-profit");
                            string orgType = Console.ReadLine()!.ToLower();
                            members[index] = new NonProfitMembership(members[index].ID, members[index].Email, orgType);
                            break;
                        case "C":
                            members[index] = new CorporateMembership(members[index].ID, members[index].Email);
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

        private static void DeleteMember(List<Membership> members)
        {
            int index = GetIndexOfMember(members);
            if (index == -1)
            {
                return;
            }
            Console.WriteLine($"You are about to delete member ${members[index].ID}");
            Console.WriteLine(members[index]);
            Console.WriteLine("Are you sure you want to continue? (Y/n)");
            string answer = Console.ReadLine()!.ToUpper();
            if (answer == "Y")
            {
                members.RemoveAt(index);
                Console.WriteLine("Successfully deleted");
            }
            else
            {
                Console.WriteLine($"Did not delete member {members[index].ID}");
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
                Console.WriteLine($"What is the amount of the purchase for membership {member.ID}");
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
                Console.WriteLine($"What is the amount of the return for membership {member.ID}");
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