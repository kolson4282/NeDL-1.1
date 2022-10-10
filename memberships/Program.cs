namespace memberships
{
    class Program
    {
        static void Main()
        {
            List<Membership> members = new List<Membership>();
            members.Add(new RegularMembership(1, "test@regular.com", 50, .01));
            members.Add(new CorporateMembership(2, "test@corporate.com", 100, .1));
            members.Add(new ExecutiveMembership(2, "test@executive.com", 100, .01, .1));
            members.Add(new NonProfitMembership(2, "test@education.com", 100, .01, "education"));
            members.Add(new NonProfitMembership(2, "test@religious.com", 100, .01, "religious"));
            members.Add(new NonProfitMembership(2, "test@military.com", 100, .01, "military"));

            foreach (Membership member in members)
            {
                member.Purchase(1000);
                member.Return(50);
                Console.WriteLine(member);
                Console.WriteLine($"Cashback for {member.ID} is ${member.CashBack()}");
                Console.WriteLine(member);
                member.Purchase(1500);
                Console.WriteLine(member);
                Console.WriteLine($"Cashback for {member.ID} is now ${member.CashBack()}");

                Console.WriteLine();
            }
        }
    }
}