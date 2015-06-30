using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    //public enum DateRequiredValue
    //{
    //    Minit
    //    Days=1,
    //    TotalDays=2,

    //}
    public class GetTime
    {
        public string Hour { get; set; }
        public string Minutes { get; set; }
        public string Seconds { get; set; }
    }
    public static class Conversion
    {
        public static GetTime GetTimeInHourMinutesSecond(string times)
        {
            GetTime getTime = new GetTime();
            string[] timeArray = times.Split(new char[] { ':', '.' });
            try
            {
                getTime.Hour = timeArray[0];
                getTime.Minutes = timeArray[1];
                if (timeArray[2] != null)
                {
                    getTime.Seconds = timeArray[2];
                }

                return getTime;
            }
            catch (Exception)
            {
                return getTime;
            }
        }

        public static DateTime GetDateFromText(string date)
        {
            try
            {
                if (!string.IsNullOrEmpty(date))
                {
                    string[] dateArray = date.Split(new char[] { '/', '-', '.' });
                    if (dateArray.Length >= 3)
                    {
                        string year = dateArray[2];
                        if (year.Length == 2)
                        {
                            DateTime nowDate = DateTime.Now;
                            string yearNow = nowDate.Year.ToString();
                            string yearStr = yearNow[0].ToString();
                            yearStr += yearNow[1].ToString();
                            year = yearStr + year;
                        }
                        return new DateTime(Convert.ToInt32(year), Convert.ToInt32(dateArray[1]), Convert.ToInt32(dateArray[0]));
                    }
                    else
                    {
                        return DateTime.MinValue;
                    }
                }
                return DateTime.MinValue;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public static int GetDateDiff(DateTime fromDate, DateTime toDate)
        {
            try
            {
                int totalDay = 0;

                if (fromDate != null && toDate != null)
                {
                    totalDay = (toDate - fromDate).Days;
                }
                return totalDay;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public static string Get24_HourTime(string time)
        {
            try
            {
                string convertedTime = "";
                string[] timeArray = time.Split(':');
                convertedTime = (Convert.ToInt16(timeArray[0]) + 12).ToString() + ":" + timeArray[1];
                return convertedTime;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public static void GroupGridColumn(System.Web.UI.WebControls.GridView grd, params string[] parms)
        {
            for (int rowIndex = grd.Rows.Count - 2; rowIndex >= 0; rowIndex--)
            {
                System.Web.UI.WebControls.GridViewRow gvRow = grd.Rows[rowIndex];
                System.Web.UI.WebControls.GridViewRow gvPreviousRow = grd.Rows[rowIndex + 1];
                for (int cellCount = 0; cellCount < gvRow.Cells.Count; cellCount++)
                {
                    bool flag = false;
                    for (int j = 0; j < parms.Count(); j++)
                    {
                        if (grd.Columns[cellCount].HeaderText == parms[j])
                        {
                            flag = true;
                            break;
                        }
                    }

                    if (flag)
                    {
                        if (gvRow.Cells[cellCount].Text == gvPreviousRow.Cells[cellCount].Text)
                        {
                            if (gvPreviousRow.Cells[cellCount].RowSpan < 2)
                            {
                                gvRow.Cells[cellCount].RowSpan = 2;
                            }
                            else
                            {
                                gvRow.Cells[cellCount].RowSpan =
                                    gvPreviousRow.Cells[cellCount].RowSpan + 1;
                            }
                            gvPreviousRow.Cells[cellCount].Visible = false;
                        }
                    }
                }
            }
        }

        //public static void GroupListColumn(System.Web.UI.WebControls.ListView grd, params string[] parms)
        //{
        //    for (int rowIndex = grd.Rows.Count - 2; rowIndex >= 0; rowIndex--)
        //    {
        //        System.Web.UI.WebControls.GridViewRow gvRow = grd.Rows[rowIndex];
        //        System.Web.UI.WebControls.GridViewRow gvPreviousRow = grd.Rows[rowIndex + 1];
        //        for (int cellCount = 0; cellCount < gvRow.Cells.Count; cellCount++)
        //        {
        //            bool flag = false;
        //            for (int j = 0; j < parms.Count(); j++)
        //            {
        //                if (grd.Columns[cellCount].HeaderText == parms[j])
        //                {
        //                    flag = true;
        //                    break;
        //                }
        //            }

        //            if (flag)
        //            {
        //                if (gvRow.Cells[cellCount].Text == gvPreviousRow.Cells[cellCount].Text)
        //                {
        //                    if (gvPreviousRow.Cells[cellCount].RowSpan < 2)
        //                    {
        //                        gvRow.Cells[cellCount].RowSpan = 2;
        //                    }
        //                    else
        //                    {
        //                        gvRow.Cells[cellCount].RowSpan =
        //                            gvPreviousRow.Cells[cellCount].RowSpan + 1;
        //                    }
        //                    gvPreviousRow.Cells[cellCount].Visible = false;
        //                }
        //            }
        //        }
        //    }
        //}

        public static DataSet ToDataSet<T>(this IList<T> list, DataSet ds, string tableName)
        {
            Type elementType = typeof(T);
            if (list != null)
            {
                foreach (T item in list)
                {
                    DataRow row = ds.Tables[tableName].NewRow();
                    foreach (var propInfo in elementType.GetProperties())
                    {
                        try
                        {
                            row[propInfo.Name] = propInfo.GetValue(item, null) ?? DBNull.Value;
                        }
                        catch { }
                    }
                    ds.Tables[tableName].Rows.Add(row);
                }
            }

            return ds;
        }

    }
    public static class ObjectShredder<T>
    {
        private static Type _type = typeof(T);
        private static FieldInfo[] _fi = _type.GetFields();
        private static PropertyInfo[] _pi = _type.GetProperties();
        private static Dictionary<string, int> _ordinalMap = new Dictionary<string, int>();
        private static DataTable _dt = new DataTable();
        // ObjectShredder constructor. 
        //public ObjectShredder()
        //{
        //    _type = typeof(T);
        //    _fi = _type.GetFields();
        //    _pi = _type.GetProperties();
        //    _ordinalMap = new Dictionary<string, int>();
        //    _dt = new DataTable();
        //}

        /// <summary> 
        /// Loads a DataTable from a sequence of objects. 
        /// </summary> 
        /// <param name="source">The sequence of objects to load into the DataTable.</param>
        /// <param name="table">The input table. The schema of the table must match that 
        /// the type T.  If the table is null, a new table is created with a schema  
        /// created from the public properties and fields of the type T.</param> 
        /// <param name="options">Specifies how values from the source sequence will be applied to 
        /// existing rows in the table.</param> 
        /// <returns>A DataTable created from the source sequence.</returns> 

        public static DataTable Shred(IEnumerable<T> source, DataTable table, LoadOption? options)
        {
            // Load the table from the scalar sequence if T is a primitive type. 
            if (typeof(T).IsPrimitive)
            {
                return ShredPrimitive(source, table, options);
            }

            // Create a new table if the input table is null. 
            if (table == null)
            {
                table = new DataTable(typeof(T).Name);
            }

            // Initialize the ordinal map and extend the table schema based on type T.
            table = ExtendTable(table, typeof(T));

            // Enumerate the source sequence and load the object values into rows.
            table.BeginLoadData();
            using (IEnumerator<T> e = source.GetEnumerator())
            {
                while (e.MoveNext())
                {
                    if (options != null)
                    {
                        table.LoadDataRow(ShredObject(table, e.Current), (LoadOption)options);
                    }
                    else
                    {
                        table.LoadDataRow(ShredObject(table, e.Current), true);
                    }
                }
            }
            table.EndLoadData();

            // Return the table. 
            return table;
        }


        public static DataTable EntityToDataTable(T source)
        {
            _dt.Clear();
            // Load the table from the scalar sequence if T is a primitive type. 
            if (typeof(T).IsPrimitive)
            {
                return ShredPrimitive(source, _dt, null);//option is null
            }

            // Create a new table if the input table is null. 
            if (_dt == null)
            {
                _dt = new DataTable(typeof(T).Name);
            }

            // Initialize the ordinal map and extend the table schema based on type T.
            _dt = ExtendTable(_dt, typeof(T));

            // Enumerate the source sequence and load the object values into rows.
            _dt.BeginLoadData();

            _dt.LoadDataRow(ShredObject(_dt, source), true);

            _dt.EndLoadData();

            // Return the table. 
            return _dt;
        }

        public static DataTable ListToDataTable(IEnumerable<T> source)
        {
            _dt.Clear();
            // Load the table from the scalar sequence if T is a primitive type. 
            if (typeof(T).IsPrimitive)
            {
                return ShredPrimitive(source, _dt, null);//option is null
            }

            // Create a new table if the input table is null. 
            if (_dt == null)
            {
                _dt = new DataTable(typeof(T).Name);
            }

            // Initialize the ordinal map and extend the table schema based on type T.
            _dt = ExtendTable(_dt, typeof(T));

            // Enumerate the source sequence and load the object values into rows.
            _dt.BeginLoadData();
            using (IEnumerator<T> e = source.GetEnumerator())
            {
                while (e.MoveNext())
                {
                    _dt.LoadDataRow(ShredObject(_dt, e.Current), true);
                }
            }
            _dt.EndLoadData();

            // Return the table. 
            return _dt;
        }
        public static DataTable ShredPrimitive(T source, DataTable table, LoadOption? options)
        {
            // Create a new table if the input table is null. 
            if (table == null)
            {
                table = new DataTable(typeof(T).Name);
            }

            if (!table.Columns.Contains("Value"))
            {
                table.Columns.Add("Value", typeof(T));
            }

            // Enumerate the source sequence and load the scalar values into rows.
            table.BeginLoadData();

            Object[] values = new object[table.Columns.Count];

            values[table.Columns["Value"].Ordinal] = source;

            if (options != null)
            {
                table.LoadDataRow(values, (LoadOption)options);
            }
            else
            {
                table.LoadDataRow(values, true);
            }


            table.EndLoadData();

            // Return the table. 
            return table;
        }
        public static DataTable ShredPrimitive(IEnumerable<T> source, DataTable table, LoadOption? options)
        {
            // Create a new table if the input table is null. 
            if (table == null)
            {
                table = new DataTable(typeof(T).Name);
            }

            if (!table.Columns.Contains("Value"))
            {
                table.Columns.Add("Value", typeof(T));
            }

            // Enumerate the source sequence and load the scalar values into rows.
            table.BeginLoadData();
            using (IEnumerator<T> e = source.GetEnumerator())
            {
                Object[] values = new object[table.Columns.Count];
                while (e.MoveNext())
                {
                    values[table.Columns["Value"].Ordinal] = e.Current;

                    if (options != null)
                    {
                        table.LoadDataRow(values, (LoadOption)options);
                    }
                    else
                    {
                        table.LoadDataRow(values, true);
                    }
                }
            }
            table.EndLoadData();

            // Return the table. 
            return table;
        }

        public static object[] ShredObject(DataTable table, T instance)
        {

            FieldInfo[] fi = _fi;
            PropertyInfo[] pi = _pi;

            if (instance.GetType() != typeof(T))
            {
                // If the instance is derived from T, extend the table schema 
                // and get the properties and fields.
                ExtendTable(table, instance.GetType());
                fi = instance.GetType().GetFields();
                pi = instance.GetType().GetProperties();
            }

            // Add the property and field values of the instance to an array.
            Object[] values = new object[table.Columns.Count];
            foreach (FieldInfo f in fi)
            {
                values[_ordinalMap[f.Name]] = f.GetValue(instance);
            }

            foreach (PropertyInfo p in pi)
            {
                values[_ordinalMap[p.Name]] = p.GetValue(instance, null);
            }

            // Return the property and field values of the instance. 
            return values;
        }

        public static DataTable ExtendTable(DataTable table, Type type)
        {
            // Extend the table schema if the input table was null or if the value  
            // in the sequence is derived from type T.             
            foreach (FieldInfo f in type.GetFields())
            {
                if (!_ordinalMap.ContainsKey(f.Name))
                {
                    // Add the field as a column in the table if it doesn't exist 
                    // already.
                    DataColumn dc = table.Columns.Contains(f.Name) ? table.Columns[f.Name]
                        : table.Columns.Add(f.Name, f.FieldType);

                    // Add the field to the ordinal map.
                    _ordinalMap.Add(f.Name, dc.Ordinal);
                }
            }
            foreach (PropertyInfo p in type.GetProperties())
            {

                if (!_ordinalMap.ContainsKey(p.Name))
                {
                    DataColumn dc = new DataColumn();

                    // It's nullable
                    if (Nullable.GetUnderlyingType(p.PropertyType) != null)
                    {
                        dc = table.Columns.Contains(p.Name) ? table.Columns[p.Name]
                           : table.Columns.Add(p.Name, Nullable.GetUnderlyingType(p.PropertyType));//change from p.PropertyType to Not nullable property type for datatable
                    }
                    else
                    {
                        // Add the property as a column in the table if it doesn't exist 
                        // already.
                        dc = table.Columns.Contains(p.Name) ? table.Columns[p.Name]
                             : table.Columns.Add(p.Name, p.PropertyType);

                    }


                    // Add the property to the ordinal map.
                    _ordinalMap.Add(p.Name, dc.Ordinal);
                }
            }

            // Return the table. 
            return table;
        }
    }
}
