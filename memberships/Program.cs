namespace memberships
{
    class Program
    {
        static void Main()
        {
            List<Membership> members = new List<Membership>();
            members.Add(new RegularMembership(1, "test", 50, .02));

            foreach (Membership member in members)
            {
                member.Purchase(100);
                member.Return(50);
                Console.WriteLine(member);
                Console.WriteLine($"Cashback for {member.ID} is ${member.CashBack()}");
                Console.WriteLine(member);
            }
        }
    }
}