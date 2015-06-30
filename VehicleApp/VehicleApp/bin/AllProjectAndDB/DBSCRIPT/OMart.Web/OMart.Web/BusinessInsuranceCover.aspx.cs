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
    public partial class BusinessInsuranceCover : System.Web.UI.Page
    {
        private readonly InsuranceCoverRT _insuranceCoverRt;
        private readonly string _visitorLogPath;
        private string _pageLogPath;
        private readonly BIReceiverRT _biReceiverRt;
        private const string sessBiApplicant = "seBiApplicant";
        private const string sessBiReceiver = "seReceiverDetailList";
        private const string sessBiReceiverDetailList = "seBiReceiverDetailList";

        public BusinessInsuranceCover()
        {
            this._visitorLogPath = Server.MapPath("~/Log file/VisitorlogFileWriting.txt");
            this._biReceiverRt = new BIReceiverRT();
            this._insuranceCoverRt = new InsuranceCoverRT();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string pageName = Path.GetFileName(Request.PhysicalPath);
                _pageLogPath = Server.MapPath("~/Log file/" + pageName + ".txt");

                this.pnlBuzInsAbout.Visible = (this.Request.QueryString["Type"] == "pnlBuzInsAbout");
                this.pnlBuzInsCover.Visible = (this.Request.QueryString["Type"] == "pnlBuzInsCover");
                this.pnlBuzInsResult.Visible = (this.Request.QueryString["Type"] == "pnlBuzInsResult");

                if (!IsPostBack)
                {

                    LogFileHelper.VisitorLogFileWritten(_visitorLogPath);
                    ancAboutYou.Attributes.Remove("class");
                    ancResult.Attributes.Remove("class");
                    ancYourCover.Attributes.Remove("class");

                    if (pnlBuzInsAbout.Visible)
                    {
                        LoadDropDownBiCategory();
                        LoadDropDownBiCategoryDetail();
                        LoadDropDownBusinessAge();
                        LoadContactDetails();
                        ancAboutYou.Attributes.Add("class", "active");

                        if (Session[sessBiApplicant] != null && Session[sessBiReceiver] != null)
                        {
                            ShowApplicantAndBiReceiverData();
                        }
                     
                    }
                    if (pnlBuzInsCover.Visible)
                    {

                        LoadDropDownIndemnityAmount();
                        LoadDropDowndPublicLiability();
                        LoadDropDownEmployerLiability();
                        LoadDropDownOfficeEquipment();
                        LoadDropDownPortableEquipment();

                        ancYourCover.Attributes.Add("class", "active");

                        if (Session[sessBiReceiverDetailList] != null)
                        {
                            ShowBiReceiverDetailData();
                        }
                    }
                    if (pnlBuzInsResult.Visible)
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





        #region protected event
        protected void btnAboutNextPage_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (!chkTermsAndCondition.Checked)                 //validate terms and condition
                {
                    lblMessageTermsAndCondition.Text = "you must agree to our terms and conditions in order to continue";
                    lblMessageTermsAndCondition.ForeColor=Color.Red;
                    lblMessageTermsAndCondition.Focus();

                    lblMessage.Text = "you must agree to our terms and conditions in order to continue";
                    lblMessage.ForeColor = Color.Red;
                    lblMessage.Focus();
                    return;
                }
                string message = BusinessLogicValidationForAboutPage();
                if (message.IsNullOrWhiteSpace())
                {
                    Applicant applicant = CreateApplicant();
                    if (Session[sessBiApplicant] == null)
                    {
                        _insuranceCoverRt.AddAppicant(applicant);
                        Session[sessBiApplicant] = applicant;
                    }
                    else
                    {
                        Applicant applicantOld = (Applicant)Session[sessBiApplicant];
                        applicant.IID = applicantOld.IID;
                        _insuranceCoverRt.UpdateAppicant(applicant);
                        Session[sessBiApplicant] = applicant;
                    }
                    Session[sessBiReceiver] = CreateBiReceiver();
                    Response.Redirect("BusinessInsuranceCover?Type=pnlBuzInsCover",false);
                    Context.ApplicationInstance.CompleteRequest();
                }
                else
                {
                    lblMessage.Text = message;
                    lblMessage.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }

        }
        protected void btnCoverPreviousPage_OnClick(object sender, EventArgs e)
        {
            try
            {
                Session[sessBiReceiverDetailList] = CreateBiReceiverDetailList();
                Response.Redirect("BusinessInsuranceCover?Type=pnlBuzInsAbout", false);
                Context.ApplicationInstance.CompleteRequest();
              
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }

        }
        protected void btnCoverNextPage_OnClick(object sender, EventArgs e)
        {
            try
            {
                List<BusinessInsuranceReceiverDetail> businessInsuranceReceiverDetailColl = new List<BusinessInsuranceReceiverDetail>(CreateBiReceiverDetailList());


                if (Session[sessBiReceiver] != null && Session[sessBiApplicant] != null)
                {
                    string biReceiverAndChidXml = ConversionXML.ConvertObjectToXML<BusinessInsuranceReceiver, BusinessInsuranceReceiverDetail>((BusinessInsuranceReceiver)Session[sessBiReceiver], businessInsuranceReceiverDetailColl, string.Empty);

                    int biReceiver = _biReceiverRt.InsertBiReceiverAndBiReceiverChildXml(biReceiverAndChidXml);

                    if (biReceiver > 0)
                    {
                        Session[sessBiApplicant] = null;
                        Session[sessBiReceiver] = null;
                        Session[sessBiReceiverDetailList] = null;
                        Response.Redirect("BusinessInsuranceCover?Type=pnlBuzInsResult",false);
                        Context.ApplicationInstance.CompleteRequest();
                    }
                    else if (biReceiver == -100)
                    {
                        lblMessage.Text = "Network connection fail ... Please try again..!!";
                        lblMessage.ForeColor = Color.Red;
                        lblMessage.Focus();
                    }
                    else if (biReceiver == -101)
                    {
                        lblMessage.Text = "Network connection fail ... Please try again..!!";
                        lblMessage.ForeColor = Color.Red;
                        lblMessage.Focus();
                    }
                    else
                    {
                        lblMessage.Text = "Error";
                        lblMessage.ForeColor = Color.Red;
                        lblMessage.Focus();
                    }
                }
                else
                {
                    lblMessage.Text = "Error: Please fill the form correctly";
                    lblMessage.ForeColor = Color.Red;
                    lblMessage.Focus();
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }

        }
        protected void ddlBusinessType_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadDropDownBiCategoryDetail();
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        #endregion protected event






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
        private Applicant CreateApplicant()
        {
            try
            {

                Applicant applicant = new Applicant();
                applicant.ApplicationFor = Convert.ToInt32(EnumCollection.BusinessInsuranceType.LifeInsurance);
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
        private void ShowBiReceiverDetailData()
        {
            try
            {
                var biReceverDetailList = (List<BusinessInsuranceReceiverDetail>)Session[sessBiReceiverDetailList];

                var biReceiverDetailForIndemnityAmount = biReceverDetailList.SingleOrDefault(x => x.BIAmountRangeID == Convert.ToInt32(EnumCollection.BIAmountType.IndemnityAmount));
                if (biReceiverDetailForIndemnityAmount != null)
                {
                    ddlIndemnityAmount.SelectedValue = biReceiverDetailForIndemnityAmount.BIAmountRangeID.ToString();
                }

                var biReceiverDetailForEmployerLiability =
                   biReceverDetailList.SingleOrDefault(
                       x => x.BIAmountRangeID == Convert.ToInt32(EnumCollection.BIAmountType.EmployerLiability));
                if (biReceiverDetailForIndemnityAmount != null)
                {
                    ddlEmployerLiability.SelectedValue = biReceiverDetailForEmployerLiability.BIAmountRangeID.ToString();
                }

                var biReceiverDetailForOfficeEquipment =
                   biReceverDetailList.SingleOrDefault(
                       x => x.BIAmountRangeID == Convert.ToInt32(EnumCollection.BIAmountType.OfficeEquipment));
                if (biReceiverDetailForIndemnityAmount != null)
                {
                    ddlOfficeEquipment.SelectedValue = biReceiverDetailForOfficeEquipment.BIAmountRangeID.ToString();
                }

                var biReceiverDetailForPortableEquipment =
                   biReceverDetailList.SingleOrDefault(
                       x => x.BIAmountRangeID == Convert.ToInt32(EnumCollection.BIAmountType.PortableEquipment));
                if (biReceiverDetailForIndemnityAmount != null)
                {
                    ddlPortableEquipment.SelectedValue = biReceiverDetailForPortableEquipment.BIAmountRangeID.ToString();
                }

                var biReceiverDetailForPublicLiability =
                   biReceverDetailList.SingleOrDefault(
                       x => x.BIAmountRangeID == Convert.ToInt32(EnumCollection.BIAmountType.PublicLiability));
                if (biReceiverDetailForIndemnityAmount != null)
                {
                    ddlPublicLiability.SelectedValue = biReceiverDetailForPublicLiability.BIAmountRangeID.ToString();
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
        private void ShowApplicantAndBiReceiverData()
        {
            try
            {
                //show applicant data
                Applicant applicant = (Applicant)Session[sessBiApplicant];
                BusinessInsuranceReceiver biReceiver = (BusinessInsuranceReceiver)Session[sessBiReceiver];
                txtDateOfBirth.Text = applicant.DateOfBirth.ToString("dd-M-yy");
                txtEmail.Text = applicant.EmailAddress;
                txtFirstName.Text = applicant.FirstName;
                txtLastName.Text = applicant.LastName;
                txtPhoneNo.Text = applicant.PhoneNo;
                rdGender.SelectedValue = applicant.GenderID.ToString();
               


                //show bi receiver data
                txtYearWiseTurnOverAmt.Text = biReceiver.YearWiseTurnoverAmt.ToString("0.##");
                ddlBICategory.SelectedValue = _biReceiverRt.GetBiCategoryIidByBiCatDetailIiD(Convert.ToInt64(biReceiver.BICategoryDetailID)).ToString();
                LoadDropDownBiCategoryDetail();
                ddlBiCategoryDetail.SelectedValue = biReceiver.BICategoryDetailID.ToString();
                ddlBusinessAge.SelectedValue = biReceiver.BIBusinessAgeID.ToString();

                //switch (applicant.WantMoreInfoID)
                //{
                //    case 0:
                //        chkConfByEmail.Checked = false;
                //        chkConfByPhone.Checked = false;
                //        chkConfByText.Checked = false;
                //        break;
                //    case 1:
                //        chkConfByEmail.Checked = true;
                //        chkConfByPhone.Checked = true;
                //        chkConfByText.Checked = true;
                //        break;
                //    case 2:
                //        chkConfByEmail.Checked = false;
                //        chkConfByPhone.Checked = false;
                //        chkConfByText.Checked = true;
                //        break;
                //    case 3:
                //        chkConfByEmail.Checked = true;
                //        chkConfByPhone.Checked = false;
                //        chkConfByText.Checked = false;
                //        break;
                //    case 4:
                //        chkConfByEmail.Checked = false;
                //        chkConfByPhone.Checked = true;
                //        chkConfByText.Checked = false;
                //        break;
                //    case 5:
                //        chkConfByEmail.Checked = true;
                //        chkConfByPhone.Checked = false;
                //        chkConfByText.Checked = true;
                //        break;
                //    case 6:
                //        chkConfByEmail.Checked = true;
                //        chkConfByPhone.Checked = true;
                //        chkConfByText.Checked = false;
                //        break;
                //    case 7:
                //        chkConfByEmail.Checked = false;
                //        chkConfByPhone.Checked = true;
                //        chkConfByText.Checked = true;
                //        break;
                //}
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
        private List<BusinessInsuranceReceiverDetail> CreateBiReceiverDetailList()
        {
            try
            {
                List<BusinessInsuranceReceiverDetail> businessInsuranceReceiverDetailColl = new List<BusinessInsuranceReceiverDetail>();
                if (ddlEmployerLiability.SelectedValue != "-1" && !ddlEmployerLiability.SelectedValue.IsNullOrWhiteSpace())
                {
                    BusinessInsuranceReceiverDetail biReceiverDetail = new BusinessInsuranceReceiverDetail();
                    biReceiverDetail.BIAmountRangeID = Convert.ToInt64(ddlEmployerLiability.SelectedValue);
                    businessInsuranceReceiverDetailColl.Add(biReceiverDetail);
                }
                if (ddlIndemnityAmount.SelectedValue != "-1" && !ddlIndemnityAmount.SelectedValue.IsNullOrWhiteSpace())
                {
                    BusinessInsuranceReceiverDetail biReceiverDetail = new BusinessInsuranceReceiverDetail();
                    biReceiverDetail.BIAmountRangeID = Convert.ToInt64(ddlIndemnityAmount.SelectedValue);
                    businessInsuranceReceiverDetailColl.Add(biReceiverDetail);
                }
                if (ddlOfficeEquipment.SelectedValue != "-1" && !ddlOfficeEquipment.SelectedValue.IsNullOrWhiteSpace())
                {
                    BusinessInsuranceReceiverDetail biReceiverDetail = new BusinessInsuranceReceiverDetail();
                    biReceiverDetail.BIAmountRangeID = Convert.ToInt64(ddlOfficeEquipment.SelectedValue);
                    businessInsuranceReceiverDetailColl.Add(biReceiverDetail);
                }
                if (ddlPortableEquipment.SelectedValue != "-1" && !ddlPortableEquipment.SelectedValue.IsNullOrWhiteSpace())
                {
                    BusinessInsuranceReceiverDetail biReceiverDetail = new BusinessInsuranceReceiverDetail();
                    biReceiverDetail.BIAmountRangeID = Convert.ToInt64(ddlPortableEquipment.SelectedValue);
                    businessInsuranceReceiverDetailColl.Add(biReceiverDetail);
                }
                if (ddlPublicLiability.SelectedValue != "-1" && !ddlPublicLiability.SelectedValue.IsNullOrWhiteSpace())
                {
                    BusinessInsuranceReceiverDetail biReceiverDetail = new BusinessInsuranceReceiverDetail();
                    biReceiverDetail.BIAmountRangeID = Convert.ToInt64(ddlPublicLiability.SelectedValue);
                    businessInsuranceReceiverDetailColl.Add(biReceiverDetail);
                }

                foreach (var businessInsuranceReceiverDetail in businessInsuranceReceiverDetailColl)
                {
                    businessInsuranceReceiverDetail.IsRemoved = false;
                    businessInsuranceReceiverDetail.CreatedBy = Session["UserID"] != null ? Convert.ToInt64(Session["UserID"]) : 0;
                    businessInsuranceReceiverDetail.CreatedDate = GlobalRT.GetServerDateTime();
                }
                Session[sessBiReceiverDetailList] = businessInsuranceReceiverDetailColl;
                return businessInsuranceReceiverDetailColl;
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
            return null;
        }
        private string BusinessLogicValidationForAboutPage()
        {
            string msg = string.Empty;
            try
            {
                //validate applicant
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
               


                //validate business insurance receiver
                if (ddlBusinessAge.SelectedValue.IsNullOrWhiteSpace() || ddlBusinessAge.SelectedValue == "-1")
                {
                    msg = "Please select your business age.";
                    return msg;
                }
                if (ddlBICategory.SelectedValue.IsNullOrWhiteSpace() || ddlBICategory.SelectedValue == "-1")
                {
                    msg = "Please select your business category.";
                    return msg;
                }
                if (ddlBiCategoryDetail.SelectedValue.IsNullOrWhiteSpace() || ddlBiCategoryDetail.SelectedValue == "-1")
                {
                    msg = "Please select your business category detail.";
                    return msg;
                }
                if (txtYearWiseTurnOverAmt.Text.IsNullOrWhiteSpace())
                {
                    msg = "Please enter year wise turn over amount.";
                    return msg;
                }

            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
            return msg;
        }
        private string BusinessLogicValidationForCoverPage()
        {
            string msg = string.Empty;
            try
            {

            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
            return msg;
        }
        private BusinessInsuranceReceiver CreateBiReceiver()
        {
            try
            {
                BusinessInsuranceReceiver biReceiver = new BusinessInsuranceReceiver();
                biReceiver.ApplicantID = ((Applicant)Session[sessBiApplicant]).IID;
                biReceiver.BIBusinessAgeID = Convert.ToInt64(ddlBusinessAge.SelectedValue);
                biReceiver.BICategoryDetailID = Convert.ToInt64(ddlBiCategoryDetail.SelectedValue);
                biReceiver.YearWiseTurnoverAmt = Convert.ToDecimal(txtYearWiseTurnOverAmt.Text);

                biReceiver.CreatedBy =Session["UserID"]!=null? Convert.ToInt64(Session["UserID"]):0;
                biReceiver.CreatedDate = GlobalRT.GetServerDateTime();
                biReceiver.IsRemoved = false;
                return biReceiver;
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
            return null;
        }

        #region load drop down
      
        private void LoadDropDownPortableEquipment()
        {
            try
            {
                var indemnityTypeList = _biReceiverRt.GetAllPortableEquipmentTypeAmount();
                DropDownListHelper.Bind(ddlPortableEquipment, indemnityTypeList, "AmountDetail", "IID");
                ddlPortableEquipment.Items.Insert(0, new ListItem("--Select--", "-1"));
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private void LoadDropDownOfficeEquipment()
        {
            try
            {

                var officeEquipmetTypeAmountList = _biReceiverRt.GetAllOfficeEquipmentTypeAmount();
                DropDownListHelper.Bind(ddlOfficeEquipment, officeEquipmetTypeAmountList, "AmountDetail", "IID");
                ddlOfficeEquipment.Items.Insert(0, new ListItem("--Select--", "-1"));
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private void LoadDropDownEmployerLiability()
        {
            try
            {

                var biAmountEmployerTypeList = _biReceiverRt.GetAllEmployerLiabilityTypeAmount();
                DropDownListHelper.Bind(ddlEmployerLiability, biAmountEmployerTypeList, "AmountDetail", "IID");
                ddlEmployerLiability.Items.Insert(0, new ListItem("--Select--", "-1"));
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private void LoadDropDowndPublicLiability()
        {
            try
            {

                var amountPublicLiablityTypeList = _biReceiverRt.GetAllPublicLiabilityTypeAmount();
                DropDownListHelper.Bind(ddlPublicLiability, amountPublicLiablityTypeList, "AmountDetail", "IID");
                ddlPublicLiability.Items.Insert(0, new ListItem("--Select--", "-1"));
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private void LoadDropDownIndemnityAmount()
        {
            try
            {
                var biAmountIndemnityTypeList = _biReceiverRt.GetAllIndemnityTypeAmount();
                DropDownListHelper.Bind(ddlIndemnityAmount, biAmountIndemnityTypeList, "AmountDetail", "IID");
                ddlIndemnityAmount.Items.Insert(0, new ListItem("--Select--", "-1"));
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private void LoadDropDownBusinessAge()
        {
            try
            {
                var businessAgeIntervalList = _biReceiverRt.GetAllBusinessAgeInterval();
                DropDownListHelper.Bind(ddlBusinessAge, businessAgeIntervalList, "AgeInterval", "IID");
                ddlBusinessAge.Items.Insert(0, new ListItem("--Select--", "-1"));
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private void LoadDropDownBiCategoryDetail()
        {
            try
            {
                var biCategoryDetailList = _biReceiverRt.GetBiCategoyDetailListByBiCategoryIid(Convert.ToInt64(ddlBICategory.SelectedValue));
                DropDownListHelper.Bind(ddlBiCategoryDetail, biCategoryDetailList, "Name", "IID");
                ddlBiCategoryDetail.Items.Insert(0, new ListItem("--Select--", "-1"));
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private void LoadDropDownBiCategory()
        {
            try
            {
                var biCategory = _biReceiverRt.GetBiCategoryList();
                DropDownListHelper.Bind(ddlBICategory, biCategory, "Name", "IID");
                ddlBICategory.Items.Insert(0, new ListItem("--Select--", "-1"));
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
        #endregion load drop down

        #endregion private methods


    }
}