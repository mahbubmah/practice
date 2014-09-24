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
using DailyExpense;

namespace DailyExpenseApp
{
    public partial class DailyExpense : Form
    {
        public string aStream;
        public string fileLocation = @"DailyExpense.txt";
        public double amount;
        public string category;
        public DailyExpense()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {

            FileStream aStream = new FileStream(fileLocation, FileMode.Append);
            CsvFileWriter aWriter = new CsvFileWriter(aStream);
            List<string> daily=new List<string>();
            category = dailyCategoryComboBox.Text;
            amount = Convert.ToDouble(amountTextBox.Text);
            daily.Add(Convert.ToString(amount));
            daily.Add(category);

            aWriter.WriteRow(daily);
            aStream.Close();

            

        }
    }
}
