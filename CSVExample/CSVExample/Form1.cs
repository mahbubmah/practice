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

namespace CSVExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string fileLocation = @"PersonList.csv";
        private void saveButton_Click(object sender, EventArgs e)
        {
            FileStream aFileStream = new FileStream(fileLocation,FileMode.Open);
            CsvFileReader aReader = new CsvFileReader(aFileStream);
            List<string> personRecod = new List<string>();
            while (aReader.ReadRow(personRecod))
            {
                string personalNumber = personRecod[2];

                if (contactTextBox.Text == personalNumber)
                {
                    MessageBox.Show("Contact No is alredy exist!");
                    aFileStream.Close();
                    return;
                }
            }
            aFileStream.Close();

            FileStream bFileStream= new FileStream(fileLocation, FileMode.Open);
            CsvFileWriter aWriter = new CsvFileWriter(bFileStream);
            personRecod.Add(nameTextBox.Text);
            personRecod.Add(emailTextBox.Text);
            personRecod.Add(contactTextBox.Text);
            personRecod.Add(homeContTextBox.Text);
            personRecod.Add(homeAddreTextBox.Text);
            aWriter.WriteRow(personRecod);
            aFileStream.Close();
        }

        private void showButton_Click(object sender, EventArgs e)
        {

        }
    }
}
