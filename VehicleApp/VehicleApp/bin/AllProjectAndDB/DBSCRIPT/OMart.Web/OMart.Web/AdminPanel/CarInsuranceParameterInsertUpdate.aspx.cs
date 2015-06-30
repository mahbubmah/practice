using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Basic;
using DAL;
using Utilities;
using System.Globalization;
using System.Text;
using System.IO;

namespace OMart.Web.AdminPanel
{
    public partial class CarInsuranceParameterInsertUpdate : System.Web.UI.Page
    {
       private readonly CarInsuranceParameterRT _BDCarInsuranceParameterRT;
        
        private int IID = default(int);

        public CarInsuranceParameterInsertUpdate()
        {
            _BDCarInsuranceParameterRT = new CarInsuranceParameterRT();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                
                if (!IsPostBack)
                {

                    LoadDropDownCarType(null);
                    LoadDropDownCarCondition(null);
                    var requestId = Request.QueryString["IID"];
                    int reqID = Convert.ToInt32( requestId);
                    bool reqIDIsValid = Int32.TryParse(requestId, out IID);
                    if (reqID != 0 )
                    {
                        ShowCarInsuranceParameterData();
                    }
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
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
        
        
        protected void btn_CreateOrEdit_Click(object sender, EventArgs e)
        {
            try
            {
                CarInsuranceParameter CarInsuranceParameter = CreateCarInsuranceParameter();
                CarInsuranceParameterRT channelRT = new CarInsuranceParameterRT();
                bool reqIDIsValid = Int32.TryParse(Request.QueryString["IID"], out IID);
                string msg = (string)BusinessLogicValidation(CarInsuranceParameter);
                var requestId = Request.QueryString["IID"];
                int reqID = Convert.ToInt32(requestId);
                if (string.IsNullOrEmpty(msg))
                {
                    if (IID <= 0)
                    {
                        CarInsuranceParameter.CreatedBy = Convert.ToInt64(Session["UserID"]);
                        CarInsuranceParameter.CreatedDate = DateTime.Now;
                        CarInsuranceParameter.IsRemoved = chkIsRemoved.Checked;
                        CarInsuranceParameterRT loanRT = new CarInsuranceParameterRT();
                        loanRT.AddCarInsuranceParameter(CarInsuranceParameter);
                        ClearData();

                        labelMessage.Text = "Information has been inserted successfully.";
                        labelMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        CarInsuranceParameterRT loanRT = new CarInsuranceParameterRT();
                        CarInsuranceParameter objCarInsuranceParameter = loanRT.GetCarInsuranceParameterByIID(IID);

                        if (objCarInsuranceParameter != null)
                        {
                            CarInsuranceParameter.CreatedBy = objCarInsuranceParameter.CreatedBy; 
                            CarInsuranceParameter.CreatedDate = objCarInsuranceParameter.CreatedDate;
                            //CarInsuranceParameter.IsRemoved = objCarInsuranceParameter.IsRemoved;
                            CarInsuranceParameter.IID = objCarInsuranceParameter.IID;

                            CarInsuranceParameter.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                            CarInsuranceParameter.ModifiedDate = DateTime.Now;
                            
                            loanRT.UpdateCarInsuranceParameter(CarInsuranceParameter);
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
            //ob.showCarInsuranceParameterGrid();
        }

        private string BusinessLogicValidation(CarInsuranceParameter CarInsuranceParameter)
        {
            string message = string.Empty;
            //bool reqIDIsValid = Int32.TryParse(Request.QueryString["IID"], out IID);


            //if (string.IsNullOrEmpty(CarInsuranceParameter.Name))
            //{
            //    return message = "CarInsuranceParameter name is required.";
            //}
            ////if (string.IsNullOrEmpty(CarInsuranceParameter.LogoUrl.ToString()))
            ////{
            ////    return message = "CarInsuranceParameter name is required.";
            ////}
            //if (IID <= 0)
            //{
            //    CarInsuranceParameterRT _BDCarInsuranceParameterRT2 = new CarInsuranceParameterRT();
            //    CarInsuranceParameter objCarInsuranceParameterName = _BDCarInsuranceParameterRT2.GetCarInsuranceParameterName(CarInsuranceParameter.Name);
            //    if (objCarInsuranceParameterName != null)
            //    {
            //        if (objCarInsuranceParameterName.Name == CarInsuranceParameter.Name)
            //        {
            //            return message = "CarInsuranceParameter name already exists.";
            //        }
            //    }

                

                


            //}
            //else
            //{
            //    CarInsuranceParameterRT _BDCarInsuranceParameterRT2 = new CarInsuranceParameterRT();
            //    CarInsuranceParameter CarInsuranceParameterName = (from tr in _BDCarInsuranceParameterRT2.GetAllCarInsuranceParameter()
            //                              where tr.Name == CarInsuranceParameter.Name && tr.IID != IID
            //                              select tr).SingleOrDefault();
            //     if (CarInsuranceParameterName != null)
            //    {
            //        if (CarInsuranceParameterName.Name == CarInsuranceParameter.Name)
            //        {
            //            return message = "CarInsuranceParameter name already exists.";
            //        }
            //    }

                 

                
            //}

            return message;
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/AdminPanel/CarInsuranceParameterView");
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void ShowCarInsuranceParameterData()
        {
            try
            {
                CarInsuranceParameterRT loanRt = new CarInsuranceParameterRT();
                CarInsuranceParameter objCarInsuranceParameter = loanRt.GetCarInsuranceParameterByIID(IID);
                if (objCarInsuranceParameter != null)
                {
                    ddlCarType.SelectedValue = Enum.GetName(typeof(Utilities.EnumCollection.CarType), objCarInsuranceParameter.CarTypeID);
                    ddlCarCondition.SelectedValue = Enum.GetName(typeof(Utilities.EnumCollection.CarCondition), objCarInsuranceParameter.CarConditionID);
                    txtMinRun.Text = objCarInsuranceParameter.MinRun.ToString();
                    txtMaxRun.Text = objCarInsuranceParameter.MaxRun.ToString();
                    txtMinCarAge.Text = objCarInsuranceParameter.MinCarAge.ToString();
                    txtMaxCarAge.Text = objCarInsuranceParameter.MaxCarAge.ToString();
                    txtMinCarValueAmount.Text = objCarInsuranceParameter.MinCarValueAmount.ToString(); 
                    txtMaxCarValueAmount.Text = objCarInsuranceParameter.MaxCarValueAmount.ToString();                    
                    txtPremiumTotalPercent.Text = objCarInsuranceParameter.PremiumTotalPercent.ToString();
                    txtDuration.Text = objCarInsuranceParameter.Duration.ToString();
                    
                    chkIsRemoved.Checked = objCarInsuranceParameter.IsRemoved;


                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        //private string BusinessLogicValidation(CarInsuranceParameter CarInsuranceParameter)
        //{
        //    string message = string.Empty;
        //    bool reqIDIsValid = Int32.TryParse(Request.QueryString["IID"], out IID);

        //    if (IID <= 0)
        //    {
        //        CarInsuranceParameter objCarInsuranceParameterName = (from tr in _CarInsuranceParameterRT.GetAllLoanAmntYrScdle()
        //                                              where tr.CompanyInfoID == CarInsuranceParameter.CompanyInfoID
        //                                              select tr).SingleOrDefault();
        //        if (CarInsuranceParameter != null)
        //        {
        //            if (objCarInsuranceParameterName.CompanyInfoID == CarInsuranceParameter.CompanyInfoID)
        //            {
        //                message = "CarInsuranceParameter name already exists.";
        //            }
        //        }

        //    }

        //    return message;
        //}

        private CarInsuranceParameter CreateCarInsuranceParameter()
        {
            Session["UserID"] = "1";
            CarInsuranceParameter objCarInsuranceParameter = new CarInsuranceParameter();
            try
            {

                objCarInsuranceParameter.CarTypeID =(Int32)Enum.Parse(typeof(Utilities.EnumCollection.CarType), ddlCarType.SelectedValue.ToString()); 
                objCarInsuranceParameter.CarConditionID =  (Int32)Enum.Parse(typeof(Utilities.EnumCollection.CarCondition), ddlCarCondition.SelectedValue.ToString());
                objCarInsuranceParameter.MinRun = Convert.ToInt64( txtMinRun.Text ) ;
                objCarInsuranceParameter.MaxRun = Convert.ToInt64( txtMaxRun.Text );
                objCarInsuranceParameter.MinCarAge = Convert.ToInt32( txtMinCarAge.Text ) ;
                objCarInsuranceParameter.MaxCarAge = Convert.ToInt32( txtMaxCarAge.Text );
                objCarInsuranceParameter.MinCarValueAmount = Convert.ToDecimal( txtMinCarValueAmount.Text ) ;
                objCarInsuranceParameter.MaxCarValueAmount = Convert.ToDecimal( txtMaxCarValueAmount.Text );
                 objCarInsuranceParameter.PremiumTotalPercent = Convert.ToDouble( txtPremiumTotalPercent.Text );
                objCarInsuranceParameter.Duration = Convert.ToInt32( txtDuration.Text) ;

                objCarInsuranceParameter.IsRemoved = chkIsRemoved.Checked ;
                
                
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return objCarInsuranceParameter;
        }

        private void ClearData()
        {


            ddlCarType.SelectedIndex = -1 ;
            ddlCarCondition.SelectedIndex = -1;
            txtMinRun.Text = string.Empty;
            txtMaxRun.Text = string.Empty;
            txtMinCarAge.Text = string.Empty;
            txtMaxCarAge.Text = string.Empty;
            txtMinCarValueAmount.Text = string.Empty;
            txtMaxCarValueAmount.Text = string.Empty;
            txtPremiumTotalPercent.Text = string.Empty;
            txtDuration.Text = string.Empty;

            chkIsRemoved.Checked = false;
            
        }

    }
}