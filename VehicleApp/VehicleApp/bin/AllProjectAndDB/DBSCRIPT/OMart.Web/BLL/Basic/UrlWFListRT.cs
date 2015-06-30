using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;


namespace BLL.Basic
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
                OiiOMartDBDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
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
                OiiOMartDBDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<UrlWFList> urlWFListList = new List<UrlWFList>();
                urlWFListList = dbContext.UrlWFLists.Where(d => d.UrlWFName==name).ToList();

                dbContext.Dispose();
                return urlWFListList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public List<UrlWFList> GetUrlWFListAll()
        {
            try
            {
                OiiOMartDBDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
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
                OiiOMartDBDataContext dbContext = DatabaseHelper.GetDataModelDataContext();

                var urlWFListList = from des in dbContext.UrlWFLists
                                   // join country in dbContext.Countries on des.ApplicableCountryID equals country.IID
                                    select new { des.IID, des.ModuleName, des.ModuleSerialNo, des.UrlWFName, des.UrlModuleName, des.UrlWFSerialNo, des.ModuleImage,des.ModuleNote, des.UrlWFDisplayName };

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
                OiiOMartDBDataContext msDC = DatabaseHelper.GetDataModelDataContext();

                UrlWFList urlWFListNew = msDC.UrlWFLists.Single(d => d.IID == urlWFList.IID);
                DatabaseHelper.Update<UrlWFList>(msDC, urlWFList, urlWFListNew);

                msDC.Dispose();
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public void DeleteUrl(int urlWFListID)
        {
            OiiOMartDBDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
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
            OiiOMartDBDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
            
            List<UserWFPermission> checkUrl = new List<UserWFPermission>();
            checkUrl = dbContext.UserWFPermissions.Where(d => d.UrlWFListID == p).ToList();

            dbContext.Dispose();
            
            return checkUrl;
        }

       
    
    }
}
