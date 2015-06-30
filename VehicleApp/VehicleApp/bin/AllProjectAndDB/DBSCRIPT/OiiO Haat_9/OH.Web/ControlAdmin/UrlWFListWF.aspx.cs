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
	public partial class UrlWFListWF : System.Web.UI.Page
	{
        private const string sessUrlWFList = "seUrlWFList";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    LoadDropDownModule();
                    LoadUrlWFList();
                    showSaveBtn();
                }
                catch (Exception ex)
                {
                    labelMessage.Text = "Error : " + ex.Message;
                    labelMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        private void LoadDropDownModule()
        {
            try
            {

                dropDownModuleName.Items.Add("--Select Module Name--");
                DropDownListHelper.Bind(dropDownModuleName, EnumHelper.EnumToList<EnumCollection.ModuleList>());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        

        protected void FillUrlWFForEdit(UrlWFList urlWFList)
        {
            try
            {
                if (urlWFList != null)
                {
                    txtUrlWFName.Text = urlWFList.UrlWFName;
                    txtUrlWFDisplayName.Text = urlWFList.UrlWFDisplayName;

                    txtModuleSerialNo.Text = urlWFList.ModuleSerialNo.ToString();
                    txtUrlWFSerialNo.Text = urlWFList.UrlWFSerialNo.ToString();

                    EnumCollection.ModuleList moduleListEnum = (EnumCollection.ModuleList)Enum.Parse(typeof(EnumCollection.ModuleList), urlWFList.ModuleName);
                    dropDownModuleName.SelectedValue = ((int)moduleListEnum).ToString();

                    Session[sessUrlWFList] = urlWFList;
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private UrlWFList CreateUrlList()
        {
            //Session["UserID"] = "1";
            UrlWFList urlWFList = new UrlWFList();
            try
            {
                if (hdIsEdit.Value == "true")
                {
                    urlWFList.IID = Convert.ToInt32(hdUrlListID.Value.ToString());
                }
                urlWFList.UrlWFName = txtUrlWFName.Text.Trim();
                urlWFList.UrlWFDisplayName = txtUrlWFDisplayName.Text.Trim();
                urlWFList.ModuleName = dropDownModuleName.SelectedItem.ToString();
                urlWFList.UrlWFSerialNo = Convert.ToInt32(txtUrlWFSerialNo.Text.Trim());
                urlWFList.ModuleSerialNo = Convert.ToInt32(txtModuleSerialNo.Text.Trim());
                if (urlWFList.IID <= 0)
                {
                    urlWFList.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    urlWFList.CreatedDate = GlobalRT.GetServerDateTime();
                }
                else
                {
                    UrlWFList url = (UrlWFList)Session[sessUrlWFList];
                    urlWFList.CreatedBy = url.CreatedBy;
                    urlWFList.CreatedDate = url.CreatedDate;
                    urlWFList.ModifiedBy = url.ModifiedBy;
                    urlWFList.ModifiedDate = url.ModifiedDate;
                }

            }
            catch (Exception e)
            {
                labelMessage.Text = "Error: " + e.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return urlWFList;
        }
        private void visiblefield()
        {

            btnSave.Visible = true;
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
        }
        private void ClearField()
        {
            txtUrlWFName.Text = string.Empty;
            txtUrlWFDisplayName.Text = string.Empty;
            dropDownModuleName.SelectedValue = null;
            //LoadDropDownModule(null);
            txtModuleSerialNo.Text = string.Empty;
            txtUrlWFSerialNo.Text = string.Empty;
        }

        private void LoadUrlWFList()
        {
            UrlWFListRT reciveTransfer = new UrlWFListRT();
            lvUrlWFList.DataSource = reciveTransfer.GetUrlWFListAllForListView();
            lvUrlWFList.DataBind();
        }


       
        protected void lvUrlWFList_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            labelMessage.Text = "...";
            labelMessage.ForeColor = System.Drawing.Color.Green;
            if (e.CommandName == "EditUrlWFList")
            {
                try
                {
                    btnSave.Visible = false;
                    btnCancel.Visible = true;
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    int urlListID = Convert.ToInt32(e.CommandArgument);
                    hdUrlListID.Value = urlListID.ToString();
                    using (UrlWFListRT receiverTransfer = new UrlWFListRT())
                    {
                        UrlWFList urlWFList = receiverTransfer.GetUrlWFListByID(urlListID);
                        FillUrlWFForEdit(urlWFList);
                    }
                }
                catch (Exception ex)
                {
                    labelMessage.Text = "Error : " + ex.Message;
                    labelMessage.ForeColor = System.Drawing.Color.Red;
                }
            }

        }
        int lvRowCount = 0;
        int currentPage = 0;
        protected void lvUrlWFList_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void dataPagerUrlWFList_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    LoadUrlWFList();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        //save department
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (UrlWFListRT receiveTransfer = new UrlWFListRT())
                {
                    List<UrlWFList> urlListList = new List<UrlWFList>();
                    urlListList = receiveTransfer.GetUrlWFListByNmae(txtUrlWFName.Text.Trim());
                    if (urlListList != null && urlListList.Count() > 0)
                    {
                        string msg = "...Url List already exist...";
                        labelMessage.Text = msg;
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                        ClearField();
                        return;
                    }

                    UrlWFList urlList = CreateUrlList();
                    receiveTransfer.AddUrlWFList(urlList);

                    if (urlList.IID > 0)
                    {
                        labelMessage.Text = "Url List Successffuly Inserted";
                        labelMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        labelMessage.Text = "Url did not Inserted";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                    }

                }
                ClearField();
                LoadUrlWFList();
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
                hdIsDelete.Value = "true";
                hdIsEdit.Value = "true";
                labelMessage.Text = string.Empty;
                using (UrlWFListRT reciveTransfer = new UrlWFListRT())
                {
                    UrlWFList urlWFList = CreateUrlList();
                    List<UserWFPermission> checkIDList = new List<UserWFPermission>();
                    checkIDList = reciveTransfer.checkUrlListByID(urlWFList.IID);
                    if (checkIDList.Count() > 0)
                    {
                        labelMessage.Text = "Url List " + txtUrlWFName + " Used in UserPermission";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        reciveTransfer.DeleteUrl(urlWFList.IID);
                        labelMessage.Text = "Successfully Deleted!";
                        labelMessage.ForeColor = System.Drawing.Color.Green;
                        showSaveBtn();
                    }

                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            LoadUrlWFList();
            ClearField();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

            labelMessage.Text = "...";
            labelMessage.ForeColor = System.Drawing.Color.Green;
            showSaveBtn();
            ClearField();


        }
        protected void showSaveBtn()
        {
            btnSave.Visible = true;
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnCancel.Visible = true;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            using (UrlWFListRT receiveTransfer = new UrlWFListRT())
            {
                hdIsEdit.Value = "true";
                 UrlWFList urlWFList = CreateUrlList();
                    List<UserWFPermission> checkIDList = new List<UserWFPermission>();
                    checkIDList = receiveTransfer.checkUrlListByID(urlWFList.IID);
                    //if (checkIDList.Count() > 0)
                    //{
                    //    labelMessage.Text = "Url List " + txtUrlWFName + " Used in UserPermission";
                    //    labelMessage.ForeColor = System.Drawing.Color.Red;
                    //    return;
                    //}
                
                
                if (urlWFList != null)
                {
                    receiveTransfer.UpdateUrlWFList(urlWFList);
                    labelMessage.Text = "Data successfully updated...";
                    labelMessage.ForeColor = System.Drawing.Color.Green;
                    showSaveBtn();
                }
                else
                {
                    labelMessage.Text = "Data not updated...";
                    labelMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            ClearField();
            LoadUrlWFList();

        }


        protected void dropDownModuleName_SelectedIndexChanged1(object sender, EventArgs e)
        {
            try
            {


                if (dropDownModuleName.SelectedIndex > 0)
                {
                    txtModuleSerialNo.Text = dropDownModuleName.SelectedValue;
                }
                else
                    txtModuleSerialNo.Text = string.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

      


    }

}


