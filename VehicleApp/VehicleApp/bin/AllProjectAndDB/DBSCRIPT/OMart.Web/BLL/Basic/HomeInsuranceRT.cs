using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Utilities;

namespace BLL.Basic
{
    public class HomeInsuranceRT : IDisposable
    {
        private readonly OiiOMartDBDataContext dbContext;

        public HomeInsuranceRT()
        {
            dbContext = DatabaseHelper.GetDataModelDataContext();
        }
        public void AddHomeInfo(HomeInfo homeInfo)
        {
            try
            {
                DatabaseHelper.Insert<HomeInfo>(homeInfo);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
        //public void UpdateReceiver(AllNews allNews)
        //{
        //    try
        //    {

        //        AllNews allnews = dbContext.AllNews.Single(d => d.IID == allNews.IID);
        //        DatabaseHelper.Update<AllNews>(dbContext, allNews, allnews);
        //    }
        //    catch (Exception ex) { throw new Exception(ex.Message, ex); }
        //}

        #region IDisposable Members
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members

        public List<AllNews> GetHomeIsuranceNewsList()
        {
            try
            {
                var insuranceNewsList =
                    dbContext.AllNews.Where(
                        x =>
                            x.IsRemoved == false &&
                            x.BusinessTypeID == Convert.ToInt32(EnumCollection.BussinessType.Insurance) &&
                            x.BusinessTypeBreakdownID ==
                            Convert.ToInt32(EnumCollection.BusinessInsuranceType.HomeInsurance)).Take(3).ToList();
                return insuranceNewsList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
        public object GetOtherInsuranceUrlList()
        {
            try
            {
                var insuranceSubUrlList =
                    dbContext.UrlWFLists.Where(
                        x =>
                            x.ModuleName == EnumCollection.BussinessType.Insurance.ToString().ToUpper() &&
                            (x.UrlModuleName == null || x.UrlModuleName == string.Empty) &&
                            x.UrlWFName != "HomeInsurance");
                return insuranceSubUrlList;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
       
    }
}
