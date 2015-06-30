using OH.BLL.Basic;
using OH.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Net;
using System.Text;
using OH.DAL;

namespace OH.Web
{
    public partial class Default : System.Web.UI.Page
    {
        private readonly CustomClientRT _customClientRT;
        private readonly ConstantCollection _constantCollection;
        private readonly VisitorIPMACAddress _visitorIPMACAddress;
        private readonly CategoryRT _categoryRT;
        public Default()
        {
            this._customClientRT = new CustomClientRT();
            this._categoryRT = new CategoryRT();
            this._constantCollection = new ConstantCollection();
            this._visitorIPMACAddress = new VisitorIPMACAddress();
        }

        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                 LoadNavManu();
                    GettingCurrentUrl();
                    LoadLatestSpotLightAds();
                    LoadLatestAds();
                    LoadLatestAdsForSale();
                    LoadOtherContent();
                    LoadBannerPic();
                    VisitorLogFileWritten();
                    ViewAll.HRef = "DefaultInner?tp=" + Utilities.StringCipher.Encrypt(EnumCollection.NavMenu.For_Sell.ToString().Replace("_"," "));
                }
                
            }
            catch (Exception ex)
            {
                LogFileWritten(ex.Message, ex.StackTrace);
            }
        }

        private void GettingCurrentUrl()
        {
            string currentURL = HttpContext.Current.Request.Url.AbsoluteUri;
            Session["backURL"] = currentURL;
        }

        private void LoadBannerPic()
        {
            try
            {
                using (BannerRT receiverTransfer = new BannerRT())
                {

                    var objPictureList = receiverTransfer.GetAllActiveBanners().OrderBy(x => x.IID).ToList();
                    var objPicture = receiverTransfer.GetFirstActiveBanners();
                    img_banner.ImageUrl = objPicture.ToString();


                    if (objPictureList.Count > 0&&objPicture!=null)
                    {
                        objPictureList.RemoveAt(0);
                        rp_BannerPictures.DataSource = objPictureList;
                        rp_BannerPictures.DataBind();
                    }
                    else if(objPictureList.Count > 0 && objPicture==null)
                    {

                        rp_BannerPictures.DataSource = objPictureList;
                        rp_BannerPictures.DataBind();
                    }
                }

            }
            catch (Exception ex)
            {
                LogFileWritten(ex.Message, ex.StackTrace);
            }
        }
        private void LoadLatestAdsForSale()
        {
            try
            {
                var objLatestAds = new CustomClientRT().GetAllLatestRandomAdsForSale().ToList();
                if (objLatestAds.Count > 0)
                {
                    rpLatestForSale.DataSource = objLatestAds;
                    rpLatestForSale.DataBind();
                }
            }
            catch (Exception ex)
            {
                LogFileWritten(ex.Message, ex.StackTrace);
            }
        }

        protected void rpLatestForSale_OnItemDataBound(object source, RepeaterItemEventArgs e)
        {
            try
            {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                Image objImage = ((Image)e.Item.FindControl("img_AdForSales"));
                if (string.IsNullOrEmpty(objImage.ImageUrl.ToString()))
                {
                    objImage.ImageUrl = _constantCollection.noImageUrl;
                    objImage.Width = 272;
                    objImage.Height = 230;
                }

                Literal objltrTitleForSale = (Literal)e.Item.FindControl("ltrForSaleTitle");
                if (objltrTitleForSale.Text.Length > 20)
                {
                    var text = objltrTitleForSale.Text.Substring(0, 20);
                   objltrTitleForSale.Text = text;
                    //objltrTitleForSale.Text = text.Substring(0, text.LastIndexOf(" "));
                }
                //Literal objltrDescription = (Literal)e.Item.FindControl("ltrForSaleDescription");
                //if (objltrDescription.Text.Length > 25)
                //{
                //    var text = objltrDescription.Text.Substring(0, 25);
                //    objltrDescription.Text = text;
                //    // objltrDescription.Text = text.Substring(0,text.LastIndexOf(" "));
                //}
            }
            }
            catch(Exception ex)
            {
                LogFileWritten(ex.Message, ex.StackTrace);
            }
        }

        private void LoadLatestAds()
        {
            try
            {
                var objLatestAds = new CustomClientRT().GetAllLatestRandomAds().ToList();
                if(objLatestAds.Count>0)
                {
                    rpGetLatestFirstAds.DataSource = objLatestAds;
                    rpGetLatestFirstAds.DataBind();
                }
            }
            catch(Exception ex)
            {
                LogFileWritten(ex.Message, ex.StackTrace);
            }
        }

        protected void rpGetLatestFirstAds_OnItemDataBound(object source, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    Image objImage = ((Image)e.Item.FindControl("img_Ads"));
                    if (string.IsNullOrEmpty(objImage.ImageUrl.ToString()))
                    {
                        objImage.ImageUrl = _constantCollection.noImageUrl;
                        objImage.Width = 269;
                        objImage.Height = 230;
                    }

                    Literal objltrLatestFirstAds = (Literal)e.Item.FindControl("ltrLatestFirstAds");
                    if (objltrLatestFirstAds.Text.Length > 20)
                    {
                        var text = objltrLatestFirstAds.Text.Substring(0, 20);
                        objltrLatestFirstAds.Text = text;
                        //objltrLatestFirstAds.Text = text.Substring(0, text.LastIndexOf(" "));
                    }


                    //Literal objltrDescription = (Literal)e.Item.FindControl("ltrDescription");
                    //if (objltrDescription.Text.Length > 25)
                    //{
                    //    var text = objltrDescription.Text.Substring(0, 25);
                    //   objltrDescription.Text = text;
                    //    // objltrDescription.Text = text.Substring(0,text.LastIndexOf(" "));
                    //}

                }
            }
            catch (Exception ex)
            {
                LogFileWritten(ex.Message, ex.StackTrace);
            }
        }
        
        private void LoadLatestSpotLightAds()
        {
            try
            {
                var objSpotLight = _customClientRT.GetAllSpotLightAds().Take(4).ToList();
                if (objSpotLight.Count > 0)
                {
                    rpGetLatestSpotLightAds.DataSource = objSpotLight;
                    rpGetLatestSpotLightAds.DataBind();
                }
            }
            catch (Exception ex)
            {
                LogFileWritten(ex.Message, ex.StackTrace);
            }
        }

        protected void rpGetLatestSpotLightAds_OnItemDataBound(object source, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {

                    Image objImage = ((Image)e.Item.FindControl("img_SpotLight"));
                    if (string.IsNullOrEmpty(objImage.ImageUrl.ToString()))
                    {
                        objImage.ImageUrl = _constantCollection.noImageUrl;
                    }
                    Literal objltrDescription = (Literal)e.Item.FindControl("ltrTitleName");
                    if (objltrDescription.Text.Length > 20)
                    {
                        var text = objltrDescription.Text.Substring(0, 20);
                        objltrDescription.Text = text;
                        //objltrDescription.Text = text.Substring(0, text.LastIndexOf(" "));
                    }
                }
            }
            catch (Exception ex)
            {
                LogFileWritten(ex.Message, ex.StackTrace);
            }
        }

        private void LogFileWritten(string mssge, string stackTrace)
        {
            try
            {
                string path = Server.MapPath("~/Resources/DefaultPagelogFileWriting.txt");
                if (!File.Exists(path))
                {
                    File.Create(path).Dispose();
                    using (TextWriter tw = new StreamWriter(path))
                    {
                        var text = DateTime.Now.ToString() + "   " + _visitorIPMACAddress.GetVisitorIPAddress() + "   " + mssge + "   " + stackTrace;
                        tw.WriteLine(text);
                      
                        tw.Flush();
                        tw.Close();
                    }
                }
                else if (File.Exists(path))
                {
                    using (var tw = File.AppendText(path))
                    {
                        var text = DateTime.Now.ToString() + "   " + _visitorIPMACAddress.GetVisitorIPAddress() + "   " + mssge + "   " + stackTrace;
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

        private void VisitorLogFileWritten()
        {
           try
            {
                string path = Server.MapPath("~/Resources/VisitorlogFileWriting.txt");
                if (!File.Exists(path))
                {
                    File.Create(path).Dispose();
                    using (TextWriter tw = new StreamWriter(path))
                    {
                        var text = DateTime.Now.ToString() + "        " + _visitorIPMACAddress.GetVisitorIPAddress() + "        " + _visitorIPMACAddress.GetVisitorMACAddress();
                        tw.WriteLine(text);

                        tw.Flush();
                        tw.Close();
                    }
                }
                else if (File.Exists(path))
                {
                    using (var tw = File.AppendText(path))
                    {
                        var text = DateTime.Now.ToString() + "        " + _visitorIPMACAddress.GetVisitorIPAddress() + "         " + _visitorIPMACAddress.GetVisitorMACAddress();
                        tw.WriteLine(text);
                        tw.Flush();
                        tw.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                LogFileWritten(ex.Message, ex.StackTrace);
            }
        }

        #region Author : Asiful Islam
        protected void rp_OtherContent_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    Image objImage = ((Image)e.Item.FindControl("img_Others"));
                    if (string.IsNullOrEmpty(objImage.ImageUrl.ToString()))
                    {
                        objImage.ImageUrl = _constantCollection.noImageUrl;
                        objImage.Width = 269;
                        objImage.Height = 230;
                    }

                    Literal objltrDescription = (Literal)e.Item.FindControl("ltrDetailDescription");
                    if (objltrDescription.Text.Length > 40)
                    {
                        var text = objltrDescription.Text.Substring(0, 40);
                        objltrDescription.Text = text;
                        //  objltrDescription.Text = text.Substring(0, text.LastIndexOf(" "));
                    }

                    Literal objltrSrtDescription = (Literal)e.Item.FindControl("ltrShortDescription");
                    if (objltrSrtDescription.Text.Length > 45)
                    {
                        var text = objltrSrtDescription.Text.Substring(0, 45);
                         objltrSrtDescription.Text = text;
                        // objltrSrtDescription.Text = text.Substring(0, text.LastIndexOf(" "));
                    }

                }
            }
            catch (Exception ex)
            {
                LogFileWritten(ex.Message, ex.StackTrace);
            }
        }
        private void LoadOtherContent()
        {
            try
            {
                var objOtherContent = _customClientRT.GetOtherContent().Take(3).ToList();
                if (objOtherContent.Count > 0)
                {
                    rp_OtherContent.DataSource = objOtherContent;
                    rp_OtherContent.DataBind();
                }
            }
            catch (Exception ex)
            {
                LogFileWritten(ex.Message, ex.StackTrace);
            }
        }

        private void LoadNavManu()
        {
          


                try
                {
                    List<EnumModifier> enumModifierList = new List<EnumModifier>();
                    var enumMemberList = EnumHelper.EnumToList<EnumCollection.NavMenu>();
                    foreach (var enumMember in enumMemberList)
                    {
                        EnumModifier aEnumModifier = new EnumModifier();
                        string enumDisplayMember = enumMember.ToString();

                        string name = string.Empty;
                        string value = string.Empty;

                        switch (enumDisplayMember)
                        {
                            case "For Sell":
                                name = "For Sell";
                                value = "1";
                                break;
                            case "Jobs":
                                name = "Jobs";
                                value = "2";
                                break;
                            case "Property":
                                name = "Property";
                                value = "3";
                                break;
                            case "Motors":
                                name = "Motors";
                                value = "4";
                                break;
                            case "Services":
                                name = "Services";
                                value = "5";
                                break;
                            case "Community":
                                name = "Community";
                                value = "6";
                                break;
                        }
                        aEnumModifier.Name = name;
                        aEnumModifier.Value = value;
                       enumModifierList.Add(aEnumModifier);
                       
                    }
                  //  DropDownListHelper.Bind(dropDownConnectionTypeID, enumModifierList, "Name", "Value", EnumCollection.ListItemType.ConnectionType);

                    rptNavMenu.DataSource = enumModifierList; //objNavManu;
                    rptNavMenu.DataBind();

                
                //var objNavManu = _categoryRT.GetNavmenu().Take(6).ToList();
                //if (objNavManu.Count > 0)
                //{
                   
                //}
            }
            catch (Exception ex)
            {
                LogFileWritten(ex.Message, ex.StackTrace);
            }
        }
        #endregion

       
    }
}