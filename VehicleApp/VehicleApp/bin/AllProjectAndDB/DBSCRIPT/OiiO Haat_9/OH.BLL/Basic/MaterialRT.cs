using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OH.DAL;
using OH.Utilities;

namespace OH.BLL.Basic
{
    public class MaterialRT:IDisposable
    {
        #region Get Methods


        public void AddMaterial(Material material)
        {
            try
            {
                   DatabaseHelper.Insert<Material>(material);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
        public decimal GetLastCode()
        {
            try
            {
                decimal lastCode = default(decimal);
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();

                var obj = dbContext.Materials.OrderByDescending(x => x.Code).FirstOrDefault();
                if (obj != null)
                {
                    lastCode = Convert.ToDecimal(obj.Code);
                }
                dbContext.Dispose();
                return lastCode;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
            
        }
        public Material GetMaterialByCode(string matCode)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                var mat = dbContext.Materials.Single(materal => materal.Code == matCode);
                dbContext.Dispose();
                return mat;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public object GetMaterialNameBYAlphabet(string materialName)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                var nameList = from mtrl in dbContext.Materials
                               where (mtrl.IsExpired == false || mtrl.IsExpired == null) && (mtrl.TitleName.StartsWith(materialName))
                               select new { mtrl.IID, Name= mtrl.TitleName };
                var list = nameList.ToList();
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public static int InsertMaterialAndAllChildXML(string objectXML)
        {
            try
            {
               return MaterialDA.InsertMaterialAndAllChildXML(objectXML);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<SpGetAllMaterialForCategoreyResult> GetAllMaterialForCategory(string catagoryName)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                var listdata= dbContext.SpGetAllMaterialForCategorey(catagoryName).ToList();
                return listdata;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public List<SP_GetAllMaterialAccordingToCategoreyIIDResult> GetAllMaterialAccordingToCategoryIID(Int64 categoryIID)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                var listdata = dbContext.SP_GetAllMaterialAccordingToCategoreyIID(categoryIID).ToList();
                return listdata;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public int CountAllForMaterialType(Int64 categoryID)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                var listdata = dbContext.SP_GetAllMaterialAccordingToCategoreyIID(categoryID).ToList();
                return listdata.Count;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }
        public int CountAllForMaterialTypenClientType(Int64 categoryID, int? clientTypeId, bool isRecent)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                if (isRecent)
                {
                    var listDataCount = dbContext.GetSortedMaterialAccordingToCategoreyIIDnClientTypeIdForClientListView(clientTypeId, categoryID,DateTime.Now, null, null).Count();
                    return listDataCount;
                }
                else
                {
                    var listDataCount = dbContext.GetSortedMaterialAccordingToCategoreyIIDnClientTypeIdForClientListView(clientTypeId, categoryID,null, null, null).Count();
                    return listDataCount;
                }
               
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }
        //Mahbub
        public object GetSortedMaterialAccordingToCategoreyIidnClientTypeId(Int64 categoryID, int? clientTypeId, bool isRecent ,int startRowIndex, int maxRowNumber)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                if (isRecent)
                {
                    var listdata =
                     dbContext.GetSortedMaterialAccordingToCategoreyIIDnClientTypeIdForClientListView(clientTypeId, categoryID,DateTime.Now ,startRowIndex, maxRowNumber);
                    return listdata;
                }
                else
                {
                    var listdata =
                     dbContext.GetSortedMaterialAccordingToCategoreyIIDnClientTypeIdForClientListView(clientTypeId, categoryID, null, startRowIndex, maxRowNumber);
                    return listdata;
                }
               
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }
        /// <summary>
        /// Hasan Add 2015.03.16 For Getting AllAds 10 rows data into listview in Everytime
        /// </summary>
        /// <param name="categoryIID"></param>
        /// <param name="startRow"></param>
        /// <returns></returns>
        public List<SP_GetSortedMaterialAccordingToCategoreyIIDResult> GetSortedMaterialAccordingToCategoreyIIDnRowNumber(Int64 categoryID, int startRowIndex, int maxRowNumber)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                var listdata = dbContext.SP_GetSortedMaterialAccordingToCategoreyIID (categoryID, startRowIndex, maxRowNumber).ToList();
                return listdata;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

      

        /// <summary>
        /// Hasan Add 2015.03.09 For Recent Ads of Materials For CategoryID
        /// </summary>
        /// <param name="categoryIID"></param>
        /// <returns></returns>

        public List<SP_GetAllSortedRecentMaterialAdsForCategoreyIIDResult> GetAllSortedRecentMaterialForCategoryIID(Int64 categoryID, int startRowIndex, int maxRowNumber)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                var listdata = dbContext.SP_GetAllSortedRecentMaterialAdsForCategoreyIID(categoryID,startRowIndex,maxRowNumber).ToList();
                return listdata;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        
        public int CountAllRecentMaterialForCategoryIID(Int64 categoryID)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                var listdata = dbContext.SP_GetAllRecentMaterialAdsForCategoreyIID(categoryID).ToList();
                return listdata.Count;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public Material GetMaterialByIID(long materialIID)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                var listdata = dbContext.Materials.SingleOrDefault(x => x.IID==materialIID);
                dbContext.Dispose();
                return listdata;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void UpdateMaterial(Material material)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                var matNew = dbContext.Materials.Single(mat => mat.IID == material.IID);
                DatabaseHelper.Update<Material>(dbContext, material, matNew);
            }
            catch (Exception exception)
            {
                
                throw new Exception(exception.Message,exception);
            }
        }

        public string GetLocationByIID(Int64 locationIID)
        {
            try
            {
                Int64 locID = 0;
                string fulladdress = null;
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                var material = dbContext.Materials.FirstOrDefault(x => x.IID == locationIID);
                if (material != null)
                {
                    locID = material.LocationID;
                }
                var location = dbContext.SP_GetLocationForGoogleMap(locID).SingleOrDefault();
                fulladdress = location.CurrentLocation + ',' + location.PoliceStationName + ',' + location.DistrictName + ',' + location.DivisionOrStateName + ',' + location.CountryName;

                dbContext.Dispose();
                return fulladdress;
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
    
        public int GetCountAllMaterialForCategoryIDnClientType(Int64 categoryID, int clientType)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                var listdata = dbContext.SP_GetAllMaterialForCategoreyIIDnClientType(categoryID, clientType).ToList();
                return listdata.Count;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<SP_GetSortedAllMaterialForCategoreyIIDnClientTypeResult> GetAllSortedMaterialForCategoryIDnClientType(Int64 categoryID, int clientType, int startRowIndex, int maxRowNumber)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                var listdata = dbContext.SP_GetSortedAllMaterialForCategoreyIIDnClientType(categoryID, clientType, startRowIndex,maxRowNumber).ToList();
                return listdata;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public object GetLocationByMaterialIID(long id)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                var listdata = dbContext.SP_GetLocationByMaterialIID(id).SingleOrDefault();
                return listdata.CurrentLocation;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public object GetAllMaterial()
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                var nameList = from mtrl in dbContext.Materials
                               where (mtrl.IsExpired == false )
                               select mtrl;
               // var list = nameList.ToList();
                return nameList.Take(5);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
    }
}
