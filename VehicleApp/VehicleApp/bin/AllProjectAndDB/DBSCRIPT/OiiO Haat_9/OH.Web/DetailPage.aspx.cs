using OH.BLL.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OH.Utilities;
using System.Configuration;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Runtime.Serialization.Json;
using GoogleMaps.LocationServices;
using System.Web.Script.Serialization;
using OH.DAL;

namespace OH.Web
{
    public partial class DetailPage : System.Web.UI.Page
    {
        private readonly ConstantCollection _constantCollection;
        private readonly CustomClientRT _customClientRT;
        private readonly VisitorIPMACAddress _visitorIPMACAddress;
        private readonly PictureRT _pictureRT;
        Int64 Iid = default(Int64);
        string EncryptedID = default(string);

        public string backURL { get; set; }

        public DetailPage()
        {
            this._constantCollection = new ConstantCollection();
            this._customClientRT = new CustomClientRT();
            this._pictureRT = new PictureRT();
            this._visitorIPMACAddress = new VisitorIPMACAddress();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                
                {
                    string currentMaterialURL = HttpContext.Current.Request.Url.AbsoluteUri;
                    Session["backMaterialURL"] = currentMaterialURL;
                    if (!string.IsNullOrEmpty(Request.QueryString["option"]))
                    {
                        backURL = Convert.ToString(Session["backURL"]);
                        href_backToPrevious_Page.HRef = backURL;
                        btnLnk_back.HRef = backURL;
                        string EncryptedID = Request.QueryString["option"];
                       
                        Int64 DecrptedIid = Convert.ToInt64(StringCipher.Decrypt(EncryptedID));
                        Session["detailID"] = DecrptedIid.ToString();
                        bool reqIDIsValid = Int64.TryParse(DecrptedIid.ToString(), out Iid);
                        if (reqIDIsValid)
                        {
                            LoadAdMaterialDetails(Iid);
                            LoadRelatedLatestAds(Iid);
                            LoadPhnNoFromMaterial(Iid);
                           
                        }
                        else
                        {
                            Response.Redirect("ErrorOccurs.html");
                        }
                        LoadGoogleMAP(Iid);
                    }

                    VisitorLogFileWritten();
                   
                }
                catch (Exception ex)
                {
                    LogFileWritten(ex.Message, ex.StackTrace);
                }
            }

        }
       

        private void LoadRelatedLatestAds(Int64 Iid)
        {
            try
            {
                var objSingleAd = _customClientRT.GetAdDetailsAccordingToId(Iid);

                var objRelatedAds = (from tr in _customClientRT.GetAllLatestAds()
                                     where tr.IID != Iid && tr.CategoryID == objSingleAd.CategoryID
                                     select tr).Take(6).ToList();

                if (objRelatedAds.Count > 0)
                {
                    rp_all_relateds.DataSource = objRelatedAds;
                    rp_all_relateds.DataBind();
                }
            }
            catch(Exception ex)
            {
                LogFileWritten(ex.Message, ex.StackTrace);
            }
        }

        private void LoadAdMaterialDetails(Int64 Iid)
        {
            try
            {
                var objSingleAd = _customClientRT.GetAdDetailsAccordingToId(Iid);
                var objPictureList = _pictureRT.GetAllPicturesAccordingToMaterialID(Iid).OrderBy(x => x.IID).ToList();

                if (objSingleAd != null)
                {
                    if (!string.IsNullOrEmpty(objSingleAd.ImageUrl))
                    {
                        img_AdDetailsup.ImageUrl = objSingleAd.ImageUrl;
                        
                        hrefImage2.HRef = objSingleAd.ImageUrl;
                      

                    }
                    else
                    {
                        img_AdDetailsup.ImageUrl = _constantCollection.noImageUrl;
                        
                        hrefImage2.HRef = objSingleAd.ImageUrl;
                     

                    }
                    lbl_txt_Title.Text = objSingleAd.TitleName;
                    lbl_Min_Description.Text = objSingleAd.BrandName + " " + objSingleAd.ModelName + " " + objSingleAd.ColorName;
                    lbl_Price_Text.Text = objSingleAd.Price > 0 ? Convert.ToString(Math.Round(objSingleAd.Price, 2)) : string.Empty;
                    ltr_Description_Ads.Text = objSingleAd.Description;
                    
                }

                if (objPictureList.Count > 1)
                {
                   // objPictureList.RemoveAt(0);
                    rp_DetailPictures.DataSource = objPictureList;
                    rp_DetailPictures.DataBind();
                }

            }
            catch (Exception ex)
            {
                LogFileWritten(ex.Message, ex.StackTrace);
            }
        }

    

        private void LogFileWritten(string mssge, string stackTrace)
        {
            var datetime = DateTime.Now.ToString();
            try
            {
                string path = Server.MapPath("~/Resources/DetailPagelogFileWriting.txt");
                if (!File.Exists(path))
                {
                    File.Create(path).Dispose();
                    using (TextWriter tw = new StreamWriter(path))
                    {
                        var text = datetime + "   " + _visitorIPMACAddress.GetVisitorIPAddress() + "   " + mssge + "   " + stackTrace;
                        tw.WriteLine(text);

                        tw.Flush();
                        tw.Close();
                    }
                }
                else if (File.Exists(path))
                {
                    using (var tw = File.AppendText(path))
                    {
                        var text = datetime + "   " + _visitorIPMACAddress.GetVisitorIPAddress() + "   " + mssge + "   " + stackTrace;
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
            var datetime = DateTime.Now.ToString();
            try
            {
                string path = Server.MapPath("~/Resources/DetailPageVisitorlogFileWriting.txt");
                if (!File.Exists(path))
                {
                    File.Create(path).Dispose();
                    using (TextWriter tw = new StreamWriter(path))
                    {
                        var text = datetime + "        " + _visitorIPMACAddress.GetVisitorIPAddress() + "        " + _visitorIPMACAddress.GetVisitorMACAddress();
                        tw.WriteLine(text);

                        tw.Flush();
                        tw.Close();
                    }
                }
                else if (File.Exists(path))
                {
                    using (var tw = File.AppendText(path))
                    {
                        var text = datetime + "        " + _visitorIPMACAddress.GetVisitorIPAddress() + "         " + _visitorIPMACAddress.GetVisitorMACAddress();
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

        public class ProgramAddresses
        {
            public ProgramAddresses()
            {
            }
            public string description { get; set; }
            public double lng { get; set; }
            public double lat { get; set; }
        }

        protected void LoadGoogleMAP(Int64 locationID)
        {
            MaterialRT _materialRT = new MaterialRT();
            try
            {
                List<ProgramAddresses> AddressList = new List<ProgramAddresses>();
                string FullAddress = _materialRT.GetLocationByIID(locationID);

                //  string FullAddress=null;
                ProgramAddresses MapAddress = new ProgramAddresses();
                MapAddress.description = FullAddress;
                var locationService = new GoogleLocationService();
                var point = locationService.GetLatLongFromAddress(FullAddress);
                MapAddress.lat = point.Latitude;
                MapAddress.lng = point.Longitude;
                AddressList.Add(MapAddress);
                string jsonString = new JavaScriptSerializer().Serialize(AddressList);
                //JsonSerializer<List<ProgramAddresses>>(AddressList);
                ScriptManager.RegisterArrayDeclaration(Page, "markers", jsonString);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "GoogleMap();", true);
            }

            catch (Exception ex)
            {
                LogFileWritten(ex.Message, ex.StackTrace);
            }
        }
        #region Asiful Islam

        protected void lnk_btn_Category_Inner_Click(object sender, EventArgs e)
        {
            try
            {
                var PictureList = _pictureRT.GetAllPicturesAccordingToMaterialID(Convert.ToInt64(Session["detailID"])).OrderBy(x => x.IID).ToList();
                LinkButton linkButton = new LinkButton();
                linkButton = (LinkButton)sender;
                int picID = (Convert.ToInt32(linkButton.CommandArgument));
                Picture picUrl = _pictureRT.getPicturebIID(picID);
                hrefImage2.HRef = picUrl.UrlAddress.ToString();
                img_AdDetailsup.ImageUrl = picUrl.UrlAddress;
                if (PictureList.Count > 1)
                {
                    // PictureList.RemoveAt(0);
                    rp_DetailPictures.DataSource = PictureList;
                    rp_DetailPictures.DataBind();
                }
            }
            catch (Exception ex)
            {
                LogFileWritten(ex.Message, ex.StackTrace);
            }
        }
        protected void btnFvrt_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserName"] == null)
                {
                    Response.Redirect("~/LoginPage");
                }
                else
                { 

                using (AdGiverRT receiverTransfer = new AdGiverRT())
                {
                    string userEmailId = Convert.ToString(Session["UserName"]);
                    AdGiver adgiverEmailId = receiverTransfer.GetAdGiverIDByEmail(userEmailId);

                    if (adgiverEmailId != null)
                    {
                        using (MyFavouriteRT receiverTransferMyfvrt = new MyFavouriteRT())
                        {
                            int MaterialID = Convert.ToInt32(Session["detailID"]);
                            MyFavourite EmailIDnMaterialID = receiverTransferMyfvrt.GetEmailIDnMaterialID(userEmailId, MaterialID);
                            MyFavourite myFvrt = CreatemyFavrt();
                            if (EmailIDnMaterialID==null)
                            {
                           
                            receiverTransferMyfvrt.AddMYFvrt(myFvrt);
                           
                                lblFvrt.Text = "You Add your Favourite Item Successfully...";
                                lblFvrt.ForeColor = System.Drawing.Color.DarkSlateBlue;
                                
                            }
                            else
                            {
                                lblFvrt.Text = "This Item is already added to your Favourite...";
                                lblFvrt.ForeColor = System.Drawing.Color.Red;
                                
                            }
                        }
                    }
                    else
                    {
                        lblFvrt.Text = "Data not Added...";
                        lblFvrt.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }
            catch (Exception ex)
            {
                lblFvrt.Text = "Error : " + ex.Message;
                lblFvrt.ForeColor = System.Drawing.Color.Red;
            }
        }

        private MyFavourite CreatemyFavrt()
        {
            MyFavourite MyFvrt = new MyFavourite();
            try
            {
                MyFvrt.MaterialID = Convert.ToInt32(Session["detailID"]);
                MyFvrt.UserLoginID = Convert.ToString(Session["UserName"]);
                MyFvrt.CreatedDate = DateTime.Now;
                MyFvrt.ReturnURL = Convert.ToString(Session["backMaterialURL"]);
            }
            catch (Exception ex)
            {
                lblFvrt.Text = "Error : " + ex.Message;
                lblFvrt.ForeColor = System.Drawing.Color.Red;
            }
            return MyFvrt;
        }

        protected void lnkContact_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "ContactInfo")
            {
                try
                {
                    lblContactNumber.Text = string.Empty;
                    lblEmail.Text = string.Empty;
                    int DetailID = Convert.ToInt32(e.CommandArgument);
                    hdContactInfo.Value = DetailID.ToString();
                    using (MaterialRT receiverTransfer = new MaterialRT())
                    {
                        Material adGiver = receiverTransfer.GetMaterialByIID(DetailID);
                        if ((adGiver.UserPhoneNumber != null && adGiver.UserEmail == null) || (adGiver.UserPhoneNumber != string.Empty && adGiver.UserEmail == string.Empty))
                        {
                            lblContactNumber.Text = "Phone No. " + adGiver.UserPhoneNumber;
                        }
                        else if ((adGiver.UserEmail != null && adGiver.UserPhoneNumber == null) || (adGiver.UserEmail != string.Empty && adGiver.UserPhoneNumber == string.Empty))
                        {
                            lblContactNumber.Text = "Email: " + adGiver.UserEmail;
                        }
                        else if ((adGiver.UserEmail != null && adGiver.UserPhoneNumber != null) && (adGiver.UserEmail != string.Empty && adGiver.UserPhoneNumber != string.Empty))
                        {
                            lblContactNumber.Text = "Phone No. " + adGiver.UserPhoneNumber;
                            lblEmail.Text = "Email: " + adGiver.UserEmail;
                        }
                        else
                        {
                            lblContactNumber.Text = "No Contact Info is provided";
                            lblContactNumber.ForeColor = System.Drawing.Color.CornflowerBlue;
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblFvrt.Text = "Error : " + ex.Message;
                    lblFvrt.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        private void LoadPhnNoFromMaterial(Int64 id)
        {
            using (MaterialRT adGRt = new MaterialRT())
            {

                var adGiver = adGRt.GetMaterialByIID(id);
                
                var loc = adGRt.GetLocationByMaterialIID(id);
                lblLocation.Text = loc.ToString();
                lbl_ID_Ads.Text = adGiver.Code;
                if(adGiver.WebSiteUrl!=null&&adGiver.WebSiteUrl!=string.Empty)
                {

                    hrefwebUrl.HRef = adGiver.WebSiteUrl;
                    lblwebUrl.Text = adGiver.WebSiteUrl;
                    lblWebsiteLink.Text = "Web Site: ";
                }

                if (adGiver.YoutubeUrl != null && adGiver.YoutubeUrl != string.Empty)
                {
                    hrefyouTubeUrl.HRef = adGiver.YoutubeUrl;
                    lblyoutube.Text = adGiver.YoutubeUrl;
                    lblYoutubelink.Text = "YouTube Link: ";
                }

                if ((adGiver.UserPhoneNumber != null && adGiver.UserEmail == null) || (adGiver.UserPhoneNumber != string.Empty && adGiver.UserEmail == string.Empty))
                {
                    lblContactNumber.Text = "Phone No. " + adGiver.UserPhoneNumber.Substring(0, 5) + "XXXXXX";
                    lnkContact.CommandArgument = adGiver.IID.ToString();
                }
                else if ((adGiver.UserEmail != null && adGiver.UserPhoneNumber == null) || (adGiver.UserEmail != string.Empty && adGiver.UserPhoneNumber == string.Empty))
                {
                    lblContactNumber.Text = "Email: " + adGiver.UserEmail.Substring(0, 5) + "XXXXXXXXXXX";
                    lnkContact.CommandArgument = adGiver.IID.ToString();
                }
                else if ((adGiver.UserEmail != null && adGiver.UserPhoneNumber != null)&& (adGiver.UserEmail != string.Empty && adGiver.UserPhoneNumber != string.Empty))
                {
                    lblContactNumber.Text = "Phone No. " + adGiver.UserPhoneNumber.Substring(0, 5) + "XXXXXX";
                    lblEmail.Text = "Email: " + adGiver.UserEmail.Substring(0, 5) + "XXXXXXXXXXX";
                    lnkContact.CommandArgument = adGiver.IID.ToString();
                }
                else
                {
                    lblContactNumber.Text = "";
                    lblContactNumber.ForeColor = System.Drawing.Color.CornflowerBlue;
                    lnkContact.CommandArgument = adGiver.IID.ToString();
                }
            }
        }
        #endregion
    }
}