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

namespace OH.Web.ControlAdmin
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



                    LoadClientTypeDropDownInfo();
                    txtCode.Text = GetCodeForMaterial();
                    btnPostAd.Visible = true;
                    btnCancel.Visible = true;

                    divBrand.Visible = false;
                    divModel.Visible = false;
                    divColor.Visible = false;
                }
               
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        #region private methods


        #region ad post methods
        private void LoadClientTypeDropDownInfo()
        {
            try
            {
                DropDownListHelper.Bind(dropDownClientType, EnumHelper.EnumToList<EnumCollection.ClientType>());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }
        private Material CreateMaterial()
        {
            Session["UserID"] = "1";
            Material material = new Material();
            try
            {
                using (MaterialRT receiverTransfer = new MaterialRT())
                {
                    if (hdIsEdit.Value == "true")
                    {
                        material.IID = Convert.ToInt32(hdMaterialID.Value);
                    }
                    material.TitleName = txtTitleName.Text.Trim();
                    using (AdGiverRT adGRt = new AdGiverRT())
                    {
                        var adGiver = !txtUserID.Text.IsNullOrWhiteSpace() ? adGRt.GetAdGiverIDByEmail(txtUserID.Text) : null;

                        material.AdGiverID = adGiver != null ? adGiver.IID : -1;

                    }

                    material.Code = GetCodeForMaterial();
                    material.Description = txtDescription.Text.Trim();
                    material.IsFeatured = chkIsFeatured.Checked;
                    material.IsSpotlight = chkIsSpotlight.Checked;
                    material.IsUrgent = chkIsUrgent.Checked;
                    material.LocationID = Convert.ToInt64(txtLocation.Text);
                    material.CategoryID = Convert.ToInt32(txtCategory.Text);
                    material.ModelID = Convert.ToInt64(txtModel.Text);
                    material.BrandID = Convert.ToInt64(txtModel.Text);
                    material.ColorID = Convert.ToInt64(txtColor.Text);
                    material.Price = Convert.ToDecimal(txtPrice.Text);
                    material.TotalVisitor = 0;


                    material.AdDate = Convert.ToDateTime(txtDate.Text);
                    material.AdDisplayLastDate = Convert.ToDateTime(txtDisplayLastDate.Text);

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
            txtCategory.Text = string.Empty;
            txtCode.Text = GetCodeForMaterial();
            txtTitleName.Text = string.Empty;
            txtUserID.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtLocation.Text = string.Empty;
            txtBrand.Text = string.Empty;
            txtModel.Text = string.Empty;
            txtColor.Text = string.Empty;
            txtDate.Text = string.Empty;
            txtDisplayLastDate.Text = string.Empty;

            txtAdGiverName.Text = string.Empty;
            dropDownClientType.SelectedValue = "1";
            txtNationalID.Text = string.Empty;
            txtCompanyName.Text = string.Empty;
            txtCompanyAddress.Text = string.Empty;
            txtCompanyPhoneNo.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtContactNo.Text = string.Empty;
            txtPhNoOptional.Text = string.Empty;
            txtLocation.Text = string.Empty;

            chkIsFeatured.Checked = false;
            chkIsSpotlight.Checked = false;
            chkIsUrgent.Checked = false;
            btnPostAd.Visible = true;
        }
        #endregion ad post methods



        #region ad giver methods

        public AdGiver CreateAdGiver()
        {
            AdGiver adgiver = new AdGiver();
            try
            {

                using (AdGiverRT adGiverRt = new AdGiverRT())
                {
                    bool IsThisEmailAlreadyExist = adGiverRt.GetAdGiverIDByEmail(txtEmail.Text) != null;
                    if (IsThisEmailAlreadyExist)
                    {
                        return null;
                    }

                    adgiver.Name = txtAdGiverName.Text;
                    adgiver.ClientTypeID = Convert.ToInt32(dropDownClientType.SelectedValue);
                    adgiver.NationalID = txtNationalID.Text;
                    adgiver.CompanyOrOrganizationName = txtCompanyName.Text;
                    adgiver.ComOrOrgAddress = txtCompanyAddress.Text;
                    adgiver.ComOrOrgPhone = txtCompanyPhoneNo.Text;
                    adgiver.EmailID = txtEmail.Text;
                    adgiver.PhoneNo1 = txtContactNo.Text;
                    adgiver.PhoneNo2 = txtPhNoOptional.Text;
                    adgiver.LocationID = Convert.ToInt32(txtLocation.Text);
                }


            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return adgiver;
        }

        #endregion ad giver methods



        #endregion private methods



        #region protected event

        protected void btnPostAd_Click(object sender, EventArgs e)
        {
            try
            {
                using (MaterialRT receiverTransfer = new MaterialRT())
                {
                    AdGiverRT adGiverRt = new AdGiverRT();
                    string matCode = string.Empty;
                    AdGiver adGiver = new AdGiver();
                    Material material = CreateMaterial();

                    if (material.AdGiverID == -1)
                    {
                        adGiver = CreateAdGiver();
                        if (adGiver != null)
                        {
                            adGiverRt.AddAdGiver(adGiver);
                            material.AdGiverID = adGiverRt.GetAdGiverIDByEmail(adGiver.EmailID).IID;
                            receiverTransfer.AddMaterial(material);
                            matCode = material.Code;
                        }


                    }
                    else
                    {
                        receiverTransfer.AddMaterial(material);
                        matCode = material.Code;
                    }

                    if (material.IID > 0)
                    {
                        labelMessage.Text = "Your ad successfully posted...and your material code is " + matCode;
                        labelMessage.ForeColor = System.Drawing.Color.Green;
                        ClearField();
                    }
                    else if (adGiver == null)
                    {
                        labelMessage.Text = "This email already taken...";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        labelMessage.Text = "Data not saved...";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                    }

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
        }

        protected void btnMatPicUpload_Click(object sender, EventArgs e)
        {

            try
            {
                if (MatPicUpload.HasFile)
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

                    var tempFilename = Path.GetFileName(tempMatImageName + MatPicUpload.FileName);

                    List<ImageUrl> matPicTempFileUrlList = new List<ImageUrl>();
                    if (Session["seMatPicTempFileName"] == null)
                    {
                        Session["seMatPicTempFileName"] = new List<ImageUrl>();
                    }
                    matPicTempFileUrlList = (List<ImageUrl>)Session["seMatPicTempFileName"];//read from sess

                    string path = Server.MapPath("~/Image/MatTempImage/") + tempFilename;
                    ImageUrl imageUrl=new ImageUrl();
                    imageUrl.ImageUrlTemp = path;

                    matPicTempFileUrlList.Add(imageUrl);

                    Session["seMatPicTempFileName"] = matPicTempFileUrlList;//write to sess

                    MatPicUpload.SaveAs(Server.MapPath("~/Image/MatTempImage/") + tempFilename);

                    labelMessage.Text = "File uploaded!";


                    datalistTempMatImage.DataSource = matPicTempFileUrlList;
                    datalistTempMatImage.DataBind();

                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "error: " + ex.Message;
            }

        }


       

        #region hidden button click event
        protected void btnCategoryID_Click(object sender, EventArgs e)
        {
            try
            {
                long categoryID = Convert.ToInt64(txtCategoryID.Text);
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

                    divColor.Visible = isColorExist;
                    divModel.Visible = isModelExist;
                    divBrand.Visible = isBrandExist;
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