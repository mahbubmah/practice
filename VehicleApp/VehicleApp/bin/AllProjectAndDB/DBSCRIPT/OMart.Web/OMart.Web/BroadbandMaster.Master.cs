using BLL.Basic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using DAL;

namespace OMart.Web
{
    public partial class BroadbandMaster : System.Web.UI.MasterPage
    {
        private readonly DefaultRT _defaultRt;
        private string _pageLogPath;
        public BroadbandMaster()
        {
            this._defaultRt = new DefaultRT();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string pageName = Path.GetFileName(Request.PhysicalPath);
                _pageLogPath = Server.MapPath("~/Log file/" + pageName + ".txt");                
                if(!IsPostBack)
                {
                    LoadMenuLinkRepeater();
                    LoadFooterLinkRepeater();
                    LoadDefaultPageUrl();
                    LoadCMSNavManu();
                    LoadLogoMartFtrInfo();
                }

            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }            
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

        private void LoadDefaultPageUrl()
        {
            #region Default url loading

            hrfRegister.HRef = "~/UserRegistration";
            hrfLogin.HRef = "~/LoginPage";

            #endregion
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

                rptCMSMenu.DataSource = enumModifierList; //objNavManu;
                rptCMSMenu.DataBind();

            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

    }
}