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
    public partial class LoanAmntYrScdle : System.Web.UI.Page
    {
        private readonly LoanAmntYrScdleRT _LoanAmountYearScheduleRT;

        int lvRowCount = 0;
        int currentPage = 0;
        public LoanAmntYrScdle()
        {
            this._LoanAmountYearScheduleRT = new LoanAmntYrScdleRT();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showLoanAmountYearScheduleGrid();
            }
        }

        public void showLoanAmountYearScheduleGrid()
        {
            try
            {
                //var llll = _countryRT.GetAllLoanAmntYrScdle().ToList();
                lvLoanAmountYearSchedule.DataSource = _LoanAmountYearScheduleRT.GetAllLoanAmntYrScdleList();
                lvLoanAmountYearSchedule.DataBind();             
                
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void dataPagerLoanAmountYearSchedule_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    showLoanAmountYearScheduleGrid();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lvLoanAmountYearSchedule_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            labelMessage.Text = string.Empty;
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("LoanAmntYrScdleInsertUpdate.aspx?IID=0",false);
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
                Response.Redirect("LoanAmntYrScdleInsertUpdate.aspx?IID=" + id, false);
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
                var objLoanAmountYearSchedule = _LoanAmountYearScheduleRT.GetAddLoanAmntYrScdleByIID(Convert.ToInt32(linkButton.CommandArgument));
                if (objLoanAmountYearSchedule != null)
                {
                    objLoanAmountYearSchedule.IsRemoved = true;
                    LoanAmntYrScdleRT loanRT = new LoanAmntYrScdleRT();
                    loanRT.UpdateLoanAmntYrScdle(objLoanAmountYearSchedule);
                    showLoanAmountYearScheduleGrid();

                    labelMessage.Text = "LoanAmountYearSchedule has been removed successfully.";
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