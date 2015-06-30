using System.IO;
using System.Xml;
using System.Xml.Linq;
using BLL.Basic;
using OB.Utilities;
using OB.DAL;
using OB.BLL.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OH.BLL.Basic;
using Utilities;

namespace OB.Web
{
    public partial class OiiOInnerMasterPage : System.Web.UI.MasterPage
    {
        private string _queryStringOfFictionType = string.Empty;
        private string _pageLogPath;
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.FindControl("pnlFiction").Visible = (this.Request.QueryString["Type"] == "bookFinction");
            //this.FindControl("pnlNonFiction").Visible = (this.Request.QueryString["Type"] == "bookNonFinction");
            try
            {
                string pageName = Path.GetFileName(Request.PhysicalPath);
                _pageLogPath = Server.MapPath("~/Log file/" + pageName + ".txt");

                LoadDefaultLoginLogout();
                if(!IsPostBack)
                {
                    
                    LoadDefaultPageUrl();
                    LoadPublisherLogo();
                    if (Session["FictionORnonFiction"]==null)
                    {
                        Session["FictionORnonFiction"] = Utilities.EnumCollection.ParentCategory.Fiction.ToString();

                    }
                   // LoadLiItems();
                    LoadCategory(Session["FictionORnonFiction"].ToString());
                    LoadPopular();
                    LoadLogoFtrInfo();
                    LoadCMSFooterManu();
                    loadVideo();




                    //LoadSiteMap();
                }

            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }

        }
        //private void LoadSiteMap()
        //{
        //    DefaultRT drt = new DefaultRT();
        //    string aa = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>";
        //    XNamespace ns = "http://schemas.microsoft.com/AspNet/SiteMap-File-1.0";
        //    var xml =  new XDocument(
        //            new XDeclaration("1.0", "UTF-8",null),
        //            new XElement(new XElement(ns + "siteMap",
        //                new XElement("siteMapNode",
        //                new XAttribute("title", "Home"),
        //                new XAttribute("url", "Default"),

        //                from node in DatabaseHelper.GetDataModelDataContext().UrlWFLists.ToList()
        //                select new XElement("siteMapNode",
        //                    new XAttribute("title", node.UrlWFDisplayName != "1" ? node.UrlWFDisplayName : "not valid"),
        //                    new XAttribute("url", node.UrlWFName)
        //                    ) 
        //                ))));

        //    SiteMapDataSource1.SiteMapProvider =aa+ xml;


        //}
        private void LoadLogoFtrInfo()
        {
            try
            {
                using (OiiOBookRT receiverTransfer = new OiiOBookRT())
                {
                    OiiOBook ContentActive = receiverTransfer.GetActiveContentForShow();
                    // lblftrAddress.Text = haatContentActive.Address;
                    lblftrPhn.Text = ContentActive.Phone;
                    lblftrEmail.Text = ContentActive.Email;
                    logoImg.ImageUrl = ContentActive.Logo;
                   
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
        private void LoadDefaultLoginLogout()
        {
            try
            {
                ulLoginOut.Visible = true;
                if (Session["UserName"] != null)
                {
                    ulLoginOutDirect.Visible = false;
                    var userText = Session["UserName"] != null ? Session["UserName"].ToString() : string.Empty;
                    lblUsername.Text = "Welcome " + userText + " !";
                    lbLogStatus.Text = Session["LoginStatus"] != null ? Session["LoginStatus"].ToString() : string.Empty;
                }
                else
                {
                    ulLoginOutDirect.Visible = true;
                    lblUsername.Text = string.Empty;
                    lbLogStatus.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
        private void loadVideo()
        {
            try
            {
                using (BookNewsRT receiverTransfer = new BookNewsRT())
                {
                    List<BookNews> firstVideo = receiverTransfer.GetActiveLeatestVideoForShow();
                    if (firstVideo.LastOrDefault().VideoLink!=null && firstVideo.LastOrDefault().VideoLink!=string.Empty)
                    {
                        iFrmVedioLink.Src = firstVideo.LastOrDefault().VideoLink;
                    }
                    else
                    {
                        iFrmVedioLink.Visible = false;
                    }
                  
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }

        }
        private void LoadCMSFooterManu()
        {
            try
            {
                List<EnumModifier> enumModifierList = new List<EnumModifier>();
                var enumMemberList = EnumHelper.EnumToList<EnumCollection.CMSType>();
                foreach (ListItem enumMember in enumMemberList)
                {
                    EnumModifier aEnumModifier = new EnumModifier();
                    aEnumModifier.Name = enumMember.Text;
                    aEnumModifier.Value = enumMember.Value;
                    enumModifierList.Add(aEnumModifier);
                }
                rptCMSMenu.DataSource = enumModifierList.Take(4); //objNavManu;
                rptCMSMenu.DataBind();

                rptService.DataSource = enumModifierList.Skip(4).Take(4);
                rptService.DataBind();
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        //private void LoadLiItems()
        //{
        //    try
        //    {
        //        this.FindControl("liBookFiction").Visible = false;
        //        this.FindControl("liBookNonFiction").Visible = false;
        //        this.FindControl("libookAuthors").Visible = false;
        //        this.FindControl("libookCompetitions").Visible = false;
        //        this.FindControl("libookNews").Visible = false;
        //        if (GetQueryStringValue() == Utilities.EnumCollection.ParentCategory.Fiction.ToString()
        //            || Session["FictionORnonFiction"].ToString() == Utilities.EnumCollection.ParentCategory.Fiction.ToString())
        //        {
        //            this.FindControl("liBookFiction").Visible = true;
        //        }
        //        else if (_queryStringOfFictionType == Utilities.EnumCollection.ParentCategory.Non_Fiction.ToString()
        //             || Session["FictionORnonFiction"].ToString() == Utilities.EnumCollection.ParentCategory.Non_Fiction.ToString())
        //        { 
        //            this.FindControl("liBookNonFiction").Visible = true;
        //        }
        //        else if (_queryStringOfFictionType == Utilities.EnumCollection.ParentCategory.authListPage.ToString()
        //            || Session["FictionORnonFiction"].ToString() == Utilities.EnumCollection.ParentCategory.authListPage.ToString())
        //        {  
        //            this.FindControl("libookAuthors").Visible = true;
        //        }
        //        else if (_queryStringOfFictionType == Utilities.EnumCollection.ParentCategory.bookCompetitions.ToString()
        //             || Session["FictionORnonFiction"].ToString() == Utilities.EnumCollection.ParentCategory.bookCompetitions.ToString())
        //        {
        //            this.FindControl("libookCompetitions").Visible = true;
        //        }
        //        else if (_queryStringOfFictionType == Utilities.EnumCollection.ParentCategory.booksNews.ToString()
        //            || Session["FictionORnonFiction"].ToString() == Utilities.EnumCollection.ParentCategory.booksNews.ToString())
        //        {
        //            this.FindControl("libookNews").Visible = true;
        //        }

        //        if (Session["FictionORnonFiction"].ToString() != Utilities.EnumCollection.ParentCategory.Fiction.ToString()&&
        //            Session["FictionORnonFiction"].ToString() != Utilities.EnumCollection.ParentCategory.Non_Fiction.ToString())
        //        {
        //            rpFictionCat.Visible = false;
        //            pnlFiction.Visible = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
        //    }

        //}

        private string GetQueryStringValue()
        {
            try
            {
                if (Request.QueryString != null && Request.QueryString.ToString()!=string.Empty)
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["Type"]))
                    {
                        _queryStringOfFictionType = this.Request.QueryString["Type"].ToString();
                        if (_queryStringOfFictionType.Length>0)
                        {
                            Session["FictionORnonFiction"] = _queryStringOfFictionType.ToString();
                            return _queryStringOfFictionType;
                        }
                            
                        else
                            return string.Empty;
                    }
                    return string.Empty;
                }
                else
                    return string.Empty;

            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
            return null;
        }
        private void LoadDefaultPageUrl()
        {
            #region Default url loading

            hrfRegister.HRef = "~/UserRegistrationPage";
            hrfLogin.HRef = "~/LoginPage";

            #endregion
        }

        protected void lbLogStatus_OnClick(object sender, EventArgs e)
        {
            Session["LoginStatus"] = "Login";
            lblUsername.Text = string.Empty;
            ulLoginOut.Visible = false;
            ulLoginOutDirect.Visible = true;
            lbLogStatus.Text = string.Empty;
            Session["UserName"] = null;
            Session["ContestantID"] = null;
            Response.Redirect("~/LoginPage.aspx");

        }
        private void LoadCategory(string queryStringOfFictionType)
        {
            try
            {
                
                BookPublisherRT _BookPublisherRT = new BookPublisherRT();
                int fictionNameID =Convert.ToInt32 (EnumHelper.GetEnumValue<EnumCollection.ParentCategory>(queryStringOfFictionType));

                if(fictionNameID==Convert.ToInt32 (EnumCollection.ParentCategory.Fiction) || fictionNameID== Convert.ToInt32 (EnumCollection.ParentCategory.Non_Fiction))
                {
                    var objPub = _BookPublisherRT.GetAllFictionCategory(fictionNameID).Take(10).ToList();
                    if (objPub.Count > 0)
                    {
                        string fictionTypeName = EnumHelper.EnumToStringWithSpace<EnumCollection.ParentCategory>(fictionNameID);
                        lFictionTypeName.Text = fictionTypeName;
                        rpFictionCat.DataSource = objPub;
                        rpFictionCat.DataBind();

                        //if (this.FindControl("pnlNonFiction").Visible == true)
                        //{
                        //    rpNonFictionCat.DataSource = objPub;
                        //    rpNonFictionCat.DataBind();
                        //}
                        //if (this.FindControl("pnlFiction").Visible == true)
                        //{
                        //    rpFictionCat.DataSource = objPub;
                        //    rpFictionCat.DataBind();
                        //}
                    }
                }

            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        protected void rpFictionCat_OnItemDataBound(object source, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    Literal objltrTitle = (Literal)e.Item.FindControl("ltrCategoryName");
                    objltrTitle.Text = objltrTitle.Text;
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
        protected void rpNonFictionCat_OnItemDataBound(object source, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    Literal objltrTitle = (Literal)e.Item.FindControl("ltrCategoryName");
                    objltrTitle.Text = objltrTitle.Text;
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
        private void LoadPublisherLogo()
        {
            try
            {
                BookPublisherRT _BookPublisherRT = new BookPublisherRT();
                var objPub = _BookPublisherRT.GetAllLogo().Take(6).ToList();
                if (objPub.Count > 0)
                {
                    //Repeater rpPublisher = (Repeater)Page.FindControl("rpPublisher");
                    rpPublisherLogo.DataSource = objPub;
                    rpPublisherLogo.DataBind();
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        protected void rpPublisherLogo_OnItemDataBound(object source, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {

                    Image objImage = ((Image)e.Item.FindControl("img_PublisherLogo"));
                    if (!string.IsNullOrEmpty(objImage.ImageUrl.ToString()))
                    {
                        objImage.ImageUrl = objImage.ImageUrl.ToString();
                        objImage.Width = 80;
                        objImage.Height = 75;
                    }

                    //Literal objltrTitle = (Literal)e.Item.FindControl("ltrPublisherName");


                    //objltrTitle.Text = objltrTitle.Text;

                    //Literal objltrDescription = (Literal)e.Item.FindControl("ltrForSaleDescription");
                    //if (objltrDescription.Text.Length > 25)
                    //{
                    //    var text = objltrDescription.Text.Substring(0, 25);
                    //    objltrDescription.Text = text;
                    //    // objltrDescription.Text = text.Substring(0,text.LastIndexOf(" "));
                    //}
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private void LoadPopular()
        {
            try
            {
                BookRT _BookRT = new BookRT();
                var objPub = _BookRT.GetAllCategoryBook();
                if (objPub != null)
                {
                    rpPopularBook.DataSource = objPub;
                    rpPopularBook.DataBind();
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        protected void rpPopularBook_OnItemDataBound(object source, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    Literal objltrTitle = (Literal)e.Item.FindControl("ltrAuthorName");
                    objltrTitle.Text = objltrTitle.Text;

                    Literal objltrbookTitle = (Literal)e.Item.FindControl("ltrBookTitle");
                    objltrbookTitle.Text = objltrbookTitle.Text;
                   // objltrbookTitle.Text.ForeColor = System.Drawing.Color.Red;

                    Literal objltrbookAbstract = (Literal)e.Item.FindControl("ltrbookAbstract");
                    if (objltrbookAbstract.Text.Length>30)
                    {
                        objltrbookAbstract.Text = objltrbookAbstract.Text.Substring(0, 100) + "...";
                        
                    }
                 }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        protected void lnk_btn_Category_Lnk_Click(object sender, EventArgs e)
        {
             try
             {

                 LinkButton linkButton = new LinkButton();
                 linkButton = (LinkButton)sender;
                 int categoryID = (Convert.ToInt32(linkButton.CommandArgument));

                 if (Session["FictionORnonFiction"].ToString() == Utilities.EnumCollection.ParentCategory.Fiction.ToString())
                 {
                     Response.Redirect("BookFiction.aspx?Tp=" + StringCipher.Encrypt(categoryID.ToString()), false);
                 }
                 else if (Session["FictionORnonFiction"].ToString() == Utilities.EnumCollection.ParentCategory.Non_Fiction.ToString())
                 {
                     Response.Redirect("BookNonFiction.aspx?Tp=" + StringCipher.Encrypt(categoryID.ToString()), false);
                 }

             }
             catch (Exception ex)
             {
                 LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
             }
        }
    }
   
}
