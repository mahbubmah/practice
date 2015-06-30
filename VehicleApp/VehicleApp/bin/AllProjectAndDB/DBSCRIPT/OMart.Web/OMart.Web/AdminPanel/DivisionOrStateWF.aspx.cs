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
    public partial class DivisionORStateWF : System.Web.UI.Page 
    {
        private const string sessDivisionOrState = "seDivisionOrState";
        int lvRowCount = 0;
        int currentPage = 0;       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    LoadDropDownCountry(null);
                    LoadDivisionOrState();
                    chkIsRemovedDivOrState.Visible = false;
                    btnCancel.Visible = true;
                }
                catch (Exception ex)
                {
                    labelMessage.Text = "Error : " + ex.Message;
                    labelMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
      
  #region private Methods

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

        private void LoadDivisionOrState()
        {
            try
            {
                using (DivisionOrStateRT receiverTransfer = new DivisionOrStateRT())
                {
                    lvDivisionOrState.DataSource = receiverTransfer.GetAllDivisionOrState(); ;
                    lvDivisionOrState.DataBind();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private DivisionOrState CreateDivsionOrState()
        {
            Session["UserID"] = "1";
            DivisionOrState divisionOrState = new DivisionOrState();
            try
            {

                if (btn_CreateOrEdit.Text == "Update")
                {
                    divisionOrState.IID = Convert.ToInt32(hdDivisionOrStateID.Value.ToString());
                }
                divisionOrState.Name = txtName.Text.Trim();
                divisionOrState.Code = txtCode.Text.Trim();

                divisionOrState.CountryID = Convert.ToInt32(ddlCountry.SelectedValue);
                divisionOrState.IsRemoved = chkIsRemovedDivOrState.Checked;

               
                if (divisionOrState.IID <= 0)
                {
                    divisionOrState.CreatedBy = Convert.ToInt64(Session["UserID"]);
                    divisionOrState.CreatedDate = GlobalRT.GetServerDateTime();
                }
                else
                {
                    DivisionOrState div = (DivisionOrState)Session[sessDivisionOrState];
                    divisionOrState.CreatedBy = div.CreatedBy; ;
                    divisionOrState.CreatedDate = div.CreatedDate;
                    divisionOrState.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                    divisionOrState.ModifiedDate = GlobalRT.GetServerDateTime();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return divisionOrState;
        }

        private void SaveDivisionOrState()
        {

            try
            {
                labelMessage.Text = string.Empty;
                using (DivisionOrStateRT receiverTransfer = new DivisionOrStateRT())
                {
                    int countryID = Convert.ToInt32(ddlCountry.SelectedValue);

                    if (receiverTransfer.IsDivisionOrStateCodeExists(txtCode.Text, countryID) && receiverTransfer.IsDivisionOrStateNameExists(txtName.Text, countryID))
                    {
                        labelMessage.Text = "Division Or State Code " + txtCode.Text + " & Name " + txtName.Text + " Already Exists!";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    if (receiverTransfer.IsDivisionOrStateCodeExist(txtCode.Text))
                    {
                        labelMessage.Text = "Division Or State Code " + txtCode.Text + " Already Exists!";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    else if (receiverTransfer.IsDivisionOrStateCodeExists(txtCode.Text, countryID))
                    {
                        labelMessage.Text = "Division Or State Code " + txtCode.Text + " Already Exists!";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    else if (receiverTransfer.IsDivisionOrStateNameExists(txtName.Text, countryID))
                    {
                        labelMessage.Text = "Division Or State Name " + txtName.Text + " Already Exists!";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    DivisionOrState divisionOrState = CreateDivsionOrState();
                    receiverTransfer.AddDivisionOrState(divisionOrState);
                    if (divisionOrState.IID > 0)
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
                LoadDivisionOrState();
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void UpdateDivisionOrState()
        {
            try
            {
                labelMessage.Text = string.Empty;
                using (DivisionOrStateRT receiverTransfer = new DivisionOrStateRT())
                {
                    DistrictRT districtRT = new DistrictRT();
                    DivisionOrState divisionOrState = CreateDivsionOrState();

                    if (divisionOrState != null)
                    {

                        if ((receiverTransfer.IsDivOrStateCodeExistInOterRows(divisionOrState.IID, divisionOrState.Code, divisionOrState.CountryID)) && (receiverTransfer.IsDivOrStateNameExistInOterRows(divisionOrState.IID, divisionOrState.Name, divisionOrState.CountryID)))
                        {
                            labelMessage.Text = "Division Or State Code " + txtCode.Text + " & Name " + txtName.Text + " Already Exists!";
                            labelMessage.ForeColor = System.Drawing.Color.Red;
                            return;
                        }
                        else if (receiverTransfer.IsDivOrStateCodeExisInOterRow(divisionOrState.IID, divisionOrState.Code))
                        {
                            labelMessage.Text = "Division Or State Code " + txtCode.Text + " Already Exists!";
                            labelMessage.ForeColor = System.Drawing.Color.Red;
                            return;
                        }

                        else if (receiverTransfer.IsDivOrStateCodeExistInOterRows(divisionOrState.IID, divisionOrState.Code, divisionOrState.CountryID))
                        {
                            labelMessage.Text = "Division Or State Code " + txtCode.Text + " Already Exists!";
                            labelMessage.ForeColor = System.Drawing.Color.Red;
                            return;
                        }

                        else if (receiverTransfer.IsDivOrStateNameExistInOterRows(divisionOrState.IID, divisionOrState.Name, divisionOrState.CountryID))
                        {
                            labelMessage.Text = "Division Or State Name " + txtName.Text + " Already Exists!";
                            labelMessage.ForeColor = System.Drawing.Color.Red;
                            return;
                        }

                        if (chkIsRemovedDivOrState.Checked == true)
                        {
                            if (districtRT.IsDistrictExistsInDivision(Convert.ToInt32(divisionOrState.IID)))
                            {
                                labelMessage.Text = "District already exist for this Division Or State";
                                labelMessage.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                receiverTransfer.UpdateDivisionOrState(divisionOrState);
                                labelMessage.Text = "Data successfully updated...";
                                labelMessage.ForeColor = System.Drawing.Color.Green;
                            }
                        }
                        else
                        {
                            receiverTransfer.UpdateDivisionOrState(divisionOrState);
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
                //DohideButton();
                chkIsRemovedDivOrState.Visible = false;
                ddlCountry.SelectedIndex = -1;
                LoadDivisionOrState();
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        /// <summary>
        /// Fill Designation For Edit
        /// </summary>
        /// <param name="divisionOrState"></param>
        private void FillDivisionOrStateForEdit(DivisionOrState divisionOrState)
        {
            try
            {
                if (divisionOrState != null)
                {
                    CountryRT recTransfer = new CountryRT();
                    txtName.Text = divisionOrState.Name;
                    txtCode.Text = divisionOrState.Code.ToString();
                    ddlCountry.SelectedValue = divisionOrState.CountryID.ToString();
                    chkIsRemovedDivOrState.Checked = divisionOrState.IsRemoved;
                    Session[sessDivisionOrState] = divisionOrState;                            
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
            txtCode.Text = string.Empty;  
            txtName.Text = string.Empty;
        }

  #endregion private Methods

  #region protected Events

        protected void btn_CreateOrEdit_Click(object sender, EventArgs e)
        {
            if(btn_CreateOrEdit.Text=="Submit")
            {
                SaveDivisionOrState();
            }
            else if (btn_CreateOrEdit.Text == "Update")
            {
                UpdateDivisionOrState();
            }
            
        }

        protected void lnkbEdit_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton linkButton = (LinkButton)sender;
                int divisionOrStateID = Convert.ToInt32(linkButton.CommandArgument);
                using (DivisionOrStateRT receiverTransfer = new DivisionOrStateRT())
                {
                    DivisionOrState divisionOrState = receiverTransfer.GetDivisionOrStateByID(divisionOrStateID);
                    hdDivisionOrStateID.Value = divisionOrStateID.ToString();
                    FillDivisionOrStateForEdit(divisionOrState);
                    btn_CreateOrEdit.Text = "Update";
                }
                chkIsRemovedDivOrState.Visible = true;
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
                DivisionOrStateRT divOrStateRT=new DivisionOrStateRT ();
                LinkButton linkButton = (LinkButton)sender;
                int divisionOrStateID = Convert.ToInt32(linkButton.CommandArgument);
                var divisionOrState = divOrStateRT.GetDivisionOrStateByID(divisionOrStateID);

                if (divisionOrState != null)
                {
                    DistrictRT districtRT = new DistrictRT();

                    if (districtRT.IsDistrictExistsInDivision(Convert.ToInt32(divisionOrState.IID)))
                    {
                        labelMessage.Text = "District Already Exist For This Division Or State";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                    }

                    else
                    {
                        divisionOrState.IsRemoved = true;
                        DivisionOrState div = (DivisionOrState)Session[sessDivisionOrState];
                        divisionOrState.CreatedBy = div.CreatedBy; ;
                        divisionOrState.CreatedDate = div.CreatedDate;
                        divisionOrState.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                        divisionOrState.ModifiedDate = GlobalRT.GetServerDateTime();
                        divOrStateRT.UpdateDivisionOrState(divisionOrState);
                        labelMessage.Text = "Data successfully deleted...";
                        labelMessage.ForeColor = System.Drawing.Color.Green;
                    }
                }
                else
                {
                    labelMessage.Text = "Data not deleted...";
                    labelMessage.ForeColor = System.Drawing.Color.Red;
                }
                LoadDivisionOrState();
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
            btn_CreateOrEdit.Text = "Submit";
            ClearField();
            ddlCountry.SelectedIndex = -1;
            chkIsRemovedDivOrState.Visible = false;
        }
        protected void dataPagerDivisionOrState_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    LoadDivisionOrState();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }

        }

        protected void lvDivisionOrState_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            labelMessage.Text = string.Empty;
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        #endregion protected Events


    }
}
