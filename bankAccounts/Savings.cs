class Savings : Account, IInterest
{
    public double InterestRate { get; set; }

    public Savings()
    {
        InterestRate = 0.05;
    }

    public Savings(int id, double balance, double rate, string type = "savings") : base(id, type, balance)
    {
        InterestRate = rate;
    }

    public double CalculateInterest()
    {
        return Balance * InterestRate;
    }

    public override void Withdrawal(double amt)
    {
        if (Balance - amt < 0)
        {
            Console.WriteLine("Cannot bring your balance below $0");
        }
        else
        {
            Balance -= amt;
        }
    }

    public override string ToString()
    {
        return base.ToString() + $" | Interest Rate: {InterestRate * 100}% | Annual Interest: ${CalculateInterest()}";
    }
}