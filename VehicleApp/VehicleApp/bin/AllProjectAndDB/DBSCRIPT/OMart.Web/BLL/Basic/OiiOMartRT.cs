using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Basic
{
   public class OiiOMartRT: IDisposable
    {
       
        private readonly OiiOMartDBDataContext _OiiOMartDBDataContext;
        public OiiOMartRT()
        {
             _OiiOMartDBDataContext = DatabaseHelper.GetDataModelDataContext();
        }
        #region IDisposable Members

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members


        public bool GetActiveMartContent()
        {
            try
            {
                var haatContent = _OiiOMartDBDataContext.OiiOMarts.Where(d => d.IsActive == true).ToList();
                if (haatContent.Count > 0)
                {
                    return false;
                }
                else
                    return true;

            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public void AddOtherContent(OiiOMart Oiioother)
        {
            try
            {
                DatabaseHelper.Insert<OiiOMart>(Oiioother);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public object GetOiiOContentAllForListView()
        {
            try
            {
                               var MartContent = from martContent in _OiiOMartDBDataContext.OiiOMarts
                                  //where OtherContent.IsActive==true
                                  select new { martContent.IID, martContent.CompanyName, martContent.Email, martContent.Phone, martContent.Logo, martContent.IsActive, martContent.Address };

                return MartContent;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public OiiOMart GetOtherContentByIID(int HaatContentID)
        {
            try
            {
             
                OiiOMart OiioMart = new OiiOMart();
                OiioMart = _OiiOMartDBDataContext.OiiOMarts.Single(d => d.IID == HaatContentID);
                _OiiOMartDBDataContext.Dispose();
                return OiioMart;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public bool IsActiveOtherContent(int contentID)
        {
            try
            {
                OiiOMartDBDataContext msDC = DatabaseHelper.GetDataModelDataContext();
                var contentData = msDC.OiiOMarts.Where(x => x.IID != contentID && x.IsActive == true).ToList();
                if (contentData.Count() > 0)
                    return true;
                else return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public void Updateoiiomartcontent(OiiOMart oiiomartcontent)
        {
            try
            {
                OiiOMartDBDataContext msDC = DatabaseHelper.GetDataModelDataContext();

                OiiOMart Oiiomartcontent = msDC.OiiOMarts.Single(d => d.IID == oiiomartcontent.IID);
                DatabaseHelper.Update<OiiOMart>(msDC, oiiomartcontent, Oiiomartcontent);
                msDC.Dispose();
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public OiiOMart GetActiveMartContentForShow()
        {
            try
            {
             

                var haatContent = _OiiOMartDBDataContext.OiiOMarts.SingleOrDefault(d => d.IsActive == true);
                _OiiOMartDBDataContext.Dispose();
                return haatContent;

            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
    }
}
