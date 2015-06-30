using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Basic
{
    public class HelpAdviceRT:IDisposable
    {
         private readonly OiiOMartDBDataContext _dbContext;
         private HelpAdvice help;

         public HelpAdviceRT()
        {
            this._dbContext = DatabaseHelper.GetDataModelDataContext();
        }

        
        public List<HelpAdvice> GetHelpContentAll()
        {
            try
            {
                var helpList = (from help in _dbContext.HelpAdvices
                                where help.IsRemoved==false
                                select help).ToList();
                return helpList;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<SP_GetTop2HelpAdviceResult> GetTop2HelpHelpAdvice()
        {
            try
            {
                var helpList = _dbContext.SP_GetTop2HelpAdvice().ToList();
                return helpList;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public HelpAdvice GetHelpByIID(int helpID)
        {
            try
            {
                help = _dbContext.HelpAdvices.Single(d => d.IID == helpID && d.IsRemoved==false);
                _dbContext.Dispose();
                return help;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
       
        public List<HelpAdvice> GetHelpListByIID(int helpIID)
        {
            try
            {
                List<HelpAdvice> helpList = _dbContext.HelpAdvices.Where(d => d.IID == helpIID).ToList();
                _dbContext.Dispose();
                return helpList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }


        public List<HelpAdvice> GetHelpByTitle(string title)
        {
            try
            {
                List<HelpAdvice> helpList = _dbContext.HelpAdvices.Where(con => con.Title == title).ToList();
                return helpList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void AddHelpDescription(HelpAdvice help)
        {
            try
            {
                DatabaseHelper.Insert<HelpAdvice>(help);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }


        public void UpdateHelp(HelpAdvice help)
        {
            try
            {
                HelpAdvice con = _dbContext.HelpAdvices.Single(d => d.IID == help.IID);
                DatabaseHelper.Update<HelpAdvice>(_dbContext, help, con);
                _dbContext.Dispose();
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
        #region IDisposable Members

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members
    }
}
