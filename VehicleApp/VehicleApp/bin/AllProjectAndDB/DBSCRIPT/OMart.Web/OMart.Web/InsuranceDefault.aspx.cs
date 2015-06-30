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
    public partial class InsuranceDefault : System.Web.UI.Page
    {

        private readonly GuideLineRT _guideLineRT;
        private readonly AllNewsRT _allNewsRT;
        private readonly VisitorIPMACAddress _visitorIPMACAddress;
        private readonly string _visitorLogPath;
        private string _pageLogPath;
        public InsuranceDefault()
        {
            this._visitorIPMACAddress = new VisitorIPMACAddress();
            this._guideLineRT = new GuideLineRT();
            this._allNewsRT = new AllNewsRT();
            this._visitorLogPath = Server.MapPath("~/Log file/VisitorlogFileWriting.txt");
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                string pageName = Path.GetFileName(Request.PhysicalPath);
                _pageLogPath = Server.MapPath("~/Log file/" + pageName + ".txt");
                GetFeatureByInsurance();
                if (!IsPostBack)
                {
                    LogFileHelper.VisitorLogFileWritten(_visitorLogPath);
                    LoadInsuranceGuide();
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
                repInsuranceNews.DataSource = _allNewsRT.GetRandomAllNewsByBusinessTypeID(Convert.ToInt32(EnumCollection.BussinessType.Insurance));
                repInsuranceNews.DataBind();

            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }

        }

        private void LoadInsuranceGuide()
        {
            try
            {
                repInsuranceGuide.DataSource = _guideLineRT.GetRandomGuideLineByBusinessTypeID(Convert.ToInt32(EnumCollection.BussinessType.Insurance));
                repInsuranceGuide.DataBind();

            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }

        }
        private void LogFileWritten(string mssge, string stackTrace)
        {
            var datetime = DateTime.Now.ToString();
            try
            {
                string path = Server.MapPath("~/Resources/DefaultInnerPagelogFileWriting.txt");
                if (!File.Exists(path))
                {
                    File.Create(path).Dispose();
                    using (TextWriter tw = new StreamWriter(path))
                    {
                        var text = datetime + "   " + VisitorIPMACAddress.GetVisitorIPAddress() + "   " + mssge + "   " + stackTrace;
                        tw.WriteLine(text);

                        tw.Flush();
                        tw.Close();
                    }
                }
                else if (File.Exists(path))
                {
                    using (var tw = File.AppendText(path))
                    {
                        var text = datetime + "   " + VisitorIPMACAddress.GetVisitorIPAddress() + "   " + mssge + "   " + stackTrace;
                        tw.WriteLine(text);
                        tw.Flush();
                        tw.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                mssge = ex.Message.ToString();
                stackTrace = ex.StackTrace.ToString();
            }
        }

        private void GetFeatureByInsurance()
        {
            try
            {
                int insuranceID = Convert.ToInt32(Utilities.EnumCollection.BussinessType.Insurance);
                using (AllFeatureRT rt = new AllFeatureRT())
                {
                    List<BLL.Basic.AllFeatureRT.AllFeatureExtract> featureList = (List<BLL.Basic.AllFeatureRT.AllFeatureExtract>)rt.GetAllFeatureByBTypeID(insuranceID);
                    if (featureList.Count > 0)
                    {
                        BLL.Basic.AllFeatureRT.AllFeatureExtract first = featureList[0];
                        ltrTitle.Text = first.BusinessTypeBreakdownName;
                        ltrDescription.Text = first.Description;
                        lkbBussinessType.CommandArgument = first.IID.ToString();
                        if (first.ImageUrl != null)
                        {
                            img_AllFeatureFirst.ImageUrl = first.ImageUrl;
                        }
                        featureList.RemoveAt(0);
                        parentRepeater.DataSource = featureList;
                        parentRepeater.DataBind();
                        var featureDetails = rt.GetAllFeatureDetailsByFeatureID(first.IID);
                        rptChildFirst.DataSource = featureDetails;
                        rptChildFirst.DataBind();
                    }
                }

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
                LinkButton lb=(LinkButton)sender;
                int featureID = Convert.ToInt32(lb.CommandArgument.ToString());
                Response.Redirect("AllFeatureMoreDetails?fID="+StringCipher.Encrypt(featureID.ToString()), false);
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
    }
}