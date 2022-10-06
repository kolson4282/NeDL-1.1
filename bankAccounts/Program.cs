class Program
{
    static void Main(string[] Args)
    {
        List<Account> accounts = FillList();

        string input;
        do
        {
            input = GetOption();

            switch (input)
            {
                case "L":
                    PrintList(accounts);
                    break;
                case "D":
                    Deposit(accounts);
                    break;
                case "W":
                    Withdraw(accounts);
                    break;
                case "Q":
                    Console.WriteLine("Goodbye");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        } while (input != "Q");
    }

    private static List<Account> FillList()
    {
        List<Account> accounts = new List<Account>();

        accounts.Add(new Checking(1, 1000, 20));
        accounts.Add(new Savings(2, 1000, .005));
        accounts.Add(new Checking(3, 100000, 10));
        accounts.Add(new CD(4, 1000000, .01, .10));
        accounts.Add(new Savings(2, 3000, .005));
        accounts.Add(new CD(4, 1000, .01, .10));
        return accounts;
    }

    private static string GetOption()
    {
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("L: List accounts");
        Console.WriteLine("D: Deposit into an account");
        Console.WriteLine("W: Withdraw from an account");
        Console.WriteLine("Q: Quit");
        string input = Console.ReadLine()!.ToUpper();

        return input;
    }

    private static void WaitForKey()
    {
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
        Console.WriteLine();
    }
    private static void PrintList(List<Account> accounts)
    {
        foreach (Account a in accounts)
        {
            Console.WriteLine(a);
        }
        WaitForKey();
    }

    private static void Deposit(List<Account> accounts)
    {
        Console.WriteLine("Depositing...");
        WaitForKey();
    }
    private static void Withdraw(List<Account> accounts)
    {
        Console.WriteLine("Withdrawing...");
        WaitForKey();
    }
}