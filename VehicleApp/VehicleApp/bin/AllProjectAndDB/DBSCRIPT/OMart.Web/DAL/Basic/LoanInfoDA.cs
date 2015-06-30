using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Basic
{
    public static class LoanInfoDA
    {
        public static int InsertLoanInfoAndFeatureChildXML(string LoanInfoAndFeatureChildXML)
        {
            using (DataHelper dHelper = new DataHelper())
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(dHelper.ConnectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("InsertLoanInfoFeatureChildXML"))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add(new SqlParameter("@LoanInfoXML", LoanInfoAndFeatureChildXML));

                            SqlParameter returnValue = new SqlParameter("@LoanInfoID", DbType.Int64);
                            returnValue.Direction = ParameterDirection.ReturnValue;
                            cmd.Parameters.Add(returnValue);
                            conn.Open();
                            cmd.Connection = conn;
                            int loaninfoID = cmd.ExecuteNonQuery();
                            conn.Close();
                            return 1;
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
