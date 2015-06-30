using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OH.DAL;

namespace OH.BLL.Basic
{
  public  class BannerRT : IDisposable
    {
        private readonly OiiOHaatDCDataContext _OiiOHaatDBDataContext;
        public BannerRT()
        {
            _OiiOHaatDBDataContext = DatabaseHelper.GetDataModelDataContext();
        }
        #region IDisposable Members
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members

        public void AddOtherContent(HomePageBanner OiioBanner)
        {
            try
            {
                DatabaseHelper.Insert<HomePageBanner>(OiioBanner);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public object GetOiiOBannerAllForListView()
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();

                var HaatBanner = from haatBanner in dbContext.HomePageBanners
                                  //where OtherContent.IsActive==true
                                  select new { haatBanner.IID, haatBanner.Title, haatBanner.Note, haatBanner.Image,haatBanner.IsActive };

                return HaatBanner;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }



        public HomePageBanner GetOtherContentByIID(int HaatBannerID)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                HomePageBanner BannerHaat = new HomePageBanner();
                BannerHaat = dbContext.HomePageBanners.Single(d => d.IID == HaatBannerID);
                dbContext.Dispose();
                return BannerHaat;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public void Updateoiiohaatbanner(HomePageBanner oiiohaatbanner)
        {
            try
            {
                OiiOHaatDCDataContext msDC = DatabaseHelper.GetDataModelDataContext();

                HomePageBanner OiiohaatBanner = msDC.HomePageBanners.Single(d => d.IID == oiiohaatbanner.IID);
                DatabaseHelper.Update<HomePageBanner>(msDC, oiiohaatbanner, OiiohaatBanner);
                msDC.Dispose();
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public List<HomePageBanner> GetAllActiveBanners()
        {
            OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
            var objPicture = (from banner in dbContext.HomePageBanners
                              where banner.IsActive == true
                              select banner).ToList();
            return objPicture;
        }

        public object GetFirstActiveBanners()
        {
            OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
            var listdata = dbContext.HomePageBanners.FirstOrDefault(d=>d.IsActive==true);
            return listdata.Image;
        }
    }
}
