//Keith Olson
//10/6/22
//Bank Account Manager.

//Three types of accounts (Checking, Savings, CD)
//Have a list of accounts
//Want to be able to print out all of the accounts
//Deposit into a specified account
//Withdraw from a specified account
//Keep going until the user selects Quit. 

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
                case "L": //List
                    PrintList(accounts);
                    WaitForKey();
                    break;
                case "D": //Deposit
                    Deposit(accounts);
                    WaitForKey();
                    break;
                case "W": //Withdraw
                    Withdraw(accounts);
                    WaitForKey();
                    break;
                case "Q": //Quit
                    Console.WriteLine("Goodbye");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        } while (input != "Q");
    }//End main

    private static List<Account> FillList()
    {
        List<Account> accounts = new List<Account>();

        accounts.Add(new Checking(1, 1000, 20));
        accounts.Add(new Savings(2, 1000, .005));
        accounts.Add(new Checking(3, 100000, 10));
        accounts.Add(new CD(4, 1000000, .01, .10));
        accounts.Add(new Savings(5, 3000, .005));
        accounts.Add(new CD(6, 1000, .01, .10));
        return accounts;
    }//End FillList

    private static string GetOption()
    {
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("L: List accounts");
        Console.WriteLine("D: Deposit into an account");
        Console.WriteLine("W: Withdraw from an account");
        Console.WriteLine("Q: Quit");
        string input = Console.ReadLine()!.ToUpper();

        return input;
    }//End GetOption

    private static void WaitForKey()
    {
        // Wait for a user to hit a key to continue. 
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
        Console.WriteLine();
    }//End WaitForKey

    private static void PrintList(List<Account> accounts)
    {
        foreach (Account a in accounts)
        {
            Console.WriteLine(a);
        }
        Console.WriteLine();
    }//End PrintList

    private static void Deposit(List<Account> accounts)
    {
        PrintList(accounts);
        Console.Write("What is the ID of the account you would like to deposit into? ");
        int id = Convert.ToInt32(Console.ReadLine());

        Account? acct = Search(accounts, id);
        if (acct == null)
        {
            Console.WriteLine($"Couldn't find an account with ID {id}");
        }
        else
        {
            double amt;
            do
            {
                Console.WriteLine("How much would you like to deposit?");
                amt = Convert.ToDouble(Console.ReadLine());
                if (amt < 0)
                {
                    Console.WriteLine("Must enter a positive number.");
                }
            } while (amt < 0);
            acct.Deposit(amt);
            Console.WriteLine($"Deposited ${amt}");
            Console.WriteLine(acct);
        }
    }//End Deposit

    private static void Withdraw(List<Account> accounts)
    {
        PrintList(accounts);
        Console.Write("What is the ID of the account you would like to withdraw from? ");
        int id = Convert.ToInt32(Console.ReadLine());

        Account? acct = Search(accounts, id);
        if (acct == null)
        {
            Console.WriteLine($"Couldn't find an account with ID {id}");
        }
        else
        {
            double amt;
            do
            {
                Console.WriteLine("How much would you like to Withdraw?");
                amt = Convert.ToDouble(Console.ReadLine());
                if (amt < 0)
                {
                    Console.WriteLine("Must enter a positive number.");
                }
            } while (amt < 0);
            bool withdrawn = acct.Withdrawal(amt);
            if (withdrawn)
            {
                Console.WriteLine($"Please take your ${amt}");
            }
            Console.WriteLine(acct);
        }
    }//End Withdraw

    private static Account? Search(List<Account> accounts, int id)
    {
        //searches for a specified ID and if not found returns null
        Account? acct = null;
        foreach (Account a in accounts)
        {
            if (a.ID == id)
            {
                acct = a;
                break;
            }
        }
        return acct;
    }//End Search
}