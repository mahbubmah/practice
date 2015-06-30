using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;
using OH.BLL.Basic;
using OH.DAL;
using OH.Utilities;

namespace OH.Web
{
    public partial class MaterialAdGiverWF : System.Web.UI.Page
    {
        private const string sessMaterial = "seMaterialLogAdGiver";
        Int64 Iid = default(Int64);
        string EncryptedID = default(string);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                  
                    //Response.Redirect("MaterialAdminListWF.aspx");//page locked
                    if (Request.QueryString["option"] != null)
                    {
                        try
                        {
                          //  Int64 matID = Convert.ToInt64(Request.QueryString["matID"]);

                            string EncryptedID = Request.QueryString["option"];
                            Int64 DecrptedIid = Convert.ToInt64(StringCipher.Decrypt(EncryptedID));
                            Session["adGiverMatIID"] = DecrptedIid;
                           // Session["adGiverMatIID"] = Request.QueryString["matID"];
                            Session["seMatPicTempFileName"] = null;
                            hdIsEdit.Value = "true";
                            LoadDropDownForCategory();
                            FillMaterialFormForEdit(DecrptedIid);
                            btnCategoryID_Click(sender, e);
                            LoadAdGiver();
                        }
                        catch (Exception)
                        {
                            Response.Redirect("~/ManageYourAds.aspx");
                        }
                    }
                    else
                    {
                        Response.Redirect("~/ManageYourAds.aspx");
                    }

                    //Get countryIID for Location
                    int countryID = Convert.ToInt32(EnumCollection.Country.Bangladesh);//change here for change country
                    hdCountryID.Value = countryID.ToString();
                }
                catch (Exception ex)
                {
                    labelMessage.Text = "Error : " + ex.Message;
                    labelMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        private void LoadAdGiver()
        {
            using (AdGiverRT adGRt = new AdGiverRT())
            {
                string Email = Session["UserName"].ToString();
                var adGiver = !txtUserID.Text.IsNullOrWhiteSpace() ? adGRt.GetAdGiverIDByEmail(Email) : null;
                
                TxtName.Text = adGiver.Name.Trim();
                
                //  lblAdGiverInfo.Text = "Please select at least one option to be contacted by.";
            }
        }
        private void LoadDropDownForCategory()
        {
            try
            {
                using (CategoryRT aCategoryRt = new CategoryRT())
                {
                    var categoryList = aCategoryRt.GetAllSearchedCategory(" ");
                    DropDownListHelper.Bind(dropDownCategory, categoryList, "Description", "IID");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private void FillMaterialFormForEdit(Int64 materialIID)
        {
            try
            {
                using (MaterialRT rt = new MaterialRT())
                {
                    hdMaterialID.Value = materialIID.ToString();

                    Material material = rt.GetMaterialByIID(materialIID);

                    if (material == null)
                    {
                        Response.Redirect("~/ManageYourAds.aspx");
                    }

                    if (!(material.BrandID == 0 || material.BrandID == null))
                    {
                        txtBrandID.Text = material.BrandID.ToString();
                        using (BrandRT brandRt = new BrandRT())
                        {
                            txtBrand.Text = brandRt.GetBrandByID((long)material.BrandID).Name;
                        }
                    }

                    if (!(material.ModelID != 0 || material.ModelID != null))
                    {
                        using (ModelRT aModelRt = new ModelRT())
                        {
                            txtModel.Text = aModelRt.GetModelByID((int)material.ModelID).Name;
                        }
                    }

                    if (!(material.ColorID != 0 || material.ColorID != null))
                    {
                        using (ColorRT aColorRt = new ColorRT())
                        {
                            txtModel.Text = aColorRt.GetColorByID((int)material.ColorID).Name;
                        }
                    }

                    using (AdGiverRT adGiverRt = new AdGiverRT())
                    {
                        txtUserID.Text = material.AdGiverID != 0 ? adGiverRt.GetAdGiverByIID((long)material.AdGiverID).EmailID : string.Empty;
                    }
                    txtTitleName.Text = material.TitleName;
                    txtPrice.Text = material.Price.ToString();
                    
                    txtDescription.Text = material.Description;
                    txtCode.Text = material.Code;
                    txtWeburl.Text = material.WebSiteUrl;
                    txtYoutubeUrl.Text = material.YoutubeUrl;
                    txtPhoneNumber.Text = material.UserPhoneNumber;
                    chkNegotiable.Checked = material.IsNegotiablePrice;

                    dropDownCategory.SelectedValue = material.CategoryID.ToString();



                    using (LocationRT aLocationRt = new LocationRT())
                    {
                        txtLocationID.Text = material.LocationID.ToString();

                        long districtID = 0, policeStationID = 0;
                        string districtName = string.Empty, polStationName = string.Empty, locationName = string.Empty;
                        bool isReceiveInfo = aLocationRt.GetLocationInfoByIID(material.LocationID, ref districtID, ref districtName, ref policeStationID, ref polStationName, ref locationName);
                        if (isReceiveInfo)
                        {
                            txtDistrictID.Text = districtID.ToString();
                            txtDistrict.Text = districtName.ToString();
                            txtPoliceStationID.Text = policeStationID.ToString();
                            txtPoliceStation.Text = polStationName.ToString();
                            txtLocation.Text = locationName.ToString();
                        }
                    }

                    DateTime addDate = material.AdDate;
                    DateTime adDisplayLastDate = (DateTime)(material.AdDisplayLastDate ?? material.AdDate);
                    int adDisplayTotalDate = (int)(adDisplayLastDate - addDate).TotalDays;
                    txtPostVisibilityDay.Text = adDisplayTotalDate.ToString();


                    List<ControlAdmin.MaterialWF.ImageUrl> matPicTempFileUrlList = new List<ControlAdmin.MaterialWF.ImageUrl>();
                    using (PictureRT aPictureRt = new PictureRT())
                    {
                        List<Picture> picList = new List<Picture>();
                        picList = aPictureRt.GetPictureByMaterialIID(Convert.ToInt64(materialIID));

                        if (picList.Count > 0)
                        {
                            foreach (var picture in picList)
                            {
                                ControlAdmin.MaterialWF.ImageUrl aImageUrl = new ControlAdmin.MaterialWF.ImageUrl();
                                aImageUrl.ImageUrlTemp = picture.UrlAddress;
                                matPicTempFileUrlList.Add(aImageUrl);
                            }
                        }
                    }
                    Session["seMatPicTempFileName"] = matPicTempFileUrlList;
                    datalistMatPic.DataSource = matPicTempFileUrlList;
                    datalistMatPic.DataBind();

                    Session[sessMaterial] = material;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        private Material CreateMaterial()
        {

            Material material = new Material();
            try
            {

                if (hdIsEdit.Value == "true")
                {
                    material.IID = Convert.ToInt32(hdMaterialID.Value);
                }
                if (string.IsNullOrEmpty(txtLocation.Text.Trim()))
                {
                    labelMessage.Text = "Please enter location";
                    return null;
                }
                if (string.IsNullOrEmpty(txtDistrict.Text.Trim()) || string.IsNullOrEmpty(txtDistrictID.Text.Trim()))
                {
                    labelMessage.Text = "Please enter district";
                    return null;
                }
                if (string.IsNullOrEmpty(txtPoliceStation.Text.Trim()) || string.IsNullOrEmpty(txtPoliceStationID.Text.Trim()))
                {
                    labelMessage.Text = "Please enter police station";
                    return null;
                }

                material.TitleName = txtTitleName.Text.Trim();
                using (AdGiverRT adGRt = new AdGiverRT())
                {
                    var adGiver = !txtUserID.Text.IsNullOrWhiteSpace() ? adGRt.GetAdGiverIDByEmail(txtUserID.Text) : null;
                    material.AdGiverID = adGiver != null ? adGiver.IID : -1;
                }
                material.Code = txtCode.Text;
                material.Description = txtDescription.Text.Trim();
                material.IsFeatured = chkIsFeatured.Checked;
                material.IsSpotlight = chkIsSpotlight.Checked;
                material.IsUrgent = chkIsUrgent.Checked;
                material.IsNegotiablePrice = chkNegotiable.Checked;
                material.YoutubeUrl = txtYoutubeUrl.Text;
                material.WebSiteUrl = txtWeburl.Text;
                material.UserPhoneNumber = txtPhoneNumber.Text;
                material.UserEmail = txtUserID.Text;
                using (LocationRT aLocationRt = new LocationRT())
                {
                    if (txtLocationID.Text != "" || txtLocationID.Text != string.Empty)
                    {
                        var loc = aLocationRt.GetLocationByIID(Convert.ToInt64(txtLocationID.Text));
                        if (txtLocation.Text.ToLower() != loc.CurrentLocation.ToLower())
                        {
                            try
                            {
                                Location aLocation = new Location();
                                if (txtLocation.Text != "" || txtLocation.Text != string.Empty)
                                {
                                    aLocation.CurrentLocation = txtLocation.Text;
                                }
                                aLocation.DistrictID =
                                    Convert.ToInt64(txtDistrictID.Text.Trim() != null ? txtDistrictID.Text.Trim() : null);
                                aLocation.PoliceStationID =
                                    Convert.ToInt64(txtPoliceStationID.Text.Trim() != null
                                        ? txtPoliceStationID.Text.Trim()
                                        : null);
                                aLocation.CountryID = Convert.ToInt32(hdCountryID.Value);
                                aLocation.CurrentLocation = txtLocation.Text;
                                aLocationRt.AddLocation(aLocation);
                                material.LocationID = aLocation.IID;
                            }
                            catch (Exception exception)
                            {
                                throw new Exception(exception.Message, exception);
                            }
                        }
                        else
                        {
                            material.LocationID = Convert.ToInt64(txtLocationID.Text);
                        }
                    }
                    else
                    {
                        try
                        {
                            Location aLocation = new Location();
                            if (txtLocation.Text != "" || txtLocation.Text != string.Empty)
                            {
                                aLocation.CurrentLocation = txtLocation.Text;
                            }
                            aLocation.DistrictID =
                                Convert.ToInt64(txtDistrictID.Text.Trim() != null ? txtDistrictID.Text.Trim() : null);
                            aLocation.PoliceStationID =
                                Convert.ToInt64(txtPoliceStationID.Text.Trim() != null
                                    ? txtPoliceStationID.Text.Trim()
                                    : null);
                            aLocation.CountryID = Convert.ToInt32(hdCountryID.Value);
                            aLocation.CurrentLocation = txtLocation.Text;
                            aLocationRt.AddLocation(aLocation);

                            material.LocationID = aLocation.IID;

                        }
                        catch (Exception exception)
                        {
                            throw new Exception(exception.Message, exception);
                        }
                    }
                }

                material.CategoryID = Convert.ToInt32(dropDownCategory.SelectedValue);
                //material.CategoryID = Convert.ToInt32(txtCategoryID.Value);

                if (txtModelID.Text != string.Empty || txtModelID.Text != "")
                {
                    material.ModelID = Convert.ToInt64(txtModelID.Text);
                }
                if (txtBrandID.Text != string.Empty || txtBrandID.Text != "")
                {
                    material.BrandID = Convert.ToInt64(txtBrandID.Text);
                }
                if (txtColorID.Text != string.Empty || txtColorID.Text != "")
                {
                    material.ColorID = Convert.ToInt64(txtColorID.Text);
                }

                material.Price = Convert.ToDecimal(txtPrice.Text.Trim() != string.Empty ? txtPrice.Text.Trim() : "0");
                material.TotalVisitor = 0;


                material.AdDate = GlobalRT.GetServerDateTime();
                DateTime date = GlobalRT.GetServerDateTime();
                material.AdDisplayLastDate = date.AddDays(Convert.ToDouble(txtPostVisibilityDay.Text.Trim() != string.Empty ? txtPostVisibilityDay.Text.Trim() : "10"));

                if (material.IID <= 0)
                {
                    material.CreatedBy = Convert.ToInt64(Session["UserID"]);
                    material.CreatedDate = GlobalRT.GetServerDateTime();
                }
                else
                {
                    Material mat = (Material)Session[sessMaterial];
                    material.CreatedBy = mat.CreatedBy;
                    material.CreatedDate = mat.CreatedDate;
                    material.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                    material.ModifiedDate = GlobalRT.GetServerDateTime();
                }

            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return material;
        }


        #region Private methods

        private bool TextControlCheckBeforeSave()
        {
            bool mandatoryFieldHasData = true;
            if (txtLocation.Text.Trim() == string.Empty)
            {
                labelMessage.Text = " Please select location for your post.";
                labelMessage.ForeColor = System.Drawing.Color.Yellow;
                labelMessage.Focus();
                mandatoryFieldHasData = false;
            }

            if (txtDescription.Text.Trim() == string.Empty)
            {
                labelMessage.Text = " Please write a description for your post.";
                labelMessage.ForeColor = System.Drawing.Color.Yellow;
                labelMessage.Focus();
                mandatoryFieldHasData = false;
            }

            if (txtTitleName.Text.Trim() == string.Empty)
            {
                labelMessage.Text = " Please give a title for your post.";
                labelMessage.ForeColor = System.Drawing.Color.Yellow;
                labelMessage.Focus();
                mandatoryFieldHasData = false;
            }


            return mandatoryFieldHasData;
        }
        public void ClearField()
        {
            txtBrand.Text = string.Empty;

            txtCode.Text = string.Empty;
            txtColor.Text = string.Empty;
            //txtDate.Text = string.Empty;
            txtDescription.Text = string.Empty;
          //  txtDisplayLastDate.Text = string.Empty;
            txtModel.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtTitleName.Text = string.Empty;
            txtDistrict.Text = string.Empty;
            txtUserID.Text = string.Empty;
            txtLocation.Text = string.Empty;
            txtPoliceStation.Text = string.Empty;

            txtColorID.Text = string.Empty;
            txtModelID.Text = string.Empty;
            txtBrandID.Text = string.Empty;
            txtPoliceStationID.Text = string.Empty;
            txtDistrictID.Text = string.Empty;
            txtLocationID.Text = string.Empty;

            hdIsEdit.Value = string.Empty;
            hdMaterialID.Value = string.Empty;

        }

        #endregion Private methods




        #region Protected Event

        protected void btnDeleteSelectedImage_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["seMatPicTempFileName"] != null)
                {
                    List<string> urlList = new List<string>();
                    foreach (DataListItem item in datalistMatPic.Items)
                    {
                        if ((item.FindControl("chkImg") as CheckBox).Checked)
                        {
                            Image img = (Image)item.FindControl("imgMatTempImage");
                            urlList.Add(img.ImageUrl);
                        }
                    }
                    List<ControlAdmin.MaterialWF.ImageUrl> temp = (List<ControlAdmin.MaterialWF.ImageUrl>)Session["seMatPicTempFileName"];
                    foreach (var url in urlList)
                    {
                        if (url != "App_Themes/Default/images/interface/no-picture.png")
                        {
                            File.Delete(Server.MapPath(url));
                        }
                        if (!url.StartsWith("~/Image/MatTempImage"))
                        {
                            using (PictureRT aPictureRt = new PictureRT())
                            {
                                aPictureRt.DeletePictureByUrl(url);
                            }
                        }

                        temp.Remove(temp.FirstOrDefault(x => x.ImageUrlTemp == url));
                    }

                    Session["seMatPicTempFileName"] = temp;
                    datalistMatPic.DataSource = temp;
                    datalistMatPic.DataBind();
                    if (temp.Count == 0)
                    {
                        Session["seMatPicTempFileName"] = null;
                        btnDeleteImageTemp.Visible = false;
                    }
                }
                labelMessage.Text = string.Empty;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }

        }


        protected void btnUpdatePost_Click(object sender, EventArgs e)
        {
            try
            {
                hdIsEdit.Value = "true";
                int imgCount = 0;
                int materialID = 0;
                string matCode = string.Empty;
                if (!TextControlCheckBeforeSave())
                {
                    return;
                }
                Material material = CreateMaterial();
                if (material == null)
                {
                    return;
                }
                List<ControlAdmin.MaterialWF.ImageUrl> matPicUrlList = new List<ControlAdmin.MaterialWF.ImageUrl>();

                btnMatPicUpload_Click(sender, e);

                var matPicListForTempUrl = (List<ControlAdmin.MaterialWF.ImageUrl>)Session["seMatPicTempFileName"];
                matPicUrlList = matPicListForTempUrl.Where(url => url.ImageUrlTemp.StartsWith("~/Image/MatTempImage")).ToList();//Set for temp img update
                List<Picture> pictureColl = new List<Picture>();
                matCode = material.Code;

                if (matPicUrlList.Count == 0)
                {
                    Picture aPicture = new Picture();
                    aPicture.MaterialID = material.IID;
                    string permanentImagePath = new ConstantCollection().noImageUrl;
                    aPicture.UrlAddress = permanentImagePath;
                    pictureColl.Add(aPicture);
                }
                else if (matPicUrlList.Count > 0)
                {
                    int tempImgCount = 0;
                    using (PictureRT aPictureRt = new PictureRT())
                    {
                        try
                        {
                            var imgList = aPictureRt.GetAllPicturesAccordingToMaterialID(material.IID).ToList();
                            if (imgList.Count > 0)
                            {
                                var picCount =
                                    (Path.GetFileNameWithoutExtension(
                                        Server.MapPath(
                                            aPictureRt.GetAllPicturesAccordingToMaterialID(material.IID)
                                                .OrderByDescending(pic => pic.UrlAddress)
                                                .FirstOrDefault()
                                                .UrlAddress)).Substring(13));

                                imgCount = Convert.ToInt32(picCount) + 1;
                                tempImgCount = imgCount;
                            }
                            else
                            {
                                imgCount = 1;//set image number if no image found
                            }

                        }
                        catch (Exception exception)
                        {
                            throw new Exception(exception.Message, exception);
                        }
                    }

                    foreach (var imageUrl in matPicUrlList)
                    {
                        Picture aPicture = new Picture();
                        aPicture.MaterialID = material.IID;
                        // string permanentImagePathToSave = Server.MapPath("~/Image/MatImage/") + matCode + "_" + count + (Path.GetExtension(imageUrl.ImageUrlTemp));//image path to save folder
                        string permanentImagePath = "~/Image/MatImage/" + matCode + "_" + imgCount + (Path.GetExtension(Server.MapPath(imageUrl.ImageUrlTemp)));//image path to save db
                        aPicture.UrlAddress = permanentImagePath;
                        // File.Move(Server.MapPath(imageUrl.ImageUrlTemp), permanentImagePathToSave);//move pic to permanent folder from tempPic folder
                        pictureColl.Add(aPicture);
                        imgCount++;
                    }
                    imgCount = tempImgCount;
                }

                if (material.AdGiverID != -1)
                {


                    using (MaterialRT aMaterialRt = new MaterialRT())
                    {
                        aMaterialRt.UpdateMaterial(material);
                    }


                    if (matPicUrlList.Count > 0)
                    {

                        using (PictureRT aPictureRt = new PictureRT())
                        {
                            foreach (var pic in pictureColl)
                            {
                                aPictureRt.AddMaterialPicture(pic);
                            }
                        }


                        foreach (var imageUrl in matPicUrlList)
                        {
                            Picture aPicture = new Picture();
                            aPicture.MaterialID = material.IID;
                            string permanentImagePathToSave = Server.MapPath("~/Image/MatImage/") + matCode + "_" + imgCount + (Path.GetExtension(imageUrl.ImageUrlTemp));//image path to save folder
                            string permanentImagePath = "~/Image/MatImage/" + matCode + "_" + imgCount + (Path.GetExtension(Server.MapPath(imageUrl.ImageUrlTemp)));//image path to save db
                            aPicture.UrlAddress = permanentImagePath;
                            File.Move(Server.MapPath(imageUrl.ImageUrlTemp), permanentImagePathToSave);//move pic to permanent folder from tempPic folder
                            imgCount++;
                        }
                    }
                    Session["seMatPicTempFileName"] = null;
                    Response.Redirect("~/ManageYourAds.aspx");
                    //labelMessage.Text = "Your post is successfully added, Your Post Code is " + matCode + " ..!!";
                    //labelMessage.ForeColor = System.Drawing.Color.Green;
                    //labelMessage.Focus();
                    ClearField();
                }
                else
                {
                    labelMessage.Text = String.Format("Please register frist. You can register here. <a href=\"{0}\">{1}</a>",
                        HttpUtility.HtmlEncode("UserRegistrationPage.aspx"), HttpUtility.HtmlEncode("Register now"));

                    labelMessage.ForeColor = System.Drawing.Color.Red;
                    labelMessage.Focus();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
                labelMessage.Focus();
            }
        }
        protected void btnDeletePost_Click(object sender, EventArgs e)
        {
            try
            {
                Int64 matId = Convert.ToInt64(Session["adGiverMatIID"]);
                using (MaterialAdGiverRT aMaterialAdminRt = new MaterialAdGiverRT())
                {
                    aMaterialAdminRt.DeleteFromMaterialAndPicAndSaveToLog(matId);
                    Response.Redirect("~/ManageYourAds.aspx");
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
                labelMessage.Focus();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearField();
            Response.Redirect("ManageYourAds.aspx");
        }

        protected void btnMatPicUpload_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["seMatPicTempFileName"] == null)
                {
                    Session["seMatPicTempFileName"] = new List<ControlAdmin.MaterialWF.ImageUrl>();
                }

                List<ControlAdmin.MaterialWF.ImageUrl> matPicTempFileUrlList = new List<ControlAdmin.MaterialWF.ImageUrl>();
                using (PictureRT aPictureRt = new PictureRT())
                {
                    List<Picture> picList = new List<Picture>();
                    picList = aPictureRt.GetPictureByMaterialIID(Convert.ToInt64(Session["adGiverMatIID"]));

                    if (picList.Count > 0)
                    {
                        foreach (var picture in picList)
                        {
                            ControlAdmin.MaterialWF.ImageUrl aImageUrl = new ControlAdmin.MaterialWF.ImageUrl();
                            aImageUrl.ImageUrlTemp = picture.UrlAddress;
                            matPicTempFileUrlList.Add(aImageUrl);
                        }
                    }
                }


                if (MatPicUpload.HasFile)
                {



                    foreach (var file in MatPicUpload.PostedFiles)
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
                        var tempMatImageName = now + rnd.Next();

                        matPicTempFileUrlList = (List<ControlAdmin.MaterialWF.ImageUrl>)Session["seMatPicTempFileName"];//read from sess

                        string path = Server.MapPath("~/Image/MatTempImage/");
                        FileUploadHelper.BindImage(file, path, tempMatImageName);


                        ControlAdmin.MaterialWF.ImageUrl imageUrl = new ControlAdmin.MaterialWF.ImageUrl();
                        imageUrl.ImageUrlTemp = "~/Image/MatTempImage/" + tempMatImageName + Path.GetExtension(file.FileName);
                        matPicTempFileUrlList.Add(imageUrl);
                        Session["seMatPicTempFileName"] = matPicTempFileUrlList;//write to sess


                        labelMessage.Text = "File uploaded!";

                    }
                    datalistMatPic.DataSource = matPicTempFileUrlList;
                    datalistMatPic.DataBind();
                    btnDeleteImageTemp.Visible = true;

                }
                else
                {
                    labelMessage.Text = "Please browse image(s)....";
                    labelMessage.ForeColor = System.Drawing.Color.Yellow;
                    labelMessage.Focus();
                }

            }
            catch (Exception ex)
            {
                labelMessage.Text = "error: " + ex.Message;
            }
        }



        #region hd Button Click
        protected void btnCategoryID_Click(object sender, EventArgs e)
        {
            try
            {
                long categoryID = Convert.ToInt64(dropDownCategory.SelectedValue);
                using (MappingCategoryRT rt = new MappingCategoryRT())
                {
                    var mapCat = rt.GetCategoryMapByCategoryID(categoryID);

                    bool isColorExist = false;
                    bool isBrandExist = false;
                    bool isModelExist = false;

                    foreach (var map in mapCat)
                    {
                        switch (map.MapName)
                        {
                            case "Brand":
                                isBrandExist = true;
                                break;
                            case "Color":
                                isColorExist = true;
                                break;
                            case "Model":
                                isModelExist = true;
                                break;
                        }
                    }
                    divBrand.Visible = isBrandExist;
                    divModel.Visible = isModelExist;
                    divColor.Visible = isColorExist;
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        #endregion hd Button Click



        #endregion Protected Event
    }
}