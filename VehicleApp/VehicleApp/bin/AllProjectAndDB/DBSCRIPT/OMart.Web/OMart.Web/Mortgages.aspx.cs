using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using DAL;
using BLL.Basic;
using System.IO;

namespace OMart.Web
{
	public partial class Mortgages : System.Web.UI.Page
	{
        private readonly string _visitorLogPath;
        private string _pageLogPath;
        public Mortgages()
        {
            this._visitorLogPath = Server.MapPath("~/Log file/VisitorlogFileWriting.txt");
        }
        protected void Page_Load(object sender, EventArgs e)
		{
            try
            {
                string pageName = Path.GetFileName(Request.PhysicalPath);
                _pageLogPath = Server.MapPath("~/Log file/" + pageName + ".txt");
                BindAllMortgageTypeInfo();
                if(!IsPostBack)
                {
                    LogFileHelper.VisitorLogFileWritten(_visitorLogPath);
                   
                    GetAllMortgagePrivider();
                }

            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }

        }
        #region private method
        private void BindAllMortgageTypeInfo()
        {
            try
            {
                List<MortgageType> typeInfo = new List<MortgageType>();
                using (MortgageRT rt = new MortgageRT())
                {
                    typeInfo = rt.GetFourMortgageTypeInfo();
                    rptMortgageTypeDisplay.DataSource = typeInfo;
                    rptMortgageTypeDisplay.DataBind();
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }

        }

        private void GetAllMortgagePrivider()
        {
            try
            { 
                using(MortgageRT rt = new MortgageRT())
                {
                    var mortgageProvider = rt.GetMortgageProvider();
                    rptMortgageProvider.DataSource = mortgageProvider;
                    rptMortgageProvider.DataBind();
                }
                
            }
            catch(Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        
        }
        #endregion private method

        protected void rptMortgageProvider_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
           // GetAllMortgagePrivider();
        }

        protected void lnkBtnMotgageType_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lb = (LinkButton)sender;
                Int64 typeID = Convert.ToInt16(lb.CommandArgument.ToString());
                Response.Redirect("MortgageDetails.aspx?mOption=" + StringCipher.Encrypt(typeID.ToString()), false);
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        protected void lnkBtnReadMore_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lb = (LinkButton)sender;
                Int64 typeID = Convert.ToInt16(lb.CommandArgument.ToString());
                Response.Redirect("MortgageDetails.aspx?mOption=" + StringCipher.Encrypt(typeID.ToString()), false);
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        protected void lnkBtnViewAll_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("MortgageDetails.aspx",false);
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

              protected void lnkBtnMtProvider_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("MortgageDetails.aspx", false);
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        protected void lkbMorgageProvider_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("MortgageDetails.aspx", false);
            }
            catch (Exception ex)
            {

            }

        }

        protected void MortgateNews_Click(object sender, EventArgs e)
        {
            try
            {
                AllNewsRT allNewsRT = new AllNewsRT();
                int ID = allNewsRT.GeTop1AllNewsIIDForBusinessTypeIDnBreakDownID(Convert.ToInt32(EnumCollection.BussinessType.Banking), Convert.ToInt32(EnumCollection.BusinessBankingType.Mortgages));
                if(ID>0)
                {
                    Response.Redirect("AllNewsDetails?ID=" + StringCipher.Encrypt(ID.ToString()), false);
                }
                else
                {
                    lBtnMortgagedNews.Attributes.Add("onClick", "javascript:alert('No News posted!');");                                     
                }

               
            }
            catch (Exception ex)
            {

                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

    }
}