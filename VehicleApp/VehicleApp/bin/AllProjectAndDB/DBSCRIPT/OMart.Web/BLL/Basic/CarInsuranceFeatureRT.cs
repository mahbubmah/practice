using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL.Basic
{
    public class CarInsuranceFeatureRT : IDisposable
    {
        //private readonly OiiOMartDBDataContext _OiiOMartDBDataContext=new OiiOMartDBDataContext();
        private readonly OiiOMartDBDataContext _OiiOMartDBDataContext;
        public CarInsuranceFeatureRT()
        {
             _OiiOMartDBDataContext = DatabaseHelper.GetDataModelDataContext();
        }

       
     public void AddCarInsuranceFeature(CarInsuranceFeature CarInsuranceFeatureObj)
        {
            try
            {
                OiiOMartDBDataContext ob = DatabaseHelper.GetDataModelDataContext();
                DatabaseHelper.Insert<CarInsuranceFeature>(CarInsuranceFeatureObj);
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message, ex); 
            }
        }

     public void UpdateCarInsuranceFeature(CarInsuranceFeature CarInsuranceFeatureObj)
        {
            try
            {
                CarInsuranceFeature CarInsuranceFeatureObjNew = _OiiOMartDBDataContext.CarInsuranceFeatures.SingleOrDefault(d => d.IID == CarInsuranceFeatureObj.IID);

                DatabaseHelper.Update<CarInsuranceFeature>(_OiiOMartDBDataContext, CarInsuranceFeatureObj, CarInsuranceFeatureObjNew);
                _OiiOMartDBDataContext.Dispose();

                //_OiiOMartDBDataContext.Dispose();
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message, ex); 
            }
        }

     public List<CarInsuranceFeature> GetAddCarInsuranceFeatureByIID(Int64? loanIID)
     {
         List<CarInsuranceFeature> featureList = new List<CarInsuranceFeature>();
         try
         {
             featureList = _OiiOMartDBDataContext.CarInsuranceFeatures.Where(d => d.CarInsuranceID == loanIID && d.IsRemoved == false).ToList();
             // _OiiOMartDBDataContext.Dispose();
             return featureList;
         }
         catch (Exception ex)
         {
             return null;
         }

     }
     //public List<CarInsuranceFeature> GetAddCarInsuranceFeatureByIID(CarInsuranceFeature CarInsuranceFeatureID)
     //   {
     //       try
     //       {
     //           CarInsuranceFeature CarInsuranceFeatureObj = _OiiOMartDBDataContext.CarInsuranceFeatures.SingleOrDefault(d => d.IID == CarInsuranceFeatureID.IID).toList();
     //           //_OiiOMartDBDataContext.Dispose();
     //           return CarInsuranceFeatureObj;
     //       }
     //       catch (Exception ex) 
     //       { 
     //           throw new Exception(ex.Message, ex);
     //       }
     //   }
     public CarInsuranceFeature GetAddCarInsuranceFeatureByIID(int CarInsuranceFeatureID)
     {
         try
         {
             CarInsuranceFeature CarInsuranceFeatureObj = _OiiOMartDBDataContext.CarInsuranceFeatures.SingleOrDefault(d => d.IID == CarInsuranceFeatureID);
             //_OiiOMartDBDataContext.Dispose();
             return CarInsuranceFeatureObj;
         }
         catch (Exception ex)
         {
             throw new Exception(ex.Message, ex);
         }
     }

     //public List<CarInsuranceFeature> GetAddCarInsuranceFeatureName(string conName)
     //   {
     //       try
     //       {
     //           var CarInsuranceFeatureObj = (from tr in _OiiOMartDBDataContext.CarInsuranceFeatures.OrderBy(x => x)
     //                            where tr.AmountStart.StartsWith(conName)
     //                            select tr).ToList();
     //           return CarInsuranceFeatureObj;
     //       }
     //       catch (Exception ex)
     //       {
     //           throw new Exception(ex.Message, ex);
     //       }
     //   }

     public List<CarInsuranceFeature> GetAllCarInsuranceFeature()
        {
            try
            {
                var CarInsuranceFeatureObj = _OiiOMartDBDataContext.CarInsuranceFeatures.ToList();                
                return CarInsuranceFeatureObj;
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



