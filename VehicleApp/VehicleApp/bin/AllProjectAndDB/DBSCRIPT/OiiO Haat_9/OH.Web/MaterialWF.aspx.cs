using System.Globalization;
using System.IO;
using System.Text;
using System.Web.Providers.Entities;
using Microsoft.Ajax.Utilities;
using OH.BLL.Basic;
using OH.DAL;
using OH.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.UI;
using System.Web.UI.WebControls;

namespace OH.Web
{
    public partial class MaterialWF : System.Web.UI.Page
    {
        private const string sessMaterial = "seMaterial";
        public class ImageUrl
        {
            public string ImageUrlPer { get; set; }
            public string ImageUrlTemp { get; set; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    LoadDefaultLoginLogout();
                    Session["seMatPicTempFileName"] = null;
                    txtCode.Text = GetCodeForMaterial();
                    txtUserID.Text = Session["UserName"].ToString();
                    btnPostAd.Visible = true;
                    btnCancel.Visible = true;
                    divModel.Visible = false;
                    divBrand.Visible = false;
                    divColor.Visible = false;
                    btnDeleteImageTemp.Visible = false;

                    int countryID = Convert.ToInt32(EnumCollection.Country.Bangladesh);//change here for change country
                    hdCountryID.Value = countryID.ToString();
                    LoadAdGiver();
                    LoadDropDownForCategory();
                    LoadDropDownForDistrict();
                    LoadDropDownForPoliceStaion();
                }

              
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private  void LoadAdGiver()
        {
             using (AdGiverRT adGRt = new AdGiverRT())
                    {
                        string Email = Session["UserName"].ToString();
                        var adGiver = !txtUserID.Text.IsNullOrWhiteSpace() ? adGRt.GetAdGiverIDByEmail(Email) : null;
                        txtPhoneNumber.Text= adGiver.PhoneNo1;
                        txtUserID.Text = adGiver.Name;
                        txtEmail.Text = adGiver.EmailID;
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
        private void LoadDropDownForDistrict()
        {
            try
            {
                using (DistrictRT aDistrictRt = new DistrictRT())
                {
                    var districtList = aDistrictRt.GetDistrictByCountryId(Convert.ToInt32(hdCountryID.Value));
                    DropDownListHelper.Bind(dropdownDistrict, districtList, "Name", "IID");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private void LoadDropDownForPoliceStaion()
        {
            try
            {
                using (PoliceStationRT aPoliceStationRt = new PoliceStationRT())
                {
                    var policeStationList = aPoliceStationRt.GetPoliceStationByCountryIdAndDistrictId(Convert.ToInt32(hdCountryID.Value),Convert.ToInt64(dropdownDistrict.SelectedValue));
                    DropDownListHelper.Bind(dropdownPoliceStation, policeStationList, "Name", "IID");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        private void LoadDefaultLoginLogout()
        {
            try
            {
                if (Session["UserName"] != null)
                {
                    var userText = Session["UserName"] != null ? Session["UserName"].ToString() : string.Empty;

                    //var _findUser = _userInformationRT.FindUserByUserName(Convert.ToString(Session["UserName"]));
                    //var objUserGroup = _userInformationRT.FindUserGroup(_findUser != null ? _findUser.UserGroupID : default(Int64));

                    //if (objUserGroup != null)
                    //{
                    //    if (Convert.ToInt32(objUserGroup.TypeID) == Convert.ToInt32(OH.Utilities.EnumCollection.UserGrpType.Add_Giver))
                    //    {
                    //        Response.Redirect("~/MaterialWF.aspx");
                    //    }
                    //    else
                    //    {
                    //        Response.Redirect("~/Default.aspx");
                    //    }
                    //}
                }
                else
                {
                    Response.Redirect("~/LoginPage.aspx");
                }
            }
            catch (Exception ex)
            {

            }
        }

        #region private methods

        private bool TextControlCheckBeforeSave()
        {
            bool mandatoryFieldHasData = true;
            if (txtLocation.Text.Trim() == string.Empty)
            {
                labelMessage.Text = " Please select location for your post.";
                labelMessage.ForeColor = System.Drawing.Color.Red;
               // labelMessage.Focus();
                mandatoryFieldHasData = false;
            }

            if (txtDescription.Text.Trim() == string.Empty)
            {
                labelMessage.Text = " Please write a description for your post.";
                labelMessage.ForeColor = System.Drawing.Color.Red;
               // labelMessage.Focus();
                mandatoryFieldHasData = false;
            }

            if (txtTitleName.Text.Trim() == string.Empty)
            {
                labelMessage.Text = " Please give a title for your post.";
                labelMessage.ForeColor = System.Drawing.Color.Red;
                //labelMessage.Focus();
                mandatoryFieldHasData = false;
            }
            if (txtEmail.Text == string.Empty && txtPhoneNumber.Text == string.Empty)
            {
                lblAdGiverInfo.Text = "Please select at least one option to be contacted by.";
                lblAdGiverInfo.ForeColor = System.Drawing.Color.Red;
                
                mandatoryFieldHasData = false;
            }

            //if (txtCategoryID.Value.Trim() == string.Empty)
            //{
            //    //if (txtCategory.Text.Trim() == string.Empty)
            //    //{
            //    //    labelMessage.Text = " Please select category for your post.";
            //    //}
            //    //else
            //    //{
            //    //    labelMessage.Text = " Please select a valid category for your post, see all category " + "'press space'" + " on category field.";
            //    //}
            //    labelMessage.ForeColor = System.Drawing.Color.Yellow;
            //    labelMessage.Focus();
            //    mandatoryFieldHasData = false;
            //}

            return mandatoryFieldHasData;
        }

        #region ad post methods
        private Material CreateMaterial()
        {

            Material material = new Material();
            try
            {
                using (MaterialRT receiverTransfer = new MaterialRT())
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
                    //if (string.IsNullOrEmpty(txtDistrict.Text.Trim()) || string.IsNullOrEmpty(txtDistrictID.Text.Trim()))
                    //{
                    //    labelMessage.Text = "Please enter district";
                    //    return null;
                    //}
                    if (string.IsNullOrEmpty(dropdownPoliceStation.SelectedValue))
                    {
                        labelMessage.Text = "Please enter police station";
                        return null;
                    }

                    material.TitleName = txtTitleName.Text.Trim();
                    using (AdGiverRT adGRt = new AdGiverRT())
                    {
                        var adGiver = !txtUserID.Text.IsNullOrWhiteSpace() ? adGRt.GetAdGiverIDByEmail(txtEmail.Text) : null;
                        material.AdGiverID = adGiver != null ? adGiver.IID : -1;
                        material.AdTypeID = adGiver.ClientTypeID;
                      
                        
                    }
                    if (txtEmail.Text != string.Empty && txtPhoneNumber.Text != string.Empty)
                    {
                        material.UserEmail = txtEmail.Text;
                        material.UserPhoneNumber = txtPhoneNumber.Text;
                    }
                    else if (txtEmail.Text == string.Empty && txtPhoneNumber.Text != string.Empty)
                    {
                        material.UserEmail = null;
                        material.UserPhoneNumber = txtPhoneNumber.Text;
                    }
                    else if (txtEmail.Text != string.Empty && txtPhoneNumber.Text == string.Empty)
                    {
                        material.UserEmail = txtEmail.Text;
                        material.UserPhoneNumber = null;
                    }
                    //else
                    //{
                    //    material.UserEmail =null;
                    //    material.UserPhoneNumber = null;
                        
                    //}
                    material.Code = GetCodeForMaterial();
                    material.Description =Server.HtmlEncode(txtDescription.Text);
                    material.IsFeatured = chkIsFeatured.Checked;
                    material.IsSpotlight = chkIsSpotlight.Checked;
                    material.IsUrgent = chkIsUrgent.Checked;

                    //for dropdown
                    if (txtLocation.Text != "" || txtLocation.Text != string.Empty)
                    {
                        using (LocationRT aLocationRt = new LocationRT())
                        {
                            Location aLocation = new Location();
                            aLocation.CurrentLocation = txtLocation.Text;
                            aLocation.DistrictID = Convert.ToInt64(dropdownDistrict.SelectedValue);
                            aLocation.PoliceStationID = Convert.ToInt64(dropdownPoliceStation.SelectedValue);
                            aLocation.CountryID = Convert.ToInt32(hdCountryID.Value);
                            aLocation.CurrentLocation = txtLocation.Text;
                            aLocationRt.AddLocation(aLocation);
                            material.LocationID = aLocation.IID;
                        }
                    }


                    //if (txtLocationID.Text != "" || txtLocationID.Text != string.Empty)
                    //{
                    //    material.LocationID = Convert.ToInt64(txtLocationID.Text);
                    //}
                    //else
                    //{
                    //    try
                    //    {
                    //        using (LocationRT aLocationRt = new LocationRT())
                    //        {
                    //            Location aLocation = new Location();
                    //            if (txtLocation.Text != "" || txtLocation.Text != string.Empty)
                    //            {
                    //                aLocation.CurrentLocation = txtLocation.Text;
                    //            }
                    //            aLocation.DistrictID = Convert.ToInt64(txtDistrictID.Text.Trim() != null ? txtDistrictID.Text.Trim() : null);
                    //            aLocation.PoliceStationID = Convert.ToInt64(txtPoliceStationID.Text.Trim() != null ? txtPoliceStationID.Text.Trim() : null);
                    //            aLocation.CountryID = Convert.ToInt32(hdCountryID.Value);
                    //            aLocation.CurrentLocation = txtLocation.Text;
                    //            aLocationRt.AddLocation(aLocation);

                    //            material.LocationID = aLocation.IID;
                    //        }
                    //    }
                    //    catch (Exception exception)
                    //    {
                    //        throw new Exception(exception.Message, exception);
                    //    }

                    //}

                    material.CategoryID = Convert.ToInt32(dropDownCategory.SelectedValue);
                    //material.CategoryID = Convert.ToInt32(txtCategoryID.Value);

                    if (txtModelID.Value != string.Empty || txtModelID.Value != "")
                    {
                        material.ModelID = Convert.ToInt64(txtModelID.Value);
                    }
                    if (txtBrandID.Value != string.Empty || txtBrandID.Value != "")
                    {
                        material.BrandID = Convert.ToInt64(txtBrandID.Value);
                    }
                    if (txtColorID.Value != string.Empty || txtColorID.Value != "")
                    {
                        material.ColorID = Convert.ToInt64(txtColorID.Value);
                    }
                    material.IsNegotiablePrice = chkNegotiable.Checked;
                    material.WebSiteUrl = txtWeburl.Text;
                    material.YoutubeUrl = txtYoutubeUrl.Text;
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

            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return material;
        }

        private string GetCodeForMaterial()
        {
            string startCode = "000001";
            decimal newCode = 0;
            DateTime date = GlobalRT.GetServerDateTime();
            try
            {
                using (MaterialRT receiverTransfer = new MaterialRT())
                {
                    string lastCode = receiverTransfer.GetLastCode().ToString();
                    string currentYear = date.Year.ToString();
                    string currentMonth = date.Month.ToString();
                    if (currentMonth.Length == 1)
                    {
                        currentMonth = 0 + currentMonth;
                    }
                    if (lastCode.Equals("0"))
                    {
                        lastCode = startCode;
                    }
                    string lastCodeYearMonth = lastCode.Substring(0, 6);
                    string currentCodeYearMonth = currentYear + currentMonth;

                    if (lastCodeYearMonth == currentCodeYearMonth)
                    {
                        newCode = Convert.ToDecimal(lastCode) + 1;
                    }
                    else
                    {
                        newCode = Convert.ToDecimal(currentYear + currentMonth + startCode);
                    }
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return newCode.ToString();
        }

        private void ClearField()
        {
            if (Session["seMatPicTempFileName"] != null)
            {
                List<ImageUrl> matPicUrlList = new List<ImageUrl>();
                matPicUrlList = (List<ImageUrl>)Session["seMatPicTempFileName"];
                foreach (var imageUrl in matPicUrlList)
                {
                    File.Delete(Server.MapPath(imageUrl.ImageUrlTemp));
                }
                Session["seMatPicTempFileName"] = null;
            }

            datalistTempMatImage.DataSource = null;
            datalistTempMatImage.DataBind();

            // txtPoliceStation.Text = string.Empty;
            txtPoliceStationID.Text = string.Empty;
            // txtDistrict.Text = string.Empty;
            txtDistrictID.Text = string.Empty;

            //txtCategory.Text = string.Empty;
            txtCode.Text = GetCodeForMaterial();
            txtTitleName.Text = string.Empty;
           // txtUserID.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtLocation.Text = string.Empty;
            txtBrand.Text = string.Empty;
            txtModel.Text = string.Empty;
            txtColor.Text = string.Empty;
            //txtDate.Text = string.Empty;
            txtPostVisibilityDay.Text = string.Empty;
            txtPrice.Text = string.Empty;

            txtLocation.Text = string.Empty;

            chkIsFeatured.Checked = false;
            chkIsSpotlight.Checked = false;
            chkIsUrgent.Checked = false;
            btnPostAd.Visible = true;
        }
        #endregion ad post methods

        #endregion private methods

        #region protected event

        protected void dropdownDistrict_SelectedIndexChange(object sender, EventArgs e)
        {
            LoadDropDownForPoliceStaion();
        }

        //protected void dropdownPoliceStation_SelectedIndexChange(object sender, EventArgs e)
        //{

        //}



        protected void btnDeleteImageTemp_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["seMatPicTempFileName"] != null)
                {
                    List<string> urlList = new List<string>();
                    foreach (DataListItem item in datalistTempMatImage.Items)
                    {
                        if ((item.FindControl("chkImg") as CheckBox).Checked)
                        {
                            Image img = (Image)item.FindControl("imgMatTempImage");
                            urlList.Add(img.ImageUrl);
                        }
                    }
                    List<ImageUrl> temp = (List<ImageUrl>)Session["seMatPicTempFileName"];
                    foreach (var url in urlList)
                    {
                        File.Delete(Server.MapPath(url));
                        temp.Remove(temp.FirstOrDefault(x => x.ImageUrlTemp == url));
                    }

                    Session["seMatPicTempFileName"] = temp;
                    datalistTempMatImage.DataSource = temp;
                    datalistTempMatImage.DataBind();
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

        protected void btnPostAd_Click(object sender, EventArgs e)
        {
            try
            {
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
                List<ImageUrl> matPicUrlList = new List<ImageUrl>();
                if (MatPicUpload.HasFile)
                {
                    btnMatPicUpload_Click(sender, e);
                }
                //else
                //{
                //    labelMessage.Text = "Select Image";
                    
                //}

                matPicUrlList = (List<ImageUrl>)Session["seMatPicTempFileName"];
                List<Picture> pictureColl = new List<Picture>();
                matCode = material.Code;
                if (matPicUrlList == null)
                {
                    Picture aPicture = new Picture();
                    aPicture.MaterialID = material.IID;
                    string permanentImagePath = new ConstantCollection().noImageUrl;
                    aPicture.UrlAddress = permanentImagePath;
                    pictureColl.Add(aPicture);
                }
                else if (matPicUrlList.Count > 0)
                {
                    int count = 1;
                    foreach (var imageUrl in matPicUrlList)
                    {
                        Picture aPicture = new Picture();
                        aPicture.MaterialID = material.IID;
                        string permanentImagePathToSave = Server.MapPath("~/Image/MatImage/") + matCode + "_" + count + (Path.GetExtension(imageUrl.ImageUrlTemp));//image path to save folder
                        string permanentImagePath = "~/Image/MatImage/" + matCode + "_" + count + (Path.GetExtension(Server.MapPath(imageUrl.ImageUrlTemp)));//image path to save db
                        aPicture.UrlAddress = permanentImagePath;
                        // File.Move(Server.MapPath(imageUrl.ImageUrlTemp), permanentImagePathToSave);//move pic to permanent folder from tempPic folder
                        pictureColl.Add(aPicture);
                        count++;
                    }
                }



                if (material.AdGiverID != -1)
                {
                    string materialAllChildXML = ConversionXML.ConvertObjectToXML<Material, Picture>(material, pictureColl, string.Empty);
                    materialID = MaterialRT.InsertMaterialAndAllChildXML(materialAllChildXML);

                    if (materialID == -100)
                    {
                        labelMessage.Text = "Network connection fail ... Please try again..!!";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                    }
                    else if (materialID == -101)
                    {
                        labelMessage.Text = "Network connection fail ... Please try again..!!";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                    }
                    else if (materialID > 0)
                    {

                        if (matPicUrlList.Count > 0)
                        {
                            int count = 1;
                            foreach (var imageUrl in matPicUrlList)
                            {
                                Picture aPicture = new Picture();
                                aPicture.MaterialID = material.IID;
                                string permanentImagePathToSave = Server.MapPath("~/Image/MatImage/") + matCode + "_" + count + (Path.GetExtension(imageUrl.ImageUrlTemp));//image path to save folder
                                string permanentImagePath = "~/Image/MatImage/" + matCode + "_" + count + (Path.GetExtension(Server.MapPath(imageUrl.ImageUrlTemp)));//image path to save db
                                aPicture.UrlAddress = permanentImagePath;
                                File.Move(Server.MapPath(imageUrl.ImageUrlTemp), permanentImagePathToSave);//move pic to permanent folder from tempPic folder
                                count++;
                            }
                        }


                        labelMessage.Text = "Your post is successfully added, Your Post Code is " + matCode + " ..!!";
                        labelMessage.ForeColor = System.Drawing.Color.Green;
                        ClearField();
                    }
                }
                else
                {
                    labelMessage.Text = String.Format("Please register first. You can register here. <a href=\"{0}\">{1}</a>",
                        HttpUtility.HtmlEncode("UserRegistrationPage.aspx"), HttpUtility.HtmlEncode("Register now"));

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
            ClearField();
            labelMessage.Text = string.Empty;
            Response.Redirect("~/Default");  
        }
        protected void btnMatPicUpload_Click(object sender, EventArgs e)
        {
            string debugStr = string.Empty;
            try
            {
                if (MatPicUpload.HasFile)
                {
                    List<ImageUrl> matPicTempFileUrlList = new List<ImageUrl>();
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

                        if (Session["seMatPicTempFileName"] == null)
                        {
                            Session["seMatPicTempFileName"] = new List<ImageUrl>();
                        }
                        matPicTempFileUrlList = (List<ImageUrl>)Session["seMatPicTempFileName"];//read from sess                       
                        string path = Server.MapPath("~/Image/MatTempImage/");
                        
                        debugStr += "FileName :" + tempMatImageName + "PsotFile :" + file.ToString() + "Server Path :" + path;
                        
                        FileUploadHelper.BindImage(file, path, tempMatImageName);                       
                        ImageUrl imageUrl = new ImageUrl();
                        imageUrl.ImageUrlTemp = "~/Image/MatTempImage/" + tempMatImageName + Path.GetExtension(file.FileName);
                        matPicTempFileUrlList.Add(imageUrl);
                        Session["seMatPicTempFileName"] = matPicTempFileUrlList;//write to sess


                        labelMessage.Text = "File uploaded!";
                        labelMessage.ForeColor = System.Drawing.Color.Green;

                    }
                    datalistTempMatImage.DataSource = matPicTempFileUrlList;
                    datalistTempMatImage.DataBind();

                    if (Session["seMatPicTempFileName"] != null)
                    {
                        btnDeleteImageTemp.Visible = true;
                    }

                }
                else
                {

                    labelMessage.Text = "Please browse image(s)....";
                    labelMessage.ForeColor = System.Drawing.Color.Red;
                }

            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error: " + ex.Message +"Stack Info "+ex.StackTrace + "Debug Info :" + debugStr;
                if (ex.InnerException != null)
                {
                    labelMessage.Text = "Error: " + ex.Message + "Inner Message :"+ex.InnerException.Message + " Stack Info " + ex.StackTrace + "Debug Info :" + debugStr;
                }
            }

        }

        #region hidden button click event
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
        #endregion hidden button click event

        #endregion protected event
    }
}