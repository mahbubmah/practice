using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalaryCalculatorApp
{
    public partial class SalaryCalculatorUi : Form
    {

        private SalaryCalculator aSalaryCalculator;
        public SalaryCalculatorUi()
        {
            InitializeComponent();
        }

        private void showSalaryButton_Click(object sender, EventArgs e)
        {
            aSalaryCalculator=new SalaryCalculator();

            string msg = employeeNameTextBox.Text + " your slary is " + Convert.ToString(aSalaryCalculator.CalculateSalary(Convert.ToDouble(basicAmounTextBox.Text), Convert.ToDouble(houseRentTextBox.Text), Convert.ToDouble(medicalAllowanceTextBox.Text)));
            

            MessageBox.Show(msg);
        }
    }
}
