using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OH.BLL.Basic;
using OH.DAL;
using OH.Utilities;
using System.Globalization;

namespace OH.Web.ControlAdmin
{
    public partial class ShowRegisteredUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    LoadRegisteredUserListView(string.Empty,string.Empty ,string.Empty );
                    //LoadLeaveRequest();
                    //LoadddlLeaveStatus();
                    //LoadddlLeaveType();
                    //LoadddlLeaveStatusForSearch();
                    //LoadddlLeaveTypeForSearch();
                    //btnSave.Visible = true;
                    //btnUpdate.Visible = false;
                    //btnDelete.Visible = false;
                    //btnCancel.Visible = false;
                }
                catch (Exception ex)
                {
                    labelMessageRegisteredUser.Text = "Error : " + ex.Message;
                    labelMessageRegisteredUser.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        private void LoadRegisteredUserListView(string email, string StartDate, string endDate)
        {
            try
            {
                using (AdGiverRT receiverTransfer = new AdGiverRT())
                {
                    string userID;
                    DateTime? SD;
                    DateTime? ED;
                    if (email != string.Empty || email != "") { userID = email; }
                    else { userID = null; }

                    if (StartDate.ToString() != string.Empty || StartDate.ToString() != "") {
                        //IFormatProvider theCultureInfo = new System.Globalization.CultureInfo("pl-PL", true);
                        SD = Convert.ToDateTime(StartDate);
                        //SD = DateTime.ParseExact(StartDate, "yyyy-MM-dd", theCultureInfo);
                    
                    }
                    else { SD = null; }

                    if (endDate.ToString() != string.Empty || endDate.ToString() != "") { ED = Convert.ToDateTime(endDate); }
                    else { ED = null; }
                    lvRegisteredUser.DataSource = receiverTransfer.GetRegisteredUserListView(userID, SD, ED);
                    lvRegisteredUser.DataBind();
                }
            }
            catch (Exception ex)
            {
                labelMessageRegisteredUser.Text = "Error : " + ex.Message;
                labelMessageRegisteredUser.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lvRegisteredUser_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }
        int lvRowCount = 0;
        int currentPage = 0;

        protected void dataPagerRegisteredUser_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                
               
                if (IsPostBack)
                {
                    LoadRegisteredUserListView(txtSearchByUserID.Text,txtSearchFromDate.Text, txtSearchToDate.Text);
                }
            }
            catch (Exception ex)
            {
                labelMessageRegisteredUser.Text = "Error : " + ex.Message;
                labelMessageRegisteredUser.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lvRegisteredUser_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            Response.Redirect("~/ControlAdmin/ShowAdGiverTracingForRegisteredUser.aspx");
        }

    }
}