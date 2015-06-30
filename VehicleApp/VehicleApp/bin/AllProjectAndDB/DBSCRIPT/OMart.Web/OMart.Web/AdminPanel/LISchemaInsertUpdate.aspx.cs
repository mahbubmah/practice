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
    public partial class LISchemaInsertUpdate : System.Web.UI.Page
    {
        private readonly LISchemaRT LisRT;

        private int IID = default(int);
        private const string seLIApplicableFeatureColl = "seLIApplicableFeatureColl";
        private const string sessApplicableFeature = "seLIApplicableFeature";
        int lvRowCount = 0;
        int currentPage = 0;

        public LISchemaInsertUpdate()
        {
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                
                if (!IsPostBack)
                {
                    LoadDropDownPremiumPolicyID(null);
                    var requestId = Request.QueryString["IID"];
                    Session[seLIApplicableFeatureColl] = null;
                    int reqID = Convert.ToInt32( requestId);
                    bool reqIDIsValid = Int32.TryParse(requestId, out IID);
                    if (reqID != 0 )
                    {
                        ShowLiSchemaData();
                    }
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        private bool IsValidFeature()
        {
            if (txtDesFeature.Text.Trim().Length <= 0)
            {
                labelMessage.Text = "Pealse give description of feature !!!";
                labelMessage.ForeColor = System.Drawing.Color.Red;
                return true;
            }
            return false;
        }
        
        protected void btnAddFeature_Click(object sender, EventArgs e)
        {
            List<LIApplicableFeature> featureColl = null;
            string description = string.Empty;
            labelMessage.Text = string.Empty;
            if (IsValidFeature())
            {
                return;
            }
            if (Session[seLIApplicableFeatureColl] == null)
            {
                featureColl = new List<LIApplicableFeature>();
            }
            else
            {
                featureColl = (List<LIApplicableFeature>)Session[seLIApplicableFeatureColl];
            }
            foreach (LIApplicableFeature feature in featureColl)
            {
                if (feature.Description == txtDesFeature.Text.Trim())
                {
                    description = "Description";
                    break;
                }
            }
            if (description == "Description")
            {
                labelMessage.Text = "Description already exists";
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                LIApplicableFeature feature = CreateLIApplicableFeature();
                featureColl.Add(feature);
                Session[seLIApplicableFeatureColl] = featureColl;
                LoadLIApplicableFeature();
                txtDesFeature.Text = string.Empty;
            }
        }
        private void LoadLIApplicableFeature()
        {
            try
            {
                lvFeature.DataSource = (List<LIApplicableFeature>)Session[seLIApplicableFeatureColl];
                lvFeature.DataBind();
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        private LIApplicableFeature CreateLIApplicableFeature()
        {
            Session["UserID"] = "1";
            LIApplicableFeature feature = new LIApplicableFeature();
            feature.Description = txtDesFeature.Text.Trim();
            feature.IsRemoved = chkIsRemoved.Checked;
            feature.CreatedBy = Convert.ToInt64(Session["UserID"]);
            feature.CreatedDate = DateTime.Now;
            return feature;
        }

        protected void lvFeature_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            try
            {
                labelMessage.Text = string.Empty;
                if (e.CommandName.Equals("DeleteInfo"))
                {
                    if (Session[seLIApplicableFeatureColl] != null)
                    {
                        List<LIApplicableFeature> LIApplicableFeatureColl = (List<LIApplicableFeature>)Session[seLIApplicableFeatureColl];
                        LIApplicableFeatureColl.RemoveAll(fe => fe.Description.Equals(e.CommandArgument));
                        Session[seLIApplicableFeatureColl] = LIApplicableFeatureColl;
                        LoadLIApplicableFeature();
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
                    LoadLIApplicableFeature();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void LoadDropDownPremiumPolicyID(int? LIApplicableAmntYrScdleOb)
        {
            try
            {

                
                {
                    dropDownComInfoID.Items.Add(new ListItem("Select Premium Policy Type ", "-1"));
                    foreach (Utilities.EnumCollection.PremiumPolicy r in Enum.GetValues(typeof(Utilities.EnumCollection.PremiumPolicy)))
                    {
                        ListItem item = new ListItem(Enum.GetName(typeof(Utilities.EnumCollection.PremiumPolicy), r), r.ToString());
                        dropDownComInfoID.Items.Add(item);
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        long chk=0;
        protected void btn_CreateOrEdit_Click(object sender, EventArgs e)
        {
            
            try
            {
                int LischemaID = 0;
                LISchema lis = new LISchema();
                LISchemaRT LisRT = new LISchemaRT();
                labelMessage.Text = string.Empty;
                 bool reqIDIsValid = Int32.TryParse(Request.QueryString["IID"], out IID);

                 if (IsValidField())
                 {
                     return;
                 }
                LISchema liSchema = CreateLISchema();
                if (IID <= 0)
                {
                    liSchema.CreatedBy = Convert.ToInt64(Session["UserID"]);
                    liSchema.CreatedDate = DateTime.Now;
                    List<LIApplicableFeature> featureList = (List<LIApplicableFeature>)Session[seLIApplicableFeatureColl];
                    string mobilePhoneInfoAllChildXML = ConversionXML.ConvertObjectToXML<LISchema, LIApplicableFeature>(liSchema, featureList, string.Empty);
                    LischemaID = LISchemaRT.InsertLISchemaAndFeatureChildXML(mobilePhoneInfoAllChildXML);

                    if (LischemaID == -100)
                    {
                        labelMessage.Text = "Network connection fail ... Please try again..!!";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                        labelMessage.Focus();
                    }
                    else if (LischemaID == -101)
                    {
                        labelMessage.Text = "Network connection fail ... Please try again..!!";   
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                        labelMessage.Focus();
                    }
                   
                    
                    ClearData();

                    labelMessage.Text = "Information has been inserted successfully.";
                    Session[seLIApplicableFeatureColl] = null;
                    labelMessage.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    LISchema objliSchema = LisRT.GetAddLoanAmntYrScdleByIID(IID);

                    if (objliSchema != null)
                    {
                        liSchema.CreatedBy = objliSchema.CreatedBy;
                        liSchema.CreatedDate = objliSchema.CreatedDate;
                       
                        liSchema.IID = objliSchema.IID;

                        liSchema.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                        liSchema.ModifiedDate = DateTime.Now;
                        List<LIApplicableFeature> lst = new List<LIApplicableFeature>();
                        if (Session[seLIApplicableFeatureColl] != null)
                        {
                            List<LIApplicableFeature> featureList = (List<LIApplicableFeature>)Session[seLIApplicableFeatureColl];

                            foreach (LIApplicableFeature feature in featureList)
                            {
                                LIApplicableFeature fe = new LIApplicableFeature();
                                fe.Description = feature.Description;
                                fe.IsRemoved = objliSchema.IsRemoved;    
                                fe.CreatedBy = objliSchema.CreatedBy;
                                fe.CreatedDate = objliSchema.CreatedDate;
                                fe.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                                fe.ModifiedDate = DateTime.Now;
                                lst.Add(fe);
                            }
                        }
                        LisRT.UpdateLISchema(liSchema, lst);
                        ClearData();
                        Session[seLIApplicableFeatureColl] = null;
                        labelMessage.Text = "Information has been updated successfully.";
                        Session[seLIApplicableFeatureColl] = null;
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

        private bool IsValidField()
        {
            //if (ddlCompanyName.SelectedValue == "-1")
            //{
            //    labelMessage.Text = "Please select a company name !!!";
            //    labelMessage.ForeColor = System.Drawing.Color.Red;
            //    return true;
            //}
            //if (ddlLoanType.SelectedIndex == 0)
            //{
            //    labelMessage.Text = "Please select a Loan Type !!!";
            //    labelMessage.ForeColor = System.Drawing.Color.Red;
            //    return true;
            //}
            //if (ddlLoanType.SelectedValue == "-1")
            //{
            //    labelMessage.Text = "Please select a Loan Type !!!";
            //    labelMessage.ForeColor = System.Drawing.Color.Red;
            //    return true;
            //}
            //if (txtTotalAmount.Text.Trim().Length <= 0)
            //{
            //    labelMessage.Text = "Please Enter Total Amount !!!";
            //    labelMessage.ForeColor = System.Drawing.Color.Red;
            //    return true;
            //}
            //if (txtTotalPaymentAmount.Text.Trim().Length <= 0)
            //{
            //    labelMessage.Text = "Please Enter Total Payment Amount !!!";
            //    labelMessage.ForeColor = System.Drawing.Color.Red;
            //    return true;
            //}
            //if (txtMonthlyReturnAmount.Text.Trim().Length <= 0)
            //{
            //    labelMessage.Text = "Please Enter Monthly Return Amount !!!";
            //    labelMessage.ForeColor = System.Drawing.Color.Red;
            //    return true;
            //}
            //if (txtTotalReturnAmount.Text.Trim().Length <= 0)
            //{
            //    labelMessage.Text = "Please Enter Total Return Amount !!!";
            //    labelMessage.ForeColor = System.Drawing.Color.Red;
            //    return true;
            //}
            //if (txtTotalInstallmentNo.Text.Trim().Length <= 0)
            //{
            //    labelMessage.Text = "Please Enter Total Installment No. !!!";
            //    labelMessage.ForeColor = System.Drawing.Color.Red;
            //    return true;
            //}
            //if (txtPostLastDisplayDate.Text.Trim().Length <= 0)
            //{
            //    labelMessage.Text = "Please Enter Post Last Display Day!!!";
            //    labelMessage.ForeColor = System.Drawing.Color.Red;
            //    return true;
            //}
            if (Session[seLIApplicableFeatureColl] == null)
            {
                labelMessage.Text = "Please add at least one feature !!!";
                labelMessage.ForeColor = System.Drawing.Color.Red;
                return true;
            }
            return false;
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
                    LoadLIApplicableFeature();
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
            try
            {
                Response.Redirect("~/AdminPanel/LISchemaView");
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void ShowLiSchemaData()
        {
            try
            {
                LISchemaRT LIApplicableRt = new LISchemaRT();
                LISchema objLiSchema = LIApplicableRt.GetAddLoanAmntYrScdleByIID(IID);
                if (objLiSchema != null)
                {
                    txtNoOfYr.Text = objLiSchema.NumberOfYear.ToString();
                    txtAgeMin.Text = objLiSchema.AgeMin.ToString();
                    txtAgeMax.Text = objLiSchema.AgeMax.ToString();
                    txtMultipleFactor.Text = objLiSchema.MultiplyFactor.ToString();
                    txtUnitAmount.Text = objLiSchema.UnitAmount.ToString();
                    txtUnitPremiumAmount.Text = objLiSchema.UnitPremiumAmount.ToString();
                    txtUnitReturnAmount.Text = objLiSchema.UnitReturnAmount.ToString();
                    dropDownComInfoID.SelectedValue  = Enum.GetName(typeof(Utilities.EnumCollection.PremiumPolicy),objLiSchema.PremiumPolicyID);
                    DisplayFeature(objLiSchema.IID);
                    chkIsRemoved.Checked = objLiSchema.IsRemoved;


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
                Session[seLIApplicableFeatureColl] = null;
                List<LIApplicableFeature> featureList = new List<LIApplicableFeature>();
                LIApplicableFeatureRT lt = new LIApplicableFeatureRT();
                featureList = lt.GetAddLiApplicableFeatureByIID(LoanID);
                lvFeature.DataSource = featureList;
                Session[seLIApplicableFeatureColl] = featureList;
                lvFeature.DataBind();
            }
            catch (Exception ex)
            {

            }
        }
        //private string BusinessLogicValidation(LISchema LiSchema)
        //{
        //    string message = string.Empty;
        //    bool reqIDIsValid = Int32.TryParse(Request.QueryString["IID"], out IID);

        //    if (IID <= 0)
        //    {
        //        LISchema objLiSchemaName = (from tr in LisRT.GetAllLIApplicableAmntYrScdle()
        //                                              where tr.CompanyInfoID == LiSchema.CompanyInfoID
        //                                              select tr).SingleOrDefault();
        //        if (LiSchema != null)
        //        {
        //            if (objLiSchemaName.CompanyInfoID == LiSchema.CompanyInfoID)
        //            {
        //                message = "LiSchema name already exists.";
        //            }
        //        }

        //    }

        //    return message;
        //}

        private LISchema CreateLISchema()
        {
            Session["UserID"] = "1";
            LISchema objLiSchema = new LISchema();
            try
            {
                objLiSchema.NumberOfYear =  Convert.ToInt32( txtNoOfYr.Text) ;
                objLiSchema.AgeMin = Convert.ToInt32(txtAgeMin.Text) ;
                objLiSchema.AgeMax = Convert.ToInt32(txtAgeMax.Text );
                objLiSchema.UnitAmount = Convert.ToDecimal( txtUnitAmount.Text);
                objLiSchema.MultiplyFactor = Convert.ToInt32(txtMultipleFactor.Text);
                objLiSchema.UnitPremiumAmount = Convert.ToDecimal(txtUnitPremiumAmount.Text) ;
                objLiSchema.UnitReturnAmount = Convert.ToDecimal(txtUnitReturnAmount.Text) ;
                //objLiSchema.PremiumPolicyID = (Int32) Utilities.EnumCollection.PremiumPolicy.(dropDownComInfoID.SelectedValue.ToString()) ;
                objLiSchema.PremiumPolicyID = (Int32)Enum.Parse(typeof(Utilities.EnumCollection.PremiumPolicy), dropDownComInfoID.SelectedValue.ToString());
                objLiSchema.IsRemoved = chkIsRemoved.Checked ;
                
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return objLiSchema;
        }

        private void ClearData()
        {
            txtNoOfYr.Text = string.Empty;
            txtAgeMin.Text = string.Empty;
            txtAgeMax.Text = string.Empty;
            txtUnitAmount.Text = string.Empty;
            txtUnitPremiumAmount.Text = string.Empty;
            txtUnitReturnAmount.Text = string.Empty;
            txtMultipleFactor.Text = string.Empty;
            chkIsRemoved.Checked = false;
            Session[seLIApplicableFeatureColl] = null;
            dropDownComInfoID.SelectedIndex = -1 ;
        }

    }
}