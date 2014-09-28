using System;
using System.Windows.Forms;

namespace EmployeeInformationUserDefinedType
{
    public partial class EmployeeInformationUI : Form
    {
        Employee employeeObj = new Employee();

        public EmployeeInformationUI()
        {
            InitializeComponent();
        }

        private void retrieveButton_Click(object sender, EventArgs e)
        {
            idTextBox.Text = employeeObj.id;
            nameTextBox.Text = employeeObj.name;
            salaryTextBox.Text = employeeObj.salary.ToString();
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            employeeObj.id = idTextBox.Text;
            employeeObj.name = nameTextBox.Text;
            employeeObj.salary = Convert.ToDouble(salaryTextBox.Text);
            ClearEmployeeInformationFromTextBoxes();
            MessageBox.Show("Employee Information." + "\nId: " 
                + employeeObj.id + "\nName: " + employeeObj.name + 
                "\nSalary: " + employeeObj.salary);
        }

        private void ClearEmployeeInformationFromTextBoxes()
        {
            idTextBox.Text = "";
            nameTextBox.Text = "";
            salaryTextBox.Text = "";
        }
    }
}
