using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Basic;

namespace OMart.Web.AdminPanel
{
    public partial class AllNewsDisplay : System.Web.UI.Page
    {
        private readonly AllNewsRT _allNewsRt;

        int lvRowCount = 0;
        int currentPage = 0;
        public AllNewsDisplay()
        {
            this._allNewsRt = new AllNewsRT();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowCardInfoGrid();
            }
        }

        private void ShowCardInfoGrid()
        {
            try
            {
                lvAllNews.DataSource = _allNewsRt.GetAllNewsForListViewDisplay();
                lvAllNews.DataBind();
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
                Response.Redirect("AllNewsInsertUpdate");
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
                Int64 id = Convert.ToInt64(linkButton.CommandArgument);
                Response.Redirect("AllNewsInsertUpdate.aspx?IID=" + id);
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
                var objAllNews = _allNewsRt.GetAllNewsByIid(Convert.ToInt32(linkButton.CommandArgument));
                if (objAllNews != null)
                {
                    objAllNews.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                    objAllNews.ModifiedDate = GlobalRT.GetServerDateTime();
                    objAllNews.IsRemoved = true;
                    _allNewsRt.UpdateAllNews(objAllNews);

                    //delete All News detail by card info iid

                    var allNewsDetailList = _allNewsRt.GetAllNewsDetailListByAllNesIid(objAllNews.IID);
                    foreach (var allNewsDetail in allNewsDetailList)
                    {
                        allNewsDetail.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                        allNewsDetail.ModifiedDate = GlobalRT.GetServerDateTime();
                        allNewsDetail.IsRemoved = true;
                        _allNewsRt.UpdateAllNewsDetail(allNewsDetail);
                    }


                    ShowCardInfoGrid();

                    labelMessage.Text = "Inforamion has been removed successfully.";
                    labelMessage.ForeColor = System.Drawing.Color.Green;

                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lvAllNews_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            labelMessage.Text = string.Empty;
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void dataPagerAllNews_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    ShowCardInfoGrid();
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