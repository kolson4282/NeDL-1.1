class Savings : Account, IInterest
{
    public double InterestRate { get; set; }

    public Savings()
    {
        InterestRate = 0.05;
    }

    public Savings(int id, double balance, double rate) : base(id, "Savings", balance)
    {
        InterestRate = rate;
    }

    public double CalculateInterest()
    {
        return Math.Round(Balance * InterestRate);
    }

    public override bool Withdrawal(double amt)
    {
        if (Balance - amt < 0)
        {
            Console.WriteLine("Cannot bring your balance below $0");
            return false;
        }
        Balance -= amt;
        return true;
    }

    public override string ToString()
    {
        return base.ToString() + $" | Interest Rate: {InterestRate * 100}% | Annual Interest: ${CalculateInterest()}";
    }
}