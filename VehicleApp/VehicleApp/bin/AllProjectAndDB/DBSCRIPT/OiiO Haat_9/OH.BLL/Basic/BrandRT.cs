using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OH.DAL;

namespace OH.BLL.Basic
{
    public class BrandRT : IDisposable
    {
        OiiOHaatDCDataContext _dbContext = null;
        public BrandRT()
        {
            _dbContext = DatabaseHelper.GetDataModelDataContext();
        }
        #region IDisposable Members

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members

        public List<Brand> GetBrandNameForSearch(string brandName)
        {
            try
            {
                var brandList = _dbContext.Brands.Where(x => x.Name.StartsWith(brandName) && x.IsRemoved == false).ToList();
                List<Brand> brList = new List<Brand>(brandList);

                return brList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public object GetAllBrandByName(string brandName)
        {
            try
            {
                var brandColl = from brandDB in _dbContext.Brands 
                                //where brandDB.IsRemoved==false
                                where brandDB.Name.Contains(brandName)
                                select new { brandDB.IID, brandDB.Name };
                return brandColl;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public object GetBrandForListView()
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                var brands = from brand in dbContext.Brands
                             join country in dbContext.Countries on brand.Origin equals country.IID
                             where brand.IsRemoved==false && country.IsRemoved==false
                             select new { brand.IID, brand.Name, Origin = country.Name, Year = brand.EastblishYear };
                return brands;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }          
        }

        public bool IsBrandNameExists(string name, int countryID)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<Brand> brandList = new List<Brand>();
                brandList = dbContext.Brands.Where(d => d.IsRemoved == false && d.Name==name && d.Origin == countryID).ToList();
                dbContext.Dispose();
                if (brandList.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public Brand GetBrandByID(long brandID)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                Brand brand = new Brand();
                brand = dbContext.Brands.Single(d => d.IID == brandID && d.IsRemoved == false);
                dbContext.Dispose();
                return brand;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public bool IsBrandNameExistInOterRows(long id, string brandName, int? countryID)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<Brand> brandList = new List<Brand>();
                brandList = dbContext.Brands.Where(d => d.IsRemoved == false && d.Name == brandName && d.IID != id && d.Origin == countryID).ToList();
                dbContext.Dispose();
                if (brandList.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public void AddBrand(Brand brand)
        {
            try
            {
                DatabaseHelper.Insert<Brand>(brand);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public void UpdateBrand(Brand brand)
        {
            try
            {
                OiiOHaatDCDataContext msDC = DatabaseHelper.GetDataModelDataContext();
                Brand brandNew = msDC.Brands.Single(d => d.IID == brand.IID);
                DatabaseHelper.Update<Brand>(msDC, brand, brandNew);

                msDC.Dispose();
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

    }
}
