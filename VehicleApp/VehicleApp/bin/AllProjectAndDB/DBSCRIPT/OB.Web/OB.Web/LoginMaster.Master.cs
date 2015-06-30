using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OB.DAL;
using OB.BLL.Basic;
using OB.Utilities;
using Utilities;

namespace OB.Web
{
    public partial class LoginMaster : System.Web.UI.MasterPage
    {
        private readonly UserInformationRT _userInformationRT;
        private string _pageLogPath;
        // private readonly CategoryRT _categoryRT;
        public LoginMaster()
        {
            //this._categoryRT = new CategoryRT();
            this._userInformationRT = new UserInformationRT();
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
                    LoadDefaultLoginLogout();
                    LoadLogoFtrInfo();
                    LoadCMSFooterManu();
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
                    aEnumModifier.Name = enumMember.Text;
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

    
        private void LoadDefaultLoginLogout()
        {
            try
            {
                ulLoginOut.Visible = true;

                if (Session["UserName"] != null)
                {
                    ulLoginOutDirect.Visible = false;
                    lblUsername.Text = "Welcome " + Session["UserName"] != null ? Session["UserName"].ToString() : string.Empty + " !";
                    lbLogStatus.Text = Session["LoginStatus"] != null ? Session["LoginStatus"].ToString() : string.Empty;

                    var _findUser = _userInformationRT.FindUserByUserName(Convert.ToString(Session["UserName"]));
                    var objUserGroup = _userInformationRT.FindUserGroup(_findUser != null ? _findUser.UserGroupID : default(Int64));

                    if (objUserGroup != null && Session["ContestantID"] == null)
                    {
                        if (Convert.ToInt32(objUserGroup.TypeID) != Convert.ToInt32(Utilities.EnumCollection.UserGroupType.General))
                        {
                            Response.Redirect("~/BookAdmin/AdminDefault.aspx");
                        }
                        else
                        {
                            Response.Redirect("~/Default.aspx");
                        }
                    }


                }
                else
                {
                    ulLoginOutDirect.Visible = true;
                    lblUsername.Text = string.Empty;
                    lbLogStatus.Text = string.Empty;
                    //Response.Redirect("~/LoginPage.aspx");     
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
    }
}