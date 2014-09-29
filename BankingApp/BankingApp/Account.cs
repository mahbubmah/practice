using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    class Account
    {
        private string number;
        private string name;
        
        private double balance;


        public void Deposit(double amount)
        {
            balance += amount;
        }

        public void Withdraw(double amount)
        {
            balance -= amount;
        }

        public string GetReport()
        {
            string msg = name + " your account no : " + number + " and it's balance is : " + balance;
            return msg;
        }

    }
}
