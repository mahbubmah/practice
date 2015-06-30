using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OH.Report;
using CrystalDecisions.Web;
using CrystalDecisions.CrystalReports.Design;
using CrystalDecisions.Reporting;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;

namespace OH.Web.ControlAdmin
{
    public partial class ShowReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["reportForm"] != null)
                {
                    ReportDocument rDoc = new ReportDocument();
                    rDoc = (ReportDocument)Session["reportForm"];
                    crystalReportViewerForAll.ReportSource = rDoc;
                    crystalReportViewerForAll.DataBind();
                }//end if
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }//end try
    }//end class
}