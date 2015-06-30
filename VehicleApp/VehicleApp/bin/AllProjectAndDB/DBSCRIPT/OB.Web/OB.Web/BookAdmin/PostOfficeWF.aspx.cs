using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OB.BLL.Basic;
using OB.DAL;
using OB.Utilities;

namespace OB.Web.BookAdmin
{
    public partial class PostOfficeWF : System.Web.UI.Page
    {
        private const string sessPostOffice = "sePostOffice";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    LoadDropDownCountry(null);
                    LoadPostOfficeListView();
                    btnSave.Visible = true;
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    btnCancel.Visible = false;
                    chkRemove.Visible = false;
                }
                catch (Exception ex)
                {
                    labelMessagePostOffice.Text = "Error : " + ex.Message;
                    labelMessagePostOffice.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        private void LoadPostOfficeListView()
        {
            try
            {
                using (PostOfficeRT receiverTransfer = new PostOfficeRT())
                {
                    lvPostOffice.DataSource = receiverTransfer.GetPostOfficeAllForListView(); ;
                    lvPostOffice.DataBind();
                }
            }
            catch (Exception ex)
            {
                labelMessagePostOffice.Text = "Error : " + ex.Message;
                labelMessagePostOffice.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                labelMessagePostOffice.Text = string.Empty;
                hdSave.Value = "true";
                int PoliceStationID = int.Parse(ddlPoliceStation.SelectedValue);
                using (PostOfficeRT receiverTransfer = new PostOfficeRT())
                {
                    if (receiverTransfer.IsPostOfficeCodeExists(txtPostOfficeCode.Text, PoliceStationID) && receiverTransfer.IsPostOfficeNameExists(txtPostOfficeName.Text, PoliceStationID))
                    {
                        labelMessagePostOffice.Text = "Post Office Code " + txtPostOfficeCode.Text + "& Name " + txtPostOfficeName.Text + " Already Exists!";
                        labelMessagePostOffice.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    else if (receiverTransfer.IsPostOfficeCodeExists(txtPostOfficeCode.Text))
                    {
                        labelMessagePostOffice.Text = "Post Office Code " + txtPostOfficeCode.Text + " Already Exists!";
                        labelMessagePostOffice.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    else if (receiverTransfer.IsPostOfficeCodeExists(txtPostOfficeCode.Text, PoliceStationID))
                    {
                        labelMessagePostOffice.Text = "Post Office Code " + txtPostOfficeCode.Text + " Already Exists!";
                        labelMessagePostOffice.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    else if (receiverTransfer.IsPostOfficeNameExists(txtPostOfficeName.Text, PoliceStationID))
                    {
                        labelMessagePostOffice.Text = "Post Office Name " + txtPostOfficeName.Text + " Already Exists!";
                        labelMessagePostOffice.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    PostOffice postOffice = CreatePostOffice();
                    receiverTransfer.AddPostOffice(postOffice);
                    if (postOffice.IID > 0)
                    {
                        labelMessagePostOffice.Text = "Data successfully saved...";
                        labelMessagePostOffice.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        labelMessagePostOffice.Text = "Data not saved...";
                        labelMessagePostOffice.ForeColor = System.Drawing.Color.Red;
                    }
                }

                ClearField();
                LoadPostOfficeListView();
                hdSave.Value = string.Empty;
                SetButton();
            }
            catch (Exception ex)
            {
                labelMessagePostOffice.Text = "Error : " + ex.Message;
                labelMessagePostOffice.ForeColor = System.Drawing.Color.Red;
            }
        }

        private PostOffice CreatePostOffice()
        {
            Session["UserID"] = "1";
            PostOffice pOffice = new PostOffice();
            try
            {
                if (hdIsEdit.Value == "true")
                {
                    pOffice.IID = Convert.ToInt32(hdPostOfficeID.Value.ToString());
                }
                pOffice.Name = txtPostOfficeName.Text.Trim();
                pOffice.Code = txtPostOfficeCode.Text.Trim();
                pOffice.CountryID = Convert.ToInt32(ddlCountry.SelectedValue);
                pOffice.DivisionOrStateID = int.Parse(ddlDivisionOrState.SelectedValue);
                pOffice.DistrictID = int.Parse(ddlDistrict.SelectedValue);
                pOffice.PoliceStationID = int.Parse(ddlPoliceStation.SelectedValue);
                
                //pOffice.CountryID = int.Parse(txtCountryID.Text);
                //pOffice.DivisionOrStateID = int.Parse(txtDivOrStateID.Text);
                //pOffice.DistrictID = int.Parse(txtDistrictID.Text);
                //pOffice.PoliceStationID = int.Parse(txtPoliceStationID.Text);

                if (pOffice.IID <= 0)
                {
                    pOffice.CreatedBy = Convert.ToInt64(Session["UserID"]);
                    pOffice.CreatedDate = GlobalRT.GetServerDateTime();
                }
                else
                {
                    PostOffice postOffice = (PostOffice)Session[sessPostOffice];
                    pOffice.CreatedBy = postOffice.CreatedBy; ;
                    pOffice.CreatedDate = postOffice.CreatedDate;
                    pOffice.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                    pOffice.ModifiedDate = GlobalRT.GetServerDateTime();
                }
                if (hdIsDelete.Value != "true")
                {
                    pOffice.IsRemoved = false;
                }
                else
                {
                    pOffice.IsRemoved = true;
                }
                if ((hdIsEdit.Value == "true" && chkRemove.Checked == false) || (hdSave.Value == "true" && chkRemove.Checked == false))
                {
                    pOffice.IsRemoved = false;
                }
                else if (hdIsEdit.Value == "true" && chkRemove.Checked == true)
                {
                    pOffice.IsRemoved = true;
                }
            }
            catch (Exception ex)
            {
                labelMessagePostOffice.Text = "Error : " + ex.Message;
                labelMessagePostOffice.ForeColor = System.Drawing.Color.Red;
            }
            return pOffice;
        }

        private void ClearField()
        {
            txtPostOfficeCode.Text = string.Empty;
            txtPostOfficeName.Text = string.Empty;
            //txtCountryName.Text = string.Empty;
            //txtDivOrStateName.Text = string.Empty;
            //txtDistrictName.Text = string.Empty;
            //txtPoliceStation.Text = string.Empty;
            ddlPoliceStation.SelectedValue = null;
            ddlDivisionOrState.SelectedValue = null;
            ddlDistrict.SelectedValue = null;
            ddlCountry.SelectedValue = null;
            chkRemove.Checked = false;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                labelMessagePostOffice.Text = string.Empty;
                using (PostOfficeRT receiverTransfer = new PostOfficeRT())
                {
                    hdIsEdit.Value = "true";
                    hdIsDelete.Value = "false";
                    PostOffice postOffice = CreatePostOffice();

                    if (postOffice != null)
                    {

                        //Exit If Both Post Office Code & Name exist in Other rows
                        if ((receiverTransfer.IsPostOfficeCodeExistInOtherRows(postOffice.IID, postOffice.Code, postOffice.DistrictID)) && (receiverTransfer.IsPostOfficeNameExistInOtherRows(postOffice.IID, postOffice.Code, postOffice.DistrictID)))
                        {
                            labelMessagePostOffice.Text = "Post Office Code " + txtPostOfficeCode.Text + "& Name " + txtPostOfficeName.Text + " Already Exists!";
                            labelMessagePostOffice.ForeColor = System.Drawing.Color.Red;
                            return;
                        }
                        //Exit if Duplicate Police Station Code
                        else if (receiverTransfer.IsPostOfficeCodeExistsInOtherRows(postOffice.IID, postOffice.Code))
                        {
                            labelMessagePostOffice.Text = "Post Office Code " + txtPostOfficeCode.Text + " Already Exists!";
                            labelMessagePostOffice.ForeColor = System.Drawing.Color.Red;
                            return;
                        }

                        //Exit If Both Police Staion Code exist in Other rows
                        else if (receiverTransfer.IsPostOfficeCodeExistInOtherRows(postOffice.IID, postOffice.Code, postOffice.DistrictID))
                        {
                            labelMessagePostOffice.Text = "Post Office Code " + txtPostOfficeCode.Text + " Already Exists!";
                            labelMessagePostOffice.ForeColor = System.Drawing.Color.Red;
                            return;
                        }

                        //Exit If Both Police Staion Name exist in Other rows
                        else if (receiverTransfer.IsPostOfficeNameExistInOtherRows(postOffice.IID, postOffice.Name, postOffice.DistrictID))
                        {
                            labelMessagePostOffice.Text = "Post Office Name " + txtPostOfficeName.Text + " Already Exists!";
                            labelMessagePostOffice.ForeColor = System.Drawing.Color.Red;
                            return;
                        }

                        receiverTransfer.UpdatePostOffice(postOffice);
                        labelMessagePostOffice.Text = "Data successfully updated...";
                        labelMessagePostOffice.ForeColor = System.Drawing.Color.Green;

                    }
                    else
                    {
                        labelMessagePostOffice.Text = "Data not updated...";
                        labelMessagePostOffice.ForeColor = System.Drawing.Color.Red;
                    }
                }
                ClearField();
                btnSave.Visible = true;
                LoadPostOfficeListView();
                SetButton();
            }
            catch (Exception ex)
            {
                labelMessagePostOffice.Text = "Error : " + ex.Message;
                labelMessagePostOffice.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lvPostOffice_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "EditPostOffice")
            {
                try
                {
                    labelMessagePostOffice.Text = string.Empty;
                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    btnCancel.Visible = true;
                    chkRemove.Visible = true;
                    int PostoffcID = Convert.ToInt32(e.CommandArgument);
                    hdPostOfficeID.Value = PostoffcID.ToString();
                    using (PostOfficeRT receiverTransfer = new PostOfficeRT())
                    {
                        PostOffice postOffice = receiverTransfer.GetPostOfficeByID(PostoffcID);
                        FillPostOfficeForEdit(postOffice);
                    }
                }
                catch (Exception ex)
                {
                    labelMessagePostOffice.Text = "Error : " + ex.Message;
                    labelMessagePostOffice.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        private void FillPostOfficeForEdit(PostOffice postOffice)
        {
            try
            {
                if (postOffice != null)
                {
                    txtPostOfficeName.Text = postOffice.Name;
                    txtPostOfficeCode.Text = postOffice.Code.ToString();
                    
                    //txtCountryName.Text = new CountryRT().GetCountryByIID(postOffice.CountryID).Name;
                    //txtCountryID.Text = postOffice.CountryID.ToString();
                    
                    //txtDivOrStateName.Text = new DivisionOrStateRT().GetDivisionOrStateByID(postOffice.DivisionOrStateID).Name;
                    //txtDivOrStateID.Text = postOffice.DivisionOrStateID.ToString();
                   
                    //txtDistrictName.Text = new DistrictRT().GetDistrictByID(postOffice.DistrictID).Name;
                    //txtDistrictID.Text = postOffice.DistrictID.ToString();

                    //txtPoliceStation.Text = new PoliceStationRT().GetPoliceStationByID(postOffice.PoliceStationID).Name;
                    //txtPoliceStationID.Text = postOffice.PoliceStationID.ToString();
                    LoadDivisionOrStateForCountry(Convert.ToInt32(postOffice.DivisionOrStateID));
                    LoadDistrictForDivOrStateChage(Convert.ToInt32(postOffice.DistrictID));
                    LoadPoliceStationForDistrictChage(Convert.ToInt32(postOffice.PoliceStationID));
                    ddlDistrict.SelectedValue = postOffice.DistrictID.ToString();
                    ddlDivisionOrState.SelectedValue = postOffice.DivisionOrStateID.ToString();
                    ddlCountry.SelectedValue = postOffice.CountryID.ToString();
                    ddlPoliceStation.SelectedValue = postOffice.PoliceStationID.ToString();
                    if (postOffice.IsRemoved == true)
                    {

                        chkRemove.Checked = true;

                    }
                    else
                    {
                        chkRemove.Checked = false;
                    }
                    Session[sessPostOffice] = postOffice;
                 
                }
            }
            catch (Exception ex)
            {
                labelMessagePostOffice.Text = "Error : " + ex.Message;
                labelMessagePostOffice.ForeColor = System.Drawing.Color.Red;
            }
        }
        int lvRowCount = 0;
        int currentPage = 0;
        protected void lvPostOffice_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void dataPagerPostOffice_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    LoadPostOfficeListView();
                }
            }
            catch (Exception ex)
            {
                labelMessagePostOffice.Text = "Error : " + ex.Message;
                labelMessagePostOffice.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                labelMessagePostOffice.Text = string.Empty;
                using (PostOfficeRT receiverTransfer = new PostOfficeRT())
                {
                    hdIsDelete.Value = "true";
                    hdIsEdit.Value = "true";
                    PostOffice postOffice = CreatePostOffice();

                    if (postOffice != null)
                    {
                        receiverTransfer.UpdatePostOffice(postOffice);
                        labelMessagePostOffice.Text = "Data successfully deleted...";
                        labelMessagePostOffice.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        labelMessagePostOffice.Text = "Data not deleted...";
                        labelMessagePostOffice.ForeColor = System.Drawing.Color.Red;
                    }
                }
                LoadPostOfficeListView();
                //DohideButton();
                btnSave.Visible = true;
                ClearField();
            }
            catch (Exception ex)
            {
                labelMessagePostOffice.Text = "Error : " + ex.Message;
                labelMessagePostOffice.ForeColor = System.Drawing.Color.Red;
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            labelMessagePostOffice.Text = string.Empty;
            SetButton();
            ClearField();
        }
        private void SetButton()
        {
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnCancel.Visible = false;
            chkRemove.Visible = false;
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
                        countryList = receverTransfer.GetCountryAll();
                    }
                    DropDownListHelper.Bind<Country>(ddlCountry, countryList, "Name", "IID", EnumCollection.ListItemType.Country);
                }
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

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int DistrictID = Convert.ToInt32(ddlDistrict.SelectedValue);
                LoadPoliceStationForDistrictChage(DistrictID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private void LoadPoliceStationForDistrictChage(int DistrictID)
        {
            try
            {
                using (PoliceStationRT receverTransfer = new PoliceStationRT())
                {
                    List<PoliceStation> PolicestationList = new List<PoliceStation>();
                    if (DistrictID != null)
                    {
                        PolicestationList = receverTransfer.GetPoliceStationForDistrictID(DistrictID);
                    }
                    else
                    {
                        PolicestationList = receverTransfer.GetPoliceStationAll();
                    }
                    DropDownListHelper.Bind<PoliceStation>(ddlPoliceStation, PolicestationList, "Name", "IID", EnumCollection.ListItemType.PoliceStation);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}