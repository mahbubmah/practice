using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL.Basic
{
    public class CardPurchaseRT: IDisposable
    {
         private readonly OiiOMartDBDataContext _OiiOMartDBDataContext;
        public CardPurchaseRT()
        {
            _OiiOMartDBDataContext = DatabaseHelper.GetDataModelDataContext();
        }
        
       
        
        public void AddCardPurchase(CardPurchase cardPurchase)
        {
            try
            {
                 
                DatabaseHelper.Insert<CardPurchase>(cardPurchase);
            }
            catch (Exception ex) 
            { throw new Exception(ex.Message, ex); }
        }

        public void UpdateCardPurchase(CardPurchase cardPurchase)
        {
            try
            {
                CardPurchase CardPurchaseNew = _OiiOMartDBDataContext.CardPurchases.SingleOrDefault(d => d.IID == cardPurchase.IID);

                DatabaseHelper.Update<CardPurchase>(_OiiOMartDBDataContext, cardPurchase, CardPurchaseNew);

                //_OiiOMartDBDataContext.Dispose();
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message, ex); 
            }
        }

        public CardPurchase GetCardPurchaseByIID(int CardPurchaseID)
        {
            try
            {
                CardPurchase cardPurchase = _OiiOMartDBDataContext.CardPurchases.SingleOrDefault(d => d.IID == CardPurchaseID);
                //_OiiOMartDBDataContext.Dispose();
                return cardPurchase;
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message, ex);
            }
        }

        //public List<CardPurchase> GetCardPurchaseName(string conName)
        //{
        //    try
        //    {
        //        var cardPurchase = (from tr in _OiiOMartDBDataContext.CardPurchases.OrderBy(x => x.Name)
        //                         where tr.Name.StartsWith(conName)
        //                         select tr).ToList();
        //        return cardPurchase;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex);
        //    }
        //}

        public CardInfo GetCardInfoByID(long cardInfoId)
        {
            try
            {
                var cardInfo = _OiiOMartDBDataContext.CardInfos.Single(d => d.IID == cardInfoId);
                return cardInfo;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
        public List<CardPurchase> GetCardPurchaseByCardInfoID(int cardinfoid)
        {
            try
            {
                List<CardPurchase> cardPurchase = _OiiOMartDBDataContext.CardPurchases.Where(d => ((d.CardInfoID == cardinfoid )&& (d.IsRemoved== false))).ToList();
                return cardPurchase;
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message, ex); 
            }
        }

        public List<CardPurchase> GetCardPurchaseByCardInfoIdAndMonthNO(int cardinfoid, int month)
        {
            try
            {
                List<CardPurchase> cardPurchase = _OiiOMartDBDataContext.CardPurchases.Where(d => ((d.CardInfoID != cardinfoid ) && (d.MonthNumber == month) && d.IsRemoved== false)).ToList();
                return cardPurchase;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        #region IDisposable Members
            public void Dispose()
            {
                GC.SuppressFinalize(this);
            }

        #endregion IDisposable Members

    }
}


