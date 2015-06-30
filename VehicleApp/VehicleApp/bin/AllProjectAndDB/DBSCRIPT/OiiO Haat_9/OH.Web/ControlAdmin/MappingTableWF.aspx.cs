using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OH.BLL.Basic;
using OH.DAL;
using OH.Utilities;
namespace OH.Web.ControlAdmin
{
    public partial class MappingTableWF : System.Web.UI.Page
    {
        public const string sessMapping = "sessMapping";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {

                    LoadMappingTable();
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

        protected void dataPagerMapping_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    LoadMappingTable();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void LoadMappingTable()
        {
            try
            {
                using (MappingTableRT receiverTransfer = new MappingTableRT())
                {
                    lvMapping.DataSource = receiverTransfer.GetAllMappingTableForListView(); ;
                    lvMapping.DataBind();
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
                using (MappingTableRT receiverTransfer = new MappingTableRT())
                {
                    //List<Mapping> MappingList = new List<Mapping>(); // Comment By Hasan
                    //MappingList = receiverTransfer.GetMappingName(txtName.Text);
                    //if (MappingList != null && MappingList.Count > 0)
                    if (receiverTransfer.IsMappingTableCodeExists(txtMappingName.Text) && (receiverTransfer.IsMappingTableNameExists(txtMappingName.Text)))
                    {
                        labelMessage.Text = "Mapping  " + txtMappingName.Text + " Already Exists!";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    //else if (receiverTransfer.IsMappingTableNameExists(txtMappingName.Text))
                    //{
                    //    labelMessage.Text = "Mapping   " + txtMappingName.Text + " Already Exists!";
                    //    labelMessage.ForeColor = System.Drawing.Color.Red;
                    //    return;
                    //}
                    //else if (receiverTransfer.IsMappingTableNameExists(txtMappingName.Text))
                    //{
                    //    labelMessage.Text = "Mapping Name  " + txtMappingName.Text + " Already Exists!";
                    //    labelMessage.ForeColor = System.Drawing.Color.Red;
                    //    return;
                    //}

                    MappingTable mapping = CreateMappingTable();
                    receiverTransfer.AddMappingTable(mapping);
                    if (mapping.IID > 0)
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
                LoadMappingTable();
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private MappingTable CreateMappingTable()
        {
            Session["UserID"] = "1";
            MappingTable mapping = new MappingTable();
            try
            {
                if (hdIsEdit.Value == "true")
                {
                    mapping.IID = Convert.ToInt32(hdMappingID.Value.ToString());
                }
                mapping.Name = txtMappingName.Text.Trim();
                mapping.Description = txtMappingDescription.Text.Trim();
                if (mapping.IID <= 0)
                {
                    mapping.CreatedBy = Convert.ToInt64(Session["UserID"]);
                    mapping.CreatedDate = GlobalRT.GetServerDateTime();
                }
                else
                {
                    MappingTable cont = (MappingTable)Session[sessMapping];
                    mapping.CreatedBy = cont.CreatedBy; ;
                    mapping.CreatedDate = cont.CreatedDate;
                    mapping.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                    mapping.ModifiedDate = GlobalRT.GetServerDateTime();
                }
                if (hdIsDelete.Value != "true")
                {
                    mapping.IsRemoved = false;
                }
                else
                {
                    mapping.IsRemoved = true;
                    hdIsDelete.Value = "false";
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return mapping;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                labelMessage.Text = string.Empty;
                using (MappingTableRT receiverTransfer = new MappingTableRT())
                {
                    hdIsEdit.Value = "true";
                    MappingTable mapping = CreateMappingTable();

                    if (mapping != null)
                    {

                    //    if (receiverTransfer.IsMappingTableNameExistOtherRows(mapping.IID, mapping.Name) && receiverTransfer.IsMappingNameExistOtherRows(mapping.IID, mapping.Name))
                    //    {
                    //        labelMessage.Text = "Mapping Code " + txtCode.Text + " & Name " + txtName.Text + " Already Exists!";
                    //        labelMessage.ForeColor = System.Drawing.Color.Red;
                    //        return;
                    //    }
                    //    if (receiverTransfer.IsMappingCodeExistOtherRows(mapping.IID, mapping.Code))
                    //    {
                    //        labelMessage.Text = "Mapping Code  " + txtCode.Text + " Already Exists!";
                    //        labelMessage.ForeColor = System.Drawing.Color.Red;
                    //        return;
                    //    }

                    //    else if (receiverTransfer.IsMappingNameExistOtherRows(mapping.IID, mapping.Name))
                    //    {
                    //        labelMessage.Text = "Mapping Name  " + txtName.Text + " Already Exists!";
                    //        labelMessage.ForeColor = System.Drawing.Color.Red;
                    //        return;
                    //    }
                        //else
                        //{
                        receiverTransfer.UpdateMappingTable(mapping);
                        labelMessage.Text = "Data successfully updated...";
                        labelMessage.ForeColor = System.Drawing.Color.Green;
                        //}
                    }
                    else
                    {
                        labelMessage.Text = "Data not updated...";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }
                ClearField();
                SetButton();
                btnSave.Visible = true;
                LoadMappingTable();
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void ClearField()
        {
            txtMappingName.Text = string.Empty;
            txtMappingDescription.Text = string.Empty;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                labelMessage.Text = string.Empty;
                using (MappingTableRT receiverTransfer = new MappingTableRT())
                {
                    hdIsDelete.Value = "true";
                    hdIsEdit.Value = "true";
                    MappingTable mapping = CreateMappingTable();

                    if (mapping != null)
                    {
                        receiverTransfer.UpdateMappingTable(mapping);
                        labelMessage.Text = "Data successfully deleted...";
                        labelMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        labelMessage.Text = "Data not deleted...";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }
                LoadMappingTable();
                ClearField();
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            SetButton();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            SetButton();
            ClearField();
        }

        private void SetButton()
        {
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnCancel.Visible = false;

        }
        //For Edit Mapping
        protected void lvMapping_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "EditMapping")
            {
                try
                {
                    labelMessage.Text = string.Empty;
                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    btnCancel.Visible = true;
                    int mappingID = Convert.ToInt32(e.CommandArgument);
                    hdMappingID.Value = mappingID.ToString();
                    using (MappingTableRT receiverTransfer = new MappingTableRT())
                    {
                        MappingTable mapping = receiverTransfer.GetMappingByIID(mappingID);
                        FillMappingTableForEdit(mapping);
                    }
                }
                catch (Exception ex)
                {
                    labelMessage.Text = "Error : " + ex.Message;
                    labelMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        private void FillMappingTableForEdit(MappingTable mapping)
        {
            try
            {
                if (mapping != null)
                {
                    txtMappingName.Text = mapping.Name.ToString();
                    txtMappingDescription.Text = mapping.Description;
                    Session[sessMapping] = mapping;
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }

        }


        int lvRowCount = 0;
        int currentPage = 0;
        protected void dataPagerMappingTable_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    LoadMappingTable();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lvMapping_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

    }

}


