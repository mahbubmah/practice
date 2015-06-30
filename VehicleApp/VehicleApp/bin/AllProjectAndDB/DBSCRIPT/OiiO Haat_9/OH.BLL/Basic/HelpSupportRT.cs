using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OH.DAL;

namespace OH.BLL.Basic
{
    public class HelpSupportRT : IDisposable
    {

         private readonly OiiOHaatDCDataContext _OiiOHaatDBDataContext;
         public HelpSupportRT()
        {
            _OiiOHaatDBDataContext = DatabaseHelper.GetDataModelDataContext();
        }
        #region IDisposable Members
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members


        public void AddOtherContent(OiiOHaatHelpSupport HelpSupportcontent)
        {
            try
            {
                DatabaseHelper.Insert<OiiOHaatHelpSupport>(HelpSupportcontent);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public object GetHelpSupportAllForListView()
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();

                var helpsupport = from helpSupport in dbContext.OiiOHaatHelpSupports
                                 //where OtherContent.IsActive==true
                                  select new { helpSupport.IID, helpSupport.Title, helpSupport.HelpSupportTypeID, helpSupport.Image, helpSupport.IsActive };

                return helpsupport;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public OiiOHaatHelpSupport GetOtherContentByIID(long helpSupportid)
        {
            try
            {
               // OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                OiiOHaatHelpSupport helpsupportContent = new OiiOHaatHelpSupport();
                helpsupportContent = _OiiOHaatDBDataContext.OiiOHaatHelpSupports.Single(d => d.IID == helpSupportid);
                _OiiOHaatDBDataContext.Dispose();
                return helpsupportContent;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public void UpdateCMScontent(OiiOHaatHelpSupport HelpSupportcontent)
        {
            try
            {
                OiiOHaatDCDataContext msDC = DatabaseHelper.GetDataModelDataContext();

                OiiOHaatHelpSupport hpSuprtcontent = msDC.OiiOHaatHelpSupports.Single(d => d.IID == HelpSupportcontent.IID);
                DatabaseHelper.Update<OiiOHaatHelpSupport>(msDC, HelpSupportcontent, hpSuprtcontent);
                msDC.Dispose();
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public object GetHelpSupportAccordingToHelpSupportID(int supportID, int startRowIndex, int maxRowNumber)
        {
            try
            {
                //OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();

                var listdata = _OiiOHaatDBDataContext.SP_GetHelpSupportAccordingToHelpSupportID(supportID, startRowIndex, maxRowNumber);
                return listdata;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public int GetCountTotalRowsForHelpSupport(int supportID)
        {
            try
            {
                var rows = _OiiOHaatDBDataContext.OiiOHaatHelpSupports.Where(d => d.IsActive==true && d.HelpSupportTypeID == supportID);
                return rows.ToList().Count;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }
    }
}
