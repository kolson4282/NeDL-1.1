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

    public override void Withdrawal(double amt)
    {
        double withdrawAmount = amt * (1 + Penalty);
        Console.WriteLine($"There will be a {Penalty * 100}% penalty assessed on this withdrawal.");
        Console.WriteLine($"Total amount to be withdrawn is {withdrawAmount}");
        base.Withdrawal(withdrawAmount); //adds the penalty percentage to the amount being withdrawn. 
    }

    public override string ToString()
    {
        return base.ToString() + $" | Early Withdrawal Penalty: {Penalty * 100}%";
    }
}