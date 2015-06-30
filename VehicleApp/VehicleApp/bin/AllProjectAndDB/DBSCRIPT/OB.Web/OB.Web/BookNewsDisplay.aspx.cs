using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OB.BLL.Basic;
using OB.DAL;
using OB.Utilities;
using Utilities;

namespace OB.Web
{
    public partial class BookNewsDisplay : System.Web.UI.Page
    {
        private readonly string _visitorLogPath;
        private string _pageLogPath;

        public BookNewsDisplay()
        {
            this._visitorLogPath = Server.MapPath("~/Log file/VisitorlogFileWriting.txt");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string pageName = Path.GetFileName(Request.PhysicalPath);
                _pageLogPath = Server.MapPath("~/Log file/" + pageName + ".txt");
                if (!IsPostBack)
                {
                    LogFileHelper.VisitorLogFileWritten(_visitorLogPath);
                   // LoadAllBookNews();
                    LoadFirstThreeBookNews();
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
           
          
         //  lnk_btn_All_Lnk_Click(sender,e);
        }
       
    
        protected void rptBookNewsShow_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    Literal objltrHeadline = (Literal)e.Item.FindControl("lblHeadline");
                    if (objltrHeadline.Text.Length > 50)
                    {
                        var text = objltrHeadline.Text.Substring(0, 50);
                        objltrHeadline.Text = text + "...";
                    }
                    else
                    {
                        objltrHeadline.Text = objltrHeadline.Text.Trim() + ".";
                    }

                    Literal objltrNewsDescription = (Literal)e.Item.FindControl("lblNewsDescription");
                    if (objltrNewsDescription.Text.Length > 125)
                    {
                        var text = objltrNewsDescription.Text.Substring(0, 125);
                        objltrNewsDescription.Text = text + "...";
                    }
                    else
                    {
                        objltrNewsDescription.Text = objltrNewsDescription.Text.Trim() + ".";
                    }

                    Literal objltrVideoLink = (Literal)e.Item.FindControl("LiteralVedio");
                    //LinkButton lnkvedio = (LinkButton)e.Item.FindControl("lnk_btn_Vedo_Lnk");
                    if (objltrVideoLink.Text == string.Empty)
                    {
                     
                        objltrVideoLink.Visible = false;
                        //lnkvedio.Visible = false;
                    }
                    else
                    {
                        objltrVideoLink.Visible = true;
                        //lnkvedio.Visible = true;
                        objltrVideoLink.Text = "Video Link: "+objltrVideoLink.Text;
                    }

                    Literal objltrAudioLink = (Literal)e.Item.FindControl("LiteralAudio");
                    //LinkButton lnkAudio = (LinkButton)e.Item.FindControl("lnk_btn_Audio_Lnk");
                    if (objltrAudioLink.Text == string.Empty)
                    {
                        //  var text = objltrNewsDescription.Text.Substring(0, 125);
                        objltrAudioLink.Visible = false;
                        //lnkAudio.Visible = false;
                    }
                    else
                    {
                        objltrAudioLink.Visible = true;
                        //lnkAudio.Visible = true;
                        objltrAudioLink.Text = "Audio Link: "+ objltrAudioLink.Text;
                    }

                    Image bookNewsimageUrl = (Image)e.Item.FindControl("img_inner");
                    if (bookNewsimageUrl.ImageUrl == string.Empty)
                    {
                        //  var text = objltrNewsDescription.Text.Substring(0, 125);
                        bookNewsimageUrl.Visible = false;
                        
                    }
                    else
                    {
                        bookNewsimageUrl.Visible = true;
                       
                    }

                    Session["itemcount"]=rptBookNewsShow.Items.Count;
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
        private void LoadAllBookNews()
        {
            try
            {
                BookNewsRT _bookNewsRT = new BookNewsRT();
                var objNews = _bookNewsRT.GetNEWSContentAll().ToList();
               
                if (objNews.Count > 0)
                {

                   rptBookNewsShow.DataSource = objNews;
                    rptBookNewsShow.DataBind();

                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        protected void lnk_btn_All_Lnk_Click(object sender, EventArgs e)
        {

            try
            {

                LinkButton linkButton = new LinkButton();
                linkButton = (LinkButton)sender;
                string ID = linkButton.Text;
                if (ID == "View All")
                {
                    
                    LoadAllBookNews();
                }
                else
                    LoadFirstThreeBookNews();
               

            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private void LoadFirstThreeBookNews()
        {
            try
            {
                BookNewsRT _bookNewsRT = new BookNewsRT();
                var objNews = _bookNewsRT.GetNEWSContentAll().Take(2).ToList();

                if (objNews.Count > 0)
                {

                    rptBookNewsShow.DataSource = objNews;
                    rptBookNewsShow.DataBind();

                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        //protected void lnk_btn_Vedo_Lnk_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
               
        //        LinkButton linkButton = new LinkButton();
        //        linkButton = (LinkButton)sender;
        //        int BookNewsID = (Convert.ToInt32(linkButton.CommandArgument));
        //        BookNewsRT _bookNewsRT = new BookNewsRT();
        //        BookNews VdoUrl = _bookNewsRT.getbooKnewsbyIID(BookNewsID);
        //        Response.Redirect(VdoUrl.VideoLink);
               
        //    }
        //    catch (Exception ex)
        //    {
        //        //LogFileWritten(ex.Message, ex.StackTrace);
        //    }
        //}

        //protected void lnk_btn_Audio_Lnk_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        LinkButton linkButton = new LinkButton();
        //        linkButton = (LinkButton)sender;
        //        int BookNewsID = (Convert.ToInt32(linkButton.CommandArgument));
        //        BookNewsRT _bookNewsRT = new BookNewsRT();
        //        BookNews VdoUrl = _bookNewsRT.getbooKnewsbyIID(BookNewsID);
        //        Response.Redirect(VdoUrl.Audio);

        //    }
        //    catch (Exception ex)
        //    {
        //        //LogFileWritten(ex.Message, ex.StackTrace);
        //    }
        //}
       
     
       
    }
}