using OH.DAL.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OH.BLL.Basic
{
    public class GlobalRT
    {
        public GlobalRT()
        {
        }

        public static DateTime GetServerDateTime()
        {
            try
            {
                return GlobalDA.GetServerDateTime();
               // return DateTime.Now;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
