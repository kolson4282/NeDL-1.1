abstract class Account
{
    public int ID { get; }
    public string Type { get; set; }
    public double Balance { get; set; }

    public Account()
    {
        ID = -1;
        Type = "N/A";
        Balance = 0;
    }

    public Account(int id, string type, double balance)
    {
        ID = id;
        Type = type;
        Balance = balance;
    }

    public void Deposit(double amt)
    {
        Balance += amt;
    }

    public abstract bool Withdrawal(double amt);

    public override string ToString()
    {
        return $"ID: {ID} | Type: {Type} | Balance: ${Balance}";
    }
}