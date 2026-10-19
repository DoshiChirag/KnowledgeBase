using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureCoding
{
    public class BankAccount
    {
        protected string customerID;
        protected decimal balance;

        public virtual string CheckAgeLimit(byte NewAge)
        {
            NewAge += 10;
            if(NewAge > 55){
                return "Valid for senior discount";
            }

            return "Not valid for senior discount";

        }

        public virtual void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be positive.");
            }
            if (amount > balance)
            {
                throw new InvalidOperationException("Insufficient funds.");
            }
            balance -= amount;
        }
        public virtual void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be positive.");
            }
            balance += amount;
        }

        public virtual decimal return_balance{
            get{ return balance; }
        }
    }
}
