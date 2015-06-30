using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using BLL;
using BLL.Basic;
using DAL;

namespace OMart.Web.AdminPanel
{
    public partial class UserGroupWF : System.Web.UI.Page
    {
        private const string sessUserGrp = "seUserGroup";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    LoadddlUserTypeID();
                    LoadUserGrp();
                    btnSave.Visible = true;
                    btnUpdate.Visible = false;
                   
                    btnCancel.Visible = false;
                    chkUserGrpIsRemove.Visible = false;
                }
                catch (Exception ex)
                {
                    labelMessageUserGroup.Text = "Error : " + ex.Message;
                    labelMessageUserGroup.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        private void LoadUserGrp()
        {
            try
            {
                using (UserGroupRT receiverTransfer = new UserGroupRT())
                {
                    lvUserGroup.DataSource = receiverTransfer.GetUserGrpAllForListView(); ;
                    lvUserGroup.DataBind();
                }
            }
            catch (Exception ex)
            {
                labelMessageUserGroup.Text = "Error : " + ex.Message;
                labelMessageUserGroup.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void LoadddlUserTypeID()
        {
            try
            {
                DropDownListHelper.Bind(DropDownTypeID, EnumHelper.EnumToList<EnumCollection.UserGrpType>(), EnumCollection.ListItemType.UserTypeID);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (DropDownTypeID.SelectedValue != "-1")
                {
                    labelMessageUserGroup.Text = string.Empty;
                    using (UserGroupRT receiverTransfer = new UserGroupRT())
                    {

                        List<UserGroup> UserGrpList = new List<UserGroup>();
                        UserGrpList = receiverTransfer.GetUserGrpName(txtUserGrpName.Text);

                        if (UserGrpList != null && UserGrpList.Count > 0)
                        {
                            string msg = "User Group Name  " + txtUserGrpName.Text + " Already Exists!";
                            //string alertScript =
                            //String.Format("alert('{0}');", msg);
                            //Page.ClientScript.RegisterStartupScript(this.GetType(), "Key", alertScript, true);

                            labelMessageUserGroup.Text = msg;
                            return;
                        }
                        hdSave.Value = "true";
                        UserGroup userGrp = CreateUserGrp();
                        receiverTransfer.AddUserGrp(userGrp);
                        if (userGrp.IID > 0)
                        {
                            labelMessageUserGroup.Text = "Data successfully saved...";
                            labelMessageUserGroup.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            labelMessageUserGroup.Text = "Data not saved...";
                            labelMessageUserGroup.ForeColor = System.Drawing.Color.Red;
                        }
                    }

                    ClearField();
                    LoadUserGrp();
                }
                else
                {
                    //DropDownTypeID.ValidateRequestMode.ToString();
                    labelMessageUserGroup.Text = "Please Select User Type";
                    labelMessageUserGroup.ForeColor = System.Drawing.Color.DarkRed;

                }
            }
            catch (Exception ex)
            {
                labelMessageUserGroup.Text = "Error : " + ex.Message;
                labelMessageUserGroup.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lnkbEdit_Click(object sender, EventArgs e)
        {
            try
            {
                labelMessageUserGroup.Text = string.Empty;
                LinkButton linkButton = (LinkButton)sender;
                int id = Convert.ToInt32(linkButton.CommandArgument);
                btnSave.Visible = false;
                btnUpdate.Visible = true;
                chkUserGrpIsRemove.Visible = true;
                btnCancel.Visible = true;

                hdUserGrpID.Value = id.ToString();
                using (UserGroupRT receiverTransfer = new UserGroupRT())
                {
                    UserGroup userGroup = receiverTransfer.GetUserGroupByIID(id);
                   
                    FillUserGrpForEdit(userGroup);
                }
                //LoadUserInfo()
            }
            catch (Exception ex)
            {
                labelMessageUserGroup.Text = "Error : " + ex.Message;
                labelMessageUserGroup.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lnkbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton linkButton = new LinkButton();
                linkButton = (LinkButton)sender;
                UserGroupRT receiverTransfer = new UserGroupRT();
                var UserGroup = receiverTransfer.GetUserGroupByIID(Convert.ToInt32(linkButton.CommandArgument));
                UserGroup.IsRemoved = true;
                if (UserGroup != null)
                {
                    receiverTransfer.UpdateUserGrp(UserGroup);
                    LoadUserGrp();
                    labelMessageUserGroup.Text = "User Group has been removed successfully.";
                    labelMessageUserGroup.ForeColor = System.Drawing.Color.Green;
                }

            }
            catch (Exception ex)
            {
                labelMessageUserGroup.Text = "Error : " + ex.Message;
                labelMessageUserGroup.ForeColor = System.Drawing.Color.Red;
            }
        }


        private UserGroup CreateUserGrp()
        {
            Session["UserID"] = "1";
            UserGroup userGrp = new UserGroup();
            try
            {
                if (hdIsEdit.Value == "true")
                {
                    userGrp.IID = Convert.ToInt32(hdUserGrpID.Value.ToString());
                }
                userGrp.Name = txtUserGrpName.Text.Trim();
                userGrp.IsRemoved = chkUserGrpIsRemove.Checked;
                userGrp.TypeID = Convert.ToInt32(DropDownTypeID.SelectedValue);
                if (userGrp.IID <= 0)
                {
                    userGrp.CreatedBy = Convert.ToInt64(Session["UserID"]);
                    userGrp.CreatedDate = GlobalRT.GetServerDateTime();
                }
                else
                {
                    UserGroup usrGrp = (UserGroup)Session[sessUserGrp];
                    userGrp.CreatedBy = usrGrp.CreatedBy; ;
                    userGrp.CreatedDate = usrGrp.CreatedDate;
                    userGrp.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                    userGrp.ModifiedDate = GlobalRT.GetServerDateTime();
                }
                //if ((hdIsEdit.Value != "true" && chkUserGrpIsRemove.Checked!=true)||(hdSave.Value=="true" &&chkUserGrpIsRemove.Checked!=true))
                //{
                //    userGrp.IsRemoved = false;
                //}
                //else
                //{
                //    userGrp.IsRemoved = true;
                //}
            }
            catch (Exception ex)
            {
                labelMessageUserGroup.Text = "Error : " + ex.Message;
                labelMessageUserGroup.ForeColor = System.Drawing.Color.Red;
            }
            return userGrp;
        }



        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // labelMessage.Text = string.Empty;
                using (UserGroupRT receiverTransfer = new UserGroupRT())
                {
                    hdIsEdit.Value = "true";
                    UserGroup usergrp = CreateUserGrp();

                    if (usergrp != null)
                    {
                        receiverTransfer.UpdateUserGrp(usergrp);
                        labelMessageUserGroup.Text = "Data successfully updated...";
                        labelMessageUserGroup.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        labelMessageUserGroup.Text = "Data not updated...";
                        labelMessageUserGroup.ForeColor = System.Drawing.Color.Red;
                    }
                }
                ClearField();
                btnVisibilityForCancel();
                LoadUserGrp();
            }
            catch (Exception ex)
            {
                labelMessageUserGroup.Text = "Error : " + ex.Message;
                labelMessageUserGroup.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // labelMessage.Text = string.Empty;
                using (UserGroupRT receiverTransfer = new UserGroupRT())
                {
                    UserGroupRT UserGrpExist = new UserGroupRT();
                    bool IsUserGrpExistinUserInfo = receiverTransfer.GetUserGrpRelationWithUserInfoTables(Convert.ToInt32(txtUsergrpID.Text));
                    bool IsUserGrpExistinUserWFPermission = receiverTransfer.GetUserGrpRelationWithUserWFPermissionTables(Convert.ToInt32(txtUsergrpID.Text));
                    if (IsUserGrpExistinUserInfo || IsUserGrpExistinUserWFPermission)
                    {
                        string msg = "User Group  " + txtUserGrpName.Text + " is being used by another Process!";
                        labelMessageUserGroup.Text = msg;
                        return;
                    }

                    else
                    {
                        hdIsDelete.Value = "true";
                        hdIsEdit.Value = "true";
                        receiverTransfer.DeleteUserGrp(Convert.ToInt64(txtUsergrpID.Text));
                        labelMessageUserGroup.Text = "Data successfully deleted...";
                        labelMessageUserGroup.ForeColor = System.Drawing.Color.Green;

                    }
                }
                LoadUserGrp();
                ClearField();
                btnVisibilityForCancel();
            }
            catch (Exception ex)
            {
                labelMessageUserGroup.Text = "Error : " + ex.Message;
                labelMessageUserGroup.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void btnVisibilityForCancel()
        {
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            
            chkUserGrpIsRemove.Checked = false;
            chkUserGrpIsRemove.Visible = false;

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearField();
            labelMessageUserGroup.Text = "";
            btnVisibilityForCancel();
        }

        private void ClearField()
        {
            txtUserGrpName.Text = string.Empty;
            //txtDescription.Text = string.Empty;
            //txtName.Text = string.Empty;
            DropDownTypeID.SelectedValue = null;
        }

        protected void lvUserGroup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void lvUserGroup_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "EditUserGroup")
            {
                try
                {
                    labelMessageUserGroup.Text = string.Empty;
                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                   
                    btnCancel.Visible = true;
                    chkUserGrpIsRemove.Visible = true;
                    int usergrpID = Convert.ToInt32(e.CommandArgument);
                    hdUserGrpID.Value = usergrpID.ToString();
                    using (UserGroupRT receiverTransfer = new UserGroupRT())
                    {
                        UserGroup usergrp = receiverTransfer.GetUserGroupByIID(usergrpID);
                        FillUserGrpForEdit(usergrp);
                    }
                }
                catch (Exception ex)
                {
                    labelMessageUserGroup.Text = "Error : " + ex.Message;
                    labelMessageUserGroup.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        private void FillUserGrpForEdit(UserGroup usergrp)
        {
            try
            {
                if (usergrp != null)
                {
                    DropDownTypeID.SelectedValue = usergrp.TypeID.ToString();
                    txtUserGrpName.Text = usergrp.Name;
                    txtUsergrpID.Text = usergrp.IID.ToString();
                    if (usergrp.IsRemoved == true)
                    {

                        chkUserGrpIsRemove.Checked = true;

                    }
                    else
                    {
                        chkUserGrpIsRemove.Checked = false;
                    }
                    Session[sessUserGrp] = usergrp;
                }
            }
            catch (Exception ex)
            {
                labelMessageUserGroup.Text = "Error : " + ex.Message;
                labelMessageUserGroup.ForeColor = System.Drawing.Color.Red;
            }
        }

        int lvRowCount = 0;
        int currentPage = 0;
        protected void lvUserGroup_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void dataPagerUserGroup_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    LoadUserGrp();
                }
            }
            catch (Exception ex)
            {
                labelMessageUserGroup.Text = "Error : " + ex.Message;
                labelMessageUserGroup.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}