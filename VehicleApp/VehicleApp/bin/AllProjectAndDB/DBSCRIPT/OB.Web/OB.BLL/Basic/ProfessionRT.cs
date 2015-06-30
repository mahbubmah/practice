using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OB.DAL;
using OB.Utilities;

namespace OB.BLL.Basic
{
    public class ProfessionRT : IDisposable
    {

        private readonly OiiOBookDCDataContext _OiiOBookDCDataContext;
        public ProfessionRT()
        {
            _OiiOBookDCDataContext = DatabaseHelper.GetDataModelDataContext();
        }


        public void AddProfession(Professions ProfessionObj)
        {
            try
            {
                OiiOBookDCDataContext ob = DatabaseHelper.GetDataModelDataContext();
                DatabaseHelper.Insert<Professions>(ProfessionObj);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void UpdateProfessions(Professions ProfessionsObj)
        {
            try
            {
                Professions ProfessionsObjNew = _OiiOBookDCDataContext.Professions.SingleOrDefault(d => d.IID == ProfessionsObj.IID);

                DatabaseHelper.Update<Professions>(_OiiOBookDCDataContext, ProfessionsObj, ProfessionsObjNew);
                _OiiOBookDCDataContext.Dispose();

                //_OiiOBookDCDataContext.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public Professions GetAddProfessionsByIID(Professions ProfessionsID)
        {
            try
            {
                Professions ProfessionsObj = _OiiOBookDCDataContext.Professions.SingleOrDefault(d => d.IID == ProfessionsID.IID);
                //_OiiOBookDCDataContext.Dispose();
                return ProfessionsObj;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public Professions GetAddProfessionsByIID(int ProfessionsID)
        {
            try
            {
                Professions ProfessionsObj = _OiiOBookDCDataContext.Professions.SingleOrDefault(d => d.IID == ProfessionsID);
                //_OiiOBookDCDataContext.Dispose();
                return ProfessionsObj;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        public List<Professions> GetAllProfessionListForDropDown()
        {
            try
            {
                var professionList = _OiiOBookDCDataContext.Professions.Where(x => x.IsRemoved == false).ToList();
                return professionList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<ProfessionEX> GetAllProfessions()
        {
            try
            {
                var ProfessionsObj = _OiiOBookDCDataContext.Professions.ToList();
                List<ProfessionEX> list = new List<ProfessionEX>();
                foreach (Professions p in ProfessionsObj)
                {
                    ProfessionEX ex = new ProfessionEX();
                    ex.IID = p.IID;
                    ex.Type = p.Type;
                    ex.Name = EnumHelper.EnumToStringWithSpace<EnumCollection.type>((int)p.Type);
                    ex.Note = p.Note;
                    list.Add(ex);
                }
                return list;
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
    public class ProfessionEX
    {
        public int IID { get; set; }
        public int? Type { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
    }

}
