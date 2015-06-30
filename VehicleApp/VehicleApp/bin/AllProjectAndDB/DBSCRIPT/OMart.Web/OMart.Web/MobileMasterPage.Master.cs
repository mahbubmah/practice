using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Basic;
using DAL;
using Utilities;

namespace OMart.Web
{
    public partial class MobileMasterPage : System.Web.UI.MasterPage
    {
        private readonly DefaultRT _defaultRt;
        private string _pageLogPath;
     
        public MobileMasterPage()
        {
            this._defaultRt = new DefaultRT();
         
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string pageName = Path.GetFileName(Request.PhysicalPath);
                _pageLogPath = Server.MapPath("~/Log file/" + pageName + ".txt");
                if (!IsPostBack)
                {
                    LoadDefaultPageUrl();
                    LoadFooterLinkRepeater();
                    LoadMenuLinkRepeater();
                    loadMobilePhonesType();
                    loadMobilePhoneAllInformation();
                    LoadCMSNavManu();
                    LoadLogoMartFtrInfo();
                }
                loadMobilePhonesType();
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message,ex.StackTrace,_pageLogPath);
            }
        }
        private void LoadDefaultPageUrl()
        {
            #region Default url loading

            hrfRegister.HRef = "~/UserRegistration";
            hrfLogin.HRef = "~/LoginPage";

            #endregion
        }
        private void LoadLogoMartFtrInfo()
        {
            try
            {
                using (OiiOMartRT receiverTransfer = new OiiOMartRT())
                {
                    OiiOMart haatContentActive = receiverTransfer.GetActiveMartContentForShow();
                    // lblftrAddress.Text = haatContentActive.Address;
                    //lblftrPhn.Text = haatContentActive.Phone;
                    //lblftrEmail.Text = haatContentActive.Email;
                    imgLogo.ImageUrl = haatContentActive.Logo;
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
        protected void repFooterWithWFUrlsDisplay_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                HiddenField objModuleName = e.Item.FindControl("hfModuleName") as HiddenField;

                var objSubModuleList = (from s in _defaultRt.GetAllModuleList()
                                        where s.ModuleName == objModuleName.Value && string.IsNullOrEmpty(s.UrlModuleName)
                                        select s).ToList();

                Repeater objRepeater = e.Item.FindControl("repFooterUrlLinkList") as Repeater;
                objRepeater.DataSource = objSubModuleList;
                objRepeater.DataBind();
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
        private void LoadFooterLinkRepeater()
        {
            try
            {

                var moduleList = (from tr in _defaultRt.GetAllModuleList()
                                  where !string.IsNullOrEmpty(tr.UrlModuleName)
                                  select tr).Take(5).ToList();

                repFooterWithWFUrlsDisplay.DataSource = moduleList;
                repFooterWithWFUrlsDisplay.DataBind();
            }
            catch (Exception ex)
            {

                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
        protected void rptModule_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                HiddenField objModuleName = e.Item.FindControl("hfModuleName") as HiddenField;

                var objSubModuleList = (from s in _defaultRt.GetAllModuleList()
                                        where s.ModuleName == objModuleName.Value.ToString() && string.IsNullOrEmpty(s.UrlModuleName)
                                        select s).ToList();

                Repeater objRepeater = e.Item.FindControl("rptUrl") as Repeater;
                objRepeater.DataSource = objSubModuleList;
                objRepeater.DataBind();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        private void LoadMenuLinkRepeater()
        {
            try
            {

                var moduleList = (from tr in _defaultRt.GetAllModuleList()
                                  where !string.IsNullOrEmpty(tr.UrlModuleName)
                                  select tr).ToList();

                rptModule.DataSource = moduleList;
                rptModule.DataBind();



            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        private void loadMobilePhonesType()
        {
            try
            {
                MPTypeRT _mPTypeRT = new MPTypeRT();
                var objmp = _mPTypeRT.GetAllMobilePhonestype().Take(7).ToList();
                if (objmp.Count > 0)
                {
                    mobilePhonesRepeater.DataSource = objmp;
                    mobilePhonesRepeater.DataBind();
                }
            }
            catch (NullReferenceException ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private void loadMobilePhoneAllInformation()
        {
            try
            {
                MPTypeRT _mPTypeRT = new MPTypeRT();
                MobilePhoneInfoRT _mobilePhoneInfoRT = new MobilePhoneInfoRT();
                var objmp = _mPTypeRT.GetAllMobilePhonestype().Take(7).ToList();
                if (objmp.Count > 0)
                {
                    var objTopTenMobile = _mobilePhoneInfoRT.GetTopTenMobilePhone();
                    if (objTopTenMobile.FirstOrDefault()!=null)
                    {
                        lblMobileAndModelName.Text = objTopTenMobile.FirstOrDefault().TypeName + " " + objTopTenMobile.FirstOrDefault().ModelName;
                        lblDescription.Text = objTopTenMobile.FirstOrDefault().Description;
                        if (objTopTenMobile.FirstOrDefault().PictureUrl!=null)
                        {
                            imgTopMP.ImageUrl = objTopTenMobile.FirstOrDefault().PictureUrl;
                        }
                    }
                    rptTopTenMobile.DataSource = objTopTenMobile.Skip(1);
                    rptTopTenMobile.DataBind();
                }
             
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        protected void mobilePhoneSliderRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    //Repeater child = e.Item.FindControl("mobileFeatureRepeater") as Repeater;
                    //child.DataSource = _mPTypeRT.GetAllMobilePhonestype();
                    //child.DataBind();
                    MPTypeRT _mPTypeRT = new MPTypeRT();
                    Literal objltrLoan = (Literal)e.Item.FindControl("lblMobileName");
                    objltrLoan.Text = objltrLoan.Text.Trim();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }
        protected void lbLogStatus_OnClick(object sender, EventArgs e)
        {
            Session["LoginStatus"] = "Login";
            lblUsername.Text = string.Empty;
            ulLoginOut.Visible = false;
            ulLoginOutDirect.Visible = true;
            lbLogStatus.Text = string.Empty;
            Session["UserName"] = null;
            Response.Redirect("~/LoginPage.aspx");
        }

        private void LoadCMSNavManu()
        {



            try
            {
                List<EnumModifier> enumModifierList = new List<EnumModifier>();
                var enumMemberList = EnumHelper.EnumToList<EnumCollection.CMSType>();
                foreach (var enumMember in enumMemberList)
                {
                    EnumModifier aEnumModifier = new EnumModifier();
                    string enumDisplayMember = enumMember.ToString();

                    string name = string.Empty;
                    string value = string.Empty;

                    switch (enumDisplayMember)
                    {
                        case "About OiiO Mart":
                            name = "About OiiO Mart";
                            value = "1";
                            break;
                        case "Work With Us":
                            name = "Work With Us";
                            value = "2";
                            break;
                        case "Our Partners":
                            name = "Our Partners";
                            value = "3";
                            break;
                        case "Privacy Policy":
                            name = "Privacy Policy";
                            value = "4";
                            break;
                        case "Terms of Use":
                            name = "Terms of Use";
                            value = "5";
                            break;
                        case "Contact With Us":
                            name = "Contact With Us";
                            value = "6";
                            break;
                        case "OiiO Mart Blog":
                            name = "OiiO Mart Blog";
                            value = "7";
                            break;
                    }
                    aEnumModifier.Name = name;
                    aEnumModifier.Value = value;
                    enumModifierList.Add(aEnumModifier);

                }
                //  DropDownListHelper.Bind(dropDownConnectionTypeID, enumModifierList, "Name", "Value", EnumCollection.ListItemType.ConnectionType);

                rptCMSMenu.DataSource = enumModifierList; //objNavManu;
                rptCMSMenu.DataBind();


                //var objNavManu = _categoryRT.GetNavmenu().Take(6).ToList();
                //if (objNavManu.Count > 0)
                //{

                //}
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }


    }
}