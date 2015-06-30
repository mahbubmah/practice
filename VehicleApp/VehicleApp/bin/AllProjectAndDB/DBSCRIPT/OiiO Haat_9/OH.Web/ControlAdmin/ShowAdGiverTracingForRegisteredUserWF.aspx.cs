using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OH.BLL.Basic;
using OH.DAL;
using OH.Utilities;

namespace OH.Web.ControlAdmin
{
    public partial class ShowAdGiverTracingForRegisteredUserWF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    RegisteredUserListView();
                }
            }
            catch (Exception ex)
            {
                labelMessageRegisteredUserAddGiverTracing.Text = "Error : " + ex.Message;
                labelMessageRegisteredUserAddGiverTracing.ForeColor = System.Drawing.Color.Red;
            }
        }

        public void RegisteredUserListView()
        {
            try
            {
            using (AddGiverTracingRT receiverTransfer = new AddGiverTracingRT())
            {
                Int64 userId = Convert.ToInt64(Session["RegistereduserID"]);
                List<AdGiverTracing> adgivertracing = receiverTransfer.GetAdGiverTracingByIID(userId);

                if (adgivertracing != null && adgivertracing.Count > 0)
                    {
                        lvRegisteredUserAddGiverTracing.DataSource = receiverTransfer.GetAdGiverTracingListViewByIID(Convert.ToInt64(userId)); 
                        lvRegisteredUserAddGiverTracing.DataBind();
                        using (AdGiverRT receiverTransferAdgiver = new AdGiverRT())
                        {
                            AdGiver e = receiverTransferAdgiver.GetAdGiverByIID(Convert.ToInt64(userId));
                            labelDisplayName.Text = "Welcome "+e.Name;
                            labelDisplayEmail.Text = "Your Email Address : "+e.EmailID;
                            labellistview.Text = e.Name + "'s Add Giver Tracing Information";
                    }
                    }
                }
            }
            catch (Exception ex)
            {
                labelMessageRegisteredUserAddGiverTracing.Text = "Error : " + ex.Message;
                labelMessageRegisteredUserAddGiverTracing.ForeColor = System.Drawing.Color.Red;
            }
         }
    }
}