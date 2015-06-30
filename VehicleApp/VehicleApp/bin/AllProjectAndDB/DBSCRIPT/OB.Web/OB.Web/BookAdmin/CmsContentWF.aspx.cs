using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Text;
using System.IO;
using OB.BLL.Basic;
using OB.DAL;
using OB.Utilities;

namespace OB.Web.BookAdmin
{
    public partial class CmsContentWF : System.Web.UI.Page
    {
        /// <summary>
        /// Author:Asiful Islam
        /// </summary>
        private const string sessCMS = "seCMS";
        public class ImageUrl
        {
            public string ImageUrlPer { get; set; }
            public string ImageUrlTemp { get; set; }
        }
        int lvRowCount = 0;
        int currentPage = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadddlCMSTypeID();
                    Session["seOthercontentPicTempFileName"] = null;
                    LoadCMSListView();
                    btnSave.Visible = true;
                    btnUpdate.Visible = false;
                    btnCancel.Visible = false;
                    chkIsActive.Visible = false;
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void LoadddlCMSTypeID()
        {
            try
            {
                DropDownListHelper.Bind(ddlCMSType, EnumHelper.EnumToList<EnumCollection.CMSType>(), EnumCollection.ListItemType.CMSTypeID);

            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void LoadCMSListView()
        {
            try
            {
                using (cmsRT receiverTransfer = new cmsRT())
                {
                    lvBookCMSContent.DataSource = receiverTransfer.GetCMSContentAllForListView(); ;
                    lvBookCMSContent.DataBind();


                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                labelMessage.Text = string.Empty;

                using (cmsRT receiverTransfer = new cmsRT())
                {
                    bool CMStypeNotExist = receiverTransfer.GetCMSContentByCMStype(Convert.ToInt32(ddlCMSType.SelectedValue));
                    if (CMStypeNotExist && ddlCMSType.SelectedValue != "-1")
                    {
                        hdSave.Value = "true";
                        CMSContent CMScontent = CreateCMScontent();
                        receiverTransfer.AddOtherContent(CMScontent);
                        if (CMScontent.IID > 0)
                        {
                            labelMessage.Text = "Data successfully saved...";
                            labelMessage.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            labelMessage.Text = "Data not saved...";
                            labelMessage.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    else
                    {
                        labelMessage.Text = "You Can't Enter Same CMS type More then once. Please Deactivate That CMS Type. \n  And You Also have to Select A CMS Type";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }


                ClearField();
                LoadCMSListView();
                hdSave.Value = null;
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private CMSContent CreateCMScontent()
        {
            Session["UserID"] = "1";
            CMSContent Cmscontent = new CMSContent();
            try
            {
                if (hdIsEdit.Value == "true")
                {
                    Cmscontent.IID = Convert.ToInt32(hdContentID.Value.ToString());
                }
                Cmscontent.Title = txtCMSTitle.Text.Trim();
                Cmscontent.CMSDescription = txtBookCMSDescription.Text.Trim();
                Cmscontent.CMSTypeID = Convert.ToInt32(ddlCMSType.SelectedValue);

                if (txtHoldImagePath.Text == string.Empty && FileUploadImage.HasFile == true)
                {
                    Cmscontent.ImageUrl = CmsImageUpload().ToString();
                }
                else if (txtHoldImagePath.Text != null && FileUploadImage.HasFile == true)
                {
                    Cmscontent.ImageUrl = CmsImageUpload().ToString();
                }
                else
                {
                    Cmscontent.ImageUrl = txtHoldImagePath.Text;
                }
                if (Cmscontent.IID <= 0)
                {
                    Cmscontent.CreatedBy = Convert.ToInt64(Session["UserID"]);
                    Cmscontent.CreatedDate = GlobalRT.GetServerDateTime();
                }
                else
                {
                    CMSContent CMScontent = (CMSContent)Session[sessCMS];
                    Cmscontent.CreatedBy = CMScontent.CreatedBy; ;
                    Cmscontent.CreatedDate = CMScontent.CreatedDate;
                    Cmscontent.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                    Cmscontent.ModifiedDate = GlobalRT.GetServerDateTime();
                }
                if ((hdIsEdit.Value == "true" && chkIsActive.Checked == true) || (hdSave.Value == "true" && chkIsActive.Checked != true))
                {
                    Cmscontent.IsActive = true;
                }
                else if (hdIsEdit.Value == "true" && chkIsActive.Checked == false)
                {
                    Cmscontent.IsActive = false;
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return Cmscontent;
        }
        private object CmsImageUpload()
        {
            List<ImageUrl> cmsPicTempFileUrlList = new List<ImageUrl>();
            ImageUrl imageUrl = new ImageUrl();
            try
            {
                if (FileUploadImage.HasFile)
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
                    string path = Server.MapPath("~/Image/CMSImage/");
                    FileUploadHelper.BindImage(FileUploadImage, path, tempMatImageName);
                    imageUrl.ImageUrlTemp = "~/Image/CMSImage/" + tempMatImageName + Path.GetExtension(FileUploadImage.FileName);

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
        private void ClearField()
        {
            txtBookCMSDescription.Text = string.Empty;
            txtCMSTitle.Text = string.Empty;
            ddlCMSType.SelectedValue = null;
            chkIsActive.Checked = false;
        }
        private void btnVisibilityForCancel()
        {
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            chkIsActive.Visible = false;

        }

        protected void lvBookCMSContent_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            labelMessage.Text = string.Empty;
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void dataPagerBookCMSContent_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    LoadCMSListView();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void lnkbEdit_Click(object sender, EventArgs e)
        {
            try
            {
                chkIsActive.Visible = true;
                btnCancel.Visible = true;
                btnUpdate.Visible = true;
                btnSave.Visible = false;
                LinkButton linkButton = (LinkButton)sender;
                Int64 cmsid = Convert.ToInt64(linkButton.CommandArgument);
                hdContentID.Value = cmsid.ToString();
                using (cmsRT receiverTransfer = new cmsRT())
                {
                    CMSContent CMScontent = receiverTransfer.GetOtherContentByIID(cmsid);
                    FillCMScontentForEdit(CMScontent);
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void FillCMScontentForEdit(CMSContent CMScontent)
        {
            try
            {
                if (CMScontent != null)
                {

                    txtBookCMSDescription.Text = CMScontent.CMSDescription;
                    txtCMSTitle.Text = CMScontent.Title;
                    ddlCMSType.SelectedValue = CMScontent.CMSTypeID.ToString();
                    txtHoldImagePath.Text = CMScontent.ImageUrl;
                    if (CMScontent.IsActive == true)
                    {

                        chkIsActive.Checked = true;

                    }
                    else
                    {
                        chkIsActive.Checked = false;
                    }
                    Session[sessCMS] = CMScontent;
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                labelMessage.Text = string.Empty;
                using (cmsRT receiverTransfer = new cmsRT())
                {
                    hdIsEdit.Value = "true";
                    CMSContent CMScontent = CreateCMScontent();

                    if (CMScontent != null)
                    {

                        if (receiverTransfer.IsExistCMSType(CMScontent.IID, CMScontent.CMSTypeID))
                        {
                            labelMessage.Text = "Same Cms Type already active ...";
                            labelMessage.ForeColor = System.Drawing.Color.Red;

                        }
                        else
                        {
                            receiverTransfer.UpdateCMScontent(CMScontent);
                            labelMessage.Text = "Data successfully updated...";
                            labelMessage.ForeColor = System.Drawing.Color.Green;
                        }

                    }
                    else
                    {
                        labelMessage.Text = "Data not updated...";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                    }

                }
                ClearField();
                btnVisibilityForCancel();
                LoadCMSListView();
                txtHoldImagePath.Text = string.Empty;
                hdIsEdit.Value = string.Empty;
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
            labelMessage.Text =string.Empty;
            btnVisibilityForCancel();
        }
    }
}