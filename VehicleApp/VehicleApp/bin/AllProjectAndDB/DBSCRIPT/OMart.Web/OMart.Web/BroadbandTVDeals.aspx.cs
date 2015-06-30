using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace OMart.Web
{
    public partial class BroadbandTVDeals : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void objDataSourceBroadBandTVDeals_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["typeID"] = Convert.ToInt32(EnumCollection.Type.TV);
        }

    }
}