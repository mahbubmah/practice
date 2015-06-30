using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Basic
{
    public static class BiReceiverDA
    {
        public static int InsertBiReceiverAndBiReceiverChildXML(string allBiReceiverAndBiReceiverChildXML)
        {
            using (DataHelper dHelper = new DataHelper())
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(dHelper.ConnectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("InsertBiReceiverAndBiReceiverChildXML"))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add(new SqlParameter("@BiReceiverXML", allBiReceiverAndBiReceiverChildXML));

                            SqlParameter returnValue = new SqlParameter("@BiReceiverID", DbType.Int64);
                            returnValue.Direction = ParameterDirection.ReturnValue;
                            cmd.Parameters.Add(returnValue);
                            conn.Open();
                            cmd.Connection = conn;
                            int biReceiver = cmd.ExecuteNonQuery();
                            conn.Close();
                            return biReceiver;
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
