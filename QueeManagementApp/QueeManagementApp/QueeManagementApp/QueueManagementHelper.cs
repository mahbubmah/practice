using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QueeManagementApp
{
    public class QueueManagementHelper
    {
        ListViewItem item = new ListViewItem();
        public void EnqueueHelper(ListView enqueListView  , int serialNo, string name, string complain)
        {
            
            item.Text = Convert.ToString(serialNo);
            item.SubItems.Add(name);
            item.SubItems.Add(complain);

            enqueListView.Items.Add(item);
         }

        public void DequeueHelper(ListView dequeueListView,int serialNo,string name,string complain)
        {
            Convert.ToString(serialNo+1);
            serialNo = Convert.ToInt32(item.Text);
            name = item.Name;

        }
    }
}
