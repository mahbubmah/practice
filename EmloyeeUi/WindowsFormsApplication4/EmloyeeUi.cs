using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class StudentInfoUi : Form
    {
        StudentInfo sInfo=new StudentInfo();

        public StudentInfoUi()
        {
            InitializeComponent();
        }


        private void showButton_Click(object sender, EventArgs e)
        {

            sInfo.regNo = regNoTextBox.Text;
            sInfo.fistName = firstNameTextBox.Text;
            sInfo.lastName = lastNameTextBox.Text;

            string msg = sInfo.fistName + " " + sInfo.lastName + ", your Reg. No. is " + sInfo.regNo;

           
            MessageBox.Show(msg);
            
           
            
        }

        private void retriveButton_Click(object sender, EventArgs e)
        {
            regNoTextBox.Text = sInfo.regNo;
            firstNameTextBox.Text = sInfo.fistName;
            lastNameTextBox.Text = sInfo.lastName;
        }
    }
}
