using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSalaryApp
{
    class Salary
    {
        public string name;
        public double basic;
        public double houseRentPercent;
        public double medicalAllowancePercent;

        public double GetMedicalAmount()
        {
            return (basic * medicalAllowancePercent) / 100;
        }

        public double GetHouseRentAmount()
        {
            return (basic*houseRentPercent)/100;

        }

        public double GetTotal()
        {
            return basic + GetHouseRentAmount() + GetMedicalAmount();
        }
    }
}
