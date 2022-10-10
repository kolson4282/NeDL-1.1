namespace memberships
{
    class RegularMembership : Membership
    {
        public RegularMembership(int id, string email, double cost, double percent) : base(id, email, "regular", cost, percent)
        {

        }
    }
}