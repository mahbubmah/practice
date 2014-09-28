using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeApp
{
    public partial class EmployeeUI : Form
    {
        Employee anEmployee = new Employee();

        public EmployeeUI()
        {
            InitializeComponent();
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            int a = 10;
            int b = a;

            anEmployee.id = idTextBox.Text;



            anEmployee.name = nameTextBox.Text;
            anEmployee.salary = Convert.ToDouble(salaryTextBox.Text);

            idTextBox.Text = string.Empty;
            nameTextBox.Text = string.Empty;
            salaryTextBox.Text = string.Empty;

            string msg = "Id: " + anEmployee.id + "\nName: " + anEmployee.name + "\nSalary: " + anEmployee.salary;

            MessageBox.Show(msg);

        }

        private void retrieveButton_Click(object sender, EventArgs e)
        {
            idTextBox.Text = anEmployee.id;
            nameTextBox.Text = anEmployee.name;
            salaryTextBox.Text = anEmployee.salary.ToString();
        }
    }
}
