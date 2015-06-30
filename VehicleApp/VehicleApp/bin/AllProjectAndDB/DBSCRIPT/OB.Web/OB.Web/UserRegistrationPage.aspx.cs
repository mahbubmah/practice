using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OB.DAL;
using BLL.Basic;
using OB.Utilities;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using OB.BLL.Basic;
using Utilities;

namespace OB.Web
{
    public partial class UserRegistrationPage : System.Web.UI.Page
    {
        private const string sessUserRegistration = "seUserRegistration";
        private readonly string _visitorLogPath;
        private string _pageLogPath;

        public UserRegistrationPage()
        {
            this._visitorLogPath = Server.MapPath("~/Log file/VisitorlogFileWriting.txt");
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
                    //LoadClientTypeDropDownInfo();

                    //Get countryIID for Location
                    //int countryID = Convert.ToInt32(EnumCollection.Country.Bangladesh);//change here for change country
                    //hdCountryID.Value = countryID.ToString();
                }
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message, exception);
            }
        }

        protected void btn_CreateAccount_Click(object sender, EventArgs e)
        {
            try
            {
                using (UserInformationRT aUserInformationRt = new UserInformationRT())
                {
                    //  UserInformationRT aUserInformationRt = new UserInformationRT();
                    UserInfo aUserInfo = new UserInfo();
                    //AdGiver adGiver = new AdGiver();
                    aUserInfo = CreateaUserInfo();
                    if (aUserInfo != null)
                    {
                        // const int userInGroup = 7; //for addgiver
                        // adGiverRt.AddAdGiver(adGiver);
                        // aUserInfo = CreateUserInfo(adGiver.IID);
                        aUserInformationRt.AddUserInfo(aUserInfo);

                    }
                    else
                    {
                        if (txtPassword.Text == string.Empty || txtPassword.Text == "")
                        {
                            lblUserRegistration.Text = "Please enter your password";
                        }
                        else if (txtConfirmPassword.Text == "" || txtConfirmPassword.Text == string.Empty)
                        {
                            lblUserRegistration.Text = "Please comfirm your password";
                        }
                        else if (txtPassword.Text != txtConfirmPassword.Text)
                        {
                            lblUserRegistration.Text = "password doesn't match";
                        }
                        else if (txtPassword.Text.Length < 6)
                        {
                            lblUserRegistration.Text = "password too short, enter at least 6 character";
                        }
                        else
                        {
                            lblUserRegistration.Text = string.Format("The email address {0} already registered ",
                                txtEmail.Text.Trim());
                        }
                        lblUserRegistration.ForeColor = System.Drawing.Color.Red;
                        //ClearField();
                        return;
                    }

                    lblUserRegistration.Text = "you have registered successfully...and your Login ID is " + aUserInfo.LoginName;
                    lblUserRegistration.ForeColor = System.Drawing.Color.Green;
                    ClearField();
                }

            }
            catch (Exception ex)
            {
                lblUserRegistration.Text = "Error : " + ex.Message;
                lblUserRegistration.ForeColor = System.Drawing.Color.Red;
            }
        }

        private UserInfo CreateaUserInfo()
        {
            UserInfo userRegistration = new UserInfo();
            try
            {

                using (UserInformationRT adGiverRt = new UserInformationRT())
                {

                    //bool IsThisEmailAlreadyExist = adGiverRt.GetUserInfoIDByEmail(txtEmail.Text) != null;
                    //if (txtPassword.Text.Length < 6 || IsThisEmailAlreadyExist || (txtPassword.Text != txtConfirmPassword.Text) || txtPassword.Text == string.Empty || txtPassword.Text == "" || txtConfirmPassword.Text == "" || txtConfirmPassword.Text == string.Empty)
                    //{
                    //    return null;
                    //}

                    userRegistration.UserName = txtFirstName.Text + " " + txtLastname.Text;
                    userRegistration.LoginName = txtEmail.Text;
                    userRegistration.PhoneNo = txtContactNo.Text;
                    userRegistration.IsActiveUser = true;

                    if (txtPassword.Text == txtConfirmPassword.Text)
                    {
                        string encriptedPass = txtPassword.Text.Trim();
                        encriptedPass = Convert.ToString(StringCipher.Encrypt(encriptedPass));
                        var salt = StringCipher.Salt;

                        userRegistration.Salt = salt;
                        userRegistration.LoginPassword = encriptedPass;
                    }
                    userRegistration.IsEmail = chkConfByEmail.Checked;
                    // userRegistration.IsSMS = chkSMS.Checked;
                    //userRegistration.CreatedBy = Convert.ToInt64(Session["UserID"]);
                    //userRegistration.CreatedDate = GlobalRT.GetServerDateTime();
                    userRegistration.IsRemoved = false;
                    using (var aUserGroupRt = new UserGroupRT())
                    {
                        var userGroup = aUserGroupRt.GetUserGroupAll();
                        userRegistration.UserGroupID = userGroup.FirstOrDefault(x => x.TypeID == Convert.ToInt32(EnumCollection.UserGroupType.General)).IID;
                    }
                    if (userRegistration.IID <= 0)
                    {
                        userRegistration.CreatedBy = Convert.ToInt64(Session["UserID"]);
                        userRegistration.CreatedDate = GlobalRT.GetServerDateTime();
                    }
                    else
                    {
                        UserInfo usrGrp = (UserInfo)Session[sessUserRegistration];
                        userRegistration.CreatedBy = usrGrp.CreatedBy; ;
                        userRegistration.CreatedDate = usrGrp.CreatedDate;
                        userRegistration.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                        userRegistration.ModifiedDate = GlobalRT.GetServerDateTime();
                    }

                }
            }
            catch (Exception ex)
            {
                lblUserRegistration.Text = "Error : " + ex.Message;
                lblUserRegistration.ForeColor = System.Drawing.Color.Red;
            }
            return userRegistration;
        }

        public void ClearField()
        {
            txtFirstName.Text = string.Empty;
            txtLastname.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;
            txtContactNo.Text = string.Empty;
            chkConfByEmail.Checked = false;
            txtConEmailAdd.Text = string.Empty;

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                ClearField();
                Response.Redirect("~/Default");
            }
            catch (Exception ex)
            {

            }
        }
    }
}