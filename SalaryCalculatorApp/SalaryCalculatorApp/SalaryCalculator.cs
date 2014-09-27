using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculatorApp
{
    class SalaryCalculator
    {
        
        
        public double CalculateSalary(double basicAmount, double houseRent, double medicaleAllowance)
        {
            return basicAmount + (((basicAmount/100)*houseRent )+ ((basicAmount/100)*medicaleAllowance));
        }
    }
}
