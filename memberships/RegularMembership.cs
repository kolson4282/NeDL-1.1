namespace memberships
{
    class RegularMembership : Membership, ISpecialOffer
    {
        public RegularMembership(int id, string email, double percent) : base(id, email, "regular", 50, percent)
        {

        }

        public double GetSpecialOffer()
        {
            return AnnualCost * .25;
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