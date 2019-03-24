using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2003
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank b = new Bank();
            Customer amity = new Customer(1, "amity", 000);
            Account amityacc = new Account(amity, 1000);
            b.AddNewCustomer(amity);
            b.OpenNewAccount(amityacc, amity);

            Account amityacc2 = new Account(amity, 2000);
            b.JoinAccount(amityacc, amityacc2);
        }
    }
}
