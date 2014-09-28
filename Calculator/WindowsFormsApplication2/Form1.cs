using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Calculaton : Form
    {
        public Calculaton()
        {
            InitializeComponent();
        }

        int FristNumber;
        int SecondNumber;
        int result = 0;


        private void btnAdd_Click(object sender, EventArgs e)
        {
            FristNumber = Convert.ToInt32(txtFristNumber.Text);
            SecondNumber = Convert.ToInt32(txtSecondNumber.Text);
            result = FristNumber + SecondNumber;
            txtResult.Text = Convert.ToString(result);


        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            FristNumber = Convert.ToInt32(txtFristNumber.Text);
            SecondNumber = Convert.ToInt32(txtSecondNumber.Text);
            result = FristNumber - SecondNumber;
            txtResult.Text = Convert.ToString(result);
        }

        private void btnMulti_Click(object sender, EventArgs e)
        {
            FristNumber = Convert.ToInt32(txtFristNumber.Text);
            SecondNumber = Convert.ToInt32(txtSecondNumber.Text);
            result = FristNumber * SecondNumber;
            txtResult.Text = Convert.ToString(result);
        }

        private void btnDivision_Click(object sender, EventArgs e)
        {
            FristNumber = Convert.ToInt32(txtFristNumber.Text);
            SecondNumber = Convert.ToInt32(txtSecondNumber.Text);
            result = FristNumber / SecondNumber;
            txtResult.Text = Convert.ToString(result);
        }
    }
}
