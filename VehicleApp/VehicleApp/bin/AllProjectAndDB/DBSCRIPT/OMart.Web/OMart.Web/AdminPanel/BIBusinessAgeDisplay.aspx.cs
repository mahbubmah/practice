using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Basic;

namespace OMart.Web.AdminPanel
{
    public partial class BIBusinessAgeDisplay : System.Web.UI.Page
    {
        private readonly BIAgeRT _biAgeRt;
        int lvRowCount = 0;
        int currentPage = 0;

        public BIBusinessAgeDisplay()
        {
            _biAgeRt = new BIAgeRT();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadBusinessAgeListView();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void LoadBusinessAgeListView()
        {
            try
            {
                var businessAgeList = _biAgeRt.GetAllBusinessAgeListForListView();
                lvBusinessAge.DataSource = businessAgeList;
                lvBusinessAge.DataBind();
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }


        protected void dataPagerBusinessAge_OnPreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    LoadBusinessAgeListView();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lvBusinessAge_OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            try
            {
                labelMessage.Text = string.Empty;
                currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("BIBusinessAgeInsertUpdate");
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
                long id = Convert.ToInt64(linkButton.CommandArgument);
                Response.Redirect("BIBusinessAgeInsertUpdate.aspx?IID=" + id);
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
                var objBusinessAge = _biAgeRt.GetBiAgeIntervalByIid(Convert.ToInt64(linkButton.CommandArgument));
                if (objBusinessAge != null)
                {
                    objBusinessAge.IsRemoved = true;
                    _biAgeRt.UpdateBusinessAge(objBusinessAge);
                    LoadBusinessAgeListView();

                    labelMessage.Text = "Information has been removed successfully.";
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