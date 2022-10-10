namespace memberships
{
    abstract class Membership
    {
        public int ID { get; }
        public string Email { get; set; }
        public string Type { get; }
        public double AnnualCost { get; }
        public double PurchaseTotal { get; set; }
        public double CashBackPercent;

        public Membership(int id, string email, string type, double cost, double percent)
        {
            ID = id;
            Email = email;
            Type = type;
            AnnualCost = cost;
            PurchaseTotal = 0;
            CashBackPercent = percent;
        }

        public void Purchase(double amt)
        {

            PurchaseTotal += amt;
        }

        public void Return(double amt)
        {
            if (PurchaseTotal - amt < 0)
            {
                Console.WriteLine("Purchase Total cannot be less than 0");
                Console.WriteLine("Return was not processed");
                return;
            }
            PurchaseTotal -= amt;
        }

        public override string ToString()
        {
            return $"ID: {ID} | Type: {Type} | Email: {Email} | Cost: ${AnnualCost} | PurchaseTotal: ${PurchaseTotal}";
        }

        public abstract double CashBack();
    }
}