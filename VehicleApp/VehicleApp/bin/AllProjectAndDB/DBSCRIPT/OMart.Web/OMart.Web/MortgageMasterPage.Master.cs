using System.IO;
using BLL.Basic;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace OMart.Web
{
    public partial class MortgageMasterPage : System.Web.UI.MasterPage
    {
        private readonly DefaultRT _defaultRt;
        private readonly VisitorCounterRT _visitorCounterRT;
        private readonly VisitorCounter _visitorCounter;
        private string _pageLogPath;

        public MortgageMasterPage()
        {
            this._defaultRt = new DefaultRT();
            this._visitorCounterRT = new VisitorCounterRT();
            this._visitorCounter = new VisitorCounter();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string pageName = Path.GetFileName(Request.PhysicalPath);
                _pageLogPath = Server.MapPath("~/Log file/" + pageName + ".txt");
                BindAllMortgageTypeInfo();
                if (!IsPostBack)
                {                   
                    LoadFooterLinkRepeater();
                    LoadMenuLinkRepeater();
                    LoadVisitorCounter();
                    LoadDefaultPageUrl();
                    LoadDefaultLoginLogout();
                    LoadCMSNavManu();
                    DisableBrowserBackButton();
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

                rptCMSMenu.DataSource = enumModifierList; 
                rptCMSMenu.DataBind();


                
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        #region private method
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
            catch(Exception ex)
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

        private List<EnumModifier> GetEnumData()
        {
            try
            {
                var list = Utilities.EnumHelper.EnumToList<Utilities.EnumCollection.MortgageType>();

                List<EnumModifier> enumModifierList = new List<EnumModifier>();

                foreach (var enumMember in list)
                {
                    EnumModifier enumModifier = new EnumModifier();
                    string enumDisplayMember = enumMember.ToString();

                    string name = string.Empty;
                    string value = string.Empty;
                    switch (enumDisplayMember)
                    {
                        case "Conventional":
                            name = "Conventional";
                            value = "1";
                            break;
                        case "Government":
                            name = "Government";
                            value = "2";
                            break;
                        case "RuralHomeFinancingProgram":
                            name = "Rural Home Financing Program";
                            value = "3";
                            break;
                        case "HomeOpportunitiesProgram":
                            name = "Home Opportunities Program";
                            value = "4";
                            break;
                        case "NoneprimeOrSubprime":
                            name = "None prime Or Subprime";
                            value = "5";
                            break;
                    }
                    enumModifier.Name = name;
                    enumModifier.Value = value;
                    enumModifierList.Add(enumModifier);
                }
                return enumModifierList;
            }
            catch (Exception ex)
            {

                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
           return null;
        }
        private void BindAllMortgageTypeInfo()
        {
            try
            {
                List<MortgageType> typeInfo = new List<MortgageType>();
                //MortgageTypeInfo topOne = new MortgageTypeInfo();
                using (MortgageRT rt = new MortgageRT())
                {
                    MortgageType one = new MortgageType();
                    rptOne.DataSource = GetEnumData();
                    rptOne.DataBind();
                    typeInfo = rt.GetAllMortgageTypeInfo();
                    if (typeInfo.Count > 0)
                    {
                        one = typeInfo[0];

                        if (!string.IsNullOrEmpty(one.ImageUrl))
                        {
                            img_AdDetailsFirst.ImageUrl = one.ImageUrl;
                        }
                        else
                        {
                            img_AdDetailsFirst.ImageUrl = "~Images/interface/noimage.jpg";
                        }
                        lnkBtnName2.CommandArgument = one.IID.ToString();
                        lblmortgageTypeName.Text = one.Name;
                        ltrDescription.Text = one.Description;
                        typeInfo.RemoveAt(0);
                        ParentRepeater.DataSource = typeInfo;
                        ParentRepeater.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {

                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
           

        }
        #endregion private method




        protected void ParentRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    Repeater child = e.Item.FindControl("childRepeater") as Repeater;
                    child.DataSource = GetEnumData();
                    child.DataBind();
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        protected void lnkBtnName1_Click(object sender, EventArgs e)
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

        protected void lnkBtnName2_Click(object sender, EventArgs e)
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
        protected void lnkBtnName3_Click(object sender, EventArgs e)
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

        protected void lnkBtnName4_Click(object sender, EventArgs e)
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

        protected void lbLogStatus_Click(object sender, EventArgs e)
        {
            Session["LoginStatus"] = "Login";
            lblUsername.Text = string.Empty;
            ulLoginOut.Visible = false;
            ulLoginOutDirect.Visible = true;
            lbLogStatus.Text = string.Empty;
            Session["UserName"] = null;
            Response.Redirect("~/LoginPage.aspx");
        }
    }
}