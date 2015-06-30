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
    public partial class Default : System.Web.UI.Page
    {
        List<DefaultRT.DefaultPageModuleDisplay> aUrlWfLists = new List<DefaultRT.DefaultPageModuleDisplay>();
        private readonly VisitorIPMACAddress _visitorIPMACAddress; // Hasan Add 2015.04.26
        private readonly AllNewsRT _allNewsRT; // Hasan Add 2015.04.26
        private readonly string _visitorLogPath;
        private string _pageLogPath;
      

        public Default()
        {
            this._visitorLogPath = Server.MapPath("~/Log file/VisitorlogFileWriting.txt");
            this._visitorIPMACAddress = new VisitorIPMACAddress();
            this._allNewsRT = new AllNewsRT();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string pageName = Path.GetFileName(Request.PhysicalPath);
                _pageLogPath = Server.MapPath("~/Log file/" + pageName + ".txt");
                LoadAllFeature(); 
                if (!IsPostBack)
                {
                    // LoadModuleRepeater();
                    LogFileHelper.VisitorLogFileWritten(_visitorLogPath);
                    GetTopFourFeature(); 
                    LoadGuideLineReapeater();
                    LoadLogInfoImages();
                    LoadLatestAllNewsForListView();  // Hasan 2015.04.26
                    LoadHelpAdvice();
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private void LoadLatestAllNewsForListView()
        {
            try
            {
                lvLatestAllNews.DataSource = _allNewsRT.GetAllDistinctParentBusinessType();
                lvLatestAllNews.DataBind();
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }

        }
      

        private void LoadLogInfoImages()
        {
            try
            {
                using (AdLogInfoRT rt = new AdLogInfoRT())
                {
                    var logInfo = rt.GetAllAdLogInfo();
                    rptLogInfoImages.DataSource = logInfo;
                    //rptLogInfoImages_ItemDataBound.DataSource = mortgageProvider;
                    rptLogInfoImages.DataBind();
                }

            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        
        }

        protected void lnkBtnLogInfoCompanies_Click(object sender, EventArgs e)
        {
            try
            {
                //LinkButton lb = (LinkButton)sender;
                //string webAddress = lb.CommandArgument.ToString();
             //   List<AdLogInfo> logInfo = new List<AdLogInfo>();
               // using (AdLogInfoRT alog = new AdLogInfoRT())
               // LinkButton lb=new LinkButton();
                //logInfo = alog.GetAllAdLogInfo();
               // Response.Redirect(webAddress,false);
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        protected void rptLogInfoImages_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            // GetAllMortgagePrivider();
        }

       



        protected void lvModuleWithWFUrlsDisplay_OnItemDataBound(object sender, ListViewItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListViewItemType.DataItem)
                {
                    HiddenField objHdCount = e.Item.FindControl("hdModuleCount") as HiddenField;
                    int count = Convert.ToInt32(objHdCount.Value);

                    Repeater objRepeater = e.Item.FindControl("repModuleUrlLinkList") as Repeater;
                    objRepeater.DataSource = aUrlWfLists.SingleOrDefault(x => x.Count == count).ModuleLinkList;
                    objRepeater.DataBind();
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
                GuideLineRT _GuideLineWithDetailsRT = new GuideLineRT();
                var objGuide = _GuideLineWithDetailsRT.GetAllGuideType().Take(4).ToList();
                if (objGuide.Count > 0)
                {
                    rpGuideLine.DataSource = objGuide;
                    rpGuideLine.DataBind();

                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        protected void rpGuideLine_OnItemDataBound(object source, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    Literal objltrGuide = (Literal)e.Item.FindControl("lblGuideLineTypeName");
                    objltrGuide.Text = objltrGuide.Text.Trim();

                    Literal objltrGuideTypeDescription = (Literal)e.Item.FindControl("ltrGuideTypeTitle");
                    objltrGuideTypeDescription.Text = objltrGuideTypeDescription.Text.Trim();
                 
                    Image objImage = ((Image)e.Item.FindControl("img_Ads"));
                    if (string.IsNullOrEmpty(objImage.ImageUrl.ToString()))
                    {
                        objImage.ImageUrl = objImage.ToString();
                        objImage.Width = 269;
                        objImage.Height = 230;
                    }

                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        protected void repChildBusiness_OnItemDataBound(object sender, ListViewItemEventArgs e)
        {
            try
            {
                if(e.Item.ItemType==ListViewItemType.DataItem)
                {
                    HiddenField businessTypeID = e.Item.FindControl("hdBusinessTypeID") as HiddenField;
                    var allNewsForChild = _allNewsRT.GetAllNewsListByBusinessTypeID(Convert.ToInt32(businessTypeID.Value));
                  

                    Repeater repObj = e.Item.FindControl("repChildBusiness") as Repeater;

                    repObj.DataSource = allNewsForChild;
                    repObj.DataBind();
                }

            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }

        }
        private void GetTopFourFeature()
        {
            try
            {
                using (AllFeatureRT rt = new AllFeatureRT())
                {
                    var featureList = rt.GetTopFourFeature();
                    rptParentFeature.DataSource = featureList;
                    rptParentFeature.DataBind();
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        
        }
        private void LoadAllFeature()
        {
            try
            {
                using (AllFeatureRT rt = new AllFeatureRT())
                {
                    List<BLL.Basic.AllFeatureRT.AllFeatureExtract> list = (List<BLL.Basic.AllFeatureRT.AllFeatureExtract>)rt.GetAllFeature();
                    if (list.Count > 0)
                    {
                        BLL.Basic.AllFeatureRT.AllFeatureExtract first = list[0];
                        lnkBtnTitle1.Text = first.BussinessTypeName;
                        ltrFeatureDescription.Text = first.Description.ToString();
                        lnkBtnTitle1.CommandArgument = first.IID.ToString();
                        lkbImageFirst.CommandArgument = first.IID.ToString();

                        if (first.ImageUrl != null)
                        {
                            img_AllFeatureFirst.ImageUrl = first.ImageUrl;
                        }
                        var childFeatureFirst = rt.GetAllFeatureByBussiTypeID((int)first.BusinessTypeBreakdownID);
                        childRepeaterFirst.DataSource = childFeatureFirst;
                        childRepeaterFirst.DataBind();
                        list.RemoveAt(0);
                        ParentRepeater.DataSource = list;
                        ParentRepeater.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
        protected void ParentRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    HiddenField hdFeatureID = e.Item.FindControl("hdAllFeatureIID") as HiddenField;
                    int id = Convert.ToInt32(hdFeatureID.Value.ToString());

                    using (AllFeatureRT rt = new AllFeatureRT())
                    {
                        AllFeature f = rt.GetAllFeatureById((int)id);
                        var childFeature = rt.GetAllFeatureByBussiTypeID(f.BusinessTypeID);
                        Repeater child = e.Item.FindControl("childRepeater") as Repeater;
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
        protected void lnkBtnTitle1_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lb = (LinkButton)sender;
                Int64 id = Convert.ToInt64(lb.CommandArgument.ToString());
                Response.Redirect("FeatureDescription.aspx?ID=" +StringCipher.Encrypt(id.ToString()), false);
            }
            catch (Exception ex)
            {

            }
        }
        protected void lkbTitle2_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lb = (LinkButton)sender;
                Int64 id = Convert.ToInt64(lb.CommandArgument.ToString());
                Response.Redirect("FeatureDescription.aspx?ID=" + StringCipher.Encrypt(id.ToString()), false);
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }

        }
        protected void lkbImage_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lb = (LinkButton)sender;
                Int64 id = Convert.ToInt64(lb.CommandArgument.ToString());
                Response.Redirect("FeatureDescription.aspx?ID=" + StringCipher.Encrypt(id.ToString()), false);
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
        protected void lkbImageFirst_Click(object sender, EventArgs e)
        {

            try
            {
                LinkButton lb = (LinkButton)sender;
                Int64 id = Convert.ToInt64(lb.CommandArgument.ToString());
                Response.Redirect("FeatureDescription.aspx?ID=" + StringCipher.Encrypt(id.ToString()), false);
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private void LoadHelpAdvice()
        { 
            try
            {
                using (HelpAdviceRT rt = new HelpAdviceRT())
                {
                    List<SP_GetTop2HelpAdviceResult> list = rt.GetTop2HelpHelpAdvice();
                    if (list.Count > 0)
                    {

                        lblHelpTitle1.Text = list[0].Title;
                        lblHelpTitle2.Text = list[1].Title;
                        if (imgHelpAdvice.ImageUrl != null)
                        {
                            imgHelpAdvice.ImageUrl = list[0].Image;
                        }
                        lblHelpDescription1.Text = list[0].Description;
                        lblHelpDescription2.Text = list[1].Description;
                        lkbHelpAdvice1.CommandArgument = list[0].IID.ToString();
                        lkbHelpAdvice2.CommandArgument = list[1].IID.ToString();
                    }
                }
            }
            catch(Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        protected void lkbHelpAdvice1_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lb = (LinkButton)sender;
                int helpID = Convert.ToInt32(lb.CommandArgument.ToString());
                Response.Redirect("HelpDescription?option="+StringCipher.Encrypt(helpID.ToString()));
            }catch(Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        protected void lkbHelpAdvice2_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lb = (LinkButton)sender;
                int helpID = Convert.ToInt32(lb.CommandArgument.ToString());
                Response.Redirect("HelpDescription?option=" + StringCipher.Encrypt(helpID.ToString()));
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }

        }
    }


}