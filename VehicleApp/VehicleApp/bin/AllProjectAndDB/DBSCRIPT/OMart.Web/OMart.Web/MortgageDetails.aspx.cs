using BLL.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using DAL;
using System.IO;
namespace OMart.Web
{
    public partial class MortgageDetails : System.Web.UI.Page
    {
        int lvRowCount = 0;
        int currentPage = 0;
        int rateTypeID = -1;
        int mortgageTypeID = -1;
        int paymentTypeID = -1;
        int periodID = -1;
        private string _pageLogPath;

        #region private method

        private void LoadDropDownMortgageType(int mortgageTypeID)
        {
            try
            {
                var list = EnumHelper.EnumCamelSpaceToList<EnumCollection.MortgageType>();
                DropDownListHelper.Bind(ddlMortgageType, list, EnumCollection.ListItemType.All);
                ddlMortgageType.SelectedValue = mortgageTypeID.ToString();
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
        private void LoadDropDownRateType(int rateTypeID)
        {
            try
            {
                var list = EnumHelper.EnumCamelSpaceToList<EnumCollection.InterestRateType>();
                DropDownListHelper.Bind(ddlRateType, list,EnumCollection.ListItemType.All);
                ddlRateType.SelectedValue = rateTypeID.ToString();
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
        private void LoadDropDownInitialPeriod(int periodID)
        {
            try
            {
                using (MortgageRT rt = new MortgageRT())
                {
                    List<SP_GetAllUpToYearResult> alist = (List<SP_GetAllUpToYearResult>)rt.GetAllUptoYear();
                    //var alist = rt.GetAllUptoYear();
                    DropDownListHelper.Bind(ddlInitialPeriod, alist, "InitialPeriod", "UptoYear", EnumCollection.ListItemType.All);
                    ddlInitialPeriod.SelectedValue = periodID.ToString();
                }



            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
        public void LoadDropDownPaymentType(int paymentTypeID)
        {
            try
            {
                //dropDownPaymentType.Items.Insert(0, new ListItem("Select Payment Method ", "-1"));
                var list = EnumHelper.EnumCamelSpaceToList<EnumCollection.PaymentType>();
                DropDownListHelper.Bind(ddlPaymentType, list,EnumCollection.ListItemType.All);
                ddlPaymentType.SelectedValue = paymentTypeID.ToString();
                
            }
            catch (Exception ex)
            {

                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private int GetQueryStringMortgageTypeID()
        {
            int mortgageType = default(int);
            try
            {
                if (!string.IsNullOrEmpty(Request.QueryString["mOption"]))
                {
                    mortgageType = Convert.ToInt32(StringCipher.Decrypt(Request.QueryString["mOption"].ToString()));
                }
                else
                {
                    // Response.Redirect("~/Mortgages.aspx", false);
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
            return mortgageType;
        }
        private int GetQueryStringRateTypeID()
        {
            int rateType = default(int);
            try
            {
                if (!string.IsNullOrEmpty(Request.QueryString["rOption"]))
                {
                    rateType = Convert.ToInt32(StringCipher.Decrypt(Request.QueryString["rOption"].ToString()));
                }
                else
                {
                   // Response.Redirect("~/Mortgages.aspx", false);
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
            return rateType;
        }
        private int GetQueryStringPaymentTypeID()
        {
            int paymentTypeID = default(int);
            try
            {
                if (!string.IsNullOrEmpty(Request.QueryString["pOption"]))
                {
                    paymentTypeID = Convert.ToInt32(StringCipher.Decrypt(Request.QueryString["pOption"].ToString()));
                }
                else
                {
                   // Response.Redirect("~/Mortgages.aspx", false);
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
            return paymentTypeID;
        }

        private int GetQueryStringPeriodID()
        {
            int periodID = -1;
            try
            {
                if (!string.IsNullOrEmpty(Request.QueryString["yOption"]))
                {
                    periodID = Convert.ToInt32(StringCipher.Decrypt(Request.QueryString["yOption"].ToString()));
                }
                else
                {
                   // Response.Redirect("~/Mortgages.aspx", false);
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
            return periodID;
        }
        #endregion private method
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string pageName = Path.GetFileName(Request.PhysicalPath);
                _pageLogPath = Server.MapPath("~/Log file/" + pageName + ".txt");
                if (!IsPostBack)
                {
                    //odsMorgageTypeDetails.CacheDuration = Session.Timeout;
                    mortgageTypeID = GetQueryStringMortgageTypeID();
                    LoadDropDownMortgageType(mortgageTypeID);
                    rateTypeID = GetQueryStringRateTypeID();
                    LoadDropDownRateType(rateTypeID);
                    paymentTypeID = GetQueryStringPaymentTypeID();
                    LoadDropDownPaymentType(paymentTypeID);
                    periodID = GetQueryStringPeriodID();
                    LoadDropDownInitialPeriod(periodID);
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }

        }
        protected void lvMortgageTypeDetails_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void odsMorgageTypeDetails_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            try
            {
                e.InputParameters["mortgageTypeID"] = Convert.ToInt32(ddlMortgageType.SelectedValue.ToString());
                e.InputParameters["paymentTypeID"] = Convert.ToInt32(ddlPaymentType.SelectedValue.ToString());
                e.InputParameters["rateTypeID"] = Convert.ToInt32(ddlRateType.SelectedValue.ToString());
                e.InputParameters["periodID"] = Convert.ToInt32(ddlInitialPeriod.SelectedValue.ToString());
            }
            catch (Exception ex)
            { }
        }

        protected void lvMortgageTypeDetails_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            try
            {
                
                using(MortgageRT rt = new MortgageRT())
                {

                    HiddenField mIID = e.Item.FindControl("hdMortgageIID") as HiddenField;
                    Int64 MortgageID =Convert.ToInt64( mIID.Value.ToString());
                    var list = rt.GetAllInterestTypeByMortgageIID(MortgageID);
                    Repeater rptRate = e.Item.FindControl("rptInterestRateType") as Repeater;
                    rptRate.DataSource = list;
                    rptRate.DataBind();

                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        protected void ddlRateType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int mortgageTypeID = Convert.ToInt32(ddlMortgageType.SelectedValue.ToString());
                int rateTypeID = Convert.ToInt32(ddlRateType.SelectedValue.ToString());
                int paymentTypeID = Convert.ToInt32(ddlPaymentType.SelectedValue.ToString());
                int periodID = Convert.ToInt32(ddlInitialPeriod.SelectedValue.ToString());

                Response.Redirect("MortgageDetails?mOption=" + StringCipher.Encrypt(mortgageTypeID.ToString()) + "&pOption=" + StringCipher.Encrypt(paymentTypeID.ToString()) + "&rOption=" + StringCipher.Encrypt(rateTypeID.ToString()) + "&yOption=" + StringCipher.Encrypt(periodID.ToString()), false);
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        protected void ddlPaymentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int mortgageTypeID = Convert.ToInt32(ddlMortgageType.SelectedValue.ToString());
                int rateTypeID = Convert.ToInt32(ddlRateType.SelectedValue.ToString());
                int paymentTypeID = Convert.ToInt32(ddlPaymentType.SelectedValue.ToString());
                int periodID = Convert.ToInt32(ddlInitialPeriod.SelectedValue.ToString());

                Response.Redirect("MortgageDetails?mOption=" + StringCipher.Encrypt(mortgageTypeID.ToString()) + "&pOption=" + StringCipher.Encrypt(paymentTypeID.ToString()) + "&rOption=" + StringCipher.Encrypt(rateTypeID.ToString()) + "&yOption=" + StringCipher.Encrypt(periodID.ToString()), false);
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        protected void ddlInitialPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int mortgageTypeID = Convert.ToInt32(ddlMortgageType.SelectedValue.ToString());
                int rateTypeID = Convert.ToInt32(ddlRateType.SelectedValue.ToString());
                int paymentTypeID = Convert.ToInt32(ddlPaymentType.SelectedValue.ToString());
                int periodID = Convert.ToInt32(ddlInitialPeriod.SelectedValue.ToString());

                Response.Redirect("MortgageDetails?mOption=" + StringCipher.Encrypt(mortgageTypeID.ToString()) + "&pOption=" + StringCipher.Encrypt(paymentTypeID.ToString()) + "&rOption=" + StringCipher.Encrypt(rateTypeID.ToString()) + "&yOption=" + StringCipher.Encrypt(periodID.ToString()), false);
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        protected void ddlMortgageType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int mortgageTypeID = Convert.ToInt32(ddlMortgageType.SelectedValue.ToString());
                int rateTypeID = Convert.ToInt32(ddlRateType.SelectedValue.ToString());
                int paymentTypeID = Convert.ToInt32(ddlPaymentType.SelectedValue.ToString());
                int periodID = Convert.ToInt32(ddlInitialPeriod.SelectedValue.ToString());

                Response.Redirect("MortgageDetails?mOption=" + StringCipher.Encrypt(mortgageTypeID.ToString()) + "&pOption=" + StringCipher.Encrypt(paymentTypeID.ToString()) + "&rOption=" + StringCipher.Encrypt(rateTypeID.ToString()) + "&yOption=" + StringCipher.Encrypt(periodID.ToString()), false);
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

    }
}