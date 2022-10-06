class CD : Account, IInterest
{
    public double InterestRate { get; set; }
    public double Penalty { get; set; }

    public CD()
    {
        Penalty = 0;
    }

    public CD(int id, double balance, double rate, double penalty) : base(id, "CD", balance)
    {
        InterestRate = rate;
        Penalty = penalty;
    }

    public override bool Withdrawal(double amt)
    {
        double withdrawAmount = Math.Round(amt * (1 + Penalty), 2); //calculates the withdrawal amount with the penalty added. 
        Console.WriteLine($"There will be a {Penalty * 100}% penalty assessed on this withdrawal.");
        Console.WriteLine($"Total amount to be withdrawn is {withdrawAmount}");
        if (Balance - withdrawAmount < 0)
        {
            Console.WriteLine("Cannot bring your balance below $0");
            return false;
        }

        Console.WriteLine("Are you sure you want to continue? (Y/N)"); //Only continue if answer is "Y" or "y". All else assume a no. 
        string answer = Console.ReadLine()!.ToUpper();
        if (answer != "Y")
        {
            Console.WriteLine("Did not withdraw the amount.");
            return false;
        }
        Balance -= withdrawAmount;
        return true;
    }
    public double CalculateInterest()
    {
        return Math.Round(Balance * InterestRate);
    }

    public override string ToString()
    {
        return base.ToString() + $" | Early Withdrawal Penalty: {Penalty * 100}% | Interest Rate: {InterestRate * 100}% | Annual Interest: ${CalculateInterest()} ";
    }
}