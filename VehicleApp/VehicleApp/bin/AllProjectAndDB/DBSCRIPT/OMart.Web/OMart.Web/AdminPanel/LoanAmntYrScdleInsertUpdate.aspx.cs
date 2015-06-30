using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Basic;
using BLL;
using DAL;
using Utilities;
namespace OMart.Web.AdminPanel
{
    public partial class LoanAmntYrScdleInsertUpdate : System.Web.UI.Page
    {

        //private readonly LoanAmntYrScdleRT _loanAmntYrScdleRT = new LoanAmntYrScdleRT();
        private readonly LoanAmntYrScdleRT _loanAmntYrScdleRT;
        
        private int IID = default(int);

        public LoanAmntYrScdleInsertUpdate()
        {
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                
                if (!IsPostBack)
                {
                    LoadDropDownCompnayInfo(null);
                    var requestId = Request.QueryString["IID"];
                    int reqID = Convert.ToInt32( requestId);
                    bool reqIDIsValid = Int32.TryParse(requestId, out IID);
                    if (reqID != 0 )
                    {
                        ShowLoanAmountYearScheduleData();
                    }
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void LoadDropDownCompnayInfo(int? LoanAmntYrScdleOb)
        {
            try
            {
                using (CompanyInfoRT receverTransfer = new CompanyInfoRT())
                {
                    List<CompanyInfo> LoanAmntYrScdleList = new List<CompanyInfo>();
                    if (LoanAmntYrScdleOb != null)
                    {
                        LoanAmntYrScdleList.Add((CompanyInfo)receverTransfer.GetCompanyInfoByIID((int)LoanAmntYrScdleOb));
                       
                    }
                    else
                    {
                        LoanAmntYrScdleList = receverTransfer.GetAllCompanyInfos();
                    }
                    DropDownListHelper.Bind<CompanyInfo>(dropDownComInfoID, LoanAmntYrScdleList, "Name", "IID", EnumCollection.ListItemType.Company);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        protected void btn_CreateOrEdit_Click(object sender, EventArgs e)
        {
            try
            {
                LoanAmtYearSchedule LoanAmountYearSchedule = CreateLoanAmtYearSchedule();
                
                bool reqIDIsValid = Int32.TryParse(Request.QueryString["IID"], out IID);
                string msg = string.Empty; // (string)BusinessLogicValidation(LoanAmountYearSchedule);

                if (string.IsNullOrEmpty(msg))
                {
                    if (IID <= 0)
                    {
                        LoanAmountYearSchedule.CreatedBy = Convert.ToInt64(Session["UserID"]);
                        LoanAmountYearSchedule.CreatedDate = DateTime.Now;
                        LoanAmountYearSchedule.IsRemoved = chkIsRemoved.Checked;
                        LoanAmntYrScdleRT loanRT = new LoanAmntYrScdleRT();
                        loanRT.AddLoanAmntYrScdle(LoanAmountYearSchedule);
                        ClearData();

                        labelMessage.Text = "Information has been inserted successfully.";
                        labelMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        LoanAmntYrScdleRT loanRT = new LoanAmntYrScdleRT();
                        LoanAmtYearSchedule objLoanAmountYearSchedule = loanRT.GetAddLoanAmntYrScdleByIID(IID);

                        if (objLoanAmountYearSchedule != null)
                        {
                            LoanAmountYearSchedule.CreatedBy = objLoanAmountYearSchedule.CreatedBy; 
                            LoanAmountYearSchedule.CreatedDate = objLoanAmountYearSchedule.CreatedDate;
                            //LoanAmountYearSchedule.IsRemoved = objLoanAmountYearSchedule.IsRemoved;
                            LoanAmountYearSchedule.IID = objLoanAmountYearSchedule.IID;

                            LoanAmountYearSchedule.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                            LoanAmountYearSchedule.ModifiedDate = DateTime.Now;
                            
                            loanRT.UpdateLoanAmntYrScdle(LoanAmountYearSchedule);
                            ClearData();

                            labelMessage.Text = "Information has been updated successfully.";
                            labelMessage.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            labelMessage.Text = "Information has not been updated successfully.";
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
            //LoanAmntYrScdle ob = new LoanAmntYrScdle();
            //ob.showLoanAmountYearScheduleGrid();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/AdminPanel/LoanAmntYrScdle");
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void ShowLoanAmountYearScheduleData()
        {
            try
            {
                LoanAmntYrScdleRT loanRt = new LoanAmntYrScdleRT();
                LoanAmtYearSchedule objLoan = loanRt.GetAddLoanAmntYrScdleByIID(IID);
                if (objLoan != null)
                {
                    txtAmntStart.Text = objLoan.AmountStart.ToString();
                    txtAmntEnd.Text = objLoan.AmountEnd.ToString();
                    txtDuration.Text = objLoan.Duration.ToString();
                    txtApr.Text = objLoan.APR.ToString();
                    txtAprNote.Text = objLoan.APRNote.ToString();
                    dropDownComInfoID.SelectedValue = objLoan.CompanyInfoID.ToString();
                    chkIsRemoved.Checked = objLoan.IsRemoved;


                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private string BusinessLogicValidation(LoanAmtYearSchedule LoanAmountYearSchedule)
        {
            string message = string.Empty;
            bool reqIDIsValid = Int32.TryParse(Request.QueryString["IID"], out IID);

            if (IID <= 0)
            {
                LoanAmtYearSchedule objLoanAmountYearScheduleName = (from tr in _loanAmntYrScdleRT.GetAllLoanAmntYrScdle()
                                                      where tr.CompanyInfoID == LoanAmountYearSchedule.CompanyInfoID
                                                      select tr).SingleOrDefault();
                if (LoanAmountYearSchedule != null)
                {
                    if (objLoanAmountYearScheduleName.CompanyInfoID == LoanAmountYearSchedule.CompanyInfoID)
                    {
                        message = "LoanAmountYearSchedule name already exists.";
                    }
                }

            }

            return message;
        }

        private LoanAmtYearSchedule CreateLoanAmtYearSchedule()
        {
            Session["UserID"] = "1";
            LoanAmtYearSchedule objLoan = new LoanAmtYearSchedule();
            try
            {
                objLoan.AmountStart =Convert.ToDecimal( txtAmntStart.Text);
                objLoan.AmountEnd = Convert.ToDecimal(txtAmntEnd.Text);
                objLoan.Duration = Convert.ToInt32( txtDuration.Text);
                objLoan.APR = Convert.ToDecimal( txtApr.Text);
                objLoan.APRNote = txtAprNote.Text;
                objLoan.IsRemoved = chkIsRemoved.Checked;
                objLoan.CompanyInfoID = Convert.ToInt32( dropDownComInfoID.SelectedValue);
                
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return objLoan;
        }

        private void ClearData()
        {
            txtAmntStart.Text = string.Empty; 
            txtAmntEnd.Text = string.Empty; 
            txtDuration.Text = string.Empty;
            txtApr.Text = string.Empty;
            txtAprNote.Text = string.Empty;
            chkIsRemoved.Checked = false;
            LoadDropDownCompnayInfo(null);
        }

    }
}