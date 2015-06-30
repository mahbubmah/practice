using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Basic;

namespace BLL.Basic
{
    public class CardInfoRT : IDisposable
    {
        private readonly OiiOMartDBDataContext dbContext;
        public CardInfoRT()
        {
            dbContext = DatabaseHelper.GetDataModelDataContext();
        }

        public static int InsertCardInfoAndAllChildCardFeatuerXML(string objectXML)
        {
            try
            {
                return CardInfoDA.InsertCardInfoAndAllFreatureChildXML(objectXML);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }



        public object GetCardInfoForListView()
        {
            try
            {

                var cardInfoList = from ci in dbContext.CardInfos.OrderByDescending(x => x.IID)
                                   join comIn in dbContext.CompanyInfos on ci.CompanyInfoID equals comIn.IID
                                   where ci.IsRemoved == false
                                   select new
                                   {
                                       ci.IID,
                                       CompanyName = comIn.Name,
                                       ci.Description,
                                       ci.Name,
                                       ci.CardLogoUrl,
                                       ci.APR,
                                       ci.MinimumLimitAmt,
                                       ci.MaximumLimitAmt,
                                       ci.AnnualFeePayment,
                                       ci.PostLastDisplayDate
                                   };

                return cardInfoList;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }


        public void UpdateCardInfo(CardInfo cardInfo)
        {
            try
            {

                CardInfo cardIn = dbContext.CardInfos.Single(d => d.IID == cardInfo.IID);
                DatabaseHelper.Update<CardInfo>(dbContext, cardInfo, cardIn);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public CardInfo GetCardInfoByID(long cardInfoId)
        {
            try
            {
                var cardInfo = dbContext.CardInfos.Single(d => d.IID == cardInfoId);
                return cardInfo;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public void AddCardInfo(CardInfo cardInfo)
        {
            try
            {
                DatabaseHelper.Insert<CardInfo>(cardInfo);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        #region IDisposable Members
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members

        public CardInfo GetCardInfoByIID(int p)
        {
            throw new NotImplementedException();
        }

        public List<CardInfo> GetCardInfoAll()
        {
            try
            {
                var cardInfo = dbContext.CardInfos.ToList();
                return cardInfo;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public List<CardPurchase> GetAllCardPurchaseByCardInfoId(long cardInfoId)
        {
            try
            {
                var cardInfo = dbContext.CardPurchases.Where(x => x.CardInfoID == cardInfoId && x.IsRemoved == false).ToList();
                return cardInfo;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public List<CardBalanceTransfer> GetAllBalanceTransferByCardInfoId(long cardInfoId)
        {
            try
            {
                var cardInfo = dbContext.CardBalanceTransfers.Where(x => x.CardInfoID == cardInfoId && x.IsRemoved == false).ToList();
                return cardInfo;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
        public List<CardTypeBankingNews> GetAllCardType()
        {
            try
            {
                List<CardTypeBankingNews> _CardTypeBankingNews = new List<CardTypeBankingNews>();
                var cardTypeList = dbContext.SP_GetAllCardTypeForBankingNews().ToList();
                foreach (var card in cardTypeList)
                {
                    var cardTypeDisplay = new CardTypeBankingNews();
                    cardTypeDisplay.IID = Convert.ToInt32(card.IID);



                    switch (card.CardType)
                    {
                        case 1:
                            cardTypeDisplay.CardName = "Visa";
                            break;

                        case 2:
                            cardTypeDisplay.CardName = "Master";
                            break;
                        case 3:
                            cardTypeDisplay.CardName = "AmericanExpress";
                            break;


                    }

                    _CardTypeBankingNews.Add(cardTypeDisplay);
                }
                return _CardTypeBankingNews;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);

            }

        }
        public class CardTypeBankingNews
        {
            public int? IID { get; set; }

            public string CardName { get; set; }

        }

        public int SelectCardInfoCount()
        {
            try
            {
                int cardInfoRowCount = dbContext.CardInfos.Count();
                return cardInfoRowCount;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        public List<CardInfo> SelectAllList(string sSortType, int iBeginRowIndex, int iMaximumRows)
        {
            try
            {
                IQueryable<CardInfo> cardInfoListPageWise = null;
                switch (sSortType)
                {
                    case "":
                        cardInfoListPageWise = dbContext.CardInfos.Where(x => x.IsRemoved == false).OrderByDescending(x => x.TotalVisitor).Skip(iBeginRowIndex).Take(iMaximumRows);
                        break;
                    case "0%BalanceTrancefer":
                        cardInfoListPageWise = (from ci in dbContext.CardInfos.Where(x => x.IsRemoved == false)
                                                join cbt in dbContext.CardBalanceTransfers.Where(x => x.TransferFeePercent == 0) on ci.IID equals cbt.CardInfoID
                                                select ci).Distinct().Skip(iBeginRowIndex).Take(iMaximumRows);
                        break;
                    case "0%Purchase":
                        cardInfoListPageWise = (from ci in dbContext.CardInfos.Where(x => x.IsRemoved == false)
                                                join cp in dbContext.CardPurchases.Where(x => x.RateOnPurchase <= 0) on ci.IID equals cp.CardInfoID
                                                select ci).Distinct().Skip(iBeginRowIndex).Take(iMaximumRows);
                        break;
                    case "LowAPR":
                        cardInfoListPageWise = dbContext.CardInfos.Where(x => x.IsRemoved == false).OrderBy(x => x.APR).Skip(iBeginRowIndex).Take(iMaximumRows);
                        break;

                }
                return cardInfoListPageWise.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        public CardInfo GetMostVisitedCardInfoByCardTypeId(int cardTypeId)
        {
            try
            {
                var cardInfoByMostVisitedCardType = dbContext.CardInfos.Where(x => x.CardTypeID == cardTypeId && x.IsRemoved == false).OrderByDescending(x => x.TotalVisitor).FirstOrDefault();
                return cardInfoByMostVisitedCardType;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public CardInfo GetCardInfoLast()
        {
            try
            {
                var cardInfoLast = dbContext.CardInfos.OrderByDescending(x => x.IID).FirstOrDefault();
                return cardInfoLast;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public IEnumerable<CardInfo> GetAllCardInfoList()
        {
            try
            {
                //var crdInfo = from ci in dbContext.CardInfos select new
                //{
                //    ci.CompanyInfo.Name
                //};
                
                var cardInfoList = dbContext.CardInfos;
                return cardInfoList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
      
    }
}

