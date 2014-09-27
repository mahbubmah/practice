using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountOperationApp
{
    class Account
    {

        public string number;
        public string name;
        public double balance = 0;

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

        public string Report()
        {
            string report="";
            report = name + ", your account number: " + number + " and it's balance is " + Convert.ToString(balance) + "Taka";
            return report;
        }
    }
}
