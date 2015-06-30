using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Basic;

namespace OMart.Web.AdminPanel
{
    public partial class GuideLineDetailDisplay : System.Web.UI.Page
    {
        /// <summary>
        /// Author: Asiful Islam
        /// Date: 22.04.2015
        /// </summary>
        private readonly GuideLineWithDetailsRT _guideLineDetailRt;

        int lvRowCount = 0;
        int currentPage = 0;
        public GuideLineDetailDisplay()
        {
            this._guideLineDetailRt = new GuideLineWithDetailsRT();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowGuideLineDetailGrid();
            }
        }

        private void ShowGuideLineDetailGrid()
        {
            try
            {
                lvGuideLineDetail.DataSource = _guideLineDetailRt.GetguideLineDetailForListView();
                lvGuideLineDetail.DataBind();
            }
            catch (Exception ex)
            {
                labelMessageGuideLineDetail.Text = "Error : " + ex.Message;
                labelMessageGuideLineDetail.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lvGuideLineDetail_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            labelMessageGuideLineDetail.Text = string.Empty;
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void lvGuideLineDetail_PreRender(object sender, EventArgs e)
        {

        }

        protected void dataPagerGuideLineDetail_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    ShowGuideLineDetailGrid();
                }
            }
            catch (Exception ex)
            {
                labelMessageGuideLineDetail.Text = "Error : " + ex.Message;
                labelMessageGuideLineDetail.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnAddGuideLineDetail_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("GuideLineDetailMoreInsUpdate");
            }
            catch (Exception ex)
            {
                labelMessageGuideLineDetail.Text = "Error : " + ex.Message;
                labelMessageGuideLineDetail.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void lnkbEdit_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton linkButton = (LinkButton)sender;
                Int64 id = Convert.ToInt64(linkButton.CommandArgument);
                Response.Redirect("GuideLineDetailMoreInsUpdate?IID=" + id);
            }
            catch (Exception ex)
            {
                labelMessageGuideLineDetail.Text = "Error : " + ex.Message;
                labelMessageGuideLineDetail.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void lnkbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton linkButton = new LinkButton();
                linkButton = (LinkButton)sender;
                var objguideLineDetail = _guideLineDetailRt.GetGuideLineDetailsByIID(Convert.ToInt64(linkButton.CommandArgument));
                if (objguideLineDetail != null)
                {
                  //  objguideLineDetail.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                    objguideLineDetail.ModifiedDate = DateTime.Now;
                    objguideLineDetail.IsRemoved = true;
                    _guideLineDetailRt.UpdateGuidelinedetail(objguideLineDetail);

                    //delete card feature by card info iid
                    using (GuideLineWithDetailsRT aguideLineDetailMoreRt = new GuideLineWithDetailsRT())
                    {
                        var guideLineDetailMoreList = aguideLineDetailMoreRt.GetAllGuidelinedetailMoreByGuidelinedetailId(objguideLineDetail.IID);
                        foreach (var guideLineDetailMore in guideLineDetailMoreList)
                        {
                            //guideLineDetailMore.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                            guideLineDetailMore.ModifiedDate = DateTime.Now;
                            guideLineDetailMore.IsRemoved = true;
                            aguideLineDetailMoreRt.UpdateGuidelinedetailMore(guideLineDetailMore);
                        }
                    }

                    ShowGuideLineDetailGrid();

                    labelMessageGuideLineDetail.Text = "Guide Line Details has been removed successfully.";
                    labelMessageGuideLineDetail.ForeColor = System.Drawing.Color.Green;

                }
            }
            catch (Exception ex)
            {
                labelMessageGuideLineDetail.Text = "Error : " + ex.Message;
                labelMessageGuideLineDetail.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}