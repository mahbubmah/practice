using OH.BLL.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OH.Web
{
    public partial class LoginMaster : System.Web.UI.MasterPage
    {
        private readonly UserInformationRT _userInformationRT;
        private readonly CategoryRT _categoryRT;
        public LoginMaster()
        {
            this._categoryRT = new CategoryRT();
            this._userInformationRT = new UserInformationRT();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadDefaultPageUrl();
                    LoadDefaultLoginLogout();

                }
            }
            catch (Exception ex)
            {

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

                    if (objUserGroup != null)
                    {
                        if (Convert.ToInt32(objUserGroup.TypeID) != Convert.ToInt32(OH.Utilities.EnumCollection.UserGrpType.Add_Giver))
                        {
                            Response.Redirect("~/ControlAdmin/AdminDefault.aspx");
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

            }
        }
        private void LoadDefaultPageUrl()
        {
            #region Default url loading

            hrfRegister.HRef = "~/Register";
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