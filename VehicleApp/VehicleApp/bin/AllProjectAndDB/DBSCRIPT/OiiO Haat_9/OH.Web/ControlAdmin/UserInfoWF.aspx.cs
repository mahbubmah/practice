using OH.BLL.Basic;
using OH.DAL;
using OH.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OH.Web.ControlAdmin
{
    public partial class UserInfoWF : System.Web.UI.Page
    {
        private const string sessUserInfo = "seUserInfo";


        #region protected method
        protected void Page_Load(object sender, EventArgs e)
        {
            //txtSalt.Visible = false;
            //hdIsDelete.Value = "";
            //hdIsEdit.Value = "";
            if (!IsPostBack)
            {
                try
                {
                    LoadDropDownUserGroup(null);
                    LoadUserInfo();
                    btnSave.Visible = true;
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    btnCancel.Visible = false;
                }
                catch (Exception ex)
                {
                    labelMessage.Text = "Error : " + ex.Message;
                    labelMessage.ForeColor = System.Drawing.Color.Red;
                }
            }

        }
        //paging Option
        int lvRowCount = 0;
        int currentPage = 0;

        protected void lvUserInfo_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void lvUserInfo_PreRender(object sender, EventArgs e)
        {

        }

        protected void lvUserInfo_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "EditUserInfo")
            {
                labelMessage.Text = string.Empty;
                try
                {
                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    btnCancel.Visible = true;
                    int userInfoID = Convert.ToInt32(e.CommandArgument);
                    hdUserInfoID.Value = userInfoID.ToString();
                    using (UserInformationRT receiverTransfer = new UserInformationRT())
                    {
                        UserInfo userInfo = receiverTransfer.GetUserInfoByID(userInfoID);
                        FillUserInfoForEdit(userInfo);
                    }
                }
                catch (Exception ex)
                {
                    labelMessage.Text = "Error : " + ex.Message;
                    labelMessage.ForeColor = System.Drawing.Color.Red;
                }
            }

        }

        protected void dataPagerUserInfo_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    LoadUserInfo();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                labelMessage.Text = string.Empty;
                using (UserInformationRT receiverTransfer = new UserInformationRT())
                {
                    List<UserInfo> UserInfo = new List<UserInfo>();
                    Int32 userGroupID = Convert.ToInt32(dropDownListGroupName.SelectedValue);
                    UserInfo = receiverTransfer.GetUserInfoIDByGropIDAndLoginNameAndLoginPassword(userGroupID, txtLoginName.Text);
                    if (UserInfo != null && UserInfo.Count > 0)
                    {
                        string msg = "Group Name  " + dropDownListGroupName.SelectedItem + " And\n" + " Login Name " + txtLoginName.Text +" Already Exists!";
                        labelMessage.Text = msg;
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    UserInfo userInfo = CreateUserInfo();
                    receiverTransfer.AddUserInfo(userInfo);
                    if (userInfo.IID > 0)
                    {
                        labelMessage.Text = "Data successfully saved...";
                        labelMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        labelMessage.Text = "Data not saved...";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }

                ClearField();
                LoadUserInfo();
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {  
            try
                {
                    labelMessage.Text = string.Empty;
                    using (UserInformationRT receiverTransfer = new UserInformationRT())
                    {
                        hdIsEdit.Value = "true";

                         List<UserInfo> userInfoList = new List<UserInfo>();
                         Int32 userGroupID = Convert.ToInt32(dropDownListGroupName.SelectedValue);
                         Int32 userID =Convert.ToInt32( hdUserInfoID.Value.ToString());
                         userInfoList = receiverTransfer.GetUserInfoIDByGropIDAndLoginNameAndLoginPasswordAndUserID(userID, userGroupID, txtLoginName.Text);

                         if (userInfoList != null && userInfoList.Count > 0)
                         {
                             string msg = "Group Name  " + "'"+dropDownListGroupName.SelectedItem +"'"+ " And\n" + " Login Name " + "'"+txtLoginName.Text+ "'" + " Already Exists!";
                             labelMessage.Text = msg;
                             labelMessage.ForeColor = System.Drawing.Color.Red;
                             return;
                         }

                        UserInfo userInfo = CreateUserInfo();

                        if (userInfo != null)
                        {
                            receiverTransfer.UpdateUserInfo(userInfo);
                            labelMessage.Text = "Data successfully updated...";
                            labelMessage.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            labelMessage.Text = "Data not updated...";
                            labelMessage.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    btnSave.Visible = true;
                    btnUpdate.Visible = false;
                    btnCancel.Visible = false;
                    btnDelete.Visible = false;
                    ClearField();
                    LoadUserInfo();
                }
                catch (Exception ex)
                {
                    labelMessage.Text = "Error : " + ex.Message;
                    labelMessage.ForeColor = System.Drawing.Color.Red;

                }
            }
        

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                 labelMessage.Text = string.Empty;
                using (UserInformationRT receiverTransfer = new UserInformationRT())
                {
                    hdIsDelete.Value = "true";
                    hdIsEdit.Value = "true";
                    UserInfo user = CreateUserInfo();

                    if (user != null)
                    {
                        receiverTransfer.UpdateUserInfo(user);
                        labelMessage.Text = "Data successfully deleted...";
                        labelMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        labelMessage.Text = "Data not deleted...";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }
                btnSave.Visible = true;
                btnUpdate.Visible = false;
                btnCancel.Visible = false;
                btnDelete.Visible = false;
                LoadUserInfo();
                ClearField();
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearField();
            btnSave.Visible = true;
            btnDelete.Visible = false;
            btnCancel.Visible = false;
            btnUpdate.Visible = false;
        }
        #endregion protected method

        #region private method

        private void LoadDropDownUserGroup(Int32? userGroupID)
        {
            try
            {
                using (UserGroupRT receverTransfer = new UserGroupRT())
                {
                    List<UserGroup> userGroupList = new List<UserGroup>();
                    if (userGroupID != null)
                    {
                        userGroupList.Add(receverTransfer.GetUserGroupByIID((Int32)userGroupID));
                    }
                    else
                    {
                        userGroupList = receverTransfer.GetUserGroupAll();
                    }
                    DropDownListHelper.Bind<UserGroup>(dropDownListGroupName, userGroupList, "Name", "IID", EnumCollection.ListItemType.UserGroup);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        private void LoadUserInfo()
        {
            try
            {
                using (UserInformationRT receiverTransfer = new UserInformationRT())
                {
                    lvUserInfo.DataSource = receiverTransfer.GetUserInfoAllForListView(); ;
                    lvUserInfo.DataBind();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }


        }


        private UserInfo CreateUserInfo()
        {
            Session["UserID"] = "1";
            UserInfo userInfo = new UserInfo();
            try
            {
                if (hdIsEdit.Value == "true")
                {
                    userInfo.IID = Convert.ToInt32(hdUserInfoID.Value.ToString());
                }

                userInfo.UserGroupID = Convert.ToInt32(dropDownListGroupName.SelectedValue);
                userInfo.LoginName = txtLoginName.Text;

                if (txtLoginPassword.Text == txtRetypePassword.Text)
                {
                    var encriptedPass = txtLoginPassword.Text.Trim();
                    encriptedPass = StringCipher.Encrypt(encriptedPass);
                    var salt = StringCipher.Salt;

                    userInfo.Salt = salt;
                    userInfo.LoginPassword = encriptedPass;
                }
              //  userInfo.LoginPassword = txtLoginPassword.Text;
                //userInfo.Salt = txtSalt.Text;

                if (chkIsActive.Checked == true )
                {
                    userInfo.IsActiveUser = true;
                }
                else
                {
                    userInfo.IsActiveUser = false;
                }

                if (userInfo.IID <= 0)
                {
                    userInfo.CreatedBy = Convert.ToInt64(Session["UserID"]);
                    userInfo.CreatedDate = GlobalRT.GetServerDateTime();
                }
                else
                {
                    UserInfo userP = (UserInfo)Session[sessUserInfo];
                    userInfo.CreatedBy = userP.CreatedBy; ;
                    userInfo.CreatedDate = userP.CreatedDate;
                    userInfo.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                    userInfo.ModifiedDate = GlobalRT.GetServerDateTime();
                }

                if (hdIsDelete.Value == "true")
                {
                    userInfo.IsRemoved = true;
                    hdIsDelete.Value = "false";

                }
                else
                {
                    userInfo.IsRemoved = false;
                }

            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return userInfo;

        }

        private void ClearField()
        {
            dropDownListGroupName.SelectedIndex=0;
            txtLoginName.Text = string.Empty;
            txtLoginPassword.Text = String.Empty;
            txtRetypePassword.Text = string.Empty;
            txtSalt.Text = String.Empty;
            chkIsActive.Checked = false;
        }

        private void FillUserInfoForEdit(UserInfo userInfo)
        {
            try
            {
                if (userInfo != null)
                {
                    dropDownListGroupName.SelectedValue = userInfo.UserGroupID.ToString();
                    txtLoginName.Text = userInfo.LoginName;
                    txtLoginPassword.Text = StringCipher.Decrypt(userInfo.LoginPassword);
                    txtSalt.Text = userInfo.Salt;
                    chkIsActive.Checked =Convert.ToBoolean( userInfo.IsActiveUser);
                    txtRetypePassword.Text = StringCipher.Decrypt(userInfo.LoginPassword);
                    Session[sessUserInfo] = userInfo;
                    
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }

        }
        #endregion private method
    }
}