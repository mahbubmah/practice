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
    public partial class AllFeatureMoreDetails : System.Web.UI.Page
    {
        int lvRowCount = 0;
        int currentPage = 0;
        private string _pageLogPath;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string pageName = Path.GetFileName(Request.PhysicalPath);
                _pageLogPath = Server.MapPath("~/Log file/" + pageName + ".txt");
                if (!IsPostBack)
                {
                    GetAllDataForDisplay();

                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }

        }
        private void GetAllDataForDisplay()
        {
            try
            {

                using (AllFeatureRT rt = new AllFeatureRT())
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                    {
                        int detailsIID = Convert.ToInt32(StringCipher.Decrypt(Request.QueryString["ID"]).ToString());
                        List<AllFeatureDetail> list = rt.GetAllFeatureDetailListByDetailsIID(detailsIID);
                        if (list.Count > 0)
                        {
                            var obj = list[0];
                            int allFeatureID = obj.AllFeatureID;
                            AllFeature feature = rt.GetAllFeatureById(allFeatureID);
                            string bussinessTypeName = rt.GetNameWithSpace(feature.BusinessTypeID);
                            string bussinessTypeBrName = rt.ExtractEnumValue((int)feature.BusinessTypeID, (int)feature.BusinessTypeBreakdownID);
                            BussinessTypeBrName.Text = bussinessTypeBrName + " " + BussinessTypeBrName.Text;
                            lvAllFeatures.DataSource = list;
                        }
                    }
                    else if (!string.IsNullOrEmpty(Request.QueryString["fID"]))
                    {
                        int featureID = Convert.ToInt32(StringCipher.Decrypt(Request.QueryString["fID"]).ToString());
                        List<AllFeature> featurelist = rt.GetAllFeatureListById(featureID);
                        if (featurelist.Count > 0)
                        {
                            var obj = featurelist[0];
                            string bussinessTypeName = rt.GetNameWithSpace(obj.BusinessTypeID);
                            string bussinessTypeBrName = rt.ExtractEnumValue((int)obj.BusinessTypeID, (int)obj.BusinessTypeBreakdownID);
                            BussinessTypeBrName.Text = bussinessTypeBrName + " " + BussinessTypeBrName.Text;
                            lvAllFeatures.DataSource = featurelist;
                        }
                    }

                }
                lvAllFeatures.DataBind();

            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
        protected void lvAllFeatures_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            try
            {
                currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        protected void dataPagerAllFeature_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    GetAllDataForDisplay();
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
    }
}