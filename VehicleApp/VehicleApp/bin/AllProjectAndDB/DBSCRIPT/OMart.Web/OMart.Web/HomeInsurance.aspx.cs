using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Basic;
using Utilities;

namespace OMart.Web
{
    public partial class HomeInsurance : System.Web.UI.Page
    {
         private readonly string _visitorLogPath;
        private string _pageLogPath;
        private readonly BIDefaultRT _biDefaultRt;
        private readonly HomeInsuranceRT _homeInsuranceRt;
        public HomeInsurance()
        {
            this._visitorLogPath = Server.MapPath("~/Log file/VisitorlogFileWriting.txt");
            this._biDefaultRt=new BIDefaultRT();
            this._homeInsuranceRt=new HomeInsuranceRT();
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
                  //  GetFeatureByInsurance();
                    LoadOtherInsuranceLinks();
                    LoadInsuranceCompanyLogo();
                    LoadGuideLineForBiInsurance();
                    LoadInsuranceNews();

                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }

        }

        private void LoadInsuranceNews()
        {
            try
            {
                var insuranceNewsList = _homeInsuranceRt.GetHomeIsuranceNewsList();
                repInsuranceNews.DataSource = insuranceNewsList;
                repInsuranceNews.DataBind();
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private void LoadGuideLineForBiInsurance()
        {
            try
            {
                var insuranceGuideLineList = _biDefaultRt.GetGuideLinesForBiInsurance();
                repBiInsuranceGuideLine.DataSource = insuranceGuideLineList;
                repBiInsuranceGuideLine.DataBind();
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private void LoadInsuranceCompanyLogo()
        {
            try
            {
                var insuranceCompanyList = _biDefaultRt.GetAllInsuranceCompany();
                repInsuranceCompanyLogo.DataSource = insuranceCompanyList;
                repInsuranceCompanyLogo.DataBind();
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private void LoadOtherInsuranceLinks()
        {
            try
            {
                var insuranceUrlList = _homeInsuranceRt.GetOtherInsuranceUrlList();
                repOtherInsurenceLinks.DataSource = insuranceUrlList;
                repOtherInsurenceLinks.DataBind();
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
       

        protected void parentRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    HiddenField hdFeatureID = e.Item.FindControl("hdAllFeatureIID") as HiddenField;
                    int id = Convert.ToInt32(hdFeatureID.Value.ToString());
                    using (AllFeatureRT rt = new AllFeatureRT())
                    {
                        var childFeature = rt.GetAllFeatureDetailsByFeatureID(id);
                        Repeater child = e.Item.FindControl("rptChildSecond") as Repeater;
                        child.DataSource = childFeature;
                        child.DataBind();
                    }


                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
        protected void lkbBussinessType_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lb = (LinkButton)sender;
                int featureID = Convert.ToInt32(lb.CommandArgument.ToString());
                Response.Redirect("AllFeatureMoreDetails?fID=" + StringCipher.Encrypt(featureID.ToString()), false);
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
    }
}