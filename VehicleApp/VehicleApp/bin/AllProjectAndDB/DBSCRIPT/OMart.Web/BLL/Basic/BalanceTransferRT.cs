using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL.Basic
{
    public class BalanceTransferRT : IDisposable
    {
        private readonly OiiOMartDBDataContext _dbContext;
        public BalanceTransferRT()
        {
            this._dbContext = DatabaseHelper.GetDataModelDataContext();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


        public void AddCardBalanceTransefer(DAL.CardBalanceTransfer balanceTransfer)
        {
            try
            {
                DatabaseHelper.Insert<CardBalanceTransfer>(balanceTransfer);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public List<DAL.CardBalanceTransfer> GetCardBalanceTransferInfoByCardNameAndMonth(int cardID, string p)
        {
            throw new NotImplementedException();
        }

        public DAL.CardBalanceTransfer GetCardBalanceTransferByIID(int cardbalanceID)
        {
            try
            {
                OiiOMartDBDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                CardBalanceTransfer cardBalance = new CardBalanceTransfer();
                cardBalance = dbContext.CardBalanceTransfers.Single(d => d.IID == cardbalanceID);
                dbContext.Dispose();
                return cardBalance;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }


        //public object GetCardBalanceTransferAll()
        //{
        //    try
        //    {
        //        var cardBalanceList = from balance in _dbContext.CardBalanceTransfers
        //                              join cards in _dbContext.CardInfos on balance.CardInfoID equals cards.IID
        //                           //where (user.IsRemoved == false && user.IsActiveUser == true)
        //                           select new
        //                           {
        //                               cardName = cards.Name,
        //                               balance.MonthNumber,
        //                               balance.TransferFeePercent,
        //                               balance.IsRemoved
        //                           };
        //        _dbContext.Dispose();
        //        return cardBalanceList;
        //    }
        //    catch (Exception ex) { throw new Exception(ex.Message, ex); }
        //}

        public object GetCardBalanceTransferAll()
        {
            try
            {
                OiiOMartDBDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                // List<CardBalanceTransfer> cardBalanceList = new List<CardBalanceTransfer>();

                var cardBalanceList = from balance in _dbContext.CardBalanceTransfers
                                      join cards in _dbContext.CardInfos on balance.CardInfoID equals cards.IID
                                      join comp in _dbContext.CompanyInfos on cards.CompanyInfoID equals comp.IID
                                      select new
                                          {
                                              balance.IID,
                                              CardName = comp.Name+" - "+cards.Name,
                                              id = cards.IID,
                                              balance.MonthNumber,
                                              balance.Note,
                                              balance.TransferFeePercent,
                                              balance.IsRemoved

                                          };


                // _dbContext.Dispose();

                return cardBalanceList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }



        }

        public string GetCardBalanceTransferAllForReport()
        {
            try
            {
                OiiOMartDBDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                // List<CardBalanceTransfer> cardBalanceList = new List<CardBalanceTransfer>();

                var cardBalanceList = from balance in _dbContext.CardBalanceTransfers

                                      select balance
                               ;


                // _dbContext.Dispose();

                return cardBalanceList.ToString();
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }



        }

        public List<CardBalanceTransfer> GetCardBalanceInfoByGivenCardInfo(int cardID, int monthNumber, decimal transferRate, string note)
        {
            try
            {
                List<CardBalanceTransfer> cardInfoList = _dbContext.CardBalanceTransfers.Where(user => user.IID != cardID && user.MonthNumber == monthNumber && user.TransferFeePercent==transferRate && user.Note == note).ToList();
                return cardInfoList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
        /// <summary>
        /// Button delete
        /// </summary>
        /// <param name="cardbalance"></param>
        public void UpdateCardBalanceTransfer(CardBalanceTransfer cardbalance)
        {
            try
            {
                OiiOMartDBDataContext _dbContext = DatabaseHelper.GetDataModelDataContext();
                _dbContext.Connection.Open();
                CardBalanceTransfer cardBalance = _dbContext.CardBalanceTransfers.Single(d => d.IID == cardbalance.IID);
                DatabaseHelper.Update<CardBalanceTransfer>(_dbContext, cardbalance, cardBalance);
                _dbContext.Dispose();
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); };
        }



        public CardBalanceTransfer GetCardBalanceInfoByID(int id)
        {
            try
            {
                CardBalanceTransfer cardBalance = new CardBalanceTransfer();
                cardBalance = _dbContext.CardBalanceTransfers.Single(d => d.IID == id);
                _dbContext.Dispose();
                return cardBalance;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public List<GetAllCardNameAccordingToBankResult> GetCardName()
        {
            try
            {
                var obj = _dbContext.GetAllCardNameAccordingToBank();
                return obj.ToList();
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }


        }

        public CardBalanceTransfer GetCardBalanceTransferInfoByID(int p)
        {
            try
            {
                CardBalanceTransfer cardBalance = new CardBalanceTransfer();
                cardBalance = _dbContext.CardBalanceTransfers.Single(d => d.IID == p);
                _dbContext.Dispose();
                return cardBalance;
            }

            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
        
    }
}
