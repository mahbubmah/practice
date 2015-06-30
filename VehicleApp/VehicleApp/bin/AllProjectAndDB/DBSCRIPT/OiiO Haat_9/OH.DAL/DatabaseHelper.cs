using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OH.DAL
{
    public class DatabaseHelper
    {
        //public DatabaseHelper()
        //{
        //}

        public const string _applicationID = "acf0ee5a-c10a-4fb0-bd2a-4063fe3edb24";
        public readonly static Guid _applicationGuid = new Guid(_applicationID);

        private static string _connectionString;


        public static OiiOHaatDCDataContext GetDataModelDataContext()
        {
            try
            {
                _connectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ToString();
                var db = new OiiOHaatDCDataContext(_connectionString);
                return db;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public static void Update<T>(OiiOHaatDCDataContext db, T obj) where T : class
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

            db.SubmitChanges();
        }

        public static void Update<T>(OiiOHaatDCDataContext db, T objSrc, T objDest) where T : class
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

            db.SubmitChanges();
        }
        public static void Update<T>(OiiOHaatDCDataContext db, T obj, long currentuser, Action<T> update) where T : class
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
            db.SubmitChanges();
        }


        public static void UpdateAll<T>(OiiOHaatDCDataContext db, List<T> items, Action<T> update) where T : class
        {
            //using (var db = GetDashboardData())
            //{

            Table<T> table = db.GetTable<T>();
            foreach (T item in items)
            {
                //table.Attach(item);
                //T newitem = FillCommonFields<T>(item, (long)HttpContext.Current.Session[AdminConstants.AGENTID], false);
                T newitem = FillCommonFields<T>(item, 2, false);

                update(newitem);
            }

            db.SubmitChanges();
            //}
        }

        public static void UpdateAll<T>(OiiOHaatDCDataContext db, List<T> items, long currentuser, Action<T> update) where T : class
        {
            //using (var db = GetDashboardData())
            //{

            Table<T> table = db.GetTable<T>();
            foreach (T item in items)
            {
                //table.Attach(item);
                T newitem = FillCommonFields<T>(item, currentuser, false);

                update(newitem);
            }

            db.SubmitChanges();
            //}
        }
        public static void Delete<T>(OiiOHaatDCDataContext db, T entity) where T : class, new()
        {
            //using (var db = GetDashboardData())
            //{
            //    Table<T> table = db.GetTable<T>();
            //    table.Attach(entity);
            //    table.DeleteOnSubmit(entity);
            //    db.SubmitChanges();
            //}

            db.GetTable<T>().DeleteOnSubmit(entity);
            db.SubmitChanges();

        }
        public static void Insert<T>(T obj) where T : class
        {
            //string s =((System.Reflection.MemberInfo)(typeof(T).GetProperties()[0])).Name;
            using (var db = GetDataModelDataContext())
            {
                //obj = FillCommonFields<T>(obj, (long)HttpContext.Current.Session[AdminConstants.AGENTID], true);
                obj = FillCommonFields<T>(obj, 2, true);

                db.GetTable<T>().InsertOnSubmit(obj);
                db.SubmitChanges();
            }
        }
        public static void Insert<T>(T obj, long currentuser) where T : class
        {

            using (var db = GetDataModelDataContext())
            {
                obj = FillCommonFields<T>(obj, currentuser, true);

                db.GetTable<T>().InsertOnSubmit(obj);
                db.SubmitChanges();
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
                                pInfo.SetValue(obj, OH.DAL.Basic.GlobalDA.GetServerDateTime(), null);
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
