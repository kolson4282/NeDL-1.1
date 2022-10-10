namespace memberships
{
    class CorporateMembership : Membership
    {
        public CorporateMembership(int id, string email, double cost, double percent) : base(id, email, "corporate", cost, percent)
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