using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Basic;
using DAL;
using Microsoft.Ajax.Utilities;
using Utilities;

namespace OMart.Web.AdminPanel
{
    public partial class LocationInsertUpdate : System.Web.UI.Page
    {
        private readonly LocationRT _locationRT;
        private long IID = default(Int64);

        public LocationInsertUpdate()
        {
            _locationRT = new LocationRT();
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
                    if (Convert.ToInt64(requestId)==0)
                    {
                        SelectCountryAndLoadDistrict(countryID);
                    }
                    bool reqIDIsValid = Int64.TryParse(requestId, out IID);
                    if (reqIDIsValid)
                    {
                        ShowLocationData();
                    }
                   
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void SelectCountryAndLoadDistrict(int countryID)
        {
            using (CountryRT countryRt = new CountryRT())
            {
                txtCountry.Text = countryRt.GetCountryByIID(countryID).Name;
                LoadDropDownForDistrict();
            }
        }

        protected void btn_CreateOrEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Location location = CreateLocation();
                bool reqIDIsValid = Int64.TryParse(Request.QueryString["IID"], out IID);
                var msg = BusinessLogicValidation(location);

                if (string.IsNullOrEmpty(msg))
                {
                    if (IID <= 0)
                    {
                        location.CreatedBy = Convert.ToInt64(Session["UserID"]);
                        location.CreatedDate = DateTime.Now;

                        _locationRT.AddLocation(location);
                        ClearData();

                        labelMessage.Text = "Information has been inserted successfully.";
                        labelMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        Location objLocation = _locationRT.GetLocationByIID(IID);

                        if (objLocation != null)
                        {
                            location.CreatedBy = objLocation.CreatedBy; ;
                            location.CreatedDate = objLocation.CreatedDate;
                            location.IID = objLocation.IID;

                            location.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                            location.ModifiedDate = DateTime.Now;

                            _locationRT.UpdateLocation(location);
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


        private void LoadDropDownForDistrict()
        {
            try
            {
                using (DistrictRT aDistrictRt = new DistrictRT())
                {
                    var districtList = aDistrictRt.GetDistrictByCountryId(Convert.ToInt32(hdCountryID.Value));
                    DropDownListHelper.Bind(dropDownDistrict, districtList, "Name", "IID",EnumCollection.ListItemType.District);
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

        private void LoadDropDownForPostOffice()
        {
            try
            {
                using (PostOfficeRT aPostOfficeRt = new PostOfficeRT())
                {
                    var postOfficeList = aPostOfficeRt.GetPostOfficesByDistrictId(Convert.ToInt64(dropDownPoliceStation.SelectedValue));
                    DropDownListHelper.Bind(dropDownPostOffice, postOfficeList, "Name", "IID", EnumCollection.ListItemType.PostOffice);
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
                    dropDownPostOffice.Items.Clear();
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
        }
        protected void dropDownPoliceStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (PostOfficeRT aPostOfficeRt = new PostOfficeRT())
                {
                    var postOfficeList = aPostOfficeRt.GetPostOfficesByDistrictId(Convert.ToInt64(dropDownPoliceStation.SelectedValue));
                    DropDownListHelper.Bind(dropDownPostOffice, postOfficeList, "Name", "IID", EnumCollection.ListItemType.PostOffice);
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
                Response.Redirect("~/AdminPanel/LocationDisplay.aspx");
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void ShowLocationData()
        {
            try
            {
                Location objLocation = _locationRT.GetLocationByIID(IID);
                if (objLocation != null)
                {


                    txtCurrentLocation.Text = objLocation.CurrentLocation;

                    using (CountryRT countryRt = new CountryRT())
                    {
                        txtCountry.Text = countryRt.GetCountryByIID(objLocation.CountryID).Name;
                    }

                    using (DistrictRT aDistrictRt = new DistrictRT())
                    {
                        LoadDropDownForDistrict();
                        dropDownDistrict.SelectedValue = aDistrictRt.GetDistrictByID(objLocation.DistrictID).IID.ToString();

                    }
                    using (PoliceStationRT aPoliceStationRt = new PoliceStationRT())
                    {
                        LoadDropDownForPoliceStaion();
                        dropDownPoliceStation.SelectedValue = aPoliceStationRt.GetPoliceStaionByID(objLocation.PoliceStationID).IID.ToString();
                    }
                    using (PostOfficeRT aPostOfficeRt = new PostOfficeRT())
                    {
                        LoadDropDownForPostOffice();
                        dropDownPostOffice.SelectedValue = objLocation.PostOfficeID != null ? aPostOfficeRt.GetPostOfficeByID((long)objLocation.PostOfficeID).IID.ToString() : string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private string BusinessLogicValidation(Location location)
        {
            string message = string.Empty;
            bool reqIDIsValid = Int64.TryParse(Request.QueryString["IID"], out IID);

            if (dropDownDistrict.SelectedValue.IsNullOrWhiteSpace() || dropDownDistrict.SelectedValue == "-1")
            {
                message = "Please select district";
                return message;
            }
            if (dropDownPoliceStation.SelectedValue.IsNullOrWhiteSpace() || dropDownPoliceStation.SelectedValue=="-1")
            {
                message = "Please select police staion";
                return message;
            }

            if (IID <= 0)
            {
                if (!txtCurrentLocation.Text.IsNullOrWhiteSpace())
                {
                    bool isLocationNameAlradyExist = _locationRT.IsLocationAlradyExist(txtCurrentLocation.Text);
                    if (isLocationNameAlradyExist)
                    {
                        message = "Location already exists.";
                    }
                }
                else
                {
                    if (dropDownPostOffice.SelectedValue.IsNullOrWhiteSpace() || dropDownPostOffice.SelectedValue!="-1")
                    {
                        bool isPoliceStationAlradyExist = _locationRT.IsPoliceStaionAlradyExist(Convert.ToInt64(dropDownPoliceStation.SelectedValue));
                        if (isPoliceStationAlradyExist)
                        {
                            message = "Location already exists.";
                        }
                    }
                    else
                    {
                        bool isPostOfficeAlradyExist = _locationRT.IsPostOfficeAlradyExist(Convert.ToInt64(dropDownPostOffice.SelectedValue));
                        if (isPostOfficeAlradyExist)
                        {
                            message = "Location already exists.";
                        }
                    }
                }
               
            }
           
            return message;
        }

        private Location CreateLocation()
        {
            Session["UserID"] = "1";
            Location location = new Location();
            try
            {
                if (IID >= 0)
                {
                    location.IID = IID;
                }

                location.CountryID = Convert.ToInt32(hdCountryID.Value);
                location.DistrictID = Convert.ToInt64(dropDownDistrict.SelectedValue);
                location.PoliceStationID = Convert.ToInt64(dropDownPoliceStation.SelectedValue);
                if (!dropDownPostOffice.SelectedValue.IsNullOrWhiteSpace())
                {
                    location.PostOfficeID = Convert.ToInt64(dropDownPostOffice.SelectedValue);
                }
                if (!txtCurrentLocation.Text.IsNullOrWhiteSpace())
                {
                    location.CurrentLocation = txtCurrentLocation.Text;
                }

            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return location;
        }

        private void ClearData()
        {
            txtCurrentLocation.Text = string.Empty;
            dropDownPoliceStation.Items.Clear();
            dropDownPostOffice.Items.Clear();
        }
    }
}