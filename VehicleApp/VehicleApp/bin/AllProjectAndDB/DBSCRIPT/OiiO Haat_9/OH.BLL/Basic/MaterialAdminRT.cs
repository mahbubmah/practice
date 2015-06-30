using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OH.DAL;

namespace OH.BLL.Basic
{
    public class MaterialAdminRT:IDisposable
    {
        #region IDisposable Members

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members



        #region Get Methods
        public List<GetMaterialsForSearchResult> GetSearchedMaterialsForListView(Int64? categoryID, Int64? pstedByID, string materialCode, DateTime? fromDate, DateTime? toDate)
        {
            try
            {
                OiiOHaatDCDataContext db = DatabaseHelper.GetDataModelDataContext();
                var materialList = db.GetMaterialsForSearch(categoryID, pstedByID, materialCode, fromDate, toDate).ToList();
                return materialList;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message,ex);
            }

        }
        #endregion Get Methods

        public void DeleteFromMaterialAndPicAndSaveToLog(long matId)
        {
            try
            {
                OiiOHaatDCDataContext db = DatabaseHelper.GetDataModelDataContext();
                db.DeleteFromMaterialAndSaveToLog(matId);
            }
            catch (Exception exception)
            {
                
                throw new Exception(exception.Message,exception);
            }
        }

        public object GetSearchedArcMaterialsForListView(long? categoryID, long? pstedByID, string matCode, DateTime? fD, DateTime? tD)
        {
            try
            {
                OiiOHaatDCDataContext db = DatabaseHelper.GetDataModelDataContext();
                var materialList = db.GetArcMaterialsForSearch(categoryID, pstedByID, matCode, fD, tD).ToList();
                return materialList;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
    }
}
