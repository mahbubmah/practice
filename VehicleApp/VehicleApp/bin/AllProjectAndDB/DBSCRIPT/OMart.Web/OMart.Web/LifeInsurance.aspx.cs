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
    public partial class LifeInsurance : System.Web.UI.Page
    {
        private readonly string _visitorLogPath;
        private string _pageLogPath;
        private readonly BIDefaultRT _biDefaultRt;
        private readonly LifeInsuranceRT _lifeInsuranceRt;
        public LifeInsurance()
        {
            this._visitorLogPath = Server.MapPath("~/Log file/VisitorlogFileWriting.txt");
            this._biDefaultRt = new BIDefaultRT();
            this._lifeInsuranceRt=new LifeInsuranceRT();
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
                var insuranceNewsList = _lifeInsuranceRt.GetLifeIsuranceNewsList();
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
                var insuranceGuideLineList = _lifeInsuranceRt.GetGuideLinesForLifeInsurance();
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
                var insuranceUrlList = _lifeInsuranceRt.GetOtherInsuranceUrlList();
                repOtherInsurenceLinks.DataSource = insuranceUrlList;
                repOtherInsurenceLinks.DataBind();
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        //private void GetFeatureByInsurance()
        //{
        //    try
        //    {
        //        int insuranceID = Convert.ToInt32(Utilities.EnumCollection.BussinessType.Insurance);
        //        using (AllFeatureRT rt = new AllFeatureRT())
        //        {
        //            List<BLL.Basic.AllFeatureRT.AllFeatureExtract> featureList = (List<BLL.Basic.AllFeatureRT.AllFeatureExtract>)rt.GetAllFeatureByBussiTypeID(insuranceID);
        //            if (featureList.Count > 0)
        //            {
        //                BLL.Basic.AllFeatureRT.AllFeatureExtract first = featureList[0];
        //                ltrTitle.Text = first.BusinessTypeBreakdownName;
        //                ltrDescription.Text = first.Description.ToString();
        //                if (first.ImageUrl != null)
        //                {
        //                    img_AllFeatureFirst.ImageUrl = first.ImageUrl;
        //                }
        //                featureList.RemoveAt(0);
        //                parentRepeater.DataSource = featureList;
        //                parentRepeater.DataBind();
        //                var featureDetails = rt.GetAllFeatureDetailListByAllFeatureId(first.IID);
        //                rptChildFirst.DataSource = featureDetails;
        //                rptChildFirst.DataBind();
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
        //    }

        //}

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