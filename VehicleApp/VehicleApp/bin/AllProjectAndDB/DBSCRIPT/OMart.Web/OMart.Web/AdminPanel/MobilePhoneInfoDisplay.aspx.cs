using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Basic;

namespace OMart.Web.AdminPanel
{
    public partial class MobilePhoneInfoDisplay : System.Web.UI.Page
    {
       
        private readonly MobilePhoneInfoRT _MobilePhoneInfoRT;

        int lvRowCount = 0;
        int currentPage = 0;
        public MobilePhoneInfoDisplay()
        {
            this._MobilePhoneInfoRT = new MobilePhoneInfoRT();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showMobilePhoneInfoGrid();
            }
        }

        private void showMobilePhoneInfoGrid()
        {
            try
            {
                lvMobilePhoneInfoDisplay.DataSource = _MobilePhoneInfoRT.GetAllMobilePhoneInformations();
                lvMobilePhoneInfoDisplay.DataBind();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error : " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void dataPagerMobilePhoneInfoDisplay_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    showMobilePhoneInfoGrid();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error : " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lvMobilePhoneInfoDisplay_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            lblMessage.Text = string.Empty;
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("MobilePhoneInfoInsertUpdate.aspx?IID=0");
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
                Response.Redirect("MobilePhoneInfoInsertUpdate.aspx?IID=" + id);
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
                var objMobilePhoneInfo = _MobilePhoneInfoRT.GetMobilePhoneInfoByIID(Convert.ToInt64(linkButton.CommandArgument));
                if (objMobilePhoneInfo != null)
                {
                    objMobilePhoneInfo.IsRemoved = true;
                    _MobilePhoneInfoRT.UpdateMobilePhoneInfo(objMobilePhoneInfo);
                    showMobilePhoneInfoGrid();

                    lblMessage.Text = "Location has been removed successfully.";
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
