using BLL.Basic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;
using OB.Utilities;
using Utilities;

namespace OB.Web
{
    public partial class BookDetails : System.Web.UI.Page
    {
        private readonly BookRT _bookRt;
        private long IID = default(Int64);
        private readonly string _visitorLogPath;
        private string _pageLogPath;

        public BookDetails()
        {
            this._visitorLogPath = Server.MapPath("~/Log file/VisitorlogFileWriting.txt");
            _bookRt = new BookRT();
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

                    bool isValidId = Int64.TryParse(Request.QueryString["ID"], out IID);
                    if (isValidId)
                    {
                        LoadByAuthor();
                        //BindImages();
                        LoadMediaReviews();
                        LoadAuthor();
                        LoadModalBuyingOption();
                    }

                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private void LoadModalBuyingOption()
        {
            try
            {
                List<EnumModifier> enumModifierList=new List<EnumModifier>();
                var enumToList = EnumHelper.EnumToList<EnumCollection.BookStore>();
                foreach (ListItem listItem in enumToList)
                {
                    string url;
                    EnumModifier aEnumModifier=new EnumModifier();
                    aEnumModifier.Value = listItem.Value;
                    aEnumModifier.Name = listItem.Text;

                    if (Convert.ToInt16(listItem.Value)==Convert.ToInt16(EnumCollection.BookStore.Amazon))
                    {
                        OtherBookStoreDesModifier(listItem.Value, out url);
                        aEnumModifier.Description = url.IsNullOrWhiteSpace() ? StringEnum.GetStringValue(EnumCollection.BookStore.Amazon) : url;
                    }

                    else if (Convert.ToInt16(listItem.Value) == Convert.ToInt16(EnumCollection.BookStore.Asda))
                    {
                        OtherBookStoreDesModifier(listItem.Value, out url);
                        aEnumModifier.Description = url.IsNullOrWhiteSpace() ? StringEnum.GetStringValue(EnumCollection.BookStore.Asda) : url;
                    }

                    else if (Convert.ToInt16(listItem.Value) == Convert.ToInt16(EnumCollection.BookStore.Blackwell))
                    {
                        OtherBookStoreDesModifier(listItem.Value, out url);
                        aEnumModifier.Description = url.IsNullOrWhiteSpace() ? StringEnum.GetStringValue(EnumCollection.BookStore.Blackwell) : url;
                    }

                    else if (Convert.ToInt16(listItem.Value) == Convert.ToInt16(EnumCollection.BookStore.Book_Depository))
                    {
                        OtherBookStoreDesModifier(listItem.Value, out url);
                        aEnumModifier.Description = url.IsNullOrWhiteSpace() ? StringEnum.GetStringValue(EnumCollection.BookStore.Book_Depository) : url;
                    }

                    else if (Convert.ToInt16(listItem.Value) == Convert.ToInt16(EnumCollection.BookStore.Foyles))
                    {
                        OtherBookStoreDesModifier(listItem.Value, out url);
                        aEnumModifier.Description = url.IsNullOrWhiteSpace() ? StringEnum.GetStringValue(EnumCollection.BookStore.Foyles) : url;
                    }

                    else if (Convert.ToInt16(listItem.Value) == Convert.ToInt16(EnumCollection.BookStore.Hive))
                    {
                        OtherBookStoreDesModifier(listItem.Value, out url);
                        aEnumModifier.Description = url.IsNullOrWhiteSpace() ? StringEnum.GetStringValue(EnumCollection.BookStore.Hive) : url;
                    }

                    else if (Convert.ToInt16(listItem.Value) == Convert.ToInt16(EnumCollection.BookStore.Sainsbury))
                    {
                        OtherBookStoreDesModifier(listItem.Value, out url);
                        aEnumModifier.Description = url.IsNullOrWhiteSpace() ? StringEnum.GetStringValue(EnumCollection.BookStore.Sainsbury) : url;
                    }

                    else if (Convert.ToInt16(listItem.Value) == Convert.ToInt16(EnumCollection.BookStore.Tesco))
                    {
                        OtherBookStoreDesModifier(listItem.Value, out url);
                        aEnumModifier.Description = url.IsNullOrWhiteSpace() ? StringEnum.GetStringValue(EnumCollection.BookStore.Tesco) : url;
                    }

                    else if (Convert.ToInt16(listItem.Value) == Convert.ToInt16(EnumCollection.BookStore.WH_Smith))
                    {
                        OtherBookStoreDesModifier(listItem.Value, out url);
                        aEnumModifier.Description = url.IsNullOrWhiteSpace() ? StringEnum.GetStringValue(EnumCollection.BookStore.WH_Smith) : url;
                    }
                    else if (Convert.ToInt16(listItem.Value) == Convert.ToInt16(EnumCollection.BookStore.Waterstones))
                    {
                        OtherBookStoreDesModifier(listItem.Value, out url);
                        aEnumModifier.Description = url.IsNullOrWhiteSpace() ? StringEnum.GetStringValue(EnumCollection.BookStore.Waterstones) : url;
                    }
                    enumModifierList.Add(aEnumModifier);
                }
                //book format string
                var bookFeatureList = _bookRt.GetAllBookFeatureByBookId(IID).ToList();
                string bookAvailableFormat = string.Empty;
                List<string> bookAvailableFormatList = new List<string>();
                foreach (var booksFeature in bookFeatureList)
                {
                   // string bookWishType = booksFeature.BookWishTypeID.ToString();
                   // bookAvailableFormatList.Add(bookWishType);
                }
                string bookwishId=string.Empty;
                foreach (var bookWishTypeId in bookAvailableFormatList)
                {
                    if (bookWishTypeId!=bookwishId)
                    {
                        if (!bookwishId.IsNullOrWhiteSpace())
                        {
                          bookAvailableFormat += ", ";
                        }
                        bookAvailableFormat += Enum.Parse(typeof (EnumCollection.BookWishType), bookWishTypeId);
                        bookwishId = bookWishTypeId;
                    }
                  
                }
                lbModalBookAvailableFormat.Text = bookAvailableFormat;

                var book = _bookRt.GetBookByIID(IID);
                lbModalAuthorName.Text = book.BookAuthor.AuthorName;
                lbModalBookEanNo.Text = book.ISBN.ToString();
                lbModalBookPrice.Text = book.Price.ToString("0.##");
                imgModalBookImage.ImageUrl = book.ImageUrl;




                rptOthorStoreLink1.DataSource = enumModifierList.Take(5);
                rptOthorStoreLink1.DataBind();

                rptOthorStoreLink2.DataSource = enumModifierList.Skip(5);
                rptOthorStoreLink2.DataBind();
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private void OtherBookStoreDesModifier(string value,out string url)
        {
            try
            {
                url = string.Empty;
                var bookFeatureList = _bookRt.GetAllBookFeatureByBookId(IID).ToList();
                foreach (var booksFeature in bookFeatureList)
                {
                    //if (booksFeature.BookAvailableStoreID != null)
                    //{
                    //    if (booksFeature.BookAvailableStoreID.ToString()==value)
                    //    {
                    //        url = booksFeature.BookAvailableUrl;
                    //    }
                    //}
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message,ex);
            }
        }

        private void LoadMediaReviews()
        {
            try
            {
                var mediaReviews = _bookRt.GetAllMediaReviewsByBookId(IID);

                rptMediaReviews.DataSource = mediaReviews;
                rptMediaReviews.DataBind();

            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private void LoadAuthor()
        {
            try
            {
                BookRT _BookRT = new BookRT();
                var objBook = _BookRT.GetBookForDetails(IID);
                if (objBook != null)
                {
                    ltrAuthorNameRight.Text = objBook.AuthorName.ToString();
                    ltrAbout.Text = objBook.AboutAuthor.ToString();
                    img_Book_Authr.ImageUrl = objBook.AuthorImage;
                    lnkAuthorMore.HRef = "BookAuthLists?ID=" + objBook.AuthorID;

                    ancAuthLink1.HRef = "AuthBiographyPage?ID=" + objBook.AuthorID;
                    ancAuthLink2.HRef = "AuthBiographyPage?ID=" + objBook.AuthorID;
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
        //public void BindImages()
        //{
        //     try
        //    {
        //    BookRT _BookRT = new BookRT();
        //    var objBooks = _BookRT.GetBookForDetails(IID);

        //    string filePaths = Server.MapPath(objBooks.ImageUrl.ToString());
        //    List<ListItem> files = new List<ListItem>();

        //    files.Add(new ListItem(Path.GetFileName(filePaths), filePaths));

        //    dListImages.DataSource = files;
        //    dListImages.DataBind();
        //    }
        //     catch (Exception ex)
        //     {
        //         throw new Exception(ex.Message, ex);
        //     }
        //}   
        private void LoadByAuthor()
        {
            try
            {
                BookRT _BookRT = new BookRT();
                var objBooks = _BookRT.GetBookForDetails(IID);
                if (objBooks != null)
                {
                    lblBookAbstruct.Text = objBooks.Abstract;

                    ltrBookTitle.Text = objBooks.BookTitle.ToString();
                    ltrAuthorName.Text = objBooks.AuthorName.ToString();
                    ltrPublisherName.Text = objBooks.PublisherName.ToString();
                    ltrBookName.Text = objBooks.BookTitle.ToString();
                    img_Book.ImageUrl = objBooks.ImageUrl;
                    large_Image.ImageUrl = objBooks.ImageUrl;
                    large_Image.Height = 500;
                    large_Image.Width = 500;
                    modalLtr.Text = objBooks.BookTitle.ToString();
                    modalAuth.Text = objBooks.AuthorName.ToString();
                    modalPub.Text = objBooks.PublisherName.ToString();
                    // largeImg.ImageUrl= objBooks.ImageUrl;
                    ltrwishtype.Text = objBooks.BookWishType.ToString();
                    rpByAuthor.DataSource = _BookRT.GetBooksByThisAuthor(objBooks.AuthorName.ToString());
                    rpByAuthor.DataBind();
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
        protected void rpByAuthor_OnItemDataBound(object source, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    Image objimg_Book = (Image)e.Item.FindControl("img_Book");
                    objimg_Book.ImageUrl = objimg_Book.ImageUrl;

                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        protected void btnLoation_OnClick(object sender, EventArgs e)
        {
            try
            {

                string mapLink = "https://www.google.com.bd/maps/search/bookstore+near+" + txtLocaton.Text;
                Response.Redirect(mapLink, false);
                Context.ApplicationInstance.CompleteRequest();

            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
    }
}