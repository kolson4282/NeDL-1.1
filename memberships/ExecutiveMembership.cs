namespace memberships
{
    class ExecutiveMembership : Membership
    {
        public double HighCashBackPercent { get; }
        public ExecutiveMembership(int id, string email, double lowPercent, double highPercent) : base(id, email, "executive", 100, lowPercent)
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

        public override string ToString()
        {
            return base.ToString() + $" | Cash Back Percent under 1000: %{CashBackPercent * 100} | Cash Back Percent over 1000: %{HighCashBackPercent * 100}";
        }
    }
}