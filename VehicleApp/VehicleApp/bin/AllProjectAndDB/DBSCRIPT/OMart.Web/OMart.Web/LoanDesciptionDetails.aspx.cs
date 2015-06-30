using BLL.Basic;
using DAL;
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
    public partial class LoanDesciptionDetails : System.Web.UI.Page
    {
        private readonly string _visitorLogPath;
        private string _pageLogPath;
        private readonly LoanInformationRT _LoanInformaitonRT;
        int loanTypeID = 0;
        //int _amount = 0;
        //int _duration = 0;
        //int lvRowCount = 0;
        int currentPage = 0;
        public LoanDesciptionDetails()
        {
            this._LoanInformaitonRT = new LoanInformationRT();
            this._visitorLogPath = Server.MapPath("~/Log file/VisitorlogFileWriting.txt");
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
                    //objDataSourceLoanDetail.CacheDuration = Session.Timeout;
                    loanTypeID=GetQueryStringDataForSearch();
                    //LoadLoanDesciptionDetailsListView(loanTypeID);
                    LoadDropDownLoanType(loanTypeID);
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        #region Private Methods
        private void LoadDropDownLoanType(int loanTypeID)
        {
            try
            {
                List<LoanType> loanTypeList = new List<LoanType>();
                loanTypeList = _LoanInformaitonRT.GetAllLoanType();
                DropDownListHelper.Bind<LoanType>(ddlLoanType, loanTypeList, "Name", "IID", EnumCollection.ListItemType.LoanType);
                ddlLoanType.SelectedValue = loanTypeID.ToString();
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
        public void ClearText()
        {
            txtDuration.Text = string.Empty;
            txtTotalAmount.Text = string.Empty;
        }

        //private void LoadLoanDesciptionDetailsListView( int LoanTypeID)
        //{
        //    try
        //    {
        //        lvLoanDescriptionDetail.DataSource = _LoanInformaitonRT.GetAllLoanDescription(LoanTypeID);
        //        lvLoanDescriptionDetail.DataBind();
            
        //    }
        //    catch (Exception ex)
        //    {
        //        LogFileWritten(ex.Message, ex.StackTrace);
        //    }
            
        //}

        private int GetQueryStringDataForSearch()
        {
            int loanType = default(int);
            try
            {
                if (!string.IsNullOrEmpty(Request.QueryString[0]))
                {
                    string reqIDIsValid = Request.QueryString[0];
                    loanType = Convert.ToInt32(StringCipher.Decrypt(Request.QueryString["ID"]).ToString());
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
            return loanType;
        }

        #endregion Private Method

        #region Protected Method
        protected void repDescription_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListViewItemType.DataItem)
                {
                    HiddenField objIID = e.Item.FindControl("hdLoanInfoID") as HiddenField;

                    var objLoanInfoFeature = _LoanInformaitonRT.GetLoanFeature(Convert.ToInt64 (objIID.Value));
                    Repeater objRepeater = e.Item.FindControl("repDescription") as Repeater;

                    objRepeater.DataSource = objLoanInfoFeature;
                    objRepeater.DataBind();
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
        //protected void dataPagerLoanDescriptionDetail_PreRender(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //lvRowCount = currentPage * 2;
        //        if (IsPostBack)
        //        {
        //            //LoadLoanDesciptionDetailsListView(Convert.ToInt32(ddlLoanType.SelectedValue));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogFileWritten(ex.Message, ex.StackTrace);
        //    }
        //}
        protected void lvLoanDescriptionDetail_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void objDataSourceLoanDetail_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            try 
            {
                e.InputParameters["loanTypeID"] = ddlLoanType.SelectedValue.ToString();
                e.InputParameters["amount"] = String.IsNullOrEmpty(txtTotalAmount.Text) ? 0 : Convert.ToInt32(txtTotalAmount.Text);
                e.InputParameters["duration"] = String.IsNullOrEmpty(txtDuration.Text) ? 0 : Convert.ToInt32(txtDuration.Text);
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }

        }

        protected void ddlLoanType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lvLoanDescriptionDetail.DataBind();
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        protected void btnSearchLoanData_Click(object sender, EventArgs e)
        {
            try 
            {
                int loanTypeID = Convert.ToInt32(ddlLoanType.SelectedValue);
                lvLoanDescriptionDetail.DataBind();               

            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        #endregion Protected Method

    }
}