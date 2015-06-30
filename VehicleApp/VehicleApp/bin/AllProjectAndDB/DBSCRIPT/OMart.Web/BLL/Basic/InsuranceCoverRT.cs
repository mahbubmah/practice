using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Basic
{
    public class InsuranceCoverRT:IDisposable
    {
        private readonly OiiOMartDBDataContext _oiioMartDbContext;
        public InsuranceCoverRT()
        {
            _oiioMartDbContext = DatabaseHelper.GetDataModelDataContext();
        }

        
        #region IDisposable Members
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members

        public List<Profession> GetProfessionsForDropDown()
        {
            try
            {
                var professionList = _oiioMartDbContext.Professions.Where(x=>x.IsRemoved==false).OrderBy(x=>x.Name).ToList();
                return professionList;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message,ex);
            }
        }
        
        public void AddAppicant(Applicant applicant)
        {
            try
            {
                DatabaseHelper.Insert<Applicant>(applicant);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
        
        public void UpdateAppicant(Applicant applicant)
        {
            try
            {
                Applicant appicantNew = _oiioMartDbContext.Applicant.Single(d => d.IID == applicant.IID);
                DatabaseHelper.Update<Applicant>(_oiioMartDbContext, applicant, appicantNew);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
    }
}
