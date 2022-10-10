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
            if (shouldDouble())
            {
                cashBack *= 2;
            }
            PurchaseTotal = 0;
            return cashBack;
        }

        public override string ToString()
        {
            return base.ToString() + $" | Organization Type: {OrgType} | Cash Back Percent: %{(shouldDouble() ? 2 * CashBackPercent : CashBackPercent) * 100}";
        }

        private bool shouldDouble()
        {
            return OrgType == "military" || OrgType == "education";
        }
    }
}