using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopAppDB.DLL.DAO;
using ShopAppDB.DLL.GATEWAY;

namespace ShopAppDB.BLL
{
    class ShopBLL
    {
        ShopGateway aShopGateway=new ShopGateway();
        public  string Save(Shop aShop,Item anItem)
        {
            if (aShop.Name==""||aShop.Address==""||anItem.ProductID==""||anItem.Quantity==0)
            {
                return "fill up the field";

            }
            else
            {

            return aShopGateway.Save(aShop,anItem);

            }
            
        }
    }
}
