using BLL.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMart.Web.AdminPanel
{
    public partial class AllFeatureDisplay : System.Web.UI.Page
    {

        private readonly AllFeatureRT _AllFeatureRT;

        int lvRowCount = 0;
        int currentPage = 0;
        public AllFeatureDisplay()
        {
            this._AllFeatureRT = new AllFeatureRT();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowFeatureInfoGrid();
            }
        }

        private void ShowFeatureInfoGrid()
        {
            try
            {
                lvAllFeature.DataSource = _AllFeatureRT.GetAllFeatureForListViewDisplay();
                lvAllFeature.DataBind();
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lvAllFeature_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            labelMessage.Text = string.Empty;
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void lvAllFeature_PreRender(object sender, EventArgs e)
        {

        }

        protected void dataPagerAllFeature_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    ShowFeatureInfoGrid();
                }
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
                var objAllFeature = _AllFeatureRT.GetAllFeatureById(Convert.ToInt32(linkButton.CommandArgument));
                if (objAllFeature != null)
                {
                    objAllFeature.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                    objAllFeature.ModifiedDate = DateTime.Now;
                    objAllFeature.IsRemoved = true;
                    _AllFeatureRT.UpdateAllFeature(objAllFeature);

                    //delete All News detail by card info iid

                    var allFeatureDetailList = _AllFeatureRT.GetAllFeatureDetailListByAllFeatureId(objAllFeature.IID);
                    foreach (var allFeatureDetail in allFeatureDetailList)
                    {
                        allFeatureDetail.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                        allFeatureDetail.ModifiedDate = DateTime.Now;
                        allFeatureDetail.IsRemoved = true;
                        _AllFeatureRT.UpdateAllFeatureDetail(allFeatureDetail);
                    }


                    ShowFeatureInfoGrid();

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

        protected void lnkbEdit_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton linkButton = (LinkButton)sender;
                Int64 id = Convert.ToInt64(linkButton.CommandArgument);
                Response.Redirect("AllFeatureInsertUpdate.aspx?IID=" + id);
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
                Response.Redirect("AllFeatureInsertUpdate");
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}