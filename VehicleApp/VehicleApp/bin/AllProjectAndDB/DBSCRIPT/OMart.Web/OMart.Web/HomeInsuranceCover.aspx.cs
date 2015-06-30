using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Basic;
using DAL;
using Microsoft.Ajax.Utilities;
using Utilities;

namespace OMart.Web
{
    public partial class HomeInsuranceCover : System.Web.UI.Page
    {
        private readonly InsuranceCoverRT _insuranceCoverRt;
        private readonly HomeInsuranceRT _homeInsuranceRt;
        private readonly string _visitorLogPath;
        private string _pageLogPath;

        public HomeInsuranceCover()
        {
            this._visitorLogPath = Server.MapPath("~/Log file/VisitorlogFileWriting.txt");
            _insuranceCoverRt = new InsuranceCoverRT();
            _homeInsuranceRt = new HomeInsuranceRT();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                string pageName = Path.GetFileName(Request.PhysicalPath);
                _pageLogPath = Server.MapPath("~/Log file/" + pageName + ".txt");

                this.pnlHomeInsCover.Visible = (this.Request.QueryString["Type"] == "pnlHomeInsCover");
                this.pnlHomeInsResult.Visible = (this.Request.QueryString["Type"] == "pnlHomeInsResult");
                if (!IsPostBack)
                {
                    LogFileHelper.VisitorLogFileWritten(_visitorLogPath);
                    ancCover.Attributes.Remove("class");
                    ancResult.Attributes.Remove("class");
                    if (pnlHomeInsCover.Visible)
                    {
                        LoadDropDownFloorSizeUnit();
                        LoadDropDownGasSupplyType();
                        LoadDropDownParkingSizeUnit();
                        LoadDropDownPowerSupplyType();
                        LoadDropDownWaterSupplyType();
                        LoadContactDetails();
                        ancCover.Attributes.Add("class", "active");

                    }
                    if (pnlHomeInsResult.Visible)
                    {
                        ancResult.Attributes.Add("class", "active");
                    }
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }

        }



        #region private methods
        private void LoadContactDetails()
        {
            try
            {
                if (Session["UserID"] != null)
                {
                    using (UserInformationRT aUserInformationRt = new UserInformationRT())
                    {
                        var applicantContactDetails = aUserInformationRt.GetUserInfoByID(Convert.ToInt32(Session["UserID"]));
                        txtEmail.Text = applicantContactDetails.LoginName;
                        if (applicantContactDetails.PhoneNo != null)
                        {
                            txtPhoneNo.Text = applicantContactDetails.PhoneNo;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
        public string BusinessLogicValidation()
        {
            string msg = string.Empty;
            try
            {
                //logic validation for applicant
                if (txtPhoneNo.Text.IsNullOrWhiteSpace() && (chkConfByPhone.Checked || chkConfByText.Checked))
                {
                    msg = "Please enter your phone no. to get informed by phone.";
                    return msg;
                }

                if (txtDateOfBirth.Text.IsNullOrWhiteSpace())
                {
                    msg = "Please your date of birth.";
                    return msg;
                }
                if (txtEmail.Text.IsNullOrWhiteSpace())
                {
                    msg = "Please enter your email.";
                    return msg;
                }
                if (txtFirstName.Text.IsNullOrWhiteSpace())
                {
                    msg = "Please enter your first name.";
                    return msg;
                }
                if (txtLastName.Text.IsNullOrWhiteSpace())
                {
                    msg = "Please enter your last name.";
                    return msg;
                }


                //logic validation home info
                if (txtAddressOfBuilding.Text.IsNullOrWhiteSpace())
                {
                    msg = "Please enter address of building.";
                    return msg;
                }
                if (txtConsDate.Text.IsNullOrWhiteSpace())
                {
                    msg = "Please enter constuction finishing year";
                    return msg;
                }
                if (txtFloorSize.Text.IsNullOrWhiteSpace())
                {
                    msg = "Please enter floor size.";
                    return msg;
                }
                if (txtNumberOfFloor.Text.IsNullOrWhiteSpace())
                {
                    msg = "Please enter number of floor.";
                    return msg;
                }
                return msg;
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
            return msg;
        }
        public HomeInfo CreateHomeInfo()
        {
            try
            {
                HomeInfo homeInfo = new HomeInfo();
                //required field
                homeInfo.AddressOfBuilding = txtAddressOfBuilding.Text;
                homeInfo.ConstructionDate = Convert.ToDateTime(txtConsDate.Text);
                homeInfo.FloorNumberOfBuilding = Convert.ToInt32(txtNumberOfFloor.Text);
                homeInfo.FloorSize = Convert.ToInt32(txtFloorSize.Text);
                homeInfo.FloorSizeUnitID = Convert.ToInt32(ddlFloorSizeUnit.SelectedValue);
                homeInfo.TotalFloorSize = homeInfo.FloorNumberOfBuilding * homeInfo.FloorSize;
                homeInfo.CreatedBy = Session["UserID"] != null ? Convert.ToInt64(Session["UserID"]) : 0;
                homeInfo.CreatedDate = GlobalRT.GetServerDateTime();
                homeInfo.IsRemoved = false;

                //nullable field
                if (ddlGasSupplyType.SelectedValue != "-1" || !ddlGasSupplyType.SelectedValue.IsNullOrWhiteSpace())
                {
                    homeInfo.GasSupplyTypeID = Convert.ToInt32(ddlGasSupplyType.SelectedValue);
                }
                if (ddlPowerSupplyType.SelectedValue != "-1" || !ddlPowerSupplyType.SelectedValue.IsNullOrWhiteSpace())
                {
                    homeInfo.PowerSupplyTypeID = Convert.ToInt32(ddlPowerSupplyType.SelectedValue);
                }
                if (ddlWaterSupplyType.SelectedValue != "-1" || !ddlWaterSupplyType.SelectedValue.IsNullOrWhiteSpace())
                {
                    homeInfo.WaterSupplyTypeID = Convert.ToInt32(ddlWaterSupplyType.SelectedValue);
                }

                if (!txtParkingSpaceSize.Text.IsNullOrWhiteSpace())
                {
                    homeInfo.ParkingSpaceSize = Convert.ToInt32(txtParkingSpaceSize);
                    homeInfo.ParkingSpaceSizeUnitID = Convert.ToInt32(ddlParkingSpageSizeUnit.SelectedValue);
                }
                if (!txtEstimatedPrice.Text.IsNullOrWhiteSpace())
                {
                    homeInfo.EstimatedPrice = Convert.ToDecimal(txtEstimatedPrice.Text);
                }
                if (!txtNumberOfRoomPerFloor.Text.IsNullOrWhiteSpace())
                {
                    homeInfo.RoomNumberPerFloor = Convert.ToInt32(txtNumberOfRoomPerFloor.Text);
                }

                return homeInfo;

            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
            return null;
        }
        public Applicant CreateApplicant()
        {
            try
            {
                Applicant applicant = new Applicant();
                applicant.ApplicationFor = Convert.ToInt32(EnumCollection.BusinessInsuranceType.HomeInsurance);
                applicant.DateOfBirth = Convert.ToDateTime(txtDateOfBirth.Text);
                applicant.EmailAddress = txtEmail.Text;
                applicant.IPNumber = VisitorIPMACAddress.GetVisitorIPAddress();
                applicant.FirstName = txtFirstName.Text;
                applicant.LastName = txtLastName.Text;
                if (!txtPhoneNo.Text.IsNullOrWhiteSpace())
                {
                    applicant.PhoneNo = txtPhoneNo.Text;
                }

                applicant.FullName = txtFirstName.Text + " " + txtLastName.Text;
                applicant.GenderID = Convert.ToInt32(rdGender.SelectedValue);

                if (chkConfByEmail.Checked && chkConfByPhone.Checked && chkConfByText.Checked)
                {
                    applicant.WantMoreInfoID = Convert.ToInt32(EnumCollection.WantMoreInfo.ByAllMedia);
                }
                else if (!chkConfByEmail.Checked && !chkConfByPhone.Checked && !chkConfByText.Checked)
                {
                    applicant.WantMoreInfoID = Convert.ToInt32(EnumCollection.WantMoreInfo.None);
                }
                else if (!chkConfByEmail.Checked && chkConfByPhone.Checked && chkConfByText.Checked)
                {
                    applicant.WantMoreInfoID = Convert.ToInt32(EnumCollection.WantMoreInfo.ByPhoneCallAndText);
                }
                else if (chkConfByEmail.Checked && !chkConfByPhone.Checked && chkConfByText.Checked)
                {
                    applicant.WantMoreInfoID = Convert.ToInt32(EnumCollection.WantMoreInfo.ByTextAndEmail);
                }
                else if (chkConfByEmail.Checked && chkConfByPhone.Checked && !chkConfByText.Checked)
                {
                    applicant.WantMoreInfoID = Convert.ToInt32(EnumCollection.WantMoreInfo.ByEmailAndPhoneCall);
                }
                else if (chkConfByEmail.Checked && !chkConfByPhone.Checked && !chkConfByText.Checked)
                {
                    applicant.WantMoreInfoID = Convert.ToInt32(EnumCollection.WantMoreInfo.ByEmail);
                }
                else if (!chkConfByEmail.Checked && chkConfByPhone.Checked && !chkConfByText.Checked)
                {
                    applicant.WantMoreInfoID = Convert.ToInt32(EnumCollection.WantMoreInfo.ByPhoneCall);
                }
                else if (!chkConfByEmail.Checked && !chkConfByPhone.Checked && chkConfByText.Checked)
                {
                    applicant.WantMoreInfoID = Convert.ToInt32(EnumCollection.WantMoreInfo.ByText);
                }
                applicant.CreatedBy = Session["UserID"] != null ? Convert.ToInt64(Session["UserID"]) : 0;
                applicant.CreatedDate = GlobalRT.GetServerDateTime();
                applicant.IsRemoved = false;
                return applicant;
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
            return null;
        }


        #region load drop down
        private void LoadDropDownFloorSizeUnit()
        {
            try
            {
                var list = EnumHelper.EnumCamelSpaceToList<EnumCollection.SpaceSizeUnitType>();
                DropDownListHelper.Bind(ddlFloorSizeUnit, list);
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
        private void LoadDropDownParkingSizeUnit()
        {
            try
            {
                var list = EnumHelper.EnumCamelSpaceToList<EnumCollection.SpaceSizeUnitType>();
                DropDownListHelper.Bind(ddlParkingSpageSizeUnit, list);
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
        private void LoadDropDownPowerSupplyType()
        {
            try
            {
                var list = EnumHelper.EnumCamelSpaceToList<EnumCollection.PowerSupplyType>();
                DropDownListHelper.Bind(ddlPowerSupplyType, list);
                ddlPowerSupplyType.Items.Insert(0, new ListItem("--Select--", "-1"));
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
        private void LoadDropDownWaterSupplyType()
        {
            try
            {
                var list = EnumHelper.EnumCamelSpaceToList<EnumCollection.WaterSupplyType>();
                DropDownListHelper.Bind(ddlWaterSupplyType, list);
                ddlWaterSupplyType.Items.Insert(0, new ListItem("--Select--", "-1"));
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
        private void LoadDropDownGasSupplyType()
        {
            try
            {
                var list = EnumHelper.EnumCamelSpaceToList<EnumCollection.GasSupplyType>();
                DropDownListHelper.Bind(ddlGasSupplyType, list);
                ddlGasSupplyType.Items.Insert(0, new ListItem("--Select--", "-1"));
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
        #endregion load drop down

        #endregion private methods


        #region protected events
        protected void btnShowResult_OnClick(object sender, EventArgs e)
        {
            try
            {
                string msg = BusinessLogicValidation();
                if (msg.IsNullOrWhiteSpace())
                {
                    Applicant applicant = CreateApplicant();
                    if (applicant != null)
                    {
                        _insuranceCoverRt.AddAppicant(applicant);
                        if (applicant.IID > 0)
                        {
                            HomeInfo homeInfo = CreateHomeInfo();
                            if (homeInfo != null)
                            {
                                homeInfo.ApplicantID = applicant.IID;
                                _homeInsuranceRt.AddHomeInfo(homeInfo);
                                if (homeInfo.IID>0)
                                {
                                    Response.Redirect("HomeInsuranceCover.aspx?Type=pnlHomeInsResult",false);
                                    Context.ApplicationInstance.CompleteRequest();
                                }
                                else
                                {
                                    lblMessage.Text = "Error: Please insert the fields correctly";
                                    lblMessage.ForeColor = Color.Red;
                                }
                            }
                            else
                            {
                                lblMessage.Text = "Error: Please insert the fields correctly";
                                lblMessage.ForeColor = Color.Red;
                            }
                        }
                        else
                        {
                            lblMessage.Text = "Error: Please insert the fields correctly";
                            lblMessage.ForeColor = Color.Red;
                        }

                    }
                    else
                    {
                        lblMessage.Text = "Error: Please insert the fields correctly";
                        lblMessage.ForeColor = Color.Red;
                    }
                }
                else
                {
                    lblMessage.Text = msg;
                    lblMessage.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
        #endregion protected events



    }
}