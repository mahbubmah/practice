using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Services;
using System.Web.Services;
using Microsoft.Ajax.Utilities;
using OB.BLL.Basic;
using OB.DAL;
using OB.Web.BookAdmin;

namespace OB.Web
{
    /// <summary>
    /// Summary description for HRWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class HRWebService : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<BooKCategory> GetAllCategoryForSearch(string catName)
        {

            List<BooKCategory> list = null;
            try
            {

                list = new BookCategoryRT().GetAllSearchedBookCategory(catName);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                if (list != null && list.Count > 0)
                {
                    list = list.Take(25).ToList();
                }
            }
            return list;
        }

       

           

      
     

        //[WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //public object GetCountryForSearchInPostOffice(string conName)
        //{
        //    //List<Country> countryList = new List<Country>();
        //    // CountryRT conRT = new CountryRT();
        //    try
        //    {
        //        return new CountryRT().GetCountryNameForPostOffice(conName);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex);
        //    }
        //    finally
        //    {
        //        //if (countryList != null && countryList.Count > 0)
        //        //{
        //        //    countryList = countryList.Take(25).ToList();
        //        //}
        //    }
        //}

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public object GetCountryForSearch(string conName)
        {
            //List<Country> countryList = new List<Country>();
            // CountryRT conRT = new CountryRT();
            try
            {
               return new CountryRT().GetCountryName(conName);
            }
            catch (Exception ex)
            {
                 throw new Exception(ex.Message, ex); 
            }
            finally
            {
                //if (countryList != null && countryList.Count > 0)
                //{
                //    countryList = countryList.Take(25).ToList();
                //}
            }            
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public object GetDivOrStateByCountryIdSearch(string diviOrStateName, int countryID)
        {
            try
            {
                return new DivisionOrStateRT().GetDivisionForCountryID(diviOrStateName, countryID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public object GetDistrictByCountryDivOrStateID(string districtName, int countryID, int divOrStateID)
        {
            try
            {
                return new DistrictRT().GetDistrictByCountryNDivisionID(districtName, countryID, divOrStateID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public object GetpoliceStatioByDistrictByCountryDivOrStateID(string policeStationName, int districtID, int divOrStateID, int countryID)
        {
            try
            {
                return new PoliceStationRT().GetPoliceStationByCountryDistrictNDivisionID(policeStationName, districtID, divOrStateID, countryID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public object GetCountryByAlphabetForSearch(string conName)
        {
            //List<Country> countryList = new List<Country>();
            // CountryRT conRT = new CountryRT();
            try
            {
                return new CountryRT().GetCountryNameBYAlphabet(conName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                //if (countryList != null && countryList.Count > 0)
                //{
                //    countryList = countryList.Take(25).ToList();
                //}
            }
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public object GetAdGiverForSearch(string AdgiverName)
        {
            try
            {
                return new AdGiverRT().GetAdgiverNameBYAlphabet(AdgiverName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

      
    }
}
