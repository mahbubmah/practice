using OH.BLL.Basic;
using OH.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OH.Web.ControlAdmin
{
    public partial class ModelWF : System.Web.UI.Page
    {
        private const string sessModel = "seModel";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    LoadModelListView();
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
        #region Private Methods
        private void LoadModelListView()
        {
            try
            {
                using (ModelRT receiverTransfer = new ModelRT())
                {
                    lvModel.DataSource = receiverTransfer.GetAllModelForListView();
                    lvModel.DataBind();
                }

            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }            
        }

        private Model CreateModel()
        {
            Session["UserID"] = 1;
            Model model = new Model();

            try
            {
                if (hdIsEdit.Value == "true")
                {
                    model.IID = Convert.ToInt32(hdModelID.Value.ToString());
                }
                model.BrandID = Convert.ToInt32(txtBrandID.Text);
                model.Name = txtModelName.Text;
                
                if (model.IID <= 0)
                {
                    model.CreatedBy = Convert.ToInt64(Session["UserID"]);
                    model.CreatedDate = GlobalRT.GetServerDateTime();
                }
                else
                {
                    Model mod = (Model)Session[sessModel];
                    model.CreatedBy = mod.CreatedBy; ;
                    model.CreatedDate = mod.CreatedDate;
                    model.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                    model.ModifiedDate = GlobalRT.GetServerDateTime();
                }
                if (hdIsDelete.Value != "true")
                {
                    model.IsRemoved = false;
                }
                else
                {
                    model.IsRemoved = true;
                    hdIsDelete.Value = "false";
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }

            return model;
        }

        private void FillModelForEdit(Model model)
        {
            try
            {
                if (model != null)
                {
                    BrandRT recTransfer = new BrandRT();
                    txtBrandID.Text = model.BrandID.ToString();
                    txtModelName.Text = model.Name;

                    txtBrandName.Text = Convert.ToString(recTransfer.GetBrandByID(Convert.ToInt64( model.BrandID)).Name);
                    Session[sessModel] = model;
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
            txtBrandName.Text = string.Empty;
            txtModelName.Text = string.Empty;
        }

        private void SetButton()
        {
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnCancel.Visible = false;
        }


        #endregion Private Methods

        #region Protected Events
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                labelMessage.Text = string.Empty;
                using (ModelRT receiverTransfer = new ModelRT())
                {
                    int brandID = int.Parse(txtBrandID.Text);

                    if (receiverTransfer.IsModelNameExists(txtModelName.Text, brandID))
                    {
                        labelMessage.Text = "Model Name " + txtModelName.Text + " Already Exists !";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    Model model = CreateModel();
                    receiverTransfer.AddModel(model);
                    if (model.IID > 0)
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
                LoadModelListView();
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
                using (ModelRT receiverTransfer = new ModelRT())
                {
                    hdIsEdit.Value = "true";
                    Model model = CreateModel();

                    if (model != null)
                    {

                        if (receiverTransfer.IsModelNameExistInOterRows(model.IID, model.Name, model.BrandID))
                        {
                            labelMessage.Text = "Model Name " + txtModelName.Text + " Already Exist !";
                            labelMessage.ForeColor = System.Drawing.Color.Red;
                            return;
                        }

                        receiverTransfer.UpdateModel(model);
                        labelMessage.Text = "Data successfully updated...";
                        labelMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        labelMessage.Text = "Data not updated...";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }
                ClearField();
                SetButton();
                LoadModelListView();
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
                using (ModelRT receiverTransfer = new ModelRT())
                {
                    hdIsDelete.Value = "true";
                    hdIsEdit.Value = "true";
                    Model model = CreateModel();

                    if (model != null)
                    {
                        receiverTransfer.UpdateModel(model);
                        labelMessage.Text = "Data successfully deleted...";
                        labelMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        labelMessage.Text = "Data not deleted...";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }
                LoadModelListView();
                SetButton();
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
            labelMessage.Text = string.Empty;
            SetButton();
            ClearField();

        }
        protected void lvModel_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "EditModel")
            {
                try
                {
                    labelMessage.Text = string.Empty;
                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    btnCancel.Visible = true;
                    int modelID = Convert.ToInt32(e.CommandArgument);
                    hdModelID.Value = modelID.ToString();
                    using (ModelRT receiverTransfer = new ModelRT())
                    {
                        Model model = receiverTransfer.GetModelByID(modelID);
                        FillModelForEdit(model);
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
        protected void dataPagerModel_PreRender(object sender, EventArgs e)
        {

            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {  
                    LoadModelListView();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }

        }

        protected void lvModel_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }
    }
        #endregion Protected Events
}