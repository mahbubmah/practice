using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OB.DAL;
using OB.Utilities;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Specialized;
using System.Reflection;
using OB.BLL.Basic;
using Utilities;

namespace OB.Web
{
    public partial class BookHomeMaster : System.Web.UI.MasterPage
    {
  
        private readonly VisitorCounterRT _visitorCounterRT;
        private readonly VisitorCounter _visitorCounter;
        private string _pageLogPath;
        public BookHomeMaster()
        {

            this._visitorCounterRT = new VisitorCounterRT();
            this._visitorCounter = new VisitorCounter();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string pageName = Path.GetFileName(Request.PhysicalPath);
                _pageLogPath = Server.MapPath("~/Log file/" + pageName + ".txt");


                if (!IsPostBack)
                {
                   
                }

                LoadDefaultLoginLogout();
                LoadDefaultPageUrl();
                LoadVisitorCounter();
                LoadLogoFtrInfo();
                LoadCMSFooterManu();
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
            
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

        private void LoadLogoFtrInfo()
        {
            try
            {
                using (OiiOBookRT receiverTransfer = new OiiOBookRT())
                {
                    OiiOBook ContentActive = receiverTransfer.GetActiveContentForShow();
                    // lblftrAddress.Text = haatContentActive.Address;
                    lblftrPhn.Text = ContentActive.Phone;
                    lblftrEmail.Text = ContentActive.Email;
                    logoImg.ImageUrl = ContentActive.Logo;
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
        private void LoadCMSFooterManu()
        {
            try
            {
                List<EnumModifier> enumModifierList = new List<EnumModifier>();
                var enumMemberList = EnumHelper.EnumToList<EnumCollection.CMSType>();
                foreach (ListItem enumMember in enumMemberList)
                {
                    EnumModifier aEnumModifier = new EnumModifier();
                    aEnumModifier.Name = enumMember.Text.Replace("FAQs","FAQ's");
                    aEnumModifier.Value = enumMember.Value;
                    enumModifierList.Add(aEnumModifier);
                }
                rptCMSMenu.DataSource = enumModifierList.Take(4); //objNavManu;
                rptCMSMenu.DataBind();

                rptService.DataSource = enumModifierList.Skip(4).Take(4);
                rptService.DataBind();
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
        private void LoadDefaultPageUrl()
        {
            #region Default url loading

            hrfRegister.HRef = "~/UserRegistrationPage";
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
            Session["ContestantID"] = null;
            Response.Redirect("~/LoginPage.aspx");

        }
        private void LoadVisitorCounter()
        {
            try
            {
                var objVisitor = _visitorCounterRT.GetAllVisitorCounterList().SingleOrDefault();

                if (objVisitor == null && OB.Web.Global.TotalNumberOfUsers == 1)
                {
                    _visitorCounter.TotalVisitor = OB.Web.Global.TotalNumberOfUsers;
                    //  _visitorCounter.VisitDate = DateTime.Today;
                    _visitorCounterRT.AddVisitorCounter(_visitorCounter);
                    OB.Web.Global.TotalNumberOfUsers = 0;
                }

                if (objVisitor != null && OB.Web.Global.TotalNumberOfUsers == 1)
                {
                    objVisitor.TotalVisitor += OB.Web.Global.TotalNumberOfUsers;
                    // _visitorCounter.VisitDate = DateTime.Today;
                    _visitorCounterRT.UpdateVisitorCounter(objVisitor);
                    OB.Web.Global.TotalNumberOfUsers = 0;
                }

                var objVisitorTotal = _visitorCounterRT.GetAllVisitorCounterList();
                lblVisitorCounter.Text = "Total Visitors : " + Convert.ToString(objVisitorTotal.SingleOrDefault().TotalVisitor);
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

       
    }
}