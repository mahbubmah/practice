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
    public partial class LIApplicableFeatureInsertUpdate : System.Web.UI.Page
    {
        private readonly LIApplicableFeatureRT _LIApplicableFeatureRT;
        
        private int IID = default(int);

        public LIApplicableFeatureInsertUpdate()
        {
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                
                if (!IsPostBack)
                {
                    
                   
                    LoadDropDownLIApplicableFeatureID(null);
                    var requestId = Request.QueryString["IID"];
                    int reqID = Convert.ToInt32( requestId);
                    bool reqIDIsValid = Int32.TryParse(requestId, out IID);
                    if (reqID != 0 )
                    {
                        ShowLIApplicableFeatureData();
                    }
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        
       
        private void LoadDropDownLIApplicableFeatureID(int? LoanAmntYrScdleOb)
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
                LIApplicableFeature LiApplicableFeature = CreateLIApplicableFeature();
                
                bool reqIDIsValid = Int32.TryParse(Request.QueryString["IID"], out IID);
                string msg = string.Empty; // (string)BusinessLogicValidation(LIApplicableFeature);

                if (string.IsNullOrEmpty(msg))
                {
                    if (IID <= 0)
                    {
                        LiApplicableFeature.CreatedBy = Convert.ToInt64(Session["UserID"]);
                        LiApplicableFeature.CreatedDate = DateTime.Now;
                        LiApplicableFeature.IsRemoved = chkIsRemoved.Checked;
                        LIApplicableFeatureRT loanRT = new LIApplicableFeatureRT();
                        loanRT.AddLiApplicableFeature((LIApplicableFeature)LiApplicableFeature);
                        ClearData();

                        labelMessage.Text = "Information has been inserted successfully.";
                        labelMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        LIApplicableFeatureRT loanRT = new LIApplicableFeatureRT();
                        LIApplicableFeature objLIApplicableFeature = loanRT.GetAddLiApplicableFeatureByIID(IID);

                        if (objLIApplicableFeature != null)
                        {
                            LiApplicableFeature.CreatedBy = objLIApplicableFeature.CreatedBy; 
                            LiApplicableFeature.CreatedDate = objLIApplicableFeature.CreatedDate;
                            //LIApplicableFeature.IsRemoved = objLIApplicableFeature.IsRemoved;
                            LiApplicableFeature.IID = objLIApplicableFeature.IID;

                            LiApplicableFeature.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                            LiApplicableFeature.ModifiedDate = DateTime.Now;
                            
                            loanRT.UpdateLiApplicableFeature(LiApplicableFeature);
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
            //ob.showLIApplicableFeatureGrid();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/AdminPanel/LIApplicableFeatureView");
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void ShowLIApplicableFeatureData()
        {
            try
            {
                LIApplicableFeatureRT loanRt = new LIApplicableFeatureRT();
                LIApplicableFeature objLIApplicableFeature = loanRt.GetAddLiApplicableFeatureByIID(IID);
                if (objLIApplicableFeature != null)
                {
                  
                    DropDownLISchemaID.Text = objLIApplicableFeature.LISchemaID.ToString();
                    txtDescription.Text = objLIApplicableFeature.Description.ToString();
                    
                    chkIsRemoved.Checked = objLIApplicableFeature.IsRemoved;


                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        //private string BusinessLogicValidation(LIApplicableFeature LIApplicableFeature)
        //{
        //    string message = string.Empty;
        //    bool reqIDIsValid = Int32.TryParse(Request.QueryString["IID"], out IID);

        //    if (IID <= 0)
        //    {
        //        LIApplicableFeature objLIApplicableFeatureName = (from tr in _LIApplicableFeatureRT.GetAllLoanAmntYrScdle()
        //                                              where tr.CompanyInfoID == LIApplicableFeature.CompanyInfoID
        //                                              select tr).SingleOrDefault();
        //        if (LIApplicableFeature != null)
        //        {
        //            if (objLIApplicableFeatureName.CompanyInfoID == LIApplicableFeature.CompanyInfoID)
        //            {
        //                message = "LIApplicableFeature name already exists.";
        //            }
        //        }

        //    }

        //    return message;
        //}

        private LIApplicableFeature CreateLIApplicableFeature()
        {
            Session["UserID"] = "1";
            LIApplicableFeature objLIApplicableFeature = new LIApplicableFeature();
            try
            {
                objLIApplicableFeature.LISchemaID = Convert.ToInt32(DropDownLISchemaID.Text) ;
                objLIApplicableFeature.Description = txtDescription.Text ;

                objLIApplicableFeature.IsRemoved = chkIsRemoved.Checked ;
                
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return objLIApplicableFeature;
        }

        private void ClearData()
        {

            txtDescription.Text = string.Empty;

            chkIsRemoved.Checked = false;
            DropDownLISchemaID.SelectedIndex = -1;
          
        }

    }
}