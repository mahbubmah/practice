using BLL.Basic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace OMart.Web
{
    public partial class LoanInformationDisplay : System.Web.UI.Page
    {
        private readonly string _visitorLogPath;
        private string _pageLogPath;
        private readonly LoanInformationRT _LoanInformaitonRT;
        public LoanInformationDisplay()
        {
            this._visitorLogPath = Server.MapPath("~/Log file/VisitorlogFileWriting.txt");
            this._LoanInformaitonRT = new LoanInformationRT();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string pageName = Path.GetFileName(Request.PhysicalPath);
                _pageLogPath = Server.MapPath("~/Log file/" + pageName + ".txt");

                if (!IsPostBack)
                {
                    LogFileHelper.VisitorLogFileWritten(_visitorLogPath);
                    LoadAllLoanType();
                    LoadCompanyLogo(Convert.ToInt32(EnumCollection.BussinessType.Banking));
                    LoadGuidesBusinessType(Convert.ToInt32 (EnumCollection.BussinessType.Banking)); /* Banking=2*/
                    LoadNewsByBusinessTypeID(Convert.ToInt32(EnumCollection.BussinessType.Banking)); /*Shopping=5*/
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private void LoadNewsByBusinessTypeID(int businessTypeID)
        {
            try
            {
                AllNewsRT allNewsRT = new AllNewsRT();
                repBankingNews.DataSource = allNewsRT.GetRandomNewsRowsByBusinessTypeID(businessTypeID);
                repBankingNews.DataBind();

            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private void LoadGuidesBusinessType(int bussinessType)
        {
            try
            {
                GuideLineRT guideLineRt = new GuideLineRT();
                repBankingLoanGuide.DataSource = guideLineRt.GetAllrowsForBusinessTypeID(bussinessType);
                repBankingLoanGuide.DataBind();

            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private void LoadCompanyLogo( int businessTypeID)
        {
            try
            {
                CompanyInfoRT companyInfoRT = new CompanyInfoRT();
                repLoanProvider.DataSource = companyInfoRT.GetRandomCompanyInfoByBusinessTypeID(businessTypeID); 
                repLoanProvider.DataBind();
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }

        }

        private void LoadAllLoanType()
        {
            try
            {
                repLoanType.DataSource = _LoanInformaitonRT.GetAllLoanInformation();
                repLoanType.DataBind();
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }         
        }
        #region Private Methods
        #endregion  Private Methods
    }
}