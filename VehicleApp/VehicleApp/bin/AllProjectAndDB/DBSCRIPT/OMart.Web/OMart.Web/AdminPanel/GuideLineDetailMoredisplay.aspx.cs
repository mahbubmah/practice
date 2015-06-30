using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Basic;

namespace OMart.Web.AdminPanel
{
    public partial class GuideLineDetailMoredisplay : System.Web.UI.Page
    {
        /// <summary>
        /// Author: Asiful Islam
        /// Date: 22.04.2015
        /// </summary>
          private readonly GuideLineWithDetailsRT _guideLineDetailMoreRt;

        int lvRowCount = 0;
        int currentPage = 0;
        public GuideLineDetailMoredisplay()
        {
            this._guideLineDetailMoreRt = new GuideLineWithDetailsRT();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowGuideLineDetailMoreGrid();
            }
        }

        private void ShowGuideLineDetailMoreGrid()
        {
            try
            {
                lvGuideLineDetailMore.DataSource = _guideLineDetailMoreRt.GetguideLineDetailMoreForListView();
                lvGuideLineDetailMore.DataBind();
            }
            catch (Exception ex)
            {
                labelMessageGuideLineDetailMore.Text = "Error : " + ex.Message;
                labelMessageGuideLineDetailMore.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lvGuideLineDetailMore_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            labelMessageGuideLineDetailMore.Text = string.Empty;
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void dataPagerGuideLineDetail_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    ShowGuideLineDetailMoreGrid();
                }
            }
            catch (Exception ex)
            {
                labelMessageGuideLineDetailMore.Text = "Error : " + ex.Message;
                labelMessageGuideLineDetailMore.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lnkbEdit_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton linkButton = (LinkButton)sender;
                Int64 id = Convert.ToInt64(linkButton.CommandArgument);
               // Response.Redirect("GuideLineDetailMoreInsUpdate?IID=" + id);
            }
            catch (Exception ex)
            {
                labelMessageGuideLineDetailMore.Text = "Error : " + ex.Message;
                labelMessageGuideLineDetailMore.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void lnkbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton linkButton = new LinkButton();
                linkButton = (LinkButton)sender;
                var objguideLineDetailMore = _guideLineDetailMoreRt.GetGuideLineDetailsMoreByIID(Convert.ToInt64(linkButton.CommandArgument));
                if (objguideLineDetailMore != null)
                {
                    //  objguideLineDetail.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                    objguideLineDetailMore.ModifiedDate = DateTime.Now;
                    objguideLineDetailMore.IsRemoved = true;
                    _guideLineDetailMoreRt.UpdateGuidelinedetailMore(objguideLineDetailMore);

                    //delete card feature by card info iid
                    //using (GuideLineWithDetailsRT aguideLineDetailMoreRt = new GuideLineWithDetailsRT())
                    //{
                    //    var guideLineDetailMoreList = aguideLineDetailMoreRt.GetAllGuidelinedetailMoreByGuidelinedetailId(objguideLineDetailMore.IID);
                    //    foreach (var guideLineDetailMore in guideLineDetailMoreList)
                    //    {
                    //        //guideLineDetailMore.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                    //        guideLineDetailMore.ModifiedDate = DateTime.Now;
                    //        guideLineDetailMore.IsRemoved = true;
                    //        aguideLineDetailMoreRt.UpdateGuidelinedetailMore(guideLineDetailMore);
                    //    }
                    //}

                    ShowGuideLineDetailMoreGrid();

                    labelMessageGuideLineDetailMore.Text = "Guide Line Details has been removed successfully.";
                    labelMessageGuideLineDetailMore.ForeColor = System.Drawing.Color.Green;

                }
            }
            catch (Exception ex)
            {
                labelMessageGuideLineDetailMore.Text = "Error : " + ex.Message;
                labelMessageGuideLineDetailMore.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}