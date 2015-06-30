using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OH.DAL;

namespace OH.BLL.Basic
{
    public class MaterialAdGiverRT : IDisposable
    {
        #region IDisposable Members

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members



        #region Get Methods
        public List<GetAdGiverMaterialsForSearchResult> GetSearchedMaterialsForListView(Int64? categoryID, string userId, string materialCode, DateTime? fromDate, DateTime? toDate)
        {
            try
            {
                OiiOHaatDCDataContext db = DatabaseHelper.GetDataModelDataContext();
                var materialList = db.GetAdGiverMaterialsForSearch(categoryID,userId , materialCode, fromDate, toDate).ToList();
                return materialList;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
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
                throw new Exception(exception.Message, exception);
            }
        }

        public List<GetAdGiverArcMaterialsForSearchResult> GetSearchedArcMaterialsForListView(long? categoryID, string userID, string matCode, DateTime? fD, DateTime? tD)
        {
            try
            {
                OiiOHaatDCDataContext db = DatabaseHelper.GetDataModelDataContext();
                var materialArcList = db.GetAdGiverArcMaterialsForSearch(categoryID, userID, matCode, fD, tD).ToList();
                return materialArcList;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
    }
    
}
