using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Basic
{
    public class BusinessInsuranceRT:IDisposable
    {
        private readonly OiiOMartDBDataContext dbContext;

        public BusinessInsuranceRT()
        {
            dbContext = DatabaseHelper.GetDataModelDataContext();
        }
        //public void AddAllNews(AllNews allNews)
        //{
        //    try
        //    {
        //        DatabaseHelper.Insert<AllNews>(allNews);
        //    }
        //    catch (Exception ex) { throw new Exception(ex.Message, ex); }
        //}
        //public void UpdateBusinessAge(AllNews allNews)
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
    }
}
