using System;
using System.Collections.Generic;
using System.Linq;
using Tula.DAL;

namespace Tula.BLL.Basic
{
   public class CmsRt : IDisposable
    {
        private readonly DBConnectionString _db;
        public CmsRt()
        {
            _db = DatabaseHelper.GetDataModelDataContext();
        }
        #region IDisposable Members
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members



        public void AddOtherContent(CMSContent cmScontent)
        {
            try
            {
                DatabaseHelper.Insert<CMSContent>(cmScontent);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public List<CMSContent> GetCmsContentAllForListView()
        {
            try
            {
                var cmsContent = from cmsCon in _db.CMSContents
                    select cmsCon;

                return cmsContent.ToList();
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public CMSContent GetOtherContentByIid(long cmsid)
        {
            try
            {
                var cmsContent = _db.CMSContents.Single(d => d.IID == cmsid);
                _db.Dispose();
                return cmsContent;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public void UpdateCmScontent(CMSContent cmScontent)
        {
            try
            {
               
                var cMscontent = _db.CMSContents.Single(d => d.IID == cmScontent.IID);
                DatabaseHelper.Update<CMSContent>(_db, cmScontent, cMscontent);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
       public bool IsExistCmsType(int cmsIid, int cmsTypeId)
        {
           try
           {
               var contentData = _db.CMSContents.Where(x => x.IID != cmsIid && x.CMSTypeID==cmsTypeId && x.IsActive).ToList();
               return contentData.Any();
           }
           catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public bool GetCmsContentByCmStype(int cmsType)
        {
            try
            {
                var cmsContent = _db.CMSContents.Where(d => d.CMSTypeID == cmsType && d.IsActive).ToList();
                return cmsContent.Count <= 0;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public CMSContent GetCMsContentByCmsTypeId(long iid)
        {
            try
            {
                var listdata = _db.CMSContents.SingleOrDefault(x => x.CMSTypeID == iid && x.IsActive);
                _db.Dispose();
                return listdata;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
