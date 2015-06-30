using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Linq;
using System.Reflection;

namespace Tula.DAL
{
    public class DatabaseHelper
    {
        //public DatabaseHelper()
        //{
        //}

        public const string _applicationID = "acf0ee5a-c10a-4fb0-bd2a-4063fe3edb24";
        public readonly static Guid _applicationGuid = new Guid(_applicationID);
        


        public static DBConnectionString GetDataModelDataContext()
        {
            try
            {
                var db = new DBConnectionString();
                return db;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public static void Update<T>(DBConnectionString db, T obj) where T : class
        {
            //using (var db = GetDashboardData())
            //{   
            //    db.GetTable<T>().Attach(obj);
            //    update(obj);
            //    db.SubmitChanges();
            //}

            //db.GetTable<T>().Attach(obj);

            obj = FillCommonFields<T>(obj, 2, false);
            //objDest = FillCommonFields<T>(objDest, (long)HttpContext.Current.Session[AdminConstants.AGENTID], false);
            //db.GetTable<T>().Attach(obj);

            db.SaveChanges();
        }

        public static void Update<T>(DBConnectionString db, T objSrc, T objDest) where T : class
        {
            //using (var db = GetDashboardData())
            //{   
            //    db.GetTable<T>().Attach(obj);
            //    update(obj);
            //    db.SubmitChanges();
            //}

            //db.GetTable<T>().Attach(obj);
            objDest = Clone<T>(objSrc, objDest);
            objDest = FillCommonFields<T>(objDest, 2, false);
            //objDest = FillCommonFields<T>(objDest, (long)HttpContext.Current.Session[AdminConstants.AGENTID], false);
            //db.GetTable<T>().Attach(obj);

            db.SaveChanges();
        }
        public static void Update<T>(DBConnectionString db, T obj, long currentuser, Action<T> update) where T : class
        {
            //using (var db = GetDashboardData())
            //{   
            //    db.GetTable<T>().Attach(obj);
            //    update(obj);
            //    db.SubmitChanges();
            //}

            //db.GetTable<T>().Attach(obj);
            obj = FillCommonFields<T>(obj, currentuser, false);
            //db.GetTable<T>().Attach(obj);
            update(obj);
            
            db.SaveChanges();
        }


        public static void UpdateAll<T>(DBConnectionString db, List<T> items, Action<T> update) where T : class
        {
            //using (var db = GetDashboardData())
            //{

            DbSet<T> table = db.Set<T>();
            foreach (T item in items)
            {
                //table.Attach(item);
                //T newitem = FillCommonFields<T>(item, (long)HttpContext.Current.Session[AdminConstants.AGENTID], false);
                T newitem = FillCommonFields<T>(item, 2, false);

                update(newitem);
            }

            db.SaveChanges();
            //}
        }

        public static void UpdateAll<T>(DBConnectionString db, List<T> items, long currentuser, Action<T> update) where T : class
        {
            //using (var db = GetDashboardData())
            //{

            DbSet<T> table = db.Set<T>();
            foreach (T item in items)
            {
                //table.Attach(item);
                T newitem = FillCommonFields<T>(item, currentuser, false);

                update(newitem);
            }

            db.SaveChanges();
            //}
        }
        public static void Delete<T>(DBConnectionString db, T entity) where T : class, new()
        {
            //using (var db = GetDashboardData())
            //{
            //    Table<T> table = db.GetTable<T>();
            //    table.Attach(entity);
            //    table.DeleteOnSubmit(entity);
            //    db.SubmitChanges();
            //}
            db.Entry(entity).State=EntityState.Deleted;
            db.SaveChanges();

        }
        public static void Insert<T>(T obj) where T : class
        {
            //string s =((System.Reflection.MemberInfo)(typeof(T).GetProperties()[0])).Name;
            using (var db = GetDataModelDataContext())
            {
                //obj = FillCommonFields<T>(obj, (long)HttpContext.Current.Session[AdminConstants.AGENTID], true);
                obj = FillCommonFields<T>(obj, 2, true);

                db.Entry(obj).State = EntityState.Added;
                db.SaveChanges();
            }
        }
        public static void Insert<T>(T obj, long currentuser) where T : class
        {

            using (var db = GetDataModelDataContext())
            {
                obj = FillCommonFields<T>(obj, currentuser, true);

                db.Entry(obj).State = EntityState.Added;
                db.SaveChanges();
            }
        }
        private static T Clone<T>(T objsrc, T objdest)
        {
            PropertyInfo[] propertyInfos = (typeof(T).GetProperties());

            foreach (PropertyInfo pInfo in propertyInfos)
            {
                bool isAssosiation = false;
                foreach (object a in pInfo.GetCustomAttributes(true))
                {
                    if (a.GetType() == typeof(System.Data.Linq.Mapping.AssociationAttribute))
                    {
                        isAssosiation = true;
                        break;
                    }
                }
                //todo : if update fail then toggole the if comment
                //if (pInfo.PropertyType.Namespace == "System" && pInfo.Name != "CreateDate")
                if (isAssosiation == false && pInfo.Name != "CreateDate")
                {
                    pInfo.SetValue(objdest, pInfo.GetValue(objsrc, null), null);
                }
            }
            return objdest;
        }

        private static T FillCommonFields<T>(T obj, long currentuser, bool isInserting)
        {
            PropertyInfo[] propertyInfos = (typeof(T).GetProperties());

            foreach (PropertyInfo pInfo in propertyInfos)
            {
                switch (pInfo.Name)
                {
                    case "TimeCheck":
                        {
                            pInfo.SetValue(obj, DateTime.Now, null);
                            break;

                        }

                    //case "UpdatedBy":
                    //    {
                    //        pInfo.SetValue(obj, currentuser, null);
                    //        break;

                    //    }
                }
                if (isInserting == true)
                {
                    switch (pInfo.Name)
                    {
                        //case "CreatedBy":
                        //    {
                        //        pInfo.SetValue(obj, currentuser, null);
                        //        break;

                        //    }
                        case "CreatedDate":
                            {
                                //OH.DAL.Basic.GlobalDA.GetServerDateTime()
                                pInfo.SetValue(obj, Basic.GlobalDA.GetServerDateTime(), null);
                                break;
                            }
                        case "IsRemoved":
                            {
                                pInfo.SetValue(obj, false, null);
                                break;
                            }
                    }
                }
            }
            return obj;
        }
    }
}
