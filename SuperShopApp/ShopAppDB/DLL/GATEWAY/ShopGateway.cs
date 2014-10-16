using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopAppDB.DLL.DAO;

namespace ShopAppDB.DLL.GATEWAY
{
    class ShopGateway
    {
        public string Save(Shop aShop,Item anItem)
        {
            string conn = @"server=ASHIQ; database=ShopAndItems; integrated security=true";
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = conn;
            connection.Open();
            string query = string.Format("INSERT INTO t_Shop VALUES('{0}','{1}','{2}','{3}')", aShop.Name, aShop.Address,anItem.ProductID,anItem.Quantity);
            SqlCommand command = new SqlCommand(query, connection);
            int affectedrow = command.ExecuteNonQuery();
            if (affectedrow > 0)
            {


                return "inserted successfully";
            }
            return "something is wrong";
        }
    }
}
