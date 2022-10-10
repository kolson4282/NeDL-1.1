namespace memberships
{
    class ExecutiveMembership : Membership
    {
        public double HighCashBackPercent { get; }
        public ExecutiveMembership(int id, string email, double cost, double lowPercent, double highPercent) : base(id, email, "executive", cost, lowPercent)
        {
            HighCashBackPercent = highPercent;
        }

        public override double CashBack()
        {
            double cashBack;
            if (PurchaseTotal < 1000)
            {
                cashBack = PurchaseTotal * CashBackPercent;
            }
            else
            {
                cashBack = PurchaseTotal * HighCashBackPercent;
            }
            PurchaseTotal = 0;
            return cashBack;
        }
    }
}