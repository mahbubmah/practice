using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Basic
{
    public class UserRegistrationRT : IDisposable
    {
         private readonly OiiOMartDBDataContext _dbContext;
         public UserRegistrationRT()
        {
            this._dbContext = DatabaseHelper.GetDataModelDataContext();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
