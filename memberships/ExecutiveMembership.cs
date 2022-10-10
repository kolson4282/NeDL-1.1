namespace memberships
{
    class ExecutiveMembership : Membership, ISpecialOffer
    {
        public double HighCashBackPercent { get; }
        public ExecutiveMembership(int id, string email) : base(id, email, "executive", 100, .05)
        {
            HighCashBackPercent = .10;
        }

        public double GetSpecialOffer()
        {
            return AnnualCost * .25;
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