using System;
using System.Windows.Forms;

namespace StudentInformationPrimitiveType
{
    public partial class StudentInformationUI : Form
    {
        public StudentInformationUI()
        {
            InitializeComponent();
        }

        private string regNo;
        private string firstName;
        private string lastName;

        private void buttonShow_Click(object sender, EventArgs e)
        {
            regNo = regNoTextBox.Text;
            firstName = firstNameTextBox.Text;
            lastName = lastNameTextBox.Text;
            ClearStudentInformationFromTextBoxes();
            MessageBox.Show(firstName + " " + lastName + @", your registration number is " + regNo);
        }

        private void ClearStudentInformationFromTextBoxes()
        {
            regNoTextBox.Text = "";
            firstNameTextBox.Text = "";
            lastNameTextBox.Text = "";
        }

        private void retriveButton_Click(object sender, EventArgs e)
        {
            regNoTextBox.Text = regNo;
            firstNameTextBox.Text = firstName;
            lastNameTextBox.Text = lastName;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            regNo = "";
            firstName = "";
            lastName = "";
            ClearStudentInformationFromTextBoxes();
        }
    }
}
