using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OB.DAL;

namespace OB.BLL.Basic
{
    public class OiiOBookRT: IDisposable
    {
         /// <summary>
        /// Created By : Asiful Islam
      /// </summary>
        private readonly OiiOBookDCDataContext _dbContext;
        public OiiOBookRT()
        {
            this._dbContext = DatabaseHelper.GetDataModelDataContext();
        }

        #region IDisposable Members

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members

        public object GetOiiOContentAllForListView()
        {
            try
            {
             

                var BookContent = from bookContent in _dbContext.OiiOBooks
                                  //where OtherContent.IsActive==true
                                  select new { bookContent.IID, bookContent.CompanyName, bookContent.Email, bookContent.Phone, bookContent.Logo, bookContent.IsActive, bookContent.Address, bookContent.LoginLogo };

                return BookContent;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }


        public bool GetActiveBookContent()
        {
            try
            {
                

                var bookContent = _dbContext.OiiOBooks.Where(d => d.IsActive == true).ToList();
                if (bookContent.Count > 0)
                {
                    return false;
                }
                else
                    return true;

            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public void AddOtherContent(OiiOBook Oiioother)
        {
            try
            {
                DatabaseHelper.Insert<OiiOBook>(Oiioother);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public OiiOBook GetOtherContentByIID(int ContentID)
        {
            try
            {
                OiiOBook Oiiobook = new OiiOBook();
                Oiiobook = _dbContext.OiiOBooks.Single(d => d.IID == ContentID);
                _dbContext.Dispose();
                return Oiiobook;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public bool IsExistCMSType(int contentID)
        {
            try
            {
                OiiOBookDCDataContext msDC = DatabaseHelper.GetDataModelDataContext();
                var contentData = msDC.OiiOBooks.Where(x => x.IID != contentID && x.IsActive == true).ToList();
                if (contentData.Count() > 0)
                    return true;
                else return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public void Updateoiiocontent(OiiOBook oiiocontent)
        {
            try
            {
                OiiOBookDCDataContext msDC = DatabaseHelper.GetDataModelDataContext();

                OiiOBook Oiiohaatcontent = msDC.OiiOBooks.Single(d => d.IID == oiiocontent.IID);
                DatabaseHelper.Update<OiiOBook>(msDC, oiiocontent, Oiiohaatcontent);
                msDC.Dispose();
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public OiiOBook GetActiveContentForShow()
        {
            try
            {
             //   OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();

                var Content = _dbContext.OiiOBooks.SingleOrDefault(d => d.IsActive == true);
                _dbContext.Dispose();
                return Content;

            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }



        
    }
}
