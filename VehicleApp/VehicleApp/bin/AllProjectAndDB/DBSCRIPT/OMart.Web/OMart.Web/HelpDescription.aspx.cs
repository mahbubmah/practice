using BLL.Basic;
using DAL;
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
    public partial class HelpDescription : System.Web.UI.Page
    {
       private readonly string _visitorLogPath;
        private string _pageLogPath;

        public HelpDescription()
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
                    LoadHelpAdviceContent();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void LoadHelpAdviceContent()
        {
            try
            {
                int helpIID = 0;
                if (!string.IsNullOrEmpty(Request.QueryString["option"]))
                {
                    helpIID = Convert.ToInt32(StringCipher.Decrypt(Request.QueryString["option"].ToString()));
                    using (HelpAdviceRT rt = new HelpAdviceRT())
                    {
                        HelpAdvice help = rt.GetHelpByIID(helpIID);
                        ltrTitle.Text = help.Title;
                        ltrDescription.Text = help.Description;

                        if(help.Image !=null)
                        {
                            img_inner.ImageUrl = help.Image;
                        }

                    }
                }

            }
            catch (Exception ex)
            {

                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }

        }
    }
}