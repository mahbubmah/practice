using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Utilities;

namespace BLL.Basic
{
  public  class BIDefaultRT:IDisposable
    {
        private readonly OiiOMartDBDataContext dbContext;
        public BIDefaultRT()
        {
            dbContext = DatabaseHelper.GetDataModelDataContext();
        }
        #region IDisposable Members
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members

      public object GetOtherInsuranceUrlList()
      {
          try
          {
              var insuranceSubUrlList =
                  dbContext.UrlWFLists.Where(
                      x =>
                          x.ModuleName == EnumCollection.BussinessType.Insurance.ToString().ToUpper() &&
                          (x.UrlModuleName==null ||x.UrlModuleName==string.Empty) && 
                          x.UrlWFName != "BusinessInsurance");
              return insuranceSubUrlList;
          }
          catch (Exception ex)
          {
              
              throw new Exception(ex.Message,ex);
          }
      }

      public object GetAllInsuranceCompany()
      {
          try
          {
              var insuranceCompanyList =
                  dbContext.CompanyInfos.Where(
                      x =>
                          x.BussinessTypeID == Convert.ToInt32(EnumCollection.BussinessType.Insurance) &&
                          x.IsRemoved == false);
              return insuranceCompanyList;
          }
          catch (Exception ex)
          {

              throw new Exception(ex.Message, ex);
          }
      }
      public object GetGuideLinesForBiInsurance()
      { 
          try
          {


              var guideLineForEnergy = (from guideLine in dbContext.GuideLines
                                        where guideLine.BusinessTypeID == Convert.ToInt16(EnumCollection.BussinessType.Insurance) && guideLine.IsRemoved == false
                                        select new
                                        {
                                            guideLine.IID,
                                            guideLine.Title,
                                            Description = guideLine.Description.Length > 151 ? guideLine.Description.Substring(0, 149) : guideLine.Description,
                                            guideLine.ImageUrl,
                                            GuideLineIid = guideLine.IID
                                        }).Take(3).ToList();


              return guideLineForEnergy;
          }
          catch (Exception ex) { throw new Exception(ex.Message, ex); }
      }

      public List<AllNews> GetBiIsuranceNewsList()
      {
          try
          {
              var insuranceNewsList =
                  dbContext.AllNews.Where(
                      x =>
                          x.IsRemoved == false &&
                          x.BusinessTypeID == Convert.ToInt32(EnumCollection.BussinessType.Insurance) &&
                          x.BusinessTypeBreakdownID ==
                          Convert.ToInt32(EnumCollection.BusinessInsuranceType.BusinessInsurance)).Take(3).ToList();
              return insuranceNewsList;
          }
          catch (Exception ex) { throw new Exception(ex.Message, ex); }
      }
    }
}
