using System;

namespace Task_5
{
    class BusinessBankAccount :BankAccount
    {
        int negativeInterest;

        public BusinessBankAccount(string accountName, double currentAmount) :base(accountName, currentAmount, Int32.MinValue)
        {
            negativeInterest = 3;
        }

        public void MonthElasped()
        {
            if(CurrentAmount < 0)
            {
                currentAmount -=  -currentAmount * negativeInterest / 100;
            }
        }

        public new void PrintAccount()
        {
            base.PrintAccount();
            Console.Write(" interest: " + negativeInterest);
        }
    }
}
