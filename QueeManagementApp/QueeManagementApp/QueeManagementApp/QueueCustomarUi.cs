using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QueeManagementApp
{
    public partial class QueueCustomarUi : Form
    {
        int serialNO;
        string name;
        string complain;
        public QueueCustomarUi()
        {
            InitializeComponent();
        }

        private void enqueueButton_Click(object sender, EventArgs e)
        {
            serialNO = serialNO+1;
            name = enqueueNameTextBox.Text;
            complain = enqueueComplainTextBox.Text;

            QueueManagementHelper enqueueList =new QueueManagementHelper();
            enqueueList.EnqueueHelper(waitingQueueListView,serialNO,name,complain);

        }

        
    }
}
