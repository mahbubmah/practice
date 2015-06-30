using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OH.BLL.Basic;
using OH.DAL;
using OH.Utilities;
using System.Globalization;
using System.Text;
using System.IO;

namespace OH.Web.ControlAdmin
{
    public partial class HaatHelpSuppotWF : System.Web.UI.Page
    {
        /// <summary>
        /// Author:Asiful Islam
        /// </summary>
        private const string sessHelpSuppot = "seHelpSuppot";
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
                    LoadddlHelpSuppotID();
                    Session["seOthercontentPicTempFileName"] = null;
                    LoadHelpSuppotListView();
                    btnSave.Visible = true;
                    btnUpdate.Visible = false;
                    btnCancel.Visible = false;
                    chkActv.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblMassagehelpSupport.Text = "Error : " + ex.Message;
                lblMassagehelpSupport.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void LoadHelpSuppotListView()
        {
            try
            {
                using (HelpSupportRT receiverTransfer = new HelpSupportRT())
                {
                    lvhelpSupport.DataSource = receiverTransfer.GetHelpSupportAllForListView(); ;
                    lvhelpSupport.DataBind();


                }
            }
            catch (Exception ex)
            {
                lblMassagehelpSupport.Text = "Error : " + ex.Message;
                lblMassagehelpSupport.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void LoadddlHelpSuppotID()
        {
            try
            {
                DropDownListHelper.Bind(ddlHelpSupportTypeID, EnumHelper.EnumToList<EnumCollection.HelpSupportType>(), EnumCollection.ListItemType.HelpSupportTypeID);

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
                lblMassagehelpSupport.Text = string.Empty;

                using (HelpSupportRT receiverTransfer = new HelpSupportRT())
                {
                    //bool CMStypeNotExist = receiverTransfer.GetCMSContentByCMStype(Convert.ToInt32(ddlCMSTypeID.SelectedValue));
                    //if (CMStypeNotExist && ddlCMSTypeID.SelectedValue != "-1")
                    //{
                        hdSave.Value = "true";
                        OiiOHaatHelpSupport HelpSupportcontent = CreateCMScontent();
                        receiverTransfer.AddOtherContent(HelpSupportcontent);
                        if (HelpSupportcontent.IID > 0)
                        {
                            lblMassagehelpSupport.Text = "Data successfully saved...";
                            lblMassagehelpSupport.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            lblMassagehelpSupport.Text = "Data not saved...";
                            lblMassagehelpSupport.ForeColor = System.Drawing.Color.Red;
                        }
                    //}
                    //else
                    //{
                    //    lblMassageCMS.Text = "You Can't Enter Same CMS type More then once. Please Deactivate That CMS Type. \n  And You Also have to Select A CMS Type";
                    //    lblMassageCMS.ForeColor = System.Drawing.Color.Red;
                    //}
                }


                ClearField();
                LoadHelpSuppotListView();
                hdSave.Value = null;
            }
            catch (Exception ex)
            {
                lblMassagehelpSupport.Text = "Error : " + ex.Message;
                lblMassagehelpSupport.ForeColor = System.Drawing.Color.Red;
            }
        }

        private OiiOHaatHelpSupport CreateCMScontent()
        {
            Session["UserID"] = "1";
            OiiOHaatHelpSupport HelpSupportcontent = new OiiOHaatHelpSupport();
            try
            {
                if (hdIsEdit.Value == "true")
                {
                    HelpSupportcontent.IID = Convert.ToInt32(hdContentID.Value.ToString());
                }
                HelpSupportcontent.Title = txtTitle.Text.Trim();
                HelpSupportcontent.Description = txtDescription.Text.Trim();
                HelpSupportcontent.HelpSupportTypeID = Convert.ToInt32(ddlHelpSupportTypeID.SelectedValue);

                if (txtHoldImagePath.Text == string.Empty && FileUploadImage.HasFile == true)
                {
                    HelpSupportcontent.Image = HelpSupportImageUpload().ToString();
                }
                else if (txtHoldImagePath.Text != null && FileUploadImage.HasFile == true)
                {
                    HelpSupportcontent.Image = HelpSupportImageUpload().ToString();
                }
                else
                {
                    HelpSupportcontent.Image = txtHoldImagePath.Text;
                }
                if (HelpSupportcontent.IID <= 0)
                {
                    HelpSupportcontent.CreatedBy = Convert.ToInt64(Session["UserID"]);
                    HelpSupportcontent.CreatedDate = GlobalRT.GetServerDateTime();
                }
                else
                {
                    OiiOHaatHelpSupport Helpsupportcontent = (OiiOHaatHelpSupport)Session[sessHelpSuppot];
                    HelpSupportcontent.CreatedBy = Helpsupportcontent.CreatedBy; ;
                    HelpSupportcontent.CreatedDate = Helpsupportcontent.CreatedDate;
                    HelpSupportcontent.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                    HelpSupportcontent.ModifiedDate = GlobalRT.GetServerDateTime();
                }
                if ((hdIsEdit.Value == "true" && chkActv.Checked == true) || (hdSave.Value == "true" && chkActv.Checked != true))
                {
                    HelpSupportcontent.IsActive = true;
                }
                else if (hdIsEdit.Value == "true" && chkActv.Checked == false)
                {
                    HelpSupportcontent.IsActive = false;
                }
            }
            catch (Exception ex)
            {
                lblMassagehelpSupport.Text = "Error : " + ex.Message;
                lblMassagehelpSupport.ForeColor = System.Drawing.Color.Red;
            }
            return HelpSupportcontent;
        }

        private object HelpSupportImageUpload()
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
                    string path = Server.MapPath("~/Image/HelpandAlert/");
                    FileUploadHelper.BindImage(FileUploadImage, path, tempMatImageName);
                    imageUrl.ImageUrlTemp = "~/Image/HelpandAlert/" + tempMatImageName + Path.GetExtension(FileUploadImage.FileName);

                    return imageUrl.ImageUrlTemp.ToString();
                }
                return imageUrl.ImageUrlTemp.ToString();
            }
            catch (Exception ex)
            {
                lblMassagehelpSupport.Text = "error: " + ex.Message;
            }
            return imageUrl.ImageUrlTemp.ToString();
        }

       

        private void ClearField()
        {
            txtDescription.Text = string.Empty;
            txtTitle.Text = string.Empty;
            ddlHelpSupportTypeID.SelectedValue = null;
            chkActv.Checked = false;
            chkActv.Visible = false;
        }

        protected void lvhelpSupport_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            lblMassagehelpSupport.Text = string.Empty;
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void dataPagerhelpSupport_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    LoadHelpSuppotListView();
                }
            }
            catch (Exception ex)
            {
                lblMassagehelpSupport.Text = "Error : " + ex.Message;
                lblMassagehelpSupport.ForeColor = System.Drawing.Color.Red;
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
                Int64 helpSupportid = Convert.ToInt64(linkButton.CommandArgument);
                hdContentID.Value = helpSupportid.ToString();
                using (HelpSupportRT receiverTransfer = new HelpSupportRT())
                {
                    OiiOHaatHelpSupport helpSupportcontent = receiverTransfer.GetOtherContentByIID(helpSupportid);
                    FillCMScontentForEdit(helpSupportcontent);
                }
            }
            catch (Exception ex)
            {
                lblMassagehelpSupport.Text = "Error : " + ex.Message;
                lblMassagehelpSupport.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void FillCMScontentForEdit(OiiOHaatHelpSupport helpSupportcontent)
        {
            try
            {
                if (helpSupportcontent != null)
                {

                    txtDescription.Text = helpSupportcontent.Description;
                    txtTitle.Text = helpSupportcontent.Title;
                    ddlHelpSupportTypeID.SelectedValue = helpSupportcontent.HelpSupportTypeID.ToString();
                    txtHoldImagePath.Text = helpSupportcontent.Image;
                    if (helpSupportcontent.IsActive == true)
                    {

                        chkActv.Checked = true;

                    }
                    else
                    {
                        chkActv.Checked = false;
                    }
                    Session[sessHelpSuppot] = helpSupportcontent;
                }
            }
            catch (Exception ex)
            {
                lblMassagehelpSupport.Text = "Error : " + ex.Message;
                lblMassagehelpSupport.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                lblMassagehelpSupport.Text = string.Empty;
                using (HelpSupportRT receiverTransfer = new HelpSupportRT())
                {
                    hdIsEdit.Value = "true";
                    OiiOHaatHelpSupport HelpSupportcontent = CreateCMScontent();

                    if (HelpSupportcontent != null)
                    {

                        //if (receiverTransfer.IsExistCMSType(HelpSupportcontent.IID, HelpSupportcontent.HelpSupportTypeID))
                        //{
                        //    lblMassageCMS.Text = "Same Cms Type already active ...";
                        //    lblMassageCMS.ForeColor = System.Drawing.Color.Red;

                        //}
                        //else
                        //{
                            receiverTransfer.UpdateCMScontent(HelpSupportcontent);
                            lblMassagehelpSupport.Text = "Data successfully updated...";
                            lblMassagehelpSupport.ForeColor = System.Drawing.Color.Green;
                        //}

                    }
                    else
                    {
                        lblMassagehelpSupport.Text = "Data not updated...";
                        lblMassagehelpSupport.ForeColor = System.Drawing.Color.Red;
                    }

                }
                ClearField();
                btnVisibilityForCancel();
                LoadHelpSuppotListView();
                txtHoldImagePath.Text = string.Empty;
                hdIsEdit.Value = null; ;
            }

            catch (Exception ex)
            {
                lblMassagehelpSupport.Text = "Error : " + ex.Message;
                lblMassagehelpSupport.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void btnVisibilityForCancel()
        {
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            chkActv.Visible = false;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearField();
            lblMassagehelpSupport.Text = "";
            btnVisibilityForCancel();
        }
    }
}