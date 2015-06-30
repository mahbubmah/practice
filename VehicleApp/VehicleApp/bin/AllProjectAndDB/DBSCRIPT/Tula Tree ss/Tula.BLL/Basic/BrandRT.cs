using System;
using System.Collections.Generic;
using System.Linq;
using Tula.DAL;

namespace Tula.BLL.Basic
{
    public class BrandRt : IDisposable
    {
       private readonly DBConnectionString _db = null;
        public BrandRt()
        {
            _db = DatabaseHelper.GetDataModelDataContext();
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
                var brandList = _db.Brands.Where(x => x.Name.StartsWith(brandName) && x.IsRemoved == false).ToList();
                var brList = new List<Brand>(brandList);

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
                var brandColl = from brandDb in _db.Brands 
                                where brandDb.Name.Contains(brandName)
                                select new { brandDb.IID, brandDb.Name };
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
                var brands = from brand in _db.Brands
                             join country in _db.Countries on brand.Origin equals country.IID
                             where brand.IsRemoved==false && country.IsRemoved==false
                             select new { brand.IID, brand.Name, Origin = country.Name, Year = brand.EastblishYear };
                return brands;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }          
        }

        public bool IsBrandNameExists(string name, int countryId)
        {
            try
            {
                var brandList = _db.Brands.Where(d => d.IsRemoved == false && d.Name==name && d.Origin == countryId).ToList();
                return brandList.Count > 0;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public Brand GetBrandById(long brandID)
        {
            try
            {
              
                var brand = _db.Brands.Single(d => d.IID == brandID && d.IsRemoved == false);
                _db.Dispose();
                return brand;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public bool IsBrandNameExistInOterRows(long id, string brandName, int? countryID)
        {
            try
            {
                var brandList  = _db.Brands.Where(d => d.IsRemoved == false && d.Name == brandName && d.IID != id && d.Origin == countryID).ToList();
                _db.Dispose();
                return brandList.Count > 0;
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
                var brandNew = _db.Brands.Single(d => d.IID == brand.IID);
                DatabaseHelper.Update<Brand>(_db, brand, brandNew);

            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

    }
}
