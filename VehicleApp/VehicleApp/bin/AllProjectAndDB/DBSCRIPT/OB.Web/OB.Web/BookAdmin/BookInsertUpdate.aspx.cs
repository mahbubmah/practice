using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Basic;
using OB.Utilities;
using OB.DAL;
using OB.BLL.Basic;
using System.Globalization;
using System.Text;
using System.IO;
using OB.DAL;


namespace OMart.Web.BookAdmin
{
    public partial class BookInsertUpdate : System.Web.UI.Page
    {
        private readonly BookRT _BookRT;
        private string seBookFeature = "BookFeature";
        private long IID = default(Int64);

        //private const string seMPFeatureColl = "seMPFeatureColl";
        private const string sessBook = "seBook";
        public BookInsertUpdate()
        {
            this._BookRT = new BookRT();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    Session[sessBook] = null;
                    LoadDropDownBookPublisher(null);

                    LoadDropDownBookCategory(null);
                    LoadDropDownBookAuthor(null);
                    LoadDropDownWishType();

                    var requestId = Request.QueryString["IID"];
                    bool reqIDIsValid = Int64.TryParse(requestId, out IID);
                    if (reqIDIsValid)
                    {
                        ShowBookData();

                    }

                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        #region private methods

        #region load dropdown
        private void LoadDropDownBookPublisher(int? BookPublisherID)
        {
            try
            {
                using (BookPublisherRT receverTransfer = new BookPublisherRT())
                {
                    List<BookPublisher> BookPublisherList = new List<BookPublisher>();
                    if (BookPublisherID != null)
                    {
                        BookPublisherList.Add(receverTransfer.GetBookPublisherByIID((int)BookPublisherID));
                    }
                    else
                    {
                        BookPublisherList = receverTransfer.GetAllBookPublishers();
                    }
                    DropDownListHelper.Bind<BookPublisher>(DropDownPublisher, BookPublisherList, "PublisherName", "IID", EnumCollection.ListItemType.BookPublisher);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        /// <summary>
        /// auto complete...if available load otherwise insert author
        /// </summary>
        /// <param name="BookPublisherID"></param>
        private void LoadDropDownBookAuthor(int? BookAuthorID)
        {
            try
            {
                using (BookAuthorRT receverTransfer = new BookAuthorRT())
                {
                    List<BookAuthor> BookAuthorList = new List<BookAuthor>();
                    if (BookAuthorID != null)
                    {
                        BookAuthorList.Add(receverTransfer.GetBookAuthorByIID((int)BookAuthorID));
                    }
                    else
                    {
                        BookAuthorList = receverTransfer.GetAllBookAuthors();
                    }
                    DropDownListHelper.Bind<BookAuthor>(DropDownAuthor, BookAuthorList, "AuthorName", "IID", EnumCollection.ListItemType.BookAuthor);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        private void LoadDropDownBookCategory(int? categoryID)
        {
            try
            {
                using (BookCategoryRT receverTransfer = new BookCategoryRT())
                {
                    List<BooKCategory> CategoryList = new List<BooKCategory>();
                    if (categoryID != null)
                    {
                        CategoryList.Add(receverTransfer.GetBookCategoryByID((int)categoryID));
                    }
                    else
                    {
                        CategoryList = receverTransfer.GetBooKCategoryAll();
                    }
                    DropDownListHelper.Bind<BooKCategory>(dropDownCategory, CategoryList, "CategoryName", "IID", EnumCollection.ListItemType.BookCategory);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private void LoadDropDownWishType()
        {

            try
            {
                DropDownListHelper.Bind(ddlBookWishType, EnumHelper.EnumToList<EnumCollection.BookWishType>(), EnumCollection.ListItemType.BookWishType);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        #endregion load dropdown
        private bool TextControlCheckBeforeSave()
        {
            bool mandatoryFieldHasData = true;


            if (txtPostVisibilityDay.Text.Trim() == string.Empty)
            {
                labelMessage.Text = " How many days Post needs to visible.";
                labelMessage.ForeColor = System.Drawing.Color.Red;
                labelMessage.Focus();
                mandatoryFieldHasData = false;
            }

            if (txtPrice.Text.Trim() == string.Empty)
            {
                labelMessage.Text = " How Much This Phone Costs.";
                labelMessage.ForeColor = System.Drawing.Color.Red;
                labelMessage.Focus();
                mandatoryFieldHasData = false;
            }
            if (DropDownAuthor.SelectedValue == "-1")
            {
                labelMessage.Text = " Select Author of this Book";
                labelMessage.ForeColor = System.Drawing.Color.Red;
                labelMessage.Focus();
                mandatoryFieldHasData = false;
            }

            return mandatoryFieldHasData;
        }


        private void ShowBookData()
        {
            try
            {
                Book _Book = _BookRT.GetBookByIID(IID);

                if (_Book != null)
                {
                    DropDownPublisher.SelectedValue = Convert.ToString(_Book.PublisherID);
                    dropDownCategory.SelectedValue = Convert.ToString(_Book.CategoryID);
                    DropDownAuthor.SelectedValue = Convert.ToString(_Book.AuthorID);
                    txtBookTitle.Text = _Book.BookTitle != null ? _Book.BookTitle.ToString() : string.Empty;
                    txtQuantity.Text = _Book.Quantity != null ? _Book.Quantity.ToString() : string.Empty;
                    txtAbstract.Text = _Book.Abstract != null ? _Book.Abstract.ToString() : string.Empty;
                    txtPrice.Text = _Book.Price != null ? _Book.Price.ToString() : string.Empty;
                    txtISBN.Text = _Book.ISBN != null ? _Book.ISBN.ToString() : string.Empty;
                    txtPostVisibilityDay.Text = Convert.ToString(_Book.LastVisibilityDate) != null ? Convert.ToString(_Book.LastVisibilityDate) : string.Empty;
                    txtPublishedDate.Text = Convert.ToString(_Book.PublishedDate) != null ? Convert.ToString(_Book.PublishedDate) : string.Empty;
                    chkIsRecommended.Checked = _Book.IsRecommended;
                    chkIsLatest.Checked = _Book.IsLatest;
                   // chkIsRemoved.Checked = _Book.IsRemoved;
                    if (_Book.ImageUrl != null)
                    {
                        string absolutePath = _Book.ImageUrl;
                        // PictureUpload.ResolveClientUrl(absolutePath);
                    }

                   // LoadBookFeatureByBookID(IID);
                    
                }

            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        //private void  LoadBookFeatureByBookID(Int64 IID)
        //{
        //    using (BookRT rt = new BookRT())
        //    {
        //        List<BookOffer> featureList = rt.GetBooksFeatureByBookID(IID);
        //        lvBookFeature.DataSource = featureList;
        //        lvBookFeature.DataBind();
        //    }
        //}

        private string BusinessLogicValidation(Book book)
        {
            string message = string.Empty;
            bool reqIDIsValid = Int64.TryParse(Request.QueryString["IID"], out IID);

            if (IID <= 0)
            {
                Book objBookName = (from tr in _BookRT.GetAllBooks()
                                    where tr.BookTitle == book.BookTitle && tr.AuthorID == book.AuthorID && tr.Edition ==book.Edition && tr.PublisherID == book.PublisherID
                                    select tr).SingleOrDefault();
                if (objBookName != null)
                {
                    if (objBookName.BookTitle == book.BookTitle)
                    {
                        message = "Book already exists.";
                    }
                }


            }

            return message;
        }

        private Book CreateBook()
        {
            Session["UserID"] = "1";
            Book _Book = new Book();
            try
            {
                if (string.IsNullOrEmpty(dropDownCategory.SelectedValue))
                {
                    labelMessage.Text = "Please Select Category Name";
                    return null;
                }
                if (string.IsNullOrEmpty(DropDownPublisher.SelectedValue))
                {
                    labelMessage.Text = "Please Select Publisher";
                    return null;
                }

                _Book.PublisherID = Convert.ToInt32(DropDownPublisher.SelectedValue);
                _Book.CategoryID = Convert.ToInt32(dropDownCategory.SelectedValue);


                _Book.BookTitle = txtBookTitle.Text.Trim();
                _Book.IsLatest = chkIsLatest.Checked;
                _Book.ISBN = Convert.ToInt32(txtISBN.Text.Trim());
                _Book.AuthorID = Convert.ToInt32(DropDownAuthor.SelectedValue);
                _Book.PublishedDate = Convert.ToDateTime(txtPublishedDate.Text);
                DateTime date = GlobalRT.GetServerDateTime();
                _Book.LastVisibilityDate = date.AddDays(Convert.ToDouble(txtPostVisibilityDay.Text.Trim() != string.Empty ? txtPostVisibilityDay.Text.Trim() : "10"));
                _Book.Abstract = txtAbstract.Text.Trim();
                _Book.Discount = Convert.ToInt32(txtDiscount.Text.Trim());
                _Book.Edition = txtEdition.Text.Trim();

                _Book.Quantity = Convert.ToInt32(txtQuantity.Text);
                _Book.Price = Convert.ToDecimal(txtPrice.Text.Trim());
                _Book.IsRecommended = chkIsRecommended.Checked;
                _Book.IsRemoved = false;
                if ((_Book.PublishedDate.Subtract(DateTime.Now).Days <= 90))
                {
                    _Book.IsLatest = chkIsLatest.Checked = true;
                }
                else
                    _Book.IsLatest = chkIsLatest.Checked = false;

            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return _Book;
        }

        private void ClearData()
        {
            DropDownPublisher.SelectedValue = "-1";
            dropDownCategory.SelectedValue = "-1";
            DropDownAuthor.SelectedValue = "-1";
            txtBookTitle.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtAbstract.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtISBN.Text = string.Empty;
            txtPostVisibilityDay.Text = string.Empty;
            txtBookAvailableUrl.Text = string.Empty; ;
            txtPublishedDate.Text = string.Empty;
            chkIsRecommended.Checked = false;
            chkIsLatest.Checked = false;
            //chkIsRemoved.Checked = false;

        }

        //private BookOtherStoreUrl CreateBookFeature()
        //{
        //    try
        //    {
        //        BookOtherStoreUrl feature = new BookOtherStoreUrl();

        //        feature.BookAvailableUrl = txtBookAvailableUrl.Text.Trim();
        //        feature.BookWishTypeID = Convert.ToInt32(ddlBookWishType.SelectedValue.ToString());
        //        feature.OfferDescription = txtOfferDescription.Text.Trim();
        //        feature.SpecialOfferDescription = txtSpecialOfferDescription.Text.Trim();

        //        if (chkHasSpecialOffer.Checked)
        //        {
        //            feature.HasSpecialOffer = true;
        //        }
        //        else
        //        {
        //            feature.HasSpecialOffer = false;
        //        }

        //        return feature;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex);
        //    }
        //}

        private void LoadBookFeature()
        {
            try
            {
                lvBookFeature.DataSource = (List<BookOtherStoreUrl>)Session[seBookFeature];
                lvBookFeature.DataBind();
            }
            catch (Exception ex)
            {
                //labelMessage.Text = "Error : " + ex.Message;
                //labelMessage.ForeColor = System.Drawing.Color.Red;
            }

        }

        private void ClearBookFeatureField()
        {
            txtBookAvailableUrl.Text = string.Empty;
            txtOfferDescription.Text = string.Empty;
            txtSpecialOfferDescription.Text = string.Empty;
            ddlBookWishType.SelectedIndex = 0;

        }

        private bool IsValidUrl()
        {
            string regx = @"#([a-z]([a-z]|\d|\+|-|\.)*):(\/\/(((([a-z]|\d|-|\.|_|~|[\x00A0-\xD7FF\xF900-\xFDCF\xFDF0-\xFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:)*@)?((\[(|(v[\da-f]{1,}\.(([a-z]|\d|-|\.|_|~)|[!\$&'\(\)\*\+,;=]|:)+))\])|((\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5]))|(([a-z]|\d|-|\.|_|~|[\x00A0-\xD7FF\xF900-\xFDCF\xFDF0-\xFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=])*)(:\d*)?)(\/(([a-z]|\d|-|\.|_|~|[\x00A0-\xD7FF\xF900-\xFDCF\xFDF0-\xFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)*)*|(\/((([a-z]|\d|-|\.|_|~|[\x00A0-\xD7FF\xF900-\xFDCF\xFDF0-\xFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)+(\/(([a-z]|\d|-|\.|_|~|[\x00A0-\xD7FF\xF900-\xFDCF\xFDF0-\xFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)*)*)?)|((([a-z]|\d|-|\.|_|~|[\x00A0-\xD7FF\xF900-\xFDCF\xFDF0-\xFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)+(\/(([a-z]|\d|-|\.|_|~|[\x00A0-\xD7FF\xF900-\xFDCF\xFDF0-\xFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)*)*)|((([a-z]|\d|-|\.|_|~|[\x00A0-\xD7FF\xF900-\xFDCF\xFDF0-\xFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)){0})(\?((([a-z]|\d|-|\.|_|~|[\x00A0-\xD7FF\xF900-\xFDCF\xFDF0-\xFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)|[\xE000-\xF8FF]|\/|\?)*)?(\#((([a-z]|\d|-|\.|_|~|[\x00A0-\xD7FF\xF900-\xFDCF\xFDF0-\xFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)|\/|\?)*)?#iS";
            return true;
        }
        #endregion private

        #region protected
        private string Upload(int? bookISBN)
        {
            List<ImageUrl> OthrContntPicTempFileUrlList = new List<ImageUrl>();
            ImageUrl imageUrl = new ImageUrl();
            try
            {
                if (PictureUpload.HasFile)
                {
                    List<ImageUrl> PicTempFileUrlList = new List<ImageUrl>();
                    foreach (var file in PictureUpload.PostedFiles)
                    {
                        var fileName = "Book_" + bookISBN;
                        var tempFilename = Path.GetFileName(fileName);

                        if (Session["seTempFileName"] == null)
                        {
                            Session["seTempFileName"] = new List<ImageUrl>();
                        }
                        PicTempFileUrlList = (List<ImageUrl>)Session["seTempFileName"];//read from sess
                        Session["seLogoTempFileName"] = PicTempFileUrlList;//write to sess

                        PictureUpload.SaveAs(Server.MapPath("~/Image/BookImage/") + tempFilename + Path.GetExtension(PictureUpload.FileName));

                        imageUrl.ImageUrlTemp = "~/Image/BookImage/" + tempFilename + Path.GetExtension(PictureUpload.FileName);
                        PicTempFileUrlList.Add(imageUrl);
                    }
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return imageUrl.ImageUrlTemp.ToString();
        }

        protected void btn_CreateOrEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int bookID = 0;
                int? bookISBN = 0;
                //if (!TextControlCheckBeforeSave())
                //{
                //    return;
                //}
                Book book = CreateBook();
                if (book == null)
                {
                    return;
                }
                bool reqIDIsValid = Int64.TryParse(Request.QueryString["IID"], out IID);
                bookISBN = book.ISBN;
                var msg = BusinessLogicValidation(book);
                ImageUrl imageUrl = new ImageUrl();
                if (PictureUpload.HasFile)
                {
                    string permanentImagePathToSave = Upload(bookISBN).ToString();
                    book.ImageUrl = permanentImagePathToSave;
                }
                if (string.IsNullOrEmpty(msg))
                {
                    if (IID <= 0)
                    {
                        book.CreatedBy = Convert.ToInt64(Session["UserID"]);
                        book.CreatedDate = DateTime.Now;


                        List<BookOtherStoreUrl> list = (List<BookOtherStoreUrl>)Session[seBookFeature];
                        if (list != null)
                        {
                            string bookAndBookFeatureChildXML = ConversionXML.ConvertObjectToXML<Book, BookOtherStoreUrl>(book, list, string.Empty);
                            using (BookRT rt = new BookRT())
                            {
                                bookID = rt.InsertBookAndBookFeatureChildXML(bookAndBookFeatureChildXML);
                                if (bookID == -100)
                                {
                                    labelMessage.Text = "Network connection fail ... Please try again..!!";
                                    labelMessage.ForeColor = System.Drawing.Color.Red;
                                    labelMessage.Focus();
                                }
                                else if (bookID == -101)
                                {
                                    labelMessage.Text = "Network connection fail ... Please try again..!!";
                                    labelMessage.ForeColor = System.Drawing.Color.Red;
                                    labelMessage.Focus();
                                }
                                ClearData();

                                labelMessage.Text = "Information has been inserted successfully.";
                                labelMessage.ForeColor = System.Drawing.Color.Green;
                                Session[seBookFeature] = null;
                                Response.Redirect("~/BookAdmin/BookDisplay");
                            }


                        }
                        else if (list == null)
                        {
                            using (BookRT rt = new BookRT())
                            {
                                rt.AddBook(book);
                                labelMessage.Text = "Information has been updated successfully.";
                                labelMessage.ForeColor = System.Drawing.Color.Green;
                                Response.Redirect("~/BookAdmin/BookDisplay");
                            }
                        }

                        _BookRT.AddBook(book);
                        ClearData();

                        labelMessage.Text = "Information has been inserted successfully.";
                        labelMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        Book objbook = _BookRT.GetBookByIID(IID);

                        if (objbook != null)
                        {
                            book.CreatedBy = objbook.CreatedBy; ;
                            book.CreatedDate = objbook.CreatedDate;
                            book.IID = objbook.IID;
                            if (PictureUpload.HasFile == null)
                            {
                                book.ImageUrl = objbook.ImageUrl;
                            }
                            book.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                            book.ModifiedDate = DateTime.Now;
                            List<BookOtherStoreUrl> featureList = (List<BookOtherStoreUrl>)Session[seBookFeature];
                            _BookRT.UpdateBookAndBookFeature(book,featureList);
                            ClearData();

                            labelMessage.Text = "Information has been updated successfully.";
                            labelMessage.ForeColor = System.Drawing.Color.Green;
                        }
                    }
                }
                else
                {
                    labelMessage.Text = msg;
                    labelMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/BookAdmin/BookDisplay");
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        //#region Feature
        //protected void btnAddFeature_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        List<MPFeature> featureColl = null;
        //        string description = string.Empty;
        //        if (Session[seMPFeatureColl] == null)
        //        {
        //            featureColl = new List<MPFeature>();
        //        }
        //        else
        //        {
        //            featureColl = (List<MPFeature>)Session[seMPFeatureColl];
        //        }
        //        foreach (MPFeature feature in featureColl)
        //        {
        //            if (feature.Description == txtDesFeature.Text.Trim().Replace(Environment.NewLine, "<br/>"))
        //            {
        //                description = "Description";
        //                break;
        //            }
        //        }
        //        if (description == "Description")
        //        {
        //            lblMessageFeature.Text = "Description already exists";
        //            lblMessageFeature.ForeColor = System.Drawing.Color.Red;
        //        }
        //        else
        //        {
        //            MPFeature feature = CreateMPFeature();
        //            featureColl.Add(feature);
        //            Session[seMPFeatureColl] = featureColl;
        //            LoadMPFeature();
        //        }
        //        lvFeature.Visible = true;
        //        ClearFeature();
        //    }
        //    catch (Exception ex)
        //    {
        //        labelMessage.Text = "Error : " + ex.Message;
        //        labelMessage.ForeColor = System.Drawing.Color.Red;
        //    }
        //}
        //private void DisplayFeature(Int64? mpID)
        //{
        //    try
        //    {
        //        List<MPFeature> featureList = new List<MPFeature>();
        //        featureList = _BookRT.GetAllFeatureByMPIID(mpID);
        //        lvFeature.DataSource = featureList;
        //        Session[seMPFeatureColl] = featureList;
        //        lvFeature.DataBind();

        //    }
        //    catch (Exception ex)
        //    {
        //        labelMessage.Text = "Error : " + ex.Message;
        //        labelMessage.ForeColor = System.Drawing.Color.Red;
        //    }
        //}

        //private void ClearFeature()
        //{
        //    txtDesFeature.Text = string.Empty;
        //}

        //private MPFeature CreateMPFeature()
        //{

        //    MPFeature feature = new MPFeature();
        //    feature.Description = txtDesFeature.Text.Trim().Replace(Environment.NewLine, "<br/>");
        //    // feature.Description = txtDescription.Text.Trim().Replace(Environment.NewLine, "<br/>");
        //    feature.CreatedBy = Convert.ToInt64(Session["UserID"]);
        //    feature.CreatedDate = DateTime.Now;
        //    feature.IsRemoved = false;
        //    return feature;


        //}

        //private void LoadMPFeature()
        //{
        //    try
        //    {
        //        lvFeature.DataSource = (List<MPFeature>)Session[seMPFeatureColl];
        //        lvFeature.DataBind();
        //    }
        //    catch (Exception ex)
        //    {
        //        labelMessage.Text = "Error : " + ex.Message;
        //        labelMessage.ForeColor = System.Drawing.Color.Red;
        //    }
        //}
        //protected void lvFeature_ItemCommand(object sender, ListViewCommandEventArgs e)
        //{
        //    try
        //    {
        //        lblMessageFeature.Text = string.Empty;
        //        if (e.CommandName.Equals("DeleteInfo"))
        //        {
        //            if (Session[seMPFeatureColl] != null)
        //            {
        //                List<MPFeature> mpFeatureColl = (List<MPFeature>)Session[seMPFeatureColl];
        //                mpFeatureColl.RemoveAll(fe => fe.Description.Equals(e.CommandArgument));
        //                Session[seMPFeatureColl] = mpFeatureColl;
        //                LoadMPFeature();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        labelMessage.Text = "Error : " + ex.Message;
        //        labelMessage.ForeColor = System.Drawing.Color.Red;
        //    }
        //}
        //protected void dataPagerFeature_PreRender(object sender, EventArgs e)
        //{

        //}

        //#endregion feature

        #endregion protected
        public class ImageUrl
        {
            public string ImageUrlPer { get; set; }
            public string ImageUrlTemp { get; set; }
        }

        protected void btnAddUrl_Click(object sender, EventArgs e)
        {
            List<BookOtherStoreUrl> featureColl = null;
            string url = string.Empty;
            string testFeild = string.Empty;
            //lblMessageFeature.Text = string.Empty;
            //if (IsValidUrl())
            //{
            //    return;
            //}
            if (Session[seBookFeature] == null)
            {
                featureColl = new List<BookOtherStoreUrl>();
            }
            else
            {
                featureColl = (List<BookOtherStoreUrl>)Session[seBookFeature];
            }
            foreach (BookOtherStoreUrl feature in featureColl)
            {
                if (feature.BookAvailableUrl == txtBookAvailableUrl.Text.Trim())
                {
                    testFeild = "Invalid";
                    break;
                }
            }
            if (testFeild == "Invalid")
            {
                //lblMessageFeature.Text = "This url already added";
                //lblMessageFeature.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
              //  BookOtherStoreUrl feature = CreateBookFeature();
             //   featureColl.Add(feature);
                Session[seBookFeature] = featureColl;
                LoadBookFeature();
                ClearBookFeatureField();
            }

        }

        protected void lvBookFeature_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("DeleteInfo"))
                {
                    ListViewDataItem dataItem = (ListViewDataItem)e.Item;
                    Label lblUrl = (Label)dataItem.FindControl("lblUrl");
                    string url = lblUrl.Text;
                    if (Session[seBookFeature] != null)
                    {
                        List<BookOtherStoreUrl> booksFeature = (List<BookOtherStoreUrl>)Session[seBookFeature];
                        booksFeature.RemoveAll(fe => fe.BookAvailableUrl.Equals(url));
                        Session[seBookFeature] = booksFeature;
                        LoadBookFeature();
                    }
                }
            }
            catch (Exception ex)
            {
                //labelMessage.Text = "Error : " + ex.Message;
                //labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnAddBookReview_Click(object sender, EventArgs e)
        {

        }

        protected void lvMediaReview_ItemCommand(object sender, ListViewCommandEventArgs e)
        {

        }

    }
}