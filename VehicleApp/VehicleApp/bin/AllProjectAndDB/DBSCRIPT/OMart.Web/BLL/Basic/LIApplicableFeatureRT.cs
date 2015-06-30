using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL.Basic
{
    public class LIApplicableFeatureRT  : IDisposable
    {
        //private readonly OiiOMartDBDataContext _OiiOMartDBDataContext=new OiiOMartDBDataContext();
        private readonly OiiOMartDBDataContext _OiiOMartDBDataContext;
        public LIApplicableFeatureRT()
        {
             _OiiOMartDBDataContext = DatabaseHelper.GetDataModelDataContext();
        }

       
     public void AddLiApplicableFeature(LIApplicableFeature LiApplicableFeatureObj)
        {
            try
            {
                OiiOMartDBDataContext ob = DatabaseHelper.GetDataModelDataContext();
                DatabaseHelper.Insert<LIApplicableFeature>(LiApplicableFeatureObj);
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message, ex); 
            }
        }

     public void UpdateLiApplicableFeature(LIApplicableFeature LiApplicableFeatureObj)
        {
            try
            {
                LIApplicableFeature LiApplicableFeatureObjNew = _OiiOMartDBDataContext.LIApplicableFeatures.SingleOrDefault(d => d.IID == LiApplicableFeatureObj.IID);

                DatabaseHelper.Update<LIApplicableFeature>(_OiiOMartDBDataContext, LiApplicableFeatureObj, LiApplicableFeatureObjNew);
                _OiiOMartDBDataContext.Dispose();

                //_OiiOMartDBDataContext.Dispose();
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message, ex); 
            }
        }

     public List<LIApplicableFeature> GetAddLiApplicableFeatureByIID(Int64? loanIID)
     {
         List<LIApplicableFeature> featureList = new List<LIApplicableFeature>();
         try
         {
             featureList = _OiiOMartDBDataContext.LIApplicableFeatures.Where(d => d.LISchemaID == loanIID && d.IsRemoved == false).ToList();
             // _OiiOMartDBDataContext.Dispose();
             return featureList;
         }
         catch (Exception ex)
         {
             return null;
         }

     }
     //public List<LIApplicableFeature> GetAddLiApplicableFeatureByIID(LIApplicableFeature LiApplicableFeatureID)
     //   {
     //       try
     //       {
     //           LIApplicableFeature LiApplicableFeatureObj = _OiiOMartDBDataContext.LIApplicableFeatures.SingleOrDefault(d => d.IID == LiApplicableFeatureID.IID).toList();
     //           //_OiiOMartDBDataContext.Dispose();
     //           return LiApplicableFeatureObj;
     //       }
     //       catch (Exception ex) 
     //       { 
     //           throw new Exception(ex.Message, ex);
     //       }
     //   }
     public LIApplicableFeature GetAddLiApplicableFeatureByIID(int LiApplicableFeatureID)
     {
         try
         {
             LIApplicableFeature LiApplicableFeatureObj = _OiiOMartDBDataContext.LIApplicableFeatures.SingleOrDefault(d => d.IID == LiApplicableFeatureID);
             //_OiiOMartDBDataContext.Dispose();
             return LiApplicableFeatureObj;
         }
         catch (Exception ex)
         {
             throw new Exception(ex.Message, ex);
         }
     }

     //public List<LIApplicableFeature> GetAddLiApplicableFeatureName(string conName)
     //   {
     //       try
     //       {
     //           var LiApplicableFeatureObj = (from tr in _OiiOMartDBDataContext.LIApplicableFeatures.OrderBy(x => x)
     //                            where tr.AmountStart.StartsWith(conName)
     //                            select tr).ToList();
     //           return LiApplicableFeatureObj;
     //       }
     //       catch (Exception ex)
     //       {
     //           throw new Exception(ex.Message, ex);
     //       }
     //   }

     public List<LIApplicableFeature> GetAllLiApplicableFeature()
        {
            try
            {
                var LiApplicableFeatureObj = _OiiOMartDBDataContext.LIApplicableFeatures.ToList();                
                return LiApplicableFeatureObj;
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



