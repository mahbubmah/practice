using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataHelper : IDisposable
    {
        public string ConnectionString;

        public DataHelper()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString(); //AppSettings["DBConnectionString"].ToString();
        }

        public string GetConnectionString()
        {
            return ConnectionString;
        }

        public DataTable GetDataFromTable(string sql)
        {
            DataTable _table = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        using (SqlDataReader reder = command.ExecuteReader())
                        {
                            lock (_table)
                            {
                                _table.Load(reder);
                            }
                            conn.Close();
                            //return _table;
                        }

                    }
                }
            }
            catch (Exception ex)
            { }


            return _table;

        }
        public string GetUserID()
        {
            string conComponent = string.Empty;
            try
            {
                SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder(new DataHelper().GetConnectionString());
                conComponent = stringBuilder.UserID;
            }
            catch(Exception ex)
            {

            }
            return conComponent;
        }
        public string GetPassword()
        {
            string conComponent = string.Empty;
            try
            {
                SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder(new DataHelper().GetConnectionString());
                conComponent = stringBuilder.Password;
            }
            catch (Exception ex)
            {

            }
            return conComponent;
        }
        public string GetServer()
        {
            string conComponent = string.Empty;
            try
            {
                SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder(new DataHelper().GetConnectionString());
                conComponent = stringBuilder.DataSource;
            }
            catch (Exception ex)
            {

            }
            return conComponent;
        }
        public string GetDataBase()
        {
            string conComponent = string.Empty;
            try
            {
                SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder(new DataHelper().GetConnectionString());
                conComponent = stringBuilder.InitialCatalog;
            }
            catch (Exception ex)
            {

            }
            return conComponent;
        }

        public void Dispose()
        {
            GC.Collect();
        }
    }
}
