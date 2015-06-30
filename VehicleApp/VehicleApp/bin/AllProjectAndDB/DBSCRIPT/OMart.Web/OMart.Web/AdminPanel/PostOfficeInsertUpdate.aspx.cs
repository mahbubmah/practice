using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Providers.Entities;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Basic;
using DAL;
using Microsoft.Ajax.Utilities;
using Utilities;

namespace OMart.Web.AdminPanel
{
    public partial class PostOfficeInsertUpdate : System.Web.UI.Page
    {
        private readonly PostOfficeRT _postOfficeRt;
        private long IID = default(Int64);

        public PostOfficeInsertUpdate()
        {
            _postOfficeRt = new PostOfficeRT();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //select country from enum
                    int countryID = Convert.ToInt32(EnumCollection.Country.Bangladesh);//change here for change country
                    hdCountryID.Value = countryID.ToString();

                    var requestId = Request.QueryString["IID"];
                    if (Convert.ToInt64(requestId) == 0)
                    {
                        SelectCountryAndLoadDivisionsOrStates(countryID);
                    }
                    bool reqIDIsValid = Int64.TryParse(requestId, out IID);
                    if (reqIDIsValid)
                    {
                        ShowPostOfficeData();
                    }

                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void SelectCountryAndLoadDivisionsOrStates(int countryID)
        {
            using (CountryRT countryRt = new CountryRT())
            {
                txtCountry.Text = countryRt.GetCountryByIID(countryID).Name;
                LoadDropDownForDivisionOrState();
            }
        }

        protected void btn_CreateOrEdit_Click(object sender, EventArgs e)
        {
            try
            {
                PostOffice postOffice = CreatePostOffice();
                bool reqIDIsValid = Int64.TryParse(Request.QueryString["IID"], out IID);
                var msg = BusinessLogicValidation(postOffice);

                if (string.IsNullOrEmpty(msg))
                {
                    if (IID <= 0)
                    {
                        postOffice.CreatedBy = Convert.ToInt64(Session["UserID"]);
                        postOffice.CreatedDate = DateTime.Now;

                        _postOfficeRt.AddPostOffice(postOffice);
                        ClearData();

                        labelMessage.Text = "Information has been inserted successfully.";
                        labelMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        PostOffice objPostOffice = _postOfficeRt.GetPostOfficeByID(IID);

                        if (objPostOffice != null)
                        {
                            postOffice.CreatedBy = objPostOffice.CreatedBy; ;
                            postOffice.CreatedDate = objPostOffice.CreatedDate;
                            postOffice.IID = objPostOffice.IID;

                            postOffice.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                            postOffice.ModifiedDate = DateTime.Now;

                            _postOfficeRt.UpdatePostOffice(postOffice);
                            ClearData();

                            labelMessage.Text = "Information has been updated successfully.";
                            labelMessage.ForeColor = System.Drawing.Color.Green;
                        }
                    }
                }
                else
                {
                    labelMessage.Text = msg;
                    labelMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void LoadDropDownForDivisionOrState()
        {
            try
            {
                using (DivisionOrStateRT aDivisionOrStateRt = new DivisionOrStateRT())
                {
                    var divisionOrStateList = aDivisionOrStateRt.GetDivisionsOrStatesByCountryID(Convert.ToInt32(hdCountryID.Value));
                    DropDownListHelper.Bind(dropDownDivisionOrState, divisionOrStateList, "Name", "IID", EnumCollection.ListItemType.DivisionOrState);
                }
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message, exception);
            }
        }
        private void LoadDropDownForDistrict()
        {
            try
            {
                using (DistrictRT aDistrictRt = new DistrictRT())
                {
                    var districtList = aDistrictRt.GetDistrictByDivOrStateID(Convert.ToInt32(dropDownDivisionOrState.SelectedValue));
                    DropDownListHelper.Bind(dropDownDistrict, districtList, "Name", "IID", EnumCollection.ListItemType.District);
                }

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
        }

        private void LoadDropDownForPoliceStaion()
        {
            try
            {
                using (PoliceStationRT aPoliceStationRt = new PoliceStationRT())
                {
                    var policeStaionList = aPoliceStationRt.GetPoliceStationByCountryIdAndDistrictId(Convert.ToInt32(hdCountryID.Value), Convert.ToInt64(dropDownDistrict.SelectedValue));
                    DropDownListHelper.Bind(dropDownPoliceStation, policeStaionList, "Name", "IID", EnumCollection.ListItemType.PoliceStaion);
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
        }



        protected void dropDownDivisionOrState_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (DistrictRT aDistrictRt = new DistrictRT())
                {
                    var districtList = aDistrictRt.GetDistrictByDivOrStateID(Convert.ToInt64(dropDownDivisionOrState.SelectedValue));
                    DropDownListHelper.Bind(dropDownDistrict, districtList, "Name", "IID", EnumCollection.ListItemType.District);
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
        }

        protected void dropDownDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (PoliceStationRT aPoliceStationRt = new PoliceStationRT())
                {
                    var policeStaionList = aPoliceStationRt.GetPoliceStationByCountryIdAndDistrictId(Convert.ToInt32(hdCountryID.Value), Convert.ToInt64(dropDownDistrict.SelectedValue));
                    DropDownListHelper.Bind(dropDownPoliceStation, policeStaionList, "Name", "IID", EnumCollection.ListItemType.PoliceStaion);
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
        }



        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/AdminPanel/PostOfficeDisplay.aspx");
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void ShowPostOfficeData()
        {
            try
            {
                PostOffice objPostOffice = _postOfficeRt.GetPostOfficeByID(IID);
                if (objPostOffice != null)
                {


                    txtPostOffice.Text = objPostOffice.Name;
                    txtPostCode.Text = objPostOffice.Code;

                    using (CountryRT countryRt = new CountryRT())
                    {
                        txtCountry.Text = countryRt.GetCountryByIID(objPostOffice.CountryID).Name;
                    }

                    using (DivisionOrStateRT aDivisionOrStateRt = new DivisionOrStateRT())
                    {
                        LoadDropDownForDivisionOrState();
                        dropDownDivisionOrState.SelectedValue = aDivisionOrStateRt.GetDivisionOrStateByID(objPostOffice.DivisionOrStateID).IID.ToString();
                    }

                    using (DistrictRT aDistrictRt = new DistrictRT())
                    {
                        LoadDropDownForDistrict();
                        dropDownDistrict.SelectedValue = aDistrictRt.GetDistrictByID(objPostOffice.DistrictID).IID.ToString();

                    }
                    using (PoliceStationRT aPoliceStationRt = new PoliceStationRT())
                    {
                        LoadDropDownForPoliceStaion();
                        dropDownPoliceStation.SelectedValue = objPostOffice.PoliceStationID != null ? aPoliceStationRt.GetPoliceStaionByID((long)objPostOffice.PoliceStationID).IID.ToString() : "-1";
                    }

                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private string BusinessLogicValidation(PostOffice postOffice)
        {
            string message = string.Empty;
            bool reqIDIsValid = Int64.TryParse(Request.QueryString["IID"], out IID);

            if (postOffice.Code == null)
            {
                message = "Please enter code";
                return message;
            }

            bool isLocationNameAlradyExist = _postOfficeRt.IsPostCodeAlreadyExist(postOffice.Code, postOffice.CountryID);
            if (isLocationNameAlradyExist)
            {
                message = "Post code already exist.";
                return message;
            }

            if (dropDownDivisionOrState.SelectedValue.IsNullOrWhiteSpace() || dropDownDivisionOrState.SelectedValue == "-1")
            {
                message = "Please select division or state";
                return message;
            }
            if (dropDownDistrict.SelectedValue.IsNullOrWhiteSpace() || dropDownDistrict.SelectedValue == "-1")
            {
                message = "Please select district";
                return message;
            }

            if (IID <= 0)
            {
                if (!txtPostOffice.Text.IsNullOrWhiteSpace())
                {
                    bool isPostOfficeNameAlradyExist = _postOfficeRt.IsPostOfficeNameExists(txtPostOffice.Text, Convert.ToInt64(dropDownDistrict.SelectedValue));
                    if (isPostOfficeNameAlradyExist)
                    {
                        message = "Post Office Name already exist.";
                    }
                }
                else
                {
                    if (dropDownPoliceStation.SelectedValue.IsNullOrWhiteSpace()||dropDownPoliceStation.SelectedValue == "-1")
                    {
                        bool isDistrictNameAlreadyExist = _postOfficeRt.IsDistrictAlreadyExists(Convert.ToInt64( dropDownDistrict.SelectedValue));
                        if (isDistrictNameAlreadyExist)
                        {
                            message = "Post Office already exist.";
                        }
                    }
                    else
                    {
                        if (txtPostOffice.Text.IsNullOrWhiteSpace() && (!dropDownPoliceStation.SelectedValue.IsNullOrWhiteSpace()|| dropDownPoliceStation.SelectedValue !="-1"))
                        {
                            bool isPoliceStationAlreadyExist = _postOfficeRt.IsPoliceStationAlreadyExists(Convert.ToInt64(dropDownPoliceStation.SelectedValue));
                            if (isPoliceStationAlreadyExist)
                            {
                                message = "Post Office already exist.";
                            }
                        }
                       
                    }
                   
                }
            }
            return message;
        }

        private PostOffice CreatePostOffice()
        {
            Session["UserID"] = "1";
            PostOffice postOffice = new PostOffice();
            try
            {
                if (IID >= 0)
                {
                    postOffice.IID = IID;
                }

                postOffice.CountryID = Convert.ToInt32(hdCountryID.Value);
                if (dropDownDivisionOrState.SelectedValue != "-1" || !dropDownDivisionOrState.SelectedValue.IsNullOrWhiteSpace())
                {
                    postOffice.DivisionOrStateID = Convert.ToInt64(dropDownDivisionOrState.SelectedValue);
                }
                if (dropDownDistrict.SelectedValue != "-1" || !dropDownDistrict.SelectedValue.IsNullOrWhiteSpace())
                {
                    postOffice.DistrictID = Convert.ToInt64(dropDownDistrict.SelectedValue);
                }

                if (dropDownPoliceStation.SelectedValue != "-1" || !dropDownPoliceStation.SelectedValue.IsNullOrWhiteSpace())
                {
                    postOffice.PoliceStationID = Convert.ToInt64(dropDownPoliceStation.SelectedValue);
                }

                if (!txtPostOffice.Text.IsNullOrWhiteSpace())
                {
                    postOffice.Name = txtPostOffice.Text;
                }
                if (!txtPostCode.Text.IsNullOrWhiteSpace())
                {
                    postOffice.Code = txtPostCode.Text;
                }

            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return postOffice;
        }

        private void ClearData()
        {
            dropDownDistrict.Items.Clear();
            dropDownPoliceStation.Items.Clear();
            txtPostOffice.Text = string.Empty;
            txtPostCode.Text = string.Empty;
        }
    }
}