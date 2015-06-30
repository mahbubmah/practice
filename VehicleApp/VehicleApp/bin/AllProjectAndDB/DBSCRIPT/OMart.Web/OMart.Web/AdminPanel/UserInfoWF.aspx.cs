using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BLL.Basic;
using DAL;
using Utilities;

namespace OMart.Web.AdminPanel
{
    public partial class UserInfoWF : System.Web.UI.Page
    {
        private const string sessUserInfo = "seUserInfo";

        #region protected method
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                try
                {
                    LoadDropDownUserGroup(null);
                    LoadUserInfo();
                    btnSave.Visible = true;
                    btnUpdate.Visible = false;
                   
                    btnCancel.Visible = false;
                }
                catch (Exception ex)
                {
                    labelMessageUserInfo.Text = "Error : " + ex.Message;
                    labelMessageUserInfo.ForeColor = System.Drawing.Color.Red;
                }
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                labelMessageUserInfo.Text = string.Empty;
                using (UserInformationRT receiverTransfer = new UserInformationRT())
                {
                    List<UserInfo> UserInfo = new List<UserInfo>();
                    Int32 userGroupID = Convert.ToInt32(dropDownListGroupName.SelectedValue);
                    UserInfo = receiverTransfer.GetUserInfoIDByGropIDAndLoginNameAndLoginPassword(userGroupID, txtLoginName.Text);
                    if (UserInfo != null && UserInfo.Count > 0)
                    {
                        string msg = "Group Name  " + dropDownListGroupName.SelectedItem + " And\n" + " Login Name " + txtLoginName.Text + " Already Exists!";
                        labelMessageUserInfo.Text = msg;
                        labelMessageUserInfo.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    UserInfo userInfo = CreateUserInfo();
                    receiverTransfer.AddUserInfo(userInfo);
                    if (userInfo.IID > 0)
                    {
                        labelMessageUserInfo.Text = "Data successfully saved...";
                        labelMessageUserInfo.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        labelMessageUserInfo.Text = "Data not saved...";
                        labelMessageUserInfo.ForeColor = System.Drawing.Color.Red;
                    }
                }

                ClearField();
                LoadUserInfo();
            }
            catch (Exception ex)
            {
                labelMessageUserInfo.Text = "Error : " + ex.Message;
                labelMessageUserInfo.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                labelMessageUserInfo.Text = string.Empty;
                using (UserInformationRT receiverTransfer = new UserInformationRT())
                {
                    hdIsEdit.Value = "true";

                    List<UserInfo> userInfoList = new List<UserInfo>();
                    Int32 userGroupID = Convert.ToInt32(dropDownListGroupName.SelectedValue);
                    Int32 userID = Convert.ToInt32(hdUserInfoID.Value.ToString());
                    userInfoList = receiverTransfer.GetUserInfoIDByGropIDAndLoginNameAndLoginPasswordAndUserID(userID, userGroupID, txtLoginName.Text);

                    if (userInfoList != null && userInfoList.Count > 0)
                    {
                        string msg = "Group Name  " + "'" + dropDownListGroupName.SelectedItem + "'" + " And\n" + " Login Name " + "'" + txtLoginName.Text + "'" + " Already Exists!";
                        labelMessageUserInfo.Text = msg;
                        labelMessageUserInfo.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    UserInfo userInfo = CreateUserInfo();

                    if (userInfo != null)
                    {
                        receiverTransfer.UpdateUserInfo(userInfo);
                        labelMessageUserInfo.Text = "Data successfully updated...";
                        labelMessageUserInfo.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        labelMessageUserInfo.Text = "Data not updated...";
                        labelMessageUserInfo.ForeColor = System.Drawing.Color.Red;
                    }
                }
                btnSave.Visible = true;
                btnUpdate.Visible = false;
                btnCancel.Visible = false;
              
                ClearField();
                LoadUserInfo();
            }
            catch (Exception ex)
            {
                labelMessageUserInfo.Text = "Error : " + ex.Message;
                labelMessageUserInfo.ForeColor = System.Drawing.Color.Red;

            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                labelMessageUserInfo.Text = string.Empty;
                using (UserInformationRT receiverTransfer = new UserInformationRT())
                {
                    hdIsDelete.Value = "true";
                    hdIsEdit.Value = "true";
                    UserInfo user = CreateUserInfo();

                    if (user != null)
                    {
                       
                        receiverTransfer.UpdateUserInfo(user);
                        labelMessageUserInfo.Text = "Data successfully deleted...";
                        labelMessageUserInfo.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        labelMessageUserInfo.Text = "Data not deleted...";
                        labelMessageUserInfo.ForeColor = System.Drawing.Color.Red;
                    }
                }
                btnSave.Visible = true;
                btnUpdate.Visible = false;
                btnCancel.Visible = false;
              
                LoadUserInfo();
                ClearField();
            }
            catch (Exception ex)
            {
                labelMessageUserInfo.Text = "Error : " + ex.Message;
                labelMessageUserInfo.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearField();
            btnSave.Visible = true;
           
            btnCancel.Visible = false;
            btnUpdate.Visible = false;
        }

        protected void lvUserInfo_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "EditUserInfo")
            {
                labelMessageUserInfo.Text = string.Empty;
                try
                {
                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    
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
                    labelMessageUserInfo.Text = "Error : " + ex.Message;
                    labelMessageUserInfo.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void lvUserInfo_PreRender(object sender, EventArgs e)
        {

        }

        protected void lvUserInfo_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        int lvRowCount = 0;
        int currentPage = 0;
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
                labelMessageUserInfo.Text = "Error : " + ex.Message;
                labelMessageUserInfo.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lnkbEdit_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton linkButton = (LinkButton)sender;
                int id = Convert.ToInt32(linkButton.CommandArgument);
                btnSave.Visible = false;
                btnUpdate.Visible = true;
               
                btnCancel.Visible = true;

                hdUserInfoID.Value = id.ToString();
                using (UserInformationRT receiverTransfer = new UserInformationRT())
                {
                    UserInfo userInfo = receiverTransfer.GetUserInfoByID(id);
                    FillUserInfoForEdit(userInfo);
                }
                //LoadUserInfo()
            }
            catch (Exception ex)
            {
                labelMessageUserInfo.Text = "Error : " + ex.Message;
                labelMessageUserInfo.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lnkbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton linkButton = new LinkButton();
                linkButton = (LinkButton)sender;
                UserInformationRT receiverTransfer = new UserInformationRT();
                var userInformation = receiverTransfer.GetUserInfoByID(Convert.ToInt32(linkButton.CommandArgument));
                userInformation.IsRemoved = true;
                if (userInformation != null)
                {
                    receiverTransfer.UpdateUserInfo(userInformation);
                    LoadUserInfo();
                    labelMessageUserInfo.Text = "User has been removed successfully.";
                    labelMessageUserInfo.ForeColor = System.Drawing.Color.Green;
                }
               
            }
            catch (Exception ex)
            {
                labelMessageUserInfo.Text = "Error : " + ex.Message;
                labelMessageUserInfo.ForeColor = System.Drawing.Color.Red;
            }
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
                labelMessageUserInfo.Text = "Error : " + ex.Message;
                labelMessageUserInfo.ForeColor = System.Drawing.Color.Red;
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
                userInfo.LoginPassword = txtLoginPassword.Text;
                userInfo.Salt = txtSalt.Text;

                if (chkIsActive.Checked == true)
                {
                    userInfo.IsActiveUser = true;
                    userInfo.IsRemoved = false;
                }
                else
                {
                    userInfo.IsActiveUser = false;
                    userInfo.IsRemoved = true;
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

                //if (hdIsDelete.Value == "true")
                //{
                //    userInfo.IsRemoved = true;
                //    hdIsDelete.Value = "false";

                //}
                //else
                //{
                //    userInfo.IsRemoved = false;
                //}

            }
            catch (Exception ex)
            {
                labelMessageUserInfo.Text = "Error : " + ex.Message;
                labelMessageUserInfo.ForeColor = System.Drawing.Color.Red;
            }
            return userInfo;

        }

        private void ClearField()
        {
            dropDownListGroupName.SelectedIndex = 0;
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
                    txtLoginPassword.Text = userInfo.LoginPassword;
                    txtSalt.Text = userInfo.Salt;
                    chkIsActive.Checked = Convert.ToBoolean(userInfo.IsActiveUser);
                    txtRetypePassword.Text = userInfo.LoginPassword;
                    Session[sessUserInfo] = userInfo;
                }
            }
            catch (Exception ex)
            {
                labelMessageUserInfo.Text = "Error : " + ex.Message;
                labelMessageUserInfo.ForeColor = System.Drawing.Color.Red;
            }

        }

        #endregion private method

        protected void lvUserInfo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}