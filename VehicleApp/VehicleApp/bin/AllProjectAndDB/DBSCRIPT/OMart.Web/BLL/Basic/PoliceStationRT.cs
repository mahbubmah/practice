using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Basic
{
    public class PoliceStationRT : IDisposable
    {
        private readonly OiiOMartDBDataContext dbContext;
        public PoliceStationRT()
        {
            dbContext = DatabaseHelper.GetDataModelDataContext();
        }

        public List<PoliceStation> GetPoliceStaionByName(string policeStationName)
        {
            try
            {
               
                List<PoliceStation> PoliceStationList = new List<PoliceStation>();
                PoliceStationList = dbContext.PoliceStations.Where(p => p.Name.Contains(policeStationName)).ToList();

                //dbContext.Dispose();
                return PoliceStationList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }


        public bool IsPoliceStationCodeExists(string policeStationCode, int districtID)
        {
            try
            {
               
                List<PoliceStation> policeStationCodeList = new List<PoliceStation>();
                policeStationCodeList = dbContext.PoliceStations.Where(d => d.DistrictID == districtID && d.Code == policeStationCode).ToList();
                //dbContext.Dispose();
                if (policeStationCodeList.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public bool IsPoliceStaionCodeExistInOtherRows(long id, string code, long districtID)
        {
            try
            {
                
                List<PoliceStation> policeStationCodeList = new List<PoliceStation>();
                policeStationCodeList = dbContext.PoliceStations.Where(d => d.IID != id && d.Code == code && d.DistrictID == districtID).ToList();
                //dbContext.Dispose();
                if (policeStationCodeList.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public bool IsPoliceStaionNameExistInOtherRows(long id, string name, long districtID)
        {
            try
            {
               
                List<PoliceStation> policeStationNameList = new List<PoliceStation>();
                policeStationNameList = dbContext.PoliceStations.Where(d => d.IID != id && d.Name == name && d.DistrictID == districtID).ToList();
                //dbContext.Dispose();
                if (policeStationNameList.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public bool IsPoliceStationNameExists(string policeStationName, int districtID)
        {
            try
            {
               
                List<PoliceStation> policeStationNameList = new List<PoliceStation>();
                policeStationNameList = dbContext.PoliceStations.Where(d => d.DistrictID == districtID && d.Name == policeStationName).ToList();
                //dbContext.Dispose();
                if (policeStationNameList.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public bool IsPoliceStationExistsInDistrict(int districtID)
        {
            try
            {
                
                List<PoliceStation> policeStationNameList = new List<PoliceStation>();
                policeStationNameList = dbContext.PoliceStations.Where(p => p.DistrictID == districtID).ToList();
                //dbContext.Dispose();
                if (policeStationNameList.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }


        public PoliceStation GetPoliceStaionByID(long policeStaionID)
        {
            try
            {
             
                PoliceStation policeStation = new PoliceStation();
                policeStation = dbContext.PoliceStations.Single(d => d.IID == policeStaionID);

               // dbContext.Dispose();
                return policeStation;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }

        }

        public PoliceStation GetPoliceStationByID(long? polceStatnID)
        {
            try
            {
               
                PoliceStation policeStation = new PoliceStation();
                policeStation = dbContext.PoliceStations.Single(d => d.IID == polceStatnID);

               // dbContext.Dispose();
                return policeStation;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }

        }

        public object GetAllPoliceStationForListView()
        {
            try
            {

                DivisionOrState divisionOrState = new DivisionOrState();
                var policeStationList = dbContext.SpGetAllPoliceStation();
                return policeStationList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

     
        public void AddPoliceStaion(PoliceStation policeStaion)
        {
            try
            {
                DatabaseHelper.Insert<PoliceStation>(policeStaion);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public void UpdatePoliceStaion(PoliceStation policeStation)
        {
            try
            {
               
                PoliceStation policeSta = dbContext.PoliceStations.Single(d => d.IID == policeStation.IID);
                DatabaseHelper.Update<PoliceStation>(dbContext, policeStation, policeSta);

                //dbContext.Dispose();
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        
        public bool IsPoliceStationCodeExists(string code)
        {
            try
            {
              
                List<PoliceStation> policeStationList = new List<PoliceStation>();
                policeStationList = dbContext.PoliceStations.Where(d => d.Code.Contains(code)).ToList();
                //dbContext.Dispose();
                if (policeStationList.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public bool IsPoliceStationCodeExistsInOtherRows(long id, string code)
        {
            try
            {
               
                List<PoliceStation> policeStationNameList = new List<PoliceStation>();
                policeStationNameList = dbContext.PoliceStations.Where(d => d.IID != id && d.Code == code).ToList();
                //dbContext.Dispose();
                if (policeStationNameList.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }

        }
        

        public List<PoliceStation> GetPoliceStationByCountryIdAndDistrictId(int countryId, long districtId)
        {
            try
            {
               
                var policeStaionList =
                    dbContext.PoliceStations.Where(
                        ps => ps.CountryID == countryId && ps.DistrictID == districtId)
                        .ToList();
                return policeStaionList;
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
