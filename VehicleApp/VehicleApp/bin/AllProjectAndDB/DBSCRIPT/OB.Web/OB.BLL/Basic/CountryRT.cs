using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OB.DAL;


namespace OB.BLL.Basic
{
    public class CountryRT : IDisposable
    {

        public CountryRT()
        {
        }

        #region Get methods

        public Country GetCountryByIID(int countryID)
        {
            try
            {
                OiiOBookDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                Country country = new Country();
                country = dbContext.Countries.Single(d => d.IID == countryID && d.IsRemoved == false);
                dbContext.Dispose();
                return country;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public List<Country> GetCountryAll()
        {
            try
            {
                OiiOBookDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<Country> countryList = new List<Country>();
                countryList = dbContext.Countries.Where(d => d.IsRemoved == false).ToList();
                dbContext.Dispose();
                return countryList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }


        public List<Country> GetAllCountryForListView()
        {
            try
            {
                OiiOBookDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();

                List<Country> Countries = dbContext.Countries.Where(C => C.IsRemoved == false).ToList();
                //dbContext.Dispose();
                return Countries;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public object GetCountryName(string conName)
        {
            try
            {
                OiiOBookDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                //List<Country> nameList = new List<Country>();
                //nameList = dbContext.Countries.Where(c => c.IsRemoved == false && c.Name.StartsWith(conName)).ToList();
                ////dbContext.Dispose();
                var Countries = from countryDB in dbContext.Countries select new { countryDB.IID, countryDB.Name };
                return Countries;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
        /// <summary>
        /// ////Asiful Islam
        /// </summary>23.02.15
        /// <param name="conName"></param>
        /// <returns></returns>
        public object GetCountryNameBYAlphabet(string conName)
        {
            try
            {
                OiiOBookDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                var nameList = from con in dbContext.Countries
                               where con.IsRemoved == false && con.Name.StartsWith(conName)
                               select new { con.IID, con.Name };
                //dbContext.Dispose();
                var list = nameList.ToList();
                return list;
                //var Countries = from countryDB in dbContext.Countries select new { countryDB.IID, countryDB.Name };
                //return Countries;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
        public bool IsCountryCodeExists(string countryCode)
        {
            try
            {
                OiiOBookDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<Country> countryCodeList = new List<Country>();
                countryCodeList = dbContext.Countries.Where(c => c.IsRemoved == false && c.Code.Contains(countryCode)).ToList();
                dbContext.Dispose();
                if (countryCodeList.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public bool IsCountryCodeExistOtherRows(int id, string code)
        {
            try
            {
                OiiOBookDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<Country> countryCodeList = new List<Country>();
                countryCodeList = dbContext.Countries.Where(c => c.IsRemoved == false && c.Code.Contains(code) && c.IID !=id).ToList();
                dbContext.Dispose();
                if (countryCodeList.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
 
        }


        public bool IsCountryNameExists(string countryName)
        {
            try
            {
                OiiOBookDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<Country> countryNameList = new List<Country>();
                countryNameList = dbContext.Countries.Where(c => c.IsRemoved == false && c.Name.Contains(countryName)).ToList();
                dbContext.Dispose();
                if (countryNameList.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }


        public bool IsCountryNameExistOtherRows( int id, string name)
        {
            try
            {
                OiiOBookDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<Country> countryCodeList = new List<Country>();
                countryCodeList = dbContext.Countries.Where(c => c.IsRemoved == false && c.Name.Contains(name) && c.IID != id).ToList();
                dbContext.Dispose();
                if (countryCodeList.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public void AddCountry(Country contry)
        {
            try
            {
                DatabaseHelper.Insert<Country>(contry);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }


        public void UpdateCountry(Country country)
        {
            try
            {
                // OiiOHRDataModelDataContext msDC = new OiiOHRDataModelDataContext();
                OiiOBookDCDataContext msDC = DatabaseHelper.GetDataModelDataContext();

                Country countryNew = msDC.Countries.Single(d => d.IID == country.IID);
                DatabaseHelper.Update<Country>(msDC, country, countryNew);

                msDC.Dispose();
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        #endregion Get methods

        #region IDisposable Members

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members


        //public void GetCountryNameByID(int contryID)
        //{
            
        //}
    }
}
