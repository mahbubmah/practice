using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OB.DAL;


namespace OH.BLL.Basic
{
    public class DefaultRT : IDisposable
    {

        private readonly OiiOBookDCDataContext _dbContext;
        public DefaultRT()
        {
            _dbContext = DatabaseHelper.GetDataModelDataContext();
        }
        #region IDisposable Members
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members


        //public void AddAdLogInfo(AdLogInfo AdLogInfoObj)
        //{
        //    try
        //    {
        //        OiiOMartDBDataContext ob = DatabaseHelper.GetDataModelDataContext();
        //        DatabaseHelper.Insert<AdLogInfo>(AdLogInfoObj);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex);
        //    }
        //}

        //public void UpdateAdLogInfo(AdLogInfo AdLogInfoObj)
        //{
        //    try
        //    {
        //        AdLogInfo AdLogInfoObjNew = _OiiOMartDBDataContext.AdLogInfos.SingleOrDefault(d => d.IID == AdLogInfoObj.IID);

        //        DatabaseHelper.Update<AdLogInfo>(_OiiOMartDBDataContext, AdLogInfoObj, AdLogInfoObjNew);
        //        _OiiOMartDBDataContext.Dispose();

        //        //_OiiOMartDBDataContext.Dispose();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex);
        //    }
        //}
        public IQueryable<BooKCategory> GetBookCatListForDefaultAside()
        {
            try
            {
                var bookCatList = _dbContext.BooKCategory.Where(x => x.IsRemoved == false).OrderBy(x => x.CategoryName);
                return bookCatList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message,ex);
            }
        }
    }
}
