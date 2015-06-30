using BLL.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OB.BLL.Basic;

namespace OB.Web.BookAdmin
{
    public partial class OiiOMasterPage : System.Web.UI.MasterPage
    {
        private readonly UserInformationRT _userInformationRT;
        public OiiOMasterPage()
        {
            // this._categoryRT = new CategoryRT();
            this._userInformationRT = new UserInformationRT();
            //   this._userWFPermission = new UserPermissionRT();
            //  this._urlWFListRT = new UrlWFListRT();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDefaultLoginLogout();
                if (!IsPostBack)
                {
                    DisableBrowserBackButton();
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

                    var _findUser = _userInformationRT.FindUserByUserName(Convert.ToString(Session["UserName"]));
                    var objUserGroup = _userInformationRT.FindUserGroup(_findUser != null ? _findUser.UserGroupID : default(Int64));

                    if (objUserGroup != null && Session["ContestantID"] == null)
                    {
                        if (Convert.ToInt32(objUserGroup.TypeID) == Convert.ToInt32(Utilities.EnumCollection.UserGroupType.General))
                        {
                            Response.Redirect("~/Default.aspx");
                        }
                    }
                    else
                    {
                        Response.Redirect("~/Default.aspx");
                    }

                }
                else
                {
                    ulLoginOutDirect.Visible = true;
                    lblUsername.Text = string.Empty;
                    lbLogStatus.Text = string.Empty;
                    //Response.Redirect("~/LoginPage.aspx");
                    Response.Redirect("~/Default.aspx");
                }
            }
            catch (Exception ex)
            {

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

    }
}