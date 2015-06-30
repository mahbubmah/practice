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

namespace OH.Web.Account
{
    public partial class Login : Page
    {
        private readonly UserInformationRT _userInformationRT;
        public Login()
        {
            using (UserInformationRT _userInfoRT = new UserInformationRT())
            {
                this._userInformationRT = _userInfoRT;
            }

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
            RegisterHyperLink.NavigateUrl = "Register";
            //OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];

            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {

                // Validate the user password
                ProviderUserName = UserName.Text.Trim();
                ProviderPassword = Password.Text.Trim();
                var _userExists = _userInformationRT.IsUserExists(ProviderUserName, ProviderPassword);

                //var manager = new UserManager();
                //var user = _userInformationRT.FindUser(ProviderUserName, ProviderPassword);

                if (_userExists)
                {
                    //IdentityHelper.SignIn(manager, user, RememberMe.Checked);
                    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                }
                else
                {
                    FailureText.Text = "Invalid username or password.";
                    Password.Text = default(string);
                    ErrorMessage.Visible = true;
                }
            }
        }
    }
}