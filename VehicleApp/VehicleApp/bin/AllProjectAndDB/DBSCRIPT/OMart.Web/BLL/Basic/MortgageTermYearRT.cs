using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL.Basic
{
    public class MortgageTermYearRT : IDisposable
    {


        private readonly OiiOMartDBDataContext _OiiOMartDBDataContext;

        public MortgageTermYearRT()
        {
            this._OiiOMartDBDataContext = DatabaseHelper.GetDataModelDataContext();
        }

        public void AddMortgageYear(MortgageTermYear mort)
        {
            try
            {
                DatabaseHelper.Insert<MortgageTermYear>(mort);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message, ex); }
        }

        public Boolean UpdateMortgageYear(MortgageTermYear mortgage)
        {
            try
            {

                MortgageTermYear mortgageNew = _OiiOMartDBDataContext.MortgageTermYears.SingleOrDefault(d => d.IID == mortgage.IID);

                DatabaseHelper.Update<MortgageTermYear>(_OiiOMartDBDataContext, mortgage, mortgageNew);
                return true;                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public MortgageTermYear GetMortgageYearByIID(int mortgageID)
        {
            try
            {
                MortgageTermYear mortgage = _OiiOMartDBDataContext.MortgageTermYears.SingleOrDefault(d => d.IID == mortgageID);
                
                return mortgage;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<MortgageTermYear> GetAllMortgageTermYear()
        {
            try
            {
                OiiOMartDBDataContext db = DatabaseHelper.GetDataModelDataContext();
                var mortgageList = db.MortgageTermYears.ToList();
                return mortgageList;
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
