using DAL;
using DAL.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Basic
{
    public class LoanInfoRT : IDisposable
    {
        private readonly OiiOMartDBDataContext _OiiOMartDBDataContext;
        public LoanInfoRT()
        {
            this._OiiOMartDBDataContext = DatabaseHelper.GetDataModelDataContext();
        }
        public object GetAllLoanInfoForDisplay()
        {
            try
            {
                var loanInfo = from loan in _OiiOMartDBDataContext.LoanInfos
                               join company in _OiiOMartDBDataContext.CompanyInfos on loan.CompanyInfoID equals company.IID
                               where(loan.IsRemoved == false)
                               select new
                               {
                                   loan.IID,
                                   cname = company.Name,
                                   lType = loan.LoanTypeID,
                                   loan.LoanAmtYearScheduleID,
                                   Des = loan.Description,
                                   totalAmount = loan.TotalAmount,
                                   loan.TotalInstallmentNo,
                                   loan.MonthlyReturnAmount,
                                   paymentAmount = loan.TotalReturnAmount,
                                   postDate = loan.PostAdDate,
                                   loan.PaymentAmt,
                                   loan.VerifiedBy,
                                   postLastDisplayDate = loan.PostLastDisplayDate,
                                   loan.RedirectUrl,
                                   loan.TotalVisitor,
                                   loan.IsVerified,
                                   loan.IsRemoved
                               };
                return loanInfo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public LoanInfo GetLoanInfoByIID(int loanInfoID)
        {
            try
            {
                LoanInfo loan = _OiiOMartDBDataContext.LoanInfos.SingleOrDefault(d => d.IID == loanInfoID);
               // _OiiOMartDBDataContext.Dispose();
                return loan;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

      
        public void UpdateLoanInfo(LoanInfo loanInfo)
        {
            try
            {
                LoanInfo loanInfoNew = _OiiOMartDBDataContext.LoanInfos.SingleOrDefault(d => d.IID == loanInfo.IID);
                DatabaseHelper.Update<LoanInfo>(_OiiOMartDBDataContext, loanInfo, loanInfoNew);
                OiiOMartDBDataContext db = DatabaseHelper.GetDataModelDataContext();
                db.DeleteLoanFeatureByLoanIID(loanInfo.IID);
               // _OiiOMartDBDataContext.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public void UpdateLoanInfoAndLoanFeature(LoanInfo loanInfo, List<LoanFeature> featureList)
        {
            try
            {
                OiiOMartDBDataContext db = DatabaseHelper.GetDataModelDataContext();
                LoanInfo loanInfoNew = db.LoanInfos.SingleOrDefault(d => d.IID == loanInfo.IID);
                DatabaseHelper.Update<LoanInfo>(db, loanInfo, loanInfoNew);
               
                //OiiOMartDBDataContext db = DatabaseHelper.GetDataModelDataContext();
                db.DeleteLoanFeatureByLoanIID(loanInfo.IID);
                db.Dispose();
                foreach (LoanFeature feature in featureList)
                {
                    feature.LoanInfoID = loanInfo.IID;
                    feature.IsRemoved = false;
                    DatabaseHelper.Insert<LoanFeature>(feature);
                }
                // _OiiOMartDBDataContext.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<LoanFeature> GetAllFeatureByLoanIID(Int64? loanIID)
        {
            List<LoanFeature> featureList = new List<LoanFeature>();
            try
            {   
                featureList = _OiiOMartDBDataContext.LoanFeatures.Where(d => d.LoanInfoID == loanIID && d.IsRemoved==false).ToList();
               // _OiiOMartDBDataContext.Dispose();
                return featureList;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public void AddLoanInfoAndFeature(LoanInfo loanInfo,List<LoanFeature> featureList)
        {
            try
            {
                DatabaseHelper.Insert<LoanInfo>(loanInfo);
                foreach(LoanFeature feature in featureList)
                {
                    feature.LoanInfoID = loanInfo.IID;
                    DatabaseHelper.Insert<LoanFeature>(feature);
                }
            }
            catch (Exception ex)
            { throw new Exception(ex.Message, ex); }
        
        }
        public void AddLoanInfo(LoanInfo loanInfo)
        {
            try
            {
                DatabaseHelper.Insert<LoanInfo>(loanInfo);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message, ex); }
        
        }
        

        public static int InsertLoanInfoAndFeatureChildXML(string objectXML)
        {
            try
            {
                return LoanInfoDA.InsertLoanInfoAndFeatureChildXML(objectXML);

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
