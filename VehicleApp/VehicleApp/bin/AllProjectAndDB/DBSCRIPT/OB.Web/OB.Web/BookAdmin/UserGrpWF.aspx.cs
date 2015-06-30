using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OB.BLL.Basic;
using OB.DAL;
using OB.Utilities;

namespace OB.Web.BookAdmin
{
    public partial class UserGrpWF : System.Web.UI.Page
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
                    btnDelete.Visible = false;
                    btnCancel.Visible = false;
                    chkRemove.Visible = false;
                }
                catch (Exception ex)
                {
                    labelMessageUserGrp.Text = "Error : " + ex.Message;
                    labelMessageUserGrp.ForeColor = System.Drawing.Color.Red;
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
                labelMessageUserGrp.Text = "Error : " + ex.Message;
                labelMessageUserGrp.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void LoadddlUserTypeID()
        {
            try
            {
                //ListItem l = new ListItem("Select User Group Type", "-1", true); 
                //l.Selected = true;
                //DropDownTypeID.Items.Add(l);
                
                DropDownListHelper.Bind(DropDownTypeID, EnumHelper.EnumToList<EnumCollection.UserGroupType>(),EnumCollection.ListItemType.UserTypeID);

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
                        labelMessageUserGrp.Text = string.Empty;
                        hdSave.Value = "true";
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

                                labelMessageUserGrp.Text = msg;
                                return;
                            }

                            UserGroup userGrp = CreateUserGrp();
                            receiverTransfer.AddUserGrp(userGrp);
                            if (userGrp.IID > 0)
                            {
                                labelMessageUserGrp.Text = "Data successfully saved...";
                                labelMessageUserGrp.ForeColor = System.Drawing.Color.Green;
                            }
                            else
                            {
                                labelMessageUserGrp.Text = "Data not saved...";
                                labelMessageUserGrp.ForeColor = System.Drawing.Color.Red;
                            }
                        }

                         ClearField();
                         LoadUserGrp();
                         hdSave.Value = string.Empty;
                         btnVisibilityForCancel();
                     
                    }
                    catch (Exception ex)
                    {
                        labelMessageUserGrp.Text = "Error : " + ex.Message;
                        labelMessageUserGrp.ForeColor = System.Drawing.Color.Red;
                    }
        }

        private void ClearField()
        {
            txtUserGrpName.Text = string.Empty;
            //txtDescription.Text = string.Empty;
            //txtName.Text = string.Empty;
            DropDownTypeID.SelectedValue = null;
            chkRemove.Checked = false;
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
                            //designation.Code = txtCode.Text.Trim();
                            //designation.Description = txtDescription.Text.Trim();
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
                            //if (hdIsDelete.Value != "true")
                            //{
                            //    userGrp.IsActive = true;
                            //}
                            //else
                            //{
                            //    userGrp.IsActive = false;
                            //}
                            if ((hdIsEdit.Value == "true" && chkRemove.Checked == false) || (hdSave.Value == "true" && chkRemove.Checked == false))
                            {
                                userGrp.IsRemoved = false;
                            }
                            else if (hdIsEdit.Value == "true" && chkRemove.Checked == true)
                            {
                                userGrp.IsRemoved = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            labelMessageUserGrp.Text = "Error : " + ex.Message;
                            labelMessageUserGrp.ForeColor = System.Drawing.Color.Red;
                        }
                        return userGrp;
        }

        protected void lvUserGroup_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
                if (e.CommandName == "EditUserGroup")
                {
                    try
                    {
                        labelMessageUserGrp.Text = string.Empty;
                        btnSave.Visible = false;
                        btnUpdate.Visible = true;
                        btnDelete.Visible = true;
                        btnCancel.Visible = true;
                        chkRemove.Visible = true;
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
                        labelMessageUserGrp.Text = "Error : " + ex.Message;
                        labelMessageUserGrp.ForeColor = System.Drawing.Color.Red;
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

                                    chkRemove.Checked = true;

                                }
                                else
                                {
                                    chkRemove.Checked = false;
                                }
                                Session[sessUserGrp] = usergrp;
                            }
                        }
                        catch (Exception ex)
                        {
                            labelMessageUserGrp.Text = "Error : " + ex.Message;
                            labelMessageUserGrp.ForeColor = System.Drawing.Color.Red;
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
                            labelMessageUserGrp.Text = "Error : " + ex.Message;
                            labelMessageUserGrp.ForeColor = System.Drawing.Color.Red;
                        }
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
                        labelMessageUserGrp.Text = "Data successfully updated...";
                        labelMessageUserGrp.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        labelMessageUserGrp.Text = "Data not updated...";
                        labelMessageUserGrp.ForeColor = System.Drawing.Color.Red;
                    }
                }
                ClearField();
                LoadUserGrp();
                btnVisibilityForCancel();
            }
            catch (Exception ex)
            {
                labelMessageUserGrp.Text = "Error : " + ex.Message;
                labelMessageUserGrp.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearField();
            labelMessageUserGrp.Text = "";
            btnVisibilityForCancel();
        }
        private void btnVisibilityForCancel()
        {
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            btnDelete.Visible = false;
            chkRemove.Visible = false;

        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
             try
                    {
                        // labelMessage.Text = string.Empty;
                        using (UserGroupRT receiverTransfer = new UserGroupRT())
                        {
                            UserGroupRT UserGrpExist=new UserGroupRT();
                            bool IsUserGrpExistinUserInfo = receiverTransfer.GetUserGrpRelationWithUserInfoTables(Convert.ToInt32(txtUsergrpID.Text));
                            bool IsUserGrpExistinUserWFPermission = receiverTransfer.GetUserGrpRelationWithUserWFPermissionTables(Convert.ToInt32(txtUsergrpID.Text));
                            if (IsUserGrpExistinUserInfo||IsUserGrpExistinUserWFPermission)
                            {
                                string msg = "User Group  " + txtUserGrpName.Text + " is being used by another Process!";
                                labelMessageUserGrp.Text = msg;
                                return;
                            }

                            else
                            {
                                hdIsDelete.Value = "true";
                                hdIsEdit.Value = "true";
                                receiverTransfer.DeleteUserGrp(Convert.ToInt64(txtUsergrpID.Text));
                                labelMessageUserGrp.Text = "Data successfully deleted...";
                                labelMessageUserGrp.ForeColor = System.Drawing.Color.Green;

                            }
                        }
                        LoadUserGrp();
                        ClearField();
                    }
                    catch (Exception ex)
                    {
                        labelMessageUserGrp.Text = "Error : " + ex.Message;
                        labelMessageUserGrp.ForeColor = System.Drawing.Color.Red;
                    }
                }

        
    }
}