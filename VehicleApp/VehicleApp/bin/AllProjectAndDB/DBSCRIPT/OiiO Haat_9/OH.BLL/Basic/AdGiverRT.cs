using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OH.DAL;

namespace OH.BLL.Basic
{
    public class AdGiverRT : IDisposable
    {
       

        #region IDisposable Members

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members

        #region Get Methods

        public List<AdGiver> GetAdGiverForAdminMaterialSearch(string adGiverName)
        {
            try
            {
                OiiOHaatDCDataContext db = DatabaseHelper.GetDataModelDataContext();
                var adGiverList = db.AdGivers.Where(adGiver => adGiver.EmailID.StartsWith(adGiverName)).ToList();
                db.Dispose();
                return adGiverList;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        public AdGiver GetAdGiverIDByEmail(string email)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                var adGiver = dbContext.AdGivers.SingleOrDefault(ag => ag.EmailID == email);
                dbContext.Dispose();
                return adGiver;
            }

            catch (Exception ex) { throw new Exception(ex.Message, ex); }

        }

        public void AddAdGiver(AdGiver adGiver)
        {
            try
            {

                DatabaseHelper.Insert<AdGiver>(adGiver);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        #endregion Get Methods

        public object GetAdgiverNameBYAlphabet(string AdgiverName)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                var nameList = from adGvr in dbContext.AdGivers
                               where adGvr.IID != null && adGvr.Name.StartsWith(AdgiverName)
                               select new { adGvr.IID, adGvr.Name };
                var list = nameList.ToList();
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }



        public List<GetSearchResultForRegisteredUserResult> GetRegisteredUserListView(string userID, DateTime? SD, DateTime? ED)
        {
            OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();

            var Fm = dbContext.GetSearchResultForRegisteredUser(userID, SD, ED,null).ToList();
            return Fm;
        }

        public AdGiver GetAdGiverByIID(long AdgiverID)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();

                var adGiver = dbContext.AdGivers.SingleOrDefault(x => x.IID == AdgiverID);

                return adGiver;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public int GetUserGroupByAdGiverID(int adGiverClientTypeID)
        {
            try
            {
                int groupID = 0;
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                Int64 userGroupID = (from userGroup in dbContext.UserGroups
                                     join adGiver in dbContext.AdGivers
                                     on userGroup.TypeID equals adGiver.ClientTypeID
                                     select userGroup.IID).FirstOrDefault();
                groupID = Convert.ToInt32(userGroupID);
                dbContext.Dispose();
                return groupID;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        //public object UpdateadGiverAccNamePhn(string userEmailId)
        //{
        //    OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
        //    AdGiver adgiveracc = new AdGiver();
        //    var adGiveracc = dbContext.SpGetAllPoliceStation(userEmailId);
        //    return adGiveracc;
        //}

        public object UpdateadGiverAccNamePhn(string userEmailId, string Name, string PhoneNo1)
        {   try
            {
            OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
            AdGiver adgiveracc = new AdGiver();
            var adGiveracc = dbContext.sp_UpdateAccNamePhone(userEmailId, Name, PhoneNo1);
            return adGiveracc;
            }
        catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public UserInfo GetPasswordIDByEmail(string userEmailId)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                UserInfo nameList = (from adGvr in dbContext.AdGivers
                               join userinfo in dbContext.UserInfos on adGvr.IID equals userinfo.AdGiverID
                               where adGvr.EmailID == userEmailId 
                               select userinfo ).FirstOrDefault();
                //var list = nameList.;
                return nameList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }



        

        public List<sp_GetAdgiverFnameLnamePhnResult> GetAdGiverNamePhnByEmail(string userEmailId)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<AdGiver> adgiveraccNmaePhn = new List<AdGiver>();
                var adGiveraccNamePhn = dbContext.sp_GetAdgiverFnameLnamePhn(userEmailId).ToList();
                return adGiveraccNamePhn;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
    }
}
