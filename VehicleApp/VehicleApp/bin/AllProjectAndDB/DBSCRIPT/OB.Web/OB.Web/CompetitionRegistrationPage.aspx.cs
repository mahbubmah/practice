using System.Drawing;
using System.IO;
using BLL.Basic;
using Microsoft.Ajax.Utilities;
using OB.BLL;
using OB.BLL.Basic;
using OB.DAL;
using OB.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace OB.Web
{
    public partial class CompetitionRegistrationPage : System.Web.UI.Page
    {
        private const string sessUserRegistration = "seUserRegistration";
        private const string sessContestantId = "ContestantID";
        private readonly CompetitionInfoRT _competitionInfoRt;
        private Int64 CompIid = default(Int64);
        private readonly string _visitorLogPath;
        private string _pageLogPath;

        public CompetitionRegistrationPage()
        {
            this._visitorLogPath = Server.MapPath("~/Log file/VisitorlogFileWriting.txt");
            _competitionInfoRt = new CompetitionInfoRT();
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
                    LoadUserInfo();
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private void LoadUserInfo()
        {
            try
            {
                if (Session[sessContestantId] != null)
                {


                    var objContestant = _competitionInfoRt.GetContestantByIid(Convert.ToInt64(Session[sessContestantId]));
                    if (objContestant != null)
                    {
                        divUserSignUpForm.Visible = false;
                        btn_CreateAccountAndRegisterCompetetion.Text = "Submit";

                        lbContestantEmail.Text = "<b>Email:<b> " + objContestant.LoginName;
                        lbContestantPhoneNo.Text = objContestant.PhoneNo.IsNullOrWhiteSpace() ? "Phone No. : Not available" : "Phone No. " + objContestant.PhoneNo;
                        lbContestantProfession.Text = "Profession: " + objContestant.Professions.Name;
                        lbContestantName.Text = "<b>Name:<b> " + objContestant.UserName;

                    }
                }
                else
                {
                    divUserDetails.Visible = false;
                    LoadProfessionDropDown();
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        protected void btn_CreateAccountAndRegisterCompetetion_Click(object sender, EventArgs e)
        {
            try
            {
                bool isCompIdValid = false;
                bool isCompEditIdValid = false;
                var contestant = new Contestant();

                if (Request.QueryString["comID"] != null)
                {
                    isCompIdValid = Int64.TryParse(StringCipher.Decrypt(Request.QueryString["comID"]), out CompIid);
                }
                else
                {
                    isCompEditIdValid = Int64.TryParse(StringCipher.Decrypt(Request.QueryString["comEditID"]), out CompIid);
                }
                if (isCompIdValid)
                {
                    contestant = CreateContestant();
                }
                else
                {
                    contestant = _competitionInfoRt.GetContestantByIid(Convert.ToInt64(Session[sessContestantId]));
                }
                var competitionRegistration = CreateOrUpdateCompetitionRegistration(contestant.IID);

                if (contestant!=null)
                {
                   Response.Redirect("ContestantHome",false);
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private Contestant CreateContestant()
        {
            try
            {
                if (Session[sessContestantId] != null)
                {
                    var contestant = _competitionInfoRt.GetContestantByIid(Convert.ToInt64(Session[sessContestantId]));
                    return contestant;
                }
                else
                {
                    var contestant = new Contestant();
                    if (!DropDownProfessionType.SelectedValue.IsNullOrWhiteSpace() || DropDownProfessionType.SelectedValue!="-1")
                    {
                        contestant.ProfessionID = Convert.ToInt32(DropDownProfessionType.SelectedValue);
                    }
                    else
                    {
                        lblMessage.Text = "Please select profession";
                        lblMessage.ForeColor = Color.Red;
                        return null;
                    }
                  

                    contestant.UserName = txtFirstName.Text + " " + txtLastname.Text;
                    if (txtConfirmPassword.Text == txtPassword.Text)
                    {
                        contestant.LoginPassword =StringCipher.Encrypt(txtPassword.Text);
                    }
                    else
                    {
                        lblMessage.Text = "Password doesn't match";
                        lblMessage.ForeColor = Color.Red;
                        return null;
                    }
                    if (txtConEmailAdd.Text == txtEmail.Text)
                    {
                        contestant.LoginName = txtEmail.Text;
                    }
                    else
                    {
                        lblMessage.Text = "Email doesn't match";
                        lblMessage.ForeColor = Color.Red;
                        return null;
                    }

                    var findUser = _competitionInfoRt.FindContestant(contestant.LoginName);
                    if (findUser!=null)
                    {
                        lblMessage.Text = "Email already exist..";
                        return null;
                    }

                    contestant.IsActiveUser = true;
                    contestant.IsEmail = chkEmail.Checked;
                    contestant.IsRemoved = false;
                    contestant.CreatedBy = Convert.ToInt32(Session[sessContestantId]);
                    contestant.CreatedDate = GlobalRT.GetServerDateTime();
                    _competitionInfoRt.AddContestant(contestant);

                    Session["LoginStatus"] = "Log out";
                    Session["UserName"] = contestant.UserName;
                    Session[sessContestantId] = contestant.IID;
                    return contestant;
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
            return null;
        }

        private bool IsValidField()
        {
            if (txtPassword.Text == string.Empty || txtPassword.Text == "")
            {
                lblUserRegistration.Text = "Please enter your password";
                lblUserRegistration.ForeColor = System.Drawing.Color.Red;
                return false;
            }
            if (txtConfirmPassword.Text == "" || txtConfirmPassword.Text == string.Empty)
            {
                lblUserRegistration.Text = "Please comfirm your password";
                lblUserRegistration.ForeColor = System.Drawing.Color.Red;
                return false;
            }
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                lblUserRegistration.Text = "password doesn't match";
                lblUserRegistration.ForeColor = System.Drawing.Color.Red;
                return false;
            }
            if (txtPassword.Text.Length < 6)
            {
                lblUserRegistration.Text = "password too short, enter at least 6 character";
                lblUserRegistration.ForeColor = System.Drawing.Color.Red;
                return false;
            }

            return true;

        }
        private int GetQueryStringCompetitionID()
        {
            int competitionID = default(int);
            try
            {
                if (!string.IsNullOrEmpty(Request.QueryString["comID"]))
                {
                    competitionID = Convert.ToInt32(StringCipher.Decrypt(Request.QueryString["comID"].ToString()));
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
            return competitionID;
        }

        private CompetitionRegistration CreateOrUpdateCompetitionRegistration(Int64 contestantId)
        {
            try
            {

                if (CompIid > 0)
                {
                    var competetionRegistration = _competitionInfoRt.GetCompetitonRegistrationByCompIdAndContestantId(CompIid, contestantId);
                    if (competetionRegistration != null)
                    {


                        if (fuCompContestantFile.HasFile)
                        {
                            string fileName = competetionRegistration.CompetitionID + "_" +
                                              competetionRegistration.ContestantId + "_" + Path.GetFileNameWithoutExtension(fuCompContestantFile.FileName);
                            if (!competetionRegistration.UploadFile.IsNullOrWhiteSpace())
                            {
                                File.Delete(Server.MapPath(competetionRegistration.UploadFile));
                            }
                            FileUploadHelper.Bind(fuCompContestantFile,Server.MapPath("~/Image/Compitition/ContestantFile/"), fileName);
                            competetionRegistration.UploadFile = "~/Image/Compitition/ContestantFile/" + fileName+Path.GetExtension(fuCompContestantFile.FileName);

                            competetionRegistration.ModifiedBy = Convert.ToInt64(Session[sessContestantId]);
                            competetionRegistration.ModifiedDate = GlobalRT.GetServerDateTime();
                            competetionRegistration.IsRemoved = false;
                            _competitionInfoRt.UpdateCompetetionRegistration(competetionRegistration);

                        }

                    }
                    else
                    {
                        competetionRegistration = new CompetitionRegistration();
                        competetionRegistration.CompetitionID = CompIid;
                        competetionRegistration.ContestantId = contestantId;
                        competetionRegistration.CreatedBy = Convert.ToInt64(Session[sessContestantId]);
                        competetionRegistration.CreatedDate = GlobalRT.GetServerDateTime();

                        if (fuCompContestantFile.HasFile)
                        {
                            string fileName = competetionRegistration.CompetitionID + "_" +
                                              competetionRegistration.ContestantId + "_" +Path.GetFileNameWithoutExtension(fuCompContestantFile.FileName) ;

                            FileUploadHelper.Bind(fuCompContestantFile, Server.MapPath("~/Image/Compitition/ContestantFile/"), fileName);
                            competetionRegistration.UploadFile = "~/Image/Compitition/ContestantFile/" + fileName + Path.GetExtension(fuCompContestantFile.FileName);
                        }

                        competetionRegistration.IsRemoved = false;
                        _competitionInfoRt.AddCompetitionRegistration(competetionRegistration);
                    }
                    return competetionRegistration;
                }
                else
                {
                    lblUserRegistration.Text = "Error : plese contact with administrator";
                    lblUserRegistration.ForeColor = System.Drawing.Color.Red;
                }
                
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
            return null;
        }

        public void ClearField()
        {
            txtFirstName.Text = string.Empty;
            txtLastname.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;
            txtContactNo.Text = string.Empty;
            chkEmail.Checked = false;
            DropDownProfessionType.SelectedIndex = 0;
            txtConEmailAdd.Text = string.Empty;

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                ClearField();
                Response.Redirect("Default",false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }


        #region private method

        private void LoadProfessionDropDown()
        {
            try
            {
                using (ProfessionRT receverTransfer = new ProfessionRT())
                {
                    var professionList = receverTransfer.GetAllProfessionListForDropDown();

                    DropDownListHelper.Bind<Professions>(DropDownProfessionType, professionList, "Name", "IID");
                    DropDownProfessionType.Items.Insert(0, new ListItem("Select profession", "-1"));
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
        #endregion private method



        protected void btnUplaodFile_OnClick(object sender, EventArgs e)
        {

        }
    }
}