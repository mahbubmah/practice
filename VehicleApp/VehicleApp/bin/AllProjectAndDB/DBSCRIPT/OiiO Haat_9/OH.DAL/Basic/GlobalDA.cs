using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OH.DAL.Basic
{
    public static class GlobalDA
    {
        public static DateTime GetServerDateTime()
        {
            try
            {
                using (DataHelper dHelper = new DataHelper())
                {
                    using (SqlConnection connection = new SqlConnection(dHelper.ConnectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("GetServerDateTime"))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            connection.Open();
                            cmd.Connection = connection;
                            object returnValue;
                            returnValue = cmd.ExecuteScalar();
                            DateTime serverDateTime = (DateTime)returnValue;
                            connection.Close();
                            return serverDateTime;
                        }
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
