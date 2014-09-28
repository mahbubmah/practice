using System;
using System.Windows.Forms;

namespace StudentInformationUsingUserDefinedType
{
    public partial class StudentInformationUI : Form
    {
        public StudentInformationUI()
        {
            InitializeComponent();
        }
        private Student aStudent = new Student();

        private void buttonShow_Click(object sender, EventArgs e)
        {
            aStudent.regNo = regNoTextBox.Text;
            aStudent.firstName = firstNameTextBox.Text;
            aStudent.lastName = lastNameTextBox.Text;
            ClearStudentInformationFromTextBoxes();
            MessageBox.Show(aStudent.firstName + " " + aStudent.lastName + ", your registration number is " + aStudent.regNo);
        }

        private void ClearStudentInformationFromTextBoxes()
        {
            regNoTextBox.Text = "";
            firstNameTextBox.Text = "";
            lastNameTextBox.Text = "";
        }

        private void retriveButton_Click(object sender, EventArgs e)
        {
            regNoTextBox.Text = aStudent.regNo;
            firstNameTextBox.Text = aStudent.firstName;
            lastNameTextBox.Text = aStudent.lastName;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            aStudent.regNo = "";
            aStudent.firstName = "";
            aStudent.lastName = "";
            ClearStudentInformationFromTextBoxes();
        }
    }
}
