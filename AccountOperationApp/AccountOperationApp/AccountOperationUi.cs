using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountOperationApp
{
    public partial class AccountOperationUi : Form
    {
        private double deposite=0;
        private double withdraw=0;

        Account aAccount;
        public AccountOperationUi()
        {
            InitializeComponent();
        }

       
        private void createButton_Click(object sender, EventArgs e)
        {
            if(accountNoTextBox.Text!=string.Empty && customarNameTextBox.Text!=string.Empty)
            {
                aAccount=new Account();
                aAccount.Create(accountNoTextBox.Text, customarNameTextBox.Text);
            }

            else
            {
                MessageBox.Show("Please enter your name and account number")
            }
            
            
            
        }

        private void depostieButton_Click(object sender, EventArgs e)
        {
            if (aAccount != null)
            {
                deposite = Convert.ToDouble(amountTextBox.Text);
                aAccount.Deposite(deposite);
            }
            else
            {
                MessageBox.Show("Please create account first")
            }
        }

        private void withdrawButton_Click(object sender, EventArgs e)
        {
            if (aAccount != null)
            {
                withdraw = Convert.ToDouble(amountTextBox.Text);
                aAccount.Withdraw(withdraw);
            }
            else
            {
                MessageBox.Show("Please create account first")
            }
        }

        private void reportButton_Click(object sender, EventArgs e)
        {
            if (aAccount != null)
            {
                MessageBox.Show(aAccount.Report());
            }
            else
            {
                MessageBox.Show("Please create account first")
            }
        }

    }
}
