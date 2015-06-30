using BLL.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using Utilities;

namespace OMart.Web.AdminPanel
{
    public partial class CompanyInfoDisplay : System.Web.UI.Page
    {
        private readonly CompanyInfoRT _companyInfoRT;

        int lvRowCount = 0;
        int currentPage = 0;
        public CompanyInfoDisplay()
        {
            this._companyInfoRT = new CompanyInfoRT();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showCompanyInfoGrid();
            }
        }

        private void showCompanyInfoGrid()
        {
            try
            {
                lvCompanyInfoDisplay.DataSource = _companyInfoRT.GetAllCompanyInformations();
                lvCompanyInfoDisplay.DataBind();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error : " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void dataPagerCompanyInfoDisplay_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    showCompanyInfoGrid();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error : " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lvCompanyInfoDisplay_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            lblMessage.Text = string.Empty;
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("CompanyInfoInsertUpdate.aspx?IID=0");
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error : " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lnkbEdit_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton linkButton = (LinkButton)sender;
                int id = Convert.ToInt32(linkButton.CommandArgument);
                Response.Redirect("CompanyInfoInsertUpdate.aspx?IID=" + id);
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error : " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lnkbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton linkButton = new LinkButton();
                linkButton = (LinkButton)sender;
                var objCompanyInfo = _companyInfoRT.GetCompanyInfoByIID(Convert.ToInt32(linkButton.CommandArgument));
                if (objCompanyInfo != null)
                {
                    objCompanyInfo.IsRemoved = true;
                    _companyInfoRT.UpdateCompanyInfo(objCompanyInfo);
                    showCompanyInfoGrid();

                    lblMessage.Text = "Company Information has been removed successfully.";
                    lblMessage.ForeColor = System.Drawing.Color.Green;

                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error : " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        
    }

    }
