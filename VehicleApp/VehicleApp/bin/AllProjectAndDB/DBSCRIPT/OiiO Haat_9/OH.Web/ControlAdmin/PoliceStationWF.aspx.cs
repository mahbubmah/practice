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
    public partial class PoliceStationWF : System.Web.UI.Page
    {
        private const string sessPoliceStation = "sePoliceStation";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    //LoadDropDownCountry(null);
                    //LoadDivisionOrState(null);
                    //LoadDropDownDistrict(null);
                    chkIsRemovedPoliceStation.Visible = false;
                    LoadPoliceStationListView();
                    btnSave.Visible = true;
                    btnUpdate.Visible = false;
                    //btnDelete.Visible = false;
                    btnCancel.Visible = false;
                }
                catch (Exception ex)
                {
                    labelMessage.Text = "Error : " + ex.Message;
                    labelMessage.ForeColor = System.Drawing.Color.Red;
                }
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
        //            DropDownListHelper.Bind<Country>(ddlCountry, countryList, "Name", "IID", EnumCollection.ListItemType.Country);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex);
        //    }
        //}

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

        //private void LoadDropDownDistrict(int? districtID)
        //{
        //    try
        //    {
        //        using (DistrictRT receverTransfer = new DistrictRT())
        //        {
        //            List<District> districtList = new List<District>();
        //            if (districtID != null)
        //            {
        //                districtList.Add(receverTransfer.GetDistrictByID((int)districtID));
        //            }
        //            else
        //            {
        //                districtList = receverTransfer.GetAllDistrict();
        //            }
        //            DropDownListHelper.Bind<District>(ddlDistrict, districtList, "Name", "IID", EnumCollection.ListItemType.District);
        //        }
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


        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                labelMessage.Text = string.Empty;
                //int districtID= Convert.ToInt32(ddlDistrict.SelectedValue);
                int districtID = int.Parse(txtDistrictID.Text);
                using (PoliceStationRT receiverTransfer = new PoliceStationRT())
                {
                    //List<PoliceStation> policeStationList = new List<PoliceStation>();
                    //policeStationList = receiverTransfer.GetPoliceStaionByName(txtName.Text);
                    //if (policeStationList != null && policeStationList.Count > 0)

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

        private PoliceStation CreatePoliceStaion()
        {
            Session["UserID"] = "1";
            PoliceStation pStaion = new PoliceStation();
            try
            {
                if (hdIsEdit.Value == "true")
                {
                    pStaion.IID = Convert.ToInt32(hdPoliceStationID.Value.ToString());
                }
                pStaion.Name = txtName.Text.Trim();
                pStaion.Code = txtCode.Text.Trim();
                //pStaion.CountryID = int.Parse(ddlCountry.SelectedValue);
                pStaion.CountryID = int.Parse(txtCountryID.Text);
                //pStaion.DivisionOrStateID = int.Parse(ddlDivisionOrState.SelectedValue);
                pStaion.DivisionOrStateID = int.Parse(txtDivOrStateID.Text);
                //pStaion.DistrictID = int.Parse(ddlDistrict.SelectedValue);
                pStaion.DistrictID = int.Parse(txtDistrictID.Text);
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
                //if (hdIsDelete.Value != "true")
                //{
                //    pStaion.IsRemoved = false;
                //}
                //else
                //{
                //    pStaion.IsRemoved = true;
                //}
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return pStaion;
        }

        private void ClearField()
        {
            txtCode.Text = string.Empty;
            txtName.Text = string.Empty;
            txtCountryName.Text = string.Empty;
            txtDivOrStateName.Text = string.Empty;
            txtDistrictName.Text = string.Empty;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                labelMessage.Text = string.Empty;
                using (PoliceStationRT receiverTransfer = new PoliceStationRT())
                {
                    hdIsEdit.Value = "true";
                    //hdIsDelete.Value = "false";
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
                        else if (receiverTransfer.IsPoliceStationCodeExistsInOtherRows(policeStaion.IID ,policeStaion.Code))
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
                        if(chkIsRemovedPoliceStation.Checked==true)
                        {
                            PostOfficeRT postOfficeRT = new PostOfficeRT();
                            if (postOfficeRT.IsPoliceStationExistsInPostOffice(Convert.ToInt32(policeStaion.IID)))
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
                btnSave.Visible = true;
                DohideButton();
                chkIsRemovedPoliceStation.Visible = false;

                LoadPoliceStationListView();
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void DohideButton()
        {
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnCancel.Visible = false;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                labelMessage.Text = string.Empty;
                using (PoliceStationRT receiverTransfer = new PoliceStationRT())
                {
                    //hdIsDelete.Value = "true";
                    hdIsEdit.Value = "true";
                    PoliceStation policeStaion = CreatePoliceStaion();

                    if (policeStaion != null)
                    {
                        PostOfficeRT postOfficeRT = new PostOfficeRT();
                        if(postOfficeRT.IsPoliceStationExistsInPostOffice(Convert.ToInt32(policeStaion.IID)))
                        {
                            labelMessage.Text = "Post Office Already Exist for this Police Station";
                            labelMessage.ForeColor = System.Drawing.Color.Red;
                        }

                        else
                        {
                            receiverTransfer.UpdatePoliceStaion(policeStaion);
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
                LoadPoliceStationListView();
                DohideButton();
                btnSave.Visible = true;
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

        private void SetButton()
        {
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnCancel.Visible = false;
        }

        protected void lvPoliceStation_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "EditPoliceStation")
            {
                try
                {
                    labelMessage.Text = string.Empty;
                    chkIsRemovedPoliceStation.Visible = true;
                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    //btnDelete.Visible = true;
                    btnCancel.Visible = true;
                    int policeStationID = Convert.ToInt32(e.CommandArgument);
                    hdPoliceStationID.Value = policeStationID.ToString();
                    using (PoliceStationRT receiverTransfer = new PoliceStationRT())
                    {
                        PoliceStation policeStaion = receiverTransfer.GetPoliceStaionByID(policeStationID);
                        FillPoliceStationForEdit(policeStaion);
                    }
                }
                catch (Exception ex)
                {
                    labelMessage.Text = "Error : " + ex.Message;
                    labelMessage.ForeColor = System.Drawing.Color.Red;
                }
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
                    //ddlCountry.SelectedValue = policeStaion.CountryID.ToString();
                    txtCountryName.Text = new CountryRT().GetCountryByIID(policeStaion.CountryID).Name;
                    txtCountryID.Text = policeStaion.CountryID.ToString();
                    //ddlDivisionOrState.SelectedValue = policeStaion.DivisionOrStateID.ToString();
                    txtDivOrStateName.Text = new DivisionOrStateRT().GetDivisionOrStateByID(policeStaion.DivisionOrStateID).Name;
                    txtDivOrStateID.Text = policeStaion.DivisionOrStateID.ToString();
                    //ddlDistrict.SelectedValue = policeStaion.DistrictID.ToString();
                    txtDistrictName.Text = new DistrictRT().GetDistrictByID(policeStaion.DistrictID).Name;
                    txtDistrictID.Text = policeStaion.DistrictID.ToString();
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

        //protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        int countryID = Convert.ToInt32(ddlCountry.SelectedValue);
        //        LoadDivisionOrStateForCountry(countryID);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex);
        //    }
        //}

        //protected void ddlDivisionOrState_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        int divisionOrStateID = Convert.ToInt32(ddlDivisionOrState.SelectedValue);
        //        LoadDistrictForDivOrStateChage(divisionOrStateID);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex);
        //    }

        //}

        //private void LoadDistrictForDivOrStateChage(int divisionOrStateID)
        //{
        //    try
        //    {
        //        using (DistrictRT receverTransfer = new DistrictRT())
        //        {
        //            List<District> districtList = new List<District>();
        //            if (divisionOrStateID != null)
        //            {
        //                districtList = receverTransfer.GetDistrictByDivOrStateID(divisionOrStateID);
        //            }
        //            else
        //            {
        //                districtList = receverTransfer.GetAllDistrict();
        //            }
        //            DropDownListHelper.Bind<District>(ddlDistrict, districtList, "Name", "IID", EnumCollection.ListItemType.District);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex);
        //    }

        //}

    }
}
