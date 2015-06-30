using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OH.DAL;

namespace OH.BLL.Basic
{
    public class OiiOHaatRT : IDisposable
    {
         /// <summary>
        /// Created By : Asiful Islam
      /// </summary>
        private readonly OiiOHaatDCDataContext _dbContext;
        public OiiOHaatRT()
        {
            this._dbContext = DatabaseHelper.GetDataModelDataContext();
        }

        #region IDisposable Members

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members


        public void AddOtherContent(OiiOHaat Oiioother)
        {
            try
            {
                DatabaseHelper.Insert<OiiOHaat>(Oiioother);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public object GetOiiOContentAllForListView()
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();

                var HaatContent = from haatContent in dbContext.OiiOHaats
                                   //where OtherContent.IsActive==true
                                  select new { haatContent.IID, haatContent.CompanyName, haatContent.Email, haatContent.Phone, haatContent.Logo, haatContent.IsActive, haatContent.Address,haatContent.LoginLogo };

                return HaatContent;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public OiiOHaat GetOtherContentByIID(int HaatContentID)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                OiiOHaat OiioHaat = new OiiOHaat();
                OiioHaat = dbContext.OiiOHaats.Single(d => d.IID == HaatContentID);
                dbContext.Dispose();
                return OiioHaat;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public void Updateoiiohaatcontent(OiiOHaat oiiohaatcontent)
        {
            try
            {
                OiiOHaatDCDataContext msDC = DatabaseHelper.GetDataModelDataContext();

                OiiOHaat Oiiohaatcontent = msDC.OiiOHaats.Single(d => d.IID == oiiohaatcontent.IID);
                DatabaseHelper.Update<OiiOHaat>(msDC, oiiohaatcontent, Oiiohaatcontent);
                msDC.Dispose();
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public bool GetActiveHaatContent()
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
               
                var haatContent = dbContext.OiiOHaats.Where(d => d.IsActive == true).ToList();
                if (haatContent.Count > 0)
                {
                    return false;
                }
                else
                    return true;
             
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public bool IsExistCMSType(int contentID)
        {
            try
            {
                OiiOHaatDCDataContext msDC = DatabaseHelper.GetDataModelDataContext();
                var contentData = msDC.OiiOHaats.Where(x => x.IID != contentID && x.IsActive == true).ToList();
                if (contentData.Count() > 0)
                    return true;
                else return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public OiiOHaat GetActiveHaatContentForShow()
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();

                var haatContent = dbContext.OiiOHaats.SingleOrDefault(d => d.IsActive == true);
                dbContext.Dispose();
                return haatContent;

            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
    }
}
