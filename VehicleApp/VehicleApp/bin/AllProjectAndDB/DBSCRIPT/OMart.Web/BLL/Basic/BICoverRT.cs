using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Basic
{
    public class BICoverRT:IDisposable
    {
          private readonly OiiOMartDBDataContext dbContext;
          public BICoverRT()
        {
            dbContext = DatabaseHelper.GetDataModelDataContext();
        }
        #region IDisposable Members
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members
    }
}
