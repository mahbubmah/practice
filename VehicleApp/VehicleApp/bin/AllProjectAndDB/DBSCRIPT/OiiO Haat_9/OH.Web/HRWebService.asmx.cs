using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Services;
using System.Web.Services;
using Microsoft.Ajax.Utilities;
using OH.BLL.Basic;
using OH.DAL;
using OH.Web.ControlAdmin;

namespace OH.Web
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
        public object GetDistrictForSearch(string districtName, string countryID)
        {
            try
            {
                var districtList = new LocationRT().GetDistrictForSearch(districtName, countryID);
                return districtList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public object GetPoliceStationForSearch(string policeStationName, string districtId, string countryID)
        {
            try
            {
                var policeStationList = new LocationRT().GetPoliceStationForSearch(policeStationName, districtId, countryID);
                return policeStationList;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public object GetLocationForSearch(string locationName, string policeStationId, string districtId, string countryID)
        {
            try
            {
                var locationList = new LocationRT().GetLocationForSearch(locationName, policeStationId, districtId,countryID);
               return locationList;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public object GetAllAdGiverForAdminSearch(string adGiverName)
        {

            List<AdGiver> list = null;

            try
            {

                list = new AdGiverRT().GetAdGiverForAdminMaterialSearch(adGiverName);

                var adGiverList = (from adGiver in list
                                  select new { adGiver.IID, adGiver.EmailID}).ToList();

                return adGiverList;

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
            return null;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public object GetAllCategoryForSearch(string catName)
        {

            List<SP_CategoryTree_GetSearchedCategoryOrAllResult> list = null;
            
            try
            {
                
                list = new CategoryRT().GetAllSearchedCategory(catName);

                //var catList = from category in list
                //                select new {category.IID,category.Description,category.Name,category.ParentID};
                //catList = catList.ToList();
                return list;

            }
            catch (Exception ex)
            {
            }
            //finally
            //{
            //    if (list != null && list.Count > 0)
            //    {
            //        list = list.Take(25).ToList();
            //    }
            //}
            //return null;
            return list;
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public object GetAllBrandByName(string brandName)
        {
            try
            {
                return new BrandRT().GetAllBrandByName(brandName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public object GetAllModelNameForSearch(string modelName, string brandID)
        {
            long brID=0;
            List<GetModelNameForSearchResult> list = null;
            try
            {
                if (!brandID.IsNullOrWhiteSpace())
                {

                    brID = Convert.ToInt64(brandID);
                }
                list = new ModelRT().GetModelNameForSearch(modelName,brID);
                var modelList = from mod in list
                    select new { mod.IID,mod.Name};
                return modelList;
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
            return null;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public object GetAllModelByName(string modelName, int brandID)
        {
            try
            {
                return new ModelRT().GetAllModelByName(modelName, brandID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<Color> GetAllColorNameForSearch(string colorName)
        {

            List<Color> list = null;
            try
            {
                
                list = new ColorRT().GetColorNameForSearch(colorName);
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

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public object GetMaterialByAlphabetForSearch(string materialName)
        {
            try
            {
                return new MaterialRT().GetMaterialNameBYAlphabet(materialName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]

        public object GetAllBrandNameForSearch(string brandName)
        {
            
            try
            {

                return new BrandRT().GetAllBrandByName(brandName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }
    }
}
