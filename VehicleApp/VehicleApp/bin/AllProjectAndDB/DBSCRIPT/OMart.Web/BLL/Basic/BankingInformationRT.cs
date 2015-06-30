using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Basic
{
     public class BankingInformationRT : IDisposable
    {
         private readonly OiiOMartDBDataContext _OiiOMartDBDataContext;
        public BankingInformationRT()
        {
            this._OiiOMartDBDataContext = DatabaseHelper.GetDataModelDataContext();
        }
        public List<LoanTypeBankingNews> GetAllLoanType()
        {
            try
            {
                List<LoanTypeBankingNews> _LoanTypeBankingNews = new List<LoanTypeBankingNews>();
                var loanTypeList = _OiiOMartDBDataContext.SP_SP_GetAllLoanTypeForBankingNews().ToList();
                foreach (var loanType in loanTypeList)
                {
                    var loanTypeDisplay = new LoanTypeBankingNews();
                    loanTypeDisplay.IID = loanType.IID;
                    switch (loanType.IID)
                    {
                        case 1:
                            loanTypeDisplay.LoanTypeName = "Personal Loan";
                            break;
                        case 2:
                            loanTypeDisplay.LoanTypeName = "Car Loan";
                            break;
                        case 3:
                            loanTypeDisplay.LoanTypeName = "Marriage Loan";
                            break;
                        case 4:
                            loanTypeDisplay.LoanTypeName = "Home Loan";
                            break;
                        case 5:
                            loanTypeDisplay.LoanTypeName = "SME Loan";
                            break;
                    }

                    _LoanTypeBankingNews.Add(loanTypeDisplay);
                }
                return _LoanTypeBankingNews;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }

        }
        public class LoanTypeBankingNews
        {
            public Int64 IID { get; set; }

            public string LoanTypeName { get; set; }
            public string LoanTypeDescription { get; set; }

            public string LoanTypeImage { get; set; }
        }
        public int GetLoanTypeOne(string name)
        {
            try
            {
              int loanTypeID=0;
              switch (name)
                {
                    case "Personal Loan":
                        return loanTypeID = 1;
                    case "Car Loan":
                        return loanTypeID = 2;
                    case "Marriage Loan":
                        return loanTypeID = 3;
                    case "Home Loan":
                        return loanTypeID = 4;
                    case "SME Loan":
                        return loanTypeID = 5;
                }

              return loanTypeID;
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

      
      
        #region Upper SlideBankingNewsDescription
        public object GetMortgageInfoDescription(int mortTypeID)
        {
            try
            {
                var mortDescription = (from mort in _OiiOMartDBDataContext.Mortgages
                                      
                                       where mort.IsRemoved == false && mort.TypeID == mortTypeID
                                       select new BankingMortgage
                                       {
                                           IID = mort.IID,
                                           mortgageAPR = mort.APR,
                                           mortgageFeeCharge=mort.FeeOrCharge,
                                           mortgageDes = mort.Description,
                                           mortgageLTV=mort.LTV
                                       });
                return mortDescription;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public class BankingMortgage
        {
            public Int64 IID { get; set; }
            public double? mortgageAPR { get; set; }
            public decimal? mortgageFeeCharge { get; set; }
            public string mortgageDes { get; set; }
            public double? mortgageLTV { get; set; }
        }
        public object GetLoanFeatures(Int64 loanTypeID)
        {
            try
            {
                var loanDescription = (from loan in _OiiOMartDBDataContext.LoanInfos
                                       join loanFeature in _OiiOMartDBDataContext.LoanFeatures
                                       on loan.IID equals loanFeature.LoanInfoID
                                       where loan.IsRemoved == false && loanFeature.IsRemoved == false && loan.LoanTypeID == loanTypeID
                                       select new BankingLoan
                                       {
                                           IID = loan.IID,
                                           LoanFeature = loanFeature.Description
                                       });
                return loanDescription;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public class BankingLoan
        {
            public Int64 IID { get; set; }


            public string LoanFeature { get; set; }


        }
        public object GetCardInfoDescription()
        {
            try
            {
                var cardDescription = (from card in _OiiOMartDBDataContext.CardInfos
                                       join cardFeature in _OiiOMartDBDataContext.CardFeatures
                                       on card.IID equals cardFeature.CardInfoID
                                       where card.IsRemoved == false && cardFeature.IsRemoved == false
                                       select new BankingCard
                                       {
                                           IID = card.IID,
                                           cardFeature = cardFeature.Description
                                       }).Take(4);
                return cardDescription;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public class BankingCard
        {
            public Int64 IID { get; set; }


            public string cardFeature { get; set; }


        }
        public string GetMortgageDescription(Int64 iid)
        {
            try
            {
                string mortgageDescription = (from mortgage in _OiiOMartDBDataContext.MortgageTypeInfos
                                              where mortgage.IID == iid
                                              select mortgage.Description).FirstOrDefault();
                return mortgageDescription;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public string GetCardDescription(Int64 iid)
        {
            try
            {
                string cardDescription = (from card in _OiiOMartDBDataContext.CardInfos
                                          where card.CardTypeID == iid
                                          select card.Description).FirstOrDefault();
                return cardDescription;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public string GetLoanDescription(Int64 iid)
        {
            try
            {
                string loanDescription = (from loan in _OiiOMartDBDataContext.LoanTypes
                                          where loan.IID==iid
                                          select loan.Description).FirstOrDefault();
                return loanDescription;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public class MortgageTypeBankingNews
        {
            public Int64 IID { get; set; }

            public string MortgageTypeName { get; set; }
            public string MortgageTypeDescription { get; set; }

            public string MortgageTypeImage { get; set; }
        }
        public int GetMortgageTypeOne(string name)
        {
            try
            {
                int mortTypeID = 0;
                switch (name)
                {
                    case "Conventional Mortgage":
                        return mortTypeID = 1;
                    case "Government Mortgage":
                        return mortTypeID = 2;
                    case "Rural Home Financing Program Mortgage":
                        return mortTypeID = 3;
                    case "Home Opportunities Program Mortgage":
                        return mortTypeID = 4;
                    case "None prime Or Subprime Mortgage":
                        return mortTypeID = 5;
                }

                return mortTypeID;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public int GetCardTypeOne(string name)
        {
            try
            {
                int cardTypeID = 0;
                switch (name)
                {
                    case "Visa":
                        return cardTypeID = 1;
                    case "Master":
                        return cardTypeID = 2;
                    case "AmericanExpress":
                        return cardTypeID = 3;
                    
                }
                  return cardTypeID;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public List<MortgageTypeBankingNews> GetAllMortgageType()
        {
            try
            {
                List<MortgageTypeBankingNews> _MortgageTypeBankingNews = new List<MortgageTypeBankingNews>();
                var MortgageTypeList = _OiiOMartDBDataContext.SP_SP_GetAllMortgageTypeForBankingNews().ToList();
                foreach (var MortgageType in MortgageTypeList)
                {
                    var MortgageTypeDisplay = new MortgageTypeBankingNews();
                    MortgageTypeDisplay.IID = MortgageType.IID;
                    switch (MortgageType.IID)
                    {
                        case 1:
                            MortgageTypeDisplay.MortgageTypeName = "Conventional Mortgage";
                            break;
                        case 2:
                            MortgageTypeDisplay.MortgageTypeName = "Government Mortgage";
                            break;
                        case 3:
                            MortgageTypeDisplay.MortgageTypeName = "Rural Home Financing Program Mortgage";
                            break;
                        case 4:
                            MortgageTypeDisplay.MortgageTypeName = "Home Opportunities Program Mortgage";
                            break;
                        case 5:
                            MortgageTypeDisplay.MortgageTypeName = "None prime Or Subprime Mortgage";
                            break;
                    }

                    _MortgageTypeBankingNews.Add(MortgageTypeDisplay);
                }
                return _MortgageTypeBankingNews;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }

        }
        #endregion Upper SlideBankingNewsDescription
        #region IDisposable Members
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members

       
    }
}
