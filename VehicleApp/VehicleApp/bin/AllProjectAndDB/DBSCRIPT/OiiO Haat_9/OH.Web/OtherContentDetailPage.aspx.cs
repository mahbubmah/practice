using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OH.Utilities;
using System.Configuration;
using System.IO;
using OH.BLL.Basic;
using OH.DAL;
using System.Security.Cryptography;
using System.Text;

namespace OH.Web
{
    /// <summary>
    /// Author: Asiful Islam
    /// </summary>
    public partial class OtherContentDetailPage : System.Web.UI.Page
    {
        private readonly ConstantCollection _constantCollection;
        private readonly OtherContentRT _otherContentRT;
        private readonly VisitorIPMACAddress _visitorIPMACAddress;
        private readonly PictureRT _pictureRT;
        string EncryptedID = default(string);
        Int64 Iid = default(Int64);

        public string backURL { get; set; }

        public OtherContentDetailPage()
        {
            this._constantCollection = new ConstantCollection();
            this._otherContentRT = new OtherContentRT();
            this._pictureRT = new PictureRT();
            this._visitorIPMACAddress = new VisitorIPMACAddress();
        }
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["option"]))
                    {
                        backURL = Convert.ToString(Session["backURL"]);
                        href_backToPrevious_Page_content.HRef = backURL;
                        hrf_back_to_Destination.HRef = backURL;
                        string EncryptedID = Request.QueryString["option"];
                        Int64 DecrptedIid = Convert.ToInt64(StringCipher.Decrypt(EncryptedID));
                        bool reqIDIsValid = Int64.TryParse(DecrptedIid.ToString(), out Iid);
                        if (reqIDIsValid)
                        {
                            LoadOtherContentDetails(Iid);
                            //LoadRelatedLatestAds(Iid);
                        }
                        else
                        {
                            Response.Redirect("ErrorOccurs.html");
                        }
                    }

                    VisitorLogFileWritten();
                }
                catch (Exception ex)
                {
                    LogFileWritten(ex.Message, ex.StackTrace);
                }
            }
        }

        private void LoadOtherContentDetails(Int64 Iid)
        {
            try
            {
                
                 var objSingleContent = _otherContentRT.GetotherContentAccordingToId(Iid);
                //var objPictureList = _pictureRT.GetAllPicturesAccordingToMaterialID(Iid).OrderBy(x => x.IID).ToList();

                if (objSingleContent != null)
                {
                    if (!string.IsNullOrEmpty(objSingleContent.ImageUrl))
                    {
                        img_OtherContentDetails.ImageUrl = objSingleContent.ImageUrl;
                    }
                    else
                    {
                        img_OtherContentDetails.ImageUrl = _constantCollection.noImageUrl;
                    }
                    lbl_txt_Title.Text = objSingleContent.Title;
                    lbl_Short_Description.Text = objSingleContent.ShortDescription;
                    //lbl_Price_Text.Text = objSingleContent.Price > 0 ? Convert.ToString(Math.Round(objSingleContent.Price, 2)) : string.Empty;
                    ltr_Content_Detail_Description.Text = objSingleContent.DetailDescription;
                    //lbl_ID_Ads.Text = objSingleContent.Code;
                }

                //if (objPictureList.Count > 1)
                //{
                //    objPictureList.RemoveAt(0);
                //    rp_DetailPictures.DataSource = objPictureList;
                //    rp_DetailPictures.DataBind();
                //}

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

        private string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
    }
}