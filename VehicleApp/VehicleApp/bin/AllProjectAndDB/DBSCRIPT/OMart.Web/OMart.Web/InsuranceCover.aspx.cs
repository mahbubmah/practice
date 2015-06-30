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
    public partial class InsuranceCover : System.Web.UI.Page
    {
        private readonly InsuranceCoverRT _insuranceCoverRt;
        private const string sessSearchLiCoverMoney = "seSearchLiCoverMoney";
        private const string sessSearchNumberOfYear = "seSearchLiNumberOfYear";
        private const string sessSearchLiHaveCriticalIllness = "seSearchLiHaveCriticalIllness";
        private const string sessSeachLiApplicantIID = "sessSeachLiApplicantIID";
        private readonly string _visitorLogPath;
        private string _pageLogPath;

        public InsuranceCover()
        {
            this._visitorLogPath = Server.MapPath("~/Log file/VisitorlogFileWriting.txt");
            _insuranceCoverRt = new InsuranceCoverRT();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                string pageName = Path.GetFileName(Request.PhysicalPath);
                _pageLogPath = Server.MapPath("~/Log file/" + pageName + ".txt");
                if (!IsPostBack)
                {
                    LogFileHelper.VisitorLogFileWritten(_visitorLogPath);
                    LoadDropDownIsSmoke();
                    LoadDropDownForProfession();
                    LoadContactDetails();
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }

        }

        private void LoadContactDetails()
        {
            try
            {
                if (Session["UserID"]!=null)
                {
                    using (UserInformationRT aUserInformationRt = new UserInformationRT())
                    {
                        var applicantContactDetails = aUserInformationRt.GetUserInfoByID(Convert.ToInt32(Session["UserID"]));
                        txtEmail.Text = applicantContactDetails.LoginName;
                        if (applicantContactDetails.PhoneNo!=null)
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

        private void LoadDropDownForProfession()
        {
            try
            {
                var professionList = _insuranceCoverRt.GetProfessionsForDropDown();
                DropDownListHelper.Bind(dropDownProfession, professionList, "Name", "IID", EnumCollection.ListItemType.Profession);
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private void LoadDropDownIsSmoke()
        {
            try
            {
                var list = EnumHelper.EnumCamelSpaceToList<EnumCollection.SmokerType>();
                DropDownListHelper.Bind(dropDownIsSmoke, list, EnumCollection.ListItemType.SmokerType);
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private string BusinessLogicValidation()
        {
            string msg = string.Empty;
            if (txtPhoneNo.Text.IsNullOrWhiteSpace() && (chkConfByPhone.Checked || chkConfByText.Checked))
            {
                msg = "Please enter your phone no. to get informed by phone.";
                return msg;
            }

            if (txtCoverMoney.Text.IsNullOrWhiteSpace())
            {
                msg = "Please Enter Cover money.";
                return msg;
            }
            if (txtNumberOfYear.Text.IsNullOrWhiteSpace())
            {
                msg = "Please enter no. of year";
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
            if (dropDownIsSmoke.SelectedValue.IsNullOrWhiteSpace() || dropDownIsSmoke.SelectedValue == "-1")
            {
                msg = "Please select your smoking status.";
                return msg;
            }
            if (dropDownProfession.SelectedValue.IsNullOrWhiteSpace() || dropDownProfession.SelectedValue == "-1")
            {
                msg = "Please select your profession.";
                return msg;
            }
            return msg;
        }

        protected void btnShowResult_OnClick(object sender, EventArgs e)
        {
            try
            {
                string message = BusinessLogicValidation();
                if (message == string.Empty || message.IsNullOrWhiteSpace())
                {
                    Applicant applicant = CreateApplicant();
                    if (applicant != null)
                    {
                        _insuranceCoverRt.AddAppicant(applicant);
                        if (applicant.IID > 0)
                        {
                            Session[sessSeachLiApplicantIID] = applicant.IID;
                            Session[sessSearchLiCoverMoney] =Convert.ToDecimal(txtCoverMoney.Text);
                            Session[sessSearchNumberOfYear] =Convert.ToInt32(txtNumberOfYear.Text);
                            if (rdCrIll.SelectedValue == "0")
                            {
                                Session[sessSearchLiHaveCriticalIllness] = false;
                            }
                            else
                            {
                                Session[sessSearchLiHaveCriticalIllness] = true;
                            }
                        }
                    }
                    else
                    {
                        lblMessage.Text = "Error: Please insert the fields correctly";
                        lblMessage.ForeColor = Color.Red;
                        return;
                    }
                    
                }
                else
                {
                    lblMessage.Text = message;
                    lblMessage.ForeColor = Color.Red;
                    return;
                }
                Response.Redirect("InsuranceQuotes");
              
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
                if (rdHaveAdditionalJob.SelectedValue == "0")
                {
                    applicant.HaveAdditionalJob = false;
                }
                else
                {
                    applicant.HaveAdditionalJob = true;
                }
                applicant.FullName = txtFirstName.Text + " " + txtLastName.Text;
                applicant.GenderID = Convert.ToInt32(rdGender.SelectedValue);
                applicant.SmokingHistoryID = Convert.ToInt32(dropDownIsSmoke.SelectedValue);
                applicant.ProfessionID = Convert.ToInt32(dropDownProfession.SelectedValue);

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
    }
}