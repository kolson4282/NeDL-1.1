namespace memberships
{
    class RegularMembership : Membership
    {
        public RegularMembership(int id, string email, double percent) : base(id, email, "regular", 50, percent)
        {

        }

        public override double CashBack()
        {
            double cashBack = CashBackPercent * PurchaseTotal;
            PurchaseTotal = 0;
            return cashBack;
        }

        public override string ToString()
        {
            return base.ToString() + $" | Cash Back Percent: %{CashBackPercent * 100}";
        }
    }
}