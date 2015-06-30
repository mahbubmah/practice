using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OB.DAL;
using OB.Utilities;
using OB.BLL.Basic;
using System.IO;
using Utilities;

namespace OB.Web
{
    public partial class CMSDetailPage : System.Web.UI.Page
    {
        Int64 Iid = default(Int64);
        string EncryptedID = default(string);
        private readonly string _visitorLogPath;
        private string _pageLogPath;
        public CMSDetailPage()
        {
            this._visitorLogPath = Server.MapPath("~/Log file/VisitorlogFileWriting.txt");

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string pageName = Path.GetFileName(Request.PhysicalPath);
            _pageLogPath = Server.MapPath("~/Log file/" + pageName + ".txt");
            if (!IsPostBack)
            {
                try
                {

                    //LogFileHelper.VisitorLogFileWritten(_visitorLogPath);
                    if (!string.IsNullOrEmpty(Request.QueryString["tp"]))
                    {



                        string EncryptedID = Request.QueryString["tp"];

                        Int64 DecrptedIid = Convert.ToInt64(StringCipher.Decrypt(EncryptedID));
                        Session["detailID"] = DecrptedIid.ToString();
                        bool reqIDIsValid = Int64.TryParse(DecrptedIid.ToString(), out Iid);
                        if (reqIDIsValid)
                        {
                            LoadAllFromCMSContent(Iid);

                        }
                        else
                        {
                            Response.Redirect("ErrorOccurs.html");
                        }

                    }
                }
                catch (Exception ex)
                {
                    LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
                }
            }
        }
        private void LoadAllFromCMSContent(long Iid)
        {
            try
            {
                using (cmsRT cmscontenat = new cmsRT())
                {

                    var adGiver = cmscontenat.GetCMsContentByCMSTypeID(Iid);
                    ltrlTitle.Text = adGiver.Title;
                    ltrlDesceiption.Text = adGiver.CMSDescription;
                    if (adGiver.ImageUrl != string.Empty && adGiver.ImageUrl != null)
                    {
                        imgCMS.ImageUrl = adGiver.ImageUrl;

                    }
                    else
                    {
                        imgCMS.Visible = false;
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