using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Basic;
using DAL;
using Microsoft.Ajax.Utilities;
using Utilities;


namespace OMart.Web
{
    public partial class PayAsYouGoWF : System.Web.UI.Page
    {
        // private readonly MobilePhoneInfoRT _mobilePhoneInfoRT;
        private readonly MPTypeRT _mPTypeRT;
        private readonly MobilePhoneInfoRT _mobilePhoneInfoRT;
        private readonly string _visitorLogPath;
        private string _pageLogPath;
        public PayAsYouGoWF()
        {
            this._visitorLogPath = Server.MapPath("~/Log file/VisitorlogFileWriting.txt");
            _mobilePhoneInfoRT = new MobilePhoneInfoRT();
        }

        public string QueryResult { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string pageName = Path.GetFileName(Request.PhysicalPath);
                _pageLogPath = Server.MapPath("~/Log file/" + pageName + ".txt");
                if (!IsPostBack)
                {
                    LogFileHelper.VisitorLogFileWritten(_visitorLogPath);
                    LoadRepNetworkImage();
                    LoadDropDLMobileBrandAndLoadModel();
                    LoadTypeAndModelDropDL();
                    LoadDropDLTotalTalkTime();
                    LoadDropDLTotalUsableData();
                    LoadDropDLMonthlyInstallment();
                    LoadResult();
                }


            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private void LoadRepNetworkImage()
        {
            try
            {
                var networkList = _mobilePhoneInfoRT.GetAllNetWorkProviderCompany();
                repNetworkImage.DataSource = networkList;
                repNetworkImage.DataBind();
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private void LoadResult()
        {
            try
            {
                if (Session["manufactureID"] == null)
                {
                    Session["manufactureID"] = "-1";
                }
                if (Session["mpTypeID"] == null)
                {
                    Session["mpTypeID"] = "-1";
                }
                if (Session["modelName"] == null)
                {
                    Session["modelName"] = "-1";
                }
                if (Session["talktime"] == null)
                {
                    Session["talktime"] = "-1";
                }
                if (Session["data"] == null)
                {
                    Session["data"] = "-1";
                }
                if (Session["montlyAmount"] == null)
                {
                    Session["montlyAmount"] = "-1";
                }
                if (Session["networkProviderID"] == null)
                {
                    Session["networkProviderID"] = "-1";
                }
                ddMonthlyInstallment.SelectedValue = (string) Session["montlyAmount"];
                ddTotalTalkTime.SelectedValue = (string)Session["talktime"];
                ddUsableData.SelectedValue = (string)Session["data"];
                ddlMobileCompany.SelectedValue = (string)Session["manufactureID"];
                ddlMobileTypeAndModel.SelectedValue = (string)Session["mpTypeID"];

                LoadMobilePhoneSearchResult(
                    (string)Session["manufactureID"],
                    (string)Session["mpTypeID"],
                    (string)Session["modelName"],
                    (string)Session["talktime"],
                    (string)Session["data"],
                    (string)Session["montlyAmount"],
                    (string)Session["networkProviderID"]
                    );

            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }

        }

        #region loadDropDown
        private void LoadDropDLMobileBrandAndLoadModel()
        {
            try
            {
                using (CompanyInfoRT aCompany = new CompanyInfoRT())
                {
                    var companyList = aCompany.GetAllMobileCompanyInfos();
                    if (companyList != null)
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
                if (modelList != null)
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
                if (moblePhoneColl != null)
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
                if (moblePhoneColl != null)
                {
                    foreach (MobilePhoneInfo mobilePhone in moblePhoneColl)
                    {
                        ListItem item = new ListItem(mobilePhone.TotalUsableData.ToString() + " " + ((EnumCollection.UsableDataUnit)mobilePhone.UsableDataUnitID).ToString(), mobilePhone.TotalUsableData + " " + mobilePhone.UsableDataUnitID);
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

        #endregion loadDropDown

        private void LoadMobilePhoneSearchResult(string manufactureID, string mpTypeID, string modelName, string talktime, string data, string montlyAmount,string networkProviderId)
        {
            try
            {
                int? seManufactureID = null;
                int? seMpTypeID = null;
                string seModelName = null;
                int? seTalktime = null;
                int? seTalktimeUnitId = null;
                decimal? seData = null;
                int? seDataUnitId = null;
                decimal? seMontlyAmount = null;
                int? seNetworkProviderID = null;
                if (manufactureID != "-1" && !manufactureID.IsNullOrWhiteSpace())
                {
                    seManufactureID = Convert.ToInt32(manufactureID);
                }
                if (mpTypeID != "-1" && !mpTypeID.IsNullOrWhiteSpace())
                {
                    seMpTypeID = Convert.ToInt32(mpTypeID);
                }
                if (modelName != "-1" && !modelName.IsNullOrWhiteSpace())
                {
                    seModelName = modelName;
                }
                if (talktime != "-1" && !talktime.IsNullOrWhiteSpace())
                {
                    seTalktime = Convert.ToInt32(talktime.Substring(0, talktime.IndexOf(" ")));
                    seTalktimeUnitId = Convert.ToInt32(talktime.Substring(talktime.IndexOf(" "), talktime.Length - talktime.IndexOf(" ")));
                }
                if (data != "-1" && !data.IsNullOrWhiteSpace())
                {
                    seData = Convert.ToDecimal(data.Substring(0, data.IndexOf(" ")));
                    seDataUnitId = Convert.ToInt32(data.Substring(data.IndexOf(" "), data.Length - data.IndexOf(" ")));
                }
                if (montlyAmount != "-1" && !montlyAmount.IsNullOrWhiteSpace())
                {
                    seMontlyAmount = Convert.ToDecimal(montlyAmount);
                }
                if (networkProviderId != "-1" && !networkProviderId.IsNullOrWhiteSpace())
                {
                    seNetworkProviderID = Convert.ToInt32(networkProviderId);
                }

                using (MobilePhoneInfoRT aMobilePhoneInfoRt = new MobilePhoneInfoRT())
                {
                    var mobilePhoneInfoSearchResultList = aMobilePhoneInfoRt.GetMobilePhoneInfoSearchResultList(seManufactureID, seMpTypeID, seModelName, seTalktime, seTalktimeUnitId, seData, seDataUnitId, seMontlyAmount, seNetworkProviderID);
                    lv_PayAsYouGo.DataSource = mobilePhoneInfoSearchResultList;
                    lv_PayAsYouGo.DataBind();
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
                Session["manufactureID"] = ddlMobileCompany.SelectedValue;
                LoadResult();
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
        protected void ddlMobileTypeAndModel_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
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
                LoadResult();
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
        protected void ddTotalTalkTime_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Session["talktime"] = ddTotalTalkTime.SelectedValue;
                LoadResult();
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        protected void ddUsableData_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Session["data"] = ddUsableData.SelectedValue;
                LoadResult();
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
        protected void ddMonthlyInstallment_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Session["montlyAmount"] = ddMonthlyInstallment.SelectedValue;
                LoadResult();
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }


        protected void repNetworkImage_OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                Session["networkProviderID"] = e.CommandArgument;
                LoadResult();
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        protected void dataPagerPayAsYouGo_OnPreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    LoadResult();
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
        int lvRowCount = 0;
        int currentPage = 0;
        protected void lv_PayAsYouGo_OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            try
            {
                currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
    }
}