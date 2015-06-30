using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Basic
{
   public class BIAgeRT:IDisposable
   {
       private readonly OiiOMartDBDataContext dbContext;

       public BIAgeRT()
        {
            dbContext = DatabaseHelper.GetDataModelDataContext();
        }
        public void AddBusinessAge(BIBusinessAge biAge)
        {
            try
            {
                DatabaseHelper.Insert<BIBusinessAge>(biAge);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
        public void UpdateBusinessAge(BIBusinessAge biAge)
        {
            try
            {

                BIBusinessAge biAgeNew  = dbContext.BIBusinessAge.Single(d => d.IID == biAge.IID);
                DatabaseHelper.Update<BIBusinessAge>(dbContext, biAge, biAgeNew);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        #region IDisposable Members
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members

       public BIBusinessAge GetBiAgeIntervalByIid(long biAgeIid)
       {
           try
           {
               var biAge = dbContext.BIBusinessAge.SingleOrDefault(biage => biage.IID == biAgeIid && biage.IsRemoved==false);
               return biAge;
           }
           catch (Exception ex) { throw new Exception(ex.Message, ex); }
       }

       public IEnumerable<BIBusinessAge> GetAllBusinessAgeListForListView()
       {
           try
           {
               var businessAgeList = dbContext.BIBusinessAge.Where(x=>x.IsRemoved==false).OrderByDescending(x=>x.IID);
               return businessAgeList;
           }
           catch (Exception ex) { throw new Exception(ex.Message, ex); }
       }
      
   }
}
