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
    public partial class AllNewsDetails : System.Web.UI.Page
    {
        private readonly string _visitorLogPath;
        private string _pageLogPath;
        private readonly AllNewsRT _allNewsRT;
        private int AllNewsIID = default(Int32);

        public AllNewsDetails()
        {
            this._visitorLogPath = Server.MapPath("~/Log file/VisitorlogFileWriting.txt");
            this._allNewsRT = new AllNewsRT();

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
                    AllNewsIID = GetQueryStringOfAllNewsID();
                    LoadAllNewsForBusinessTypeID(AllNewsIID);
                    LoadAllNewsByIID(AllNewsIID);
                } 
 
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }

        }

        #region Private Methods
        private int GetQueryStringOfAllNewsID()
        {
            return Convert.ToInt32 (StringCipher.Decrypt(Request.QueryString["ID"].ToString()));
        }

        private void LoadAllNewsByIID(int iID)
        {
            try 
            {
                var allNews =_allNewsRT.GetAllNewsByIid(iID);
                if(allNews.IID>0)
                {
                    lbltype.Text = _allNewsRT.GetNewsTypeNameByBusiessType(allNews.BusinessTypeID);
                    lblTitle.Text = allNews.TitleName;
                    lblDescription.Text = allNews.Description;
                    img.ImageUrl = allNews.ImageUrl;
                }
 
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private void LoadAllNewsForBusinessTypeID(int allNewsIID)
        {
            try
            {
                repAllTypeNews.DataSource = _allNewsRT.GetRandomNewsRowsByBusinessTypeID(_allNewsRT.GetAllNewsByIid(allNewsIID).BusinessTypeID);
                repAllTypeNews.DataBind();

            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }


        #endregion Private Methods


        #region Protected Events
        protected void objDataSourceNewsDetails_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            try
            {
                e.InputParameters["allNewsIid"] = GetQueryStringOfAllNewsID();
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        #endregion Protected Events
    }
} 