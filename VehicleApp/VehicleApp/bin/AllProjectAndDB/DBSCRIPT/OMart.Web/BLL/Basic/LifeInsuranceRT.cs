using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Utilities;

namespace BLL.Basic
{
    public class LifeInsuranceRT : IDisposable
    {
        //private readonly OiiOMartDBDataContext _OiiOMartDBDataContext=new OiiOMartDBDataContext();
        private readonly OiiOMartDBDataContext _OiiOMartDBDataContext;
        public LifeInsuranceRT()
        {
            _OiiOMartDBDataContext = DatabaseHelper.GetDataModelDataContext();
        }
        public List<AllNews> GetLifeIsuranceNewsList()
        {
            try
            {
                var insuranceNewsList =
                    _OiiOMartDBDataContext.AllNews.Where(
                        x =>
                            x.IsRemoved == false &&
                            x.BusinessTypeID == Convert.ToInt32(EnumCollection.BussinessType.Insurance) &&
                            x.BusinessTypeBreakdownID ==
                            Convert.ToInt32(EnumCollection.BusinessInsuranceType.LifeInsurance)).Take(3).ToList();
                return insuranceNewsList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public object GetGuideLinesForLifeInsurance()
        {
            try
            {


                var guideLinesForLifeInsurance = (from guideLine in _OiiOMartDBDataContext.GuideLines
                                                  where guideLine.BusinessTypeID == Convert.ToInt16(EnumCollection.BussinessType.Insurance) && guideLine.IsRemoved == false
                                                  select new
                                                  {
                                                      guideLine.IID,
                                                      guideLine.Title,
                                                      Description = guideLine.Description.Length > 151 ? guideLine.Description.Substring(0, 149) : guideLine.Description,
                                                      guideLine.ImageUrl,
                                                      GuideLineIid = guideLine.IID
                                                  }).Take(3).ToList();


                return guideLinesForLifeInsurance;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
        public object GetOtherInsuranceUrlList()
        {
            try
            {
                var insuranceSubUrlList =
                    _OiiOMartDBDataContext.UrlWFLists.Where(
                        x =>
                            x.ModuleName == EnumCollection.BussinessType.Insurance.ToString().ToUpper() &&
                            (x.UrlModuleName == null || x.UrlModuleName == string.Empty) &&
                            x.UrlWFName != "LifeInsurance");
                return insuranceSubUrlList;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
        public void AddLifeInsurance(LifeInsurance LifeInsuranceObj)
        {
            try
            {
                OiiOMartDBDataContext ob = DatabaseHelper.GetDataModelDataContext();
                DatabaseHelper.Insert<LifeInsurance>(LifeInsuranceObj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void UpdateLifeInsurance(LifeInsurance LifeInsuranceObj)
        {
            try
            {
                LifeInsurance LifeInsuranceObjNew = _OiiOMartDBDataContext.LifeInsurances.SingleOrDefault(d => d.IID == LifeInsuranceObj.IID);

                DatabaseHelper.Update<LifeInsurance>(_OiiOMartDBDataContext, LifeInsuranceObj, LifeInsuranceObjNew);
                _OiiOMartDBDataContext.Dispose();

                //_OiiOMartDBDataContext.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public LifeInsurance GetLifeInsuranceByIID(LifeInsurance LifeInsuranceID)
        {
            try
            {
                LifeInsurance LifeInsuranceObj = _OiiOMartDBDataContext.LifeInsurances.SingleOrDefault(d => d.IID == LifeInsuranceID.IID);
                //_OiiOMartDBDataContext.Dispose();
                return LifeInsuranceObj;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public LifeInsurance GetLifeInsuranceByIID(int LifeInsuranceID)
        {
            try
            {
                LifeInsurance LifeInsuranceObj = _OiiOMartDBDataContext.LifeInsurances.SingleOrDefault(d => d.IID == LifeInsuranceID);
                //_OiiOMartDBDataContext.Dispose();
                return LifeInsuranceObj;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        //public List<LifeInsurance> GetAddLifeInsuranceName(string conName)
        //   {
        //       try
        //       {
        //           var LifeInsuranceObj = (from tr in _OiiOMartDBDataContext.LifeInsurances.OrderBy(x => x)
        //                            where tr.AmountStart.StartsWith(conName)
        //                            select tr).ToList();
        //           return LifeInsuranceObj;
        //       }
        //       catch (Exception ex)
        //       {
        //           throw new Exception(ex.Message, ex);
        //       }
        //   }

        public object GetAllLifeInsuranceForListView()
        {
            var lifInsurance = from lifInsu in _OiiOMartDBDataContext.LifeInsurances
                               join com in _OiiOMartDBDataContext.CompanyInfos on lifInsu.CompanyInfoID equals com.IID
                               join lisc in _OiiOMartDBDataContext.LISchemas on lifInsu.LISchemaID equals lisc.IID
                               select new { lifInsu.IID, lifInsu.ClaimsPaidPercent, lifInsu.PackageName, lifInsu.TotalCoverAmount, lifInsu.CriticalillnessCoverAmount, lifInsu.IsGuranteedPremium, lifInsu.IsRemoved, Name = com.Name, lifInsu.LISchemaID, NumberOfYear = lisc.NumberOfYear }; //diviionOrState.Name

            return lifInsurance;
        }
        public object GetAllLifeInsurance()
        {
            try
            {

                var LifeInsuranceObj = _OiiOMartDBDataContext.LifeInsurances.ToList();
                return LifeInsuranceObj;

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



