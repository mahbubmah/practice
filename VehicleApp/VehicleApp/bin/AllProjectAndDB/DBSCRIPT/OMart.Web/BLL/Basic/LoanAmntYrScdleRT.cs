using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Basic
{
    public class LoanAmntYrScdleRT : IDisposable
    {
        //private readonly OiiOMartDBDataContext _OiiOMartDBDataContext=new OiiOMartDBDataContext();
        private readonly OiiOMartDBDataContext _OiiOMartDBDataContext;
        public LoanAmntYrScdleRT()
        {
             _OiiOMartDBDataContext = DatabaseHelper.GetDataModelDataContext();
        }

       
     public void AddLoanAmntYrScdle(LoanAmtYearSchedule loanAmntYrScdleObj)
        {
            try
            {
                OiiOMartDBDataContext ob = DatabaseHelper.GetDataModelDataContext();
                DatabaseHelper.Insert<LoanAmtYearSchedule>(loanAmntYrScdleObj);
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message, ex); 
            }
        }

     public void UpdateLoanAmntYrScdle(LoanAmtYearSchedule loanAmntYrScdleObj)
        {
            try
            {
                LoanAmtYearSchedule loanAmntYrScdleObjNew = _OiiOMartDBDataContext.LoanAmtYearSchedules.SingleOrDefault(d => d.IID == loanAmntYrScdleObj.IID);

                DatabaseHelper.Update<LoanAmtYearSchedule>(_OiiOMartDBDataContext, loanAmntYrScdleObj, loanAmntYrScdleObjNew);
                _OiiOMartDBDataContext.Dispose();

                //_OiiOMartDBDataContext.Dispose();
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message, ex); 
            }
        }

     public LoanAmtYearSchedule GetAddLoanAmntYrScdleByIID(LoanAmtYearSchedule loanAmntYrScdleID)
        {
            try
            {
                LoanAmtYearSchedule loanAmntYrScdleObj = _OiiOMartDBDataContext.LoanAmtYearSchedules.SingleOrDefault(d => d.IID == loanAmntYrScdleID.IID);
                //_OiiOMartDBDataContext.Dispose();
                return loanAmntYrScdleObj;
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message, ex);
            }
        }
     public LoanAmtYearSchedule GetAddLoanAmntYrScdleByIID(int loanAmntYrScdleID)
     {
         try
         {
             LoanAmtYearSchedule loanAmntYrScdleObj = _OiiOMartDBDataContext.LoanAmtYearSchedules.SingleOrDefault(d => d.IID == loanAmntYrScdleID);
             //_OiiOMartDBDataContext.Dispose();
             return loanAmntYrScdleObj;
         }
         catch (Exception ex)
         {
             throw new Exception(ex.Message, ex);
         }
     }

     //public List<LoanAmtYearSchedule> GetAddLoanAmntYrScdleName(string conName)
     //   {
     //       try
     //       {
     //           var loanAmntYrScdleObj = (from tr in _OiiOMartDBDataContext.LoanAmtYearSchedules.OrderBy(x => x)
     //                            where tr.AmountStart.StartsWith(conName)
     //                            select tr).ToList();
     //           return loanAmntYrScdleObj;
     //       }
     //       catch (Exception ex)
     //       {
     //           throw new Exception(ex.Message, ex);
     //       }
     //   }

     public List<LoanAmtYearSchedule> GetAllLoanAmntYrScdle()
        {
            try
            {
                var loanAmntYrScdleObj = _OiiOMartDBDataContext.LoanAmtYearSchedules.ToList();                
                return loanAmntYrScdleObj;
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message, ex); 
            }
        }
        public object GetAllLoanAmntYrScdleList()
        {
            try
            {
                var loanAmntYrScdleObj =( from lay in _OiiOMartDBDataContext.LoanAmtYearSchedules
                                              join com in _OiiOMartDBDataContext.CompanyInfos on lay.CompanyInfoID equals com.IID
                                              select new{CompanyName = com.Name, lay.AmountEnd, lay.AmountStart, lay.APR, lay.APRNote,
                                              lay.CompanyInfoID, lay.Duration, lay.IID, lay.IsRemoved, lay}).ToList();                
                return loanAmntYrScdleObj;
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



