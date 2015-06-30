using BLL.Basic;
using OMart.Web.AdminPanel.ReportMortgage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMart.Web.AdminPanel
{
    public partial class MortgageReportUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                MortgageReport report = new MortgageReport();
                using (MortgageRT rt = new MortgageRT())
                {
                    try
                    {
                        DataTable table = new DataTable();
                        table = rt.DisplayMortgageData();
                        report.SetDataSource(table);
                        crv.ReportSource = report;
                        crv.RefreshReport();

                    }
                    catch (Exception ex)
                    {
                        //labelMessage.Text = "Can not open connection ! ";
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}