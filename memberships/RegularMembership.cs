namespace memberships
{
    class RegularMembership : Membership
    {
        public RegularMembership(int id, string email, double cost, double percent) : base(id, email, "regular", cost, percent)
        {

        }

        public override double CashBack()
        {
            double cashBack = CashBackPercent * PurchaseTotal;
            PurchaseTotal = 0;
            return cashBack;
        }
    }
}