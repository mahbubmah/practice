using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OB.BLL.Basic;
using OB.DAL;
using BLL.Basic;
using OB.Utilities;
using System.Web.Security;
using Utilities;

namespace OB.Web
{
    public partial class LoginPage : System.Web.UI.Page
    {
        private readonly UserInformationRT _userInformationRT;
        private readonly CompetitionInfoRT _competitionInfoRt;
        private readonly string _visitorLogPath;
        private string _pageLogPath;
        public LoginPage()
        {
            this._visitorLogPath = Server.MapPath("~/Log file/VisitorlogFileWriting.txt");
            this._userInformationRT = new UserInformationRT();
            this._competitionInfoRt = new CompetitionInfoRT();
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
                string pageName = Path.GetFileName(Request.PhysicalPath);
                _pageLogPath = Server.MapPath("~/Log file/" + pageName + ".txt");
                if (!IsPostBack)
                {
                    LogFileHelper.VisitorLogFileWritten(_visitorLogPath);
                    LoadPageForContestant();
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }

        }

        private void LoadPageForContestant()
        {
            try
            {
                if (Session["ContestantID"] != null)
                {
                    Response.Redirect("ContestantHome",false);
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
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
                    var _findContestant = _competitionInfoRt.FindContestant(ProviderUserName, ProviderPassword);
                    if (_userExists)
                    {
                        var objUserGroup = _userInformationRT.FindUserGroup(_findUser != null ? _findUser.UserGroupID : default(Int64));

                        FormsAuthentication.SetAuthCookie(ProviderUserName, true);
                        Session["LoginStatus"] = "Log out";
                        Session["UserName"] = ProviderUserName;

                        if (objUserGroup != null)
                        {
                            if (Convert.ToInt32(objUserGroup.TypeID) == Convert.ToInt32(Utilities.EnumCollection.UserGroupType.Management) || Convert.ToInt32(objUserGroup.TypeID) == Convert.ToInt32(Utilities.EnumCollection.UserGroupType.Control_User))
                            {
                                Response.Redirect("~/BookAdmin/AdminDefault.aspx", false);
                            }
                            else if (Convert.ToInt32(objUserGroup.TypeID) == Convert.ToInt32(Utilities.EnumCollection.UserGroupType.General))
                            {
                                Response.Redirect("~/Default.aspx", false);
                            }
                            else
                            {
                                Response.Redirect("~/Default.aspx", false);
                            }
                        }
                    }
                    else if (_findContestant != null)
                    {
                        FormsAuthentication.SetAuthCookie(ProviderUserName, true);
                        Session["LoginStatus"] = "Log out";
                        Session["UserName"] = ProviderUserName;
                        Session["ContestantID"] = _findContestant.IID;
                        Response.Redirect("ContestantHome", false);
                        Context.ApplicationInstance.CompleteRequest();
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
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
    }
}