using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OB.DAL;


namespace BLL.Basic
{
    public class LocationRT : IDisposable
    {
        private readonly OiiOBookDCDataContext _OiiOBookDCDataContext;
        public LocationRT()
        {
            _OiiOBookDCDataContext = DatabaseHelper.GetDataModelDataContext();
        }

        #region Get Methods
        public Location GetLocationByIID(long locationID)
        {
            try
            {
                Location location = _OiiOBookDCDataContext.Locations.SingleOrDefault(loc => loc.IID == locationID);
                return location;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        #endregion Get Methods
       


        #region IDisposable Members
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members

     
    }
}
