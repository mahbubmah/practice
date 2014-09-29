using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingObject
{
    class Program
    {
        static void Main(string[] args)
        {
            int b = 100;
            int k = b;
            b = 300;
            //k?


            Account account1 = new Account();
            account1.number = "123456";
            account1.name = "Morshed";
            account1.name = "Rana";
            account1.Deposit(3000);

            //Account account11 = account1;
            //Account account22 = account1;
            //Account account33 = account22;

            //account33.number = "00008";

            //account1.number ??

            Account account2 = new Account();
            account2.number = "222222";
            account2.name = "Milon";
            account2.Deposit(1000);

            account1 = account2;







            Account account3 = new Account();
            account3.number = "33333";
            account3.name = "Afrin";

            

        }
    }
}
