using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Basic;
using DAL;

namespace OMart.Web.AdminPanel
{
    public partial class CarInsuranceView : System.Web.UI.Page
    {
        private readonly CarInsuranceRT _CarInsuranceRT;

        int lvRowCount = 0;
        int currentPage = 0;
        public CarInsuranceView()
        {
            this._CarInsuranceRT = new CarInsuranceRT();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showCarInsuranceGrid();
            }
        }

        public void showCarInsuranceGrid()
        {
            try
            {
                //var llll = _countryRT.GetAllLoanAmntYrScdle().ToList();
                lvCarInsurance.DataSource = _CarInsuranceRT.GetAllLoanAmntYrScdle();
                lvCarInsurance.DataBind();             
                
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void dataPagerCarInsurance_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    showCarInsuranceGrid();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lvCarInsurance_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            labelMessage.Text = string.Empty;
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("CarInsuranceInsertUpdate.aspx?IID=0",false);
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lnkbEdit_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton linkButton = (LinkButton)sender;
                int id = Convert.ToInt32(linkButton.CommandArgument);
                Response.Redirect("CarInsuranceInsertUpdate.aspx?IID=" + id, false);
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lnkbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton linkButton = new LinkButton();
                linkButton = (LinkButton)sender;
                var objCarInsurance = _CarInsuranceRT.GetAddLoanAmntYrScdleByIID(Convert.ToInt32(linkButton.CommandArgument));
                if (objCarInsurance != null)
                {
                    objCarInsurance.IsRemoved = true;
                    CarInsuranceRT loanRT = new CarInsuranceRT();

                    loanRT.UpdateLoanAmntYrScdle(objCarInsurance);
                    showCarInsuranceGrid();

                    labelMessage.Text = "CarInsurance has been removed successfully.";
                    labelMessage.ForeColor = System.Drawing.Color.Green;

                }
                
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}