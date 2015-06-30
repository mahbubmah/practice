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
    public partial class CarInsuranceParameterView : System.Web.UI.Page
    { 
        private readonly CarInsuranceParameterRT _CarInsuranceParameterRT;

        int lvRowCount = 0;
        int currentPage = 0;
        public CarInsuranceParameterView()
        {
            this._CarInsuranceParameterRT = new CarInsuranceParameterRT();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showCarInsuranceParameterGrid();
            }
        }

        public void showCarInsuranceParameterGrid()
        {
            try
            {
                //var llll = _countryRT.GetAllLoanAmntYrScdle().ToList();
                lvCarInsuranceParameter.DataSource = _CarInsuranceParameterRT.GetAllCarInsuranceParameterForListView();
                lvCarInsuranceParameter.DataBind();             
                
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void dataPagerCarInsuranceParameter_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    showCarInsuranceParameterGrid();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lvCarInsuranceParameter_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            labelMessage.Text = string.Empty;
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("CarInsuranceParameterInsertUpdate.aspx?IID=0", false);
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
                Response.Redirect("CarInsuranceParameterInsertUpdate.aspx?IID=" + id, false);
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
                var objCarInsuranceParameter = _CarInsuranceParameterRT.GetCarInsuranceParameterByIID(Convert.ToInt32(linkButton.CommandArgument));
                if (objCarInsuranceParameter != null)
                {
                    objCarInsuranceParameter.IsRemoved = true;
                    CarInsuranceParameterRT loanRT = new CarInsuranceParameterRT();
                    loanRT.UpdateCarInsuranceParameter(objCarInsuranceParameter);
                    showCarInsuranceParameterGrid();

                    labelMessage.Text = "CarInsuranceParameter has been removed successfully.";
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