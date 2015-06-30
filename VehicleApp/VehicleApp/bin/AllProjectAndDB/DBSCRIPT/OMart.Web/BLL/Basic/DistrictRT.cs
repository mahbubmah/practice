using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Basic
{
    public class DistrictRT : IDisposable
    {
        private readonly OiiOMartDBDataContext _OiiOMartDBDataContext;
        public DistrictRT()
        {
            _OiiOMartDBDataContext = DatabaseHelper.GetDataModelDataContext();
        }


        public District GetDistrictByID(int districtID)
        {
            try
            {
               
                District district = new District();
                district = _OiiOMartDBDataContext.Districts.Single(d => d.IID == districtID);

                //_OiiOMartDBDataContext.Dispose();
                return district;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public List<District> GetDistrictByDivOrStateID(long divisionOrStateID)
        {
            try
            {
                List<District> divisionOrStateList = _OiiOMartDBDataContext.Districts.Where(d => d.DivisionOrStateID == divisionOrStateID && d.IsRemoved==false).ToList();
   
                return divisionOrStateList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }


        public object GetAllDistrictForListView()
        {
            try
            {
                


                var districtList = from distict in _OiiOMartDBDataContext.Districts
                                   join country in _OiiOMartDBDataContext.Countries on distict.CountryID equals country.IID
                                   join divisionOrState in _OiiOMartDBDataContext.DivisionOrStates on distict.DivisionOrStateID equals divisionOrState.IID
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
        //        OiiOHaatDCDataContext _OiiOMartDBDataContext = DatabaseHelper.GetDataModelDataContext();
        //        List<District> districtList = new List<District>();
        //        districtList = _OiiOMartDBDataContext.Districts.Where(d => d.IsRemoved == false && d.Name.Contains(name)).ToList();

        //        _OiiOMartDBDataContext.Dispose();
        //        return districtList;
        //    }
        //    catch (Exception ex) { throw new Exception(ex.Message, ex); }
        //}

        public List<District> GetAllDistrict()
        {
            try
            {
               
                List<District> districtList = new List<District>();
                districtList = _OiiOMartDBDataContext.Districts.ToList();
                //_OiiOMartDBDataContext.Dispose();
                return districtList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public bool IsDistrictCodeExists(string districtCode, int divOrStateID)
        {
            try
            {
              
                List<District> districtCodeList = new List<District>();
                //districtCodeList = _OiiOMartDBDataContext.Districts.Where(d => d.IsRemoved == false && d.Code.Contains(districtCode) && d.DivisionOrStateID==divOrStateID).ToList();
                districtCodeList = _OiiOMartDBDataContext.Districts.Where(d => d.DivisionOrStateID == divOrStateID && d.Code.Contains(districtCode)).ToList();
                //_OiiOMartDBDataContext.Dispose();
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
                //districtCodeList = _OiiOMartDBDataContext.Districts.Where(d => d.IsRemoved == false && d.Code.Contains(code) && d.IID!=id && d.DivisionOrStateID==divOrStateID).ToList();
                districtCodeList = _OiiOMartDBDataContext.Districts.Where(d => d.DivisionOrStateID == divOrStateID && d.Code.Contains(code) && d.IID != id).ToList();
                //_OiiOMartDBDataContext.Dispose();
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
                //districtNameList = _OiiOMartDBDataContext.Districts.Where(d => d.IsRemoved == false && d.Name==districtName && d.DivisionOrStateID==divOrStateID).ToList();
                districtNameList = _OiiOMartDBDataContext.Districts.Where(d => d.DivisionOrStateID == divOrStateID && d.Name == districtName).ToList();
                //_OiiOMartDBDataContext.Dispose();
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
                //districtNameList = _OiiOMartDBDataContext.Districts.Where(d => d.IsRemoved == false && d.DivisionOrStateID == divOrStateID).ToList();
                districtNameList = _OiiOMartDBDataContext.Districts.Where(d => d.DivisionOrStateID == divOrStateID).ToList();
                //_OiiOMartDBDataContext.Dispose();
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
                //districtCodeList = _OiiOMartDBDataContext.Districts.Where(d => d.IsRemoved == false && d.Name.Contains(name) && d.IID != id && d.DivisionOrStateID==divOrStateID).ToList();
                districtCodeList = _OiiOMartDBDataContext.Districts.Where(d => d.DivisionOrStateID == divOrStateID && d.Name.Contains(name) && d.IID != id).ToList();
                //_OiiOMartDBDataContext.Dispose();
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
                District objDistrict = _OiiOMartDBDataContext.Districts.Single(d => d.IID == district.IID);
                DatabaseHelper.Update<District>(_OiiOMartDBDataContext, district, objDistrict);

                //_OiiOMartDBDataContext.Dispose();
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
                //districtCodeList = _OiiOMartDBDataContext.Districts.Where(d => d.IsRemoved == false && d.Code==code).ToList();
                districtCodeList = _OiiOMartDBDataContext.Districts.Where(d => d.Code == code).ToList();
                //_OiiOMartDBDataContext.Dispose();
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
                //districtNameList = _OiiOMartDBDataContext.Districts.Where(d => d.IsRemoved == false && d.Code==code && d.IID != id).ToList();
                districtNameList = _OiiOMartDBDataContext.Districts.Where(d => d.Code == code && d.IID != id).ToList();
                //_OiiOMartDBDataContext.Dispose();
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
                //district = _OiiOMartDBDataContext.Districts.Single(d => d.IID == disID && d.IsRemoved == false);
                district = _OiiOMartDBDataContext.Districts.Single(d => d.IID == disID);

                //_OiiOMartDBDataContext.Dispose();
                return district;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public object GetDistrictByCountryNDivisionID(string districtName, int countryID, int divOrStateID)
        {
            try
            {
              
                var divisionList = from dis in _OiiOMartDBDataContext.Districts
                                   //where dis.IsRemoved == false && dis.CountryID == countryID && dis.DivisionOrStateID==divOrStateID && dis.Name.StartsWith(districtName)
                                   where dis.CountryID == countryID && dis.DivisionOrStateID == divOrStateID && dis.Name.StartsWith(districtName)
                                   select new { dis.IID, dis.Name };
                var list = divisionList.ToList();

                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
        public List<District> GetDistrictByCountryId(int countryId)
        {
            try
            {
               
                var districtList = from dis in _OiiOMartDBDataContext.Districts
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
