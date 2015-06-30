using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OH.Utilities
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
            catch(Exception ex)
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
}
