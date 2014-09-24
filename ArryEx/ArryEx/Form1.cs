using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ArryEx
{
    public partial class Form1 : Form
    {
        List<string> nameList = new List<string>();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            
            nameList.Add(nameTextBox.Text);
        }

        private void showAllButton_Click(object sender, EventArgs e)
        {
            showAllListBox.Items.Clear();
            foreach (string aName in nameList)
            {
                
                showAllListBox.Items.Add(nameList);
                MessageBox.Show(nameList);
            }
        }

    }
}
