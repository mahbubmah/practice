using System;
using System.Collections.Generic;
using System.Linq;
using Tula.DAL;

namespace Tula.BLL.Basic
{
    public class AdGiverRt : IDisposable
    {
       
         private readonly DBConnectionString _db;

         public AdGiverRt()
        {
             _db = DatabaseHelper.GetDataModelDataContext();
        }
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
              
                var adGiverList = _db.AdGivers.Where(adGiver => adGiver.EmailID.StartsWith(adGiverName)).ToList();
                return adGiverList;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        public AdGiver GetAdGiverIdByEmail(string email)
        {
            try
            {
               
                var adGiver = _db.AdGivers.SingleOrDefault(ag => ag.EmailID == email);
                _db.Dispose();
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

        public object GetAdgiverNameByAlphabet(string adgiverName)
        {
            try
            {

                var nameList = from adGvr in _db.AdGivers
                               where adGvr.Name.StartsWith(adgiverName)
                               select new { adGvr.IID, adGvr.Name };
                var list = nameList.ToList();
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }



        public List<GetSearchResultForRegisteredUser_Result> GetRegisteredUserListView(string userID, DateTime? SD, DateTime? ED)
        {
            var fm = _db.GetSearchResultForRegisteredUser(userID, SD, ED,null).ToList();
            return fm;
        }

        public AdGiver GetAdGiverByIid(long adgiverId)
        {
            try
            {
                var adGiver = _db.AdGivers.SingleOrDefault(x => x.IID == adgiverId);

                return adGiver;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public int GetUserGroupByAdGiverId(int adGiverClientTypeId)
        {
            try
            {
                int groupId = 0;
            
                Int64 userGroupId = (from userGroup in _db.UserGroups
                                     join adGiver in _db.AdGivers
                                     on userGroup.TypeID equals adGiver.ClientTypeID
                                     select userGroup.IID).FirstOrDefault();
                groupId = Convert.ToInt32(userGroupId);
                return groupId;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

   

        public object UpdateadGiverAccNamePhn(string userEmailId, string Name, string PhoneNo1)
        {   try
            {
            var adGiveracc = _db.sp_UpdateAccNamePhone(userEmailId, Name, PhoneNo1);
            return adGiveracc;
            }
        catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public UserInfo GetPasswordIdByEmail(string userEmailId)
        {
            try
            {
             
                UserInfo nameList = (from adGvr in _db.AdGivers
                               join userinfo in _db.UserInfoes on adGvr.IID equals userinfo.AdGiverID
                               where adGvr.EmailID == userEmailId 
                               select userinfo ).FirstOrDefault();
                //var list = nameList.;
                return nameList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
        
        public List<sp_GetAdgiverFnameLnamePhn_Result> GetAdGiverNamePhnByEmail(string userEmailId)
        {
            try
            {
                var adGiveraccNamePhn = _db.sp_GetAdgiverFnameLnamePhn(userEmailId).ToList();
                return adGiveraccNamePhn;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
    }
}
