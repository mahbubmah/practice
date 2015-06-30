using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Basic;
using DAL;
using Utilities;



namespace OMart.Web
{
    public partial class ShoppingMaster : System.Web.UI.MasterPage
    {
        private readonly DefaultRT _defaultRt;
        List<DefaultRT.DefaultPageModuleDisplay> aUrlWfLists = new List<DefaultRT.DefaultPageModuleDisplay>();
        private readonly UserInformationRT _userInformationRT;
        private readonly VisitorCounterRT _visitorCounterRT;
        private readonly VisitorCounter _visitorCounter;
        private string _pageLogPath;

        public ShoppingMaster()
        {
            this._defaultRt = new DefaultRT();
            this._userInformationRT = new UserInformationRT();
            this._visitorCounterRT = new VisitorCounterRT();
            this._visitorCounter = new VisitorCounter();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string pageName = Path.GetFileName(Request.PhysicalPath);
               _pageLogPath = Server.MapPath("~/Log file/" + pageName + ".txt");
              //  BindAllMortgageTypeInfo();
                if (!IsPostBack)
                {
                    LoadMenuLinkRepeater();
                    LoadFooterLinkRepeater();
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

        protected void repFooterWithWFUrlsDisplay_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                HiddenField objHdCount = e.Item.FindControl("hdModuleCount") as HiddenField;
                int count = Convert.ToInt32(objHdCount.Value);

                Repeater objRepeater = e.Item.FindControl("repFooterUrlLinkList") as Repeater;
                objRepeater.DataSource = aUrlWfLists.FirstOrDefault(x => x.Count == count).ModuleLinkList;
                objRepeater.DataBind();
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

        private void LoadFooterLinkRepeater()
        {
            try
            {

                var moduleList = _defaultRt.GetAllModuleList().OrderBy(x => x.ModuleName).ToList();
                int modulNumber = 0;
                string moduleName = String.Empty;

                foreach (var urlWfList in moduleList)
                {
                    if (moduleName != urlWfList.ModuleName)
                    {
                        DefaultRT.DefaultPageModuleDisplay aDefaultPageModuleDisplay = new DefaultRT.DefaultPageModuleDisplay();
                        aDefaultPageModuleDisplay.ModuleName = urlWfList.ModuleName;
                        aDefaultPageModuleDisplay.Count = modulNumber + 1;
                        aDefaultPageModuleDisplay.ModuleImage = urlWfList.ModuleImage;

                        modulNumber++;

                        List<DefaultRT.ModuleLink> aModuleLinkList = new List<DefaultRT.ModuleLink>();
                        var urlWfListByModuleList = _defaultRt.GetAllModuleList().Where(x => x.ModuleName == urlWfList.ModuleName).ToList();
                        foreach (var urlWf in urlWfListByModuleList)
                        {
                            DefaultRT.ModuleLink aModuleLink = new DefaultRT.ModuleLink();
                            aModuleLink.Url = urlWf.UrlWFName;
                            aModuleLink.UrlDisplayName = urlWf.UrlWFDisplayName;
                            aModuleLinkList.Add(aModuleLink);
                        }
                        aDefaultPageModuleDisplay.ModuleLinkList = aModuleLinkList;

                        aUrlWfLists.Add(aDefaultPageModuleDisplay);


                        if (modulNumber > 4)
                        {
                            break;
                        }
                    }
                    moduleName = urlWfList.ModuleName;
                }

               // repFooterWithWFUrlsDisplay.DataSource = aUrlWfLists;
               // repFooterWithWFUrlsDisplay.DataBind();



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

                throw new Exception(ex.Message, ex);
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