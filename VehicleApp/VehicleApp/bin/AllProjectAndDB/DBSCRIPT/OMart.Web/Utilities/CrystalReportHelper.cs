using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using DAL;
using Utilities;


namespace Utilities
{
    public class CrParameter
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public static class CrHelper
    {
        public static string SessParamListStr = "crPramList";
        public static string SessParamStr = "crPram";
        public static string SessReportFormStr = "reportForm";
        public static void SetLoginInfo(ReportDocument crystalReportPage)
        {
            SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder(new DataHelper().GetConnectionString());
            crystalReportPage.SetDatabaseLogon(stringBuilder.UserID, stringBuilder.Password, stringBuilder.DataSource, stringBuilder.InitialCatalog);
        }
        
    }

    public static class CrystalReportHelper<TCrystalReportPage> where TCrystalReportPage : ReportClass
    {

        public static void SetLoginInfo(TCrystalReportPage crystalReportPage)
        {
            SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder(new DataHelper().GetConnectionString());
            crystalReportPage.SetDatabaseLogon(stringBuilder.UserID, stringBuilder.Password, stringBuilder.DataSource, stringBuilder.InitialCatalog);
        }

        public static void LoadCrystalReport<T>(CrystalReportViewer crystalReportViewer, TCrystalReportPage crystalReportPage, IEnumerable<T> list)
        {
            try
            {
                SetLoginInfo(crystalReportPage);
                var dt = ObjectShredder<T>.ListToDataTable(list);
                crystalReportPage.SetDataSource(dt);
                crystalReportViewer.ReportSource = crystalReportPage;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public static void LoadCrystalReport<T>(CrystalReportViewer crystalReportViewer, TCrystalReportPage crystalReportPage, T source)
        {
            try
            {
                SetLoginInfo(crystalReportPage);
                var dt = ObjectShredder<T>.EntityToDataTable(source);
                crystalReportPage.SetDataSource(dt);
                crystalReportViewer.ReportSource = crystalReportPage;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public static ReportDocument LoadCrystalReport<T>(TCrystalReportPage crystalReportPage, IEnumerable<T> list)
        {
            try
            {
                SetLoginInfo(crystalReportPage);
                var dt = ObjectShredder<T>.ListToDataTable(list);
                crystalReportPage.SetDataSource(dt);
                return crystalReportPage;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }


        public static ReportDocument LoadCrystalReport<T>(TCrystalReportPage crystalReportPage, T name)
        {
            try
            {
                SetLoginInfo(crystalReportPage);
                var dt = ObjectShredder<T>.EntityToDataTable(name);
                crystalReportPage.SetDataSource(dt);
                return crystalReportPage;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

    }
}
