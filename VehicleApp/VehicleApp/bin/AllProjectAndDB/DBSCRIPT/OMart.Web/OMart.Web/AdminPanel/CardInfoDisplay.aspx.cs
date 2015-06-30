using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Basic;
using DAL;
using OMart.Web.AdminPanel.CrystalReports;
using Utilities;

namespace OMart.Web.AdminPanel
{
    public partial class CardInfoDisplay : System.Web.UI.Page
    {
        private readonly CardInfoRT _cardInfoRt;

        int lvRowCount = 0;
        int currentPage = 0;
        public CardInfoDisplay()
        {
            this._cardInfoRt = new CardInfoRT();
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
                lvCardInfo.DataSource = _cardInfoRt.GetCardInfoForListView();
                lvCardInfo.DataBind();
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void dataPagerCardInfo_PreRender(object sender, EventArgs e)
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

        protected void lvCardInfo_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            labelMessage.Text = string.Empty;
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("CardInfoInsertUpdate.aspx");
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
                Response.Redirect("CardInfoInsertUpdate.aspx?IID=" + id);
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
                var objCardInfo = _cardInfoRt.GetCardInfoByID(Convert.ToInt64(linkButton.CommandArgument));
                if (objCardInfo != null)
                {
                    objCardInfo.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                    objCardInfo.ModifiedDate = DateTime.Now;
                    objCardInfo.IsRemoved = true;
                    _cardInfoRt.UpdateCardInfo(objCardInfo);

                    //delete card feature by card info iid
                    using (CardFeatureRT aCardFeatureRt = new CardFeatureRT())
                    {
                        var cardFeatureList = aCardFeatureRt.GetAllCardFeaturesByCardInfoId(objCardInfo.IID);
                        foreach (var cardFeature in cardFeatureList)
                        {
                            cardFeature.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                            cardFeature.ModifiedDate = DateTime.Now;
                            cardFeature.IsRemoved = true;
                            aCardFeatureRt.UpdateCardFeature(cardFeature);
                        }
                    }

                    ShowCardInfoGrid();

                    labelMessage.Text = "Card inforamion has been removed successfully.";
                    labelMessage.ForeColor = System.Drawing.Color.Green;

                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                //rptBiAmountRangeList reportdocument = new rptBiAmountRangeList();
                //CrystalReportHelper<rptBiAmountRangeList>.SetLoginInfo(reportdocument);
                //Session["reportForm"] = reportdocument;
                //ClientScript.RegisterStartupScript(GetType(), "openwindow", "<script type=text/javascript> window.open('ShowReport'); </script>");
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }

        }

        protected void lnkbPrint_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton linkButton = (LinkButton)sender;
                var objCardInfo = _cardInfoRt.GetCardInfoByID(Convert.ToInt64(linkButton.CommandArgument));
          

                CrParameter parameter=new CrParameter();
                parameter.Name = "IID";
                parameter.Value = objCardInfo.IID.ToString();
                Session[CrHelper.SessParamStr] = parameter;
                Session[CrHelper.SessReportFormStr] = new crCardInfo();
                ClientScript.RegisterStartupScript(GetType(), "openwindow", "<script type=text/javascript> window.open('ShowReport'); </script>");
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}