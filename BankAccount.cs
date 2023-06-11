using System;

namespace Task_5
{
    class BankAccount
    {
        string accountName;
        int accountNum;
        protected double currentAmount;
        double limit;
        static int specialNum;

        public BankAccount(string accountName, double currentAmount, double limit)
        {
            this.accountName = accountName;

            if(currentAmount < 0)
            {
                throw new ArgumentException("\nArgumentException - current amount cant be negative");
            }
            else
            {
                this.currentAmount = currentAmount;
            }
            this.limit = limit;
            accountNum = ++specialNum;
        }

        public double CurrentAmount 
        {
            get 
            {
                return currentAmount;
            }
        }

        public double Limit 
        { 
            get
            {
                return limit;
            }
            set
            {
                limit = value;
            } 
        }

        public string AccountName 
        {
            get
            {
                return accountName;
            }
        }

        public int AccountNum 
        { 
            get
            {
                return accountNum;
            }
        }

        public void Deposit(double depositAmount)
        {
            if (depositAmount < 0)
            {
                throw new ArgumentException("\nArgumentException - you cant deposit negative amount");
            }
            else
            {
                currentAmount += depositAmount;
            }
        }

        public void Withdraw(double amountToDraw)
        {
            if(amountToDraw < 0)
            {
                throw new ArgumentException("\nArgumentException - you cant withdraw negative amount");
            }
            else if(currentAmount - amountToDraw < limit)
            {
                throw new InvalidOperationException("\nInvalidOperationException - you cant witdraw more than your limit, you can withdraw: "
                    + (currentAmount - limit));
            }
            else
            {
                currentAmount -= amountToDraw;
            }
        }

        public void PrintAccount()
        {
            Console.Write("\nname: " + AccountName + " number: " + AccountNum + " amount: " + currentAmount + " limit: " + limit);
        }
    }
}
