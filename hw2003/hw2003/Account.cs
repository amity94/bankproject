using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2003
{
    class Account
    {
        private static int numberOfAcc = 1;
        private readonly int accountNumber;
        private readonly Customer accountOwner;
        private int maxMinusAllowed;

        public int AccountNumber
        {
            get
            {
                return accountNumber;
            }
        }
        public int Balance { get; private set; }
        public Customer AccountOwner
        {
            get
            {
                return accountOwner;
            }
        }

        public int MaxMinusAllowed
        {
            get
            {
                return maxMinusAllowed;
            }
        }

        public Account(Customer cust, int monthlyIncome)
        {
            accountOwner = cust;
            this.maxMinusAllowed = monthlyIncome * -3;
            accountNumber = numberOfAcc;
            numberOfAcc++;
            this.Balance = 0;
        }
        public void Add(int amount)
        {
            this.Balance += amount;
        }
        public void Subtract(int amount)
        {
            this.Balance -= amount;
        }

        public static bool operator ==(Account a1, Account a2)
        {
            return a1.AccountNumber == a2.AccountNumber;
        }
        public static bool operator !=(Account a1, Account a2)
        {
            return a1.AccountNumber != a2.AccountNumber;
        }

        public static Account operator +(Account a1, Account a2)
        {
            if (a1.AccountOwner == a2.AccountOwner)
            {
                Account acc3 = new Account(a1.AccountOwner, a1.MaxMinusAllowed / -3);
                acc3.Balance = a1.Balance + a2.Balance;
                return acc3;
            }
            return null;
        }

        public override bool Equals(object obj)
        {
            if(obj!= null && obj is Account)
            {
                return this == obj as Account;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return AccountNumber;
        }
    }
}
