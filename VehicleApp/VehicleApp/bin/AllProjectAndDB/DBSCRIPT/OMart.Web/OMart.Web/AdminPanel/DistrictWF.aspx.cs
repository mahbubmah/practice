using BLL.Basic;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
namespace OMart.Web.ControlAdmin
{
    public partial class DistrictWF : System.Web.UI.Page
    {
        private const string sessDistrict = "seDistrict";
        int lvRowCount = 0;
        int currentPage = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    LoadDropDownCountry(null);
                    LoadDivisionOrState(null);                 
                    LoadDistrictListView();
                    chkIsRemovedDistrict.Visible = false;
                    //btnCancel.Visible = false;
                }
                catch (Exception ex)
                {
                    labelMessage.Text = "Error : " + ex.Message;
                    labelMessage.ForeColor = System.Drawing.Color.Red;
                }
            }

        }
        #region private Methods
        private void LoadDistrictListView()
        {
            try
            {
                using (DistrictRT receiverTransfer = new DistrictRT())
                {
                    lvDistrict.DataSource = receiverTransfer.GetAllDistrictForListView(); ;
                    lvDistrict.DataBind();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void LoadDivisionOrState(int? divisionOrStateID)
        {
            try
            {
                using (DivisionOrStateRT receverTransfer = new DivisionOrStateRT())
                {
                    List<DivisionOrState> divisionOrStateList = new List<DivisionOrState>();
                    if (divisionOrStateID != null)
                    {
                        divisionOrStateList.Add(receverTransfer.GetDivisionOrStateByID((int)divisionOrStateID));
                    }
                    else
                    {
                        divisionOrStateList = receverTransfer.GetDivisionOrStateAll();
                    }
                    DropDownListHelper.Bind<DivisionOrState>(ddlDivisionOrState, divisionOrStateList, "Name", "IID", EnumCollection.ListItemType.State);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        private void LoadDropDownCountry(int? countryID)
        {
            try
            {
                using (CountryRT receverTransfer = new CountryRT())
                {
                    List<Country> countryList = new List<Country>();
                    if (countryID != null)
                    {
                        countryList.Add(receverTransfer.GetCountryByIID((int)countryID));
                    }
                    else
                    {
                        countryList = receverTransfer.GetAllCountries();
                    }
                    DropDownListHelper.Bind<Country>(ddlCountry, countryList, "Name", "IID", EnumCollection.ListItemType.Country);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        private void LoadDivisionOrStateForCountry(int countryID)
        {
            try
            {
                using (DivisionOrStateRT receverTransfer = new DivisionOrStateRT())
                {
                    List<DivisionOrState> divisionOrStateList = new List<DivisionOrState>();
                    if (countryID != null)
                    {
                        divisionOrStateList = receverTransfer.GetDistrictOrStateForCountryID(countryID);
                    }
                    else
                    {
                        divisionOrStateList = receverTransfer.GetDivisionOrStateAll();
                        //DropDownListHelper.Bind<DivisionOrState>(ddlDivisionOrState, divisionOrStateList, "Name", "IID", EnumCollection.ListItemType.State);
                    }
                    //DropDownListHelper.Bind<DivisionOrState>(ddlDivisionOrState, divisionOrStateList, "Name", "IID");
                    DropDownListHelper.Bind<DivisionOrState>(ddlDivisionOrState, divisionOrStateList, "Name", "IID", EnumCollection.ListItemType.State);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        private District CreateDistrict()
        {
            Session["UserID"] = "1";
            District district = new District();
            try
            {
                if (btn_CreateOrEdit.Text == "Update")
                {
                    district.IID = Convert.ToInt32(hdDistrictID.Value.ToString());
                }
                district.Name = txtName.Text.Trim();
                district.Code = txtCode.Text.Trim();
                district.DivisionOrStateID = int.Parse(ddlDivisionOrState.SelectedValue);
                district.CountryID = Convert.ToInt32(ddlCountry.SelectedValue);
                district.IsRemoved = chkIsRemovedDistrict.Checked;
                if (district.IID <= 0)
                {
                    district.CreatedBy = Convert.ToInt64(Session["UserID"]);
                    district.CreatedDate = GlobalRT.GetServerDateTime();
                }
                else
                {
                    District dst = (District)Session[sessDistrict];
                    district.CreatedBy = dst.CreatedBy; ;
                    district.CreatedDate = dst.CreatedDate;
                    district.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                    district.ModifiedDate = GlobalRT.GetServerDateTime();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return district;
        }

        private void SaveDistrict()
        {
            try
            {
                labelMessage.Text = string.Empty;
                int contryID = Convert.ToInt32(ddlCountry.SelectedValue);
                int divOrStateID = Convert.ToInt32(ddlDivisionOrState.SelectedValue);
                using (DistrictRT receiverTransfer = new DistrictRT())
                {
                    if (receiverTransfer.IsDistrictCodeExists(txtCode.Text, divOrStateID) && receiverTransfer.IsDistrictNameExists(txtName.Text, divOrStateID))
                    {
                        labelMessage.Text = "District Code " + txtCode.Text + " & Name " + txtName.Text + " Already Exists!";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    else if (receiverTransfer.IsDistrictCodeExists(txtCode.Text))
                    {
                        labelMessage.Text = "District Code " + txtCode.Text + " Already Exists!";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    else if (receiverTransfer.IsDistrictCodeExists(txtCode.Text, divOrStateID))
                    {
                        labelMessage.Text = "District Code " + txtCode.Text + " Already Exists!";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    else if (receiverTransfer.IsDistrictNameExists(txtName.Text, divOrStateID))
                    {
                        labelMessage.Text = "District Name " + txtName.Text + " Already Exists!";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    District district = CreateDistrict();
                    receiverTransfer.AddDistrict(district);
                    if (district.IID > 0)
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
                LoadDistrictListView();
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void UpdateDistrict()
        {
            try
            {
                labelMessage.Text = string.Empty;
                using (DistrictRT receiverTransfer = new DistrictRT())
                {
                    District district = CreateDistrict();
                    PoliceStationRT policeStationRT = new PoliceStationRT();

                    if (district != null)
                    {
                        if (receiverTransfer.IsDistCodeExistInOtherRows(district.IID, district.Code, district.DivisionOrStateID) && receiverTransfer.IsDistCodeExistInOtherRows(district.IID, district.Code, district.DivisionOrStateID))
                        {
                            labelMessage.Text = "District Code " + txtCode.Text + " & Name " + txtName.Text + " Already Exists!";
                            labelMessage.ForeColor = System.Drawing.Color.Red;
                            return;
                        }
                        else if (receiverTransfer.IsDistCodeExistInOtherRows(district.IID, district.Code))
                        {
                            labelMessage.Text = "District Code " + txtCode.Text + " Already Exists!";
                            labelMessage.ForeColor = System.Drawing.Color.Red;
                            return;
                        }
                        else if (receiverTransfer.IsDistCodeExistInOtherRows(district.IID, district.Code, district.DivisionOrStateID))
                        {
                            labelMessage.Text = "District Code " + txtCode.Text + " Already Exists!";
                            labelMessage.ForeColor = System.Drawing.Color.Red;
                            return;
                        }
                        else if (receiverTransfer.IsDistNameExistInOtherRows(district.IID, district.Name, district.DivisionOrStateID))
                        {
                            labelMessage.Text = "District Name " + txtName.Text + " Already Exists!";
                            labelMessage.ForeColor = System.Drawing.Color.Red;
                            return;
                        }

                        if (chkIsRemovedDistrict.Checked == true)
                        {
                            if (policeStationRT.IsPoliceStationExistsInDistrict(Convert.ToInt32(district.IID)))
                            {
                                labelMessage.Text = " Police Station Already Exist for this Country !";
                                labelMessage.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                receiverTransfer.UpdateDistict(district);
                                labelMessage.Text = "Data successfully updated...";
                                labelMessage.ForeColor = System.Drawing.Color.Green;
                            }
                        }
                        else
                        {
                            receiverTransfer.UpdateDistict(district);
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
                btn_CreateOrEdit.Text = "Submit";
                chkIsRemovedDistrict.Visible = false;

                LoadDistrictListView();
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void FillDistictForEdit(District district)
        {
            try
            {
                if (district != null)
                {
                    txtName.Text = district.Name;
                    txtCode.Text = district.Code.ToString();
                    ddlCountry.SelectedValue = district.CountryID.ToString();
                    ddlDivisionOrState.SelectedValue = district.DivisionOrStateID.ToString();
                    chkIsRemovedDistrict.Checked = district.IsRemoved;

                    Session[sessDistrict] = district;
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
            txtName.Text = string.Empty;
            txtCode.Text = string.Empty;
            ddlCountry.SelectedIndex = -1 ;
            ddlDivisionOrState.SelectedIndex = -1;
        }
        #endregion private Methods


        #region Protected Events

        protected void btn_CreateOrEdit_Click(object sender, EventArgs e)
        {
            if (btn_CreateOrEdit.Text == "Submit")
            {
                SaveDistrict();
            }
            else if (btn_CreateOrEdit.Text == "Update")
            {
                UpdateDistrict();
            }
        }

        protected void lnkbEdit_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton linkButton = (LinkButton)sender;
                int districtID = Convert.ToInt32(linkButton.CommandArgument);
                using (DistrictRT receiverTransfer = new DistrictRT())
                {
                    District district = receiverTransfer.GetDistrictByID(districtID);
                    hdDistrictID.Value = districtID.ToString();
                    FillDistictForEdit(district);
                    btn_CreateOrEdit.Text = "Update";
                }
                chkIsRemovedDistrict.Visible = true;
                labelMessage.Text = string.Empty;
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void lnkbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DistrictRT districtRT = new DistrictRT();
                LinkButton linkButton = (LinkButton)sender;
                int districtID = Convert.ToInt32(linkButton.CommandArgument);
                var district = districtRT.GetDistrictByID(districtID);

                if (district != null)
                {
                    PoliceStationRT policeStationRT = new PoliceStationRT();

                    if (policeStationRT.IsPoliceStationExistsInDistrict(Convert.ToInt32(district.IID)))
                    {
                        labelMessage.Text = "Police Station Already Exist For This District";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                    }

                    else
                    {
                        district.IsRemoved = true;
                        District dis = (District)Session[sessDistrict];
                        district.CreatedBy = dis.CreatedBy; ;
                        district.CreatedDate = dis.CreatedDate;
                        district.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                        district.ModifiedDate = GlobalRT.GetServerDateTime();
                        districtRT.UpdateDistict(district);
                        labelMessage.Text = "Data successfully deleted...";
                        labelMessage.ForeColor = System.Drawing.Color.Green;
                    }
                }
                else
                {
                    labelMessage.Text = "Data not deleted...";
                    labelMessage.ForeColor = System.Drawing.Color.Red;
                }
                LoadDistrictListView();
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void dataPagerDistrict_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    LoadDistrictListView();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }

        }

        protected void lvDistrict_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            labelMessage.Text = string.Empty;
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            labelMessage.Text = string.Empty;
            btn_CreateOrEdit.Text = "Submit";
            ClearField();
            chkIsRemovedDistrict.Visible = false;
        }
        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int countryID = Convert.ToInt32(ddlCountry.SelectedValue);
                LoadDivisionOrStateForCountry(countryID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        #endregion Protected Events
    }
}