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
using System.Web.Providers.Entities;
using Microsoft.Ajax.Utilities;

namespace OMart.Web.AdminPanel
{
    public partial class GuideLineDetailMoreInsUpdate : System.Web.UI.Page
    {
        /// <summary>
        /// Author: Asiful Islam
        /// Date: 20.04.2015
        /// </summary>
        private readonly GuideLineWithDetailsRT _GuideLineWithDetailsMoreRt;
        private const string sessGuideLineWithDetailsMore = "seGuideLineWithDetailsMore";
        private int IID = default(Int32);
        int lvRowCount = 0;
        int currentPage = 0;
        public GuideLineDetailMoreInsUpdate()
        {
            _GuideLineWithDetailsMoreRt = new GuideLineWithDetailsRT();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    
                    LoadDropDownGuideLineWithDetails(null);
                    LoadDropDownGuideLine(null);
                    if (Session[sessGuideLineWithDetailsMore] == null)
                    {
                        Session[sessGuideLineWithDetailsMore] = null;
                    }
                    var requestId = Request.QueryString["IID"];
                    bool reqIDIsValid = Int32.TryParse(requestId, out IID);
                    if (reqIDIsValid)
                    {
                        ShowGuideLineDetail();
                    }
                }
                ShowGuideLineWithDetailsMoreGrid();
            }
            catch (Exception ex)
            {
                lblMassageGuideLineDetailMore.Text = "Error : " + ex.Message;
                lblMassageGuideLineDetailMore.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void ShowGuideLineDetail()
        {
            try
            {
                GuideLineDetail objGuideLineDetail = _GuideLineWithDetailsMoreRt.GetGuideLineDetailsByIID(IID);
                if (objGuideLineDetail != null)
                {

                    ddlGiudeLineID.SelectedValue = objGuideLineDetail.GuideLineID.ToString();
                    txtGiudeLineDetailTitle.Text = objGuideLineDetail.Title != null ? objGuideLineDetail.Title.ToString() : string.Empty;
                    txtGuideLineDetailsDescription.Text = objGuideLineDetail.Description ?? string.Empty;
                    txtGuideLineDetailsHoldImagePath.Text = objGuideLineDetail.ImageUrl;
                    ddlGuideLineDetails.SelectedValue = objGuideLineDetail.IID.ToString();
                    chkIsRemovedForGuideLineDetails.Checked = objGuideLineDetail.IsRemoved;
                    DisplayGuideLineDetailMore(objGuideLineDetail.IID);

                }
            }
            catch (Exception ex)
            {
                lblMassageGuideLineDetailMore.Text = "Error : " + ex.Message;
                lblMassageGuideLineDetailMore.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void DisplayGuideLineDetailMore(int GuidelinedetailId)
        {
            try
            {
                Session[sessGuideLineWithDetailsMore] = null;
                List<GuideLineDetailMore> typeList = new List<GuideLineDetailMore>();
                typeList = _GuideLineWithDetailsMoreRt.GetAllGuidelinedetailMoreByGuidelinedetailId(GuidelinedetailId);
                lvGuideLineDetailMore.DataSource = typeList;
                Session[sessGuideLineWithDetailsMore] = typeList;
                lvGuideLineDetailMore.DataBind();
            }
            catch (Exception ex)
            {

            }
        }

      
        #region Guide Line with details More portion
        private void LoadDropDownGuideLineWithDetails(int? GuideLineWithDetailsID)
        {
            try
            {
                //ddlGuideLineDetails.Items.Add("--Select Guide Line Details--");
                using (GuideLineWithDetailsRT receverTransfer = new GuideLineWithDetailsRT())
                {
                    List<GuideLineDetail> GuideLineWithDetail = new List<GuideLineDetail>();
                    if (GuideLineWithDetailsID != null)
                    {
                        GuideLineWithDetail.Add(receverTransfer.GetGuideLineWithDetailsByIID((int)GuideLineWithDetailsID));
                    }
                    else
                    {
                        GuideLineWithDetail = receverTransfer.GetAllGuideLineWithDetail();
                    }
                    DropDownListHelper.Bind<GuideLineDetail>(ddlGuideLineDetails, GuideLineWithDetail, "Title", "IID", EnumCollection.ListItemType.GuideLineDetail);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

          
        }

        private void ShowGuideLineWithDetailsMoreGrid()
        {
            try
            {
                lvGuideLineDetailMore.DataSource = Session[sessGuideLineWithDetailsMore];
                lvGuideLineDetailMore.DataBind();
            }
            catch (Exception ex)
            {
                lblMassageGuideLineDetailMore.Text = "Error : " + ex.Message;
                lblMassageGuideLineDetailMore.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnAddGuideLineDetailMore_Click(object sender, EventArgs e)
        {
            try
            {

                List<GuideLineDetailMore> GuideLineWithDetailsMorelist = null;
                string description = string.Empty;
                lblMassageGuideLineDetailMore.Text = string.Empty;
                if (IsValidFeature())
                {
                    return;
                }
                if (Session[sessGuideLineWithDetailsMore] == null)
                {
                    GuideLineWithDetailsMorelist = new List<GuideLineDetailMore>();
                }
                else
                {
                    GuideLineWithDetailsMorelist = (List<GuideLineDetailMore>)Session[sessGuideLineWithDetailsMore];
                }
                foreach (GuideLineDetailMore feature in GuideLineWithDetailsMorelist)
                {
                    if (feature.Title == txtGuideLineDetailsMoreTitle.Text.Trim())
                    {
                        description = "Description";
                        break;
                    }
                }
                if (description == "Description")
                {
                    lblMassageGuideLineDetailMore.Text = "Title already exists";
                    lblMassageGuideLineDetailMore.ForeColor = System.Drawing.Color.Red;
                }
                else if(ddlGuideLineDetails.SelectedValue!="-1")
                {
                    GuideLineDetailMore guideLineDetailMore = CreateGuideLineDetailMore();
                    GuideLineWithDetailsMorelist.Add(guideLineDetailMore);
                    Session[sessGuideLineWithDetailsMore] = GuideLineWithDetailsMorelist;
                    ShowGuideLineWithDetailsMoreGrid();
                    txtGuideLineDetailsMoreTitle.Text = string.Empty;
                    txtGuideLineDetailsMoreHoldImagePath.Text = string.Empty;
                    txtGuideLineDetailsMoreDescription.Text = string.Empty;
                    ddlGuideLineDetails.SelectedValue = null;
                   // ClearData();

                }
                else
                {
                    lblMassageGuideLineDetailMore.Text = "Please Select guide Line Detail";
                    lblMassageGuideLineDetailMore.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblMassageGuideLineDetailMore.Text = "Error : " + ex.Message;
                lblMassageGuideLineDetailMore.ForeColor = System.Drawing.Color.Red;
            }
        }

        private bool IsValidFeature()
        {
            if (txtGuideLineDetailsMoreTitle.Text.Trim().Length <= 0)
            {
                lblMassageGuideLineDetailMore.Text = "Please give Title of feature !!!";
                lblMassageGuideLineDetailMore.ForeColor = System.Drawing.Color.Red;
                return true;
            }
            return false;
        }

        private GuideLineDetailMore CreateGuideLineDetailMore()
        {
            Session["UserID"] = "1";
            GuideLineDetailMore guideLineDetailMore = new GuideLineDetailMore();
            try
            {
                guideLineDetailMore.Title = txtGuideLineDetailsMoreTitle.Text.Trim();
                guideLineDetailMore.Description = txtGuideLineDetailsMoreDescription.Text.Trim();
                if (txtGuideLineDetailsMoreHoldImagePath.Text == string.Empty && FileUploadImageGuideLineDetailsMore.HasFile == true)
                {
                    guideLineDetailMore.ImageUrl = ImageUploadguideLineDetailMore().ToString();
                }
                else if (txtGuideLineDetailsMoreHoldImagePath.Text != null && FileUploadImageGuideLineDetailsMore.HasFile == true)
                {
                    guideLineDetailMore.ImageUrl = ImageUploadguideLineDetailMore().ToString();
                }
                else
                {
                    guideLineDetailMore.ImageUrl = txtGuideLineDetailsMoreHoldImagePath.Text;
                }
                guideLineDetailMore.GuideLineDetailID = Convert.ToInt32(ddlGuideLineDetails.SelectedValue);
                guideLineDetailMore.IsRemoved = chkIsRemovedForGuideLineDetailMore.Checked;


                //if (guideLineDetailMore.IID <= 0)
                //{
                guideLineDetailMore.CreatedBy = Convert.ToInt64(Session["UserID"]);
                guideLineDetailMore.CreatedDate = GlobalRT.GetServerDateTime();

                //}
                //else
                //{
                //    GuideLineDetailMore GuideLinedetailMore = (GuideLineDetailMore)Session[sessGuideLineWithDetailsMore];
                //    guideLineDetailMore.CreatedBy = GuideLinedetailMore.CreatedBy; ;
                //    guideLineDetailMore.CreatedDate = GuideLinedetailMore.CreatedDate;
                //    guideLineDetailMore.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                //    guideLineDetailMore.ModifiedDate = GlobalRT.GetServerDateTime();
                //}
               
            }
            catch (Exception ex)
            {
                lblMassageGuideLineDetailMore.Text = "Error : " + ex.Message;
                lblMassageGuideLineDetailMore.ForeColor = System.Drawing.Color.Red;
            }
            return guideLineDetailMore;
        }

        public class ImageUrl
        {
            public string ImageUrlPer { get; set; }
            public string ImageUrlTemp { get; set; }
        }
        private object ImageUploadguideLineDetailMore()
        {
            List<ImageUrl> guideLineDetailMorePicTempFileUrlList = new List<ImageUrl>();
            ImageUrl imageUrl = new ImageUrl();
            try
            {
                if (FileUploadImageGuideLineDetailsMore.HasFile)
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
                    string path = Server.MapPath("~/All Photos/GuideLine/GuideLineDetailMore/");
                    FileUploadHelper.BindImage(FileUploadImageGuideLineDetailsMore, path, tempMatImageName, 800, 800);
                    imageUrl.ImageUrlTemp = "~/All Photos/GuideLine/GuideLineDetailMore/" + tempMatImageName + Path.GetExtension(FileUploadImageGuideLineDetailsMore.FileName);

                    return imageUrl.ImageUrlTemp.ToString();
                }
                return imageUrl.ImageUrlTemp.ToString();
            }
            catch (Exception ex)
            {
                lblMassageGuideLineDetailMore.Text = "error: " + ex.Message;
            }
            return imageUrl.ImageUrlTemp.ToString();
        }

        protected void lvGuideLineDetailMore_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            lblMassageGuideLineDetailMore.Text = string.Empty;
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void lvGuideLineDetailMore_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    ShowGuideLineWithDetailsMoreGrid();
                }
            }
            catch (Exception ex)
            {
                lblMassageGuideLineDetailMore.Text = "Error : " + ex.Message;
                lblMassageGuideLineDetailMore.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void dataPagerGuideLineDetailMore_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    ShowGuideLineWithDetailsMoreGrid();
                }
            }
            catch (Exception ex)
            {
                lblMassageGuideLineDetailMore.Text = "Error : " + ex.Message;
                lblMassageGuideLineDetailMore.ForeColor = System.Drawing.Color.Red;
            }
        }


        protected void lvGuideLineDetailMore_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            try
            {
                lblMassageGuideLineDetailMore.Text = string.Empty;
                if (e.CommandName.Equals("DeleteInfo"))
                {
                    if (Session[sessGuideLineWithDetailsMore] != null)
                    {
                        List<GuideLineDetailMore> guidelineDetailMore = (List<GuideLineDetailMore>)Session[sessGuideLineWithDetailsMore];
                        guidelineDetailMore.RemoveAll(fe => fe.Title.Equals(e.CommandArgument));
                        Session[sessGuideLineWithDetailsMore] = guidelineDetailMore;
                        ShowGuideLineWithDetailsMoreGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                lblMassageGuideLineDetailMore.Text = "Error : " + ex.Message;
                lblMassageGuideLineDetailMore.ForeColor = System.Drawing.Color.Red;
            }
        }
        #endregion
        #region Guide Line details portion
        private void LoadDropDownGuideLine(int? GuideLineID)
        {
            try
            {
                //ddlGuideLineDetails.Items.Add("--Select Guide Line Details--");
                using (GuideLineWithDetailsRT receverTransfer = new GuideLineWithDetailsRT())
                {
                    List<GuideLine> GuideLine = new List<GuideLine>();
                    if (GuideLineID != null)
                    {
                        GuideLine.Add(receverTransfer.GetGuideLineByIID((int)GuideLineID));
                    }
                    else
                    {
                        GuideLine = receverTransfer.GetAllGuideLine();
                    }
                    DropDownListHelper.Bind<GuideLine>(ddlGiudeLineID, GuideLine, "Title", "IID", EnumCollection.ListItemType.GuideLine);
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
                GuideLineDetail Guidelinedetail = CreateGuideLineDetail();
                bool reqIDIsValid = int.TryParse(Request.QueryString["IID"], out IID);
                var msg = BusinessLogicValidationGuidelinedetail(Guidelinedetail);

                if (string.IsNullOrEmpty(msg))
                {
                    if (IID <= 0)
                    {
                        Guidelinedetail.CreatedBy = Convert.ToInt64(Session["UserID"]);
                        Guidelinedetail.CreatedDate = GlobalRT.GetServerDateTime();
                        List<GuideLineDetailMore> guidelinedetailMore = new List<GuideLineDetailMore>();
                        List<GuideLineDetailMore> guidelinedetailMoreList = (List<GuideLineDetailMore>)Session[sessGuideLineWithDetailsMore];

                        if (guidelinedetailMoreList.Count>0)
                        {
                            guidelinedetailMore = guidelinedetailMoreList;
                        }
                       

                        string GuidelinedetailWithAllChildCardFeatureXML = ConversionXML.ConvertObjectToXML<GuideLineDetail, GuideLineDetailMore>(Guidelinedetail, guidelinedetailMore, string.Empty);

                        int GuidelinedetailId = GuideLineWithDetailsRT.InsertGuidelinedetailAndDetailMoreXML(GuidelinedetailWithAllChildCardFeatureXML);
                        //_cardInfoRt.AddCardInfo(cardInfo);
                        if (GuidelinedetailId > 0)
                        {
                            Session[sessGuideLineWithDetailsMore] = null;
                            ClearData();
                            lblMassageGuideLineDetailMore.Text = "Information has been inserted successfully.";
                            lblMassageGuideLineDetailMore.ForeColor = System.Drawing.Color.Green;
                        }
                        else if (GuidelinedetailId == -100)
                        {
                            lblMassageGuideLineDetailMore.Text = "Network connection fail ... Please try again..!!";
                            lblMassageGuideLineDetailMore.ForeColor = System.Drawing.Color.Red;
                            lblMassageGuideLineDetailMore.Focus();
                        }
                        else if (GuidelinedetailId == -101)
                        {
                            lblMassageGuideLineDetailMore.Text = "Network connection fail ... Please try again..!!";
                            lblMassageGuideLineDetailMore.ForeColor = System.Drawing.Color.Red;
                            lblMassageGuideLineDetailMore.Focus();
                        }
                        else
                        {
                            lblMassageGuideLineDetailMore.Text = "Error";
                            lblMassageGuideLineDetailMore.ForeColor = System.Drawing.Color.Red;
                            lblMassageGuideLineDetailMore.Focus();
                        }

                    }
                    else
                    {
                        GuideLineDetail objGuideLineDetails = _GuideLineWithDetailsMoreRt.GetGuideLineWithDetailsByIID(IID);
                       
                        if (objGuideLineDetails != null)
                        {
                            Guidelinedetail.CreatedBy = objGuideLineDetails.CreatedBy; ;
                            Guidelinedetail.CreatedDate = objGuideLineDetails.CreatedDate;
                            Guidelinedetail.IID = objGuideLineDetails.IID;

                            Guidelinedetail.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                            Guidelinedetail.ModifiedDate = DateTime.Now;
                            List<GuideLineDetailMore> interestTypeList = new List<GuideLineDetailMore>();
                            if (Session[sessGuideLineWithDetailsMore] != null)
                            {
                                List<GuideLineDetailMore> typeList = (List<GuideLineDetailMore>)Session[sessGuideLineWithDetailsMore];

                                foreach (GuideLineDetailMore r in typeList)
                                {
                                    GuideLineDetailMore t = new GuideLineDetailMore();
                                    t.Title = r.Title;
                                    t.GuideLineDetailID = r.GuideLineDetailID;
                                    t.Description = r.Description;
                                    t.ImageUrl = r.ImageUrl;
                                    t.IsRemoved = r.IsRemoved;
                                    t.CreatedBy = r.CreatedBy;
                                    t.CreatedDate = r.CreatedDate;
                                    t.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                                    t.ModifiedDate = DateTime.Now;
                                   // GuideLineDetailMore objGuideLineDetailsMOre = _GuideLineWithDetailsMoreRt.GetGuideLineDetailMoreByTitle(t.Title);
                                    if (!_GuideLineWithDetailsMoreRt.IsExistGuideLineDetailMoreByTitle(t.Title))
                                    {
                                        interestTypeList.Add(t);
                                    }
                                }
                            }
                            _GuideLineWithDetailsMoreRt.UpdateGuidelinedetailMore(Guidelinedetail, interestTypeList);
                            ClearData();

                            lblMassageGuideLineDetailMore.Text = "Information has been updated successfully.";
                            lblMassageGuideLineDetailMore.ForeColor = System.Drawing.Color.Green;
                            Session[sessGuideLineWithDetailsMore] = null;
                        }
                    }
                }
                else
                {
                    lblMassageGuideLineDetailMore.Text = msg;
                    lblMassageGuideLineDetailMore.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblMassageGuideLineDetailMore.Text = "Error : " + ex.Message;
                lblMassageGuideLineDetailMore.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void ClearData()
        {
            txtGiudeLineDetailTitle.Text = string.Empty;
            txtGuideLineDetailsDescription.Text = string.Empty;
            txtGuideLineDetailsHoldImagePath.Text = string.Empty;
            txtGuideLineDetailsMoreDescription.Text = string.Empty;
            txtGuideLineDetailsMoreHoldImagePath.Text = string.Empty;
            txtGuideLineDetailsMoreTitle.Text = string.Empty;
            ddlGiudeLineID.SelectedValue = null;
            ddlGuideLineDetails.SelectedValue = null;
        }

        private string BusinessLogicValidationGuidelinedetail(GuideLineDetail Guidelinedetail)
        {
            string message = string.Empty;
            bool reqIDIsValid = Int32.TryParse(Request.QueryString["IID"], out IID);

            if (ddlGiudeLineID.SelectedValue == "-1" || ddlGiudeLineID.SelectedValue.IsNullOrWhiteSpace())
            {
                message = "Please select Guide Line";
                return message;
            }
            if (txtGiudeLineDetailTitle.Text.IsNullOrWhiteSpace())
            {
                message = "Please enter Giude Line Detail Title";
                return message;
            }
           
            if (txtGuideLineDetailsDescription.Text.IsNullOrWhiteSpace())
            {
                message = "Please enter Giude Line Detail Description";
                return message;
            }
            if (!FileUploadImageGuideLineDetails.HasFile&&txtGuideLineDetailsHoldImagePath.Text==string.Empty)
            {
                message = "Please Select a Picture";
                return message;
            }

            return message;
        }

        private GuideLineDetail CreateGuideLineDetail()
        {
            Session["UserID"] = "1";
            GuideLineDetail guideLineDetail = new GuideLineDetail();
            try
            {
                guideLineDetail.Title = txtGiudeLineDetailTitle.Text.Trim();
                guideLineDetail.Description = txtGuideLineDetailsDescription.Text.Trim();
                if (txtGuideLineDetailsHoldImagePath.Text == string.Empty && FileUploadImageGuideLineDetails.HasFile == true)
                {
                    guideLineDetail.ImageUrl = ImageUploadguideLineDetail().ToString();
                }
                else if (txtGuideLineDetailsHoldImagePath.Text != null && FileUploadImageGuideLineDetails.HasFile == true)
                {
                    guideLineDetail.ImageUrl = ImageUploadguideLineDetail().ToString();
                }
                else
                {
                    guideLineDetail.ImageUrl = txtGuideLineDetailsHoldImagePath.Text;
                }
                guideLineDetail.GuideLineID = Convert.ToInt32(ddlGiudeLineID.SelectedValue);
                guideLineDetail.IsRemoved = chkIsRemovedForGuideLineDetails.Checked;


                //if (guideLineDetail.IID <= 0)
                //{
                //    guideLineDetail.CreatedBy = Convert.ToInt64(Session["UserID"]);
                //    guideLineDetail.CreatedDate = GlobalRT.GetServerDateTime();
                //}
                //else
                //{
                //    GuideLineDetailMore GuideLinedetail = (GuideLineDetailMore)Session[sessGuideLineWithDetailsMore];
                //    guideLineDetail.CreatedBy = GuideLinedetail.CreatedBy; ;
                //    guideLineDetail.CreatedDate = GuideLinedetail.CreatedDate;
                //    guideLineDetail.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                //    guideLineDetail.ModifiedDate = GlobalRT.GetServerDateTime();
                //}

            }
            catch (Exception ex)
            {
                lblMassageGuideLineDetailMore.Text = "Error : " + ex.Message;
                lblMassageGuideLineDetailMore.ForeColor = System.Drawing.Color.Red;
            }
            return guideLineDetail;
        }

        private object ImageUploadguideLineDetail()
        {
            List<ImageUrl> guideLineDetailPicTempFileUrlList = new List<ImageUrl>();
            ImageUrl imageUrl = new ImageUrl();
            try
            {
                if (FileUploadImageGuideLineDetails.HasFile)
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
                    FileUploadHelper.BindImage(FileUploadImageGuideLineDetails, path, tempMatImageName, 800, 800);
                    imageUrl.ImageUrlTemp = "~/All Photos/GuideLine/GuideLineDetail/" + tempMatImageName + Path.GetExtension(FileUploadImageGuideLineDetails.FileName);

                    return imageUrl.ImageUrlTemp.ToString();
                }
                return imageUrl.ImageUrlTemp.ToString();
            }
            catch (Exception ex)
            {
                lblMassageGuideLineDetailMore.Text = "error: " + ex.Message;
            }
            return imageUrl.ImageUrlTemp.ToString();
        }
        #endregion

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/AdminPanel/GuideLineDetailDisplay");
                ClearData();
            }
            catch (Exception ex)
            {
                lblMassageGuideLineDetailMore.Text = "Error : " + ex.Message;
                lblMassageGuideLineDetailMore.ForeColor = System.Drawing.Color.Red;
            }
        }



    }
}