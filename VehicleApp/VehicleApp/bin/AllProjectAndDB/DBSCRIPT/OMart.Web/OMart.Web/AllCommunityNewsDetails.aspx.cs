using BLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using DAL;
using System.Web.UI.HtmlControls;

namespace OMart.Web
{
    public partial class AllCommunityNewsDetails : System.Web.UI.Page
    {
      
        private readonly string _visitorLogPath;
        private string _pageLogPath;
        private readonly CommunityNewsRT _CommunityNewsRT;
        private long IID = default(Int64);
        public int lvRowCount { get; set; }
        public int currentPage { get; set; }

        public AllCommunityNewsDetails()
        {
            this._visitorLogPath = Server.MapPath("~/Log file/VisitorlogFileWriting.txt");
            this._CommunityNewsRT = new CommunityNewsRT();
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
                    IID = Convert.ToInt64(StringCipher.Decrypt(Request.QueryString["ID"]).ToString());
                    LoadCommunityNewsReapeater();
                    LoadListViewSingleAllNews();
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }     
        }
        private void LoadCommunityNewsReapeater()
         {
            try
            {
                //CommunityNewsRT _CommunityNewsRT = new CommunityNewsRT();
                var objNews = _CommunityNewsRT.GetNewsType(IID);
                foreach (var cn in objNews)
                {
                     ltrType.Text = cn.NewsType;
                        ltrDate.Text = cn.PublishDate.ToString("dd-MMM-yyyy");
                        //ltrtype.Text = objGuide.BussinessTypeName;
                        ltrTitle.Text = cn.HeadLine;
                        ltrDes.Text = cn.NewsDescription;
                       
                        img_Guide.ImageUrl = cn.Image;

                    if(cn.IsOnlyVideo==true && cn.VideoLink!=null){
                      // iframe 
                      //  cn.VideoLink;
                    }
                        ltrNewsType.Text = cn.NewsType;
                   
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }  
        }

        private void LoadListViewSingleAllNews()
          {
              try
              {
                  lvAllCommunityNews.DataSource = _CommunityNewsRT.GetAllDetailByNewsTypeIID(IID); ;
                  lvAllCommunityNews.DataBind();
              }
              catch (Exception ex)
              {
                  LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
              } 
          }

        protected void dataPagerAllCommunityNews_PreRender(object sender, EventArgs e)
          {
              try
              {
                  lvRowCount = currentPage * 10;
                  if (IsPostBack)
                  {
                      LoadListViewSingleAllNews();
                  }
              }
              catch (Exception ex)
              {
                  LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
              }
          }
          protected void lvAllCommunityNews_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
          {
              currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
          }
    }

    
}