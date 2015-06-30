using BLL.Basic;
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
    public partial class GuideLineDetails : System.Web.UI.Page
    {
        private readonly string _visitorLogPath;
        private string _pageLogPath;
        private readonly GuideLineRT _GuideLineRT;
        private long IID = default(Int64);
        public int lvRowCount { get; set; }
        public int currentPage { get; set; }

        public GuideLineDetails()
        {
            this._visitorLogPath = Server.MapPath("~/Log file/VisitorlogFileWriting.txt");
            this._GuideLineRT = new GuideLineRT();
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
                    LoadGuideLineReapeater();
                    LoadListViewSingleAllGuide();
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }     
        }
        private void LoadGuideLineReapeater()
         {
            try
            {
                //GuideLineRT _GuideLineRT = new GuideLineRT();
                var objGuide = _GuideLineRT.GetOneGuidesAllType(IID);
                if (objGuide.IID>0)
                {
                    lblGuideLineTypeName.Text = objGuide.BussinessTypeName;
                    ltrtype.Text = objGuide.BussinessTypeName;
                    ltrTitle.Text = objGuide.GuideTypeTitle;
                    ltrDes.Text = objGuide.GuideTypeDescription;
                    img_Guide.ImageUrl = objGuide.GuideTypeImage;

                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }  
        }

          private void LoadListViewSingleAllGuide()
          {
              try
              {
                  lvAllGuides.DataSource = _GuideLineRT.GetAllDetailByGuidLineIID(IID); ;
                  lvAllGuides.DataBind();
              }
              catch (Exception ex)
              {
                  LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
              } 
          }

          protected void dataPagerAllGuides_PreRender(object sender, EventArgs e)
          {
              try
              {
                  lvRowCount = currentPage * 10;
                  if (IsPostBack)
                  {
                      LoadListViewSingleAllGuide();
                  }
              }
              catch (Exception ex)
              {
                  LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
              }
          }
          protected void lvAllGuides_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
          {
              currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
          }
    }

    
}