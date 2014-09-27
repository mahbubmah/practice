using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountOperationApp
{
    internal class Account
    {

        private string number;
        private string name;
        private double balance = 0;


        public string Name
        {
            set { name = value; }
            get { return name; }
        }

        public string Number
        {
            set { number = value; }
            get { return number; }
        }

        public double Balance
        {
            get { return balance; }
        }

        public void Create(string aAccountNo,string nName)
        {
            number = aAccountNo;
            name = nName;
        }

        public double Deposite(double deposite)
        {

            balance = balance + deposite;
            return balance;
        }

        public double Withdraw(double withdraw)
        {
            balance = balance - withdraw;
            return balance;
        }
        
        
    }
}
