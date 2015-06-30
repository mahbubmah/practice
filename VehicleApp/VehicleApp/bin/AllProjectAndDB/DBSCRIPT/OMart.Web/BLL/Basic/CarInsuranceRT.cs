using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Basic;
namespace BLL.Basic
{
    public class CarInsuranceRT : IDisposable
    {
        //private readonly OiiOMartDBDataContext _OiiOMartDBDataContext=new OiiOMartDBDataContext();
        private readonly OiiOMartDBDataContext _OiiOMartDBDataContext;
        public CarInsuranceRT()
        {
            _OiiOMartDBDataContext = DatabaseHelper.GetDataModelDataContext();
        }


        public void AddLIApplicableInfoAndFeature(CarInsurance loanInfo, List<CarInsuranceFeature> featureList)
        {
            try
            {
                DatabaseHelper.Insert<CarInsurance>(loanInfo);
                foreach (CarInsuranceFeature feature in featureList)
                {
                    feature.CarInsuranceID = loanInfo.IID;
                    DatabaseHelper.Insert<CarInsuranceFeature>(feature);
                }
            }
            catch (Exception ex)
            { throw new Exception(ex.Message, ex); }

        }
        public static int InsertCarInsuranceAndFeatureChildXML(string objectXML)
        {
            try
            {
                return CarInsuranceFeatureDA.InsertCarInsuranceAndFeatureChildXML(objectXML);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public void UpdateLoanAmntYrScdle(CarInsurance loanAmntYrScdleObj)
        {
            try
            {
                CarInsurance loanAmntYrScdleObjNew = _OiiOMartDBDataContext.CarInsurances.SingleOrDefault(d => d.IID == loanAmntYrScdleObj.IID);

                DatabaseHelper.Update<CarInsurance>(_OiiOMartDBDataContext, loanAmntYrScdleObj, loanAmntYrScdleObjNew);
                _OiiOMartDBDataContext.Dispose();

                //_OiiOMartDBDataContext.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public void UpdateCarInsurance(CarInsurance loanInfo, List<CarInsuranceFeature> featureList)
        {
            try
            {
                OiiOMartDBDataContext db = DatabaseHelper.GetDataModelDataContext();
                CarInsurance loanInfoNew = db.CarInsurances.SingleOrDefault(d => d.IID == loanInfo.IID);
                DatabaseHelper.Update<CarInsurance>(db, loanInfo, loanInfoNew);

                //OiiOMartDBDataContext db = DatabaseHelper.GetDataModelDataContext();
                db.DeleteLiFeatureByLIIID(loanInfo.IID);
                db.Dispose();
                foreach (CarInsuranceFeature feature in featureList)
                {
                    feature.CarInsuranceID = loanInfo.IID;
                    feature.IsRemoved = false;
                    DatabaseHelper.Insert<CarInsuranceFeature>(feature);
                }
                // _OiiOMartDBDataContext.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public CarInsurance GetAddLoanAmntYrScdleByIID(CarInsurance loanAmntYrScdleID)
        {
            try
            {
                CarInsurance loanAmntYrScdleObj = _OiiOMartDBDataContext.CarInsurances.SingleOrDefault(d => d.IID == loanAmntYrScdleID.IID);
                //_OiiOMartDBDataContext.Dispose();
                return loanAmntYrScdleObj;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public CarInsurance GetAddLoanAmntYrScdleByIID(int loanAmntYrScdleID)
        {
            try
            {
                CarInsurance loanAmntYrScdleObj = _OiiOMartDBDataContext.CarInsurances.SingleOrDefault(d => d.IID == loanAmntYrScdleID);
                //_OiiOMartDBDataContext.Dispose();
                return loanAmntYrScdleObj;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        //public CarInsurance GetLoanAmntYrScdleByNoOfYr(int loanAmntYrScdleID)
        //{
        //    try
        //    {
        //        CarInsurance loanAmntYrScdleObj = _OiiOMartDBDataContext.CarInsurances.SingleOrDefault(d => d.NumberOfYear == loanAmntYrScdleID);
        //        //_OiiOMartDBDataContext.Dispose();
        //        return loanAmntYrScdleObj;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex);
        //    }
        //}

        //public List<CarInsurance> GetAddLoanAmntYrScdleName(string conName)
        //   {
        //       try
        //       {
        //           var loanAmntYrScdleObj = (from tr in _OiiOMartDBDataContext.CarInsurances.OrderBy(x => x)
        //                            where tr.AmountStart.StartsWith(conName)
        //                            select tr).ToList();
        //           return loanAmntYrScdleObj;
        //       }
        //       catch (Exception ex)
        //       {
        //           throw new Exception(ex.Message, ex);
        //       }
        //   }

        public object GetAllLoanAmntYrScdle()
        {
            try
            {
                //var districtList = from distict in _OiiOMartDBDataContext.Districts
                //                   join country in _OiiOMartDBDataContext.Countries on distict.CountryID equals country.IID
                //                   join divisionOrState in _OiiOMartDBDataContext.DivisionOrStates on distict.DivisionOrStateID equals divisionOrState.IID
                //                   //where (country.IsRemoved == false && divisionOrState.IsRemoved == false && distict.IsRemoved == false) //
                //                   //where distict.IsRemoved == false
                //                   select new { distict.IID, distict.Code, distict.Name, DivisionOrState = divisionOrState.Name, CountryName = country.Name, distict.IsRemoved };
                var loanAmntYrScdleObj = from car in _OiiOMartDBDataContext.CarInsurances.Where(x=>x.IsRemoved==false)
                                         join com in _OiiOMartDBDataContext.CompanyInfos on car.CompanyInfoID equals com.IID
                                         select new
                                         {
                                             car.AnnuallyGrossAmount,
                                             car.CarInsuranceFeatures,
                                             car.CarInsuranceParameter,
                                             car.CarInsuranceParameterID,
                                             car.CarValueAmount,
                                             car.CompanyInfo,
                                             car.CompanyInfoID,
                                             car.FixedCompulsoryAmount,
                                             car.FixedTotalAmount,
                                             car.FixedVoluntaryAmount,
                                             car.IID,
                                             car.InstallmentAmount,
                                             car.TotalMonth,
                                             CompanyName = com.Name,
                                             car.IsRemoved
                                         };
                return loanAmntYrScdleObj;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        //public object GetAllLoanAmntYrScdleforList()
        //{
        //    var lifInsurance = from lifInsu in _OiiOMartDBDataContext.CarInsurances
        //                       join com in _OiiOMartDBDataContext.CarInsuranceFeatures on lifInsu.IID equals com.CarInsuranceID
        //                       select new { lifInsu.IID, lifInsu.NumberOfYear, lifInsu.AgeMin, lifInsu.AgeMax,
        //                           lifInsu.UnitAmount, lifInsu.UnitPremiumAmount, lifInsu.UnitReturnAmount, lifInsu.IsRemoved, Description = com.Description, lifInsu.PremiumPolicyID }; //diviionOrState.Name

        //    return lifInsurance;
        //}


        #region IDisposable Members
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members



        public List<spGetAllInsuranceCarNewsResult> GetAllInsuranceCarNews()
        {
            try
            {
                var car = _OiiOMartDBDataContext.spGetAllInsuranceCarNews().ToList();
                //_OiiOMartDBDataContext.Dispose();
                return car;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public object GetAllInsuranceTypesForCarInsurance()
        {
            try
            {
                var insuranceList = from url in _OiiOMartDBDataContext.UrlWFLists
                                    where (url.ModuleName == "Insurance" && url.UrlWFSerialNo >= 0 && url.UrlWFName != "CarInsurance")
                                     select new
                                   {
                                       url.UrlWFName,
                                       url.UrlWFDisplayName
                                   };

                return insuranceList;
            }

            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            
        }

        public object GetAllInsuranceCompanies()
        {
            try
            {
                var insuranceList = from comp in _OiiOMartDBDataContext.CompanyInfos
                                    where (comp.BussinessTypeID ==4)
                                    select new
                                    {
                                        comp.LogoUrl
                                    };

                return insuranceList;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public object GetAllCarInsuranceQuote(int CarTypeID, int CarConditionID, long run, int age, decimal CarValueAmount, float PremiumTotalPercent, int Duration)
        {
            try
            {
                var carInsResult = _OiiOMartDBDataContext.spGetCarInsuranceQuotes(CarTypeID, CarConditionID, run, age, CarValueAmount, PremiumTotalPercent, Duration);

 

                return carInsResult;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
    }
}


