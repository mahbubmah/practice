using System;
using System.Collections.Generic;
using System.Linq;
using Tula.DAL;

namespace Tula.BLL.Basic
{
  public  class BannerRt : IDisposable
    {
        private readonly DBConnectionString _db;
        public BannerRt()
        {
            _db = DatabaseHelper.GetDataModelDataContext();
        }
        #region IDisposable Members
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members

        public void AddOtherContent(HomePageBanner tulaBanner)
        {
            try
            {
                DatabaseHelper.Insert<HomePageBanner>(tulaBanner);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public object GetOiiOBannerAllForListView()
        {
            try
            {
                var HaatBanner = from haatBanner in _db.HomePageBanners
                                
                                  select new { haatBanner.IID, haatBanner.Title, haatBanner.Note, haatBanner.Image,haatBanner.IsActive };

                return HaatBanner;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }



        public HomePageBanner GetOtherContentByIid(int treeBannerId)
        {
            try
            {   
                HomePageBanner bannerTree =_db.HomePageBanners.Single(d => d.IID == treeBannerId);
                return bannerTree;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public void Updateoiiohaatbanner(HomePageBanner oiiohaatbanner)
        {
            try
            {
              var treeBanner = _db.HomePageBanners.Single(d => d.IID == oiiohaatbanner.IID);
                DatabaseHelper.Update<HomePageBanner>(_db, oiiohaatbanner, treeBanner);
  
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public List<HomePageBanner> GetAllActiveBanners()
        {
          
            var objPicture = (from banner in _db.HomePageBanners
                              where banner.IsActive
                              select banner).ToList();
            return objPicture;
        }

        public object GetFirstActiveBanners()
        {
            var listdata = _db.HomePageBanners.FirstOrDefault(d=>d.IsActive);
            return listdata.Image;
        }
    }
}
