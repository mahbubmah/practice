using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OH.DAL;

namespace OH.BLL.Basic
{
    /// <summary>
    /// Created By : Asiful Islam
    /// </summary>
    public class VisitorCounterRT : IDisposable
    {

        private readonly OiiOHaatDCDataContext _OiiOMartDBDataContext;

        public VisitorCounterRT()
        {
            _OiiOMartDBDataContext = DatabaseHelper.GetDataModelDataContext();
        }

        public void AddVisitorCounter(VisitorCounter visitorCounter)
        {
            try
            {
                DatabaseHelper.Insert<VisitorCounter>(visitorCounter);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void UpdateVisitorCounter(VisitorCounter visitorCounter)
        {
            try
            {
                VisitorCounter objVisitor = _OiiOMartDBDataContext.VisitorCounters.SingleOrDefault(d => d.IID == visitorCounter.IID);
                DatabaseHelper.Update<VisitorCounter>(_OiiOMartDBDataContext, visitorCounter, objVisitor);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public List<VisitorCounter> GetAllVisitorCounterList()
        {
            try
            {
                List<VisitorCounter> Registereduser = new List<VisitorCounter>();
                Registereduser = _OiiOMartDBDataContext.VisitorCounters.ToList();
                Dispose();
                return Registereduser;
            }
            catch (Exception ex)
            {

                throw new Exception();
            }
        }

        public void DeleteVisitorCounterByIID(long Id)
        {
            try
            {
                
                VisitorCounter objVisitor = _OiiOMartDBDataContext.VisitorCounters.SingleOrDefault(x => x.IID == Id);
                DatabaseHelper.Delete(_OiiOMartDBDataContext, objVisitor);
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
