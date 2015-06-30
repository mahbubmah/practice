using System.IO;
using BLL.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace OB.Web
{
    public partial class BookAuthLists : System.Web.UI.Page
    {
        private readonly string _visitorLogPath;
        private string _pageLogPath;

        public BookAuthLists()
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
                }

                pnlSearchedAuthor.Visible = false;
            pnlAuthorSearchResult.Visible = true;
            LoadFeatureAuthor();
            LoadSearchAuthor();
            LoadBookPublishThisMonthByAuthor();

            }

            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
        private void LoadSearchAuthor()
        {
            try
            {
                BookAuthorRT _BookAuthorRT = new BookAuthorRT();
                var objSearchAuthor = _BookAuthorRT.GetSearchedAuthorsAlphabeticalLists();
                if (objSearchAuthor != null)
                {
                    rpAuthorSearch.DataSource = objSearchAuthor;
                    rpAuthorSearch.DataBind();
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private void LoadFeatureAuthor()
        {
            try
            {
               
                BookAuthorRT _BookAuthorRT = new BookAuthorRT();
                var objFauthor = _BookAuthorRT.GetOneFeaturedAuthor();
                if (objFauthor != null)
                {
                    rpFAuthor.DataSource = objFauthor;
                    rpFAuthor.DataBind();
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        protected void rpFAuthor_OnItemDataBound(object source, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    Literal objltrAuthorName = (Literal)e.Item.FindControl("ltrAuthorName");
                    objltrAuthorName.Text = objltrAuthorName.Text;

                    Literal objltrbookTitle = (Literal)e.Item.FindControl("ltrFavQuote");
                    if (objltrbookTitle.Text.Length > 500)
                    {
                        objltrbookTitle.Text = objltrbookTitle.Text.Substring(0, 500) + ".......";
                    }
                    else
                    {
                        objltrbookTitle.Text = objltrbookTitle.Text;
                    }
                    Literal objltrAuthor = (Literal)e.Item.FindControl("ltrAuthor");
                    objltrAuthor.Text = objltrAuthor.Text;
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        protected void lnkAlphabet_Click(object sender, EventArgs e)
        {
           try
           {
            LinkButton btn = (LinkButton)(sender);
            string alphabet = btn.CommandArgument;
            pnlAuthorSearchResult.Visible = false;
            pnlSearchedAuthor.Visible = true;
            BookAuthorRT _BookAuthorRT = new BookAuthorRT();
            var objSeacredAuthor = _BookAuthorRT.GetAllSearchedAuthor(alphabet);
            if (objSeacredAuthor != null)
            {
                rpAllAuthor.DataSource = objSeacredAuthor;
                rpAllAuthor.DataBind();
            }

            }
           catch (Exception ex)
           {
               LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
           }
        }
        protected void rpAllAuthor_OnItemDataBound(object source, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    Literal objltrAuthorName = (Literal)e.Item.FindControl("ltrAuthorName");
                    objltrAuthorName.Text = objltrAuthorName.Text;
                    
                    Literal objltrbookTitle = (Literal)e.Item.FindControl("ltrAbout");
                    if (objltrbookTitle.Text.Length > 500)
                    {
                        objltrbookTitle.Text = objltrbookTitle.Text.Substring(0, 500) + ".......";
                    }
                    else
                    {
                        objltrbookTitle.Text = objltrbookTitle.Text;
                    }
                    //Image img_Author = (Image)e.Item.FindControl("img_Author");
                    //img_Author.ImageUrl =img_Author.Picture;
                   
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private void LoadBookPublishThisMonthByAuthor()
        {
            try
            {

                BookRT _BookRT = new BookRT();
                var obj = _BookRT.GetAllPublishingThisMonth();
                if (obj != null)
                {
                    rpBookPublishThisMonth.DataSource = obj;
                    rpBookPublishThisMonth.DataBind();
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

                    
    }
}