using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorApp
{
    public partial class CalculatorUI : Form
    {
        Calculator aCalculator = new Calculator();
        private double firstNo = 0;
        private double secondNo;
        private double result;

        public CalculatorUI()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            InitializeFirstNoAndSecondNo();
            result = aCalculator.Add(firstNo, secondNo);
            resultTextBox.Text = result.ToString();
        }

        private void InitializeFirstNoAndSecondNo()
        {
            firstNo = Convert.ToDouble(firstNumberTextBox.Text);
            secondNo = Convert.ToDouble(secondNumberTextBox.Text);
        }

        private void subtractButton_Click(object sender, EventArgs e)
        {
            InitializeFirstNoAndSecondNo();
            result = aCalculator.Subtract(firstNo, secondNo);
            resultTextBox.Text = result.ToString();
        }

        private void multiplyButton_Click(object sender, EventArgs e)
        {
            InitializeFirstNoAndSecondNo();
            result = aCalculator.Multiply(firstNo, secondNo);
            resultTextBox.Text = result.ToString();
        }

        private void divideButton_Click(object sender, EventArgs e)
        {
            InitializeFirstNoAndSecondNo();
            result = aCalculator.Divide(firstNo, secondNo);
            resultTextBox.Text = result.ToString();
        }
    }
}
