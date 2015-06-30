using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL.Basic
{
    public class ProfessionRT : IDisposable
    {
        //private readonly OiiOMartDBDataContext _OiiOMartDBDataContext=new OiiOMartDBDataContext();
        private readonly OiiOMartDBDataContext _OiiOMartDBDataContext;
        public ProfessionRT()
        {
             _OiiOMartDBDataContext = DatabaseHelper.GetDataModelDataContext();
        }

       
     public void AddProfession(Profession ProfessionObj)
        {
            try
            {
                OiiOMartDBDataContext ob = DatabaseHelper.GetDataModelDataContext();
                DatabaseHelper.Insert<Profession>(ProfessionObj);
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message, ex); 
            }
        }

     public void UpdateProfessions(Profession ProfessionsObj)
        {
            try
            {
                Profession ProfessionsObjNew = _OiiOMartDBDataContext.Professions.SingleOrDefault(d => d.IID == ProfessionsObj.IID);

                DatabaseHelper.Update<Profession>(_OiiOMartDBDataContext, ProfessionsObj, ProfessionsObjNew);
                _OiiOMartDBDataContext.Dispose();

                //_OiiOMartDBDataContext.Dispose();
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message, ex); 
            }
        }

     public Profession GetAddProfessionsByIID(Profession ProfessionsID)
        {
            try
            {
                Profession ProfessionsObj = _OiiOMartDBDataContext.Professions.SingleOrDefault(d => d.IID == ProfessionsID.IID);
                //_OiiOMartDBDataContext.Dispose();
                return ProfessionsObj;
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message, ex);
            }
        }
     public Profession GetAddProfessionsByIID(int ProfessionsID)
     {
         try
         {
             Profession ProfessionsObj = _OiiOMartDBDataContext.Professions.SingleOrDefault(d => d.IID == ProfessionsID);
             //_OiiOMartDBDataContext.Dispose();
             return ProfessionsObj;
         }
         catch (Exception ex)
         {
             throw new Exception(ex.Message, ex);
         }
     }
   


     public List<Profession> GetAllProfessions()
        {
            try
            {
                var ProfessionsObj = _OiiOMartDBDataContext.Professions.ToList();                
                return ProfessionsObj;
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



