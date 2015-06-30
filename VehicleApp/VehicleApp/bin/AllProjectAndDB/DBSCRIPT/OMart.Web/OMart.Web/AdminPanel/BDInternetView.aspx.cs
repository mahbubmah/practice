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
    public partial class BDInternetView : System.Web.UI.Page
   {
        private readonly BDInternetRT _BDInternetRT;

        int lvRowCount = 0;
        int currentPage = 0;
        public BDInternetView()
        {
            this._BDInternetRT = new BDInternetRT();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showBDInternetGrid();
            }
        }

        public void showBDInternetGrid()
        {
            try
            {
                //var llll = _countryRT.GetAllLoanAmntYrScdle().ToList();
                lvBDInternet.DataSource = _BDInternetRT.GetAllLoanAmntYrScdle();
                lvBDInternet.DataBind();             
                
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void dataPagerBDInternet_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    showBDInternetGrid();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lvBDInternet_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            labelMessage.Text = string.Empty;
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("BDInternetInsertUpdate.aspx?IID=0",false);
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
                Response.Redirect("BDInternetInsertUpdate.aspx?IID=" + id, false);
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
                var objBDInternet = _BDInternetRT.GetBDInternetByIID(Convert.ToInt32(linkButton.CommandArgument));
                if (objBDInternet != null)
                {
                    objBDInternet.IsRemoved = true;
                    BDInternetRT loanRT = new BDInternetRT();

                    loanRT.UpdateLoanAmntYrScdle(objBDInternet);
                    showBDInternetGrid();

                    labelMessage.Text = "BDInternet has been removed successfully.";
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