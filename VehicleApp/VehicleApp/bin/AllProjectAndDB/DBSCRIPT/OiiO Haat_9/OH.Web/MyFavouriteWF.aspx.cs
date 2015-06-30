using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OH.BLL.Basic;
using OH.DAL;
using OH.Utilities;

namespace OH.Web
{
    public partial class MyFavouriteWF : System.Web.UI.Page
    {
        /// <summary>
        /// Asiful Islam
        /// </summary>
        public string Url { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadDefaultLoginLogout();
                    LoadMyFavourite();

                }
            }
            catch (Exception ex)
            {
                lblMyfabourite.Text = "Error : " + ex.Message;
                lblMyfabourite.ForeColor = System.Drawing.Color.Red;
            }
            
        }
        private void LoadMyFavourite()
        {
            try
            {
                using (MyFavouriteRT receiverTransfer = new MyFavouriteRT())
                {
                    string EmailID = Session["UserName"].ToString();
                    lvMyfvrt.DataSource = receiverTransfer.GetMyFavouriteAllForListView(EmailID); ;
                    lvMyfvrt.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblMyfabourite.Text = "Error : " + ex.Message;
                lblMyfabourite.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void LoadDefaultLoginLogout()
        {
            try
            {
                if (Session["UserName"] == null)
                {
                    Response.Redirect("~/LoginPage.aspx");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        protected void lvMyfvrt_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteMyfvrt")
            {
                try
                {
                    lblMyfabourite.Text = string.Empty;

                    int MyfabouriteID = Convert.ToInt32(e.CommandArgument);
                    hdmyfvrt.Value = MyfabouriteID.ToString();
                    using (MyFavouriteRT receiverTransfer = new MyFavouriteRT())
                    {
                        receiverTransfer.DeleteMyfabourite(MyfabouriteID);
                        lblMyfabourite.Text = "Data successfully deleted...";
                        lblMyfabourite.ForeColor = System.Drawing.Color.Green;
                    }
                }
                catch (Exception ex)
                {
                    lblMyfabourite.Text = "Error : " + ex.Message;
                    lblMyfabourite.ForeColor = System.Drawing.Color.Red;
                }
            }

            else if (e.CommandName == "EditMyfvrt")
            {
                try
                {
                    using (AdGiverRT receiverTransfer = new AdGiverRT())
                    {
                        lblMyfabourite.Text = string.Empty;
                        string userEmailId = Convert.ToString(Session["UserName"]);
                        AdGiver adgiverEmailId = receiverTransfer.GetAdGiverIDByEmail(userEmailId);

                        using (MyFavouriteRT receiverTransferMyfvrt = new MyFavouriteRT())
                        {
                            //int MaterialID = Convert.ToInt32(Request.QueryString["ID"]);
                            List<MyFavourite> EmailIDfrmMyfvrt = receiverTransferMyfvrt.GetEmailIDfrmMyfvrt(userEmailId);

                            if (adgiverEmailId.EmailID != null && EmailIDfrmMyfvrt!=null &&EmailIDfrmMyfvrt.Count>0)
                            {
 
                                int UrlID =Convert.ToInt32(e.CommandArgument);
                                MyFavourite url = receiverTransferMyfvrt.GetUrlFrmMyfvrt(UrlID);
                                Response.Redirect("DetailPage?option="+StringCipher.Encrypt(url.MaterialID.ToString()));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblMyfabourite.Text = "Error : " + ex.Message;
                    lblMyfabourite.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        private void getlinkofUrl()
        {
           
        }
        int lvRowCount = 0;
        int currentPage = 0;

        protected void lvMyfvrt_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void dataPagerMyfvrt_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    LoadMyFavourite();
                }
            }
            catch (Exception ex)
            {
                lblMyfabourite.Text = "Error : " + ex.Message;
                lblMyfabourite.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}