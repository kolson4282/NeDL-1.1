namespace memberships
{
    class NonProfitMembership : Membership
    {
        public string OrgType { get; }
        public NonProfitMembership(int id, string email, double cost, double lowPercent, string orgType) : base(id, email, "non-profit", cost, lowPercent)
        {
            OrgType = orgType;
        }

        public override double CashBack()
        {
            double cashBack = PurchaseTotal * CashBackPercent;
            if (OrgType == "military" || OrgType == "education")
            {
                cashBack *= 2;
            }
            PurchaseTotal = 0;
            return cashBack;
        }
    }
}