using BLL.Basic;
using DAL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace OMart.Web.AdminPanel
{
    public partial class CompanyInfoInsertUpdate : System.Web.UI.Page
    {
        private readonly CompanyInfoRT _companyInfoRT;
        private long IID = default(Int64);

        public CompanyInfoInsertUpdate()
        {
            this._companyInfoRT = new CompanyInfoRT();
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
                        ShowCompanyInfoData();
                       
                    }
                    LoadDropDownCompanyBussinessType();
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
                        countryList = receverTransfer.GetAllCountries();
                    }
                    DropDownListHelper.Bind<Country>(dropdownCountry, countryList, "Name", "IID", EnumCollection.ListItemType.Country);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private void LoadDropDownCompanyBussinessType()
        {
            try
            {


                {
                    dropDownBussinessTypeID.Items.Add(new ListItem("Select Business Type ", "-1"));
                    foreach (Utilities.EnumCollection.BussinessType r in Enum.GetValues(typeof(Utilities.EnumCollection.BussinessType)))
                    {
                        ListItem item = new ListItem(Enum.GetName(typeof(Utilities.EnumCollection.BussinessType), r), r.ToString());
                        dropDownBussinessTypeID.Items.Add(item);
                    }

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
                string comName = string.Empty;

                CompanyInfo company = CreateCompanyInfo();
                bool reqIDIsValid = Int64.TryParse(Request.QueryString["IID"], out IID);

                ImageUrl imageUrl = new ImageUrl();
                //if (LogoUpload.HasFile)
                //{
                //    btnLogoUpload_Click(sender, e);
                //}
                //ImageUrl imageUrl = new ImageUrl();
                if (LogoUpload.HasFile)
                {
                   // string permanentImagePathToSave = Upload(company.Name).ToString();
                    // string permanentImagePathToSave = Server.MapPath("~/Images/MobilePhone/") + (Path.GetExtension(imageUrl.ImageUrlTemp)) + MobComName.ToString();//image path to save folder
                    //  string permanentImagePath = "~/Images/MobilePhone/" + MobComName + (Path.GetExtension(Server.MapPath(imageUrl.ImageUrlTemp))).ToString();//image path to save db
                    //company.LogoUrl = permanentImagePathToSave;

                    company.LogoUrl = ImageUpload(LogoUpload, "~/All Photos/Company/").ToString();
                }
                else
                {

                    labelMessage.Text = "Please browse image(s)....";
                    labelMessage.ForeColor = System.Drawing.Color.DarkBlue;
                    labelMessage.Focus();
                    return;
                }

                //comName = company.Name;            
                  
                //        string permanentImagePathToSave = Server.MapPath("~/Image/Company/") + comName +  (Path.GetExtension(imageUrl.ImageUrlTemp));//image path to save folder
                //        string permanentImagePath = "~/Image/Company/" + comName + (Path.GetExtension(Server.MapPath(imageUrl.ImageUrlTemp)));//image path to save db
                //        company.LogoUrl = permanentImagePath;
                       // File.Move(Server.MapPath(imageUrl.ImageUrlTemp), permanentImagePathToSave);//move pic to permanent folder from tempPic folder
                 var msg = BusinessLogicValidation(company); 
                if (string.IsNullOrEmpty(msg))
                {
                    if (IID <= 0)
                    {
                        company.CreatedBy = Convert.ToInt64(Session["UserID"]);
                        company.CreatedDate = DateTime.Now;
                        company.IsRemoved = false;

                        _companyInfoRT.AddCompanyInfo(company);
                        ClearData();

                        labelMessage.Text = "Information has been inserted successfully.";
                        labelMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        CompanyInfo objCompany = _companyInfoRT.GetCompanyInfoByIID(IID);

                        if (objCompany != null)
                        {
                            company.CreatedBy = objCompany.CreatedBy; ;
                            company.CreatedDate = objCompany.CreatedDate;
                            company.IsRemoved = objCompany.IsRemoved;
                            company.IID = objCompany.IID;

                            company.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                            company.ModifiedDate = DateTime.Now;

                            _companyInfoRT.UpdateCompanyInfo(company);
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
                Response.Redirect("~/AdminPanel/CompanyInfoDisplay");
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void ShowCompanyInfoData()
        {
            try
            {
                CompanyInfo objCompany = _companyInfoRT.GetCompanyInfoByIID(IID);
                if (objCompany != null)
                {
                    txtCompanyInfoName.Text = objCompany.Name;
                    txtBussDescription.Text = objCompany.BussinessDescription;
                    dropdownCountry.Text = Convert.ToString(objCompany.OriginCountryID);
                    txtAddress.Text = objCompany.Address;
                    
                    txtTotalCountryBussCover.Text = Convert.ToString(objCompany.TotalCountryBussCover);
                    dropDownBussinessTypeID.Text = Convert.ToString(objCompany.BussinessTypeID);
                    txtWebAddress.Text = objCompany.WebAddress;
                    txtEstablishedYear.Text =  Convert.ToString(objCompany.EstablishedYear);
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private string BusinessLogicValidation(CompanyInfo company)
        {
            string message = string.Empty;
            bool reqIDIsValid = Int64.TryParse(Request.QueryString["IID"], out IID);

            if (IID <= 0)
            {
                CompanyInfo objCompanyName = (from tr in _companyInfoRT.GetAllCompanyInfos()
                                          where tr.Name == company.Name
                                          select tr).SingleOrDefault();
                if (objCompanyName != null)
                {
                    if (objCompanyName.Name == company.Name)
                    {
                        message = "Company name already exists.";
                    }
                }

          
            }

            return message;
        }

        private CompanyInfo CreateCompanyInfo()
        {
            Session["UserID"] = "1";
            CompanyInfo company = new CompanyInfo();
            try
            {
                company.Name = txtCompanyInfoName.Text.Trim();
                company.BussinessDescription = txtBussDescription.Text.Trim().Replace(Environment.NewLine, "<br/>");
                company.OriginCountryID = Convert.ToInt32(dropdownCountry.SelectedValue);
                company.TotalCountryBussCover = Convert.ToInt32(txtTotalCountryBussCover.Text);
                company.Address = txtAddress.Text.Trim();
                //company.LogoUrl = txtLogoUrl.Text;
                company.WebAddress = txtWebAddress.Text;
                company.EstablishedYear = Convert.ToInt32( txtEstablishedYear.Text.Trim());
                company.BussinessTypeID = (Int32)Enum.Parse(typeof(Utilities.EnumCollection.BussinessType), dropDownBussinessTypeID.SelectedValue.ToString());
                company.ContactPhoneNo = txtContactPhoneNo.Text;

            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return company;
        }

        private void ClearData()
        {
            txtCompanyInfoName.Text = string.Empty; 
            txtBussDescription.Text = string.Empty;
            //txtOriginCountryID.Text = string.Empty;
            
            txtTotalCountryBussCover.Text = string.Empty;
           // txtLogoUrl.Text = string.Empty;
            txtWebAddress.Text = string.Empty;
            txtAddress.Text = string.Empty;
           // txtBussinessTypeID = string.Empty;
            txtContactPhoneNo.Text = string.Empty;
            txtEstablishedYear.Text = string.Empty;
            txtContactPhoneNo.Text = string.Empty;
            LoadDropDownCountry(null);
            LoadDropDownCompanyBussinessType();
        }

        //protected void btnLogoUpload_Click(object sender, EventArgs e)
        //{             
        //    try
        //    {
        //        string debugStr = string.Empty;
        //        if (LogoUpload.HasFile)
        //        {
        //            List<ImageUrl> logoPicTempFileUrlList = new List<ImageUrl>();
        //            foreach (var file in LogoUpload.PostedFiles)
        //            {
        //                string now = "";
        //                now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff", CultureInfo.InvariantCulture);

        //                //take only letter or digit
        //                var sb = new StringBuilder();
        //                foreach (char t in now.Where(char.IsLetterOrDigit))
        //                {
        //                    sb.Append(t);
        //                }

        //                now = sb.ToString();//save to now string
        //                var rnd = new Random(100000);
        //                var tempLogoImageName = now + rnd.Next();

        //                var tempFilename = Path.GetFileName(tempLogoImageName +"__"+ LogoUpload.FileName);

                  
        //                if (Session["seLogoTempFileName"] == null)
        //                {
        //                    Session["seLogoTempFileName"] = new List<ImageUrl>();
        //                }
        //                logoPicTempFileUrlList = (List<ImageUrl>)Session["seLogoTempFileName"];//read from sess

        //                ImageUrl imageUrl = new ImageUrl();
                     
        //                Session["seLogoTempFileName"] = logoPicTempFileUrlList;//write to sess

        //                LogoUpload.SaveAs(Server.MapPath("~/Images/Logo/") + tempFilename);

        //                imageUrl.ImageUrlTemp = "~/Image/Logo/" + tempLogoImageName + Path.GetExtension(file.FileName);
        //                logoPicTempFileUrlList.Add(imageUrl);
                                             

        //            }
                   
        //        }
               
               
        //    }
        //    catch (Exception ex)
        //    {
        //        labelMessage.Text = "Error : " + ex.Message;
        //        labelMessage.ForeColor = System.Drawing.Color.Red;
        //    }


        //}
        //private string Upload(string modelName)
        //{
        //    List<ImageUrl> OthrContntPicTempFileUrlList = new List<ImageUrl>();
        //    ImageUrl imageUrl = new ImageUrl();
        //    try
        //    {
        //        if (LogoUpload.HasFile)
        //        {
        //            List<ImageUrl> PicTempFileUrlList = new List<ImageUrl>();
        //            foreach (var file in LogoUpload.PostedFiles)
        //            {
        //                //string now = "";
        //                //now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff", CultureInfo.InvariantCulture);

        //                ////take only letter or digit
        //                //var sb = new StringBuilder();
        //                //foreach (char t in now.Where(char.IsLetterOrDigit))
        //                //{
        //                //    sb.Append(t);
        //                //}

        //                //now = sb.ToString();//save to now string
        //                //var rnd = new Random(100000);
        //                // var tempImageName = modelName;

        //                //var tempFilename = Path.GetFileName(tempImageName + "__" + PictureUpload.FileName);
        //                var tempFilename = Path.GetFileName(modelName);

        //                if (Session["seTempFileName"] == null)
        //                {
        //                    Session["seTempFileName"] = new List<ImageUrl>();
        //                }
        //                PicTempFileUrlList = (List<ImageUrl>)Session["seTempFileName"];//read from sess

        //                //  ImageUrl imageUrl = new ImageUrl();

        //                Session["seLogoTempFileName"] = PicTempFileUrlList;//write to sess

        //                LogoUpload.SaveAs(Server.MapPath("~/All Photos/Company/") + tempFilename + Path.GetExtension(LogoUpload.FileName));

        //                imageUrl.ImageUrlTemp = "~/All Photos/Company/" + tempFilename + Path.GetExtension(LogoUpload.FileName);
        //                PicTempFileUrlList.Add(imageUrl);
        //            }

        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        labelMessage.Text = "Error : " + ex.Message;
        //        labelMessage.ForeColor = System.Drawing.Color.Red;
        //    }
        //    return imageUrl.ImageUrlTemp.ToString();
        //}

        private string ImageUpload(FileUpload file, string pathString)
        {
            List<ImageUrl> OthrContntPicTempFileUrlList = new List<ImageUrl>();
            ImageUrl imageUrl = new ImageUrl();
            try
            {
                if (file.HasFile)
                {
                    string now = "";
                    now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff", CultureInfo.InvariantCulture);
                    //take only letter or digit
                    var sb = new StringBuilder();
                    foreach (char t in now.Where(char.IsLetterOrDigit))
                    {
                        sb.Append(t);
                    }
                    now = sb.ToString();//save to now string
                    var rnd = new Random(100000);
                    var tempImageName = now + rnd.Next();
                    string path = Server.MapPath(pathString);
                    //FileUploadHelper.BindImage(file, path, tempImageName, 800, 800);
                    FileUploadHelper.BindImage(file, path, tempImageName);
                    imageUrl.ImageUrlTemp = pathString + tempImageName + Path.GetExtension(file.FileName);

                    return imageUrl.ImageUrlTemp.ToString();
                }
                return imageUrl.ImageUrlTemp.ToString();
            }
            catch (Exception ex)
            {
                labelMessage.Text = "error: " + ex.Message;
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