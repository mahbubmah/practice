using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Basic;
using DAL;
using Utilities;
using System.IO;

namespace OMart.Web
{
    public partial class FeatureDescription : System.Web.UI.Page
    {
        private string _pageLogPath;
        private readonly AllFeatureRT _AllFeatureRT;

        public FeatureDescription()
        {
            _AllFeatureRT = new AllFeatureRT();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string pageName = Path.GetFileName(Request.PhysicalPath);
                _pageLogPath = Server.MapPath("~/Log file/" + pageName + ".txt");
                if(!IsPostBack)
                {
                    GetFeatureByID();
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        #region private method
        private int GetQueryStringID()
        {
            int id = default(int);
            try
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    id = Convert.ToInt32(StringCipher.Decrypt(Request.QueryString["ID"]).ToString());
                }
                else
                {
                    // Response.Redirect("~/Mortgages.aspx", false);
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
            return id;
        }

        private void GetFeatureByID()
        {
            try
            {
                {
                    AllFeature Feature = _AllFeatureRT.GetAllFeatureById(GetQueryStringID());
                    ltrtype.Text = EnumHelper.EnumToString<Utilities.EnumCollection.BussinessType>(Feature.BusinessTypeID);
                    ltrTitle.Text = Feature.TitleName;
                    ltrDes.Text = Feature.Description;
                    if (Feature.ImageUrl != null)
                    {
                        img_Feature.ImageUrl = Feature.ImageUrl;
                    }
                    else
                    {
                        img_Feature.ImageUrl = "~/Images/Interfaces/noimage.jpg";
                    }

                    var details = _AllFeatureRT.GetAllFeatureByBussiTypeID(Feature.BusinessTypeID);
                  lvAllFeature.DataSource = details;
                  lvAllFeature.DataBind();
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
        #endregion private method
    }
}