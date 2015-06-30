using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OH.BLL.Basic;
using OH.DAL;
using OH.Utilities;
using System.Text;
using System.Globalization;
using System.IO;

namespace OH.Web.ControlAdmin
{
    public partial class OiiOAlertWF : System.Web.UI.Page
    {
        /// <summary>
        /// Author:Asiful Islam
        /// </summary>
        private const string sessAlert = "seAlert";
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
               
                    Session["seOthercontentPicTempFileName"] = null;
                    LoadAlertListView();
                    btnSave.Visible = true;
                    btnUpdate.Visible = false;
                    btnCancel.Visible = false;
                    chkActv.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblMassageAlert.Text = "Error : " + ex.Message;
                lblMassageAlert.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void LoadAlertListView()
        {
            try
            {
                using (alertRT receiverTransfer = new alertRT())
                {
                    lvAlert.DataSource = receiverTransfer.GetAlertAllForListView(); ;
                    lvAlert.DataBind();


                }
            }
            catch (Exception ex)
            {
                lblMassageAlert.Text = "Error : " + ex.Message;
                lblMassageAlert.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                lblMassageAlert.Text = string.Empty;

                using (alertRT receiverTransfer = new alertRT())
                {
                    //bool CMStypeNotExist = receiverTransfer.GetCMSContentByCMStype(Convert.ToInt32(ddlCMSTypeID.SelectedValue));
                    //if (CMStypeNotExist && ddlCMSTypeID.SelectedValue != "-1")
                    //{
                    hdSave.Value = "true";
                    OiiOHaatAlert Alertcontent = CreateAlertcontent();
                    receiverTransfer.AddAlertContent(Alertcontent);
                    if (Alertcontent.IID > 0)
                    {
                        lblMassageAlert.Text = "Data successfully saved...";
                        lblMassageAlert.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblMassageAlert.Text = "Data not saved...";
                        lblMassageAlert.ForeColor = System.Drawing.Color.Red;
                    }
                    //}
                    //else
                    //{
                    //    lblMassageCMS.Text = "You Can't Enter Same CMS type More then once. Please Deactivate That CMS Type. \n  And You Also have to Select A CMS Type";
                    //    lblMassageCMS.ForeColor = System.Drawing.Color.Red;
                    //}
                }


                ClearField();
                LoadAlertListView();
                hdSave.Value = null;
            }
            catch (Exception ex)
            {
                lblMassageAlert.Text = "Error : " + ex.Message;
                lblMassageAlert.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void ClearField()
        {
            txtDescription.Text = string.Empty;
            txtTitle.Text = string.Empty;
            chkActv.Checked = false;
            chkActv.Visible = false;
            
        }
        private void btnVisibilityForCancel()
        {
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            chkActv.Visible = false;
        }
        private OiiOHaatAlert CreateAlertcontent()
        {
            Session["UserID"] = "1";
            OiiOHaatAlert Alertcontent = new OiiOHaatAlert();
            try
            {
                if (hdIsEdit.Value == "true")
                {
                    Alertcontent.IID = Convert.ToInt32(hdContentID.Value.ToString());
                }
                Alertcontent.Title = txtTitle.Text.Trim();
                Alertcontent.Description = txtDescription.Text.Trim();
           

                if (txtHoldImagePath.Text == string.Empty && FileUploadImage.HasFile == true)
                {
                    Alertcontent.Image = AlertImageUpload().ToString();
                }
                else if (txtHoldImagePath.Text != null && FileUploadImage.HasFile == true)
                {
                    Alertcontent.Image = AlertImageUpload().ToString();
                }
                else
                {
                    Alertcontent.Image = txtHoldImagePath.Text;
                }
                if (Alertcontent.IID <= 0)
                {
                    Alertcontent.CreatedBy = Convert.ToInt64(Session["UserID"]);
                    Alertcontent.CreatedDate = GlobalRT.GetServerDateTime();
                }
                else
                {
                    OiiOHaatAlert alertcontent = (OiiOHaatAlert)Session[sessAlert];
                    Alertcontent.CreatedBy = alertcontent.CreatedBy; ;
                    Alertcontent.CreatedDate = alertcontent.CreatedDate;
                    Alertcontent.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                    Alertcontent.ModifiedDate = GlobalRT.GetServerDateTime();
                }
                if ((hdIsEdit.Value == "true" && chkActv.Checked == true) || (hdSave.Value == "true" && chkActv.Checked != true))
                {
                    Alertcontent.IsActive = true;
                }
                else if (hdIsEdit.Value == "true" && chkActv.Checked == false)
                {
                    Alertcontent.IsActive = false;
                }
            }
            catch (Exception ex)
            {
                lblMassageAlert.Text = "Error : " + ex.Message;
                lblMassageAlert.ForeColor = System.Drawing.Color.Red;
            }
            return Alertcontent;
        }

        private object AlertImageUpload()
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
                lblMassageAlert.Text = "error: " + ex.Message;
            }
            return imageUrl.ImageUrlTemp.ToString();
        }

        protected void lvAlert_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            lblMassageAlert.Text = string.Empty;
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void dataPagerAlert_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    LoadAlertListView();
                }
            }
            catch (Exception ex)
            {
                lblMassageAlert.Text = "Error : " + ex.Message;
                lblMassageAlert.ForeColor = System.Drawing.Color.Red;
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
                Int64 alertid = Convert.ToInt64(linkButton.CommandArgument);
                hdContentID.Value = alertid.ToString();
                using (alertRT receiverTransfer = new alertRT())
                {
                    OiiOHaatAlert alertcontent = receiverTransfer.GetOtherContentByIID(alertid);
                    FillCMScontentForEdit(alertcontent);
                }
            }
            catch (Exception ex)
            {
                lblMassageAlert.Text = "Error : " + ex.Message;
                lblMassageAlert.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void FillCMScontentForEdit(OiiOHaatAlert alertcontent)
        {
            try
            {
                if (alertcontent != null)
                {

                    txtDescription.Text = alertcontent.Description;
                    txtTitle.Text = alertcontent.Title;

                    txtHoldImagePath.Text = alertcontent.Image;
                    if (alertcontent.IsActive == true)
                    {

                        chkActv.Checked = true;

                    }
                    else
                    {
                        chkActv.Checked = false;
                    }
                    Session[sessAlert] = alertcontent;
                }
            }
            catch (Exception ex)
            {
                lblMassageAlert.Text = "Error : " + ex.Message;
                lblMassageAlert.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                lblMassageAlert.Text = string.Empty;
                using (alertRT receiverTransfer = new alertRT())
                {
                    hdIsEdit.Value = "true";
                    OiiOHaatAlert alertcontent = CreateAlertcontent();

                    if (alertcontent != null)
                    {

                        //if (receiverTransfer.IsExistCMSType(HelpSupportcontent.IID, HelpSupportcontent.HelpSupportTypeID))
                        //{
                        //    lblMassageCMS.Text = "Same Cms Type already active ...";
                        //    lblMassageCMS.ForeColor = System.Drawing.Color.Red;

                        //}
                        //else
                        //{
                        receiverTransfer.UpdateAlertcontent(alertcontent);
                        lblMassageAlert.Text = "Data successfully updated...";
                        lblMassageAlert.ForeColor = System.Drawing.Color.Green;
                        //}

                    }
                    else
                    {
                        lblMassageAlert.Text = "Data not updated...";
                        lblMassageAlert.ForeColor = System.Drawing.Color.Red;
                    }

                }
                ClearField();
                btnVisibilityForCancel();
                LoadAlertListView();
                txtHoldImagePath.Text = string.Empty;
                hdIsEdit.Value = null;
            }

            catch (Exception ex)
            {
                lblMassageAlert.Text = "Error : " + ex.Message;
                lblMassageAlert.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearField();
            lblMassageAlert.Text = "";
            btnVisibilityForCancel();
        }


    }
}