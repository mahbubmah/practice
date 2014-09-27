using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorOopApp
{
    public partial class CalculatorUi : Form
    {
        Calculator aCalculator;
        private double firstNumber;
        private double lastNumber;
        private double result;



        public CalculatorUi()
        {
            InitializeComponent();
        }

        private void additionBoutton_Click(object sender, EventArgs e)
        {

            if (firstNumberTextBox.Text != string.Empty && lastNumberTextBox.Text != string.Empty)
            {
                aCalculator = new Calculator();
                InitializeFirstNoAndSecondNumber();
                result = aCalculator.Addition(firstNumber, lastNumber);
                resultTextBox.Text = Convert.ToString(result);
            }
            else
            {
                MessageBox.Show("Please Enter two number");

            }
        }

        private void subtructionButton_Click(object sender, EventArgs e)
        {
            if (firstNumberTextBox.Text != string.Empty && lastNumberTextBox.Text != string.Empty)
            {
                aCalculator = new Calculator();
                InitializeFirstNoAndSecondNumber();
                result = aCalculator.Subtraction(firstNumber, lastNumber);
                resultTextBox.Text = Convert.ToString(result);
            }
            else
            {
                MessageBox.Show("Please Enter two number");

            }
        }

        private void InitializeFirstNoAndSecondNumber()
        {
            firstNumber = Convert.ToDouble(firstNumberTextBox.Text);
            lastNumber = Convert.ToDouble(lastNumberTextBox.Text);
        }

        private void multiplicationButton_Click(object sender, EventArgs e)
        {
            if (firstNumberTextBox.Text != string.Empty && lastNumberTextBox.Text != string.Empty)
            {
                aCalculator = new Calculator();
                InitializeFirstNoAndSecondNumber();
                result = aCalculator.Multiplication(firstNumber, lastNumber);
                resultTextBox.Text = Convert.ToString(result);
            }
            else
            {
                MessageBox.Show("Please Enter two number");

            }
        }

        private void divisionButton_Click(object sender, EventArgs e)
        {
            if (firstNumberTextBox.Text != string.Empty && lastNumberTextBox.Text != string.Empty)
            {
                aCalculator = new Calculator();
                InitializeFirstNoAndSecondNumber();
                result = aCalculator.Division(firstNumber, lastNumber);
                resultTextBox.Text = Convert.ToString(result);
            }
            else
            {
                MessageBox.Show("Please Enter two number");

            }
        }
    }
}
