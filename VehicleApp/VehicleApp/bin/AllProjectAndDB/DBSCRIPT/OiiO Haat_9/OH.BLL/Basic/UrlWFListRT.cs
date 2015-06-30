using OH.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OH.DAL;
namespace OH.BLL.Basic
{
    public class UrlWFListRT:IDisposable
    {
        public UrlWFListRT()
        {
        }

        #region Get methods

        public UrlWFList GetUrlWFListByID(int urlListID)
        {
            
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                UrlWFList urlWFListList = new UrlWFList();
                urlWFListList = dbContext.UrlWFLists.Single(d => d.IID == urlListID);
                dbContext.Dispose();
                return urlWFListList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

   

        public List<UrlWFList> GetUrlWFListByNmae(string name)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<UrlWFList> urlWFListList = new List<UrlWFList>();
                urlWFListList = dbContext.UrlWFLists.Where(d => d.UrlWFName.Contains(name)).ToList();

                dbContext.Dispose();
                return urlWFListList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public List<UrlWFList> GetUrlWFListAll()
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<UrlWFList> urlWFListList = new List<UrlWFList>();
                urlWFListList = dbContext.UrlWFLists.ToList();

                dbContext.Dispose();
                return urlWFListList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public object GetUrlWFListAllForListView()
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();

                var urlWFListList = from des in dbContext.UrlWFLists
                                   // join country in dbContext.Countries on des.ApplicableCountryID equals country.IID
                                    select new { des.IID, des.ModuleName, des.ModuleSerialNo, des.UrlWFName, des.UrlWFSerialNo, des.UrlWFDisplayName };

                var activeUrlWFList = urlWFListList.ToList();
                //dbContext.Dispose();
                return activeUrlWFList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }

        }

        public void AddUrlWFList(UrlWFList urlWFList)
        {
            try
            {
                DatabaseHelper.Insert<UrlWFList>(urlWFList);
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message, ex); 
            }
        }

        public void UpdateUrlWFList(UrlWFList urlWFList)
        {
            try
            {
                OiiOHaatDCDataContext msDC = DatabaseHelper.GetDataModelDataContext();

                UrlWFList urlWFListNew = msDC.UrlWFLists.Single(d => d.IID == urlWFList.IID);
                DatabaseHelper.Update<UrlWFList>(msDC, urlWFList, urlWFListNew);

                msDC.Dispose();
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public void DeleteUrl(int urlWFListID)
        {
            OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
            dbContext.SpDeleteUrlList(urlWFListID);
        }

        #endregion Get methods

        #region IDisposable Members

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members

        public List<UserWFPermission> checkUrlListByID(int p)
        {
            OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
            
            List<UserWFPermission> checkUrl = new List<UserWFPermission>();
            checkUrl = dbContext.UserWFPermissions.Where(d => d.UrlWFListID == p).ToList();

            dbContext.Dispose();
            
            return checkUrl;
        }

       
    }
}
