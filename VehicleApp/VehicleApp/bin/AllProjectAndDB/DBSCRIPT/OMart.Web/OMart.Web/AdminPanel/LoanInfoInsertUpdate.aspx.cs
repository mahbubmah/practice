using BLL.Basic;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace OMart.Web.AdminPanel
{
    public partial class LoanInfoInsertUpdate : System.Web.UI.Page
    {
        #region private variable declaration

        private readonly LoanInfoRT _LoanInfoRT;
        private int IID = default(int);
        private const string seLoanFeatureColl = "seLoanFeatureColl";
        private const string sessLoanFeature = "seLoanFeature";
        int lvRowCount = 0;
        int currentPage = 0;

        #endregion private variable declaration

        #region protected method
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    LoadDropDownCompanyName();
                    LoadDropDownLoanType();
                    LoadDropDownLoanAmtYearSchedule();
                    Session[seLoanFeatureColl] = null;
                    var requestId = Request.QueryString["IID"];
                    bool reqIDIsValid = Int32.TryParse(requestId, out IID);
                    if (reqIDIsValid)
                    {
                        FillLoanInfoIntoUI();
                    }
                }
                catch (Exception ex)
                {
                    labelMessage.Text = "Error : " + ex.Message;
                    labelMessage.ForeColor = System.Drawing.Color.Red;
                }
            }

        }
        public LoanInfoInsertUpdate()
        {
            this._LoanInfoRT = new LoanInfoRT();
        }
        protected void btnAddFeature_Click(object sender, EventArgs e)
        {
            List<LoanFeature> featureColl = null;
            string description = string.Empty;
            lblMessageFeature.Text = string.Empty;
            if (IsValidFeature())
            {
                return;
            }
            if (Session[seLoanFeatureColl] == null)
            {
                featureColl = new List<LoanFeature>();
            }
            else
            {
                featureColl = (List<LoanFeature>)Session[seLoanFeatureColl];
            }
            foreach (LoanFeature feature in featureColl)
            {
                if (feature.Description == txtDesFeature.Text.Trim())
                {
                    description = "Description";
                    break;
                }
            }
            if (description == "Description")
            {
                lblMessageFeature.Text = "Description already exists";
                lblMessageFeature.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                LoanFeature feature = CreateLoanFeature();
                featureColl.Add(feature);
                Session[seLoanFeatureColl] = featureColl;
                LoadLoanFeature();
                txtDesFeature.Text = string.Empty;
            }
        }

        protected void lvFeature_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            try
            {
                lblMessageFeature.Text = string.Empty;
                if (e.CommandName.Equals("DeleteInfo"))
                {
                    if (Session[seLoanFeatureColl] != null)
                    {
                        List<LoanFeature> loanFeatureColl = (List<LoanFeature>)Session[seLoanFeatureColl];
                        loanFeatureColl.RemoveAll(fe => fe.Description.Equals(e.CommandArgument));
                        Session[seLoanFeatureColl] = loanFeatureColl;
                        LoadLoanFeature();
                    }
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void dataPagerFeature_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    LoadLoanFeature();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btn_CreateOrEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int loanInfiID = 0;
                labelMessage.Text = string.Empty;
                bool reqIDIsValid = Int32.TryParse(Request.QueryString["IID"], out IID);

                if (IsValidField())
                {
                    return;
                }
                LoanInfo loanInfo = CreateLoanInfo();
                if (IID <= 0)
                {
                    loanInfo.CreatedBy = Convert.ToInt64(Session["UserID"]);
                    loanInfo.CreatedDate = DateTime.Now;
                    loanInfo.IsRemoved = false;
                    List<LoanFeature> featureList = (List<LoanFeature>)Session[seLoanFeatureColl];
                    if (featureList != null)
                    {
                        string loanInfoAndFeatureChildXML = ConversionXML.ConvertObjectToXML<LoanInfo, LoanFeature>(loanInfo, featureList, string.Empty);
                        loanInfiID = LoanInfoRT.InsertLoanInfoAndFeatureChildXML(loanInfoAndFeatureChildXML);

                        if (loanInfiID == -100)
                        {
                            labelMessage.Text = "Network connection fail ... Please try again..!!";
                            labelMessage.ForeColor = System.Drawing.Color.Red;
                            labelMessage.Focus();
                        }
                        else if (loanInfiID == -101)
                        {
                            labelMessage.Text = "Network connection fail ... Please try again..!!";
                            labelMessage.ForeColor = System.Drawing.Color.Red;
                            labelMessage.Focus();
                        }
                        // _LoanInfoRT.AddLoanInfoAndFeature(loanInfo, featureList);

                        ClearField();

                        labelMessage.Text = "Information has been inserted successfully.";
                        labelMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    { 
                        using(LoanInfoRT rt = new LoanInfoRT())
                        {
                            rt.AddLoanInfo(loanInfo);
                            labelMessage.Text = "Information has been inserted successfully.";
                            labelMessage.ForeColor = System.Drawing.Color.Green;
                            ClearField();
                            
                        }
                    }
                }
                else
                {
                    LoanInfo objLoanInfo = _LoanInfoRT.GetLoanInfoByIID(IID);

                    if (objLoanInfo != null)
                    {
                        loanInfo.CreatedBy = objLoanInfo.CreatedBy;
                        loanInfo.CreatedDate = objLoanInfo.CreatedDate;
                        loanInfo.IsRemoved = objLoanInfo.IsRemoved;
                        loanInfo.IID = objLoanInfo.IID;

                        loanInfo.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                        loanInfo.ModifiedDate = DateTime.Now;
                        List<LoanFeature> lst = new List<LoanFeature>();
                        if (Session[seLoanFeatureColl] != null)
                        {
                            List<LoanFeature> featureList = (List<LoanFeature>)Session[seLoanFeatureColl];

                            foreach (LoanFeature feature in featureList)
                            {
                                LoanFeature fe = new LoanFeature();
                                fe.Description = feature.Description;
                                fe.IsRemoved = false;
                                fe.CreatedBy = objLoanInfo.CreatedBy;
                                fe.CreatedDate = objLoanInfo.CreatedDate;
                                fe.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                                fe.ModifiedDate = DateTime.Now;
                                lst.Add(fe);
                            }
                        }
                        _LoanInfoRT.UpdateLoanInfoAndLoanFeature(loanInfo, lst);
                        ClearField();
                        Session[seLoanFeatureColl] = null;
                        labelMessage.Text = "Information has been updated successfully.";
                        labelMessage.ForeColor = System.Drawing.Color.Green;
                    }
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //ClearField();
            try
            {
                Response.Redirect("~/AdminPanel/LoanInfoDisplay");
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lvFeature_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            labelMessage.Text = string.Empty;
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void lvFeature_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    LoadLoanFeature();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        #endregion protected method


        #region  private method
        private void LoadDropDownCompanyName()
        {
            try
            {
                using (CompanyInfoRT receverTransfer = new CompanyInfoRT())
                {
                    List<CompanyInfo> companyNameList = new List<CompanyInfo>();
                    companyNameList = receverTransfer.GetAllCompanyInfos();
                    DropDownListHelper.Bind<CompanyInfo>(ddlCompanyName, companyNameList, "Name", "IID", EnumCollection.ListItemType.Company);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        private void LoadDropDownLoanAmtYearSchedule()
        {
            try
            {
                using (LoanAmntYrScdleRT receverTransfer = new LoanAmntYrScdleRT())
                {
                    List<LoanAmtYearSchedule> cLoanAmtYearScheduleList = new List<LoanAmtYearSchedule>();
                    cLoanAmtYearScheduleList = receverTransfer.GetAllLoanAmntYrScdle();
                    DropDownListHelper.Bind<LoanAmtYearSchedule>(ddlLoanAmtYearScheduleID, cLoanAmtYearScheduleList, "Duration", "IID", EnumCollection.ListItemType.LoanAmtYearSchedule);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        private void LoadDropDownLoanType()
        {
            try
            {

                ddlLoanType.Items.Add("--Select Loan Type--");
                DropDownListHelper.Bind(ddlLoanType, EnumHelper.EnumToList<EnumCollection.LoanType>());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private void FillLoanInfoIntoUI()
        {
            int days = 0;
            try
            {
                LoanInfo loan = _LoanInfoRT.GetLoanInfoByIID(IID);
                if (loan != null)
                {
                    ddlCompanyName.SelectedValue = loan.CompanyInfoID.ToString();
                    ddlLoanType.SelectedValue = loan.LoanTypeID.ToString();
                    txtTotalAmount.Text = loan.TotalAmount.ToString();
                    txtTotalPaymentAmount.Text = loan.PaymentAmt.ToString();
                    txtMonthlyReturnAmount.Text = loan.MonthlyReturnAmount.ToString();
                    txtTotalReturnAmount.Text = loan.TotalReturnAmount.ToString();
                    txtDescription.Text = loan.Description;
                    txtTotalInstallmentNo.Text = loan.TotalInstallmentNo.ToString();                  
                    days = Convert.ToInt32((loan.PostLastDisplayDate - loan.PostAdDate).Days);
                   
                    txtPostLastDisplayDate.Text = days <= 0 ? "0" : days.ToString();
                    ddlLoanAmtYearScheduleID.SelectedValue = loan.LoanAmtYearScheduleID.ToString();
                    chkIsverified.Checked = Convert.ToBoolean(loan.IsVerified);
                    txtRedirectUrl.Text = loan.RedirectUrl;
                    chkIsPostAdExtended.Checked = Convert.ToBoolean(loan.IsPostAdExtended);
                    chkIsRemoved.Checked = Convert.ToBoolean(loan.IsRemoved);
                    DisplayFeature(loan.IID);
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void DisplayFeature(Int64? LoanID)
        {
            try
            {
                Session[seLoanFeatureColl] = null;
                List<LoanFeature> featureList = new List<LoanFeature>();
                featureList = _LoanInfoRT.GetAllFeatureByLoanIID(LoanID);
                lvFeature.DataSource = featureList;
                Session[seLoanFeatureColl] = featureList;
                lvFeature.DataBind();
            }
            catch (Exception ex)
            {

            }
        }

        private LoanFeature CreateLoanFeature()
        {
            Session["UserID"] = "1";
            LoanFeature feature = new LoanFeature();
            feature.Description = txtDesFeature.Text.Trim();
            feature.IsRemoved = false;
            feature.CreatedBy = Convert.ToInt64(Session["UserID"]);
            feature.CreatedDate = DateTime.Now;
            return feature;
        }

        private void LoadLoanFeature()
        {
            try
            {
                lvFeature.DataSource = (List<LoanFeature>)Session[seLoanFeatureColl];
                lvFeature.DataBind();
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void ClearField()
        {
            ddlCompanyName.SelectedIndex = 0;
            ddlLoanAmtYearScheduleID.SelectedIndex = 0;
            ddlLoanType.SelectedIndex = 0;
            txtTotalAmount.Text = string.Empty;
            txtTotalPaymentAmount.Text = string.Empty;
            txtTotalReturnAmount.Text = string.Empty;
            txtTotalInstallmentNo.Text = string.Empty;
            txtRedirectUrl.Text = string.Empty;
            txtPostLastDisplayDate.Text = string.Empty;
            txtDescription.Text = string.Empty;
            chkIsPostAdExtended.Checked = false;
            chkIsRemoved.Checked = false;
            chkIsverified.Checked = false;
            Session[seLoanFeatureColl] = null;
            LoadLoanFeature();
        }

        private LoanInfo CreateLoanInfo()
        {
            Session["UserID"] = "1";
            LoanInfo loanInfo = new LoanInfo();
            try
            {
                loanInfo.CompanyInfoID = Convert.ToInt32(ddlCompanyName.SelectedValue.ToString());
                loanInfo.LoanTypeID = Convert.ToInt32(ddlLoanType.SelectedValue.ToString());
                loanInfo.TotalAmount = Convert.ToDecimal(txtTotalAmount.Text.Trim());
                loanInfo.PaymentAmt = Convert.ToDecimal(txtTotalPaymentAmount.Text.Trim());
                loanInfo.MonthlyReturnAmount = Convert.ToDecimal(txtMonthlyReturnAmount.Text.Trim());
                loanInfo.TotalReturnAmount = Convert.ToDecimal(txtTotalReturnAmount.Text.Trim());
                loanInfo.PostAdDate = DateTime.Now;
                loanInfo.PostLastDisplayDate = DateTime.Today.AddDays(Convert.ToInt16(txtPostLastDisplayDate.Text.Trim()));//Convert.ToDateTime(txtPostLastDisplayDate.Text);
                loanInfo.Description = txtDescription.Text.Trim();
                loanInfo.TotalInstallmentNo = Convert.ToInt32(txtTotalInstallmentNo.Text.Trim());
                loanInfo.LoanAmtYearScheduleID = Convert.ToInt32(ddlLoanAmtYearScheduleID.SelectedValue.ToString());
                loanInfo.RedirectUrl = txtRedirectUrl.Text.Trim();

                if (chkIsverified.Checked)
                {
                    loanInfo.IsVerified = true;
                }
                else
                {
                    loanInfo.IsVerified = false;
                }
                if (chkIsRemoved.Checked)
                {
                    loanInfo.IsRemoved = true;
                }
                else
                {
                    loanInfo.IsRemoved = false;
                }
                if (chkIsPostAdExtended.Checked)
                {
                    loanInfo.IsPostAdExtended = true;
                }
                else
                {
                    loanInfo.IsPostAdExtended = false;
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return loanInfo;
        }

        private bool IsValidField()
        {
            if (ddlCompanyName.SelectedValue == "-1")
            {
                labelMessage.Text = "Please select a company name !!!";
                labelMessage.ForeColor = System.Drawing.Color.Red;
                return true;
            }
            if (ddlLoanType.SelectedIndex == 0)
            {
                labelMessage.Text = "Please select a Loan Type !!!";
                labelMessage.ForeColor = System.Drawing.Color.Red;
                return true;
            }
            if (ddlLoanType.SelectedValue == "-1")
            {
                labelMessage.Text = "Please select a Loan Type !!!";
                labelMessage.ForeColor = System.Drawing.Color.Red;
                return true;
            }
            if (txtTotalAmount.Text.Trim().Length <= 0)
            {
                labelMessage.Text = "Please Enter Total Amount !!!";
                labelMessage.ForeColor = System.Drawing.Color.Red;
                return true;
            }
            if (txtTotalPaymentAmount.Text.Trim().Length <= 0)
            {
                labelMessage.Text = "Please Enter Total Payment Amount !!!";
                labelMessage.ForeColor = System.Drawing.Color.Red;
                return true;
            }
            if (txtMonthlyReturnAmount.Text.Trim().Length <= 0)
            {
                labelMessage.Text = "Please Enter Monthly Return Amount !!!";
                labelMessage.ForeColor = System.Drawing.Color.Red;
                return true;
            }
            if (txtTotalReturnAmount.Text.Trim().Length <= 0)
            {
                labelMessage.Text = "Please Enter Total Return Amount !!!";
                labelMessage.ForeColor = System.Drawing.Color.Red;
                return true;
            }
            if (txtTotalInstallmentNo.Text.Trim().Length <= 0)
            {
                labelMessage.Text = "Please Enter Total Installment No. !!!";
                labelMessage.ForeColor = System.Drawing.Color.Red;
                return true;
            }
            if (txtPostLastDisplayDate.Text.Trim().Length <= 0)
            {
                labelMessage.Text = "Please Enter Post Last Display Day!!!";
                labelMessage.ForeColor = System.Drawing.Color.Red;
                return true;
            }
            if (Session[seLoanFeatureColl] == null)
            {
                labelMessage.Text = "Please add at least one feature !!!";
                labelMessage.ForeColor = System.Drawing.Color.Red;
                return true;
            }
            return false;
        }

        private bool IsValidFeature()
        {
            if (txtDesFeature.Text.Trim().Length <= 0)
            {
                lblMessageFeature.Text = "Pealse give description of feature !!!";
                lblMessageFeature.ForeColor = System.Drawing.Color.Red;
                return true;
            }
            return false;
        }

        #endregion private method


    }
}