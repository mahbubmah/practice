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
    public partial class AdLogInfoView : System.Web.UI.Page
    {
        private readonly AdLogInfoRT _AdLogInfoRT;

        int lvRowCount = 0;
        int currentPage = 0;
        public AdLogInfoView()
        {
            this._AdLogInfoRT = new AdLogInfoRT();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showAdLogInfoGrid();
            }
        }

        public void showAdLogInfoGrid()
        {
            try
            {
                //var llll = _countryRT.GetAllLoanAmntYrScdle().ToList();
                lvAdLogInfo.DataSource = _AdLogInfoRT.GetAllAdLogInfoForListView();
                lvAdLogInfo.DataBind();             
                
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void dataPagerAdLogInfo_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    showAdLogInfoGrid();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lvAdLogInfo_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            labelMessage.Text = string.Empty;
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("AdLogInfoViewInsertUpdate.aspx?IID=0", false);
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
                Response.Redirect("AdLogInfoViewInsertUpdate.aspx?IID=" + id, false);
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
                var objAdLogInfo = _AdLogInfoRT.GetAdLogInfoByIID(Convert.ToInt32(linkButton.CommandArgument));
                if (objAdLogInfo != null)
                {
                    objAdLogInfo.IsRemoved = true;
                    AdLogInfoRT loanRT = new AdLogInfoRT();
                    loanRT.UpdateAdLogInfo(objAdLogInfo);
                    showAdLogInfoGrid();

                    labelMessage.Text = "AdLogInfo has been removed successfully.";
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