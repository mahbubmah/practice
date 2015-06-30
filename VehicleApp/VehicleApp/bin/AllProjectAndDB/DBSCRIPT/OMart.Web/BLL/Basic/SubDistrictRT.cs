using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Basic
{
    public class SubDistrictRT:IDisposable
    {
         private readonly OiiOMartDBDataContext _OiiOMartDBDataContext;
         public SubDistrictRT()
        {
            _OiiOMartDBDataContext = DatabaseHelper.GetDataModelDataContext();
        }



        #region IDisposable Members
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members

        public bool GetSubDistrictByID(long p)
        {
            throw new NotImplementedException();
        }
    }
}
