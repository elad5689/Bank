using System;

namespace Task_5
{
    class Bank
    {
        BankAccount[] regularAccount;
        int actualRegularAccount;
        BusinessBankAccount[] businessAccount;
        int actualBusinessAccount;

        public Bank(int size)
        {
            regularAccount = new BankAccount[size];
            actualRegularAccount = 0;
            businessAccount = new BusinessBankAccount[size];
            actualBusinessAccount = 0;
        }

        public void AddAccount(BankAccount accountToAdd)
        {
            if(actualRegularAccount == regularAccount.Length)
            {
                throw new IndexOutOfRangeException("\nIndexOutOfRangeException - the bank is full, no more new accounts");
            }
            else
            {
                regularAccount[actualRegularAccount] = accountToAdd;
                actualRegularAccount++;
                Console.WriteLine("\nRegular account added successfully");
            }
        }

        public void AddBusinessAccount(BusinessBankAccount accountToAdd)
        {
            if(actualBusinessAccount == businessAccount.Length)
            {
                throw new IndexOutOfRangeException("\nIndexOutOfRangeException - the bank is full, no more new accounts");
            }
            else
            {
                businessAccount[actualBusinessAccount] = accountToAdd;
                actualBusinessAccount++;
                Console.WriteLine("\nBusiness account added successfully");
            }
        }

        public BankAccount GetBankAccount(string accountName)
        {
            for(int i = 0; i < actualRegularAccount; i++)
            {
                if(regularAccount[i].AccountName == accountName)
                {
                    return regularAccount[i];
                }    
            }
            throw new ArgumentException("\nArgumentException - there is no account with this name");
        }

        public BusinessBankAccount GetBusinessBankAccount(string accountName)
        {
            for(int i = 0; i < actualBusinessAccount; i++)
            {
                if(businessAccount[i].AccountName == accountName)
                {
                    return businessAccount[i];
                }
            }
            throw new ArgumentException("\nArgumentException - there is no account with this name");
        }

        public void CloseBankAccount(BankAccount accountToDelete)
        {
            int i;

            if(accountToDelete.CurrentAmount != 0)
            {
                throw new ArgumentException("\nArgumentException - the balance of the account is not 0, you can't close it");
            }
            for(i = 0; i < actualRegularAccount; i++)
            {
                if(regularAccount[i] == accountToDelete)
                {
                    for(; i < actualRegularAccount - 1; i++)
                    {
                        regularAccount[i] = regularAccount[i + 1];
                    }
                    regularAccount[actualRegularAccount - 1] = null;
                    actualRegularAccount--;
                    Console.WriteLine("\nRegular account closed successfully");
                    return;
                }
            }
            throw new ArgumentException("\nArgumentException - the account you want to close is not exsist");
        }

        public void CloseBusinessAccount(BusinessBankAccount accountToDelete)
        {
            int i;

            if (accountToDelete.CurrentAmount != 0)
            {
                throw new ArgumentException("\nArgumentException - the balance of the account is not 0, you can't close it");
            }
            for (i = 0; i < actualBusinessAccount; i++)
            {
                if (businessAccount[i] == accountToDelete)
                {
                    for (; i < actualBusinessAccount - 1; i++)
                    {
                        businessAccount[i] = businessAccount[i + 1];
                    }
                    businessAccount[actualBusinessAccount - 1] = null;
                    actualBusinessAccount--;
                    Console.WriteLine("\nBusiness account closed successfully");
                    return;
                }
            }
            throw new ArgumentException("\nArgumentException - the account you want to close is not exsist");
        }

        public void MonthElapsed()
        {
            for(int i = 0; i < actualBusinessAccount; i++)
            {
                businessAccount[i].MonthElasped();
            }
        }

        public void PrintBalance(double accountNum)
        {
            int i;

            for (i = 0; i < actualRegularAccount; i++)
            {
                if(regularAccount[i].AccountNum == accountNum)
                {
                    Console.WriteLine("Account number: " + regularAccount[i].AccountNum + " amount: " + regularAccount[i].CurrentAmount);
                    return;
                }
            }
            for (i = 0; i < actualBusinessAccount; i++)
            {
                if (businessAccount[i].AccountNum == accountNum)
                {
                    Console.WriteLine("Account number: " + businessAccount[i].AccountNum + " amount: " + businessAccount[i].CurrentAmount);
                    return;
                }
            }
            throw new ArgumentException("\nArgumentException - the account number is not exsist");
        }

        public void PrintDetails()
        {
            Console.WriteLine("\n***Details of regular accounts***");
            for(int i = 0; i < actualRegularAccount; i++)
            {
                regularAccount[i].PrintAccount();
            }
            Console.WriteLine("\n\n***Details of Business accounts***");
            for (int i = 0; i < actualBusinessAccount; i++)
            {
                businessAccount[i].PrintAccount();
            }
        }

        public double getAssets()
        {
            double totalAmount = 0;

            for (int i = 0; i < actualRegularAccount; i++)
            {
                totalAmount += regularAccount[i].CurrentAmount;
            }
            for (int i = 0; i < actualBusinessAccount; i++)
            {
                totalAmount += businessAccount[i].CurrentAmount;
            }
            return totalAmount;
        }
    }
}
