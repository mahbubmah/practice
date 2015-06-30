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
    public partial class BookInnerDetails : System.Web.UI.Page
    {
        private int _queryStringOfFictionTypeID = 0;
        private readonly string _visitorLogPath;
        private string _pageLogPath;

        public BookInnerDetails()
        {
            this._visitorLogPath = Server.MapPath("~/Log file/VisitorlogFileWriting.txt");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string pageName = Path.GetFileName(Request.PhysicalPath);
                _pageLogPath = Server.MapPath("~/Log file/" + pageName + ".txt");

                if(!IsPostBack)
                {
                    LogFileHelper.VisitorLogFileWritten(_visitorLogPath);
                    LoadAllFictionBooks(GetQueryForFictionType());
                }
             
                
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private int GetQueryForFictionType()
        {
            try
            {
                if (Request.QueryString != null && Request.QueryString.ToString() != string.Empty)
                {
                    if (!string.IsNullOrEmpty(Request.QueryString[0]))
                    {
                        _queryStringOfFictionTypeID = Convert.ToInt32(this.Request.QueryString["Type"].ToString());
                        if (_queryStringOfFictionTypeID > 0)

                            return Convert.ToInt32(_queryStringOfFictionTypeID);
                        else
                            return 0;
                    }
                    return 0;
                }
                else
                    return 0;
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
            return -1;
        }


        private void LoadAllFictionBooks(int fictionTypeID)
        {
            try
            {
                BookRT _BookRT = new BookRT();
                var objPub = _BookRT.GetAllFictionCategoryBook(fictionTypeID);
                if (objPub != null)
                {
                    rpAllFictionBook.DataSource = objPub;
                    rpAllFictionBook.DataBind();
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        protected void rpAllFictionBook_OnItemDataBound(object source, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    Literal objltrTitle = (Literal)e.Item.FindControl("ltrAuthorName");
                    objltrTitle.Text = objltrTitle.Text;

                    Literal objltrbookTitle = (Literal)e.Item.FindControl("ltrBookTitle");
                    objltrbookTitle.Text = objltrbookTitle.Text;

                    Literal objltrbookAbstract = (Literal)e.Item.FindControl("ltrAbstract");
                    objltrbookAbstract.Text = objltrbookAbstract.Text;
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        
    }
}