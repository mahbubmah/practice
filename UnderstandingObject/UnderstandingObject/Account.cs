using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingObject
{
    class Account
    {
        public string number;
        public string name;
        public double balance;

        public void Deposit(double amount)
        {
            balance += amount;
        }

        public void Withdraw(double amount)
        {
            balance -= amount;
        }
    }
}
