using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OB.DAL;


namespace OB.BLL.Basic
{
    public class DistrictRT : IDisposable
    {
        public DistrictRT()
        {

        }


        public District GetDistrictByID(int districtID)
        {
            try
            {
                OiiOBookDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                District district = new District();
                district = dbContext.Districts.Single(d => d.IID == districtID && d.IsRemoved == false);

                dbContext.Dispose();
                return district;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public List<District> GetDistrictByDivOrStateID(int divisionOrStateID)
        {
            try
            {
                OiiOBookDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<District> divisionOrStateList = new List<District>();
                divisionOrStateList = dbContext.Districts.Where(d => d.DivisionOrStateID == divisionOrStateID && d.IsRemoved == false).ToList();
                dbContext.Dispose();
                return divisionOrStateList;

            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }


        public object GetAllDistrictForListView()
        {
            try
            {
                OiiOBookDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();

                var districtList = from distict in dbContext.Districts
                                   join country in dbContext.Countries on distict.CountryID equals country.IID
                                   join divisionOrState in dbContext.DivisionOrStates on distict.DivisionOrStateID equals divisionOrState.IID
                                   where (country.IsRemoved == false && divisionOrState.IsRemoved == false && distict.IsRemoved == false) 
                                   select new { distict.IID, distict.Code, distict.Name, DivisionOrState = divisionOrState.Name, CountryName = country.Name }; //divisionOrState.Name

                return districtList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        //public List<District> GetDistrictByName(string name)
        //{
        //    try
        //    {
        //        OiiOBookDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
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
                OiiOBookDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<District> districtList = new List<District>();
                districtList = dbContext.Districts.Where(d => d.IsRemoved == false).ToList();
                dbContext.Dispose();
                return districtList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public bool IsDistrictCodeExists(string districtCode, int divOrStateID)
        {
            try
            {
                OiiOBookDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<District> districtCodeList = new List<District>();
                districtCodeList = dbContext.Districts.Where(d => d.IsRemoved == false && d.Code.Contains(districtCode) && d.DivisionOrStateID==divOrStateID).ToList();
                dbContext.Dispose();
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
                OiiOBookDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<District> districtCodeList = new List<District>();
                districtCodeList = dbContext.Districts.Where(d => d.IsRemoved == false && d.Code.Contains(code) && d.IID!=id && d.DivisionOrStateID==divOrStateID).ToList();
                dbContext.Dispose();
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
                OiiOBookDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<District> districtNameList = new List<District>();
                districtNameList = dbContext.Districts.Where(d => d.IsRemoved == false && d.Name==districtName && d.DivisionOrStateID==divOrStateID).ToList();
                dbContext.Dispose();
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
                OiiOBookDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<District> districtCodeList = new List<District>();
                districtCodeList = dbContext.Districts.Where(d => d.IsRemoved == false && d.Name.Contains(name) && d.IID != id && d.DivisionOrStateID==divOrStateID).ToList();
                dbContext.Dispose();
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
                OiiOBookDCDataContext msDC = DatabaseHelper.GetDataModelDataContext();

                District objDistrict = msDC.Districts.Single(d => d.IID == district.IID);
                DatabaseHelper.Update<District>(msDC, district, objDistrict);

                msDC.Dispose();
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
                OiiOBookDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<District> districtCodeList = new List<District>();
                districtCodeList = dbContext.Districts.Where(d => d.IsRemoved == false && d.Code==code).ToList();
                dbContext.Dispose();
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
                OiiOBookDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<District> districtNameList = new List<District>();
                districtNameList = dbContext.Districts.Where(d => d.IsRemoved == false && d.Code==code && d.IID != id).ToList();
                dbContext.Dispose();
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
                OiiOBookDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                District district = new District();
                district = dbContext.Districts.Single(d => d.IID == disID && d.IsRemoved == false);

                dbContext.Dispose();
                return district;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public object GetDistrictByCountryNDivisionID(string districtName, int countryID, int divOrStateID)
        {
            try
            {
                OiiOBookDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                var divisionList = from dis in dbContext.Districts
                                   where dis.IsRemoved == false && dis.CountryID == countryID && dis.DivisionOrStateID==divOrStateID /*&& div.Name.StartsWith(divOrStateName)*/
                                   select new { dis.IID, dis.Name };
                var list = divisionList.ToList();

                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

  
    }
}
