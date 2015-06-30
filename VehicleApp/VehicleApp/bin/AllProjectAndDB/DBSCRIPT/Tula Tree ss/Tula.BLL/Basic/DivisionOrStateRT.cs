using System;
using System.Collections.Generic;
using System.Linq;
using Tula.DAL;

namespace Tula.BLL.Basic
{
    public class DivisionOrStateRT : IDisposable
    {
        private DBConnectionString db=new DBConnectionString();
        public DivisionOrStateRT()
        {

        }

        public DivisionOrState GetDivisionOrStateByID(int divisionOrStateID)
        {
            try
            {
               
                DivisionOrState divisionOrState = new DivisionOrState();
                //divisionOrState = dbContext.DivisionOrStates.Single(d => d.IID == divisionOrStateID && d.IsRemoved == false);
                divisionOrState = db.DivisionOrStates.Single(d => d.IID == divisionOrStateID);
                db.Dispose();
                return divisionOrState;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public List<DivisionOrState> GetDivisionOrStateAll()
        {
            try
            {
                
                List<DivisionOrState> divisionOrStateList = new List<DivisionOrState>();
                //divisionOrStateList = dbContext.DivisionOrStates.Where(d => d.IsRemoved == false).ToList();
                divisionOrStateList = db.DivisionOrStates.ToList();
                db.Dispose();
                return divisionOrStateList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public List<DivisionOrState> GetDistrictOrStateForCountryId(int countryId)
        {
            try
            {
                var divisionOrStateList = db.DivisionOrStates.Where(d => d.CountryID == countryId && d.IsRemoved == false).ToList();
                return divisionOrStateList;

            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public bool IsDivisionOrStateCodeExists( string code, int countryID)
        {
            try
            {
            
                List<DivisionOrState> divisionOrStateList = new List<DivisionOrState>();
                //divisionOrStateList = dbContext.DivisionOrStates.Where(d => d.IsRemoved == false && d.Code.Contains(code) && d.CountryID==countryID).ToList();
                divisionOrStateList = db.DivisionOrStates.Where(d => d.CountryID == countryID && d.Code.Contains(code)).ToList();
                db.Dispose();
                if (divisionOrStateList.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public bool IsDivOrStateCodeExistInOterRows(long id, string code, int countryID)
        {
            try
            {
            
                List<DivisionOrState> divisionOrStateList = new List<DivisionOrState>();
                //divisionOrStateList = dbContext.DivisionOrStates.Where(d => d.IsRemoved == false && d.Code==code && d.IID!=id && d.CountryID==countryID).ToList();
                divisionOrStateList = db.DivisionOrStates.Where(d => d.CountryID == countryID && d.Code == code && d.IID != id).ToList();
                db.Dispose();
                if (divisionOrStateList.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
 
        }


        public bool IsDivisionOrStateNameExists(string name, int countryID)
        {
            try
            {
            
                List<DivisionOrState> divisionOrStateList = new List<DivisionOrState>();
                //divisionOrStateList = dbContext.DivisionOrStates.Where(d => d.IsRemoved == false && d.Name==name && d.CountryID==countryID).ToList();
                divisionOrStateList = db.DivisionOrStates.Where(d => d.CountryID == countryID && d.Name == name).ToList();
                db.Dispose();
                if (divisionOrStateList.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public bool IsDivisionOrStateExistsInCountry(int countryID)
        {
            try
            {
             
                List<DivisionOrState> divisionOrStateList = new List<DivisionOrState>();
                divisionOrStateList = db.DivisionOrStates.Where(d => d.IsRemoved == false && d.CountryID == countryID).ToList();
                //divisionOrStateList = dbContext.DivisionOrStates.Where(d => d.CountryID == countryID).ToList();
                db.Dispose();
                if (divisionOrStateList.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public bool IsDivOrStateNameExistInOterRows(long id, string name, int countryID)
        {
            try
            {
             
                List<DivisionOrState> divisionOrStateList = new List<DivisionOrState>();
                //divisionOrStateList = dbContext.DivisionOrStates.Where(d => d.IsRemoved == false && d.Name==name && d.IID != id && d.CountryID==countryID).ToList();
                divisionOrStateList = db.DivisionOrStates.Where(d => d.CountryID == countryID && d.Name == name && d.IID != id).ToList();
                db.Dispose();
                if (divisionOrStateList.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }


        public object GetAllDivisionOrState()
        {
            try
            {
           
                var divisionList = from div in db.DivisionOrStates
                                   join country in db.Countries on div.CountryID equals country.IID
                                   //where country.IsRemoved == false && div.IsRemoved == false
                                   //where div.IsRemoved == false
                                   select new { div.IID, div.Code, div.Name, div.CreatedBy, div.CreatedDate, div.IsRemoved, CountryName = country.Name };

                return divisionList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public List<DivisionOrState> GetDivisionByCode(string code)
        {
            try
            {
            
                List<DivisionOrState> divisionList = new List<DivisionOrState>();
                //divisionList = dbContext.DivisionOrStates.Where(d => d.IsRemoved == false && d.Code.Contains(code)).ToList();
                divisionList = db.DivisionOrStates.Where(d => d.Code==code).ToList();

                //dbContext.Dispose();
                return divisionList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }



        }

        public void AddDivisionOrState(DivisionOrState divisionOrState)
        {
            try
            {
                DatabaseHelper.Insert<DivisionOrState>(divisionOrState);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }


        public void UpdateDivisionOrState(DivisionOrState divisionOrState)
        {
            try
            {
              
                DivisionOrState divisionOrStateNew = db.DivisionOrStates.Single(d => d.IID == divisionOrState.IID);
                DatabaseHelper.Update<DivisionOrState>(db, divisionOrState, divisionOrStateNew);

                db.Dispose();
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


        public bool IsDivisionOrStateCodeExist(string code)
        {
            try
            {
            
                List<DivisionOrState> divisionOrStateList = new List<DivisionOrState>();
                //divisionOrStateList = dbContext.DivisionOrStates.Where(d => d.IsRemoved == false && d.Code.Contains(code)).ToList();
                divisionOrStateList = db.DivisionOrStates.Where(d => d.Code.Contains(code)).ToList();
                db.Dispose();
                if (divisionOrStateList.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
            
        }

        public bool IsDivOrStateCodeExisInOterRow(long id, string code)
        {
            try
            {
      
                List<DivisionOrState> divisionOrStateList = new List<DivisionOrState>();
                //divisionOrStateList = dbContext.DivisionOrStates.Where(d => d.IsRemoved == false && d.Code == code && d.IID != id).ToList();
                divisionOrStateList = db.DivisionOrStates.Where(d => d.Code == code && d.IID != id).ToList();
                db.Dispose();
                if (divisionOrStateList.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
            
        }

        public object GetDivisionForCountryID(string divOrStateName, int countryID)
        {
            //OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
            //var division = from divOrState in dbContext.DivisionOrStates
            //               join country in dbContext.Countries on divOrState.CountryID equals country.IID
            //               where country.IID==countryID  && divOrState.IsRemoved==false/*&& divOrState.Name.StartsWith(divOrStateName)*/
            //               select new { divOrState.IID, divOrState.Name };            
            //return division;

            try
            {
            
                var divisionList = from div in db.DivisionOrStates
                                   join country in db.Countries on div.CountryID equals country.IID
                                   //where country.IsRemoved == false && div.IsRemoved == false && div.CountryID == countryID && div.Name.StartsWith(divOrStateName)
                                   where  div.CountryID == countryID && div.Name.StartsWith(divOrStateName)
                                   select new { div.IID, div.Name };
                var divlist = divisionList.ToList();

                return divlist;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
 
        }

        public DivisionOrState GetDivisionOrStateByID(long stateID)
        {
            try
            {
            
                DivisionOrState divisionOrState = new DivisionOrState();
                //divisionOrState = dbContext.DivisionOrStates.Single(d => d.IID == p && d.IsRemoved == false);
                divisionOrState = db.DivisionOrStates.Single(d => d.IID == stateID );
                db.Dispose();
                return divisionOrState;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
    }

}
