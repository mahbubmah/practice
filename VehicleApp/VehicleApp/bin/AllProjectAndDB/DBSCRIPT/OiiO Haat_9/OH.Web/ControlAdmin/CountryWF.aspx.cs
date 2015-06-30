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
    public partial class CountryWF : System.Web.UI.Page
    {
        public const string sessDesignation = "sessCountry";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {

                    LoadCountry();
                    btnSave.Visible = true;
                    btnUpdate.Visible = false;
                    //btnDelete.Visible = false;
                    btnCancel.Visible = false;
                    chkIsRemoved.Visible = false;
                }
                catch (Exception ex)
                {
                    labelMessage.Text = "Error : " + ex.Message;
                    labelMessage.ForeColor = System.Drawing.Color.Red;
                }
            }

        }

        protected void dataPagerDesignation_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    LoadCountry();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void LoadCountry()
        {
            try
            {
                using (CountryRT receiverTransfer = new CountryRT())
                {
                    lvCountry.DataSource = receiverTransfer.GetAllCountryForListView(); ;
                    lvCountry.DataBind();
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
                using (CountryRT receiverTransfer = new CountryRT())
                {
                    //List<Country> countryList = new List<Country>(); // Comment By Hasan
                    //countryList = receiverTransfer.GetCountryName(txtName.Text);
                    //if (countryList != null && countryList.Count > 0)
                    if(receiverTransfer.IsCountryCodeExists(txtCode.Text) && (receiverTransfer.IsCountryNameExists(txtName.Text)))
                    {
                        labelMessage.Text = "Country Code " + txtCode.Text + " & Name " + txtName.Text + " Already Exists!";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    else if(receiverTransfer.IsCountryCodeExists(txtCode.Text))
                    {
                        labelMessage.Text= "Country Code  " + txtCode.Text + " Already Exists!";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    else if(receiverTransfer.IsCountryNameExists(txtName.Text))
                    {
                        labelMessage.Text = "Country Name  " + txtName.Text + " Already Exists!";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    Country country = CreateCountry();
                    receiverTransfer.AddCountry(country);
                    if (country.IID > 0)
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
                LoadCountry();
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private Country CreateCountry()
        {
            Session["UserID"] = "1";
            Country country = new Country();
            try
            {
                if (hdIsEdit.Value == "true")
                {
                    country.IID = Convert.ToInt32(hdCountryID.Value.ToString());
                }
                country.Name = txtName.Text.Trim();
                country.Code = txtCode.Text.Trim();
                country.IsRemoved = chkIsRemoved.Checked;
                if (country.IID <= 0)
                {
                    country.CreatedBy = Convert.ToInt64(Session["UserID"]);
                    country.CreatedDate = GlobalRT.GetServerDateTime();
                }
                else
                {
                    Country cont = (Country)Session[sessDesignation];
                    country.CreatedBy = cont.CreatedBy; ;
                    country.CreatedDate = cont.CreatedDate;
                    country.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                    country.ModifiedDate = GlobalRT.GetServerDateTime();
                }
                //if (hdIsDelete.Value != "true")
                //{
                //    country.IsRemoved = false;
                //}
                //else
                //{
                //    country.IsRemoved = true;
                //}
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return country;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                labelMessage.Text = string.Empty;
                using (CountryRT receiverTransfer = new CountryRT())
                {
                    hdIsEdit.Value = "true";
                    //hdIsDelete.Value = "false";
                    Country country = CreateCountry();
                    DivisionOrStateRT divOrStateRT = new DivisionOrStateRT();

                    if (country != null)
                    {

                        if (receiverTransfer.IsCountryCodeExistOtherRows(country.IID, country.Code) && receiverTransfer.IsCountryCodeExistOtherRows(country.IID, country.Name))
                        {
                            labelMessage.Text = "Country Code " + txtCode.Text + " & Name " + txtName.Text + " Already Exists!";
                            labelMessage.ForeColor = System.Drawing.Color.Red;
                            return;
                        }
                        if (receiverTransfer.IsCountryCodeExistOtherRows(country.IID ,country.Code))
                        {
                            labelMessage.Text = "Country Code  " + txtCode.Text + " Already Exists!";
                            labelMessage.ForeColor = System.Drawing.Color.Red;
                            return;
                        }

                        else if (receiverTransfer.IsCountryNameExistOtherRows(country.IID, country.Name))
                        {
                            labelMessage.Text = "Country Name  " + txtName.Text + " Already Exists!";
                            labelMessage.ForeColor = System.Drawing.Color.Red;
                            return;
                        }

                        if(chkIsRemoved.Checked==true)
                        {
                            if (divOrStateRT.IsDivisionOrStateExistsInCountry(country.IID))
                            {
                                labelMessage.Text = "DivisionOrState Already exist for This Country";
                                labelMessage.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                receiverTransfer.UpdateCountry(country);
                                labelMessage.Text = "Data successfully updated...";
                                labelMessage.ForeColor = System.Drawing.Color.Green;
                            }
                        }

                        else
                        {
                            receiverTransfer.UpdateCountry(country);
                            labelMessage.Text = "Data successfully updated...";
                            labelMessage.ForeColor = System.Drawing.Color.Green;
                        }
                    }
                    else
                    {
                        labelMessage.Text = "Data not updated...";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }
                ClearField();
                DoHideButtons();
                btnSave.Visible = true;
                chkIsRemoved.Visible = false;
                LoadCountry();
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void DoHideButtons()
        {
            btnUpdate.Visible = false;
            //btnDelete.Visible = false;
            btnCancel.Visible = false;
        }

        private void ClearField()
        {
            txtCode.Text = string.Empty;
            txtName.Text = string.Empty;
            chkIsRemoved.Checked = false;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                labelMessage.Text = string.Empty;
                using (CountryRT receiverTransfer = new CountryRT())
                {
                    hdIsDelete.Value = "true";
                    hdIsEdit.Value = "true";
                    Country country = CreateCountry();

                    if (country != null)
                    {
                        DivisionOrStateRT divOrStateRT = new DivisionOrStateRT();
                        //if(divOrStateRT.IsDivisionOrStateExistsInCountry(country.IID))
                        //{
                        //    labelMessage.Text = "DivisionOrState Already Exist For This Country";
                        //    labelMessage.ForeColor = System.Drawing.Color.Red;
                        //}
                        //else
                        //{
                            receiverTransfer.UpdateCountry(country);
                            labelMessage.Text = "Data successfully deleted...";
                            labelMessage.ForeColor = System.Drawing.Color.Green;
                        //}
                    }
                    else
                    {
                        labelMessage.Text = "Data not deleted...";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }
                LoadCountry();
                ClearField();
                SetButton();
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            SetButton();
            ClearField();
            labelMessage.Text = string.Empty;
            chkIsRemoved.Visible = false;
        }

        private void SetButton()
        {
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            //btnDelete.Visible = false;
            btnCancel.Visible = false;
            
        }
        //For Edit Country
        protected void lvCountry_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "EditCountry")
            {
                try
                {
                    labelMessage.Text = string.Empty;
                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    //btnDelete.Visible = true;
                    btnCancel.Visible = true;
                    chkIsRemoved.Visible = true;
                    int countryID = Convert.ToInt32(e.CommandArgument);
                    hdCountryID.Value = countryID.ToString();
                    using (CountryRT receiverTransfer = new CountryRT())
                    {
                        Country country = receiverTransfer.GetCountryByIID(countryID);
                        FillCountryForEdit(country);
                    }
                }
                catch (Exception ex)
                {
                    labelMessage.Text = "Error : " + ex.Message;
                    labelMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        private void FillCountryForEdit(Country country)
        {
            try
            {
                if (country != null)
                {
                    txtCode.Text = country.Code.ToString();
                    txtName.Text = country.Name;
                    chkIsRemoved.Checked = country.IsRemoved;
                    Session[sessDesignation] = country;
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
        protected void dataPagerCountry_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    LoadCountry();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lvCountry_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            labelMessage.Text = string.Empty;
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

    }

}


