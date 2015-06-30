using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Basic;
using Utilities;
using DAL;
using System.Globalization;
using System.Text;
using System.IO;

namespace OMart.Web.AdminPanel
{
    public partial class AllFeatureInsertUpdate : System.Web.UI.Page
    {
        private readonly AllFeatureRT _allFeatureRT;
        private const string sessAllFetureDetail = "seAllFeatureDetail";
        private int IID = default(Int32);


        #region private method
        private void LoadDropDownForBusinessType()
        {
            try
            {

                DropDownListHelper.Bind(dropDownBusinessType, EnumHelper.EnumCamelSpaceToList<EnumCollection.BussinessType>(), EnumCollection.ListItemType.BussinessType);
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void LoadDropDownForBusinessTypeBreakdown()
        {
            try
            {

                dropDownBusinessTypeBreakdown.Items.Clear();
                dropDownBusinessTypeBreakdown.Items.Add(new ListItem("--Select--", "-1"));
                switch (dropDownBusinessType.SelectedValue)
                {
                    case "1":
                        DropDownListHelper.Bind(dropDownBusinessTypeBreakdown, EnumHelper.EnumCamelSpaceToList<EnumCollection.BusinessEnergyType>());
                        break;
                    case "2":
                        DropDownListHelper.Bind(dropDownBusinessTypeBreakdown, EnumHelper.EnumCamelSpaceToList<EnumCollection.BusinessBankingType>());
                        break;
                    case "3":
                        DropDownListHelper.Bind(dropDownBusinessTypeBreakdown, EnumHelper.EnumCamelSpaceToList<EnumCollection.BusinessTravelType>());
                        break;
                    case "4":
                        DropDownListHelper.Bind(dropDownBusinessTypeBreakdown, EnumHelper.EnumCamelSpaceToList<EnumCollection.BusinessInsuranceType>());
                        break;
                    case "5":
                        DropDownListHelper.Bind(dropDownBusinessTypeBreakdown, EnumHelper.EnumCamelSpaceToList<EnumCollection.BusinessShoppingType>());
                        break;
                    case "6":
                        DropDownListHelper.Bind(dropDownBusinessTypeBreakdown, EnumHelper.EnumCamelSpaceToList<EnumCollection.BusinessMobilePhonesType>());
                        break;
                    case "7":
                        DropDownListHelper.Bind(dropDownBusinessTypeBreakdown, EnumHelper.EnumCamelSpaceToList<EnumCollection.NetworkServiceProvider>());
                        break;
                    case "8":
                        DropDownListHelper.Bind(dropDownBusinessTypeBreakdown, EnumHelper.EnumCamelSpaceToList<EnumCollection.BusinessBroadbandType>());
                        break;
                }

            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void ShowAllFeatureDetailsData()
        {
            lvAllFeatureDetails.DataSource = Session[sessAllFetureDetail];
            lvAllFeatureDetails.DataBind();
        }

        private void ShowAllFeatureData()
        {
            try
            {
                AllFeature allFeature = _allFeatureRT.GetAllFeatureById(IID);
                if (allFeature.IsRemoved)
                {
                    labelMessage.Text = "Error : this information has been removed.";
                    labelMessage.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                if (allFeature.IID > 0)
                {

                    Session[sessAllFetureDetail] = new List<AllFeatureDetail>(_allFeatureRT.GetAllFeatureDetailListByAllFeatureId(allFeature.IID));


                    txtDescription.Text = allFeature.Description;
                    txtTitleName.Text = allFeature.TitleName;
                    dropDownBusinessType.SelectedValue = allFeature.BusinessTypeID.ToString();
                    LoadDropDownForBusinessTypeBreakdown();
                    dropDownBusinessTypeBreakdown.SelectedValue = allFeature.BusinessTypeBreakdownID.ToString();
                }
                ShowAllFeatureDetailsData();
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private AllFeatureDetail CreateAllFeatureDetails()
        {
            AllFeatureDetail allfeatureDetail = new AllFeatureDetail();
            try
            {
                if (IID >= 0)
                {
                    allfeatureDetail.IID = IID;
                }
                allfeatureDetail.TitleName = txtDetailTitleName.Text.Trim();

                /* For Child picture*/

                if (childPictureUpload.HasFile)
                {
                    allfeatureDetail.ImageUrl = ImageUpload(childPictureUpload, "~/All Photos/AllFeatureDetails/").ToString();
                }



                allfeatureDetail.Description = txtDetailDescription.Text.Trim();
                allfeatureDetail.IsRemoved = false;
                if (allfeatureDetail.CreatedBy == 0)
                {
                    allfeatureDetail.CreatedBy = Convert.ToInt64(Session["UserID"]);
                    allfeatureDetail.CreatedDate = GlobalRT.GetServerDateTime();
                }
                else
                {
                    allfeatureDetail.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                    allfeatureDetail.ModifiedDate = GlobalRT.GetServerDateTime();
                }

            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return allfeatureDetail;
        }
        private AllFeature CreateAllFeature()
        {

            AllFeature allFeature = new AllFeature();
            try
            {
                if (IID >= 0)
                {
                    allFeature.IID = IID;
                }
                allFeature.TitleName = txtTitleName.Text.Trim();
                allFeature.Description = txtDescription.Text.Trim();
                if (parentPictureFileUpload.HasFile)
                {
                    allFeature.ImageUrl = ImageUpload(parentPictureFileUpload, "~/All Photos/AllFeature/").ToString();
                }
                if (dropDownBusinessTypeBreakdown.SelectedValue == "-1")
                {
                    allFeature.BusinessTypeBreakdownID = 0;
                }
                else if (dropDownBusinessTypeBreakdown.SelectedValue != "-1")
                {
                    allFeature.BusinessTypeBreakdownID = Convert.ToInt32(dropDownBusinessTypeBreakdown.SelectedValue);
                }
                if (dropDownBusinessType.SelectedValue != "-1")
                {
                    allFeature.BusinessTypeID = Convert.ToInt32(dropDownBusinessType.SelectedValue);
                }


                if (allFeature.CreatedBy == 0)
                {
                    allFeature.CreatedBy = Convert.ToInt64(Session["UserID"]);
                    allFeature.CreatedDate = GlobalRT.GetServerDateTime();
                }
                else
                {
                    allFeature.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                    allFeature.ModifiedDate = GlobalRT.GetServerDateTime();
                }
                allFeature.IsRemoved = false;
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return allFeature;
        }
        private void ClearData()
        {
            txtDescription.Text = string.Empty;
            txtDetailDescription.Text = string.Empty;
            txtDetailTitleName.Text = string.Empty;
            txtTitleName.Text = string.Empty;
            dropDownBusinessTypeBreakdown.SelectedValue = "-1";
            dropDownBusinessType.SelectedValue = "-1";
            lvAllFeatureDetails.Items.Clear();
        }

        private bool IsExist(int bussinessTypeID, int bussinessTypeBrID)
        {
            using (AllFeatureRT rt = new AllFeatureRT())
            {
                if (rt.IsExistFeature(bussinessTypeID, bussinessTypeBrID))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
        private string BusinessLogicValidationAllFeature()
        {
            string msg = string.Empty;
            try
            {
                if (string.IsNullOrWhiteSpace(txtTitleName.Text))
                {
                    msg = "please enter a title";
                }
                if (string.IsNullOrWhiteSpace(txtDescription.Text))
                {
                    msg = "please enter description";
                }
                if (dropDownBusinessType.SelectedValue == "-1")
                {
                    msg = "please select business type";
                }

            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return msg;
        }
        private void ClearAllNewsData()
        {
            txtDetailDescription.Text = string.Empty;
            txtDetailTitleName.Text = string.Empty;
        }

        private string BusinessLogicValidationAllFeatureDetail(AllFeatureDetail allFeatureDetail)
        {
            string msg = string.Empty;
            try
            {
                if (string.IsNullOrWhiteSpace(txtDetailTitleName.Text))
                {
                    msg = "please enter a title";
                }
                if (string.IsNullOrWhiteSpace(txtDetailDescription.Text))
                {
                    msg = "please enter description";
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return msg;
        }

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
        #endregion private method

        #region constructor
        public AllFeatureInsertUpdate()
        {
            _allFeatureRT = new AllFeatureRT();
        }

        #endregion constructor

        #region protected method
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadDropDownForBusinessType();
                    LoadDropDownForBusinessTypeBreakdown();

                    var requestId = Request.QueryString["IID"];
                    bool reqIDIsValid = Int32.TryParse(requestId, out IID);
                    if (reqIDIsValid)
                    {
                        ShowAllFeatureData();
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }

        }

        protected void dropDownBusinessType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (dropDownBusinessType.SelectedValue != "-1")
                {
                    LoadDropDownForBusinessTypeBreakdown();
                }

            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        int lvRowCount = 0;
        int currentPage = 0;

        protected void lvAllFeatureDetails_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            labelMessage.Text = string.Empty;
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void dataPagerAllNewsDetails_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    // ShowAllNewsDetailsData();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lnkbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton linkButton = new LinkButton();
                linkButton = (LinkButton)sender;
                List<AllFeatureDetail> allFeatureDetailList = (List<AllFeatureDetail>)Session[sessAllFetureDetail];
                if (allFeatureDetailList.Count > 0)
                {
                    allFeatureDetailList.Remove(allFeatureDetailList.FirstOrDefault(x => x.TitleName == linkButton.CommandArgument));
                    Session[sessAllFetureDetail] = allFeatureDetailList;
                    ShowAllFeatureDetailsData();

                    //labelMessage.Text = "News details has been removed successfully.";
                    //labelMessage.ForeColor = System.Drawing.Color.Green;

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
                Response.Redirect("~/AdminPanel/AllFeatureDisplay.aspx");
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnCreateOrEdit_Click(object sender, EventArgs e)
        {
            try
            {
                var msg = BusinessLogicValidationAllFeature();
                if (!string.IsNullOrWhiteSpace(msg))
                {
                    labelMessage.Text = msg;
                    labelMessage.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                bool reqIDIsValid = int.TryParse(Request.QueryString["IID"], out IID);
                if (IID <= 0)
                {
                    if (IsExist(Convert.ToInt32(dropDownBusinessType.SelectedValue.ToString()), Convert.ToInt32(dropDownBusinessTypeBreakdown.SelectedValue.ToString())))
                    {
                        labelMessage.Text = dropDownBusinessType.Text + " is already exist";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }

                string feature = string.Empty;
                AllFeature allFeature = CreateAllFeature();               

                if (IID <= 0)
                {
                    List<AllFeatureDetail> allFeatureDetailColl = new List<AllFeatureDetail>();
                    List<AllFeatureDetail> allFeatureDetailList = (List<AllFeatureDetail>)Session[sessAllFetureDetail];

                    if (allFeatureDetailList != null)
                    {
                        if (allFeatureDetailList.Count > 0)
                        {
                            allFeatureDetailColl = allFeatureDetailList;
                        }

                        string allNewsWithAllChildAllNewsDetailXML = ConversionXML.ConvertObjectToXML<AllFeature, AllFeatureDetail>(allFeature, allFeatureDetailList, string.Empty);

                        int allFeatureId = AllFeatureRT.InsertAllFetureAndAllChildAllFeatureCartDetailsXML(allNewsWithAllChildAllNewsDetailXML);
                        if (allFeatureId > 0)
                        {
                            Session[sessAllFetureDetail] = new List<AllFeatureDetail>();
                            ClearData();
                            labelMessage.Text = "Information has been inserted successfully.";
                            labelMessage.ForeColor = System.Drawing.Color.Green;
                            Response.Redirect("AllFeatureDisplay");
                        }
                        else if (allFeatureId == -100)
                        {
                            labelMessage.Text = "Network connection fail ... Please try again..!!";
                            labelMessage.ForeColor = System.Drawing.Color.Red;
                            labelMessage.Focus();
                        }
                        else if (allFeatureId == -101)
                        {
                            labelMessage.Text = "Network connection fail ... Please try again..!!";
                            labelMessage.ForeColor = System.Drawing.Color.Red;
                            labelMessage.Focus();
                        }
                        else
                        {
                            labelMessage.Text = "Error";
                            labelMessage.ForeColor = System.Drawing.Color.Red;
                        }

                    }
                    else
                    {
                        using (AllFeatureRT rt = new AllFeatureRT())
                        {
                            rt.AddAllFeature(allFeature);
                            labelMessage.Text = "Information has been inserted successfully.";
                            Response.Redirect("AllFeatureDisplay");
                            labelMessage.ForeColor = System.Drawing.Color.Green;
                            ClearData();
                        }
                    }


                }
                else
                {
                    AllFeature objAllFeature = _allFeatureRT.GetAllFeatureById(IID);

                    if (objAllFeature != null)
                    {
                        allFeature.IID = objAllFeature.IID;
                        if (parentPictureFileUpload.HasFile == false)
                        {
                            allFeature.ImageUrl =objAllFeature.ImageUrl ;
                        }
                        allFeature.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                        allFeature.ModifiedDate = DateTime.Now;

                        _allFeatureRT.UpdateAllFeature(allFeature);


                        var allFeatureDetailsListToRemove = _allFeatureRT.GetAllFeatureDetailListByAllFeatureId(IID);
                        foreach (var allFeatureDetail in allFeatureDetailsListToRemove)
                        {
                            allFeatureDetail.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                            allFeatureDetail.ModifiedDate = DateTime.Now;
                            allFeatureDetail.IsRemoved = true;
                            _allFeatureRT.UpdateAllFeatureDetail(allFeatureDetail);
                        }

                        List<AllFeatureDetail> allFeatureDetailsListToAdd = (List<AllFeatureDetail>)Session[sessAllFetureDetail];
                        foreach (var allFeatureDetail in allFeatureDetailsListToAdd)
                        {
                            if (allFeatureDetail.IID <= 0)
                            {
                                allFeatureDetail.AllFeatureID = IID;
                                _allFeatureRT.AddAllFeatureDetail(allFeatureDetail);
                            }
                            else
                            {
                                allFeatureDetail.IsRemoved = false;
                                allFeatureDetail.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                                allFeatureDetail.ModifiedDate = DateTime.Now;
                                _allFeatureRT.UpdateAllFeatureDetail(allFeatureDetail);
                            }
                        }
                        Session[sessAllFetureDetail] = new List<AllFeatureDetail>();
                        ClearData();

                        labelMessage.Text = "Information has been updated successfully.";
                        labelMessage.ForeColor = System.Drawing.Color.Green;
                        Response.Redirect("AllFeatureDisplay");
                    }
                }



            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnCreateOrEditAllFeatureDetail_Click(object sender, EventArgs e)
        {
            try
            {
                AllFeatureDetail allFeatureDetail = CreateAllFeatureDetails();
                var msg = BusinessLogicValidationAllFeatureDetail(allFeatureDetail);
                if (string.IsNullOrWhiteSpace(msg))
                {
                    List<AllFeatureDetail> allFeatureDetailList;
                    if (Session[sessAllFetureDetail] != null)
                    {
                        allFeatureDetailList = (List<AllFeatureDetail>)Session[sessAllFetureDetail];
                    }
                    else
                    {
                        allFeatureDetailList = new List<AllFeatureDetail>();
                    }

                    allFeatureDetailList.Add(allFeatureDetail);
                    Session[sessAllFetureDetail] = allFeatureDetailList;
                    ShowAllFeatureDetailsData();
                    ClearAllNewsData();
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
        protected void btnCancelAllNewsDetail_Click(object sender, EventArgs e)
        {
            ClearAllNewsData();
        }

        protected void btnParentPictureUpload_Click(object sender, EventArgs e)
        {
            try
            {
                string debugStr = string.Empty;
                if (parentPictureFileUpload.HasFile)
                {
                    List<ImageUrl> PicTempFileUrlList = new List<ImageUrl>();
                    foreach (var file in parentPictureFileUpload.PostedFiles)
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

                        var tempFilename = Path.GetFileName(tempImageName + "__" + parentPictureFileUpload.FileName);


                        if (Session["seTempFileName"] == null)
                        {
                            Session["seTempFileName"] = new List<ImageUrl>();
                        }
                        PicTempFileUrlList = (List<ImageUrl>)Session["seTempFileName"];//read from sess

                        ImageUrl imageUrl = new ImageUrl();

                        Session["seLogoTempFileName"] = PicTempFileUrlList;//write to sess

                        parentPictureFileUpload.SaveAs(Server.MapPath("~/Images/AllFeature/") + tempFilename);

                        imageUrl.ImageUrlTemp = "~/Image/AllFeature/" + tempImageName + Path.GetExtension(file.FileName);
                        PicTempFileUrlList.Add(imageUrl);
                    }

                }


            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btndeChildPictureUpload_Click(object sender, EventArgs e)
        {
            try
            {
                string debugStr = string.Empty;
                if (childPictureUpload.HasFile)
                {
                    List<ImageUrl> PicTempFileUrlList = new List<ImageUrl>();
                    foreach (var file in childPictureUpload.PostedFiles)
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

                        var tempFilename = Path.GetFileName(tempImageName + "__" + childPictureUpload.FileName);


                        if (Session["seTempFileName"] == null)
                        {
                            Session["seTempFileName"] = new List<ImageUrl>();
                        }
                        PicTempFileUrlList = (List<ImageUrl>)Session["seTempFileName"];//read from sess

                        ImageUrl imageUrl = new ImageUrl();

                        Session["seLogoTempFileName"] = PicTempFileUrlList;//write to sess

                        parentPictureFileUpload.SaveAs(Server.MapPath("~/Images/AllFeatureDetails/") + tempFilename);

                        imageUrl.ImageUrlTemp = "~/Image/AllFeatureDetails/" + tempImageName + Path.GetExtension(file.FileName);
                        PicTempFileUrlList.Add(imageUrl);
                    }

                }


            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }

        }
        #endregion protected method




        public class ImageUrl
        {
            public string ImageUrlPer { get; set; }
            public string ImageUrlTemp { get; set; }
        }
    }
}