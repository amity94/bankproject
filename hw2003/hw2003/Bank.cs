using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2003
{
    class Bank : IBank
    {
        private List<Account> acclist;
        private List<Customer> custlist;
        private Dictionary<int, Customer> custID_Dict;
        private Dictionary<int, Customer> custNumber_Dict;
        private Dictionary<int, Account> accountNumber_Dict;
        private Dictionary<Customer, List<Account>> account_Dict;

        private int totalMoneyInBank;
        private int profits;
#region
        internal Customer GetCustomerById(int customerId)
        {
            Customer cust;
            custID_Dict.TryGetValue(customerId, out cust);
            return cust;
        }

        internal Customer GetCustomerByNumber(int customerNumber)
        {
            Customer cust;
            custNumber_Dict.TryGetValue(customerNumber, out cust);
            return cust;
        }
        
        internal Account GetAccountByNumber(int accountNumber)
        {
            Account acc;
            accountNumber_Dict.TryGetValue(accountNumber, out acc);
            return acc;
        }

        internal List<Account> GetAccountsByCustomer(Customer cust)
        {
            List<Account> lst;
            account_Dict.TryGetValue(cust, out lst);
            return lst;
        }
#endregion
        internal void AddNewCustomer(Customer cust)
        {
            if (!custlist.Contains(cust))
            {
                custlist.Add(cust);
                custID_Dict.Add(cust.CustomerID, cust);
                custNumber_Dict.Add(cust.CustomerNumber, cust);

                List<Account> accountlist;
                account_Dict.TryGetValue(cust, out accountlist);
            }
        }

        internal bool OpenNewAccount(Account acc, Customer cust)
        {
            if (!acclist.Contains(acc))
            {
                acclist.Add(acc);
                accountNumber_Dict.Add(acc.AccountNumber, acc);

                List<Account> customerlist;
                account_Dict.TryGetValue(cust, out customerlist);
                customerlist.Add(acc);
                return true;
            }
            return false;
        }

        public int Deposit(Account acc, int amount)
        {
            acc.Add(amount);
            totalMoneyInBank += amount;
            return acc.Balance;
        }

        internal int Withdraw(Account acc, int amount)
        {
            acc.Subtract(amount);
            if (acc.Balance < acc.MaxMinusAllowed)
                throw new BalanceException("Funds Too Low");
            totalMoneyInBank -= amount;
            return acc.Balance;
        }
        
        internal int GetCustomerTotalBalance(Customer cust)
        {
            int sum = 0;
            if (account_Dict.TryGetValue(cust, out List<Account> accounts))
            {
                foreach(var account in accounts)
                {
                    sum += account.Balance;
                }
            }
            return sum;
        }

        internal bool CloseAccount(Account acc, Customer cust)
        {
            if (acclist.Contains(acc))
            {
                acclist.Remove(acc);
                accountNumber_Dict.Remove(acc.AccountNumber);

                List<Account> customerlist;
                account_Dict.TryGetValue(cust, out customerlist);
                customerlist.Remove(acc);
                return true;
            }
            return false;
        }

        internal void ChargeAnnualCommission(float percentage)
        {
            
            foreach(var a in acclist)
            {
                int savebalance = a.Balance;
                if (a.Balance > 0)
                    a.Subtract((int)(a.Balance * percentage/100));
                else if(a.Balance <0)
                    a.Subtract((int)(a.Balance * percentage/50));

                profits = profits + Math.Abs(a.Balance - savebalance);
            }
        }

        internal void JoinAccount(Account acc1, Account acc2)
        {
            Account acc3 =  acc1 + acc2;
            //not finished!!
        }

        public Bank()
        {
            acclist = new List<Account>();
            custlist = new List<Customer>();
            accountNumber_Dict = new Dictionary<int, Account>();
            account_Dict = new Dictionary<Customer, List<Account>>();
            custID_Dict = new Dictionary<int, Customer>();
            custNumber_Dict = new Dictionary<int, Customer>();
        }

        public string Name => throw new NotImplementedException();

        public string Address => throw new NotImplementedException();

        public int CustomerCount => throw new NotImplementedException();
    }
}
