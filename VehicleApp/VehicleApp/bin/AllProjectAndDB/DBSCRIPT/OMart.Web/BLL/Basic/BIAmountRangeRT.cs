using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using DAL;

namespace BLL.Basic
{
    public class BIAmountRangeRT : IDisposable
    {
        private readonly OiiOMartDBDataContext dbContext;

        public BIAmountRangeRT()
        {
            dbContext = DatabaseHelper.GetDataModelDataContext();
        }
        public void AddAmountRange(BIAmountRange amountRange)
        {
            try
            {
                DatabaseHelper.Insert<BIAmountRange>(amountRange);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
        public void UpdateAmountRange(BIAmountRange amountRange)
        {
            try
            {
                BIAmountRange amountRangeNew = dbContext.BIAmountRange.Single(d => d.IID == amountRange.IID);
                DatabaseHelper.Update<BIAmountRange>(dbContext, amountRange, amountRangeNew);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        #region IDisposable Members
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members

        public BIAmountRange GetBiAbmountRangeByIid(long biAmountRangeIid)
        {
            try
            {
                var biAmountRange =dbContext.BIAmountRange.SingleOrDefault(biamount => biamount.IID == biAmountRangeIid && biamount.IsRemoved == false);
                return biAmountRange;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }

        }

        public object GetAllBusinessAmountRange()
        {
            try
            {
                var biAmountRangeList =
                    dbContext.BIAmountRange.Where(x => x.IsRemoved == false).OrderByDescending(x => x.IID);
                return biAmountRangeList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
    }
}
