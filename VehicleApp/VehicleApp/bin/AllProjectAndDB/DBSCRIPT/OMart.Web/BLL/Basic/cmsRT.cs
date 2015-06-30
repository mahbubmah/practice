using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Basic
{
   public class cmsRT : IDisposable
    {
        private readonly OiiOMartDBDataContext _OiiOMartDBDataContext;
        public cmsRT()
        {
             _OiiOMartDBDataContext = DatabaseHelper.GetDataModelDataContext();
        }
        #region IDisposable Members
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members



        public void AddOtherContent(CMSContent CMScontent)
        {
            try
            {
                DatabaseHelper.Insert<CMSContent>(CMScontent);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public object GetCMSContentAllForListView()
        {
            try
            {
                OiiOMartDBDataContext dbContext = DatabaseHelper.GetDataModelDataContext();

                var cmsContent = from CmsContent in dbContext.CMSContents
                                   //where OtherContent.IsActive==true
                                   select new { CmsContent.IID, CmsContent.Title, CmsContent.CMSDescription, CmsContent.CMSTypeID, CmsContent.ImageUrl, CmsContent.IsActive };

                return cmsContent;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public CMSContent GetOtherContentByIID(long cmsid)
        {
            try
            {
                OiiOMartDBDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                CMSContent cmsContent = new CMSContent();
                cmsContent = dbContext.CMSContents.Single(d => d.IID == cmsid);
                dbContext.Dispose();
                return cmsContent;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public void UpdateCMScontent(CMSContent CMScontent)
        {
            try
            {
                OiiOMartDBDataContext msDC = DatabaseHelper.GetDataModelDataContext();

                CMSContent cMscontent = msDC.CMSContents.Single(d => d.IID == CMScontent.IID);
                DatabaseHelper.Update<CMSContent>(msDC, CMScontent, cMscontent);
                msDC.Dispose();
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
       public bool IsExistCMSType(int cmsIID, int cmsTypeID)
        {
           try
           {
               OiiOMartDBDataContext msDC = DatabaseHelper.GetDataModelDataContext();
               var contentData = msDC.CMSContents.Where(x => x.IID != cmsIID && x.CMSTypeID==cmsTypeID && x.IsActive == true).ToList();
               if (contentData.Count() > 0)
                   return true;
               else return false;
               

           }
           catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public bool GetCMSContentByCMStype(int cmsType)
        {
            try
            {
                OiiOMartDBDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                //CMSContent cmsContent = new CMSContent();
               var cmsContent = dbContext.CMSContents.Where(d => d.CMSTypeID == cmsType && d.IsActive==true).ToList();
               if (cmsContent.Count > 0)
               {
                   return false;
               }
               else
                   return true;
                //dbContext.Dispose();
              //  return cmsContent;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public CMSContent GetCMsContentByCMSTypeID(long Iid)
        {
            try
            {
                OiiOMartDBDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                var listdata = dbContext.CMSContents.SingleOrDefault(x => x.CMSTypeID == Iid && x.IsActive==true);
                dbContext.Dispose();
                return listdata;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
