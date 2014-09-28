using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentAppUsingStack
{
    public partial class StudentUI : Form
    {

        Stack<Student> students = new Stack<Student>();
        public StudentUI()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Student aStudent = new Student();
            aStudent.regNo = regNoTextBox.Text;
            aStudent.lastName = lastNameTextBox.Text;
            aStudent.firstName = firstNameTextBox.Text;
            students.Push(aStudent);
        }

        private void buttonShowAll_Click(object sender, EventArgs e)
        {
            foreach (Student aStudent in students)
            {
                
            }
        }
    }
}
