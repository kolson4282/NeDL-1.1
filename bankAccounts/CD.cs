class CD : Savings
{
    public double Penalty { get; set; }

    public CD()
    {
        Penalty = 0;
    }

    public CD(int id, double balance, double rate, double penalty) : base(id, balance, rate, "CD")
    {
        Penalty = penalty;
    }

    public override bool Withdrawal(double amt)
    {
        double withdrawAmount = Math.Round(amt * (1 + Penalty), 2);
        Console.WriteLine($"There will be a {Penalty * 100}% penalty assessed on this withdrawal.");
        Console.WriteLine($"Total amount to be removed is {withdrawAmount}");
        return base.Withdrawal(withdrawAmount); //adds the penalty percentage to the amount being withdrawn. 
    }

    public override string ToString()
    {
        return base.ToString() + $" | Early Withdrawal Penalty: {Penalty * 100}%";
    }
}