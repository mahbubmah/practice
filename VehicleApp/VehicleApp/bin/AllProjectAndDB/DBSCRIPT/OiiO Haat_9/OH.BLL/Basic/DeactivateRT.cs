using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OH.DAL;

namespace OH.BLL.Basic
{
    public class DeactivateRT : IDisposable
    {
        /// <summary>
        /// Created By : Asiful Islam
        /// </summary>
       public DeactivateRT()
        { }
        #region IDisposable Members

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members


        public List<LeavingCause> GetLeavingCouseAll()
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<LeavingCause> LeavingCauseList = new List<LeavingCause>();
                LeavingCauseList = dbContext.LeavingCauses.Where(d => d.IsRemoved == false).ToList();
                dbContext.Dispose();
                return LeavingCauseList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
    }
}
