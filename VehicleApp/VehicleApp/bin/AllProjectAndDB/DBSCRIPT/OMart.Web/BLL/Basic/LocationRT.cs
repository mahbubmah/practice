using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Basic
{
    public class LocationRT : IDisposable
    {
        private readonly OiiOMartDBDataContext _OiiOMartDBDataContext;
        public LocationRT()
        {
            _OiiOMartDBDataContext = DatabaseHelper.GetDataModelDataContext();
        }





        #region Get Methods


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


                //var retDistrict = (from lc in _OiiOMartDBDataContext.SP_GetDistrictForSearch(district, countryIID)
                //                   select new
                //                   {
                //                       lc.DistrictID,
                //                       lc.DistrictName,
                //                       fullSearchDistrict = lc.DistrictName
                //                   }).Take(10);

                ////db.Dispose();
                //return retDistrict;
                return null;
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


                //var retPoliceStation = (from lc in db.SP_GetPoliceStaionForSearch(policeStation, districtIID, countryIID)
                //                        select new
                //                        {
                //                            lc.DistrictID,
                //                            lc.DistrictName,
                //                            lc.PoliceStationID,
                //                            lc.PoliceStationName,
                //                            fullSearchPoliceStation = (lc.DistrictName + ", " + lc.PoliceStationName)
                //                        }).Take(10);

                ////db.Dispose();
                //return retPoliceStation;
                return null;
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


                //var retLocation = (from lc in db.SP_GetLocationForSearch(location, policeStationIID, districtIID, countryIID)
                //                   select new
                //                   {
                //                       lc.LocationID,
                //                       lc.DistrictID,
                //                       lc.DistrictName,
                //                       lc.PoliceStationID,
                //                       lc.PoliceStationName,
                //                       lc.CurrentLocationName,
                //                       fullSearchLocation = (lc.DistrictName + ", " + lc.PoliceStationName + ", " + lc.CurrentLocationName)
                //                   }).Take(10);
                ////db.Dispose();
                //return retLocation;
                return null;
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


                var location = _OiiOMartDBDataContext.Locations.SingleOrDefault(loc => loc.IID == locationId);
                var fullLocation = (from ps in _OiiOMartDBDataContext.PoliceStations
                                    join dis in _OiiOMartDBDataContext.Districts on ps.DistrictID equals dis.IID
                                    where ps.IID == location.PoliceStationID
                                    select new
                                    {
                                        LocationName = location.CurrentLocation,
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


                var location = _OiiOMartDBDataContext.Locations.SingleOrDefault(loc => loc.IID == locationID);
                var fullLocation = (from ps in _OiiOMartDBDataContext.PoliceStations
                                    join dis in _OiiOMartDBDataContext.Districts on ps.DistrictID equals dis.IID
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

        public Location GetLocationByIID(long locationId)
        {
            try
            {

                var location = _OiiOMartDBDataContext.Locations.SingleOrDefault(loc => loc.IID == locationId);
                return location;
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message, exception);
            }
        }


        

        #endregion Get Methods



       


        #region IDisposable Members

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members





        public void UpdateLocation(Location location)
        {
            try
            {
                Location objLocation = _OiiOMartDBDataContext.Locations.Single(d => d.IID == location.IID);
                DatabaseHelper.Update<Location>(_OiiOMartDBDataContext, location, objLocation);
                _OiiOMartDBDataContext.Dispose();
            }
            catch (Exception ex){throw new Exception(ex.Message,ex);}
        }

        public object GetAllLocationForListView()
        {
            try
            {
                var locationList = _OiiOMartDBDataContext.SP_GetAllLocationForListView();
                
                return locationList;
            }
            catch (Exception ex)
            {
                
                throw new Exception();
            }
        }

        public void DeleteLocationByIID(long locId)
        {
            try
            {
                Location loc = _OiiOMartDBDataContext.Locations.SingleOrDefault(x => x.IID == locId);
                DatabaseHelper.Delete(_OiiOMartDBDataContext, loc);
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message,ex);
            }
        }



        public bool IsLocationAlradyExist(string locationName)
        {
            bool isLocationNameAlreadyExist = false;
            try
            {
                if (locationName != string.Empty || locationName != "")
                {
                    var loc = _OiiOMartDBDataContext.Locations.Where(lo => lo.CurrentLocation == locationName).ToList();
                    if(loc.Count > 0)
                    {
                        isLocationNameAlreadyExist = true;
                    }
                }
                return isLocationNameAlreadyExist;
            }
            catch (Exception exception)
            {
                
                throw new Exception(exception.Message,exception);
            }
        }

        public bool IsPostOfficeAlradyExist(long postOfficeid)
        {
            bool isPostOfficeAlreadyExist = false;
            try
            {
                    var loc = _OiiOMartDBDataContext.Locations.Where(lo => lo.PostOfficeID == postOfficeid && lo.CurrentLocation==null).ToList();
                    if (loc.Count > 0)
                    {
                        isPostOfficeAlreadyExist = true;
                    }
                return isPostOfficeAlreadyExist;
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message, exception);
            }
        }

        public bool IsPoliceStaionAlradyExist(long policeStaionId)
        {
            bool isPoliceStaionAlreadyExist = false;
            try
            {
                var loc = _OiiOMartDBDataContext.Locations.Where(lo =>lo.PoliceStationID==policeStaionId && lo.PostOfficeID == null && lo.CurrentLocation == null).ToList();
                if (loc.Count > 0)
                {
                    isPoliceStaionAlreadyExist = true;
                }
                return isPoliceStaionAlreadyExist;
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message, exception);
            }
        }
    }
}
