using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OH.DAL;

namespace OH.BLL.Basic
{
    public class MaterialLogRT : IDisposable
    {
        #region Get Methods

        public MaterialLog GetMaterialByIID(long materialIID)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                var listdata = dbContext.MaterialLogs.SingleOrDefault(x => x.IID == materialIID);
                dbContext.Dispose();
                return listdata;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void UpdateMaterial(MaterialLog material)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                var matNew = dbContext.MaterialLogs.Single(mat => mat.IID == material.IID);
                DatabaseHelper.Update<MaterialLog>(dbContext, material, matNew);
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message, exception);
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
