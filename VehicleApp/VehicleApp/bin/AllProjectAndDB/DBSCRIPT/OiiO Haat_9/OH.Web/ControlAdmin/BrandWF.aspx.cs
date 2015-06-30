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
    public partial class BrandWF : System.Web.UI.Page
    {
        #region Private Methods

        private const string sessBrand = "seBrand";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    LoadBrandListView();
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

        private void LoadBrandListView()
        {
            try
            {
                using (BrandRT receiverTransfer = new BrandRT())
                {
                    lvBrand.DataSource = receiverTransfer.GetBrandForListView();
                    lvBrand.DataBind();
                }

            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }              
        }

        private Brand CreateBrand()
        {
            Session["UserID"] = 1;
            Brand brand = new Brand();

            try
            {
                if (hdIsEdit.Value == "true")
                {
                    brand.IID = Convert.ToInt32(hdBrandID.Value.ToString());
                }
                brand.Name = txtBrandName.Text;
                brand.Origin = Convert.ToInt32(txtOriginID.Text);
                brand.EastblishYear =  Convert.ToInt32(txtEstablishYear.Text);
                
                if (brand.IID <= 0)
                {
                    brand.CreatedBy = Convert.ToInt64(Session["UserID"]);
                    brand.CreatedDate = GlobalRT.GetServerDateTime();
                }
                else
                {
                    Brand br = (Brand)Session[sessBrand];
                    brand.CreatedBy = br.CreatedBy; ;
                    brand.CreatedDate = br.CreatedDate;
                    brand.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                    brand.ModifiedDate = GlobalRT.GetServerDateTime();
                }
                if (hdIsDelete.Value != "true")
                {
                    brand.IsRemoved = false;
                }
                else
                {
                    brand.IsRemoved = true;
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }

            return brand;
        }

        private void FillBrandForEdit(Brand brand)
        {
            try
            {
                if (brand != null)
                {
                    CountryRT recTransfer = new CountryRT();
                    txtBrandName.Text = brand.Name;
                    txtOriginID.Text = brand.Origin.ToString();
                    txtEstablishYear.Text = brand.EastblishYear.ToString();

                    txtOriginName.Text = Convert.ToString(recTransfer.GetCountryByIID(Convert.ToInt32(brand.Origin)).Name);
                    Session[sessBrand] = brand;
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
            txtOriginName.Text = string.Empty;
            txtEstablishYear.Text = string.Empty;
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
                using (BrandRT receiverTransfer = new BrandRT())
                {
                    int originID = int.Parse(txtOriginID.Text);

                    if (receiverTransfer.IsBrandNameExists(txtBrandName.Text, originID))
                    {
                        labelMessage.Text = "Brand Name " + txtBrandName.Text + " Already Exists !";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    Brand brand = CreateBrand();
                    receiverTransfer.AddBrand(brand);
                    if (brand.IID > 0)
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
                LoadBrandListView();
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
                using (BrandRT receiverTransfer = new BrandRT())
                {
                    hdIsEdit.Value = "true";
                    Brand brand = CreateBrand();

                    if (brand != null)
                    {

                        if (receiverTransfer.IsBrandNameExistInOterRows(brand.IID, brand.Name, brand.Origin))
                        {
                            labelMessage.Text = "Brand Name " + txtBrandName.Text + " Already Exist!";
                            labelMessage.ForeColor = System.Drawing.Color.Red;
                            return;
                        }

                        receiverTransfer.UpdateBrand(brand);
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
                LoadBrandListView();
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
                using (BrandRT receiverTransfer = new BrandRT())
                {
                    hdIsDelete.Value = "true";
                    hdIsEdit.Value = "true";
                    Brand brand = CreateBrand();

                    if (brand != null)
                    {
                        receiverTransfer.UpdateBrand(brand);
                        labelMessage.Text = "Data successfully deleted...";
                        labelMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        labelMessage.Text = "Data not deleted...";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }
                LoadBrandListView();
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

        int lvRowCount = 0;
        int currentPage = 0;
        protected void dataPagerBrand_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    LoadBrandListView();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }

        }

        protected void lvBrand_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "EditBrand")
            {
                try
                {
                    labelMessage.Text = string.Empty;
                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    btnCancel.Visible = true;
                    long brandID = Convert.ToInt32(e.CommandArgument);
                    hdBrandID.Value = brandID.ToString();
                    using (BrandRT receiverTransfer = new BrandRT())
                    {
                        Brand brand = receiverTransfer.GetBrandByID(brandID);
                        FillBrandForEdit(brand);
                    }
                }
                catch (Exception ex)
                {
                    labelMessage.Text = "Error : " + ex.Message;
                    labelMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void lvBrand_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }
        #endregion Protected Events
    }
}