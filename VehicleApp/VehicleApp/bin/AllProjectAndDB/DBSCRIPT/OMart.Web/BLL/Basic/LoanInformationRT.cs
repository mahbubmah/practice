using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Basic
{
     public class LoanInformationRT
    {
         private readonly OiiOMartDBDataContext _OiiOMartDBDataContext; 
         public LoanInformationRT()
         {
            this._OiiOMartDBDataContext = DatabaseHelper.GetDataModelDataContext();
         }
         public object GetAllLoanInformation() 
         {
             try
             {
                 var loanInformation = _OiiOMartDBDataContext.SpGetAllLoanTypeInformation();
                 return loanInformation;
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message, ex);
             }
         }
         //public object GetAllLoanDescription( int LoanTypeID)
         //{
         //    try
         //    {
         //        var loanDescription = _OiiOMartDBDataContext.SpGetAllLoanDescriptionDetail(LoanTypeID).ToList();
         //        return loanDescription;
         //    }
         //    catch (Exception ex)
         //    {
         //        throw new Exception(ex.Message, ex);
         //    }
         //}

         public int CountAllLoanDescription(int loanTypeID,int amount, int duration )
         {
             try
             {
                 var loanDescription = _OiiOMartDBDataContext.SpGetAllLoanDescriptionDetail(loanTypeID,amount,duration).ToList();
                 return loanDescription.Count;
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message, ex);
             }
         }

         public object GetAllLoanDescriptionTest(int loanTypeID,  int amount, int duration,  int startRowIndex, int maxRowNumber)
         {
             try
             {
                 //var loanDescription = _OiiOMartDBDataContext.SpGetAllLoanDescriptionDetailPassingParameter(loanTypeID, startRowIndex, maxRowNumber).ToList();
                 var loanDescription = _OiiOMartDBDataContext.SpSearchAllLoanDescriptionDetailPassingParameter(loanTypeID,amount,duration,startRowIndex,maxRowNumber).ToList();
                 return loanDescription;
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message, ex);
             }
         }

         public List<LoanFeature> GetLoanFeature(long LoanFeatureID)
         {
             try
             {
                 //var loanFeature = _OiiOMartDBDataContext.LoanFeatures.Where(l => l.LoanInfoID == LoanFeatureID  && l.IsRemoved==false).ToList();
                 //return loanFeature.GetRange(0,3);

                 IEnumerable<LoanFeature> allNews = _OiiOMartDBDataContext.ExecuteQuery<LoanFeature>(@"SELECT  top 3 * FROM [LoanFeature] WHERE IsRemoved=0 AND LoanInfoID=" +LoanFeatureID+"  ORDER BY newid()");
                 return allNews.ToList();

             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message, ex);
             }
         }
     
         public List<LoanType> GetAllLoanType()
         {
             try
             {
                 var loanType = _OiiOMartDBDataContext.LoanTypes.Where(l => l.IsRemoved == false).ToList();
                 return loanType;
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message, ex);
             }
         }
         public List<LoanType> GetLoanTypeAndDescription()
         {
             try
             {
                 var loanType = _OiiOMartDBDataContext.LoanTypes.OrderBy(l=>l.IID).Where(l => l.IsRemoved == false).ToList();
                 return loanType;
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message, ex);
             }
         }
    }
}
