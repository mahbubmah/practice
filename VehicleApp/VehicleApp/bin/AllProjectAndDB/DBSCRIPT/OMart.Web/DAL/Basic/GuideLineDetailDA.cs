using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Basic
{
    public static class GuideLineDetailDA
    {

        public static int InsertGuideLineDetailChildXML(string guideLineDetailChildAllChildXML)
        {
            using (DataHelper dHelper = new DataHelper())
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(dHelper.ConnectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("InsertGuideLineDetailChildXML"))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add(new SqlParameter("@GuideLineXML", guideLineDetailChildAllChildXML));
                            SqlParameter returnValue = new SqlParameter("@GuideLineID", DbType.Int64);
                            returnValue.Direction = ParameterDirection.ReturnValue;
                            cmd.Parameters.Add(returnValue);
                            conn.Open();
                            cmd.Connection = conn;
                            int mobilePhoneInfoID = cmd.ExecuteNonQuery();
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
        public static int InsertGuidelinedetailAndAllFreatureChildXML(string GuidelinedetailWithAllChildCardFeatureXML)
        {
            using (DataHelper dHelper = new DataHelper())
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(dHelper.ConnectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("[dbo].[InsertGuidelinedetailAndAllFreatureChildXML]"))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add(new SqlParameter("@GuidelinedetailXML", GuidelinedetailWithAllChildCardFeatureXML));

                            SqlParameter returnValue = new SqlParameter("@GuideLineDetailID", DbType.Int64);
                            returnValue.Direction = ParameterDirection.ReturnValue;
                            cmd.Parameters.Add(returnValue);
                            conn.Open();
                            cmd.Connection = conn;
                            int guideLineDetailID = cmd.ExecuteNonQuery();
                            conn.Close();
                            return guideLineDetailID;
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
