using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OB.DAL;


namespace OB.BLL.Basic
{
    public class AdGiverRT : IDisposable
    {


        #region IDisposable Members

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members

        #region Get Methods
        public AdGiver GetAdGiverIDByEmail(string email)
        {
            try
            {
                OiiOBookDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                var adGiver = dbContext.AdGivers.SingleOrDefault(ag => ag.EmailID == email);
                dbContext.Dispose();
                return adGiver;
            }

            catch (Exception ex) { throw new Exception(ex.Message, ex); }

        }

        public void AddAdGiver(AdGiver adGiver)
        {
            try
            {

                DatabaseHelper.Insert<AdGiver>(adGiver);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        #endregion Get Methods



        public object GetAdgiverNameBYAlphabet(string AdgiverName)
        {
            try
            {
                OiiOBookDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                var nameList = from adGvr in dbContext.AdGivers
                               where adGvr.IID != null && adGvr.Name.StartsWith(AdgiverName)
                               select new { adGvr.IID, adGvr.Name };
                var list = nameList.ToList();
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
    }
}
