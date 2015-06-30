using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Basic
{
   public static class CardInfoDA
    {
       public static int InsertCardInfoAndAllFreatureChildXML(string cardInfoAllChildCardFeatureXML)
       {
           using (DataHelper dHelper = new DataHelper())
           {
               try
               {
                   using (SqlConnection conn = new SqlConnection(dHelper.ConnectionString))
                   {
                       using (SqlCommand cmd = new SqlCommand("InsertCardInfoAndAllFreatureChildXML"))
                       {
                           cmd.CommandType = CommandType.StoredProcedure;
                           cmd.Parameters.Add(new SqlParameter("@CardInfoXML", cardInfoAllChildCardFeatureXML));

                           SqlParameter returnValue = new SqlParameter("@CardInfoID", DbType.Int64);
                           returnValue.Direction = ParameterDirection.ReturnValue;
                           cmd.Parameters.Add(returnValue);
                           conn.Open();
                           cmd.Connection = conn;
                           int cardInfoId = cmd.ExecuteNonQuery();
                           conn.Close();
                           return cardInfoId;
                       }
                   }
               }
               catch (Exception ex)
               {
                   throw new Exception(ex.Message, ex);
               }
           }
       }

     
    }
}
