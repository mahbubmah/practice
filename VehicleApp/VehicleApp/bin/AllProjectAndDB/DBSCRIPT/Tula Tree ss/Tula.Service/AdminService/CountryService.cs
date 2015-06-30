using System;
using System.Collections.Generic;
using System.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tula.DAL;

namespace Tula.Service.AdminService
{
    //class for any logic
    public class CountryService : IDisposable
    {
        private DBConnectionString _db;

        public CountryService()
        {
            _db = new DBConnectionString();
        }

        #region IDisposable Members

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members

      
    }
}
