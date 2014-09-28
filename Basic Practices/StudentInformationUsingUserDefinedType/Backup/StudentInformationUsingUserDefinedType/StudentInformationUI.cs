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
        private Student studentObj = new Student();

        private void buttonShow_Click(object sender, EventArgs e)
        {
            //studentObj.SaveInformation(
            studentObj.regNo = regNoTextBox.Text;
            studentObj.firstName = firstNameTextBox.Text;
            studentObj.lastName = lastNameTextBox.Text;
            ClearStudentInformationFromTextBoxes();
            MessageBox.Show(studentObj.firstName + " " + studentObj.lastName + ", your registration number is " + studentObj.regNo);
        }

        private void ClearStudentInformationFromTextBoxes()
        {
            regNoTextBox.Text = "";
            firstNameTextBox.Text = "";
            lastNameTextBox.Text = "";
        }

        private void retriveButton_Click(object sender, EventArgs e)
        {
            regNoTextBox.Text = studentObj.regNo;
            firstNameTextBox.Text = studentObj.firstName;
            lastNameTextBox.Text = studentObj.lastName;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            studentObj.regNo = "";
            studentObj.firstName = "";
            studentObj.lastName = "";
            ClearStudentInformationFromTextBoxes();
        }
    }
}
