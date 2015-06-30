using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OH.DAL;

namespace OH.BLL.Basic
{
  public  class OtherContentRT:IDisposable
    {
      /// <summary>
        /// Created By : Asiful Islam
      /// </summary>
        private readonly OiiOHaatDCDataContext _dbContext;
        public OtherContentRT()
        {
            this._dbContext = DatabaseHelper.GetDataModelDataContext();
        }

        #region IDisposable Members

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members



        public void AddOtherContent(OiiOOther Oiioother)
        {
            try
            {
                DatabaseHelper.Insert<OiiOOther>(Oiioother);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public object GetotherContentAllForListView()
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();

                var otherContent = from OtherContent in dbContext.OiiOOthers
                                   //where OtherContent.IsActive==true
                                   select new { OtherContent.IID, OtherContent.Title, OtherContent.ShortDescription, OtherContent.DetailDescription, OtherContent.ImageUrl, OtherContent.IsActive };
               
                return otherContent;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public void Updateoiiocontent(OiiOOther oiiocontent)
        {
            try
            {
                OiiOHaatDCDataContext msDC = DatabaseHelper.GetDataModelDataContext();

                OiiOOther Oiiocontent = msDC.OiiOOthers.Single(d => d.IID == oiiocontent.IID);
                DatabaseHelper.Update<OiiOOther>(msDC, oiiocontent, Oiiocontent);
                msDC.Dispose();
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public OiiOOther GetOtherContentByIID(int OtherContentID)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                OiiOOther Oiioother = new OiiOOther();
                Oiioother = dbContext.OiiOOthers.Single(d => d.IID == OtherContentID);
                dbContext.Dispose();
                return Oiioother;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }



        public OH_OT_GetAllOtherContentResult GetotherContentAccordingToId(Int64 Iid)
        {
            try
            {
                var obj = _dbContext.OH_OT_GetAllOtherContent().SingleOrDefault(x => x.IID == Iid);
                return obj;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public object GetotherActiveContentAllForListView()
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();

                var otherContent = from OtherContent in dbContext.OiiOOthers
                                   where OtherContent.IsActive == true
                                   select new { OtherContent.IID, OtherContent.Title, OtherContent.ShortDescription, OtherContent.DetailDescription, OtherContent.ImageUrl, OtherContent.IsActive };

                return otherContent;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }



        public List<SP_GetWholeWebSearchResult> GetSearchResultForListView(string search)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                var SearchResul = dbContext.SP_GetWholeWebSearch(search).ToList();
                return SearchResul;
            }

            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
    }
}
