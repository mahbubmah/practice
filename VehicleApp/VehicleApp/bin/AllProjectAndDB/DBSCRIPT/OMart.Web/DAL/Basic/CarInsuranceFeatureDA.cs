﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Basic
{
    public static class CarInsuranceFeatureDA
    {
        public static int InsertCarInsuranceAndFeatureChildXML(string CarInsuranceFeatureAllChildXML)
        {
            using (DataHelper dHelper = new DataHelper())
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(dHelper.ConnectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("InsertCarInsuranceFreatureChildXML"))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add(new SqlParameter("@CarInsuranceFreatureXML", CarInsuranceFeatureAllChildXML));

                            SqlParameter returnValue = new SqlParameter("@CarInsuranceID", DbType.Int64);
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

    }
}