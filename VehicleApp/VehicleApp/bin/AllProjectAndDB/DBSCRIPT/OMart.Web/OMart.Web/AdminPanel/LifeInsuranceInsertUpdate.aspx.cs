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
    public partial class LifeInsuranceInsertUpdate : System.Web.UI.Page
    {
       private readonly LifeInsuranceRT _LifeInsuranceRT;
        
        private int IID = default(int);

        public LifeInsuranceInsertUpdate()
        {
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                
                if (!IsPostBack)
                {
                    
                    LoadDropDownCompanyID(null);
                    LoadDropDownLifeInsuranceID(null);
                    var requestId = Request.QueryString["IID"];
                    int reqID = Convert.ToInt32( requestId);
                    bool reqIDIsValid = Int32.TryParse(requestId, out IID);
                    if (reqID != 0 )
                    {
                        ShowLifeInsuranceData();
                    }
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        
        private void LoadDropDownCompanyID(int? LoanAmntYrScdleOb)
        {
            try
            {
                CompanyInfoRT com = new CompanyInfoRT();
                List <CompanyInfo> comList = new List<CompanyInfo>();
                  comList = com.GetAllCompanyInfos();

                  DropDownListHelper.Bind<CompanyInfo>(DropDownComInfoID, comList, "Name", "IID", EnumCollection.ListItemType.Company);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        private void LoadDropDownLifeInsuranceID(int? LoanAmntYrScdleOb)
        {
            try
            {
                LISchemaRT _LisSRT = new LISchemaRT();
                List<LISchema> LIList = new List<LISchema>();
                LIList = _LisSRT.GetAllLoanAmntYrScdle();
                DropDownListHelper.Bind<LISchema>(DropDownLISchemaID, LIList, "NumberOfYear", "IID", EnumCollection.ListItemType.LISchema);
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
                DAL.LifeInsurance LifeInsurance = CreateLifeInsurance();
                
                bool reqIDIsValid = Int32.TryParse(Request.QueryString["IID"], out IID);
                string msg = string.Empty; // (string)BusinessLogicValidation(LifeInsurance);

                if (string.IsNullOrEmpty(msg))
                {
                    if (IID <= 0)
                    {
                        LifeInsurance.CreatedBy = Convert.ToInt64(Session["UserID"]);
                        LifeInsurance.CreatedDate = DateTime.Now;
                        LifeInsurance.IsRemoved = chkIsRemoved.Checked;
                        LifeInsuranceRT loanRT = new LifeInsuranceRT();
                        loanRT.AddLifeInsurance(LifeInsurance);
                        ClearData();

                        labelMessage.Text = "Information has been inserted successfully.";
                        labelMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                      LifeInsuranceRT loanRT = new LifeInsuranceRT();
                        DAL.LifeInsurance objLifeInsurance = loanRT.GetLifeInsuranceByIID(IID);

                        if (objLifeInsurance != null)
                        {
                            LifeInsurance.CreatedBy = objLifeInsurance.CreatedBy; 
                            LifeInsurance.CreatedDate = objLifeInsurance.CreatedDate;
                            //LifeInsurance.IsRemoved = objLifeInsurance.IsRemoved;
                            LifeInsurance.IID = objLifeInsurance.IID;

                            LifeInsurance.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                            LifeInsurance.ModifiedDate = DateTime.Now;
                            
                            loanRT.UpdateLifeInsurance(LifeInsurance);
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
            //ob.showLifeInsuranceGrid();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/AdminPanel/LifeInsuranceWF");
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void ShowLifeInsuranceData()
        {
            try
            {
                LifeInsuranceRT loanRt = new LifeInsuranceRT();
                DAL.LifeInsurance objLifeInsurance = loanRt.GetLifeInsuranceByIID(IID);
                if (objLifeInsurance != null)
                {
                    DropDownComInfoID.Text = objLifeInsurance.CompanyInfoID.ToString();
                    DropDownLISchemaID.Text = objLifeInsurance.LISchemaID.ToString();
                    txtClaimsPaidPercent.Text = objLifeInsurance.ClaimsPaidPercent.ToString();
                    txtCriticalillnessCoverAmount.Text = objLifeInsurance.CriticalillnessCoverAmount.ToString();
                    txtPackageName.Text = objLifeInsurance.PackageName.ToString();
                    txtTotalCoverAmount.Text = objLifeInsurance.TotalCoverAmount.ToString();
                    CheckBoxISGuranteedPremium.Checked = (Boolean)objLifeInsurance.IsGuranteedPremium;
                    chkIsRemoved.Checked = objLifeInsurance.IsRemoved;


                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        //private string BusinessLogicValidation(LifeInsurance LifeInsurance)
        //{
        //    string message = string.Empty;
        //    bool reqIDIsValid = Int32.TryParse(Request.QueryString["IID"], out IID);

        //    if (IID <= 0)
        //    {
        //        LifeInsurance objLifeInsuranceName = (from tr in _LifeInsuranceRT.GetAllLoanAmntYrScdle()
        //                                              where tr.CompanyInfoID == LifeInsurance.CompanyInfoID
        //                                              select tr).SingleOrDefault();
        //        if (LifeInsurance != null)
        //        {
        //            if (objLifeInsuranceName.CompanyInfoID == LifeInsurance.CompanyInfoID)
        //            {
        //                message = "LifeInsurance name already exists.";
        //            }
        //        }

        //    }

        //    return message;
        //}

        private DAL.LifeInsurance CreateLifeInsurance()
        {
            Session["UserID"] = "1";
            DAL.LifeInsurance objLifeInsurance = new DAL.LifeInsurance();
            try
            {
                objLifeInsurance.CompanyInfoID = Convert.ToInt32( DropDownComInfoID.Text) ;
                objLifeInsurance.LISchemaID = Convert.ToInt32( DropDownLISchemaID.Text );
                objLifeInsurance.ClaimsPaidPercent = txtClaimsPaidPercent.Text ;
                objLifeInsurance.CriticalillnessCoverAmount =Convert.ToDecimal( txtCriticalillnessCoverAmount.Text );
                objLifeInsurance.PackageName = txtPackageName.Text;
                objLifeInsurance.TotalCoverAmount = Convert.ToDecimal( txtTotalCoverAmount.Text );
                objLifeInsurance.IsGuranteedPremium = CheckBoxISGuranteedPremium.Checked ;
                objLifeInsurance.IsRemoved = chkIsRemoved.Checked  ;
                
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return objLifeInsurance;
        }

        private void ClearData()
        {
            txtClaimsPaidPercent.Text = string.Empty;
            txtCriticalillnessCoverAmount.Text = string.Empty;
            txtPackageName.Text = string.Empty;
            txtTotalCoverAmount.Text = string.Empty;
            DropDownLISchemaID.SelectedIndex = -1;
            CheckBoxISGuranteedPremium.Checked = false;
            chkIsRemoved.Checked = false;
            DropDownComInfoID.SelectedIndex = -1 ;
        }

    }
}