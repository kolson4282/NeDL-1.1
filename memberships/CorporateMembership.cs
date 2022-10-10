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
    }
}