using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace OMart.Web
{
    public partial class BroadbandMobileDeals : System.Web.UI.Page
    {
        private readonly string _visitorLogPath;
        private string _pageLogPath;

        public BroadbandMobileDeals()
        {
            this._visitorLogPath = Server.MapPath("~/Log file/VisitorlogFileWriting.txt");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string pageName = Path.GetFileName(Request.PhysicalPath);
                _pageLogPath = Server.MapPath("~/Log file/" + pageName + ".txt");    
            
                if(!IsPostBack)
                {
                    LogFileHelper.VisitorLogFileWritten(_visitorLogPath);
                }

            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        protected void objDataSourceBDInternetDeals_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["typeID"] = Convert.ToInt32 (EnumCollection.Type.MobileBroadbandWirelessconnection);
        }
    }
}