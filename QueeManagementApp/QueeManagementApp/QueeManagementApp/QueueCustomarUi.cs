using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QueeManagementApp
{
    public partial class QueueCustomarUi : Form
    {
        int serialNO=0;
        string name;
        string complain;
        int n=0;
        
        Queue<QueueManagementHelper> queue = new Queue<QueueManagementHelper>();
        
        public QueueCustomarUi()
        {
            InitializeComponent();
        }

        private void enqueueButton_Click(object sender, EventArgs e)
        {
            if (enqueueNameTextBox.Text == string.Empty && enqueueComplainTextBox.Text == string.Empty)
            {
                MessageBox.Show("Please insert your name and complain");
            }

            else if (enqueueComplainTextBox.Text == string.Empty)
            {
                MessageBox.Show("Please insert your complain");
            }

            else if (enqueueNameTextBox.Text == string.Empty)
            {
                MessageBox.Show("Please insert your name");
            }
            else
            {
                dequeueButton.Enabled = true;

                name = enqueueNameTextBox.Text;
                complain = enqueueComplainTextBox.Text;

                ListViewItem item = new ListViewItem();
                item.Text = Convert.ToString(serialNO + 1);
                item.SubItems.Add(name);
                item.SubItems.Add(complain);

                waitingQueueListView.Items.Add(item);
                QueueManagementHelper waitingQueue = new QueueManagementHelper();

                waitingQueue.name = name;
                waitingQueue.complain = complain;
                waitingQueue.serialNo = serialNO;

                queue.Enqueue(waitingQueue);

                serialNO++;

                if (serialNO == 1)
                    waitingQueueListView.Items.RemoveAt(0);

                enqueueNameTextBox.Text = string.Empty;
                enqueueComplainTextBox.Text = string.Empty;
                
                MessageBox.Show(name + "'s serial NO. is " + serialNO);             
                
            }
        }

        private void dequeueButton_Click(object sender, EventArgs e)
        {
            

            

            if (n==serialNO)
            {
                dequeueButton.Enabled = false;

                dequeueNameTextBox.Text = string.Empty;
                dequeueComplainTextBox.Text = string.Empty;
                dequeueSerialNoTextBox.Text = string.Empty;

                MessageBox.Show("There is no Complain");
            }
            else
            {
                QueueManagementHelper waitingDequeue = new QueueManagementHelper();
                waitingDequeue = (QueueManagementHelper)queue.Dequeue();

                dequeueSerialNoTextBox.Text = Convert.ToString(waitingDequeue.serialNo + 1);
                dequeueNameTextBox.Text = waitingDequeue.name;
                dequeueComplainTextBox.Text = waitingDequeue.complain;

                waitingQueueListView.Items.RemoveAt(0);
                n++;
            }
           

        }

        
    }
}
