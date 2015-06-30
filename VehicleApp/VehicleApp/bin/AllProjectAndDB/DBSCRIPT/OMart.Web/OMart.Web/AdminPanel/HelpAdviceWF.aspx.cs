using BLL.Basic;
using DAL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace OMart.Web.AdminPanel
{
    public partial class HelpAdviceWF : System.Web.UI.Page
    {
        private const string sessHelpContent = "seHelpContent";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    LoadHelpListView();
                    btnSave.Visible = true;
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    btnCancel.Visible = false;
                }
                catch (Exception ex)
                {
                    labelMessage.Text = "Error : " + ex.Message;
                    labelMessage.ForeColor = System.Drawing.Color.Red;
                }
            }

        }

        #region private method
       

        private void LoadHelpListView()
        {
            try
            {
                using (HelpAdviceRT receiverTransfer = new HelpAdviceRT())
                {
                    var helpList = receiverTransfer.GetHelpContentAll();
                    lvHelpAdvice.DataSource = helpList;
                    lvHelpAdvice.DataBind();

                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private HelpAdvice CreateHelpAdvice()
        {
            Session["UserID"] = "1";
            HelpAdvice help = new HelpAdvice();
            try
            {
                if (hdIsEdit.Value == "true")
                {
                    help.IID = Convert.ToInt32(hdHelpID.Value.ToString());
                }
                help.Title = txtHelpTitle.Text.Trim();
                //cms.CMSDescription = txtCMSDes.Text.Trim();
                //string str = txtCMSDes.Text;
                help.Description =txtHelpDescription.Text.Trim();
                if (txtHoldImagePath.Text == string.Empty && FileUploadImage.HasFile == true)
                {
                    help.Image = ImageUpload().ToString();
                }
                else if (txtHoldImagePath.Text != null && FileUploadImage.HasFile == true)
                {
                    help.Image = ImageUpload().ToString();
                }
                else
                {
                    help.Image = txtHoldImagePath.Text;
                }
                if (help.IID <= 0)
                {
                    help.CreatedBy = Convert.ToInt64(Session["UserID"]);
                    help.CreatedDate = GlobalRT.GetServerDateTime();
                }
                else
                {
                    HelpAdvice con = (HelpAdvice)Session[sessHelpContent];
                    help.CreatedBy = con.CreatedBy; ;
                    help.CreatedDate = con.CreatedDate;
                    help.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                    help.ModifiedDate = GlobalRT.GetServerDateTime();
                }
                
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return help;
        }
        public class ImageUrl
        {
            public string ImageUrlPer { get; set; }
            public string ImageUrlTemp { get; set; }
        }

        private string ImageUpload()
        {
            List<ImageUrl> OthrContntPicTempFileUrlList = new List<ImageUrl>();
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
                    string path = Server.MapPath("~/All Photos/HelpPhotos/");
                    FileUploadHelper.BindImage(FileUploadImage, path, tempMatImageName, 800, 800);
                    imageUrl.ImageUrlTemp = "~/All Photos/HelpPhotos/" + tempMatImageName + Path.GetExtension(FileUploadImage.FileName);

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

        private void FillNewsForEdit(HelpAdvice help)
        {
            try
            {
                if (help != null)
                {
                    txtHelpTitle.Text = help.Title;
                    txtHelpDescription.Text = help.Description;
                    txtHoldImagePath.Text = help.Image;
                   
                    Session[sessHelpContent] = help;
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void ClearField()
        {
            txtHelpTitle.Text = string.Empty;
            txtHelpDescription.Text = string.Empty;
            txtHoldImagePath.Text = string.Empty;
        }

        private void btnVisibilityForCancel()
        {
            btnSave.Visible = true;
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
        }
        #endregion private method

        #region protected method
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                labelMessage.Text = string.Empty;

                using (HelpAdviceRT receiverTransfer = new HelpAdviceRT())
                {
                    List<HelpAdvice> helpList = new List<HelpAdvice>();
                    helpList = receiverTransfer.GetHelpByTitle(txtHelpTitle.Text.Trim());
                    if (helpList != null && helpList.Count > 0)
                    {
                        string msg = "Title Name  " + txtHelpTitle.Text + " Already Exists!";
                        labelMessage.Text = msg;
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    hdSave.Value = "true";
                    HelpAdvice help = CreateHelpAdvice();
                    receiverTransfer.AddHelpDescription(help);
                    if (help.IID > 0)
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

                ClearField();
                LoadHelpListView();
                hdSave.Value = null;
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
                 using (HelpAdviceRT receiverTransfer = new HelpAdviceRT())
                {
                    hdIsEdit.Value = "true";
                    HelpAdvice help = CreateHelpAdvice();

                    if (help != null)
                    {
                        receiverTransfer.UpdateHelp(help);
                        labelMessage.Text = "Data successfully updated...";
                        labelMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        labelMessage.Text = "Data not updated...";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }
                ClearField();
                btnVisibilityForCancel();
                LoadHelpListView();
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
                ClearField();
                btnVisibilityForCancel();
            }
            catch (Exception ex) { }
        }

        protected void lvHelpAdvice_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "EditNews")
            {
                try
                {
                    labelMessage.Text = string.Empty;
                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    btnDelete.Visible = false;
                    btnCancel.Visible = true;
                    int helpID = Convert.ToInt32(e.CommandArgument);
                    hdHelpID.Value = helpID.ToString();
                    using (HelpAdviceRT receiverTransfer = new HelpAdviceRT())
                    {
                        HelpAdvice help = receiverTransfer.GetHelpByIID(helpID);
                        FillNewsForEdit(help);
                    }
                }
                catch (Exception ex)
                {
                    labelMessage.Text = "Error : " + ex.Message;
                    labelMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        int lvRowCount = 0;
        int currentPage = 0;
        protected void lvHelpAdvice_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void dataPagerHelpAdvice_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    LoadHelpListView();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        #endregion protected method
    }
}