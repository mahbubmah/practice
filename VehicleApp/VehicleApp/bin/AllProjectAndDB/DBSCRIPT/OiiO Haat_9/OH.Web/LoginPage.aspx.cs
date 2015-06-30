using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
//using OH.Web.Models;
using OH.BLL.Basic;
using System.Web.Security;
using System.Web.UI.WebControls;
using OH.Utilities;
using OH.DAL;

namespace OH.Web
{
    public partial class LoginPage : System.Web.UI.Page
    {
        private readonly UserInformationRT _userInformationRT;
        public LoginPage()
        {
            this._userInformationRT = new UserInformationRT();
        }
        protected string ProviderUserName
        {
            get { return (string)ViewState["ProviderUserName"] ?? String.Empty; }
            private set { ViewState["ProviderUserName"] = value; }
        }

        protected string ProviderPassword
        {
            get { return (string)ViewState["ProviderPassword"] ?? String.Empty; }
            private set { ViewState["ProviderPassword"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadLogoHaatFtrInfo();
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            try
            {
                if (IsValid)
                {
                    ProviderUserName = UserName.Text.Trim();
                    ProviderPassword =StringCipher.Encrypt(Password.Text.Trim());

                    var _userExists = _userInformationRT.IsUserExists(ProviderUserName, ProviderPassword);
                    var _findUser = _userInformationRT.FindUser(ProviderUserName, ProviderPassword);

                    if (_userExists)
                    {
                        var objUserGroup = _userInformationRT.FindUserGroup(_findUser != null ? _findUser.UserGroupID : default(Int64));

                        FormsAuthentication.SetAuthCookie(ProviderUserName, true);
                        Session["LoginStatus"] = "Log out";
                        Session["UserName"] = ProviderUserName;

                        if (objUserGroup != null)
                        {
                            if (Convert.ToInt32(objUserGroup.TypeID) == Convert.ToInt32(OH.Utilities.EnumCollection.UserGrpType.Management) || Convert.ToInt32(objUserGroup.TypeID) == Convert.ToInt32(OH.Utilities.EnumCollection.UserGrpType.Control_User))
                            {
                                Response.Redirect("~/ControlAdmin/AdminDefault.aspx");
                            }
                            else if (Convert.ToInt32(objUserGroup.TypeID) == Convert.ToInt32(OH.Utilities.EnumCollection.UserGrpType.Add_Giver))
                            {
                                Response.Redirect("~/MaterialWF.aspx");
                            }
                            else
                            {
                                Response.Redirect("~/Default.aspx");
                            }
                        }
                    }
                    else
                    {
                        Session["LoginStatus"] = "Login";
                        FailureText.Text = "Invalid username or password.";
                        Password.Text = default(string);
                        ErrorMessage.Visible = true;
                        //Response.Redirect("~/LoginPage.aspx");
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void LoadLogoHaatFtrInfo()
        {
            try
            {
                using (OiiOHaatRT receiverTransfer = new OiiOHaatRT())
                {
                    OiiOHaat haatContentActive = receiverTransfer.GetActiveHaatContentForShow();

                    loginLogoImg.ImageUrl = haatContentActive.LoginLogo;
                }
            }
            catch (Exception ex)
            {

            }
        }

    }
}