using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OH.BLL.Basic;
using OH.DAL;
using OH.Utilities;

namespace OH.Web
{
    public partial class MyAccountDetail : System.Web.UI.Page
    {
        /// <summary>
        /// Author : Asiful Islam
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    showUserNamePhn();
                    LoadDropDownLeavingCause();
                }
            }
            catch(Exception ex)
            {
                lblAccountdetails.Text = "Error : " + ex.Message;
                lblAccountdetails.ForeColor = System.Drawing.Color.Red;
            }
         }

        private void showUserNamePhn()
        {
            try
            {
                using (AdGiverRT receiverTransfer = new AdGiverRT())
                {
                    string userEmailId = Convert.ToString(Session["UserName"]);
                    AdGiver adgiverEmailId = receiverTransfer.GetAdGiverIDByEmail(userEmailId);
                    var info= receiverTransfer.GetAdGiverNamePhnByEmail(userEmailId);
                    if (adgiverEmailId != null)
                    {
                        txtfName.Text = info[0].firstname;
                        txtlName.Text = info[0].lastname;
                        txtpNo.Text = info[0].PhoneNo1;                        
                       
                    }
                   
                }
            }
            catch (Exception ex)
            {
                lblAccountdetails.Text = "Error : " + ex.Message;
                lblAccountdetails.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnSaveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                using (AdGiverRT receiverTransfer = new AdGiverRT())
                {
                    string userEmailId = Convert.ToString(Session["UserName"]);
                    AdGiver adgiverEmailId = receiverTransfer.GetAdGiverIDByEmail(userEmailId);

                    if (adgiverEmailId != null)
                    {
                        AdGiver adGiverNamePhn = CreateadGiverNamePhn();
                        receiverTransfer.UpdateadGiverAccNamePhn(userEmailId, adGiverNamePhn.Name,adGiverNamePhn.PhoneNo1);
                        lblAccountdetails.Text = "Name and Phone No. successfully updated...";
                        lblAccountdetails.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblAccountdetails.Text = "Name and Phone No. not updated...";
                        lblAccountdetails.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                lblAccountdetails.Text = "Error : " + ex.Message;
                lblAccountdetails.ForeColor = System.Drawing.Color.Red;
            }
            //clearfield();
            showUserNamePhn();
        }

        private AdGiver CreateadGiverNamePhn()
        {
            AdGiver adGiver = new AdGiver();
            try
            {
                adGiver.PhoneNo1 = txtpNo.Text;
                adGiver.Name = txtfName.Text+" "+txtlName.Text; 
            }
            catch (Exception ex)
            {
                lblAccountdetails.Text = "Error : " + ex.Message;
                lblAccountdetails.ForeColor = System.Drawing.Color.Red;
            }
            return adGiver;
        }

        protected void btnChngPass_Click(object sender, EventArgs e)
        {

            try
            {
                using (AdGiverRT receiverTransfer = new AdGiverRT())
                {
                    string userEmailId = Convert.ToString(Session["UserName"]);
                    string password = txtCurrentPass.Text;
                    AdGiver adgiverEmailId = receiverTransfer.GetAdGiverIDByEmail(userEmailId);
                    string UserpassWord =StringCipher.Decrypt(receiverTransfer.GetPasswordIDByEmail(userEmailId).LoginPassword);
                    if (adgiverEmailId != null && UserpassWord==password)
                    {
                        using (UserInformationRT receiverTransferuserinfo = new UserInformationRT())
                        {
                            UserInfo UserInfoPassword = CreateUserInfoPassword();
                            receiverTransferuserinfo.UpdateUserInfoPassword(userEmailId, StringCipher.Encrypt(UserInfoPassword.LoginPassword));
                            lblAccountdetails.Text = "Password successfully updated...";
                            lblAccountdetails.ForeColor = System.Drawing.Color.Green;
                        }
                    }
                    else
                    {
                        lblAccountdetails.Text = "Current Password is not Valid";
                        lblAccountdetails.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                lblAccountdetails.Text = "Error : " + ex.Message;
                lblAccountdetails.ForeColor = System.Drawing.Color.Red;
            }
            clearfield();
        
        }

        private UserInfo CreateUserInfoPassword()
        {
            UserInfo Userinfo = new UserInfo();
            try
            {
                Userinfo.LoginPassword = txtNewPass.Text;
            }
            catch (Exception ex)
            {
                lblAccountdetails.Text = "Error : " + ex.Message;
                lblAccountdetails.ForeColor = System.Drawing.Color.Red;
            }
            return Userinfo;
        }
        public void clearfield()
        {
            txtConfirmPassword.Text = string.Empty;
            txtCurrentPass.Text = string.Empty;
            txtfName.Text = string.Empty;
            txtlName.Text = string.Empty;
            txtNewPass.Text = string.Empty;
            txtpNo.Text = string.Empty;
        }

        private void LoadDropDownLeavingCause()
        {
            try
            {
                using (DeactivateRT receverTransfer = new DeactivateRT())
                {
                    List<LeavingCause> LeavingCouseList = new List<LeavingCause>();
                    //if (countryID != null)
                    //{
                    //    countryList.Add(receverTransfer.GetCountryByIID((int)countryID));
                    //}
                    //else

                    LeavingCouseList = receverTransfer.GetLeavingCouseAll();

                    DropDownListHelper.Bind<LeavingCause>(ddlLeavingCause, LeavingCouseList, "Name", "IID");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        protected void btnDeactive_Click(object sender, EventArgs e)
        {
            try
            {
                using (AdGiverRT receiverTransfer = new AdGiverRT())
                {
                    string userEmailId = Convert.ToString(Session["UserName"]);
                    AdGiver adgiverEmailId = receiverTransfer.GetAdGiverIDByEmail(userEmailId);

                    if (adgiverEmailId != null)
                    {
                        using (UserInformationRT receiverTransferuserinfo = new UserInformationRT())
                        {
                            UserInfo UserDeactive = CreateUserDeactive();
                            receiverTransferuserinfo.UpdateUserDeactive(userEmailId, UserDeactive.Comments,UserDeactive.LeavingCausesID,UserDeactive.IsActiveUser);
                            Session["UserName"] = null;
                            Response.Redirect("~/");
                        }
                    }
                    else
                    {
                        lblAccountdetails.Text = "Account is not Deactivated Yet";
                        lblAccountdetails.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                lblAccountdetails.Text = "Error : " + ex.Message;
                lblAccountdetails.ForeColor = System.Drawing.Color.Red;
            }
        }

        private UserInfo CreateUserDeactive()
        {
            UserInfo UserinfoDeactive = new UserInfo();
            try
            {
                UserinfoDeactive.Comments = txtComment.Text;
                UserinfoDeactive.LeavingCausesID = Convert.ToInt32(ddlLeavingCause.SelectedValue);
                UserinfoDeactive.IsActiveUser = false;
            }
            catch (Exception ex)
            {
                lblAccountdetails.Text = "Error : " + ex.Message;
                lblAccountdetails.ForeColor = System.Drawing.Color.Red;
            }
            return UserinfoDeactive;
        }

        
    }
}