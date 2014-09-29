namespace SalaryAppReverse
{
    internal class Salary
    {
        public string name;
        public double basic;
        public double medicalPercent;
        public double houseRentPercent;


        public double GetTotal()
        {
            return basic + GetMedicalAmount() + GetHouseRentAmount();
        }

        private double GetHouseRentAmount()
        {
            return (basic*houseRentPercent)/100;
        }

        private double GetMedicalAmount()
        {
            return (basic*medicalPercent)/100;
        }
    }
}