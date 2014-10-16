using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShopAppDB.BLL;
using ShopAppDB.DLL.DAO;

namespace ShopAppDB
{
    public partial class ShopUI : Form
    {
        

        public ShopUI()
        {
            InitializeComponent();
        }
        private Shop aShop;
        private Item anItem;
        private ShopBLL aShopBll;

        private void saveShopButton_Click(object sender, EventArgs e)
        {
            aShop = new Shop(textBoxShopName.Text,textBoxShopAddress.Text);
            MessageBox.Show("shop has been created");
        }

        private void addItemButton_Click(object sender, EventArgs e)
        {
            anItem = new Item();
            //aShop.Items.Add(anItem);
            anItem.ProductID = textBoxProductID.Text;
            anItem.Quantity = Convert.ToInt16(textBoxItemQTY.Text);
            aShop.Add(anItem);
            aShopBll = new ShopBLL();
            aShopBll.Save(aShop,anItem);

        }

        private void showDetailButton_Click(object sender, EventArgs e)
        {

        }
    }
}
