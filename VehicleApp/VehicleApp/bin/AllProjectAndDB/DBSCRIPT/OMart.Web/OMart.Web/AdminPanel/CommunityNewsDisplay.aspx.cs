using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMart.Web.AdminPanel
{
    public partial class CommunityNewsDisplay : System.Web.UI.Page
    {
       private readonly CommunityNewsRT _CommunityNewsRT;

        int lvRowCount = 0;
        int currentPage = 0;
        public CommunityNewsDisplay()
        {
            this._CommunityNewsRT = new CommunityNewsRT();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showCommunityNewsGrid();
            }
        }

        private void showCommunityNewsGrid()
        {
            try
            {
                lvCommunityNews.DataSource = _CommunityNewsRT.GetAllCommunityNews();
                lvCommunityNews.DataBind();
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void dataPagerCommunityNews_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    showCommunityNewsGrid();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lvCommunityNews_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            labelMessage.Text = string.Empty;
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("CommunityNewsInsertUpdate.aspx?IID=0");
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
                Response.Redirect("CommunityNewsInsertUpdate.aspx?IID=" + id);
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
                var objCommunityNews = _CommunityNewsRT.GetCommunityNewsByIID(Convert.ToInt32(linkButton.CommandArgument));
                if (objCommunityNews != null)
                {
                    objCommunityNews.IsRemoved = true;
                    _CommunityNewsRT.UpdateCommunityNews(objCommunityNews);
                    showCommunityNewsGrid();

                    labelMessage.Text = "CommunityNews has been removed successfully.";
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