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
    public partial class DivisionORStateWF : System.Web.UI.Page 
    {
        private const string sessDivisionOrState = "seDivisionOrState";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    LoadDropDownCountry(null);
                    LoadDivisionOrState();
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
                        countryList = receverTransfer.GetCountryAll();
                    }
                    DropDownListHelper.Bind<Country>(ddlCountryID, countryList, "Name", "IID", EnumCollection.ListItemType.Country);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private DivisionOrState CreateDivsionOrState()
        {
            Session["UserID"] = "1";
            DivisionOrState divisionOrState = new DivisionOrState();
            try
            {
                if (hdIsEdit.Value == "true")
                {
                    divisionOrState.IID = Convert.ToInt32(hdDivisionOrStateID.Value.ToString());
                }
                divisionOrState.Name = txtName.Text.Trim();
                divisionOrState.Code = txtCode.Text.Trim();

                divisionOrState.CountryID = Convert.ToInt32(ddlCountryID.SelectedValue);

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
                if (hdIsDelete.Value != "true")
                {
                    divisionOrState.IsRemoved = false;
                }
                else
                {
                    divisionOrState.IsRemoved = true;
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return divisionOrState;
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

        /// <summary>
        /// Fill Designation For Edit
        /// </summary>
        /// <param name="divisionOrState"></param>
        private void FillDesignationForEdit(DivisionOrState divisionOrState)
        {
            try
            {
                if (divisionOrState != null)
                {
                    CountryRT recTransfer = new CountryRT();
                    ddlCountryID.SelectedValue = divisionOrState.CountryID.ToString();
                    txtName.Text = divisionOrState.Name;
                    txtCode.Text = divisionOrState.Code.ToString();

                    //txtCountryName.Text = Convert.ToString(recTransfer.GetCountryByIID(divisionOrState.CountryID).Name);
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
            ddlCountryID.SelectedValue = null;
        }

        private void DohideButton()
        {
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnCancel.Visible = false;
        }

        private void SetButton()
        {
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnCancel.Visible = false;
        }

        #endregion private Methods

        #region protected Events
              

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                labelMessage.Text = string.Empty;
                using (DivisionOrStateRT receiverTransfer = new DivisionOrStateRT())
                {
                    //List<DivisionOrState> divisionList = new List<DivisionOrState>(); // Comment By Hasan 2015.02.16
                    //divisionList = receiverTransfer.GetDivisionByCode(txtCode.Text);
                    //if (divisionList != null && divisionList.Count > 0)

                    //int countryID = Convert.ToInt32(hdCountryID.ToString());
                    int countryID = Convert.ToInt32(ddlCountryID.SelectedValue);

                    if(receiverTransfer.IsDivisionOrStateCodeExists(txtCode.Text, countryID) && receiverTransfer.IsDivisionOrStateNameExists(txtName.Text, countryID))
                    {
                        labelMessage.Text = "Division Or State Code " + txtCode.Text + " & Name "+  txtName.Text  + " Already Exists!";
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

                    else if (receiverTransfer.IsDivisionOrStateNameExists(txtName.Text,countryID))
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
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                labelMessage.Text = string.Empty;
                using (DivisionOrStateRT receiverTransfer = new DivisionOrStateRT())
                {
                    hdIsEdit.Value = "true";
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

                        receiverTransfer.UpdateDesignation(divisionOrState);
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
                btnSave.Visible = true;
                DohideButton();
                hdIsEdit.Value = string.Empty;
                LoadDivisionOrState();
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
                using (DivisionOrStateRT receiverTransfer = new DivisionOrStateRT())
                {
                    hdIsDelete.Value = "true";
                    hdIsEdit.Value = "true";
                    DivisionOrState divisionOrState = CreateDivsionOrState();

                    if (divisionOrState != null)
                    {
                        receiverTransfer.UpdateDesignation(divisionOrState);
                        labelMessage.Text = "Data successfully deleted...";
                        labelMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        labelMessage.Text = "Data not deleted...";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }
                LoadDivisionOrState();
                ClearField();
                hdIsEdit.Value = string.Empty;
                hdIsDelete.Value = string.Empty;
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


        protected void lvDivisionOrState_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "EditDivission")
            {
                try
                {
                    labelMessage.Text = string.Empty;
                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    btnCancel.Visible = true;
                    int divisionOrStateID = Convert.ToInt32(e.CommandArgument);
                    hdDivisionOrStateID.Value = divisionOrStateID.ToString();
                    using (DivisionOrStateRT receiverTransfer = new DivisionOrStateRT())
                    {
                        DivisionOrState divisionOrState = receiverTransfer.GetDivisionOrStateByID(divisionOrStateID);
                        FillDesignationForEdit(divisionOrState);
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
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        #endregion protected Events


    }
}
