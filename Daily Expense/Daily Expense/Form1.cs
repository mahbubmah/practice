using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSVLib;

namespace Daily_Expense
{
    public partial class Form1 : Form
    {
        private string fileLocation = @"d:\expense.csv";
        public Form1()
        {
            InitializeComponent();
        }

       
        private void amountTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            {
                FileStream aStreamForExpense= new FileStream(fileLocation, FileMode.OpenOrCreate);
                CsvFileReader aReader = new CsvFileReader(aStreamForExpense);
                List<string> aRecord = new List<string>();

               
                aStreamForExpense.Close();

                FileStream aStream = new FileStream(fileLocation, FileMode.Append);
                CsvFileWriter aWriter = new CsvFileWriter(aStream);
                List<string> aExpenseRecord = new List<string>();
                aExpenseRecord.Add(amountTextBox.Text.ToString());
                aExpenseRecord.Add(particularTextBox.Text);
                aExpenseRecord.Add(catagoryComboBox.Text);
                aWriter.WriteRow(aExpenseRecord);
                MessageBox.Show("saved successfully");
                aStream.Close();
            }
        }

        private void catagoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void particularTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void showButton_Click(object sender, EventArgs e)
        {

        }

        private void totalTextBox_TextChanged(object sender, EventArgs e) 
        {

        }

        private void maximumTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
