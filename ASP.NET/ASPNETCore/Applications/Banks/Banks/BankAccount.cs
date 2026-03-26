using System;

namespace Banks
{
    public class BankAccount
    {
        private readonly string m_customerName;
        private double m_balance;

       

        public double Balance { get => m_balance; set => m_balance = value; }

        public string CustomerName => m_customerName;

        private BankAccount()
        {
            
        }

        public BankAccount(String customerName,double balance)
        {
            m_customerName = customerName;
            m_balance = balance;

        }

        public void Debit(double amount)
        {
            if(amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of debit must be positive");
            }
            if(amount > m_balance)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of debit exceeds balance");
            }
            m_balance -= amount;
        }

        public void Credit(double amount)
        {
            if(amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of credit must be positive");
            }

            m_balance += amount;
        }



        static void Main(string[] args)
        {
            BankAccount cd = new BankAccount("Mr. Chirag Doshi", 11.99);
            cd.Credit(5.77);
            cd.Debit(11.22);

            Console.WriteLine("Current balance is ${0}", cd.Balance);


        }


    }
}
