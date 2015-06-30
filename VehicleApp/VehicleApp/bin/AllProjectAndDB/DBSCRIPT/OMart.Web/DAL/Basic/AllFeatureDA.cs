using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Basic
{
    public class AllFeatureDA
    {

        public static int InsertAllFatureAndAllChildAllFeatureDetailsXML(string allFeatureAllChildAllFeatureDetailsXML)
        {
            using (DataHelper dHelper = new DataHelper())
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(dHelper.ConnectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("InsertAllFeatureAndAllChildAllFeatureCartDetailsXML"))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add(new SqlParameter("@AllFeatureXML", allFeatureAllChildAllFeatureDetailsXML));

                            SqlParameter returnValue = new SqlParameter("@AllFeatureID", DbType.Int64);
                            returnValue.Direction = ParameterDirection.ReturnValue;
                            cmd.Parameters.Add(returnValue);
                            conn.Open();
                            cmd.Connection = conn;
                            int allNews = cmd.ExecuteNonQuery();
                            conn.Close();
                            return allNews;
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
