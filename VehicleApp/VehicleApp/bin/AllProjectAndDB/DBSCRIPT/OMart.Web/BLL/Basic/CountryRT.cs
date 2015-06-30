using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Basic
{
    public class CountryRT : IDisposable
    {

        private readonly OiiOMartDBDataContext _OiiOMartDBDataContext;
        public CountryRT()
        {
            _OiiOMartDBDataContext = DatabaseHelper.GetDataModelDataContext();
        }

        public void AddCountry(Country contry)
        {
            try
            {
                DatabaseHelper.Insert<Country>(contry);
            }
            catch (Exception ex) 
            { throw new Exception(ex.Message, ex); }
        }

        public void UpdateCountry(Country country)
        {
            try
            {
                Country countryNew = _OiiOMartDBDataContext.Countries.SingleOrDefault(d => d.IID == country.IID);

                DatabaseHelper.Update<Country>(_OiiOMartDBDataContext, country, countryNew);

                //_OiiOMartDBDataContext.Dispose();
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message, ex); 
            }
        }

        public Country GetCountryByIID(int countryID)
        {
            try
            {
                Country country = _OiiOMartDBDataContext.Countries.SingleOrDefault(d => d.IID == countryID);
                //_OiiOMartDBDataContext.Dispose();
                return country;
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message, ex);
            }
        }

        public List<Country> GetCountryName(string conName)
        {
            try
            {
                var Countries = (from tr in _OiiOMartDBDataContext.Countries.OrderBy(x => x.Name)
                                 where tr.Name.StartsWith(conName)
                                 select tr).ToList();
                return Countries;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<Country> GetAllCountries()
        {
            try
            {
                List<Country> Countries = _OiiOMartDBDataContext.Countries.OrderBy(x=>x.Name).ToList();
                return Countries;
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message, ex); 
            }
        }


        #region IDisposable Members
            public void Dispose()
            {
                GC.SuppressFinalize(this);
            }

        #endregion IDisposable Members

    }
}
