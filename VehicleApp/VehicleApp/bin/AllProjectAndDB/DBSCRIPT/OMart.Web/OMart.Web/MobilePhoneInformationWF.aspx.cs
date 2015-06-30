using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BLL.Basic;
using DAL;
using Utilities;




namespace OMart.Web
{
    public partial class MobilePhoneInformationWF : System.Web.UI.Page
    {
        private readonly MobilePhoneInfoRT _mobilePhoneInfoRT;
        private readonly MPTypeRT _mPTypeRT;
        private readonly string _visitorLogPath;
        private string _pageLogPath;

        public MobilePhoneInformationWF()
        {
            this._visitorLogPath = Server.MapPath("~/Log file/VisitorlogFileWriting.txt");
            this._mobilePhoneInfoRT = new MobilePhoneInfoRT();
            this._mPTypeRT = new MPTypeRT();
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
                    LoadDropDLMobileBrandAndLoadModel();
                    LoadTypeAndModelDropDL();
                    LoadDropDLTotalTalkTime();
                    LoadDropDLTotalUsableData();
                    LoadDropDLMonthlyInstallment();
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private void LoadDropDLMobileBrandAndLoadModel()
        {
            try
            {
                using (CompanyInfoRT aCompany = new CompanyInfoRT())
                {
                    var companyList = aCompany.GetAllMobileCompanyInfos();
                    if (companyList!=null)
                    {
                        DropDownListHelper.Bind(ddlMobileCompany, companyList, "Name", "IID", EnumCollection.ListItemType.MPType);
                    }
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private void LoadTypeAndModelDropDL()
        {
            try
            {
                var modelList = _mobilePhoneInfoRT.GetModelByCompanyID(Convert.ToInt32(ddlMobileCompany.SelectedValue.ToString()));
                if (modelList!=null)
                {
                    DropDownListHelper.Bind(ddlMobileTypeAndModel, modelList, "Models", "IID", EnumCollection.ListItemType.MPModel);
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private void LoadDropDLTotalTalkTime()
        {
            //
            try
            {
                ListItem selectItem = new ListItem("Select total talk time", "-1");
                ddTotalTalkTime.Items.Add(selectItem);

                var moblePhoneColl = _mobilePhoneInfoRT.GetAllMobilePhoneInfoForTotalTalkTime();
                //DropDownListHelper.Bind(ddTotalTalkTime, moblePhoneColl, "TotalTalkTime", "IID", EnumCollection.ListItemType.None);
                if (moblePhoneColl!=null)
                {
                    foreach (MobilePhoneInfo mobilePhone in moblePhoneColl)
                    {
                        ListItem item = new ListItem(mobilePhone.TotalTalkTime + " " + ((EnumCollection.TalkTimeUnit)mobilePhone.TalkTimeUnitID).ToString(), mobilePhone.TotalTalkTime + " " + mobilePhone.TalkTimeUnitID);
                        ddTotalTalkTime.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private void LoadDropDLTotalUsableData()
        {
            //
            try
            {
                ListItem selectItem = new ListItem("Select total data", "-1");
                ddUsableData.Items.Add(selectItem);

                var moblePhoneColl = _mobilePhoneInfoRT.GetAllMobilePhoneInfoForTotalUsableData();
                //DropDownListHelper.Bind(ddUsableData, moblePhoneColl, "TotalUsableData", "IID", EnumCollection.ListItemType.None);
                if (moblePhoneColl!=null)
                {
                    foreach (MobilePhoneInfo mobilePhone in moblePhoneColl)
                    {
                        ListItem item = new ListItem(mobilePhone.TotalUsableData.ToString() + " " + ((EnumCollection.UsableDataUnit)mobilePhone.UsableDataUnitID).ToString(), mobilePhone.TotalUsableData +" "+ mobilePhone.UsableDataUnitID);
                        ddUsableData.Items.Add(item);
                    }
                }
               
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private void LoadDropDLMonthlyInstallment()
        {
            //
            try
            {
                ListItem selectItem = new ListItem("Select installment amount", "-1");
                ddMonthlyInstallment.Items.Add(selectItem);

                var moblePhoneColl = _mobilePhoneInfoRT.GetAllMobilePhoneInfoForMonthlyInstallmentAmt();
                // DropDownListHelper.Bind(ddMonthlyInstallment, moblePhoneColl, "MonthlyInstallmentAmt", "IID", EnumCollection.ListItemType.None);
                if (moblePhoneColl != null)
                {
                    foreach (MobilePhoneInfo mobilePhone in moblePhoneColl)
                    {
                        ListItem item = new ListItem(mobilePhone.MonthlyInstallmentAmt.ToString() + " Monthly",
                            mobilePhone.MonthlyInstallmentAmt.ToString());
                        ddMonthlyInstallment.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
        protected void ddlMobileCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadTypeAndModelDropDL();
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        //private void loadMobilePhoneAllInformation()
        //{
        //    try
        //    {
        //        mobilePhoneSliderRepeater.DataSource = _mobilePhoneInfoRT.GetMobilePhoneAllInformation();
        //        mobilePhoneSliderRepeater.DataBind();
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Message.ToString();
        //    }
        //}

        //protected void mobilePhoneSliderRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    try 
        //    {
        //        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //        {
        //            Repeater child = e.Item.FindControl("mobileFeatureRepeater") as Repeater;
        //            child.DataSource = _mPTypeRT.GetAllMobilePhonestype();
        //            child.DataBind();
        //        }

        //    }
        //    catch(Exception ex)
        //    {

        //    }

        //}


        protected void lnkbtnCompareDeals_Click(object sender, EventArgs e)
        {
            try
            {
                //string s1 = ss.Substring(0, ss.IndexOf(" "));
                //string s2 = ss.Substring(ss.IndexOf(" "), ss.Length - ss.IndexOf(" "));

                Session["manufactureID"] = ddlMobileCompany.SelectedValue;
                Session["mpTypeID"] = ddlMobileTypeAndModel.SelectedValue;
                if (Convert.ToInt32(ddlMobileTypeAndModel.SelectedValue) > -1)
                {
                    string model = ddlMobileTypeAndModel.SelectedItem.Text;
                    Session["modelName"] = model != "-1" ? (model.Split('-').Count() == 2 ? model.Split('-')[1] : string.Empty) : "-1";
                }
                else
                {
                    Session["modelName"] = "-1";
                }

                Session["talktime"] = ddTotalTalkTime.SelectedValue;
                Session["data"] = ddUsableData.SelectedValue;
                Session["montlyAmount"] = ddMonthlyInstallment.SelectedValue;
                Response.Redirect("PayAsYouGoWF.aspx");
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

     
        protected void lnkbtnAnotherDeals_Click(object sender, EventArgs e)
        {
            try
            {
                //string s1 = ss.Substring(0, ss.IndexOf(" "));
                //string s2 = ss.Substring(ss.IndexOf(" "), ss.Length - ss.IndexOf(" "));

                Session["talktime"] = ddTotalTalkTime.SelectedValue;
                Session["data"] = ddUsableData.SelectedValue;
                Session["montlyAmount"] = ddMonthlyInstallment.SelectedValue;
                Session["manufactureID"] = ddlMobileCompany.SelectedValue;
                Session["mpTypeID"] = ddlMobileTypeAndModel.SelectedValue;
                if (Convert.ToInt32(ddlMobileTypeAndModel.SelectedValue) > -1)
                {
                    string model = ddlMobileTypeAndModel.SelectedItem.Text;
                    Session["modelName"] = model != "-1" ? (model.Split('-').Count() == 2 ? model.Split('-')[1] : string.Empty) : "-1";
                }
                else
                {
                    Session["modelName"] = "-1";
                }
                Response.Redirect("PayAsYouGoWF.aspx");
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }

        }
    }
}