using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int Time;
        int Balance;
        int Intarest = 0;
        private void btnCalculation_Click(object sender, EventArgs e)
        {
            if (comboBoxBank.Text =="BRAC")
            {
                Time = Convert.ToInt32(txtTime.Text);
                Balance = Convert.ToInt32(txtBalance.Text);
                Intarest = (Time*Balance*6)/100;
                txtIntarest.Text = Convert.ToString(Intarest);
            }
            else if (comboBoxBank.Text == "DBBL")
            {
                Time = Convert.ToInt32(txtTime.Text);
                Balance = Convert.ToInt32(txtBalance.Text);
                Intarest = (Time * Balance * 7) / 100;
                txtIntarest.Text = Convert.ToString(Intarest);
            }
            else
            {
                Time = Convert.ToInt32(txtTime.Text);
                Balance = Convert.ToInt32(txtBalance.Text);
                Intarest = (Time * Balance * 8) / 100;
                txtIntarest.Text = Convert.ToString(Intarest);
            }
        }
    }
}
