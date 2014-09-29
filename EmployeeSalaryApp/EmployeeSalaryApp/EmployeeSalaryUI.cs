using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeSalaryApp
{
    public partial class EmployeeSalaryUI : Form
    {
        public EmployeeSalaryUI()
        {
            InitializeComponent();
        }

        private void showMeSalaryButton_Click(object sender, EventArgs e)
        {
            Salary aSalary = new Salary();
            aSalary.name = employeeNameTextBox.Text;
            aSalary.basic = Convert.ToDouble(basicAmountTextBox.Text);
            aSalary.medicalAllowancePercent = Convert.ToDouble(medicalAllowanceTextBox.Text);
            aSalary.houseRentPercent = Convert.ToDouble(houseRentTextBox.Text);
            double total = aSalary.GetTotal();
            MessageBox.Show(aSalary.name + " your salary is: " + total);
        }
    }
}
