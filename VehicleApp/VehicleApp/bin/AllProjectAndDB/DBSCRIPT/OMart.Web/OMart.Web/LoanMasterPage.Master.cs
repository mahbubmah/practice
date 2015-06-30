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
    public partial class LoanMasterPage : System.Web.UI.MasterPage
    {
        private readonly DefaultRT _defaultRt;
       
        private string _pageLogPath;
        public LoanMasterPage()
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
                    LoadMenuLinkRepeater();
                    LoadFooterLinkRepeater();
                    LoadDefaultPageUrl();
                    LoadRepeaterLoanData();
                    LoadCMSNavManu();
                    LoadLogoMartFtrInfo();
                }
            }
            catch(Exception ex)
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
        private void LoadRepeaterLoanData()
        {
            try 
            {
                LoanInformationRT loanInformationRT = new LoanInformationRT();
                List<LoanType> objLoanTypeList = new List<LoanType>();
                LoanType objLoanT = new LoanType();

                objLoanTypeList = loanInformationRT.GetLoanTypeAndDescription();
                objLoanT = objLoanTypeList[0];
                hrefLoan.HRef = "LoanDesciptionDetails?ID=" + StringCipher.Encrypt(objLoanT.IID.ToString());
                lblLoanTypeName.Text = objLoanT.Name + " Loan";
                lblDescription.Text = objLoanT.Description;
                objLoanTypeList.RemoveAt(0);

                repLoanTypeMaster.DataSource = objLoanTypeList;
                repLoanTypeMaster.DataBind();

            }
            catch(Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
        protected void linkBtnLoanTypeName_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lb = (LinkButton)sender;
                Int64 loanTypeID = Convert.ToInt16(lb.CommandArgument.ToString());
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
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