using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OH.DAL;

namespace OH.BLL.Basic
{
    public class PoliceStationRT : IDisposable
    {
        public PoliceStationRT()
        {
        }

        public List<PoliceStation> GetPoliceStaionByName(string policeStationName)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<PoliceStation> PoliceStationList = new List<PoliceStation>();
                PoliceStationList = dbContext.PoliceStations.Where(p => p.Name.Contains(policeStationName)).ToList();

                dbContext.Dispose();
                return PoliceStationList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }


        public bool IsPoliceStationCodeExists(string policeStationCode, int districtID)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<PoliceStation> policeStationCodeList = new List<PoliceStation>();
                policeStationCodeList = dbContext.PoliceStations.Where(d =>  d.DistrictID==districtID && d.Code==policeStationCode ).ToList();
                dbContext.Dispose();
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
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<PoliceStation> policeStationCodeList = new List<PoliceStation>();
                policeStationCodeList = dbContext.PoliceStations.Where(d => d.IID!=id && d.Code==code && d.DistrictID == districtID).ToList();
                dbContext.Dispose();
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
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<PoliceStation> policeStationNameList = new List<PoliceStation>();
                policeStationNameList = dbContext.PoliceStations.Where(d =>  d.IID != id && d.Name==name && d.DistrictID == districtID).ToList();
                dbContext.Dispose();
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
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<PoliceStation> policeStationNameList = new List<PoliceStation>();
                policeStationNameList = dbContext.PoliceStations.Where(d => d.DistrictID == districtID && d.Name == policeStationName).ToList();
                dbContext.Dispose();
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
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<PoliceStation> policeStationNameList = new List<PoliceStation>();
                policeStationNameList = dbContext.PoliceStations.Where(p =>  p.DistrictID == districtID && p.IsRemoved==false).ToList();
                dbContext.Dispose();
                if (policeStationNameList.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }


        public PoliceStation GetPoliceStaionByID(int policeStaionID)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                PoliceStation policeStation = new PoliceStation();
                policeStation = dbContext.PoliceStations.Single(d => d.IID == policeStaionID);

                dbContext.Dispose();
                return policeStation;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }

        }

        public PoliceStation GetPoliceStationByID(long? polceStatnID)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                PoliceStation policeStation = new PoliceStation();
                policeStation = dbContext.PoliceStations.Single(d => d.IID == polceStatnID );

                dbContext.Dispose();
                return policeStation;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }

        }



        public object GetAllPoliceStationForListView()
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
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
                OiiOHaatDCDataContext msDC = DatabaseHelper.GetDataModelDataContext();
                PoliceStation policeSta = msDC.PoliceStations.Single(d => d.IID == policeStation.IID);
                DatabaseHelper.Update<PoliceStation>(msDC, policeStation, policeSta);

                msDC.Dispose();
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public bool IsPoliceStationCodeExists(string code)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<PoliceStation> policeStationList = new List<PoliceStation>();
                policeStationList = dbContext.PoliceStations.Where(d => d.Code.Contains(code)).ToList();
                dbContext.Dispose();
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
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<PoliceStation> policeStationNameList = new List<PoliceStation>();
                policeStationNameList = dbContext.PoliceStations.Where(d => d.IID != id && d.Code==code).ToList();
                dbContext.Dispose();
                if (policeStationNameList.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
            
        }


        public List<SearchForPoliceStationbyCountryDivisionDistrictResult> GetPoliceStationByCountryDistrictNDivisionID(string policeStationName, int districtID, int divOrStateID, int countryID)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                var PStationSearch = dbContext.SearchForPoliceStationbyCountryDivisionDistrict(policeStationName, districtID, divOrStateID, countryID).ToList();
                return PStationSearch;
            }

            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public List<PoliceStation> GetPoliceStationByCountryIdAndDistrictId(int countryId, long districtId)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                var policeStaionList =
                    dbContext.PoliceStations.Where(
                        ps => ps.CountryID == countryId && ps.DistrictID == districtId)
                        .ToList();
                return policeStaionList;
            }

            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
    }

}
