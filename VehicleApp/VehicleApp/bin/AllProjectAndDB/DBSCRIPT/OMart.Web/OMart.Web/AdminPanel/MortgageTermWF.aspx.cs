using BLL.Basic;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMart.Web
{
    public partial class MortgageTermWF : System.Web.UI.Page
    {
        private readonly MortgageTermYearRT _mortgageTermYearRT;
        private int IID = default(int);

        int lvRowCount = 0;
        int currentPage = 0;

        public MortgageTermWF()
        {
            this._mortgageTermYearRT = new MortgageTermYearRT();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           
               chkIsRemovedMortgageTerm.Visible = false;          

            try
            {
                if (!IsPostBack)
                {
                    hdEdit.Value = "false";
                    hdIID.Value = string.Empty;
                    var requestId = Request.QueryString["IID"];
                    bool reqIDIsValid = Int32.TryParse(requestId, out IID);              

                    if (reqIDIsValid)
                    {
                        ShowMortgageYearData();
                        
                    }
                    showMortgageTermYearGrid();
                }
               
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void ShowMortgageYearData()
        {
            try
            {
                MortgageTermYear objMortgage = _mortgageTermYearRT.GetMortgageYearByIID(IID);
                if (objMortgage != null)
                {
                    txtMortgageYear.Text =Convert.ToString(objMortgage.NumberOfYear);
                    txtDescription.Text = objMortgage.Description;                    
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
                    MortgageTermYear mortYear = CreateMortgaeYear();

                    if (IID <= 0)
                    {                      
                        mortYear.CreatedBy = Convert.ToInt64(Session["UserID"]);
                        mortYear.CreatedDate = DateTime.Now;
                        if (hdEdit.Value == "true")
                        {
                            _mortgageTermYearRT.UpdateMortgageYear(mortYear);
                            hdEdit.Value = "false";
                        }
                        else
                            _mortgageTermYearRT.AddMortgageYear(mortYear);
                           

                        labelMessage.Text = "Information has been submitted successfully.";
                        labelMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        MortgageTermYear objMortgage = _mortgageTermYearRT.GetMortgageYearByIID(IID);

                        if (objMortgage != null)
                        {
                            mortYear.CreatedBy = objMortgage.CreatedBy; ;
                            mortYear.CreatedDate = objMortgage.CreatedDate;
                            mortYear.IsRemoved = objMortgage.IsRemoved;
                            mortYear.IID = objMortgage.IID;

                            mortYear.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                            mortYear.ModifiedDate = DateTime.Now;

                            _mortgageTermYearRT.AddMortgageYear(mortYear);


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

            chkIsRemovedMortgageTerm.Visible = false;
            showMortgageTermYearGrid();
            ClearData();
        }

        private void ClearData()
        {
            txtMortgageYear.Text = string.Empty; 
            txtDescription.Text = string.Empty;           
           
        }

        private void showMortgageTermYearGrid()
        {
            try
            {
                lvUserGroup.DataSource = _mortgageTermYearRT.GetAllMortgageTermYear();
                lvUserGroup.DataBind();
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private MortgageTermYear CreateMortgaeYear()
        {
            Session["UserID"] = "1";
            MortgageTermYear mortgageYear = new MortgageTermYear();
            try
            {
                if (hdEdit.Value == "true")
                {                   
                    mortgageYear.IID = Convert.ToInt32(hdIID.Value);                                      
                }
                mortgageYear.NumberOfYear = Convert.ToInt32(txtMortgageYear.Text);
                mortgageYear.Description = txtDescription.Text.Trim();
                mortgageYear.IsRemoved = chkIsRemovedMortgageTerm.Checked;

            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return mortgageYear;
        }

        protected void lnkbEdit_Click(object sender, EventArgs e)
        {
            try
            {
             
                hdEdit.Value = "true";
                LinkButton linkButton = (LinkButton)sender;
                hdIID.Value = linkButton.CommandArgument;

                fillMortgage(Convert.ToInt32(hdIID.Value));
               
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void fillMortgage(int id)
        {
            MortgageTermYear mor = new MortgageTermYear();
            mor = _mortgageTermYearRT.GetMortgageYearByIID(id);
            try
             {
                 txtMortgageYear.Text = mor.NumberOfYear.ToString();
                 txtDescription.Text = mor.Description;
                 chkIsRemovedMortgageTerm.Checked = mor.IsRemoved;
                 chkIsRemovedMortgageTerm.Visible = true;
             }
            catch(Exception ex)
            {

            }
        }

        protected void dataPagerMortgageTerm_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    ShowMortgageYearData();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lvMortgageTerm_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            labelMessage.Text = string.Empty;
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void lnkbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton linkButton = new LinkButton();
                linkButton = (LinkButton)sender;
                var objMortgageTermYear = _mortgageTermYearRT.GetMortgageYearByIID(Convert.ToInt32(linkButton.CommandArgument));
                if (objMortgageTermYear != null)
                {
                    objMortgageTermYear.IsRemoved = true;
                    _mortgageTermYearRT.UpdateMortgageYear(objMortgageTermYear);
                    ShowMortgageYearData();

                    labelMessage.Text = "Mortgage Term Year removed successfully.";
                    labelMessage.ForeColor = System.Drawing.Color.Green;
                    showMortgageTermYearGrid();

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
            txtMortgageYear.Text = string.Empty;
            txtDescription.Text = string.Empty;
            chkIsRemovedMortgageTerm.Checked = false;
            labelMessage.Text = string.Empty;
           
        }               
        
    }
}