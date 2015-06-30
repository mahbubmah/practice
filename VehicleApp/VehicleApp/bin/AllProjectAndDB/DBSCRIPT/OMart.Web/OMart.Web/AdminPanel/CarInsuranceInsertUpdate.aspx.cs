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
    public partial class CarInsuranceInsertUpdate : System.Web.UI.Page
    {
        private readonly CarInsuranceRT LisRT;

        private int IID = default(int);
        private const string seCarInsuranceFeatureColl = "seCarInsuranceFeatureColl";
        private const string sessApplicableFeature = "seCarInsuranceFeature";
        int lvRowCount = 0;
        int currentPage = 0;
        int lvRowCount2 = 0;
        int currentPage2 = 0;

        public CarInsuranceInsertUpdate()
        {
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if(hdCarParamChk.Value == "true")
                     DivShowCarInsParDiv.Visible = true;
                else
                    DivShowCarInsParDiv.Visible = false;
                if (!IsPostBack)
                {
                    
                    LoadDropDownCompany(null);
                    var requestId = Request.QueryString["IID"];
                    Session[seCarInsuranceFeatureColl] = null;
                    int reqID = Convert.ToInt32( requestId);
                    bool reqIDIsValid = Int32.TryParse(requestId, out IID);
                    if (reqID != 0 )
                    {
                        ShowCarInsuranceData();
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
            List<CarInsuranceFeature> featureColl = null;
            string description = string.Empty;
            labelMessage.Text = string.Empty;
            if (IsValidFeature())
            {
                return;
            }
            if (Session[seCarInsuranceFeatureColl] == null)
            {
                featureColl = new List<CarInsuranceFeature>();
            }
            else
            {
                featureColl = (List<CarInsuranceFeature>)Session[seCarInsuranceFeatureColl];
            }
            foreach (CarInsuranceFeature feature in featureColl)
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
                CarInsuranceFeature feature = CreateCarInsuranceFeature();
                featureColl.Add(feature);
                Session[seCarInsuranceFeatureColl] = featureColl;
                LoadCarInsuranceFeature();
                txtDesFeature.Text = string.Empty;
            }
        }
        private void LoadCarInsuranceFeature()
        {
            try
            {
                lvFeature.DataSource = (List<CarInsuranceFeature>)Session[seCarInsuranceFeatureColl];
                lvFeature.DataBind();
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        private CarInsuranceFeature CreateCarInsuranceFeature()
        {
            try
            {
                CarInsuranceFeature feature = new CarInsuranceFeature();
                feature.Description = txtDesFeature.Text.Trim();
                feature.IsRemoved = false;
                feature.CreatedBy = Convert.ToInt64(Session["UserID"]);
                feature.CreatedDate = DateTime.Now;
                return feature;
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return null;

        }

        protected void lvFeature_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            try
            {
                labelMessage.Text = string.Empty;
                if (e.CommandName.Equals("DeleteInfo"))
                {
                    if (Session[seCarInsuranceFeatureColl] != null)
                    {
                        List<CarInsuranceFeature> CarInsuranceFeatureColl = (List<CarInsuranceFeature>)Session[seCarInsuranceFeatureColl];
                        CarInsuranceFeatureColl.RemoveAll(fe => fe.Description.Equals(e.CommandArgument));
                        Session[seCarInsuranceFeatureColl] = CarInsuranceFeatureColl;
                        LoadCarInsuranceFeature();
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
                    LoadCarInsuranceFeature();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void dataPagerInsuranceParameter_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount2 = currentPage * 10;
                if (IsPostBack)
                {
                    LoadCarInsuranceFeature();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void LoadDropDownCompany(int? companyID)
        {
            try
            {
                using (CompanyInfoRT receverTransfer = new CompanyInfoRT())
                {
                    List<CompanyInfo> companyInfoList = new List<CompanyInfo>();
                    if (companyID != null)
                    {
                        companyInfoList.Add(receverTransfer.GetCompanyInfoByIIDAndBusinessTypeInsurance((int)companyID));
                    }
                    else
                    {
                        companyInfoList = receverTransfer.GetAllMobileCompanyInfosBusinessTypeInsurance();
                    }
                    DropDownListHelper.Bind<CompanyInfo>(DropDownCompanyInfoID, companyInfoList, "Name", "IID", EnumCollection.ListItemType.Company);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        //private void LoadDropDownCompany(int? LIApplicableAmntYrScdleOb)
        //{
        //    try
        //    {

                
        //        {
        //            dropDownComInfoID.Items.Add(new ListItem("Select Premium Policy Type ", "-1"));
        //            foreach (Utilities.EnumCollection.PremiumPolicy r in Enum.GetValues(typeof(Utilities.EnumCollection.PremiumPolicy)))
        //            {
        //                ListItem item = new ListItem(Enum.GetName(typeof(Utilities.EnumCollection.PremiumPolicy), r), r.ToString());
        //                dropDownComInfoID.Items.Add(item);
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex);
        //    }
        //}
        long chk=0;
        protected void btn_CreateOrEdit_Click(object sender, EventArgs e)
        {
            
            try
            {
                int CarInsuranceID = 0;
                CarInsurance lis = new CarInsurance();
                CarInsuranceRT LisRT = new CarInsuranceRT();
                labelMessage.Text = string.Empty;
                 bool reqIDIsValid = Int32.TryParse(Request.QueryString["IID"], out IID);

                 if (IsValidField())
                 {
                     return;
                 }
                
                if (IID <= 0)
                {
                    CarInsurance CarInsurance = CreateCarInsurance();
                    CarInsurance.CreatedBy = Convert.ToInt64(Session["UserID"]);
                    CarInsurance.CreatedDate = DateTime.Now;
                    List<CarInsuranceFeature> featureList = (List<CarInsuranceFeature>)Session[seCarInsuranceFeatureColl];
                    string mobilePhoneInfoAllChildXML = ConversionXML.ConvertObjectToXML<CarInsurance, CarInsuranceFeature>(CarInsurance, featureList, string.Empty);
                    CarInsuranceID = CarInsuranceRT.InsertCarInsuranceAndFeatureChildXML(mobilePhoneInfoAllChildXML);

                    if (CarInsuranceID == -100)
                    {
                        labelMessage.Text = "Network connection fail ... Please try again..!!";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                        labelMessage.Focus();
                    }
                    else if (CarInsuranceID == -101)
                    {
                        labelMessage.Text = "Network connection fail ... Please try again..!!";   
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                        labelMessage.Focus();
                    }
                   
                    
                    ClearData();

                    labelMessage.Text = "Information has been inserted successfully.";
                    Session[seCarInsuranceFeatureColl] = null;
                    labelMessage.ForeColor = System.Drawing.Color.Green;
                }
                else
                {

                    
                    CarInsurance objCarInsurance = LisRT.GetAddLoanAmntYrScdleByIID(IID);
                    
                    CarInsurance CarInsurance = CreateCarInsurance();
                   

                    if (objCarInsurance != null)
                    {
                        CarInsurance.CreatedBy = objCarInsurance.CreatedBy;
                        CarInsurance.CreatedDate = objCarInsurance.CreatedDate;
                       
                        CarInsurance.IID = objCarInsurance.IID;

                        CarInsurance.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                        CarInsurance.ModifiedDate = DateTime.Now;
                        List<CarInsuranceFeature> lst = new List<CarInsuranceFeature>();
                        if (Session[seCarInsuranceFeatureColl] != null)
                        {
                            List<CarInsuranceFeature> featureList = (List<CarInsuranceFeature>)Session[seCarInsuranceFeatureColl];

                            foreach (CarInsuranceFeature feature in featureList)
                            {
                                CarInsuranceFeature fe = new CarInsuranceFeature();
                                fe.Description = feature.Description;
                                fe.IsRemoved = objCarInsurance.IsRemoved;    
                                fe.CreatedBy = objCarInsurance.CreatedBy;
                                fe.CreatedDate = objCarInsurance.CreatedDate;
                                fe.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                                fe.ModifiedDate = DateTime.Now;
                                lst.Add(fe);
                            }
                        }
                        LisRT.UpdateCarInsurance(CarInsurance, lst);
                        ClearData();
                        Session[seCarInsuranceFeatureColl] = null;
                        labelMessage.Text = "Information has been updated successfully.";
                        Session[seCarInsuranceFeatureColl] = null;
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
            if (hdCarParamChk.Value == "")
            {
                labelMessage.Text = "Please Search and Select Car Insurance Parameter !!!";
                labelMessage.ForeColor = System.Drawing.Color.Red;
                return true;
            }
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
            if (Session[seCarInsuranceFeatureColl] == null)
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
                    LoadCarInsuranceFeature();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void lvInsuranceParameter_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            try
            {
                //labelMessage.Text = string.Empty;
                //if (e.CommandName.Equals("DeleteInfo"))
                //{
                //    if (Session[seCarInsuranceFeatureColl] != null)
                //    {
                //        List<CarInsuranceFeature> CarInsuranceFeatureColl = (List<CarInsuranceFeature>)Session[seCarInsuranceFeatureColl];
                //        CarInsuranceFeatureColl.RemoveAll(fe => fe.Description.Equals(e.CommandArgument));
                //        Session[seCarInsuranceFeatureColl] = CarInsuranceFeatureColl;
                //        LoadCarInsuranceFeature();
                //    }
                //}
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void lvInsuranceParameter_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            labelMessage.Text = string.Empty;
            currentPage2 = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void lvInsuranceParameter_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount2 = currentPage * 10;
                if (IsPostBack)
                {
                    LoadCarInsuranceFeature();
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
                Response.Redirect("~/AdminPanel/CarInsuranceView");
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void ShowCarInsuranceData()
        {
            try
            {
                CarInsuranceRT LIApplicableRt = new CarInsuranceRT();
                CarInsurance objCarInsurance = LIApplicableRt.GetAddLoanAmntYrScdleByIID(IID);
                if (objCarInsurance != null)
                {
                    
                    CarInsuranceParameterRT _Rt = new CarInsuranceParameterRT();
                    string carParString = _Rt.BindForSearchResult(objCarInsurance.CarInsuranceParameterID);
                    txtCarInsuranceParameterID.Text = carParString;

                    DropDownCompanyInfoID.SelectedValue = objCarInsurance.CompanyInfoID.ToString();
                    hdCarInsuranceTypeID.Value = objCarInsurance.CarInsuranceParameterID.ToString();
                    txtCarValueAmount.Text = objCarInsurance.CarValueAmount.ToString();
                    txtFixedTotalAmount.Text = objCarInsurance.FixedTotalAmount.ToString();
                    txtFixedVoluntaryAmount.Text = objCarInsurance.FixedVoluntaryAmount.ToString();
                    txtFixedCompulsoryAmount.Text = objCarInsurance.FixedCompulsoryAmount.ToString();
                    txtAnnuallyGrossAmount.Text = objCarInsurance.AnnuallyGrossAmount.ToString();
                    txtTotalMonth.Text = objCarInsurance.TotalMonth.ToString();
                    txtInstallmentAmount.Text = objCarInsurance.InstallmentAmount.ToString();
                    //objCarInsurance.PremiumPolicyID = (Int32) Utilities.EnumCollection.PremiumPolicy.(dropDownComInfoID.SelectedValue.ToString()) ;
                    DisplayFeature(objCarInsurance.IID);}
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
                Session[seCarInsuranceFeatureColl] = null;
                List<CarInsuranceFeature> featureList = new List<CarInsuranceFeature>();
                CarInsuranceFeatureRT lt = new CarInsuranceFeatureRT();
                featureList = lt.GetAddCarInsuranceFeatureByIID(LoanID);
                lvFeature.DataSource = featureList;
                Session[seCarInsuranceFeatureColl] = featureList;
                lvFeature.DataBind();
            }
            catch (Exception ex)
            {

            }
        }
        //private string BusinessLogicValidation(CarInsurance CarInsurance)
        //{
        //    string message = string.Empty;
        //    bool reqIDIsValid = Int32.TryParse(Request.QueryString["IID"], out IID);

        //    if (IID <= 0)
        //    {
        //        CarInsurance objCarInsuranceName = (from tr in LisRT.GetAllLIApplicableAmntYrScdle()
        //                                              where tr.CompanyInfoID == CarInsurance.CompanyInfoID
        //                                              select tr).SingleOrDefault();
        //        if (CarInsurance != null)
        //        {
        //            if (objCarInsuranceName.CompanyInfoID == CarInsurance.CompanyInfoID)
        //            {
        //                message = "CarInsurance name already exists.";
        //            }
        //        }

        //    }

        //    return message;
        //}

        private CarInsurance CreateCarInsurance()
        {
           
            CarInsurance objCarInsurance = new CarInsurance();
            try
            {
                
                objCarInsurance.CompanyInfoID = Convert.ToInt32 (DropDownCompanyInfoID.SelectedValue);
                objCarInsurance.CarInsuranceParameterID = Convert.ToInt32(hdCarInsuranceTypeID.Value );
                objCarInsurance.CarValueAmount = Convert.ToDecimal( txtCarValueAmount.Text);
                objCarInsurance.FixedTotalAmount = Convert.ToDecimal(txtFixedTotalAmount.Text);
                objCarInsurance.FixedVoluntaryAmount = Convert.ToDecimal(txtFixedVoluntaryAmount.Text) ;
                objCarInsurance.FixedCompulsoryAmount = Convert.ToDecimal(txtFixedCompulsoryAmount.Text) ;
                objCarInsurance.AnnuallyGrossAmount = Convert.ToDecimal(txtAnnuallyGrossAmount.Text);
                objCarInsurance.TotalMonth = Convert.ToInt32(txtTotalMonth.Text);
                objCarInsurance.InstallmentAmount = Convert.ToDecimal(txtInstallmentAmount.Text);
                //objCarInsurance.PremiumPolicyID = (Int32) Utilities.EnumCollection.PremiumPolicy.(dropDownComInfoID.SelectedValue.ToString()) ;
               
                objCarInsurance.IsRemoved = false;
                
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return objCarInsurance;
        }

        private void ClearData()
        {
            txtCarInsuranceParameterID.Text = string.Empty;
            DropDownCompanyInfoID.SelectedIndex = -1;
            hdCarInsuranceTypeID.Value = string.Empty;
            txtCarValueAmount.Text = string.Empty;
            txtFixedTotalAmount.Text = string.Empty;
            txtFixedVoluntaryAmount.Text = string.Empty;
            txtFixedCompulsoryAmount.Text = string.Empty;
            txtAnnuallyGrossAmount.Text = string.Empty;
            txtTotalMonth.Text = string.Empty;
            txtInstallmentAmount.Text = string.Empty;
            Session[seCarInsuranceFeatureColl] = null;
            ddlCarType.SelectedIndex = -1;
            ddlCarCondition.SelectedIndex = -1;
            txtMinCarValueAmount.Text = string.Empty;
            txtMaxCarValueAmount.Text = string.Empty;
            DivShowCarInsParDiv.Visible = false;
            showGrid();
      
        }

        protected void btnShowCarInsParDiv_Click(object sender, EventArgs e)
        {
            try
            {
          
                    hdCarParamChk.Value = "true";
                    DivShowCarInsParDiv.Visible = true;
                    LoadDropDownCarType(null);
                    LoadDropDownCarCondition(null);

                    showGrid();
                    btnShowCarInsParDiv.Enabled = false;

            }

            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            
        }
        private void LoadDropDownCarType(int? LIApplicableAmntYrScdleOb)
        {
            try
            {


                {
                    ddlCarType.Items.Add(new ListItem("Select Car Type ", "-1"));
                    foreach (Utilities.EnumCollection.CarType r in Enum.GetValues(typeof(Utilities.EnumCollection.CarType)))
                    {
                        ListItem item = new ListItem(Enum.GetName(typeof(Utilities.EnumCollection.CarType), r), r.ToString());
                        ddlCarType.Items.Add(item);
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        private void LoadDropDownCarCondition(int? LIApplicableAmntYrScdleOb)
        {
            try
            {


                {
                    ddlCarCondition.Items.Add(new ListItem("Select Car Condition Type ", "-1"));
                    foreach (Utilities.EnumCollection.CarCondition r in Enum.GetValues(typeof(Utilities.EnumCollection.CarCondition)))
                    {
                        ListItem item = new ListItem(Enum.GetName(typeof(Utilities.EnumCollection.CarCondition), r), r.ToString());
                        ddlCarCondition.Items.Add(item);
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        protected void lnkbSelect_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton linkButton = (LinkButton)sender;
                int id = Convert.ToInt32(linkButton.CommandArgument);
                hdCarInsuranceTypeID.Value = id.ToString();
                CarInsuranceParameterRT _Rt = new CarInsuranceParameterRT();
                string carParString = _Rt.BindForSearchResult(id);
                txtCarInsuranceParameterID.Text = carParString;
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        public void showGrid(List<CarInsuranceParameter>  ob)
        {
            try
            {
                //var llll = _countryRT.GetAllLoanAmntYrScdle().ToList();
                
                lvInsuranceParameter.DataSource = ob;
                lvInsuranceParameter.DataBind();

            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        public void showGrid()
        {
            try
            {
                //var llll = _countryRT.GetAllLoanAmntYrScdle().ToList();

                lvInsuranceParameter.DataSource = null;
                lvInsuranceParameter.DataBind();

            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void btnSearchParameter_Click(object sender, EventArgs e)
        {
            CarInsuranceParameter objCarInsuranceParameter = new CarInsuranceParameter();
            try
            {

                objCarInsuranceParameter.CarTypeID = (Int32)Enum.Parse(typeof(Utilities.EnumCollection.CarType), ddlCarType.SelectedValue.ToString());
                objCarInsuranceParameter.CarConditionID = (Int32)Enum.Parse(typeof(Utilities.EnumCollection.CarCondition), ddlCarCondition.SelectedValue.ToString());
                if (txtMinCarValueAmount.Text != "")
                {
                    objCarInsuranceParameter.MinCarValueAmount = Convert.ToDecimal(txtMinCarValueAmount.Text);
                }
                else
                    objCarInsuranceParameter.MinCarValueAmount = 0;

                if (txtMaxCarValueAmount.Text != "")
                {
                    objCarInsuranceParameter.MaxCarValueAmount = Convert.ToDecimal(txtMaxCarValueAmount.Text);
                }
                else
                    objCarInsuranceParameter.MaxCarValueAmount=0;
                List<CarInsuranceParameter> objCarInsuranceParameter2 = new List<CarInsuranceParameter>();
                CarInsuranceParameterRT obj = new CarInsuranceParameterRT();
                if (objCarInsuranceParameter.MinCarValueAmount != 0 && objCarInsuranceParameter.MaxCarValueAmount != 0)
                     objCarInsuranceParameter2 = obj.SearchCarInsuranceParameter1(objCarInsuranceParameter);
                else if (objCarInsuranceParameter.MinCarValueAmount != 0 && objCarInsuranceParameter.MaxCarValueAmount == 0)
                    objCarInsuranceParameter2 = obj.SearchCarInsuranceParameter2(objCarInsuranceParameter);
                else if (objCarInsuranceParameter.MinCarValueAmount == 0 && objCarInsuranceParameter.MaxCarValueAmount != 0)
                    objCarInsuranceParameter2 = obj.SearchCarInsuranceParameter3(objCarInsuranceParameter);
                else
                    objCarInsuranceParameter2 = obj.SearchCarInsuranceParameter4(objCarInsuranceParameter);
                if (objCarInsuranceParameter2.Count > 0)
                    showGrid(objCarInsuranceParameter2);
                else
                    showGrid();

                


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

    }
}