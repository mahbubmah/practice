using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Basic;
using DAL;
using Utilities;
using System.Globalization;
using System.Text;
using System.IO;

namespace OMart.Web.AdminPanel
{
    public partial class GuideLineWithDetailsInsertUpdate : System.Web.UI.Page
    {
         #region private variable declaration
        
        private readonly GuideLineWithDetailsRT _GuideLineWithDetailsRT;
        private int IID = default(int);
        private const string seGuideLinewithDetailsColl = "seGuideLinewithDetailsColl";
        private const string sessGuideLinewithDetails = "seGuideLinewithDetails";
        int lvRowCount = 0;
        int currentPage = 0;

        #endregion private variable declaration

        #region protected method
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    
                    LoadDropDownBusinessType();
                    
                    Session[seGuideLinewithDetailsColl] = null;
                    var requestId = Request.QueryString["IID"];
                    bool reqIDIsValid = Int32.TryParse(requestId, out IID);
                    if (reqIDIsValid)
                    {
                        FillGuideLineIntoUI();
                    }
                }
                catch (Exception ex)
                {
                    labelMessage.Text = "Error : " + ex.Message;
                    labelMessage.ForeColor = System.Drawing.Color.Red;
                }
            }

        }
        public GuideLineWithDetailsInsertUpdate()
        {
            this._GuideLineWithDetailsRT = new GuideLineWithDetailsRT();
        }
        protected void btnAddGuideLine_Click(object sender, EventArgs e)
        {
            List<GuideLineDetail> featureColl = null;
            string description = string.Empty;
            labelMessage.Text = string.Empty;
            if (IsValidFeature())
            {
                return;
            }
            if (Session[seGuideLinewithDetailsColl] == null)
            {
                featureColl = new List<GuideLineDetail>();
            }
            else
            {
                featureColl = (List<GuideLineDetail>)Session[seGuideLinewithDetailsColl];
            }
            foreach (GuideLineDetail feature in featureColl)
            {
                if (feature.Title == txtTitle.Text.Trim() )
                {
                    description = "Description";
                    break;
                }
            }
            if (description == "Description")
            {
                labelMessage.Text = "Title already exists";
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                GuideLineDetail feature = CreateGuideLinewithDetails();
                featureColl.Add(feature);
                Session[seGuideLinewithDetailsColl] = featureColl;
                LoadGuideLinewithDetails();
                txtTitle2.Text = string.Empty;
                txtDescription2.Text = string.Empty;
                

            }
        }
        public class ImageUrl
        {
            public string ImageUrlPer { get; set; }
            public string ImageUrlTemp { get; set; }
        }

        private string ImageUpload2()
        {
            List<ImageUrl> OthrContntPicTempFileUrlList = new List<ImageUrl>();
            ImageUrl imageUrl = new ImageUrl();
            try
            {
                if (FileUploadImage2.HasFile)
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
                    string path = Server.MapPath("~/All Photos/GuideLine/GuideLineDetail/");
                    FileUploadHelper.BindImage(FileUploadImage2, path, tempMatImageName, 800, 800);
                    imageUrl.ImageUrlTemp = "~/All Photos/GuideLine/GuideLineDetail/" + tempMatImageName + Path.GetExtension(FileUploadImage1.FileName);

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

        private string ImageUpload1()
        {
            List<ImageUrl> OthrContntPicTempFileUrlList = new List<ImageUrl>();
            ImageUrl imageUrl = new ImageUrl();
            try
            {
                if (FileUploadImage1.HasFile)
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
                    string path = Server.MapPath("~/All Photos/GuideLine/GuideLineDetail/");
                    FileUploadHelper.BindImage(FileUploadImage1, path, tempMatImageName, 800, 800);
                    imageUrl.ImageUrlTemp = "~/All Photos/GuideLine/GuideLineDetail/" + tempMatImageName + Path.GetExtension(FileUploadImage1.FileName);

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
        protected void lvGuideLine_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            try
            {
                labelMessage.Text = string.Empty;
                if (e.CommandName.Equals("DeleteInfo"))
                {
                    if (Session[seGuideLinewithDetailsColl] != null)
                    {
                        List<GuideLineDetail> GuideLineDetailColl = (List<GuideLineDetail>)Session[seGuideLinewithDetailsColl];
                        GuideLineDetailColl.RemoveAll(fe => fe.Title.Equals(e.CommandArgument));
                        Session[seGuideLinewithDetailsColl] = GuideLineDetailColl;
                        LoadGuideLinewithDetails();
                    }
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void dataPagerFeature_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    LoadGuideLinewithDetails();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btn_CreateOrEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int GuideLineID = 0;
                labelMessage.Text = string.Empty;
                bool reqIDIsValid = Int32.TryParse(Request.QueryString["IID"], out IID);

                if (IsValidField())
                {
                    return;
                }
                GuideLine GuideLineWithDetails = CreateGuideLine();
                if (IID <= 0)
                {
                    GuideLineWithDetails.CreatedBy = Convert.ToInt64(Session["UserID"]);
                    GuideLineWithDetails.CreatedDate = DateTime.Now;
                    GuideLineWithDetails.IsRemoved = chkIsRemoved1.Checked;
                    List<GuideLineDetail> featureList = (List<GuideLineDetail>)Session[seGuideLinewithDetailsColl];
                    string mobilePhoneInfoAllChildXML = ConversionXML.ConvertObjectToXML<GuideLine, GuideLineDetail>(GuideLineWithDetails, featureList, string.Empty);
                    GuideLineID = GuideLineWithDetailsRT.InsertGuideLineDetailChildXML(mobilePhoneInfoAllChildXML);

                    if (GuideLineID == -100)
                    {
                        labelMessage.Text = "Network connection fail ... Please try again..!!";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                        labelMessage.Focus();
                    }
                    else if (GuideLineID == -101)
                    {
                        labelMessage.Text = "Network connection fail ... Please try again..!!";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                        labelMessage.Focus();
                    }
                    
                    ClearField();

                    labelMessage.Text = "Information has been inserted successfully.";
                    labelMessage.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    GuideLine objGuideLineWithDetails = _GuideLineWithDetailsRT.GetguideLineByIID(IID);

                    if (objGuideLineWithDetails != null)
                    {
                        GuideLineWithDetails.CreatedBy = objGuideLineWithDetails.CreatedBy;
                        GuideLineWithDetails.CreatedDate = objGuideLineWithDetails.CreatedDate;
                        GuideLineWithDetails.IsRemoved = objGuideLineWithDetails.IsRemoved;
                        GuideLineWithDetails.IID = objGuideLineWithDetails.IID;

                        GuideLineWithDetails.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                        GuideLineWithDetails.ModifiedDate = DateTime.Now;
                        List<GuideLineDetail> lst = new List<GuideLineDetail>();
                        if (Session[seGuideLinewithDetailsColl] != null)
                        {
                            List<GuideLineDetail> featureList = (List<GuideLineDetail>)Session[seGuideLinewithDetailsColl];

                            foreach (GuideLineDetail feature in featureList)
                            {
                                GuideLineDetail fe = new GuideLineDetail();
                                fe.Title = feature.Title;
                                fe.Description = feature.Description;
                                fe.IsRemoved = feature.IsRemoved;
                                fe.CreatedBy = objGuideLineWithDetails.CreatedBy;
                                fe.CreatedDate = objGuideLineWithDetails.CreatedDate;
                                fe.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                                fe.ModifiedDate = DateTime.Now;
                                lst.Add(fe);
                            }
                        }
                        _GuideLineWithDetailsRT.UpdateguideLineAndGuideLineDetail(GuideLineWithDetails, lst);
                        ClearField();
                        Session[seGuideLinewithDetailsColl] = null;
                        labelMessage.Text = "Information has been updated successfully.";
                        labelMessage.ForeColor = System.Drawing.Color.Green;
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
            //ClearField();
            try
            {
                Response.Redirect("~/AdminPanel/GuideLineWithDetails");
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lvGuideLine_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            labelMessage.Text = string.Empty;
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void lvGuideLine_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    LoadGuideLinewithDetails();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        #endregion protected method


        #region  private method
        
        private void LoadDropDownBusinessType()
        {
            try
            {

                ddlBusinessType.Items.Add("--Select Business Type--");
                DropDownListHelper.Bind(ddlBusinessType, EnumHelper.EnumToList<EnumCollection.BussinessType>());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private void FillGuideLineIntoUI()
        {
            try
            {
                GuideLine guideLine = _GuideLineWithDetailsRT.GetguideLineByIID(IID);
                if (guideLine != null)
                {
                    ddlBusinessType.SelectedValue = guideLine.BusinessTypeID.ToString();
                   
                    txtTitle.Text = guideLine.Title.ToString();
                    txtDescription1.Text = guideLine.Description.ToString();
                    
                    txtHoldImagePath.Text = guideLine.ImageUrl.ToString();
                    chkIsRemoved1.Checked = Convert.ToBoolean(guideLine.IsRemoved);
                    DisplayFeature(guideLine.IID);
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void DisplayFeature(Int64? LoanID)
        {
            try
            {
                Session[seGuideLinewithDetailsColl] = null;
                List<GuideLineDetail> featureList = new List<GuideLineDetail>();
                featureList = _GuideLineWithDetailsRT.GetAllDetailByGuidLineIID(LoanID);
                lvGuideLine.DataSource = featureList;
                Session[seGuideLinewithDetailsColl] = featureList;
                lvGuideLine.DataBind();
            }
            catch (Exception ex)
            {

            }
        }

        private GuideLineDetail CreateGuideLinewithDetails()
        {
            Session["UserID"] = "1";
            GuideLineDetail feature = new GuideLineDetail();
            feature.Title = txtTitle2.Text.Trim();
            feature.Description = txtDescription2.Text.Trim();
            if (txtHoldImagePath2.Text == string.Empty && FileUploadImage2.HasFile == true)
            {
                feature.ImageUrl = ImageUpload2().ToString();
            }
            else if (txtHoldImagePath2.Text != null && FileUploadImage2.HasFile == true)
            {
                feature.ImageUrl = ImageUpload2().ToString();
            }
            else
            {
                feature.ImageUrl = txtHoldImagePath2.Text;
            }
            feature.IsRemoved = chkIsRemoved2.Checked;
            feature.CreatedBy = Convert.ToInt64(Session["UserID"]);
            feature.CreatedDate = DateTime.Now;
            return feature;
        }

        private void LoadGuideLinewithDetails()
        {
            try
            {
                lvGuideLine.DataSource = (List<GuideLineDetail>)Session[seGuideLinewithDetailsColl];
                lvGuideLine.DataBind();
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void ClearField()
        {
            
            ddlBusinessType.SelectedIndex = 0;
            txtTitle.Text = string.Empty;
            
            txtDescription1.Text = string.Empty;
            
            chkIsRemoved1.Checked = false;
            
            Session[seGuideLinewithDetailsColl] = null;
            LoadGuideLinewithDetails();
        }

        private GuideLine CreateGuideLine()
        {
            Session["UserID"] = "1";
            GuideLine guideLine = new GuideLine();
            try
            {
                guideLine.BusinessTypeID = Convert.ToInt32(ddlBusinessType.SelectedValue.ToString());
                guideLine.Title = txtTitle.Text.Trim();
                guideLine.Description = txtDescription1.Text.Trim();

                if (txtHoldImagePath.Text == string.Empty && FileUploadImage1.HasFile == true)
                {
                    guideLine.ImageUrl = ImageUpload1().ToString();
                }
                else if (txtHoldImagePath.Text != null && FileUploadImage1.HasFile == true)
                {
                    guideLine.ImageUrl = ImageUpload1().ToString();
                }
                else
                {
                    guideLine.ImageUrl = txtHoldImagePath.Text;
                }
                
                if (chkIsRemoved1.Checked)
                {
                    guideLine.IsRemoved = true;
                }
                else
                {
                    guideLine.IsRemoved = false;
                }
               
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return guideLine;
        }

        private bool IsValidField()
        {
            
            //if (ddlLoanType.SelectedIndex == 0)
            //{
            //    labelMessage.Text = "Please select a Loan Type !!!";
            //    labelMessage.ForeColor = System.Drawing.Color.Red;
            //    return true;
            //}
            //if (ddlLoanType.SelectedValue == "-1")
            //{
            //    labelMessage.Text = "Please select a Loan Type !!!";
            //    labelMessage.ForeColor = System.Drawing.Color.Red;
            //    return true;
            //}
            //if (txtTotalAmount.Text.Trim().Length <= 0)
            //{
            //    labelMessage.Text = "Please Enter Total Amount !!!";
            //    labelMessage.ForeColor = System.Drawing.Color.Red;
            //    return true;
            //}
            //if (txtTotalPaymentAmount.Text.Trim().Length <= 0)
            //{
            //    labelMessage.Text = "Please Enter Total Payment Amount !!!";
            //    labelMessage.ForeColor = System.Drawing.Color.Red;
            //    return true;
            //}
            //if (txtMonthlyReturnAmount.Text.Trim().Length <= 0)
            //{
            //    labelMessage.Text = "Please Enter Monthly Return Amount !!!";
            //    labelMessage.ForeColor = System.Drawing.Color.Red;
            //    return true;
            //}
            //if (txtTotalReturnAmount.Text.Trim().Length <= 0)
            //{
            //    labelMessage.Text = "Please Enter Total Return Amount !!!";
            //    labelMessage.ForeColor = System.Drawing.Color.Red;
            //    return true;
            //}
            //if (txtTotalInstallmentNo.Text.Trim().Length <= 0)
            //{
            //    labelMessage.Text = "Please Enter Total Installment No. !!!";
            //    labelMessage.ForeColor = System.Drawing.Color.Red;
            //    return true;
            //}
            //if (txtPostLastDisplayDate.Text.Trim().Length <= 0)
            //{
            //    labelMessage.Text = "Please Enter Post Last Display Day!!!";
            //    labelMessage.ForeColor = System.Drawing.Color.Red;
            //    return true;
            //}
            if (Session[seGuideLinewithDetailsColl] == null)
            {
                labelMessage.Text = "Please add at least one feature !!!";
                labelMessage.ForeColor = System.Drawing.Color.Red;
                return true;
            }
            return false;
        }

        private bool IsValidFeature()
        {
            if (txtTitle2.Text.Trim().Length <= 0)
            {
                labelMessage.Text = "Pealse give Title of feature !!!";
                labelMessage.ForeColor = System.Drawing.Color.Red;
                return true;
            }
            return false;
        }

        #endregion private method


    }
}