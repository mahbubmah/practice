using BLL.Basic;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;


namespace OMart.Web.AdminPanel
{
    public partial class UserPermissionWF : System.Web.UI.Page
    {
        private const string sessUserPermission = "seUserPermission";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    LoadDropDownUserGroup(null);
                    LoadDropDownUrlList(null);
                    LoadUserPermission();
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

        #region protected method
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                labelMessage.Text = string.Empty;
                using (UserPermissionRT receiverTransfer = new UserPermissionRT())
                {
                    List<UserWFPermission> UserWFPermission = new List<UserWFPermission>();
                    Int32 userGroupID = Convert.ToInt32(dropDownListGroupName.SelectedValue);
                    Int32 urlListID = Convert.ToInt32(dropDownListURLList.SelectedValue);
                    UserWFPermission = receiverTransfer.GetUserPermissionByGropIDAndUrlID(userGroupID, urlListID);
                    if (UserWFPermission != null && UserWFPermission.Count > 0)
                    {
                        string msg = "Group Name  " + dropDownListGroupName.SelectedItem + " And\n" + "Url Name " + dropDownListURLList.SelectedItem + " Already Exists!";
                        labelMessage.Text = msg;
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    UserWFPermission userPerission = CreateUserWFPermission();
                    receiverTransfer.AddUserPermission(userPerission);
                    if (userPerission.IID > 0)
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
                LoadUserPermission();
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dropDownListGroupName.SelectedIndex == 0 || dropDownListURLList.SelectedIndex == 0)
            {
                string msg = "Please select a Group Name and Url Name";
                labelMessage.Text = msg;
                labelMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else
            {
                try
                {
                    labelMessage.Text = string.Empty;
                    using (UserPermissionRT receiverTransfer = new UserPermissionRT())
                    {
                        hdIsEdit.Value = "true";

                        List<UserWFPermission> UserWFPermission = new List<UserWFPermission>();
                        Int32 userGroupID = Convert.ToInt32(dropDownListGroupName.SelectedValue);
                        Int32 urlListID = Convert.ToInt32(dropDownListURLList.SelectedValue);
                        UserWFPermission = receiverTransfer.GetUserPermissionByGropIDAndUrlID(userGroupID, urlListID);
                        if (UserWFPermission != null && UserWFPermission.Count > 0)
                        {
                            string msg = "Group Name  " + dropDownListGroupName.SelectedItem + " And\n" + "Url Name " + dropDownListURLList.SelectedItem + " Already Exists!";
                            labelMessage.Text = msg;
                            return;
                        }

                        UserWFPermission userPermission = CreateUserWFPermission();

                        if (userPermission != null)
                        {
                            receiverTransfer.UpdateUserPermisssion(userPermission);
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
                    ClearField();
                    LoadUserPermission();
                }
                catch (Exception ex)
                {
                    labelMessage.Text = "Error : " + ex.Message;
                    labelMessage.ForeColor = System.Drawing.Color.Red;

                }
            }

        }


        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }


        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearField();
            btnSave.Visible = true;
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
        }

        protected void lvUserPermission_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "EditUserPermission")
            {
                labelMessage.Text = string.Empty;
                try
                {
                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    btnDelete.Visible = false;
                    btnCancel.Visible = true;
                    int userPermissionID = Convert.ToInt32(e.CommandArgument);
                    hdUserPermissionID.Value = userPermissionID.ToString();
                    using (UserPermissionRT receiverTransfer = new UserPermissionRT())
                    {
                        UserWFPermission userPermission = receiverTransfer.GetUserPermissionByID(userPermissionID);
                        FillUserPermissionForEdit(userPermission);
                    }
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
        protected void lvUserPermission_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void dataPagerUserPermission_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    LoadUserPermission();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lvUserPermission_PreRender(object sender, EventArgs e)
        {

        }

        #endregion protected method



        #region  private method
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

        private void LoadDropDownUrlList(Int32? urlWFListID)
        {
            try
            {
                using (UrlWFListRT receverTransfer = new UrlWFListRT())
                {
                    List<UrlWFList> urlList = new List<UrlWFList>();
                    if (urlWFListID != null)
                    {
                        urlList.Add(receverTransfer.GetUrlWFListByID((Int32)urlWFListID));
                    }
                    else
                    {
                        urlList = receverTransfer.GetUrlWFListAll();
                    }
                    DropDownListHelper.Bind<DAL.UrlWFList>(dropDownListURLList, urlList, "ModuleName", "IID", EnumCollection.ListItemType.UrlList);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        private void LoadUserPermission()
        {
            try
            {
                using (UserPermissionRT receiverTransfer = new UserPermissionRT())
                {
                    lvUserPermission.DataSource = receiverTransfer.GetUserPermissionAllForListView(); ;
                    lvUserPermission.DataBind();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }


        }

        private void ClearField()
        {
            dropDownListGroupName.SelectedIndex = 0;
            dropDownListURLList.SelectedIndex = 0;
        }

        ////Create an User Permission

        private UserWFPermission CreateUserWFPermission()
        {
            Session["UserID"] = "1";
            UserWFPermission userWFPermission = new UserWFPermission();
            try
            {
                if (hdIsEdit.Value == "true")
                {
                    userWFPermission.IID = Convert.ToInt32(hdUserPermissionID.Value.ToString());
                }
                userWFPermission.UserGroupID = Convert.ToInt32(dropDownListGroupName.SelectedValue);
                userWFPermission.UrlWFListID = Convert.ToInt32(dropDownListURLList.SelectedValue);

                if (userWFPermission.IID <= 0)
                {
                    userWFPermission.CreatedBy = Convert.ToInt64(Session["UserID"]);
                    userWFPermission.CreatedDate = GlobalRT.GetServerDateTime();
                }
                else
                {
                    UserWFPermission userP = (UserWFPermission)Session[sessUserPermission];
                    userWFPermission.CreatedBy = userP.CreatedBy; ;
                    userWFPermission.CreatedDate = userP.CreatedDate;
                    userWFPermission.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                    userWFPermission.ModifiedDate = GlobalRT.GetServerDateTime();
                }

            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return userWFPermission;

        }

        private void FillUserPermissionForEdit(UserWFPermission userPermission)
        {
            try
            {
                if (userPermission != null)
                {
                    dropDownListGroupName.SelectedValue = userPermission.UserGroupID.ToString();
                    dropDownListURLList.SelectedValue = userPermission.UrlWFListID.ToString();
                    Session[sessUserPermission] = userPermission;
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