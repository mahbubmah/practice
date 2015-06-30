using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OH.DAL;

namespace OH.BLL.Basic
{
   public class UserPermissionRT:IDisposable
    {
       public UserPermissionRT()
       {
       
       }

       #region IDisposable Members

       public void Dispose()
       {
           GC.SuppressFinalize(this);
       }

       #endregion IDisposable Members

       public object GetUserPermissionAllForListView()
       {
           try
           {
               OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();

               var userPermissionList = from user in dbContext.UserWFPermissions
                                        join gp in dbContext.UserGroups on user.UserGroupID equals gp.IID
                                        join url in dbContext.UrlWFLists on user.UrlWFListID equals url.IID
                                        select new
                                        {
                                            user.IID,
                                            groupName=gp.Name,
                                            urlName=url.ModuleName,
                                        };
               return userPermissionList;
           }
           catch (Exception ex) { throw new Exception(ex.Message, ex); }
       }

       public List<UserWFPermission> GetUserPermissionByGropIDAndUrlID(Int32 userGroupID, Int32 urlListID)
       {
           try
           {
               OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
               List<UserWFPermission> userWFPermission = new List<UserWFPermission>();
               userWFPermission = dbContext.UserWFPermissions.Where(d => d.UserGroupID == userGroupID && d.UrlWFListID == urlListID).ToList();
               dbContext.Dispose();
               return userWFPermission;
           }
           catch (Exception ex) { throw new Exception(ex.Message, ex); }
       }

       public void AddUserPermission(UserWFPermission userWFPermission)
       {
           try
           {
               DatabaseHelper.Insert<UserWFPermission>(userWFPermission);
           }
           catch (Exception ex) { throw new Exception(ex.Message, ex); }
       }

       public void UpdateUserPermisssion(UserWFPermission userPermission)
       {
           try
           {
               OiiOHaatDCDataContext msDC = DatabaseHelper.GetDataModelDataContext();

               UserWFPermission userPermissionNew = msDC.UserWFPermissions.Single(d => d.IID == userPermission.IID);
               DatabaseHelper.Update<UserWFPermission>(msDC, userPermission, userPermissionNew);

               msDC.Dispose();
           }
           catch (Exception ex) { throw new Exception(ex.Message, ex); }
       }

       public UserWFPermission GetUserPermissionByID(Int32 userPermissionID)
       {
           try
           {
               UserWFPermission userPermission = new UserWFPermission();
               OiiOHaatDCDataContext DbContext = DatabaseHelper.GetDataModelDataContext();
               userPermission = DbContext.UserWFPermissions.Single(d => d.IID == userPermissionID);
               DbContext.Dispose();
               return userPermission;
           }
           catch (Exception ex) { throw new Exception(ex.Message, ex); }
       }
    }
}
