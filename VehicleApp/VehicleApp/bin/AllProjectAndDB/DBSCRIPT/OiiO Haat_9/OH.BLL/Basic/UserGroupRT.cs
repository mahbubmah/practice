using OH.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OH.BLL.Basic
{
    // Creates Modified BY Asiful Islam
    public class UserGroupRT : IDisposable
    {
        /// <summary>
        /// Created By : Asiful Islam
        /// </summary>
        public UserGroupRT()
        { }

        #region IDisposable Members

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members

        public UserGroup GetUserGroupByIID(Int32 userGroupID)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                UserGroup userGroup = new UserGroup();
                userGroup = dbContext.UserGroups.Single(d => d.IID == userGroupID);
                dbContext.Dispose();
                return userGroup;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public List<UserGroup> GetUserGrpName(string UserGrpName)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<UserGroup> UserGrpList = new List<UserGroup>();
                UserGrpList = dbContext.UserGroups.Where(d => d.IID != null && d.Name.Contains(UserGrpName)).ToList();

                dbContext.Dispose();
                return UserGrpList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public List<UserGroup> GetUserGroupAll()
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<UserGroup> userGrouptList = new List<UserGroup>();
                userGrouptList = dbContext.UserGroups.ToList();

                dbContext.Dispose();
                return userGrouptList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public void AddUserGrp(UserGroup userGrp)
        {
            try
            {
                DatabaseHelper.Insert<UserGroup>(userGrp);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public object GetUserGrpAllForListView()
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();

                var usrGrpList = from usergroup in dbContext.UserGroups
                                 //join country in dbContext.Countries on des.ApplicableCountryID equals country.IID
                                 select new { usergroup.IID, usergroup.Name, usergroup.TypeID,usergroup.IsRemoved };

                //var activeDesignation = usrGrpList.Where(d => d.IsActive == true).ToList();
                //dbContext.Dispose();
                return usrGrpList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public void UpdateUserGrp(UserGroup usergroup)
        {
            try
            {
                OiiOHaatDCDataContext msDC = DatabaseHelper.GetDataModelDataContext();

                UserGroup userGrp = msDC.UserGroups.Single(d => d.IID == usergroup.IID);
                DatabaseHelper.Update<UserGroup>(msDC, usergroup, userGrp);
                msDC.Dispose();
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public bool GetUserGrpRelationWithUserInfoTables(int UserInfoUserGrpID)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                bool UserGrpExist = false;
                var usrGrpListFromOtherTable = from usergroup in dbContext.UserGroups
                                               join userinfo in dbContext.UserInfos on usergroup.IID equals userinfo.UserGroupID
                                               //join UserWFprmit in dbContext.UserWFPermissions on usergroup.IID equals UserWFprmit.UserGroupID
                                               //where usergroup.IID == UserGrpID || userinfo.UserGroupID == UserGrpID || UserWFprmit.UserGroupID
                                               select new { usergroup.IID, userInfo = userinfo.UserGroupID };
                var CompareUserGrp = usrGrpListFromOtherTable.Where(d => d.userInfo == UserInfoUserGrpID).ToList();
                //var userGroupList = CompareUserGrp.ToList();
                if (CompareUserGrp.Count() > 0)
                {
                    UserGrpExist = true;
                    return UserGrpExist;
                }
                return UserGrpExist;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
        public bool GetUserGrpRelationWithUserWFPermissionTables(int UserWFPermissionUserGrpID)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                bool UserGrpExist = false;
                var usrGrpListFromOtherTable = from usergroup in dbContext.UserGroups
                                               //join userinfo in dbContext.UserInfos on usergroup.IID equals userinfo.UserGroupID
                                               join UserWFprmit in dbContext.UserWFPermissions on usergroup.IID equals UserWFprmit.UserGroupID
                                               //where usergroup.IID == UserGrpID || userinfo.UserGroupID == UserGrpID || UserWFprmit.UserGroupID
                                               select new { usergroup.IID, userWfpermission = UserWFprmit.UserGroupID };
                var CompareUserGrp = usrGrpListFromOtherTable.Where(d => d.userWfpermission == UserWFPermissionUserGrpID);
                //var userGroupList = CompareUserGrp.ToList();
                if (CompareUserGrp.Count() > 0)
                {
                    UserGrpExist = true;
                    return UserGrpExist;
                }
                return UserGrpExist;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public void DeleteUserGrp(long usergrpID)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                dbContext.DeleteFromUserGroup(usergrpID);
            }

            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
    }
}
