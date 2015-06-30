using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OB.DAL;

namespace OB.BLL.Basic
{
   public class cmsRT : IDisposable
    {
        private readonly OiiOBookDCDataContext _OiiOBooKDBDataContext;
        public cmsRT()
        {
            _OiiOBooKDBDataContext = DatabaseHelper.GetDataModelDataContext();
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
              

                var cmsContent = from CmsContent in _OiiOBooKDBDataContext.CMSContents
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
                
                CMSContent cmsContent = new CMSContent();
                cmsContent = _OiiOBooKDBDataContext.CMSContents.Single(d => d.IID == cmsid);
                _OiiOBooKDBDataContext.Dispose();
                return cmsContent;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public void UpdateCMScontent(CMSContent CMScontent)
        {
            try
            {
                OiiOBookDCDataContext msDC = DatabaseHelper.GetDataModelDataContext();

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
               OiiOBookDCDataContext msDC = DatabaseHelper.GetDataModelDataContext();
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
              
               var cmsContent = _OiiOBooKDBDataContext.CMSContents.Where(d => d.CMSTypeID == cmsType && d.IsActive==true).ToList();
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
             
                var listdata = _OiiOBooKDBDataContext.CMSContents.SingleOrDefault(x => x.CMSTypeID == Iid && x.IsActive==true);
                _OiiOBooKDBDataContext.Dispose();
                return listdata;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
