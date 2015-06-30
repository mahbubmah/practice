using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using BLL;
using BLL.Basic;
using DAL;

namespace OMart.Web.AdminPanel
{
    public partial class CardInfoPurchase : System.Web.UI.Page
    {
        private readonly CardInfoRT _cardInfoRt;

        int lvRowCount = 0;
        int currentPage = 0;
        public CardInfoPurchase()
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

       

        protected void lnkbEdit_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton linkButton = (LinkButton)sender;
                Int64 id = Convert.ToInt64(linkButton.CommandArgument);
                Response.Redirect("CardPurchaseWF.aspx?IID=" + id);
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

    }
}