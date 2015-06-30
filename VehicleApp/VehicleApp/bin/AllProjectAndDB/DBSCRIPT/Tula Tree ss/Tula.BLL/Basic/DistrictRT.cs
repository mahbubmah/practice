using System;
using System.Collections.Generic;
using System.Linq;
using Tula.DAL;

namespace Tula.BLL.Basic
{
    public class DistrictRT : IDisposable
    {
        private DBConnectionString db;
        public DistrictRT()
        {
            db=new DBConnectionString();
        }


        public District GetDistrictByID(int districtID)
        {
            try
            {
               
                District district = new District();
                district = db.Districts.Single(d => d.IID == districtID);

                db.Dispose();
                return district;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public List<District> GetDistrictByDivOrStateID(int divisionOrStateID)
        {
            try
            {
              
                List<District> divisionOrStateList = new List<District>();
                //divisionOrStateList = dbContext.Districts.Where(d => d.DivisionOrStateID == divisionOrStateID && d.IsRemoved == false).ToList();
                divisionOrStateList = db.Districts.Where(d => d.DivisionOrStateID == divisionOrStateID).ToList();
                db.Dispose();
                return divisionOrStateList;

            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }


        public object GetAllDistrictForListView()
        {
            try
            {
               


                var districtList = from distict in db.Districts
                                   join country in db.Countries on distict.CountryID equals country.IID
                                   join divisionOrState in db.DivisionOrStates on distict.DivisionOrStateID equals divisionOrState.IID
                                   //where (country.IsRemoved == false && divisionOrState.IsRemoved == false && distict.IsRemoved == false) //
                                   //where distict.IsRemoved == false
                                   select new { distict.IID, distict.Code, distict.Name, DivisionOrState = divisionOrState.Name, CountryName = country.Name, distict.IsRemoved }; //divisionOrState.Name

                return districtList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        //public List<District> GetDistrictByName(string name)
        //{
        //    try
        //    {
        //        OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
        //        List<District> districtList = new List<District>();
        //        districtList = dbContext.Districts.Where(d => d.IsRemoved == false && d.Name.Contains(name)).ToList();

        //        dbContext.Dispose();
        //        return districtList;
        //    }
        //    catch (Exception ex) { throw new Exception(ex.Message, ex); }
        //}

        public List<District> GetAllDistrict()
        {
            try
            {
              
                List<District> districtList = new List<District>();
                districtList = db.Districts.ToList();
               // dbContext.Dispose();
                return districtList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public bool IsDistrictCodeExists(string districtCode, int divOrStateID)
        {
            try
            {
              
                List<District> districtCodeList = new List<District>();
                //districtCodeList = dbContext.Districts.Where(d => d.IsRemoved == false && d.Code.Contains(districtCode) && d.DivisionOrStateID==divOrStateID).ToList();
                districtCodeList = db.Districts.Where(d => d.DivisionOrStateID == divOrStateID && d.Code.Contains(districtCode)).ToList();
                db.Dispose();
                if (districtCodeList.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public bool IsDistCodeExistInOtherRows(long id, string code, long divOrStateID)
        {
            try
            {
          
                List<District> districtCodeList = new List<District>();
                //districtCodeList = dbContext.Districts.Where(d => d.IsRemoved == false && d.Code.Contains(code) && d.IID!=id && d.DivisionOrStateID==divOrStateID).ToList();
                districtCodeList = db.Districts.Where(d => d.DivisionOrStateID == divOrStateID && d.Code.Contains(code) && d.IID != id).ToList();
                db.Dispose();
                if (districtCodeList.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); } 
        }

        public bool IsDistrictNameExists(string districtName, int divOrStateID)
        {
            try
            {
              
                List<District> districtNameList = new List<District>();
                //districtNameList = dbContext.Districts.Where(d => d.IsRemoved == false && d.Name==districtName && d.DivisionOrStateID==divOrStateID).ToList();
                districtNameList = db.Districts.Where(d => d.DivisionOrStateID == divOrStateID && d.Name == districtName).ToList();
                db.Dispose();
                if (districtNameList.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public bool IsDistrictExistsInDivision(int divOrStateID)
        {
            try
            {
         
                List<District> districtNameList = new List<District>();
                //districtNameList = dbContext.Districts.Where(d => d.IsRemoved == false && d.DivisionOrStateID == divOrStateID).ToList();
                districtNameList = db.Districts.Where(d => d.DivisionOrStateID == divOrStateID).ToList();
                db.Dispose();
                if (districtNameList.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
        public bool IsDistNameExistInOtherRows(long id, string name, long divOrStateID)
        {
            try
            {
             
                List<District> districtCodeList = new List<District>();
                //districtCodeList = dbContext.Districts.Where(d => d.IsRemoved == false && d.Name.Contains(name) && d.IID != id && d.DivisionOrStateID==divOrStateID).ToList();
                districtCodeList = db.Districts.Where(d => d.DivisionOrStateID == divOrStateID && d.Name.Contains(name) && d.IID != id).ToList();
                db.Dispose();
                if (districtCodeList.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public void AddDistrict(District district)
        {
            try
            {
                DatabaseHelper.Insert<District>(district);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public void UpdateDistict(District district)
        {
            try
            {
              

                District objDistrict = db.Districts.Single(d => d.IID == district.IID);
                DatabaseHelper.Update<District>(db, district, objDistrict);

                db.Dispose();
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public bool IsDistrictCodeExists(string code)
        {
            try
            {
            
                List<District> districtCodeList = new List<District>();
                //districtCodeList = dbContext.Districts.Where(d => d.IsRemoved == false && d.Code==code).ToList();
                districtCodeList = db.Districts.Where(d => d.Code == code).ToList();
                db.Dispose();
                if (districtCodeList.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public bool IsDistCodeExistInOtherRows(long id, string code)
        {
            try
            {
          
                List<District> districtNameList = new List<District>();
                //districtNameList = dbContext.Districts.Where(d => d.IsRemoved == false && d.Code==code && d.IID != id).ToList();
                districtNameList = db.Districts.Where(d => d.Code == code && d.IID != id).ToList();
                db.Dispose();
                if (districtNameList.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
            
        }

        public District GetDistrictByID(long disID)
        {
            try
            {
              
                District district = new District();
                //district = dbContext.Districts.Single(d => d.IID == disID && d.IsRemoved == false);
                district = db.Districts.Single(d => d.IID == disID);

                db.Dispose();
                return district;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public List<District> GetDistrictByCountryIdAndDivisionOrStateId(int countryId, long divOrStateId)
        {
            try
            {

                var divisionList =
                    db.Districts.Where(
                        x => x.IsRemoved == false && x.CountryID == countryId && x.DivisionOrStateID == divOrStateId)
                        .ToList();
                var list = divisionList;

                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
        public List<District> GetDistrictByCountryId(int countryId)
        {
            try
            {
                var districtList = from dis in db.Districts
                    //where dis.IsRemoved == false && dis.CountryID == countryId 
                                   where dis.CountryID == countryId 
                    select dis;
                var list = districtList.ToList();
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
    }
}
