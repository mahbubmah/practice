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
    public partial class PoliceStationWF : System.Web.UI.Page
    {
        private const string sessPoliceStation = "sePoliceStation";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    LoadDropDownCountry(null);
                    LoadDropDownDivisionOrState(null);
                    LoadDropDownDistrict(null);
                    chkIsRemovedPoliceStation.Visible = false;
                    LoadPoliceStationListView();
                    //btnCancel.Visible = false;
                }
                catch (Exception ex)
                {
                    labelMessage.Text = "Error : " + ex.Message;
                    labelMessage.ForeColor = System.Drawing.Color.Red;
                }
            }

        }
        #region Private Methods
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

        private void LoadDropDownDivisionOrState(int? divisionOrStateID)
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
                    if(divisionOrStateID!=null)
                    {
                        ddlDivisionOrState.SelectedValue = divisionOrStateID.ToString();
                    }          
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private void LoadDropDownDistrict(int? districtID)
        {
            try
            {
                using (DistrictRT receverTransfer = new DistrictRT())
                {
                    List<District> districtList = new List<District>();
                    if (districtID != null)
                    {
                        districtList.Add(receverTransfer.GetDistrictByID((int)districtID));
                    }
                    else
                    {
                        districtList = receverTransfer.GetAllDistrict();
                    }
                    DropDownListHelper.Bind<District>(ddlDistrict, districtList, "Name", "IID", EnumCollection.ListItemType.District);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private void LoadPoliceStationListView()
        {
            try
            {
                using (PoliceStationRT receiverTransfer = new PoliceStationRT())
                {
                    lvPoliceStation.DataSource = receiverTransfer.GetAllPoliceStationForListView();
                    lvPoliceStation.DataBind();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
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
                    }
                    DropDownListHelper.Bind<DivisionOrState>(ddlDivisionOrState, divisionOrStateList, "Name", "IID", EnumCollection.ListItemType.State);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        private PoliceStation CreatePoliceStaion()
        {
            Session["UserID"] = "1";
            PoliceStation pStaion = new PoliceStation();
            try
            {
                if (btn_CreateOrEdit.Text == "Update")
                {
                    pStaion.IID = Convert.ToInt32(hdPoliceStationID.Value.ToString());
                }
                pStaion.Name = txtName.Text.Trim();
                pStaion.Code = txtCode.Text.Trim();

                pStaion.CountryID = int.Parse(ddlCountry.SelectedValue);
                pStaion.DivisionOrStateID = int.Parse(ddlDivisionOrState.SelectedValue);
                pStaion.DistrictID = int.Parse(ddlDistrict.SelectedValue);
                pStaion.IsRemoved = chkIsRemovedPoliceStation.Checked;

                if (pStaion.IID <= 0)
                {
                    pStaion.CreatedBy = Convert.ToInt64(Session["UserID"]);
                    pStaion.CreatedDate = GlobalRT.GetServerDateTime();
                }
                else
                {
                    PoliceStation policeStation = (PoliceStation)Session[sessPoliceStation];
                    pStaion.CreatedBy = policeStation.CreatedBy; ;
                    pStaion.CreatedDate = policeStation.CreatedDate;
                    pStaion.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                    pStaion.ModifiedDate = GlobalRT.GetServerDateTime();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return pStaion;
        }

        private void SavePoliceStation()
        {
            try
            {
                labelMessage.Text = string.Empty;
                int districtID = Convert.ToInt32(ddlDistrict.SelectedValue);

                using (PoliceStationRT receiverTransfer = new PoliceStationRT())
                {
                    if (receiverTransfer.IsPoliceStationCodeExists(txtCode.Text, districtID) && receiverTransfer.IsPoliceStationNameExists(txtName.Text, districtID))
                    {
                        labelMessage.Text = "Police Staion Code " + txtCode.Text + "& Name " + txtName.Text + " Already Exists!";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    else if (receiverTransfer.IsPoliceStationCodeExists(txtCode.Text))
                    {
                        labelMessage.Text = "Police Staion Code " + txtCode.Text + " Already Exists!";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    else if (receiverTransfer.IsPoliceStationCodeExists(txtCode.Text, districtID))
                    {
                        labelMessage.Text = "Police Staion Code " + txtCode.Text + " Already Exists!";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    else if (receiverTransfer.IsPoliceStationNameExists(txtName.Text, districtID))
                    {
                        labelMessage.Text = "Police Staion Name " + txtName.Text + " Already Exists!";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    PoliceStation policeStation = CreatePoliceStaion();
                    receiverTransfer.AddPoliceStaion(policeStation);
                    if (policeStation.IID > 0)
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
                LoadPoliceStationListView();
                chkIsRemovedPoliceStation.Visible = false;
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void FillPoliceStationForEdit(PoliceStation policeStaion)
        {
            try
            {
                if (policeStaion != null)
                {
                    txtName.Text = policeStaion.Name;
                    txtCode.Text = policeStaion.Code.ToString();
                    ddlCountry.SelectedValue = policeStaion.CountryID.ToString();
                    ddlDivisionOrState.SelectedValue = policeStaion.DivisionOrStateID.ToString();
                    ddlDistrict.SelectedValue = policeStaion.DistrictID.ToString();
                    chkIsRemovedPoliceStation.Checked = policeStaion.IsRemoved;
                    Session[sessPoliceStation] = policeStaion;
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void UpdatePoliceStation()
        {
            try
            {
                labelMessage.Text = string.Empty;
                using (PoliceStationRT receiverTransfer = new PoliceStationRT())
                {
                    PoliceStation policeStaion = CreatePoliceStaion();
                    if (policeStaion != null)
                    {
                        //Exit If Both Police Staion Code & Name exist in Other rows
                        if ((receiverTransfer.IsPoliceStaionCodeExistInOtherRows(policeStaion.IID, policeStaion.Code, policeStaion.DistrictID)) && (receiverTransfer.IsPoliceStaionNameExistInOtherRows(policeStaion.IID, policeStaion.Code, policeStaion.DistrictID)))
                        {
                            labelMessage.Text = "Police Staion Code " + txtCode.Text + "& Name " + txtName.Text + " Already Exists!";
                            labelMessage.ForeColor = System.Drawing.Color.Red;
                            return;
                        }
                        //Exit if Duplicate Police Station Code
                        else if (receiverTransfer.IsPoliceStationCodeExistsInOtherRows(policeStaion.IID, policeStaion.Code))
                        {
                            labelMessage.Text = "Police Staion Code " + txtCode.Text + " Already Exists!";
                            labelMessage.ForeColor = System.Drawing.Color.Red;
                            return;
                        }

                        //Exit If Both Police Staion Code exist in Other rows
                        else if (receiverTransfer.IsPoliceStaionCodeExistInOtherRows(policeStaion.IID, policeStaion.Code, policeStaion.DistrictID))
                        {
                            labelMessage.Text = "Police Staion Code " + txtCode.Text + " Already Exists!";
                            labelMessage.ForeColor = System.Drawing.Color.Red;
                            return;
                        }

                        //Exit If Both Police Staion Name exist in Other rows
                        else if (receiverTransfer.IsPoliceStaionNameExistInOtherRows(policeStaion.IID, policeStaion.Name, policeStaion.DistrictID))
                        {
                            labelMessage.Text = "Police Staion Name " + txtName.Text + " Already Exists!";
                            labelMessage.ForeColor = System.Drawing.Color.Red;
                            return;
                        }
                        if (chkIsRemovedPoliceStation.Checked == true)
                        {
                            PostOfficeRT postOfficeRT = new PostOfficeRT();
                            if (postOfficeRT.IsPostOfficeExistsInPoliceStation(Convert.ToInt32(policeStaion.IID)))
                            {
                                labelMessage.Text = "Post Office Already Exist for this Police Station";
                                labelMessage.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                receiverTransfer.UpdatePoliceStaion(policeStaion);
                                labelMessage.Text = "Data successfully updated...";
                                labelMessage.ForeColor = System.Drawing.Color.Green;
                            }
                        }
                        else
                        {
                            receiverTransfer.UpdatePoliceStaion(policeStaion);
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
                //DohideButton();
                chkIsRemovedPoliceStation.Visible = false;
                btn_CreateOrEdit.Text = "Submit";
                LoadPoliceStationListView();
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void LoadDistrictForDivOrStateChage(int divisionOrStateID)
        {
            try
            {
                using (DistrictRT receverTransfer = new DistrictRT())
                {
                    List<District> districtList = new List<District>();
                    if (divisionOrStateID != null)
                    {
                        districtList = receverTransfer.GetDistrictByDivOrStateID(divisionOrStateID);
                    }
                    else
                    {
                        districtList = receverTransfer.GetAllDistrict();
                    }
                    DropDownListHelper.Bind<District>(ddlDistrict, districtList, "Name", "IID", EnumCollection.ListItemType.District);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        private void ClearField()
        {
            txtCode.Text = string.Empty;
            txtName.Text = string.Empty;
            ddlCountry.SelectedIndex = -1;
            ddlDivisionOrState.SelectedIndex = -1;
            ddlDistrict.SelectedIndex = -1;
            //txtCountryName.Text = string.Empty;
            //txtDivOrStateName.Text = string.Empty;
            //txtDistrictName.Text = string.Empty;
        }

        #endregion Private Methods


        #region Protected Events
        protected void btn_CreateOrEdit_Click(object sender, EventArgs e)
        {
            if (btn_CreateOrEdit.Text == "Submit")
            {
                SavePoliceStation();
            }
            else if (btn_CreateOrEdit.Text == "Update")
            {
                UpdatePoliceStation();
            }

        }

        protected void lnkbEdit_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton linkButton = (LinkButton)sender;
                int policeStationID = Convert.ToInt32(linkButton.CommandArgument);
                using (PoliceStationRT receiverTransfer = new PoliceStationRT())
                {
                    PoliceStation policeStation = receiverTransfer.GetPoliceStaionByID(policeStationID);
                    hdPoliceStationID.Value = policeStationID.ToString();
                    FillPoliceStationForEdit(policeStation);
                    btn_CreateOrEdit.Text = "Update";
                }
                chkIsRemovedPoliceStation.Visible = true;
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
                PoliceStationRT policeStationRT = new PoliceStationRT();
                LinkButton linkButton = (LinkButton)sender;
                int policeStationID = Convert.ToInt32(linkButton.CommandArgument);
                var policeStation = policeStationRT.GetPoliceStaionByID(policeStationID);

                if (policeStation != null)
                {
                    PostOfficeRT postOfficeRT = new PostOfficeRT();

                    if (postOfficeRT.IsPostOfficeExistsInPoliceStation(Convert.ToInt32(policeStation.IID)))
                    {
                        labelMessage.Text = "Post Office Already Exist For This Police Station !";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                    }

                    else
                    {
                        policeStation.IsRemoved = true;
                        PoliceStation policeSt = (PoliceStation)Session[sessPoliceStation];
                        policeStation.CreatedBy = policeSt.CreatedBy; ;
                        policeStation.CreatedDate = policeSt.CreatedDate;
                        policeStation.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                        policeStation.ModifiedDate = GlobalRT.GetServerDateTime();
                        policeStationRT.UpdatePoliceStaion(policeStation);
                        labelMessage.Text = "Data successfully deleted...";
                        labelMessage.ForeColor = System.Drawing.Color.Green;
                    }
                }
                else
                {
                    labelMessage.Text = "Data not deleted...";
                    labelMessage.ForeColor = System.Drawing.Color.Red;
                }
                LoadPoliceStationListView();
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        //private void DohideButton()
        //{
        //    btnUpdate.Visible = false;
        //    btnDelete.Visible = false;
        //    btnCancel.Visible = false;
        //}

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            labelMessage.Text = string.Empty;
            //SetButton();
            ClearField();
        }

        //private void SetButton()
        //{
        //    btnSave.Visible = true;
        //    btnUpdate.Visible = false;
        //    btnDelete.Visible = false;
        //    btnCancel.Visible = false;
        //}
        int lvRowCount = 0;
        int currentPage = 0;
        protected void dataPagerPoliceStation_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    LoadPoliceStationListView();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }

        }

        protected void lvPoliceStation_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
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

        protected void ddlDivisionOrState_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int divisionOrStateID = Convert.ToInt32(ddlDivisionOrState.SelectedValue);
                LoadDistrictForDivOrStateChage(divisionOrStateID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }
        #endregion Protected Events

    }
}
