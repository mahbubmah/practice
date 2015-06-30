using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Basic;
using DAL;
using Microsoft.Ajax.Utilities;
using Utilities;

namespace OMart.Web
{
    public partial class CreditCardsDetail : System.Web.UI.Page
    {
        private readonly CardInfoRT _cardInfoRt;
        private Int64 _cardInfoIid = default(Int64);
        private readonly string _visitorLogPath ;
        private string _pageLogPath;


        int lvRowCount = 0;
        int currentPage = 0;
        public class CardTypeSlide
        {
            public string Name { get; set; }
            public string CardInfoName { get; set; }
            public string Description { get; set; }
            public string CardLogoUrl { get; set; }
        }

        public CreditCardsDetail()
        {
            this._visitorLogPath = Server.MapPath("~/Log file/VisitorlogFileWriting.txt");
            this._cardInfoRt = new CardInfoRT();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string pageName = Path.GetFileName(Request.PhysicalPath);
                _pageLogPath = Server.MapPath("~/Log file/" + pageName + ".txt");
              

                if (!IsPostBack)
                {
                    LogFileHelper.VisitorLogFileWritten(_visitorLogPath);
                    objDsCardInfo.CacheDuration = Session.Timeout;
                    CardTypeSlideLoad();
                }


            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }


        private void CardTypeSlideLoad()
        {
            try
            {
                List<CardTypeSlide> cardTypeSlideList = new List<CardTypeSlide>();

                foreach (ListItem cardTypeListItem in EnumHelper.EnumCamelSpaceToList<EnumCollection.CardType>())
                {
                    CardTypeSlide aCardTypeSlide = new CardTypeSlide();
                    var cardTypeDetails = _cardInfoRt.GetMostVisitedCardInfoByCardTypeId(Convert.ToInt32(cardTypeListItem.Value));

                    if (cardTypeDetails != null)
                    {
                        aCardTypeSlide.Name = cardTypeListItem.Text;
                        aCardTypeSlide.CardInfoName = cardTypeDetails.Name;
                        aCardTypeSlide.Description = cardTypeDetails.Description;
                        aCardTypeSlide.CardLogoUrl = cardTypeDetails.CardLogoUrl;

                        cardTypeSlideList.Add(aCardTypeSlide);
                    }
                }
                if (cardTypeSlideList.Count > 0)
                {
                    var firstCardTypeDetailsForActiveSlide = cardTypeSlideList.FirstOrDefault();

                    lblCardSlideActiveCardInfoDescription.Text = firstCardTypeDetailsForActiveSlide.Description;
                    lblCardSlideActiveCardInfoName.Text = firstCardTypeDetailsForActiveSlide.CardInfoName;
                    lblCardSlideActiveCardTypeName.Text = firstCardTypeDetailsForActiveSlide.Name;
                    imgCardSlideActiveCardTypeImage.ImageUrl = firstCardTypeDetailsForActiveSlide.CardLogoUrl;
                    if (cardTypeSlideList.Count > 1)
                    {
                        repCardTypeSlideDisplay.DataSource = cardTypeSlideList.Skip(1);
                        repCardTypeSlideDisplay.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }



        }

        protected void repCardInfo_OnItemDataBound(object sender, ListViewItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListViewItemType.DataItem)
                {

                    HiddenField objIID = e.Item.FindControl("hdCardInfoId") as HiddenField;
                    _cardInfoIid = Convert.ToInt64(objIID.Value);

                    using (CardFeatureRT aCardFeatureRt = new CardFeatureRT())
                    {
                        var objChildCardFeatureList = aCardFeatureRt.GetAllCardFeaturesByCardInfoId(Convert.ToInt64(objIID.Value)).Take(3);
                        Repeater objRepeater = e.Item.FindControl("repCardFeature") as Repeater;
                        objRepeater.DataSource = objChildCardFeatureList;
                        objRepeater.DataBind();
                    }
                    using (CardInfoRT aCardInfoRt = new CardInfoRT())
                    {
                        var objCardPurchase = aCardInfoRt.GetAllCardPurchaseByCardInfoId(Convert.ToInt64(objIID.Value)).Take(3);
                        Repeater repCardPurchase = e.Item.FindControl("repCardPurchase") as Repeater;
                        repCardPurchase.DataSource = objCardPurchase;
                        repCardPurchase.DataBind();


                        var objCardBalanceTransfer = aCardInfoRt.GetAllBalanceTransferByCardInfoId(Convert.ToInt64(objIID.Value)).Take(3);
                        Repeater repBalanceTransfer = e.Item.FindControl("repCardBalanceTransfer") as Repeater;
                        repBalanceTransfer.DataSource = objCardBalanceTransfer;
                        repBalanceTransfer.DataBind();
                    }

                }
            }
            catch (Exception ex)
            {

                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
        
        protected void dataPagerCardInfo_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        protected void lvCardInfo_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void repCardPurchase_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                using (CardInfoRT aCardInfoRt = new CardInfoRT())
                {
                    var objCardPurchase = aCardInfoRt.GetAllCardPurchaseByCardInfoId(Convert.ToInt64(_cardInfoIid));

                    if (objCardPurchase.Count < 1)
                    {
                        Label lblEmptyData = e.Item.FindControl("lblEmptyDataPurchase") as Label;
                        lblEmptyData.Visible = true;
                    }
                }

            }
            catch (Exception ex)
            {

                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        protected void repCardBalanceTransfer_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                using (CardInfoRT aCardInfoRt = new CardInfoRT())
                {
                    var objCardBalanceTransfer = aCardInfoRt.GetAllBalanceTransferByCardInfoId(Convert.ToInt64(_cardInfoIid));

                    if (objCardBalanceTransfer.Count < 1)
                    {
                        Label lblEmptyData = e.Item.FindControl("lblEmptyDataBalanceTransfer") as Label;
                        lblEmptyData.Visible = true;
                    }
                }

            }
            catch (Exception ex)
            {

                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        protected void zeroBalanceTranceferRate_OnClick(object sender, EventArgs e)
        {
            lvCardInfo.Sort(lbSortZeroBalanceTranceferRate.CommandArgument, SortDirection.Ascending);
        }

        protected void zropPercentPurchase_OnClick(object sender, EventArgs e)
        {
            lvCardInfo.Sort(lbSortZeropPercentPurchase.CommandArgument, SortDirection.Ascending);
        }

        protected void lbSortLowApr_OnClick_OnClick(object sender, EventArgs e)
        {
            lvCardInfo.Sort(lbSortLowApr.CommandArgument, SortDirection.Ascending);
        }

        protected void lbSortMostPopular_OnClick(object sender, EventArgs e)
        {
            lvCardInfo.Sort(lbSortMostPopular.CommandArgument, SortDirection.Ascending);
        }

        protected void creditCardNews_Click(object sender, EventArgs e)
        {
            try
            {
                AllNewsRT allNewsRT = new AllNewsRT();
                int ID=allNewsRT.GeTop1AllNewsIIDForBusinessTypeIDnBreakDownID(Convert.ToInt32(EnumCollection.BussinessType.Banking), Convert.ToInt32(EnumCollection.BusinessBankingType.CraditCards));
                if(ID>0)
                {
                    Response.Redirect("AllNewsDetails?ID=" + StringCipher.Encrypt(ID.ToString()), false);
                }
                else
                {
                    lBtncreditCardNews.Attributes.Add("onClick", "javascript:alert('No Credit Card News posted!');");  
                }

            }
            catch (Exception ex)
            {

                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        protected void creditCardGuide_Click(object sender, EventArgs e)
        {
            try
            {


            }
            catch (Exception ex)
            {

                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }


    }
}