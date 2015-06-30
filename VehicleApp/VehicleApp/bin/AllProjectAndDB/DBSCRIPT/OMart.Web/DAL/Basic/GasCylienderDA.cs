using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Basic
{
    public static class GasCylienderDA
    {
            public static int InsertGasCylienderAndAllChildGasCylinderAndDealerInfoMappingXml(string allGasCylienderAndAllChildGasCylinderAndDealerInfoMappingXml)
            {
                using (DataHelper dHelper = new DataHelper())
                {
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(dHelper.ConnectionString))
                        {
                            using (SqlCommand cmd = new SqlCommand("InsertGasCylienderAndAllChildGasCylinderAndDealerInfoMappingXML"))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add(new SqlParameter("@GasCylienderXML", allGasCylienderAndAllChildGasCylinderAndDealerInfoMappingXml));

                                SqlParameter returnValue = new SqlParameter("@GasCylienderXML", DbType.Int64);
                                returnValue.Direction = ParameterDirection.ReturnValue;
                                cmd.Parameters.Add(returnValue);
                                conn.Open();
                                cmd.Connection = conn;
                                int gasCyliender = cmd.ExecuteNonQuery();
                                conn.Close();
                                return gasCyliender;
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
