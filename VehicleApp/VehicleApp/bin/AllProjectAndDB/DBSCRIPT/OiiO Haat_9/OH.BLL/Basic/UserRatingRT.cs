using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OH.DAL;
using OH.Utilities;
using System.ComponentModel;
namespace OH.BLL.Basic
{

    public class UserRatingRT : IDisposable
    {
        #region Get Methods


        public void AddUserRating( UserRating userRating)
        {
            try
            {
                DatabaseHelper.Insert<UserRating>(userRating);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public string GetRatingByIID(Int64 ratingIID)
        {
            try
            {     //DataTable dt = this.GetData("SELECT ISNULL(AVG(Rating), 0) AverageRating, COUNT(Rating) RatingCount FROM UserRatings");
                Int64 locID = 0;
                string fullstatus = null;
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                //var rating = dbContext.UserRatings.FirstOrDefault(x => x.IID == ratingIID);
              
                //var location = dbContext.SP_GetLocationForGoogleMap(locID).SingleOrDefault();
                //fullstatus = location.CurrentLocation + ',' + location.PoliceStationName + ',' + location.DistrictName + ',' + location.DivisionOrStateName + ',' + location.CountryName;

                dbContext.Dispose();
                return fullstatus;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public void UpdateMaterial(UserRating userRating)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                var matNew = dbContext.UserRatings.Single(mat => mat.IID == userRating.IID);
                DatabaseHelper.Update<UserRating>(dbContext, userRating, matNew);
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


    }
}
