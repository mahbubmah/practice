using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Basic;
using DAL;
using Utilities;
using System.Web.Security;

namespace OMart.Web
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
            try
              {
                if (!IsPostBack)
                {
                   
                }
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message, exception);
            }
        
        }

        protected void LogIn(object sender, EventArgs e)
        {
            try
            {
                if (IsValid)
                {
                    ProviderUserName = UserName.Text.Trim();
                    ProviderPassword = StringCipher.Encrypt(Password.Text.Trim());

                    var _userExists = _userInformationRT.IsUserExists(ProviderUserName, ProviderPassword);
                    var _findUser = _userInformationRT.FindUser(ProviderUserName, ProviderPassword);

                    if (_userExists)
                    {
                        var objUserGroup = _userInformationRT.FindUserGroup(_findUser != null ? _findUser.UserGroupID : default(Int64));

                        FormsAuthentication.SetAuthCookie(ProviderUserName, true);
                        Session["LoginStatus"] = "Log out";
                        Session["UserName"] = ProviderUserName;
                        Session["UserID"] = _userInformationRT.GetUserInfoIDByEmail(Session["UserName"].ToString()).IID;

                        if (objUserGroup != null)
                        {
                            if (Convert.ToInt32(objUserGroup.TypeID) == Convert.ToInt32(Utilities.EnumCollection.UserGrpType.Management) || Convert.ToInt32(objUserGroup.TypeID) == Convert.ToInt32(Utilities.EnumCollection.UserGrpType.Control_User))
                            {
                                Response.Redirect("~/AdminPanel/AdminDefault.aspx");
                            }
                            else if (Convert.ToInt32(objUserGroup.TypeID) == Convert.ToInt32(Utilities.EnumCollection.UserGrpType.Add_Giver))
                            {
                                Response.Redirect("~/AdminPanel/AdminDefault.aspx");
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


      
    }
}