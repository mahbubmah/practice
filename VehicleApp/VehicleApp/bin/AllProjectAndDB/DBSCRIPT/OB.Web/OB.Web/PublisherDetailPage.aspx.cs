using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Basic;
using OB.BLL.Basic;
using OB.DAL;
using Utilities;

namespace OB.Web
{
    public partial class PublisherDetailPage : System.Web.UI.Page
    {
        private Int64 IID = default(Int64);
        private readonly BookPublisherRT _bookPublisherRt;
        private readonly string _visitorLogPath;
        private string _pageLogPath;

        public PublisherDetailPage()
        {
            this._visitorLogPath = Server.MapPath("~/Log file/VisitorlogFileWriting.txt");
            this._bookPublisherRt = new BookPublisherRT();
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
                    bool isPublisherIdValid = Int64.TryParse(Request.QueryString["ID"], out IID);
                    if (isPublisherIdValid)
                    {
                        LoadPublisherDetail();
                    }
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }


        }

        private void LoadPublisherDetail()
        {
            try
            {
                var objPublisher = _bookPublisherRt.GetBookPublisherByIID(IID);
                List<Book> publisherLatestBookList =
                    (from csBookList in _bookPublisherRt.GetBooksPublishedByPublisher(IID).Where(
                        x => x.PublishedDate <= GlobalRT.GetServerDateTime()
                             && x.PublishedDate >= GlobalRT.GetServerDateTime().Subtract(new TimeSpan(60, 0, 0, 0)))
                     select csBookList).Take(4).ToList();

                List<Book> comingSoonBooks =
                   (from csBookList in _bookPublisherRt.GetBooksPublishedByPublisher(IID).Where(
                       x => x.PublishedDate > GlobalRT.GetServerDateTime()
                            && x.PublishedDate <= GlobalRT.GetServerDateTime().AddDays(60))
                    select csBookList).Take(4).ToList();


                if (objPublisher != null)
                {
                    lbAboutPublisher.Text = objPublisher.AboutPublisher;
                    lbPublisherAward.Text = objPublisher.AwardAchieved;
                    lbPublisherTitle1.Text = objPublisher.PublisherName;
                    lbPublisherTitle2.Text = objPublisher.PublisherName;
                    lbPublisherWebsite.Text = objPublisher.WebsiteLink;
                    ancPublisherWebSiteLink.HRef = objPublisher.WebsiteLink;
                    imgPublisherLogo.ImageUrl = objPublisher.PublisherLogoUrl;

                    //coming soon book
                    lbPublisherTitle4.Text = objPublisher.PublisherName;
                    ltrBookCount1.Text = comingSoonBooks.Count.ToString();
                    ltrPublisherName1.Text = objPublisher.PublisherName;


                    rptComingSoonBooks.DataSource = comingSoonBooks;
                    rptComingSoonBooks.DataBind();

                    //latest books
                    lbPublisherTitle3.Text = objPublisher.PublisherName;
                    ltrPublisherName.Text = objPublisher.PublisherName;
                    ltrBookCount.Text = publisherLatestBookList.Count.ToString();


                    rptLatestBooks.DataSource = publisherLatestBookList;
                    rptLatestBooks.DataBind();

                }

            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }

        }

        protected void linkToBookDetails_OnClick(object sender, EventArgs e)
        {
            try
            {
               // Response.Redirect("", false);
               // Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
    }
}