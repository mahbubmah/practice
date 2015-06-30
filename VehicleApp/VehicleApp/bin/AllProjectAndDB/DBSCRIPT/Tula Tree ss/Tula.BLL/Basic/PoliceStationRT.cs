using System;
using System.Collections.Generic;
using System.Linq;
using Tula.DAL;

namespace Tula.BLL.Basic
{
    public class PoliceStationRT : IDisposable
    {
        private DBConnectionString db=new DBConnectionString();
        public PoliceStationRT()
        {
        }

        public List<PoliceStation> GetPoliceStaionByName(string policeStationName)
        {
            try
            {
              
                List<PoliceStation> PoliceStationList = new List<PoliceStation>();
                PoliceStationList = db.PoliceStations.Where(p => p.Name.Contains(policeStationName)).ToList();

                db.Dispose();
                return PoliceStationList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }


        public bool IsPoliceStationCodeExists(string policeStationCode, int districtID)
        {
            try
            {
            
                List<PoliceStation> policeStationCodeList = new List<PoliceStation>();
                policeStationCodeList = db.PoliceStations.Where(d =>  d.DistrictID==districtID && d.Code==policeStationCode ).ToList();
                db.Dispose();
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
                policeStationCodeList = db.PoliceStations.Where(d => d.IID!=id && d.Code==code && d.DistrictID == districtID).ToList();
                db.Dispose();
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
                policeStationNameList = db.PoliceStations.Where(d =>  d.IID != id && d.Name==name && d.DistrictID == districtID).ToList();
                db.Dispose();
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
                policeStationNameList = db.PoliceStations.Where(d => d.DistrictID == districtID && d.Name == policeStationName).ToList();
                db.Dispose();
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
                policeStationNameList = db.PoliceStations.Where(p =>  p.DistrictID == districtID && p.IsRemoved==false).ToList();
                db.Dispose();
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
             
                PoliceStation policeStation = new PoliceStation();
                policeStation = db.PoliceStations.Single(d => d.IID == policeStaionID);

                db.Dispose();
                return policeStation;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }

        }

        public PoliceStation GetPoliceStationByID(long? polceStatnID)
        {
            try
            {
              
                PoliceStation policeStation = new PoliceStation();
                policeStation = db.PoliceStations.Single(d => d.IID == polceStatnID );

                db.Dispose();
                return policeStation;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }

        }



        public object GetAllPoliceStationForListView()
        {
            try
            {
              
                DivisionOrState divisionOrState = new DivisionOrState();
                var policeStationList = db.SpGetAllPoliceStation();
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
            
                PoliceStation policeSta = db.PoliceStations.Single(d => d.IID == policeStation.IID);
                DatabaseHelper.Update<PoliceStation>(db, policeStation, policeSta);

                db.Dispose();
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
             
                List<PoliceStation> policeStationList = new List<PoliceStation>();
                policeStationList = db.PoliceStations.Where(d => d.Code.Contains(code)).ToList();
                db.Dispose();
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
                policeStationNameList = db.PoliceStations.Where(d => d.IID != id && d.Code==code).ToList();
                db.Dispose();
                if (policeStationNameList.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
            
        }


        public List<SearchForPoliceStationbyCountryDivisionDistrict_Result> GetPoliceStationByCountryDistrictNDivisionID(string policeStationName, int districtID, int divOrStateID, int countryID)
        {
            try
            {
             
                var PStationSearch = db.SearchForPoliceStationbyCountryDivisionDistrict(policeStationName, districtID, divOrStateID, countryID).ToList();
                return PStationSearch;
            }

            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public List<PoliceStation> GetPoliceStationByCountryIdAndDistrictId(int countryId, long districtId)
        {
            try
            {
               
                return db.PoliceStations.Where(
                        ps => ps.CountryID == countryId && ps.DistrictID == districtId)
                        .ToList();
            }

            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public List<PoliceStation> GetAllPoliceStationsByDistrictId(long districtId)
        {
            try
            {
                return db.PoliceStations.Where(x => x.DistrictID == districtId && x.IsRemoved == false).ToList();
            }

            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
    }

}
