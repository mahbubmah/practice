using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentInfoApp
{
    public partial class StudentInformation : Form
    {
        List<Students> aStudent = new List<Students>();

        Students students = new Students();

        public StudentInformation()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            
            students.regNo = regNoTextBox.Text;
            students.firstName = firstNameTextBox.Text;
            students.lastName = lastNameTextBox.Text;

            aStudent.Add(students);
            
            regNoTextBox.Text = string.Empty;
            firstNameTextBox.Text = string.Empty;
            lastNameTextBox.Text = string.Empty;

            
            
        }
        string msg1 = "Reg. No.\t=Name\n";

        private void retriveButton_Click(object sender, EventArgs e)
        {
            


            foreach (Students sss in aStudent)
            {
                msg1+= sss.regNo + "\t" + sss.GetFullName();

            }
            MessageBox.Show(msg1);
        }
    }
}
