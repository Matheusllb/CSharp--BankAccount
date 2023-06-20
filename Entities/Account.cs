using BankAccount.Entities.Exceptions;
using System.Globalization;

namespace BankAccount.Entities
{
    public class Account
    {
        public int Number { get; private set; }
        public string Holder { get; private set; }
        public double Balance { get; private set; }
        public double WithdrawLimit { get; private set; }

        public Account(int number, string holder, double balance, double withdrawLimit) 
        {
            Number = number;
            Holder = holder;
            Balance = balance;
            WithdrawLimit = withdrawLimit;
        }

        public void Deposit(double value)
        {
            Balance += value;
        }
        public void Withdraw(double value)
        {
            if(Balance >= value)
            {
                if (WithdrawLimit > value)
                {
                    Balance -= value;
                }
                else
                {
                    throw new DomainException("Withdrawal amount exceeds limit");
                }
            }
            else
            {
                throw new DomainException("Insufficient funds for withdrawal");
            }
            
        }

        public override string ToString()
        {
            return "\nNumber: "
                + Number
                + "\nHolder: "
                + Holder
                + "\nBalance: $ "
                + Balance.ToString("F2", CultureInfo.InvariantCulture)
                + "\nWithdraw limit: "
                + WithdrawLimit.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
