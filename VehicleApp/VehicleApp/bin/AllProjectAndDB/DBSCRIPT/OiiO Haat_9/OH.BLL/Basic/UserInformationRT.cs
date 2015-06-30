using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OH.DAL;
using OH.Utilities;

namespace OH.BLL.Basic
{
    public class UserInformationRT : IDisposable
    {
        private readonly OiiOHaatDCDataContext _dbContext;
        private  UserInfo _userInfo;
        private UserGroup _userGroup;
        public UserInformationRT()
        {
            this._dbContext = DatabaseHelper.GetDataModelDataContext();
            this._userInfo = new UserInfo();
            this._userGroup = new UserGroup();
        }

        public UserInfo GetUserInformationID(Int64 IID)
        {
            try
            {
                _userInfo = (from ur in _dbContext.UserInfos
                             where ur.IID == IID && ur.IsRemoved == false
                             select ur).SingleOrDefault();
               // _dbContext.Dispose();
                return _userInfo;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public bool IsUserExists(string userName, string userPassword)
        {
            bool isExists = false;
            try
            {
                _userInfo = (from tr in _dbContext.UserInfos
                             where tr.LoginName.Trim().ToLower() == userName.Trim().ToLower() && tr.LoginPassword.Trim().ToLower() == userPassword.Trim().ToLower()
                             && tr.IsActiveUser == true && tr.IsRemoved == false
                             select tr).SingleOrDefault();
               // _dbContext.Dispose();

                if (_userInfo != null)
                {
                    isExists = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return isExists;

        }

        public UserInfo FindUser(string userName, string userPassword)
        {
            try
            {
                _userInfo = (from tr in _dbContext.UserInfos
                             where tr.LoginName.Trim().ToLower() == userName.Trim().ToLower() && tr.LoginPassword.Trim().ToLower() == userPassword.Trim().ToLower()
                             && tr.IsActiveUser == true && tr.IsRemoved == false
                             select tr).SingleOrDefault();
                //_dbContext.Dispose();
               
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message, ex); 
            }

            return _userInfo;
        }

        public UserInfo FindUserByUserName(string userName)
        {
            try
            {
                _userInfo = (from tr in _dbContext.UserInfos
                             where tr.LoginName.Trim().ToLower() == userName.Trim().ToLower()
                             && tr.IsActiveUser == true && tr.IsRemoved == false
                             select tr).SingleOrDefault();
                //_dbContext.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return _userInfo;
        }

        public UserGroup FindUserGroup(Int64 UserGroupID)
        {
            _userGroup = (from tr in _dbContext.UserGroups
                          where tr.IID == UserGroupID
                          select tr).SingleOrDefault();
            _dbContext.Dispose();

            return _userGroup;
        }

        public object GetUserInfoAllForListView()
        {
            try
            {
                var userInfoList = from user in _dbContext.UserInfos
                                         join gp in _dbContext.UserGroups on user.UserGroupID equals gp.IID
                                         where(user.IsRemoved == false)
                                         select new
                                         {
                                             user.IID,
                                             user.LoginName,
                                             groupName = gp.Name,
                                             LoginPassword =StringCipher.Decrypt(user.LoginPassword),
                                             user.IsActiveUser,
                                             user.IsRemoved
                                         };
                return userInfoList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }



        public List<UserInfo> GetUserInfoIDByGropIDAndLoginNameAndLoginPasswordAndUserID(int userID,int userGroupID, string loginName)
        {

            try
            {
                List<UserInfo> userInfoList = _dbContext.UserInfos.Where(user=>user.IID !=userID && user.UserGroupID == userGroupID && user.LoginName == loginName).ToList();
                return userInfoList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
            
        }

        public List<UserInfo> GetUserInfoIDByGropIDAndLoginNameAndLoginPassword(int userGroupID, string loginName)
        {

            try
            {
                List<UserInfo> userInfoList = _dbContext.UserInfos.Where(user => user.UserGroupID == userGroupID && user.LoginName == loginName).ToList();
                return userInfoList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }

        }

        public void AddUserInfo(UserInfo userInfo)
        {
            try
            {
                DatabaseHelper.Insert<UserInfo>(userInfo);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public UserInfo GetUserInfoByID(int userInfoID)
        {
           try
           {
               UserInfo userInfo = new UserInfo();
               userInfo = _dbContext.UserInfos.Single(d => d.IID == userInfoID);
               _dbContext.Dispose();
               return userInfo;
           }
           catch (Exception ex) { throw new Exception(ex.Message, ex); }
       }

        public void UpdateUserInfo(UserInfo userInfo)
        {
            try
            {
                UserInfo userInfoNew = _dbContext.UserInfos.Single(d => d.IID == userInfo.IID);
                DatabaseHelper.Update<UserInfo>(_dbContext, userInfo, userInfoNew);
                _dbContext.Dispose();
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public object UpdateUserInfoPassword(string userEmailId, string LoginPassword)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                UserInfo Userinfo = new UserInfo();
                var UserinfoPass = dbContext.sp_UpdateAccPassword(userEmailId, LoginPassword);
                return UserinfoPass;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public object UpdateUserDeactive(string userEmailId, string Comments, int? LeavingCausesID, bool? IsActiveUser)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                UserInfo Userinfo = new UserInfo();
                var UserinfoPass = dbContext.sp_UpdateUserDeactivation(userEmailId, Comments, LeavingCausesID,IsActiveUser);
                return UserinfoPass;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
    }
    }
