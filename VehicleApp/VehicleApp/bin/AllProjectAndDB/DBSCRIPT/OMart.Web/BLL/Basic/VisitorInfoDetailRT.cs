using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Basic
{
    public class VisitorInfoDetailRT : IDisposable
    {
         public void AddVisitorInfo(VisitorInfoDetail visitor)
        {
            try
            {
                DatabaseHelper.Insert<VisitorInfoDetail>(visitor);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
        #region IDisposable Members

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members
    
    }
}
