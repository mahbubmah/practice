using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Basic;

namespace BLL.Basic
{
    public class CardRegionWiseFeeRT: IDisposable
    {
        private readonly OiiOMartDBDataContext _dbContext;
        public CardRegionWiseFeeRT()
        {
            _dbContext = DatabaseHelper.GetDataModelDataContext();
        }

        public void AddCardsRegionWiseFee(DAL.CardRegionWiseFee cardsRegionFee)
        {
            try
            {
                DatabaseHelper.Insert<CardRegionWiseFee>(cardsRegionFee);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            
        }

        public List<CardRegionWiseFee> GetCardsFeeInfoByCardsIDAndRegionID(int cardsFeeID, int cardsInfoID, int regionID)
        {
            try
            {
                List<CardRegionWiseFee> cardsRegionFeeList = _dbContext.CardRegionWiseFees.Where(cardF => cardF.IID != cardsFeeID && cardF.CardInfoID == cardsInfoID && cardF.RegionID == regionID).ToList();
                return cardsRegionFeeList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
            
        }

        public void UpdateCardRegionFee(CardRegionWiseFee cardsRegionFee)
        {
            try
            {
                OiiOMartDBDataContext _dbContext = DatabaseHelper.GetDataModelDataContext();
                _dbContext.Connection.Open();
                CardRegionWiseFee RegionFee = _dbContext.CardRegionWiseFees.Single(d => d.IID == cardsRegionFee.IID);
                DatabaseHelper.Update<CardRegionWiseFee>(_dbContext, cardsRegionFee, RegionFee);
                //_dbContext.Dispose();
            }

            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public object GetALLCardRegionWiseFeeListView()
        {
            try
            {
                var cardFees = from Fees in _dbContext.CardRegionWiseFees
                               join cards in _dbContext.CardInfos on Fees.CardInfoID equals cards.IID
                               join comp in _dbContext.CompanyInfos on cards.CompanyInfoID equals comp.IID
                                   //where (user.IsRemoved == false && user.IsActiveUser == true)
                                   select new
                                   {
                                       Fees.IID,
                                       CardName = comp.Name + " - " + cards.Name,
                                       Fees.RegionID,
                                       Fees.Note,
                                       Fees.UsageFeePercent,
                                       Fees.IsRemoved
                                   };
               // _dbContext.Dispose();
                return cardFees;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public CardRegionWiseFee GetCardRegionFeeByIID(int cardRegionFeeID)
        {
            try
            {
                CardRegionWiseFee country = _dbContext.CardRegionWiseFees.SingleOrDefault(d => d.IID == cardRegionFeeID);
                //_OiiOMartDBDataContext.Dispose();
                return country;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public CardRegionWiseFee getCardRegionWiseFeeInfoByID(int IID)
        {
            return null;
        }
    }
}
