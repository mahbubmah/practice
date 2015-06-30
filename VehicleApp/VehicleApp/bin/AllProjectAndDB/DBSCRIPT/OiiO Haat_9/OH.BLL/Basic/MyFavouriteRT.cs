using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OH.DAL;

namespace OH.BLL.Basic
{
    public class MyFavouriteRT : IDisposable
    {
         /// <summary>
        /// Created By : Asiful Islam
        /// </summary>
        public MyFavouriteRT()
        { }
        #region IDisposable Members

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members

        public void AddMYFvrt(MyFavourite myFvrt)
        {
            try
            {
                DatabaseHelper.Insert<MyFavourite>(myFvrt);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public MyFavourite GetEmailIDnMaterialID(string userEmailId, int MaterialID)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                var ID = dbContext.MyFavourites.SingleOrDefault(ag => ag.UserLoginID == userEmailId && ag.MaterialID == MaterialID);
                dbContext.Dispose();
                return ID;
            }

            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

      
        public object GetMyFavouriteAllForListView(string EmailID)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();

                var MyFavouritepList = from myFvrt in dbContext.MyFavourites
                                       join metarial in dbContext.Materials on myFvrt.MaterialID equals metarial.IID
                                       join category in dbContext.Categories on metarial.CategoryID equals category.IID
                                       where myFvrt.UserLoginID==EmailID
                                 select new { myFvrt.IID,name=metarial.TitleName,CatEgory=category.Name };
                

                //var activeDesignation = usrGrpList.Where(d => d.IsActive == true).ToList();
                //dbContext.Dispose();
                return MyFavouritepList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public void DeleteMyfabourite(int MyfabouriteID)
        {
             try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                dbContext.DeleteFromMyFvrt(MyfabouriteID);
            }

             catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public MyFavourite GetUrlFrmMyfvrt(int UrlID)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                var ID = dbContext.MyFavourites.SingleOrDefault(ag => ag.IID == UrlID);
                dbContext.Dispose();
                //var ID = from myFvrt in dbContext.MyFavourites
                //                       join metarial in dbContext.Materials on myFvrt.MaterialID equals metarial.IID
                //                       //join category in dbContext.Categories on metarial.CategoryID equals category.IID
                //         where myFvrt.IID == UrlID
                //                       select new { myFvrt.IID, matID = metarial.IID};

                return ID;
            }

            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public List<MyFavourite> GetEmailIDfrmMyfvrt(string userEmailId)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<MyFavourite> myFvrt = new List<MyFavourite>();
                 myFvrt = dbContext.MyFavourites.Where(ag => ag.UserLoginID == userEmailId).ToList();
                dbContext.Dispose();
                return myFvrt;
            }

            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
    }
}
