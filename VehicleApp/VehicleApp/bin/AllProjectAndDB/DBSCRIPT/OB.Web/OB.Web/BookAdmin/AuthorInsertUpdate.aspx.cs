using BLL.Basic;
using OB.BLL.Basic;
using OB.DAL;
using OB.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OB.Web.BookAdmin
{
    public partial class AuthorInsertUpdate : System.Web.UI.Page
    {
        private readonly BookAuthorRT _BookAuthorRT;
        private long IID = default(Int64);

        public AuthorInsertUpdate()
        {
            this._BookAuthorRT = new BookAuthorRT();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    var requestId = Request.QueryString["IID"];
                    bool reqIDIsValid = Int64.TryParse(requestId, out IID);
                    if (reqIDIsValid)
                    {
                        ShowAuthorData();
                       
                    }
                   
                    LoadDropDownCountry(null);
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void LoadDropDownCountry(int? countryID)
        {
            try
            {
                using (CountryRT receverTransfer = new CountryRT())
                {
                    List<Country> countryList = new List<Country>();
                    if (countryID != null)
                    {
                        countryList.Add(receverTransfer.GetCountryByIID((int)countryID));
                    }
                    else
                    {
                        countryList = receverTransfer.GetAllCountryForListView();
                    }
                    DropDownListHelper.Bind<Country>(dropdownCountry, countryList, "Name", "IID", EnumCollection.ListItemType.Country);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

       

        protected void btn_CreateOrEdit_Click(object sender, EventArgs e)
        {
            try
            {
              //  string authorName = string.Empty;

                BookAuthor author = CreateBookAuthor();
                bool reqIDIsValid = Int64.TryParse(Request.QueryString["IID"], out IID);
              //  authorName = author.AuthorName;
                var msg = BusinessLogicValidation(author); 
              //  ImageUrl imageUrl = new ImageUrl();
              

               
                if (string.IsNullOrEmpty(msg))
                {
                    if (IID <= 0)
                    {
                        author.CreatedBy = Convert.ToInt64(Session["UserID"]);
                        author.CreatedDate = DateTime.Now;
                        author.IsRemoved = false;

                        _BookAuthorRT.AddBookAuthor(author);
                        ClearData();

                        labelMessage.Text = "Information has been inserted successfully.";
                        labelMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        BookAuthor objAuthor = _BookAuthorRT.GetBookAuthorByIID(IID);

                        if (objAuthor != null)
                        {
                            author.CreatedBy = objAuthor.CreatedBy; ;
                            author.CreatedDate = objAuthor.CreatedDate;
                            author.IsRemoved = objAuthor.IsRemoved;
                            author.IID = objAuthor.IID;

                            author.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                            author.ModifiedDate = DateTime.Now;

                            _BookAuthorRT.UpdateBookAuthor(author);
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
                Response.Redirect("~/BookAdmin/AuthorDisplay");
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void ShowAuthorData()
        {
            try
            {
                BookAuthor objAuthor = _BookAuthorRT.GetBookAuthorByIID(IID);
                if (objAuthor != null)
                {
                    txtAuthorName.Text = objAuthor.AuthorName;
                    txtAboutAuthor.Text = objAuthor.AboutAuthor;
                    LoadDropDownCountry(objAuthor.CountryID);
                    dropdownCountry.SelectedValue = objAuthor.CountryID.ToString();
                    txtFavQuote.Text = objAuthor.FavouriteQuote;
                    txtHoldImagePath.Text = objAuthor.Picture;
                    chkIsFeatured.Checked = objAuthor.IsFeatured.Value;
                    chkIsRemoved.Checked = objAuthor.IsRemoved;
                   
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private string BusinessLogicValidation(BookAuthor company)
        {
            string message = string.Empty;
            bool reqIDIsValid = Int64.TryParse(Request.QueryString["IID"], out IID);

            if (IID <= 0)
            {
                BookAuthor objCompanyName = (from tr in _BookAuthorRT.GetAllBookAuthors()
                                         where tr.AuthorName == company.AuthorName
                                          select tr).SingleOrDefault();
                if (objCompanyName != null)
                {
                    if (objCompanyName.AuthorName == company.AuthorName)
                    {
                        message = "Author name already exists.";
                    }
                }

          
            }

            return message;
        }

        private BookAuthor CreateBookAuthor()
        {
            Session["UserID"] = "1";
            BookAuthor author = new BookAuthor();
            try
            {
                author.AuthorName = txtAuthorName.Text.Trim();
                author.AboutAuthor = txtAboutAuthor.Text.Trim().Replace(Environment.NewLine, "<br/>");
                if (dropdownCountry.SelectedValue!="-1")
                {
                      author.CountryID = Convert.ToInt32(dropdownCountry.SelectedValue);
                }
              
                author.FavouriteQuote = txtFavQuote.Text;
                author.IsFeatured = chkIsFeatured.Checked;
                author.IsRemoved = chkIsRemoved.Checked;
                if (txtHoldImagePath.Text == string.Empty && ImageUpload.HasFile == true)
                {
                    string permanentImagePathToSave = Upload(author.AuthorName).ToString();
                    author.Picture = permanentImagePathToSave;
                }
                    else if(txtHoldImagePath.Text != null && ImageUpload.HasFile == true)
                    {
                        string permanentImagePathToSave = Upload(author.AuthorName).ToString();
                        author.Picture = permanentImagePathToSave;
                    }
                else if (txtHoldImagePath.Text != null && ImageUpload.HasFile == false)
                {
                    author.Picture = txtHoldImagePath.Text;
                    }
                else
                {

                    labelMessage.Text = "Please browse image(s)....";
                    labelMessage.ForeColor = System.Drawing.Color.DarkBlue;
                    labelMessage.Focus();
                   
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return author;
        }

        private void ClearData()
        {
            txtAuthorName.Text = string.Empty;
            txtAboutAuthor.Text = string.Empty;
           
            txtFavQuote.Text = string.Empty;
          
        }

        private string Upload(string authorName)
        {
            List<ImageUrl> OthrContntPicTempFileUrlList = new List<ImageUrl>();
            ImageUrl imageUrl = new ImageUrl();
            try
            {
                if (ImageUpload.HasFile)
                {
                    List<ImageUrl> PicTempFileUrlList = new List<ImageUrl>();
                    foreach (var file in ImageUpload.PostedFiles)
                    {
                        var tempFilename = Path.GetFileName(authorName);

                        if (Session["seTempFileName"] == null)
                        {
                            Session["seTempFileName"] = new List<ImageUrl>();
                        }
                        PicTempFileUrlList = (List<ImageUrl>)Session["seTempFileName"];//read from sess
                        Session["seLogoTempFileName"] = PicTempFileUrlList;//write to sess

                        ImageUpload.SaveAs(Server.MapPath("~/Image/AuthorImage/") + tempFilename + Path.GetExtension(ImageUpload.FileName));

                        imageUrl.ImageUrlTemp = "~/Image/AuthorImage/" + tempFilename + Path.GetExtension(ImageUpload.FileName);
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
        public class ImageUrl
        {
            public string ImageUrlPer { get; set; }
            public string ImageUrlTemp { get; set; }
        }

    }
}