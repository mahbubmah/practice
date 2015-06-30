using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OH.DAL;
using System.Data.Linq.SqlClient;

namespace OH.BLL.Basic
{
    public class DivisionOrStateRT : IDisposable
    {
        public DivisionOrStateRT()
        {

        }

        public DivisionOrState GetDivisionOrStateByID(int divisionOrStateID)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                DivisionOrState divisionOrState = new DivisionOrState();
                //divisionOrState = dbContext.DivisionOrStates.Single(d => d.IID == divisionOrStateID && d.IsRemoved == false);
                divisionOrState = dbContext.DivisionOrStates.Single(d => d.IID == divisionOrStateID);
                dbContext.Dispose();
                return divisionOrState;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public List<DivisionOrState> GetDivisionOrStateAll()
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<DivisionOrState> divisionOrStateList = new List<DivisionOrState>();
                //divisionOrStateList = dbContext.DivisionOrStates.Where(d => d.IsRemoved == false).ToList();
                divisionOrStateList = dbContext.DivisionOrStates.ToList();
                dbContext.Dispose();
                return divisionOrStateList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public List<DivisionOrState> GetDistrictOrStateForCountryID(int countryID)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<DivisionOrState> divisionOrStateList = new List<DivisionOrState>();
                //divisionOrStateList = dbContext.DivisionOrStates.Where(d => d.CountryID == countryID && d.IsRemoved == false).ToList();
                divisionOrStateList = dbContext.DivisionOrStates.Where(d => d.CountryID == countryID).ToList();
                dbContext.Dispose();
                return divisionOrStateList;

            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public bool IsDivisionOrStateCodeExists( string code, int countryID)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<DivisionOrState> divisionOrStateList = new List<DivisionOrState>();
                //divisionOrStateList = dbContext.DivisionOrStates.Where(d => d.IsRemoved == false && d.Code.Contains(code) && d.CountryID==countryID).ToList();
                divisionOrStateList = dbContext.DivisionOrStates.Where(d => d.CountryID == countryID && d.Code.Contains(code)).ToList();
                dbContext.Dispose();
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
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<DivisionOrState> divisionOrStateList = new List<DivisionOrState>();
                //divisionOrStateList = dbContext.DivisionOrStates.Where(d => d.IsRemoved == false && d.Code==code && d.IID!=id && d.CountryID==countryID).ToList();
                divisionOrStateList = dbContext.DivisionOrStates.Where(d => d.CountryID == countryID && d.Code == code && d.IID != id).ToList();
                dbContext.Dispose();
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
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<DivisionOrState> divisionOrStateList = new List<DivisionOrState>();
                //divisionOrStateList = dbContext.DivisionOrStates.Where(d => d.IsRemoved == false && d.Name==name && d.CountryID==countryID).ToList();
                divisionOrStateList = dbContext.DivisionOrStates.Where(d => d.CountryID == countryID && d.Name == name).ToList();
                dbContext.Dispose();
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
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<DivisionOrState> divisionOrStateList = new List<DivisionOrState>();
                divisionOrStateList = dbContext.DivisionOrStates.Where(d => d.IsRemoved == false && d.CountryID == countryID).ToList();
                //divisionOrStateList = dbContext.DivisionOrStates.Where(d => d.CountryID == countryID).ToList();
                dbContext.Dispose();
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
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<DivisionOrState> divisionOrStateList = new List<DivisionOrState>();
                //divisionOrStateList = dbContext.DivisionOrStates.Where(d => d.IsRemoved == false && d.Name==name && d.IID != id && d.CountryID==countryID).ToList();
                divisionOrStateList = dbContext.DivisionOrStates.Where(d => d.CountryID == countryID && d.Name == name && d.IID != id).ToList();
                dbContext.Dispose();
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
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                var divisionList = from div in dbContext.DivisionOrStates
                                   join country in dbContext.Countries on div.CountryID equals country.IID
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
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<DivisionOrState> divisionList = new List<DivisionOrState>();
                //divisionList = dbContext.DivisionOrStates.Where(d => d.IsRemoved == false && d.Code.Contains(code)).ToList();
                divisionList = dbContext.DivisionOrStates.Where(d => d.Code==code).ToList();

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
                OiiOHaatDCDataContext msDC = DatabaseHelper.GetDataModelDataContext();
                DivisionOrState divisionOrStateNew = msDC.DivisionOrStates.Single(d => d.IID == divisionOrState.IID);
                DatabaseHelper.Update<DivisionOrState>(msDC, divisionOrState, divisionOrStateNew);

                msDC.Dispose();
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
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<DivisionOrState> divisionOrStateList = new List<DivisionOrState>();
                //divisionOrStateList = dbContext.DivisionOrStates.Where(d => d.IsRemoved == false && d.Code.Contains(code)).ToList();
                divisionOrStateList = dbContext.DivisionOrStates.Where(d => d.Code.Contains(code)).ToList();
                dbContext.Dispose();
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
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<DivisionOrState> divisionOrStateList = new List<DivisionOrState>();
                //divisionOrStateList = dbContext.DivisionOrStates.Where(d => d.IsRemoved == false && d.Code == code && d.IID != id).ToList();
                divisionOrStateList = dbContext.DivisionOrStates.Where(d => d.Code == code && d.IID != id).ToList();
                dbContext.Dispose();
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
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                var divisionList = from div in dbContext.DivisionOrStates
                                   join country in dbContext.Countries on div.CountryID equals country.IID
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
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                DivisionOrState divisionOrState = new DivisionOrState();
                //divisionOrState = dbContext.DivisionOrStates.Single(d => d.IID == p && d.IsRemoved == false);
                divisionOrState = dbContext.DivisionOrStates.Single(d => d.IID == stateID );
                dbContext.Dispose();
                return divisionOrState;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
    }

}
