﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Basic
{
   public static class AllNewsDA
    {
       public static int InsertAllNewsAndAllChildAllNewsCartDetailsXML(string allNewsAllChildAllNewsDetailsXML)
       {
           using (DataHelper dHelper = new DataHelper())
           {
               try
               {
                   using (SqlConnection conn = new SqlConnection(dHelper.ConnectionString))
                   {
                       using (SqlCommand cmd = new SqlCommand("InsertAllNewsAndAllChildAllNewsCartDetailsXML"))
                       {
                           cmd.CommandType = CommandType.StoredProcedure;
                           cmd.Parameters.Add(new SqlParameter("@AllNewsXML", allNewsAllChildAllNewsDetailsXML));

                           SqlParameter returnValue = new SqlParameter("@AllNewsID", DbType.Int64);
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