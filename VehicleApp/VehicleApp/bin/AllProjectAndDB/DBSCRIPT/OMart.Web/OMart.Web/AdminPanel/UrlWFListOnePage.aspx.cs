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

namespace OMart.Web
{
    public partial class UrlWFListOnePage : System.Web.UI.Page
    {
        private const string sessUrlWFList = "seUrlWFList";

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
                    string path = Server.MapPath("~/Images/banner/");
                    FileUploadHelper.BindImage(FileUploadImage, path, tempMatImageName, 800, 800);
                    imageUrl.ImageUrlTemp = "~/Images/banner/" + tempMatImageName + Path.GetExtension(FileUploadImage.FileName);

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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    LoadDropDownModule();
                    LoadUrlWFList();
                    showSaveBtn();
                }
                catch (Exception ex)
                {
                    labelMessage.Text = "Error : " + ex.Message;
                    labelMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        private void LoadDropDownModule()
        {
            try
            {

                dropDownModuleName.Items.Add("--Select Module Name--");
                DropDownListHelper.Bind(dropDownModuleName, EnumHelper.EnumToList<EnumCollection.BussinessType>());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        protected void lnkbDelete_Click()
        {
            try
            {
                
                try
                {
                    hdIsDelete.Value = "true";
                    hdIsEdit.Value = "true";
                    labelMessage.Text = string.Empty;
                    using (UrlWFListRT reciveTransfer = new UrlWFListRT())
                    {
                        UrlWFList urlWFList = CreateUrlList();
                        List<UserWFPermission> checkIDList = new List<UserWFPermission>();
                        checkIDList = reciveTransfer.checkUrlListByID(urlWFList.IID);
                        if (checkIDList.Count() > 0)
                        {
                            labelMessage.Text = "Url List " + txtUrlWFName + " Used in UserPermission";
                            labelMessage.ForeColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            reciveTransfer.DeleteUrl(urlWFList.IID);
                            labelMessage.Text = "Successfully Deleted!";
                            labelMessage.ForeColor = System.Drawing.Color.Green;

                        }

                    }
                }
                catch (Exception ex)
                {
                    labelMessage.Text = "Error " + ex.Message;
                    labelMessage.ForeColor = System.Drawing.Color.Red;
                }
                LoadUrlWFList();
                ClearField();
                showSaveBtn();
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lnkbEdit_Click(object sender, EventArgs e)
        {
            using (UrlWFListRT receiveTransfer = new UrlWFListRT())
            {
                hdIsEdit.Value = "true";
                UrlWFList urlWFList = CreateUrlList();
                List<UserWFPermission> checkIDList = new List<UserWFPermission>();
                checkIDList = receiveTransfer.checkUrlListByID(urlWFList.IID);
                if (checkIDList.Count() > 0)
                {
                    labelMessage.Text = "Url List " + txtUrlWFName + " Used in UserPermission";
                    labelMessage.ForeColor = System.Drawing.Color.Red;
                    return;
                }


                if (urlWFList != null)
                {
                    receiveTransfer.UpdateUrlWFList(urlWFList);
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
            LoadUrlWFList();
        }
        protected void FillUrlWFForEdit(UrlWFList urlWFList)
        {
            try
            {
                if (urlWFList != null)
                {
                    txtUrlWFName.Text = urlWFList.UrlWFName;
                    txtUrlWFDisplayName.Text = urlWFList.UrlWFDisplayName;
                    txtModuleurl.Text = urlWFList.UrlModuleName;
                    txtModuleSerialNo.Text = urlWFList.ModuleSerialNo.ToString();
                    txtUrlWFSerialNo.Text = urlWFList.UrlWFSerialNo.ToString();
                    txtHoldImagePath.Text = urlWFList.ModuleImage.ToString();
                    txtModuleNote.Text = urlWFList.ModuleNote.ToString();
                    //FileUploadImage.AppRelativeTemplateSourceDirectory = urlWFList.ModuleImage.ToString();

                    EnumCollection.BussinessType moduleListEnum = (EnumCollection.BussinessType)Enum.Parse(typeof(EnumCollection.BussinessType), urlWFList.ModuleName);
                    dropDownModuleName.SelectedValue = ((int)moduleListEnum).ToString();

                    Session[sessUrlWFList] = urlWFList;
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private UrlWFList CreateUrlList()
        {
            Session["UserID"] = "1";
            UrlWFList urlWFList = new UrlWFList();
            try
            {
                if (hdIsEdit.Value == "true")
                {
                    urlWFList.IID = Convert.ToInt32(hdUrlListID.Value.ToString());
                }
                urlWFList.UrlWFName = txtUrlWFName.Text.Trim();
                urlWFList.UrlWFDisplayName = txtUrlWFDisplayName.Text.Trim();
                urlWFList.ModuleName = dropDownModuleName.SelectedItem.ToString();
                urlWFList.UrlModuleName = txtModuleurl.Text.Trim(); 
                urlWFList.ModuleNote = txtModuleNote.Text.Trim();
                
                if (txtHoldImagePath.Text == string.Empty && FileUploadImage.HasFile == true)
                {
                    urlWFList.ModuleImage = ImageUpload().ToString();
                }
                else if (txtHoldImagePath.Text != null && FileUploadImage.HasFile == true)
                {
                    urlWFList.ModuleImage = ImageUpload().ToString();
                }
                else
                {
                    urlWFList.ModuleImage = txtHoldImagePath.Text;
                }
                urlWFList.UrlWFSerialNo = Convert.ToInt32(txtUrlWFSerialNo.Text.Trim());
                urlWFList.ModuleSerialNo = Convert.ToInt32(txtModuleSerialNo.Text.Trim());
                if (urlWFList.IID <= 0)
                {
                    urlWFList.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    urlWFList.CreatedDate = GlobalRT.GetServerDateTime();
                }
                else
                {
                    UrlWFList url = (UrlWFList)Session[sessUrlWFList];
                    urlWFList.CreatedBy = url.CreatedBy;
                    urlWFList.CreatedDate = url.CreatedDate;
                    urlWFList.ModifiedBy = url.ModifiedBy;
                    urlWFList.ModifiedDate = url.ModifiedDate;
                }

            }
            catch (Exception e)
            {
                labelMessage.Text = "Error: " + e.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return urlWFList;
        }
        private void visiblefield()
        {

            btnSave.Visible = true;
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
        }
        private void ClearField()
        {
            txtUrlWFName.Text = string.Empty;
            txtUrlWFDisplayName.Text = string.Empty;
            dropDownModuleName.SelectedValue = null;
            //LoadDropDownModule(null);
            txtModuleSerialNo.Text = string.Empty;
            txtUrlWFSerialNo.Text = string.Empty;
            txtModuleNote.Text = string.Empty;
        }

        private void LoadUrlWFList()
        {
            UrlWFListRT reciveTransfer = new UrlWFListRT();
            lvUrlWFList.DataSource = reciveTransfer.GetUrlWFListAllForListView();
            lvUrlWFList.DataBind();
        }



        protected void lvUrlWFList_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            labelMessage.Text = "...";
            labelMessage.ForeColor = System.Drawing.Color.Green;
            if (e.CommandName == "EditUrlWFList")
            {
                try
                {
                    btnUpdate.Visible = true;
                    btnCancel.Visible = true;
                    btnSave.Visible = false;
                    btnDelete.Visible = false;
                    int urlListID = Convert.ToInt32(e.CommandArgument);
                    hdUrlListID.Value = urlListID.ToString();
                    using (UrlWFListRT receiverTransfer = new UrlWFListRT())
                    {
                        UrlWFList urlWFList = receiverTransfer.GetUrlWFListByID(urlListID);
                        FillUrlWFForEdit(urlWFList);
                    }
                    

                }
                catch (Exception ex)
                {
                    labelMessage.Text = "Error : " + ex.Message;
                    labelMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            else if (e.CommandName == "DeleteUrlWFList")
            {
                try
                {

                    int urlListID = Convert.ToInt32(e.CommandArgument);
                    hdUrlListID.Value = urlListID.ToString();
                    using (UrlWFListRT receiverTransfer = new UrlWFListRT())
                    {
                        UrlWFList urlWFList = receiverTransfer.GetUrlWFListByID(urlListID);
                        FillUrlWFForEdit(urlWFList);
                    }
                    lnkbDelete_Click();

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
        protected void lvUrlWFList_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void dataPagerUrlWFList_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 5;
                if (IsPostBack)
                {
                    LoadUrlWFList();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        //save department
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (UrlWFListRT receiveTransfer = new UrlWFListRT())
                {
                    List<UrlWFList> urlListList = new List<UrlWFList>();
                    urlListList = receiveTransfer.GetUrlWFListByNmae(txtUrlWFName.Text.Trim());
                    if (urlListList != null && urlListList.Count() > 0)
                    {
                        string msg = "...Url List already exist...";
                        labelMessage.Text = msg;
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                        ClearField();
                        return;
                    }

                    UrlWFList urlList = CreateUrlList();
                    receiveTransfer.AddUrlWFList(urlList);

                    if (urlList.IID > 0)
                    {
                        labelMessage.Text = "Url List Successffuly Inserted";
                        labelMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        labelMessage.Text = "Url did not Inserted";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                    }

                }
                ClearField();
                LoadUrlWFList();
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                hdIsDelete.Value = "true";
                hdIsEdit.Value = "true";
                labelMessage.Text = string.Empty;
                using (UrlWFListRT reciveTransfer = new UrlWFListRT())
                {
                    UrlWFList urlWFList = CreateUrlList();
                    List<UserWFPermission> checkIDList = new List<UserWFPermission>();
                    checkIDList = reciveTransfer.checkUrlListByID(urlWFList.IID);
                    if (checkIDList.Count() > 0)
                    {
                        labelMessage.Text = "Url List " + txtUrlWFName + " Used in UserPermission";
                        labelMessage.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        reciveTransfer.DeleteUrl(urlWFList.IID);
                        labelMessage.Text = "Successfully Deleted!";
                        labelMessage.ForeColor = System.Drawing.Color.Green;

                    }

                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            LoadUrlWFList();
            ClearField();
            showSaveBtn();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

            labelMessage.Text = "...";
            labelMessage.ForeColor = System.Drawing.Color.Green;
            showSaveBtn();
            ClearField();


        }
        protected void showSaveBtn()
        {
            btnSave.Visible = true;
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            using (UrlWFListRT receiveTransfer = new UrlWFListRT())
            {
                hdIsEdit.Value = "true";
                UrlWFList urlWFList = CreateUrlList();
                List<UserWFPermission> checkIDList = new List<UserWFPermission>();
                checkIDList = receiveTransfer.checkUrlListByID(urlWFList.IID);
                if (checkIDList.Count() > 0)
                {
                    labelMessage.Text = "Url List " + txtUrlWFName + " Used in UserPermission";
                    labelMessage.ForeColor = System.Drawing.Color.Red;
                    return;
                }


                if (urlWFList != null)
                {
                    receiveTransfer.UpdateUrlWFList(urlWFList);
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
            LoadUrlWFList();

        }


        protected void dropDownModuleName_SelectedIndexChanged1(object sender, EventArgs e)
        {
            try
            {


                if (dropDownModuleName.SelectedIndex > 0)
                {
                    txtModuleSerialNo.Text = dropDownModuleName.SelectedValue;
                }
                else
                    txtModuleSerialNo.Text = string.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }




    }
}