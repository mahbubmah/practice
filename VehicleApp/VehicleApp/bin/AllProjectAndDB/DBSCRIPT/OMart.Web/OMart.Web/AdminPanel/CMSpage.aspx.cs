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
    public partial class CMSpage : System.Web.UI.Page
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
                    LoadddlUserTypeID();
                    Session["seOthercontentPicTempFileName"] = null;
                    LoadCMSListView();
                    btnSave.Visible = true;
                    btnUpdate.Visible = false;
                  
                    btnCancel.Visible = false;
                    chkActv.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblMassageCMS.Text = "Error : " + ex.Message;
                lblMassageCMS.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void LoadCMSListView()
        {
            try
            {
                using (cmsRT receiverTransfer = new cmsRT())
                {
                    lvCMSContent.DataSource = receiverTransfer.GetCMSContentAllForListView(); ;
                    lvCMSContent.DataBind();
                   
                    
                }
            }
            catch (Exception ex)
            {
                lblMassageCMS.Text = "Error : " + ex.Message;
                lblMassageCMS.ForeColor = System.Drawing.Color.Red;
            }
        }


        private void LoadddlUserTypeID()
        {
            try
            {
                DropDownListHelper.Bind(ddlCMSTypeID, EnumHelper.EnumToList<EnumCollection.CMSType>(), EnumCollection.ListItemType.CMSTypeID);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                lblMassageCMS.Text = string.Empty;

                using (cmsRT receiverTransfer = new cmsRT())
                {
                    bool CMStypeNotExist = receiverTransfer.GetCMSContentByCMStype(Convert.ToInt32(ddlCMSTypeID.SelectedValue));
                    if (CMStypeNotExist && ddlCMSTypeID.SelectedValue!="-1")
                    {
                        hdSave.Value = "true";
                        CMSContent CMScontent = CreateCMScontent();
                        receiverTransfer.AddOtherContent(CMScontent);
                        if (CMScontent.IID > 0)
                        {
                            lblMassageCMS.Text = "Data successfully saved...";
                            lblMassageCMS.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            lblMassageCMS.Text = "Data not saved...";
                            lblMassageCMS.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    else
                    {
                        lblMassageCMS.Text = "You Can't Enter Same CMS type More then once. Please Deactivate That CMS Type. \n  And You Also have to Select A CMS Type";
                        lblMassageCMS.ForeColor = System.Drawing.Color.Red;
                    }
                }
            

                ClearField();
                LoadCMSListView();
                hdSave.Value = null;
            }
            catch (Exception ex)
            {
                lblMassageCMS.Text = "Error : " + ex.Message;
                lblMassageCMS.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void ClearField()
        {
            txtDescription.Text = string.Empty;
            txtTitle.Text = string.Empty;
            ddlCMSTypeID.SelectedValue = null ;
        }
        private void btnVisibilityForCancel()
        {
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
           
            chkActv.Visible = false;
           
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
                Cmscontent.Title = txtTitle.Text.Trim();
                Cmscontent.CMSDescription = txtDescription.Text.Trim();
                Cmscontent.CMSTypeID = Convert.ToInt32(ddlCMSTypeID.SelectedValue);

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
                if ((hdIsEdit.Value == "true" && chkActv.Checked == true) || (hdSave.Value == "true" && chkActv.Checked != true))
                {
                    Cmscontent.IsActive = true;
                }
                else if (hdIsEdit.Value == "true" && chkActv.Checked == false)
                {
                    Cmscontent.IsActive = false;
                }
            }
            catch (Exception ex)
            {
                lblMassageCMS.Text = "Error : " + ex.Message;
                lblMassageCMS.ForeColor = System.Drawing.Color.Red;
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
                    string path = Server.MapPath("~/All Photos/CMSPhoto/");
                    FileUploadHelper.BindImage(FileUploadImage, path, tempMatImageName);
                    imageUrl.ImageUrlTemp = "~/All Photos/CMSPhoto/" + tempMatImageName + Path.GetExtension(FileUploadImage.FileName);

                    return imageUrl.ImageUrlTemp.ToString();
                }
                return imageUrl.ImageUrlTemp.ToString();
            }
            catch (Exception ex)
            {
                lblMassageCMS.Text = "error: " + ex.Message;
            }
            return imageUrl.ImageUrlTemp.ToString();
        }

        protected void lvCMSContent_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            lblMassageCMS.Text = string.Empty;
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void dataPagerCMSContent_PreRender(object sender, EventArgs e)
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
                lblMassageCMS.Text = "Error : " + ex.Message;
                lblMassageCMS.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lnkbEdit_Click(object sender, EventArgs e)
        {
            try
            {
                chkActv.Visible = true;
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
                lblMassageCMS.Text = "Error : " + ex.Message;
                lblMassageCMS.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void FillCMScontentForEdit(CMSContent CMScontent)
        {
            try
            {
                if (CMScontent != null)
                {

                    txtDescription.Text = CMScontent.CMSDescription;
                    txtTitle.Text = CMScontent.Title;
                    ddlCMSTypeID.SelectedValue = CMScontent.CMSTypeID.ToString();
                    txtHoldImagePath.Text = CMScontent.ImageUrl;
                    if (CMScontent.IsActive == true)
                    {

                        chkActv.Checked = true;

                    }
                    else
                    {
                        chkActv.Checked = false;
                    }
                    Session[sessCMS] = CMScontent;
                }
            }
            catch (Exception ex)
            {
                lblMassageCMS.Text = "Error : " + ex.Message;
                lblMassageCMS.ForeColor = System.Drawing.Color.Red;
            }
        }

       

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                lblMassageCMS.Text = string.Empty;
                using (cmsRT receiverTransfer = new cmsRT())
                {
                    //bool CMStypeExist = receiverTransfer.GetCMSContentByCMStype(Convert.ToInt32(ddlCMSTypeID.SelectedValue));
                    //if (CMStypeExist)
                    //{
                        hdIsEdit.Value = "true";
                        CMSContent CMScontent = CreateCMScontent();

                        if (CMScontent != null)
                        {
                            
                            if( receiverTransfer.IsExistCMSType(CMScontent.IID,CMScontent.CMSTypeID))
                            {
                                lblMassageCMS.Text = "Same Cms Type already active ...";
                                lblMassageCMS.ForeColor = System.Drawing.Color.Red;

                            }
                            else
                            {
                                receiverTransfer.UpdateCMScontent(CMScontent);
                                lblMassageCMS.Text = "Data successfully updated...";
                                lblMassageCMS.ForeColor = System.Drawing.Color.Green;
                            }

                        }
                        else
                        {
                            lblMassageCMS.Text = "Data not updated...";
                            lblMassageCMS.ForeColor = System.Drawing.Color.Red;
                        }

                //}

                //    else
                //    {
                //        lblMassageCMS.Text = "You Can't Update Same CMS type More then once. Please Deactivate That CMS Type and Insert Again";
                //        lblMassageCMS.ForeColor = System.Drawing.Color.Green;
                //    }

                }
                ClearField();
                btnVisibilityForCancel();
                LoadCMSListView();
                txtHoldImagePath.Text = string.Empty;
            }

            catch (Exception ex)
            {
                lblMassageCMS.Text = "Error : " + ex.Message;
                lblMassageCMS.ForeColor = System.Drawing.Color.Red;
            }
        }
        

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearField();
            lblMassageCMS.Text = "";
            btnVisibilityForCancel();
        }



    }
}