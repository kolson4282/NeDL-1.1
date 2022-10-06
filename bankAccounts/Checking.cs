class Checking : Account
{
    public double AnnualFee { get; set; }

    public Checking()
    {
        AnnualFee = 10;
    }

    public Checking(int id, double balance, double fee) : base(id, "Checking", balance)
    {
        AnnualFee = fee;
    }

    public override string ToString()
    {
        return base.ToString() + $" | Annual Fee: ${AnnualFee}";
    }

    public override bool Withdrawal(double amt)
    {
        if (amt > Balance / 2)
        {
            Console.WriteLine($"Can only withdraw up to 50% of your balance. (${Balance / 2})");
            return false;
        }

        Balance -= amt;
        return true;
    }
}