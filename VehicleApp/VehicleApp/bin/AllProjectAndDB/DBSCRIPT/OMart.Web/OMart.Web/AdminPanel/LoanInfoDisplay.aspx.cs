using BLL.Basic;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMart.Web.AdminPanel
{
    public partial class LoanInfoDisplay : System.Web.UI.Page
    {
        #region variable declaration
        private readonly LoanInfoRT _LoanInfoRT;
        int lvRowCount = 0;
        int currentPage = 0;
        #endregion variable declaration

        #region protected mathod
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            { 
                if(!IsPostBack)
                {
                    showLoanInfoInListView();
                }
            }
            catch(Exception ex)
            {
            
            }
        }
        public LoanInfoDisplay()
        {
            _LoanInfoRT = new LoanInfoRT();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("LoanInfoInsertUpdate.aspx?IID=0");
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
                Response.Redirect("LoanInfoInsertUpdate.aspx?IID=" + id);
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
                var loanInfo = _LoanInfoRT.GetLoanInfoByIID(Convert.ToInt32(linkButton.CommandArgument));
                if (loanInfo != null)
                {
                    loanInfo.IsRemoved = true;
                    _LoanInfoRT.UpdateLoanInfo(loanInfo);
                    showLoanInfoInListView();
                    labelMessage.Text = "Loan Information has been removed successfully.";
                    labelMessage.ForeColor = System.Drawing.Color.Green;

                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void dataPagerLoanInfo_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    showLoanInfoInListView();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lvLoanInfo_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            labelMessage.Text = string.Empty;
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void lvLoanInfo_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    showLoanInfoInListView();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
#endregion protected method


        #region private method

        private void showLoanInfoInListView()
        {
            try
            {
                lvLoanInfo.DataSource = _LoanInfoRT.GetAllLoanInfoForDisplay();
                lvLoanInfo.DataBind();
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        #endregion private method

      
    }
}