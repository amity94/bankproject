using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2003
{
    class Customer
    {
        private static int numberOfCust = 1;
        private readonly int customerNumber;
        private readonly int customerID;
        public int CustomerID
        {
            get
            {
                return customerID;
            }
        }
        public string Name { get; private set; }
        public int PhNumber { get; private set; }
        public int CustomerNumber
        {
            get
            {
                return customerNumber;
            }
        }
        public Customer(int id, string name, int phone)
        {
            customerNumber = numberOfCust;
            numberOfCust++;            
            this.customerID = id;
            this.Name = name;
            this.PhNumber = phone;
        }

        public static bool operator ==(Customer c1, Customer c2)
        {
            return c1.CustomerID == c2.CustomerID;
        }
        public static bool operator !=(Customer c1, Customer c2)
        {
            return (c1.CustomerID != c2.CustomerID);
        }
        public override bool Equals(object obj)
        {
            if(obj != null && obj is Customer)
            {
                return this == obj as Customer;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return CustomerNumber;
        }
    }
}
