using System.IO;
using BLL.Basic;
using OB.Utilities;
using OB.BLL.Basic;
using OB.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OB.BLL;
using Utilities;

namespace OB.Web
{
    public partial class OiiOBookDetailsInnerMasterPage : System.Web.UI.MasterPage
    {
        private long IID = default(Int64);
        private const string sessBookNewsLetter = "seEmailSubscribe";
        private string _pageLogPath;
      
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //this.FindControl("pnlAuthListSidebar").Visible = (this.Request.QueryString["Type"] == "authListPage");
            
             try
            {
                string pageName = Path.GetFileName(Request.PhysicalPath);
                _pageLogPath = Server.MapPath("~/Log file/" + pageName + ".txt");

                this.FindControl("pnlauthListleftSidebar").Visible = (this.Request.QueryString["Type"] == "authListPage");
                 LoadDefaultLoginLogout();
                if (!IsPostBack)
                {
                    IID = Convert.ToInt64(Request.QueryString["ID"]);
                   // LoadAuthor();
                    LoadPublisherLogo();
                    LoadCategory();
                    LoadDefaultPageUrl();
                    LoadLogoFtrInfo();
                    LoadCMSFooterManu();
                    loadVideo();
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
                    if (firstVideo.LastOrDefault().VideoLink != null && firstVideo.LastOrDefault().VideoLink != string.Empty)
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

        private void LoadCategory()
        {
            try
            {
                BookPublisherRT _BookPublisherRT = new BookPublisherRT();
                var objPub = _BookPublisherRT.GetAllFictionCategory().Take(10).ToList();
                if (objPub.Count > 0)
                {
                    if (this.FindControl("pnlNonFiction").Visible == true)
                    {
                        rpNonFictionCat.DataSource = objPub;
                        rpNonFictionCat.DataBind();
                    }
                    if (this.FindControl("pnlFiction").Visible == true)
                    {
                        rpFictionCat.DataSource = objPub;
                        rpFictionCat.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
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
                throw new Exception(ex.Message, ex);
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
                throw new Exception(ex.Message, ex);
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
                throw new Exception(ex.Message, ex);
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
                    
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        //private void LoadAuthor()
        //{
        //    try
        //    {
        //        BookRT _BookRT = new BookRT();
        //        var objAuthor = _BookRT.GetBookForDetails(IID);
        //        if (objAuthor != null)
        //        {
        //            ltrAuthorName.Text = objAuthor.AuthorName.ToString();
        //            ltrAbout.Text = objAuthor.AboutAuthor.ToString();
        //            img_Book.ImageUrl = objAuthor.AuthorImage;
        //            lnkAuthorMore.HRef = "BookAuthLists?ID=" + objAuthor.AuthorID;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex);
        //    }
        //}

        private BookNewsLetter CreateBookLetter()
        {
            Session["UserID"] = "1";
            BookNewsLetter BookLetter = new BookNewsLetter();
            try
            {
                if (hdIsEdit.Value == "true")
                {
                    //BookLetter.IID = Convert.ToInt32(hdEmailID.Value.ToString());
                    BookNewsLetterRT receiverTransfer = new BookNewsLetterRT();
                    BookNewsLetter emailSubscription = receiverTransfer.GetEmailSubscribrIDByEmail(txtEmailAdd.Text);
                    Session[sessBookNewsLetter] = emailSubscription;
                    // OiiONewsLetter EmailSubscribe = (OiiONewsLetter)Session[sessEmailSubscribe];
                    BookLetter.IID = emailSubscription.IID;
                }
                BookLetter.UserEmail = txtEmailAdd.Text.Trim();
                BookLetter.SubscribeDate = DateTime.Now;

                if (BookLetter.IID <= 0)
                {
                    BookLetter.CreatedBy = Convert.ToInt64(Session["UserID"]);
                    BookLetter.CreatedDate = GlobalRT.GetServerDateTime();
                }
                else
                {
                    //OiiOOther Oiioother = (OiiOOther)Session[sessOtherContent];
                    BookNewsLetter letter = (BookNewsLetter)Session[sessBookNewsLetter];
                    BookLetter.CreatedBy = letter.CreatedBy; ;
                    BookLetter.CreatedDate = letter.CreatedDate;
                    BookLetter.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                    BookLetter.ModifiedDate = GlobalRT.GetServerDateTime();
                }
                if (hdIsEdit.Value != "true")
                {
                    BookLetter.IsSubscribe = true;
                }
                else
                {
                    BookLetter.IsSubscribe = false;
                }
            }
            catch (Exception ex)
            {
                lblEmailSubscribe.Text = "Error : " + ex.Message;
                lblEmailSubscribe.ForeColor = System.Drawing.Color.Red;
            }
            return BookLetter;

        }

        protected void btn_subscribe_Click(object sender, EventArgs e)
        {
            try
            {
                lblEmailSubscribe.Text = string.Empty;

                using (BookNewsLetterRT receiverTransfer = new BookNewsLetterRT())
                {
                    List<BookNewsLetter> BookList = new List<BookNewsLetter>();
                    BookList = receiverTransfer.GetLetterListByEmail(txtEmailAdd.Text);
                    if (BookList != null && BookList.Count > 0)
                    {
                        string msg = "Email Name  " + txtEmailAdd.Text + " Already Exists!";
                        lblEmailSubscribe.Text = msg;
                        lblEmailSubscribe.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    //hdSave.Value = "true";
                    BookNewsLetter letter = CreateBookLetter();
                    receiverTransfer.AddBookLetter(letter);
                    if (letter.IID > 0)
                    {
                        lblEmailSubscribe.Text = "Data successfully saved...";
                        lblEmailSubscribe.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblEmailSubscribe.Text = "Data not saved...";
                        lblEmailSubscribe.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                lblEmailSubscribe.Text = "Error : " + ex.Message;
                lblEmailSubscribe.ForeColor = System.Drawing.Color.White;
            }

        }


       
           
        
        //
       
    }

}
