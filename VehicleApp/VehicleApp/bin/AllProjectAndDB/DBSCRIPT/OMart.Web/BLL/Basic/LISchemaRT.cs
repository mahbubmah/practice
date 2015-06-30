using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Basic;
namespace BLL.Basic
{
    public class LISchemaRT: IDisposable
    {
        //private readonly OiiOMartDBDataContext _OiiOMartDBDataContext=new OiiOMartDBDataContext();
        private readonly OiiOMartDBDataContext _OiiOMartDBDataContext;
        public LISchemaRT()
        {
             _OiiOMartDBDataContext = DatabaseHelper.GetDataModelDataContext();
        }


        public void AddLIApplicableInfoAndFeature(LISchema loanInfo, List<LIApplicableFeature> featureList)
        {
            try
            {
                DatabaseHelper.Insert<LISchema>(loanInfo);
                foreach (LIApplicableFeature feature in featureList)
                {
                    feature.LISchemaID = loanInfo.IID;
                    DatabaseHelper.Insert<LIApplicableFeature>(feature);
                }
            }
            catch (Exception ex)
            { throw new Exception(ex.Message, ex); }

        }
        public static int InsertLISchemaAndFeatureChildXML(string objectXML)
        {
            try
            {
                return LISchemaFeatureDA.InsertLISchemaAndFeatureChildXML(objectXML);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public void UpdateLoanAmntYrScdle(LISchema loanAmntYrScdleObj)
        {
            try
            {
                LISchema loanAmntYrScdleObjNew = _OiiOMartDBDataContext.LISchemas.SingleOrDefault(d => d.IID == loanAmntYrScdleObj.IID);

                DatabaseHelper.Update<LISchema>(_OiiOMartDBDataContext, loanAmntYrScdleObj, loanAmntYrScdleObjNew);
                _OiiOMartDBDataContext.Dispose();

                //_OiiOMartDBDataContext.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
     public void UpdateLISchema(LISchema loanInfo, List<LIApplicableFeature> featureList)
     {
         try
         {
             OiiOMartDBDataContext db = DatabaseHelper.GetDataModelDataContext();
             LISchema loanInfoNew = db.LISchemas.SingleOrDefault(d => d.IID == loanInfo.IID);
             DatabaseHelper.Update<LISchema>(db, loanInfo, loanInfoNew);

             //OiiOMartDBDataContext db = DatabaseHelper.GetDataModelDataContext();
             db.DeleteLiFeatureByLIIID(loanInfo.IID);
             db.Dispose();
             foreach (LIApplicableFeature feature in featureList)
             {
                 feature.LISchemaID = loanInfo.IID;
                 feature.IsRemoved = false;
                 DatabaseHelper.Insert<LIApplicableFeature>(feature);
             }
             // _OiiOMartDBDataContext.Dispose();
         }
         catch (Exception ex)
         {
             throw new Exception(ex.Message, ex);
         }
     }

     public LISchema GetAddLoanAmntYrScdleByIID(LISchema loanAmntYrScdleID)
        {
            try
            {
                LISchema loanAmntYrScdleObj = _OiiOMartDBDataContext.LISchemas.SingleOrDefault(d => d.IID == loanAmntYrScdleID.IID);
                //_OiiOMartDBDataContext.Dispose();
                return loanAmntYrScdleObj;
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message, ex);
            }
        }
     public LISchema GetAddLoanAmntYrScdleByIID(int loanAmntYrScdleID)
     {
         try
         {
             LISchema loanAmntYrScdleObj = _OiiOMartDBDataContext.LISchemas.SingleOrDefault(d => d.IID == loanAmntYrScdleID);
             //_OiiOMartDBDataContext.Dispose();
             return loanAmntYrScdleObj;
         }
         catch (Exception ex)
         {
             throw new Exception(ex.Message, ex);
         }
     }
     public LISchema GetAddLoanAmntYrScdleByNoOfYr(int loanAmntYrScdleID)
     {
         try
         {
             LISchema loanAmntYrScdleObj = _OiiOMartDBDataContext.LISchemas.SingleOrDefault(d => d.NumberOfYear == loanAmntYrScdleID);
             //_OiiOMartDBDataContext.Dispose();
             return loanAmntYrScdleObj;
         }
         catch (Exception ex)
         {
             throw new Exception(ex.Message, ex);
         }
     }

     //public List<LISchema> GetAddLoanAmntYrScdleName(string conName)
     //   {
     //       try
     //       {
     //           var loanAmntYrScdleObj = (from tr in _OiiOMartDBDataContext.LISchemas.OrderBy(x => x)
     //                            where tr.AmountStart.StartsWith(conName)
     //                            select tr).ToList();
     //           return loanAmntYrScdleObj;
     //       }
     //       catch (Exception ex)
     //       {
     //           throw new Exception(ex.Message, ex);
     //       }
     //   }

     public List<LISchema> GetAllLoanAmntYrScdle()
        {
            try
            {

                var loanAmntYrScdleObj = _OiiOMartDBDataContext.LISchemas.ToList();                
                return loanAmntYrScdleObj;
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message, ex); 
            }
        }
     public object GetAllLoanAmntYrScdleforList()
     {
         var lifInsurance = from lifInsu in _OiiOMartDBDataContext.LISchemas
                            join com in _OiiOMartDBDataContext.LIApplicableFeatures on lifInsu.IID equals com.LISchemaID
                            select new { lifInsu.IID, lifInsu.NumberOfYear, lifInsu.AgeMin, lifInsu.AgeMax, lifInsu.UnitAmount, lifInsu.UnitPremiumAmount, lifInsu.UnitReturnAmount, lifInsu.IsRemoved, Description = com.Description, lifInsu.PremiumPolicyID }; //diviionOrState.Name

         return lifInsurance;
     }


        #region IDisposable Members
            public void Dispose()
            {
                GC.SuppressFinalize(this);
            }

        #endregion IDisposable Members

    }
}



