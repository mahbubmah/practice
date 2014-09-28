using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentsApp
{
    public partial class StudentUI : Form
    {

        List<string> names = new List<string>();

        List<Student> studentList = new List<Student>();
        public StudentUI()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Student aStudent = new Student();
            aStudent.regNo = regNoTextBox.Text;
            aStudent.firstName = firstNameTextBox.Text;
            aStudent.lastName = lastNameTextBox.Text;
            studentList.Add(aStudent);
            MessageBox.Show("Student has been added");
        }

        private void buttonShowAll_Click(object sender, EventArgs e)
        {
            string msg = "Reg No\tFull Name\n";
            foreach (Student aStudent in studentList)
            {
                msg += aStudent.regNo + "\t" + aStudent.GetFullName()+ "\n";
            }
            MessageBox.Show(msg);
        }
    }
}
