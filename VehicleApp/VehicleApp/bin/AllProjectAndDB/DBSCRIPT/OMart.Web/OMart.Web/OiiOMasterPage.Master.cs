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
using System.Net;
using System.Net.NetworkInformation;
using System.Text;


namespace OMart.Web
{
    public partial class OiiOMasterPage : System.Web.UI.MasterPage
    {
        private readonly DefaultRT _defaultRt;
        private readonly VisitorCounterRT _visitorCounterRT;
        private readonly VisitorCounter _visitorCounter;
        private string _pageLogPath;
        public OiiOMasterPage()
        {
            this._defaultRt = new DefaultRT();
            this._visitorCounterRT = new VisitorCounterRT();
            this._visitorCounter = new VisitorCounter();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {

                //LoadAllFeature();
                if (!IsPostBack)
                {
                    string pageName = Path.GetFileName(Request.PhysicalPath);
                    _pageLogPath = Server.MapPath("~/Log file/" + pageName + ".txt");
                    LoadMenuLinkRepeater();
                    LoadFooterLinkRepeater();
                    LoadCMSNavManu();
                    LoadVisitorCounter();
                    LoadDefaultPageUrl();
                    LoadDefaultLoginLogout();
                    LoadLogoMartFtrInfo();
                    DisableBrowserBackButton();

                }

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

                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
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
        private void LoadVisitorCounter()
        {
            try
            {
                var objVisitor = _visitorCounterRT.GetAllVisitorCounterList().SingleOrDefault();

                if (objVisitor == null && OMart.Web.Global.TotalNumberOfUsers == 1)
                {
                    _visitorCounter.TotalVisitor = OMart.Web.Global.TotalNumberOfUsers;
                    _visitorCounterRT.AddVisitorCounter(_visitorCounter);
                    OMart.Web.Global.TotalNumberOfUsers = 0;
                }

                if (objVisitor != null && OMart.Web.Global.TotalNumberOfUsers == 1)
                {
                    objVisitor.TotalVisitor += OMart.Web.Global.TotalNumberOfUsers;
                    _visitorCounterRT.UpdateVisitorCounter(objVisitor);
                    OMart.Web.Global.TotalNumberOfUsers = 0;
                }

                var objVisitorTotal = _visitorCounterRT.GetAllVisitorCounterList();
                lblTotalNumberOfVisitor.Text = Convert.ToString(objVisitorTotal.SingleOrDefault().TotalVisitor);
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private void DisableBrowserBackButton()
        {
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetNoServerCaching();
            HttpContext.Current.Response.Cache.SetNoStore();
        }

        private void LoadDefaultLoginLogout()
        {
            try
            {
                ulLoginOut.Visible = true;
                if (Session["UserName"] != null)
                {
                    ulLoginOutDirect.Visible = false;
                    var userText = Session["UserName"] != null ? Session["UserName"].ToString() : string.Empty;
                    lblUsername.Text = "Welcome " + userText + " !";
                    lbLogStatus.Text = Session["LoginStatus"] != null ? Session["LoginStatus"].ToString() : string.Empty;

                    //var _findUser = _userInformationRT.FindUserByUserName(Convert.ToString(Session["UserName"]));
                    //var objUserGroup = _userInformationRT.FindUserGroup(_findUser != null ? _findUser.UserGroupID : default(Int64));

                    //if (objUserGroup != null)
                    //{
                    //    if (Convert.ToInt32(objUserGroup.TypeID) != Convert.ToInt32(OH.Utilities.EnumCollection.UserGrpType.Add_Giver))
                    //    {
                    //        Response.Redirect("~/ControlAdmin/AdminDefault.aspx");
                    //    }
                    //    else
                    //    {
                    //        Response.Redirect("~/Default.aspx");
                    //    }
                    //}
                }
                else
                {
                    ulLoginOutDirect.Visible = true;
                    lblUsername.Text = string.Empty;
                    lbLogStatus.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
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
    }
}