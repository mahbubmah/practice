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
//using OMart.Web.AdminPanel.Report;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace OMart.Web.AdminPanel
{
    public partial class MortgageInsertUpdate : System.Web.UI.Page
    {
        #region private variable declaration
        private readonly MortgageRT _mortgageRt;
        private long IID = default(Int64);

        private const string seInterestRateColl = "seInterestRateColl";
        private const string sessInterestRate = "seInterestRate";
        int lvRowCount = 0;
        int currentPage = 0;
        #endregion private variable declaration

        public MortgageInsertUpdate()
        {
            _mortgageRt = new MortgageRT();
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                btnReport.Enabled = false;
                if (!IsPostBack)
                {
                    Session[seInterestRateColl] = null;
                    LoadDropDownCompanyInfo();
                    LoadDropDownInterestRateType();
                    LoadDropDownMortgageType();
                    LoadDropDownOparetionType();
                    LoadDropDownPaymentType();
                    LoadDropDownTermYear();
                    var requestId = Request.QueryString["IID"];
                    bool reqIDIsValid = Int64.TryParse(requestId, out IID);
                    if (reqIDIsValid)
                    {
                        ShowMortgageData();
                    }

                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }


        #region private methods


        private void ShowMortgageData()
        {
            int days = 0;
            try
            {
                Mortgage objMorgage = _mortgageRt.GetMortgageById(IID);
                if (objMorgage != null)
                {

                    dropDownCompanyInfo.SelectedValue = objMorgage.CompanyInfoID.ToString();
                    // dropDownInterestRateType.SelectedValue = objMorgage.InterestRateTypeID.ToString();
                    dropDownMortgageType.SelectedValue = objMorgage.TypeID.ToString();
                    dropDownOparationType.SelectedValue = objMorgage.OperationTypeID.ToString();
                    dropDownPaymentType.SelectedValue = objMorgage.PaymentTypeID.ToString();

                    if (objMorgage.TermYearID != null)
                    {
                        dropDownTermYear.SelectedValue = objMorgage.TermYearID.ToString();
                    }

                    days = (objMorgage.PostLastDisplayDate - objMorgage.PostAdDate).Days;

                    txtPostLastDisplayDate.Text = days <= 0 ? "0" : days.ToString();//objMorgage.PostLastDisplayDate.ToString("dd/MM/yyyy");

                    txtAPR.Text = objMorgage.APR != null ? objMorgage.APR.ToString() : string.Empty;
                    txtDescription.Text = objMorgage.Description ?? string.Empty;
                    txtFeeOrCharge.Text = objMorgage.FeeOrCharge != null ? objMorgage.FeeOrCharge.ToString() : string.Empty;
                    txtLTV.Text = objMorgage.LTV != null ? objMorgage.LTV.ToString() : string.Empty;
                    txtPropertyValuMaxAmt.Text = objMorgage.PropertyValueMaxAmt != null ? objMorgage.PropertyValueMaxAmt.ToString() : string.Empty;
                    txtPropertyValuMinAmt.Text = objMorgage.PropertyValueMinAmt != null ? objMorgage.PropertyValueMinAmt.ToString() : string.Empty;
                    txtMonthlyInstallmentAmount.Text = objMorgage.MonthlyInstallmentAmt != null ? objMorgage.MonthlyInstallmentAmt.ToString() : string.Empty;
                    chkIsPostAdExtended.Checked = objMorgage.IsPostAdExtended != null ? (bool)objMorgage.IsPostAdExtended : false;
                    txtRedirectUrl.Text = objMorgage.RedirectUrl;
                    DisplayMortgageInterestType(objMorgage.IID);

                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void DisplayMortgageInterestType(Int64? mortgageID)
        {
            try
            {
                Session[seInterestRateColl] = null;
                List<MortgageInterestRate> typeList = new List<MortgageInterestRate>();
                typeList = _mortgageRt.GetAllInterestTypeByMortgageIID(mortgageID);
                lvMortgageInterestRate.DataSource = typeList;
                Session[seInterestRateColl] = typeList;
                lvMortgageInterestRate.DataBind();
            }
            catch (Exception ex)
            {

            }
        }

        private string BusinessLogicValidation()
        {
            string message = string.Empty;
            bool reqIDIsValid = Int64.TryParse(Request.QueryString["IID"], out IID);

            if (dropDownCompanyInfo.SelectedValue.ToString() == "-1")
            {
                message = "Please select company";
                return message;
            }
            if (dropDownOparationType.SelectedValue.ToString() == "-1")
            {
                message = "Please select mortgage type";
                return message;
            }
            if (dropDownMortgageType.SelectedValue.ToString() == "-1")
            {
                message = "Please select mortgage operation type";
                return message;
            }
            if (dropDownPaymentType.SelectedValue.ToString() == "-1")
            {
                message = "Please select payment type";
                return message;
            }
            //if (dropDownTermYear.SelectedValue.ToString()=="-1")
            //{
            //    message = "Please select interest rate type";
            //    return message;
            //}

            if (txtPostLastDisplayDate.Text.IsNullOrWhiteSpace())
            {
                message = "Please select post last display date";
                return message;
            }

            return string.Empty;
        }

        private Mortgage CreateMortgage()
        {
            Session["UserID"] = "1";
            Mortgage mortgage = new Mortgage();
            try
            {
                if (IID >= 0)
                {
                    mortgage.IID = IID;
                }


                mortgage.PostAdDate = GlobalRT.GetServerDateTime();

                if (!txtPostLastDisplayDate.Text.IsNullOrWhiteSpace())
                {
                    mortgage.PostLastDisplayDate = DateTime.Today.AddDays(Convert.ToInt32(txtPostLastDisplayDate.Text));
                }

                mortgage.CompanyInfoID = Convert.ToInt32(dropDownCompanyInfo.SelectedValue);
                mortgage.TypeID = Convert.ToInt32(dropDownMortgageType.SelectedValue);
                mortgage.OperationTypeID = Convert.ToInt32(dropDownOparationType.SelectedValue);
                // mortgage.InterestRateTypeID = Convert.ToInt32(dropDownInterestRateType.SelectedValue);
                mortgage.PaymentTypeID = Convert.ToInt32(dropDownPaymentType.SelectedValue);
                mortgage.RedirectUrl = txtRedirectUrl.Text.Trim();

                if (dropDownTermYear.SelectedValue != "-1")
                {
                    mortgage.TermYearID = Convert.ToInt32(dropDownTermYear.SelectedValue);
                }


                if (!txtDescription.Text.IsNullOrWhiteSpace())
                {
                    mortgage.Description = txtDescription.Text;
                }
                if (!txtFeeOrCharge.Text.IsNullOrWhiteSpace())
                {
                    mortgage.FeeOrCharge = Convert.ToDecimal(txtFeeOrCharge.Text);
                }
                if (!txtLTV.Text.IsNullOrWhiteSpace())
                {
                    mortgage.LTV = Convert.ToDouble(txtLTV.Text);
                }
                if (!txtMonthlyInstallmentAmount.Text.IsNullOrWhiteSpace())
                {
                    mortgage.MonthlyInstallmentAmt = Convert.ToDecimal(txtMonthlyInstallmentAmount.Text);
                }
                if (!txtPropertyValuMaxAmt.Text.IsNullOrWhiteSpace())
                {
                    mortgage.PropertyValueMaxAmt = Convert.ToDecimal(txtPropertyValuMaxAmt.Text);
                }
                if (!txtAPR.Text.IsNullOrWhiteSpace())
                {
                    mortgage.PropertyValueMinAmt = Convert.ToDecimal(txtPropertyValuMinAmt.Text);
                }

                if (!txtAPR.Text.IsNullOrWhiteSpace())
                {
                    mortgage.APR = Convert.ToDouble(txtAPR.Text);
                }


                mortgage.IsPostAdExtended = chkIsPostAdExtended.Checked;


            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return mortgage;
        }
        private void ClearData()
        {
            txtPostLastDisplayDate.Text = string.Empty;
            txtAPR.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtFeeOrCharge.Text = string.Empty;
            txtLTV.Text = string.Empty;
            txtPropertyValuMaxAmt.Text = string.Empty;
            txtPropertyValuMinAmt.Text = string.Empty;
            txtMonthlyInstallmentAmount.Text = string.Empty;

            chkIsPostAdExtended.Checked = false;


            dropDownCompanyInfo.SelectedIndex = 0;
            ddlInterestRateType.SelectedIndex = 0;
            dropDownMortgageType.SelectedIndex = 0;
            dropDownOparationType.SelectedIndex = 0;
            dropDownPaymentType.SelectedIndex = 0;
            dropDownTermYear.SelectedIndex = 0;
            txtRedirectUrl.Text = string.Empty;
            txtInterestRate.Text = string.Empty;
            txtUptoYear.Text = string.Empty;
            txtNote.Text = string.Empty;
            Session[seInterestRateColl] = null;
        }


        #region load dropdown

        public void LoadDropDownCompanyInfo()
        {
            try
            {
                using (CompanyInfoRT aCompanyInfoRt = new CompanyInfoRT())
                {
                    var companyList = aCompanyInfoRt.GetAllCompanyInfos();
                    DropDownListHelper.Bind(dropDownCompanyInfo, companyList, "Name", "IID", EnumCollection.ListItemType.CompanyInfo);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
        public void LoadDropDownOparetionType()
        {
            try
            {
                //dropDownOparationType.Items.Insert(0, new ListItem("Select Mortgage Operation Type ", "-1"));
                var list = EnumHelper.EnumCamelSpaceToList<EnumCollection.MortgageOperationType>();
                DropDownListHelper.Bind(dropDownOparationType, list, EnumCollection.ListItemType.MortgageOperationType);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
        public void LoadDropDownMortgageType()
        {
            try
            {
                //dropDownMortgageType.Items.Insert(0, new ListItem("Select Mortgage Type ", "-1"));
                var list = EnumHelper.EnumCamelSpaceToList<EnumCollection.MortgageType>();
                DropDownListHelper.Bind(dropDownMortgageType, list, EnumCollection.ListItemType.MortgageType);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
        public void LoadDropDownInterestRateType()
        {
            try
            {
                var list = EnumHelper.EnumCamelSpaceToList<EnumCollection.InterestRateType>();
                //ddlInterestRateType.Items.Insert(0, new ListItem("Select Interest Type", "-1"));
                DropDownListHelper.Bind(ddlInterestRateType, list, EnumCollection.ListItemType.InterestRateType);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
        public void LoadDropDownTermYear()
        {
            try
            {
                using (MortgageTermYearRT aMortgageTermYearRt = new MortgageTermYearRT())
                {
                    var mortgageTermYearList = aMortgageTermYearRt.GetAllMortgageTermYear();
                    DropDownListHelper.Bind(dropDownTermYear, mortgageTermYearList, "NumberOfYear", "IID", EnumCollection.ListItemType.MortgageTermYear);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        public void LoadDropDownPaymentType()
        {
            try
            {
                //dropDownPaymentType.Items.Insert(0, new ListItem("Select Payment Method ", "-1"));
                var list = EnumHelper.EnumCamelSpaceToList<EnumCollection.PaymentType>();
                DropDownListHelper.Bind(dropDownPaymentType, list, EnumCollection.ListItemType.PaymentType);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        #endregion load dropdown

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/AdminPanel/MortgageDisplay.aspx");
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void LoadMortgageInterestRate()
        {
            try
            {
                lvMortgageInterestRate.DataSource = (List<MortgageInterestRate>)Session[seInterestRateColl];
                lvMortgageInterestRate.DataBind();
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private MortgageInterestRate CreateMortgageInterestRate()
        {
            Session["UserID"] = "1";
            MortgageInterestRate rate = new MortgageInterestRate();
            rate.InterestRateTypeID = Convert.ToInt16(ddlInterestRateType.SelectedValue.ToString());
            rate.Rate = Convert.ToDouble(txtInterestRate.Text);
            rate.UptoYear = int.Parse(txtUptoYear.Text);
            rate.Note = txtNote.Text;
            rate.IsRemoved = false;
            rate.CreatedBy = Convert.ToInt64(Session["UserID"]);
            rate.CreatedDate = DateTime.Now;
            return rate;
        }

        private bool IsValidInterestType()
        {
            if (Convert.ToInt16(ddlInterestRateType.SelectedValue) == -1)
            {
                return true;
            }
            if (string.IsNullOrWhiteSpace(txtInterestRate.Text))
            {
                return true;
            }
            return false;
        }
        private void ClearMortgageInterstRateFeild()
        {
            ddlInterestRateType.SelectedIndex = 0;
            txtInterestRate.Text = string.Empty;
            txtNote.Text = string.Empty;
            txtUptoYear.Text = string.Empty;
        }

        #endregion private methods





        protected void btn_CreateOrEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int mortGageID = 0;

                bool reqIDIsValid = Int64.TryParse(Request.QueryString["IID"], out IID);
                var msg = BusinessLogicValidation();
                if (!string.IsNullOrEmpty(msg))
                {
                    labelMessage.Text = msg;
                    labelMessage.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                Mortgage mortgage = CreateMortgage();
                if (IID <= 0)
                {
                    mortgage.CreatedBy = Convert.ToInt64(Session["UserID"]);
                    mortgage.CreatedDate = DateTime.Now;

                    List<MortgageInterestRate> list = (List<MortgageInterestRate>)Session[seInterestRateColl];
                    if (list != null)
                    {
                        string mortgageAndInterestRateChildXML = ConversionXML.ConvertObjectToXML<Mortgage, MortgageInterestRate>(mortgage, list, string.Empty);
                        mortGageID = MortgageRT.InsertMortgageAndInterestRateChildXML(mortgageAndInterestRateChildXML);
                        // _mortgageRt.AddMortageAndInterestRateType(mortgage,list);
                        if (mortGageID == -100)
                        {
                            labelMessage.Text = "Network connection fail ... Please try again..!!";
                            labelMessage.ForeColor = System.Drawing.Color.Red;
                            labelMessage.Focus();
                        }
                        else if (mortGageID == -101)
                        {
                            labelMessage.Text = "Network connection fail ... Please try again..!!";
                            labelMessage.ForeColor = System.Drawing.Color.Red;
                            labelMessage.Focus();
                        }
                        ClearData();

                        labelMessage.Text = "Information has been inserted successfully.";
                        labelMessage.ForeColor = System.Drawing.Color.Green;
                        Session[seInterestRateColl] = null;
                        btnReport.Enabled = true;
                       // Response.Redirect("MortgageDisplay");
                    }
                    else if (list == null)
                    {
                        using (MortgageRT rt = new MortgageRT())
                        {
                            rt.AddMortgage(mortgage);
                            labelMessage.Text = "Information has been updated successfully.";
                            labelMessage.ForeColor = System.Drawing.Color.Green;
                            btnReport.Enabled = true;
                            //Response.Redirect("MortgageDisplay");
                        }
                    }

                }
                else
                {
                    Mortgage objMortgage = _mortgageRt.GetMortgageById(IID);

                    if (objMortgage != null)
                    {
                        mortgage.CreatedBy = objMortgage.CreatedBy; ;
                        mortgage.CreatedDate = objMortgage.CreatedDate;
                        mortgage.IID = objMortgage.IID;

                        mortgage.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                        mortgage.ModifiedDate = DateTime.Now;
                        List<MortgageInterestRate> interestTypeList = new List<MortgageInterestRate>();
                        if (Session[seInterestRateColl] != null)
                        {
                            List<MortgageInterestRate> typeList = (List<MortgageInterestRate>)Session[seInterestRateColl];

                            foreach (MortgageInterestRate r in typeList)
                            {
                                MortgageInterestRate t = new MortgageInterestRate();
                                t.InterestRateTypeID = r.InterestRateTypeID;
                                t.Rate = r.Rate;
                                t.UptoYear = r.UptoYear;
                                t.Note = r.Note;
                                t.CreatedBy = r.CreatedBy;
                                t.CreatedDate = r.CreatedDate;
                                t.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                                t.ModifiedDate = DateTime.Now;
                                interestTypeList.Add(t);
                            }
                        }
                        _mortgageRt.UpdateMortgageAndInterestRateType(mortgage, interestTypeList);
                        ClearData();


                        labelMessage.Text = "Information has been updated successfully.";
                        labelMessage.ForeColor = System.Drawing.Color.Green;
                        Session[seInterestRateColl] = null;
                        //Response.Redirect("MortgageDisplay");
                        Session["mortgageObj"] = mortgage;
                        btnReport.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lvMortgageInterestRate_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            try
            {
                // lblMessageFeature.Text = string.Empty;
                if (e.CommandName.Equals("DeleteInfo"))
                {
                    ListViewDataItem dataItem = (ListViewDataItem)e.Item;
                    //int DispalyIndex = e.Item.DisplayIndex;
                    //int ItemIndex = e.Item.DataItemIndex;

                    Label lblInterestRateTypeID = (Label)dataItem.FindControl("lblInterestRateTypeID");
                    Label lblRate = (Label)dataItem.FindControl("lblRate");
                    int id = Convert.ToInt16(lblInterestRateTypeID.Text);
                    double rate = Convert.ToDouble(lblRate.Text);
                    if (Session[seInterestRateColl] != null)
                    {
                        List<MortgageInterestRate> mortgageRateColl = (List<MortgageInterestRate>)Session[seInterestRateColl];
                        mortgageRateColl.RemoveAll(fe => fe.InterestRateTypeID.Equals(id) && fe.Rate.Equals(rate));
                        Session[seInterestRateColl] = mortgageRateColl;
                        LoadMortgageInterestRate();
                    }
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }

        }

        protected void lvMortgageInterestRate_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void lvMortgageInterestRate_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    LoadMortgageInterestRate();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void dpMortgageInterestRate_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    LoadMortgageInterestRate();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnAddFeature_Click(object sender, EventArgs e)
        {
            List<MortgageInterestRate> rateColl = null;
            string note = string.Empty;
            string testFeild = string.Empty;
            //lblMessageFeature.Text = string.Empty;
            if (IsValidInterestType())
            {
                return;
            }
            if (Session[seInterestRateColl] == null)
            {
                rateColl = new List<MortgageInterestRate>();
            }
            else
            {
                rateColl = (List<MortgageInterestRate>)Session[seInterestRateColl];
            }
            foreach (MortgageInterestRate rate in rateColl)
            {
                if (rate.Rate == Convert.ToDouble(txtInterestRate.Text.Trim()) && rate.InterestRateTypeID == Convert.ToInt16(ddlInterestRateType.SelectedValue.ToString()))
                {
                    testFeild = "Invalid";
                    break;
                }
            }
            if (testFeild == "Invalid")
            {
                //lblMessageFeature.Text = "Interest Rate already exists";
                //lblMessageFeature.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                MortgageInterestRate feature = CreateMortgageInterestRate();
                rateColl.Add(feature);
                Session[seInterestRateColl] = rateColl;
                LoadMortgageInterestRate();
                ClearMortgageInterstRateFeild();
            }
        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/AdminPanel/MortgageReportUI");
            }
            catch (Exception ex)
            { 
            }
        }
    }
}