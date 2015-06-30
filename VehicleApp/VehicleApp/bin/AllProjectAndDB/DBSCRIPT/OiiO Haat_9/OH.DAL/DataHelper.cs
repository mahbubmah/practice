using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OH.DAL
{
    public class DataHelper : IDisposable
    {
        public string ConnectionString;

        public DataHelper()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString(); //AppSettings["DBConnectionString"].ToString();
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

        public void Dispose()
        {
            GC.Collect();
        }
    }
}
