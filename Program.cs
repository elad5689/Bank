using System;

namespace Task_5
{
    class Program
    {
        static void Main(string[] args)
        {
            char choice = '0';
            Bank ruppinBank = new Bank(10);

            while (choice != 'Q' && choice != 'q')
            {
                try
                {
                    Console.WriteLine("\n\nWelcome to bank system");
                    Console.WriteLine("Add regular account - press A");
                    Console.WriteLine("Add business account - press B");
                    Console.WriteLine("Close regular account - press C");
                    Console.WriteLine("Close business account - press E");
                    Console.WriteLine("Deposit money in account - press D");
                    Console.WriteLine("Withdraw money from account - press W");
                    Console.WriteLine("Month Elapsed - press M");
                    Console.WriteLine("Total bank balance - press X");
                    Console.WriteLine("Get accounts details - press L");
                    Console.WriteLine("Exit - press Q");
                    Console.Write("Enter your choice: ");

                    choice = char.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 'A':
                        case 'a':
                            ruppinBank.AddAccount(GetDeatilsNewAccount());
                            break;

                        case 'B':
                        case 'b':
                            ruppinBank.AddBusinessAccount(GetDeatilsNewBusinessAccount());
                            break;

                        case 'C':
                        case 'c':
                            Console.Write("Enter the name of the account you want to close: ");
                            ruppinBank.CloseBankAccount(ruppinBank.GetBankAccount(Console.ReadLine()));
                            break;

                        case 'E':
                        case 'e':
                            Console.Write("Enter the name of the account you want to close: ");
                            ruppinBank.CloseBusinessAccount(ruppinBank.GetBusinessBankAccount(Console.ReadLine()));
                            break;

                        case 'D':
                        case 'd':
                     
                        case 'W':
                        case 'w':
                            GetDetailsForDepositWithdrawl(ref ruppinBank, true);
                            break;

                        case 'M':
                        case 'm':
                            ruppinBank.MonthElapsed();
                            break;

                        case 'X':
                        case 'x':
                            Console.WriteLine("\nTotal amount in the bank: " + ruppinBank.getAssets());
                            break;

                        case 'L':
                        case 'l':
                            ruppinBank.PrintDetails();
                            break;
                    }
                }
                catch(IndexOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(InvalidOperationException ex1)
                {
                    Console.WriteLine(ex1.Message);
                }
                catch(FormatException)
                {
                    Console.WriteLine("\nFormatException - you entered a wrong format");
                }
                catch (ArgumentException ex2)
                {
                    Console.WriteLine(ex2.Message);
                }
            }
        }

        //let the user input details for new regular account
        static BankAccount GetDeatilsNewAccount()
        {
            Console.Write("Enter account name: ");
            string name = Console.ReadLine();

            Console.Write("Enter current amount: ");
            double amount = double.Parse(Console.ReadLine());

            Console.Write("Enter limit to the account: ");
            double limit = double.Parse(Console.ReadLine());

            BankAccount tmp = new BankAccount(name, amount, limit);

            return tmp;
        }

        //let the user input details for new business account
        static BusinessBankAccount GetDeatilsNewBusinessAccount()
        {
            Console.Write("Enter account name: ");
            string name = Console.ReadLine();

            Console.Write("Enter current amount: ");
            double amount = double.Parse(Console.ReadLine());

            BusinessBankAccount tmp = new BusinessBankAccount(name, amount);

            return tmp;
        }

        //let the user choose between regular and business account
        //used for Withdrawl and Deposit
        static void GetDetailsForDepositWithdrawl(ref Bank bank, bool withdraw)
        {
            try
            {
                Console.Write("\nPress - 1 for regular account\nPress - 2 for business account");
                Console.Write("\nEnter your choice: ");
                int x = int.Parse(Console.ReadLine());
                if (x != 1 && x != 2)
                {
                    throw new ArgumentException("\nArgumentException - I told you to choose 1 or 2");
                }
                if (x == 1)
                {
                    if(!withdraw)
                    {
                        DepositToAccount(ref bank, false);
                    }
                    else
                    {
                        WithdrawMoney(ref bank, false);
                    }
                }
                else
                {
                    if (!withdraw)
                    {
                        DepositToAccount(ref bank, true);
                    }
                    else
                    {
                        WithdrawMoney(ref bank, true);
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("\nFormatException - I told you to choose 1 or 2");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //let the user input details for deposit to account
        static void DepositToAccount(ref Bank bank, bool isBusiness)
        {
            Console.Write("Enter the name of the account you want to deposit to: ");
            if(!isBusiness)
            {
                BankAccount tmp = bank.GetBankAccount(Console.ReadLine());
                Console.Write("Enter the amount you want to deposit: ");
                tmp.Deposit(double.Parse(Console.ReadLine()));
                Console.WriteLine("Your amount after the deposit: ");
                bank.PrintBalance(tmp.AccountNum);
            }
            else
            {
                BusinessBankAccount tmp = bank.GetBusinessBankAccount(Console.ReadLine());
                Console.Write("Enter the amount you want to deposit: ");
                tmp.Deposit(double.Parse(Console.ReadLine()));
                Console.WriteLine("Your amount after the deposit: ");
                bank.PrintBalance(tmp.AccountNum);
            }
        }

        //let the user input details for withdraw from account
        static void WithdrawMoney(ref Bank bank, bool isBusiness)
        {
            Console.Write("Enter the name of the account you want to withdraw from: ");
            if (!isBusiness)
            {
                BankAccount tmp = bank.GetBankAccount(Console.ReadLine());
                Console.Write("Enter the amount you want to withdraw: ");
                tmp.Withdraw(double.Parse(Console.ReadLine()));
                Console.WriteLine("Your amount after the withdraw: ");
                bank.PrintBalance(tmp.AccountNum);
            }
            else
            {
                BusinessBankAccount tmp = bank.GetBusinessBankAccount(Console.ReadLine());
                Console.Write("Enter the amount you want to withdraw: ");
                tmp.Withdraw(double.Parse(Console.ReadLine()));
                Console.WriteLine("Your amount after the withdraw: ");
                bank.PrintBalance(tmp.AccountNum);
            }
        }


        static void WithdrawDeposit(ref Bank bank)
        {
            Console.Write("Enter name: ");
            string tmp = Console.ReadLine();
            Console.Write("Enter amount: ");
            double amount = double.Parse(Console.ReadLine());

            try
            {
                BankAccount a = bank.GetBankAccount(tmp);
                if (a != null)
                {
                    a.Deposit(amount);
                    return; 
                }
            }
            catch
            { }
            BusinessBankAccount b = bank.GetBusinessBankAccount(tmp);
            b.Deposit(amount);
            return;
        }
    }
}
