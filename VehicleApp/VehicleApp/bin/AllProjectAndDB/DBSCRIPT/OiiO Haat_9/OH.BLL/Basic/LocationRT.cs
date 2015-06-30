using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OH.DAL;
using OH.Utilities;

namespace OH.BLL.Basic
{
    public class LocationRT : IDisposable
    {




        public void AddLocation(Location location)
        {
            try
            {
                DatabaseHelper.Insert<Location>(location);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }


        public object GetDistrictForSearch(string districtName, string countryId)
        {
            try
            {
                string district = string.Empty;
                int? countryIID;

                if (districtName != string.Empty || districtName != "") { district = districtName; }
                else { district = null; }
                if (countryId != string.Empty || countryId != "") { countryIID = Convert.ToInt32(countryId); }
                else { countryIID = null; }

                OiiOHaatDCDataContext db = DatabaseHelper.GetDataModelDataContext();
                var retDistrict = (from lc in db.SP_GetDistrictForSearch(district,countryIID)
                                  select new
                                  {
                                      lc.DistrictID,
                                      lc.DistrictName,
                                      fullSearchDistrict = lc.DistrictName
                                  }).Take(10);

                //db.Dispose();
                return retDistrict;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }


        //for search police staion
        public object GetPoliceStationForSearch(string policeStationName, string districtId, string countryId)
        {
            try
            {
                string policeStation = string.Empty;
                Int64? districtIID;
                int? countryIID;

                if (policeStationName != string.Empty || policeStationName != "") { policeStation = policeStationName; }
                else { policeStation = null; }
                if (districtId != string.Empty || districtId != "") { districtIID = Convert.ToInt64(districtId); }
                else { districtIID = null; }
                if (countryId != string.Empty || countryId != "") { countryIID = Convert.ToInt32(countryId); }
                else { countryIID = null; }

                OiiOHaatDCDataContext db = DatabaseHelper.GetDataModelDataContext();
                var retPoliceStation = (from lc in db.SP_GetPoliceStaionForSearch(policeStation, districtIID, countryIID)
                                  select new
                                  {
                                      lc.DistrictID,
                                      lc.DistrictName,
                                      lc.PoliceStationID,
                                      lc.PoliceStationName,
                                      fullSearchPoliceStation = (lc.DistrictName + ", " + lc.PoliceStationName)
                                  }).Take(10);

                //db.Dispose();
                return retPoliceStation;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
            
        }

        //for search location
        public object GetLocationForSearch(string locationName, string policeStationId, string districtId, string countryId)
        {
            try
            {
                string location = string.Empty;
                Int64? policeStationIID;
                Int64? districtIID;
                int? countryIID;

                if (locationName != string.Empty || locationName != "") { location = locationName; }
                else { location = null; }
                if (policeStationId != string.Empty || policeStationId != "") { policeStationIID = Convert.ToInt64(policeStationId); }
                else { policeStationIID = null; }
                if (districtId != string.Empty || districtId != "") { districtIID = Convert.ToInt64(districtId); }
                else { districtIID = null; }
                if (countryId != string.Empty || countryId != "") { countryIID = Convert.ToInt32(countryId); }
                else { countryIID = null; }

                OiiOHaatDCDataContext db = DatabaseHelper.GetDataModelDataContext();
                var retLocation = (from lc in db.SP_GetLocationForSearch(location,policeStationIID,districtIID,countryIID)
                                  select new
                                  {
                                      lc.LocationID,
                                      lc.DistrictID,
                                      lc.DistrictName,
                                      lc.PoliceStationID,
                                      lc.PoliceStationName,
                                      lc.CurrentLocationName,
                                      fullSearchLocation = (lc.DistrictName + ", " + lc.PoliceStationName + ", " + lc.CurrentLocationName)
                                  }).Take(10);
                //db.Dispose();
                return retLocation;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }



        public object GetLocationInfoByIID(long locationId)
        {
            try
            {
                OiiOHaatDCDataContext db = DatabaseHelper.GetDataModelDataContext();

                var location = db.Locations.SingleOrDefault(loc => loc.IID == locationId);
                var fullLocation = (from ps in db.PoliceStations
                                   join dis in db.Districts on ps.DistrictID equals dis.IID
                                   where ps.IID == location.PoliceStationID
                                   select new
                                   {
                                       LocationName=location.CurrentLocation,
                                       policeStationIID = ps.IID,
                                       districtIID = dis.IID,
                                       policeStationName = ps.Name,
                                       districtName = dis.Name
                                   }).SingleOrDefault();
                return fullLocation;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }

        }

        public bool GetLocationInfoByIID(long locationID, ref long districtID, ref string districtName, ref long policeStationID, ref string policeStationName, ref string locationName)
        {
            bool isSuccess = false;
            try
            {
                OiiOHaatDCDataContext db = DatabaseHelper.GetDataModelDataContext();

                var location = db.Locations.SingleOrDefault(loc => loc.IID == locationID);
                var fullLocation = (from ps in db.PoliceStations
                                    join dis in db.Districts on ps.DistrictID equals dis.IID
                                    where ps.IID == location.PoliceStationID
                                    select new
                                    {
                                        DistrictName = dis.Name,
                                        DistrictIID = dis.IID,
                                        PoliceStationIID = ps.IID,
                                        PoliceStationName = ps.Name,
                                        LocationName = location.CurrentLocation
                                    }).ToList();

                foreach (var varItem in fullLocation)
                {
                    districtID = varItem.DistrictIID;
                    districtName = varItem.DistrictName;
                    policeStationID = varItem.PoliceStationIID;
                    policeStationName = varItem.PoliceStationName;
                    locationName = varItem.LocationName;
                    isSuccess = true;
                }              
            }
            catch (Exception ex)
            {
                isSuccess = false;
                throw new Exception(ex.Message, ex);
            }
            return isSuccess;
        }

        #region IDisposable Members

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members       
    
        public Location GetLocationByIID(long locationId)
        {
            try
            {
                OiiOHaatDCDataContext db = DatabaseHelper.GetDataModelDataContext();
                var location = db.Locations.SingleOrDefault(loc => loc.IID == locationId);
                return location;
            }
            catch (Exception exception)
            {
                
                throw new Exception(exception.Message,exception);
            }
        }
    }
}
