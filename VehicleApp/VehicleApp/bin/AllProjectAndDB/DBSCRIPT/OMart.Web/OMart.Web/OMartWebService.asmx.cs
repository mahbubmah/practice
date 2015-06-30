using BLL.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace OMart.Web
{
    /// <summary>
    /// Summary description for OMartWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class OMartWebService : System.Web.Services.WebService
    {

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
    }
}
