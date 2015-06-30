using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OH.BLL.Basic;
using OH.DAL;
using OH.Utilities;
using OH.Report;
using OH.Report.ReportForm;
using OH.Report.ReportData;
namespace OH.Web.ControlAdmin
{
    public partial class DistrictWF : System.Web.UI.Page
    {
        private const string sessDistrict = "seDistrict";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    //LoadDropDownCountry(null);
                    //LoadDivisionOrState(null);                 
                    LoadDistrictListView();
                    chkIsRemovedDistrict.Visible = false;
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

        //private void LoadDivisionOrState(int? divisionOrStateID)
        //{
        //    try
        //    {
        //        using (DivisionOrStateRT receverTransfer = new DivisionOrStateRT())
        //        {
        //            List<DivisionOrState> divisionOrStateList = new List<DivisionOrState>();
        //            if (divisionOrStateID != null)
        //            {
        //                divisionOrStateList.Add(receverTransfer.GetDivisionOrStateByID((int)divisionOrStateID));
        //            }
        //            else
        //            {
        //                divisionOrStateList = receverTransfer.GetDivisionOrStateAll();
        //            }
        //            DropDownListHelper.Bind<DivisionOrState>(ddlDivisionOrState, divisionOrStateList, "Name", "IID", EnumCollection.ListItemType.State);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex);
        //    }

        //}

        //private void LoadDropDownCountry(int? countryID)
        //{
        //    try
        //    {
        //        using (CountryRT receverTransfer = new CountryRT())
        //        {
        //            List<Country> countryList = new List<Country>();
        //            if (countryID != null)
        //            {
        //                countryList.Add(receverTransfer.GetCountryByIID((int)countryID));
        //            }
        //            else
        //            {
        //                countryList = receverTransfer.GetCountryAll();
        //            }
        //            DropDownListHelper.Bind<Country>(dropDownApplicableCountry, countryList, "Name", "IID", EnumCollection.ListItemType.Country);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex);
        //    }
        //}

        private void ClearField()
        {
            txtName.Text = string.Empty;
            txtCode.Text = string.Empty;
            txtCountryName.Text = string.Empty;
            txtDivisionOrStateName.Text = string.Empty;
            //labelMessage.Text = string.Empty;
        }

        protected void lvDistrict_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "EditDistrict")
            {
                try
                {
                    labelMessage.Text = string.Empty;
                    chkIsRemovedDistrict.Visible = true;
                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    btnDelete.Visible = false;
                    btnCancel.Visible = true;
                    int districtID = Convert.ToInt32(e.CommandArgument);
                    hdDistrictID.Value = districtID.ToString();
                    using (DistrictRT receiverTransfer = new DistrictRT())
                    {
                        District district = receiverTransfer.GetDistrictByID(districtID);
                        FillDistictForEdit(district);
                    }
                }
                catch (Exception ex)
                {
                    labelMessage.Text = "Error : " + ex.Message;
                    labelMessage.ForeColor = System.Drawing.Color.Red;
                }
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
                    txtDivisionOrStateID.Text=Convert.ToString( district.DivisionOrStateID);
                    txtCountryName.Text =new CountryRT().GetCountryByIID(district.CountryID).Name;
                    txtCountryID.Text = district.CountryID.ToString();
                    txtDivisionOrStateName.Text = new DivisionOrStateRT().GetDivisionOrStateByID(district.DivisionOrStateID).Name;
                    chkIsRemovedDistrict.Checked = district.IsRemoved;
                

                    //dropDownApplicableCountry.SelectedValue = district.CountryID.ToString();
                    //ddlDivisionOrState.SelectedValue = district.DivisionOrStateID.ToString();
                    Session[sessDistrict] = district;
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {   
                labelMessage.Text = string.Empty;
                int divOrStateID = Convert.ToInt32(txtDivisionOrStateID.Text);
                //int contryID = Convert.ToInt32(txtCountryID.Text);
                using (DistrictRT receiverTransfer = new DistrictRT())
                {
                    //List<District> districtList = new List<District>(); // Comment by Hasan 2015.02.16
                    //districtList = receiverTransfer.GetDistrictByName(txtName.Text);
                    //if (districtList != null && districtList.Count > 0)

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
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                labelMessage.Text = string.Empty;
                using (DistrictRT receiverTransfer = new DistrictRT())
                {
                    hdIsEdit.Value = "true";
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
                        
                        if(chkIsRemovedDistrict.Checked==true)
                        {
                            if (policeStationRT.IsPoliceStationExistsInDistrict(Convert.ToInt32(district.IID)))
                            {
                                labelMessage.Text = " Police Station Already Exist for this District !";
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
                SetButton();
                chkIsRemovedDistrict.Visible = false;

                LoadDistrictListView();
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
                // labelMessage.Text = string.Empty;
                using (DistrictRT receiverTransfer = new DistrictRT())
                {
                    hdIsDelete.Value = "true";
                    hdIsEdit.Value = "true";
                    District district = CreateDistrict();

                    if (district != null)
                    {
                        PoliceStationRT policeStationRT = new PoliceStationRT();
                        if( policeStationRT.IsPoliceStationExistsInDistrict(Convert.ToInt32 (district.IID)))
                        {
                            labelMessage.Text=" Police Station Already Exist for this Country !";
                            labelMessage.ForeColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            receiverTransfer.UpdateDistict(district);
                            labelMessage.Text = "Data successfully deleted...";
                            labelMessage.ForeColor = System.Drawing.Color.Green;
                        }         
                    }
                    else
                    {
                        labelMessage.Text = "Data not deleted...";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }
                LoadDistrictListView();
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
            chkIsRemovedDistrict.Visible = false;
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                List<District> districtList = new DistrictRT().GetAllDistrict();
                UserPostDS ds = new UserPostDS();
                Conversion.ToDataSet(districtList, ds, "DistrictDS");
                DistrictInfoRpt districtInfoRpt = new DistrictInfoRpt();
                districtInfoRpt.SetDataSource(ds);
                Session["reportForm"] = districtInfoRpt;
                ClientScript.RegisterStartupScript(GetType(), "openwindow", "<script type=text/javascript> window.open('ShowReport.aspx'); </script>");
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }
        private District CreateDistrict()
        {
            Session["UserID"] = "1";
            District district = new District();
            try
            {
                if (hdIsEdit.Value == "true")
                {
                    district.IID = Convert.ToInt32(hdDistrictID.Value.ToString());
                }
                district.Name = txtName.Text.Trim();
                district.Code = txtCode.Text.Trim();
                //district.DivisionOrStateID = int.Parse(ddlDivisionOrState.SelectedValue);
                district.DivisionOrStateID = int.Parse(txtDivisionOrStateID.Text);
                //district.CountryID = Convert.ToInt32(dropDownApplicableCountry.SelectedValue);
                district.CountryID = int.Parse(txtCountryID.Text);
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
                //if (hdIsDelete.Value != "true")
                //{
                //    district.IsRemoved = false;
                //}
                //else
                //{
                //    district.IsRemoved = true;
                //}
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return district;
        }
       
        private void SetButton()
        {
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnCancel.Visible=false;
        }
       
        //protected void dropDownApplicableCountry_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    try
        //    {
        //        int countryID = Convert.ToInt32(dropDownApplicableCountry.SelectedValue);
        //        LoadDivisionOrStateForCountry(countryID);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex);
        //    }
        //}

        //private void LoadDivisionOrStateForCountry(int countryID)
        //{
        //    try
        //    {
        //        using (DivisionOrStateRT receverTransfer = new DivisionOrStateRT())
        //        {
        //            List<DivisionOrState> divisionOrStateList = new List<DivisionOrState>();
        //            if (countryID != null)
        //            {
        //                divisionOrStateList = receverTransfer.GetDistrictOrStateForCountryID(countryID);
        //            }
        //            else
        //            {
        //                divisionOrStateList = receverTransfer.GetDivisionOrStateAll();
        //            }
        //            DropDownListHelper.Bind<DivisionOrState>(ddlDivisionOrState, divisionOrStateList, "Name", "IID", EnumCollection.ListItemType.State);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex);
        //    }

        //}


    }
}