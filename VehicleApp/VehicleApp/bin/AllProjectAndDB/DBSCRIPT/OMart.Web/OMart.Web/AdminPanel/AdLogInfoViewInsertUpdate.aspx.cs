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
    public partial class AdLogInfoViewInsertUpdate : System.Web.UI.Page
    {
       private readonly AdLogInfoRT _BDAdLogInfoRT;
        
        private int IID = default(int);

        public AdLogInfoViewInsertUpdate()
        {
            _BDAdLogInfoRT = new AdLogInfoRT();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                
                if (!IsPostBack)
                {

                    LoadDropDownPremiumPolicyID(null);
                    var requestId = Request.QueryString["IID"];
                    int reqID = Convert.ToInt32( requestId);
                    bool reqIDIsValid = Int32.TryParse(requestId, out IID);
                    if (reqID != 0 )
                    {
                        ShowAdLogInfoData();
                    }
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void LoadDropDownPremiumPolicyID(int? LIApplicableAmntYrScdleOb)
        {
            try
            {


                {
                    ddlDisplayOnPageID.Items.Add(new ListItem("Select Display On Page ID Type ", "-1"));
                    foreach (Utilities.EnumCollection.DisplayOnPage r in Enum.GetValues(typeof(Utilities.EnumCollection.DisplayOnPage)))
                    {
                        ListItem item = new ListItem(Enum.GetName(typeof(Utilities.EnumCollection.DisplayOnPage), r), r.ToString());
                        ddlDisplayOnPageID.Items.Add(item);
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
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
                    string path = Server.MapPath("~/All Photos/Logo/");
                    //FileUploadHelper.BindImage(FileUploadImage, path, tempMatImageName, 800, 800);
                    FileUploadHelper.BindImage(FileUploadImage, path, tempMatImageName);
                    imageUrl.ImageUrlTemp = "~/All Photos/Logo/" + tempMatImageName + Path.GetExtension(FileUploadImage.FileName);

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
        
        protected void btn_CreateOrEdit_Click(object sender, EventArgs e)
        {
            try
            {
                AdLogInfo AdLogInfo = CreateAdLogInfo();
                AdLogInfoRT channelRT = new AdLogInfoRT();
                bool reqIDIsValid = Int32.TryParse(Request.QueryString["IID"], out IID);
                string msg = (string)BusinessLogicValidation(AdLogInfo);
                var requestId = Request.QueryString["IID"];
                int reqID = Convert.ToInt32(requestId);
                if (string.IsNullOrEmpty(msg))
                {
                    if (IID <= 0)
                    {
                        AdLogInfo.CreatedBy = Convert.ToInt64(Session["UserID"]);
                        AdLogInfo.CreatedDate = DateTime.Now;
                        AdLogInfo.IsRemoved = chkIsRemoved.Checked;
                        AdLogInfoRT loanRT = new AdLogInfoRT();
                        loanRT.AddAdLogInfo(AdLogInfo);
                        ClearData();

                        labelMessage.Text = "Information has been inserted successfully.";
                        labelMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        AdLogInfoRT loanRT = new AdLogInfoRT();
                        AdLogInfo objAdLogInfo = loanRT.GetAdLogInfoByIID(IID);

                        if (objAdLogInfo != null)
                        {
                            AdLogInfo.CreatedBy = objAdLogInfo.CreatedBy; 
                            AdLogInfo.CreatedDate = objAdLogInfo.CreatedDate;
                            //AdLogInfo.IsRemoved = objAdLogInfo.IsRemoved;
                            AdLogInfo.IID = objAdLogInfo.IID;

                            AdLogInfo.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                            AdLogInfo.ModifiedDate = DateTime.Now;
                            
                            loanRT.UpdateAdLogInfo(AdLogInfo);
                            ClearData();

                            labelMessage.Text = "Information has been updated successfully.";
                            labelMessage.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            labelMessage.Text = "Information has not been updated successfully.";
                            labelMessage.ForeColor = System.Drawing.Color.Green;
                        }
                    }
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
            //LoanAmntYrScdle ob = new LoanAmntYrScdle();
            //ob.showAdLogInfoGrid();
        }

        private string BusinessLogicValidation(AdLogInfo AdLogInfo)
        {
            string message = string.Empty;
            bool reqIDIsValid = Int32.TryParse(Request.QueryString["IID"], out IID);


            if (string.IsNullOrEmpty(AdLogInfo.Name))
            {
                return message = "AdLogInfo name is required.";
            }
            //if (string.IsNullOrEmpty(AdLogInfo.LogoUrl.ToString()))
            //{
            //    return message = "AdLogInfo name is required.";
            //}
            if (IID <= 0)
            {
                AdLogInfoRT _BDAdLogInfoRT2 = new AdLogInfoRT();
                AdLogInfo objAdLogInfoName = _BDAdLogInfoRT2.GetAdLogInfoName(AdLogInfo.Name);
                if (objAdLogInfoName != null)
                {
                    if (objAdLogInfoName.Name == AdLogInfo.Name)
                    {
                        return message = "AdLogInfo name already exists.";
                    }
                }

                

                


            }
            else
            {
                AdLogInfoRT _BDAdLogInfoRT2 = new AdLogInfoRT();
                AdLogInfo AdLogInfoName = (from tr in _BDAdLogInfoRT2.GetAllAdLogInfo()
                                          where tr.Name == AdLogInfo.Name && tr.IID != IID
                                          select tr).SingleOrDefault();
                 if (AdLogInfoName != null)
                {
                    if (AdLogInfoName.Name == AdLogInfo.Name)
                    {
                        return message = "AdLogInfo name already exists.";
                    }
                }

                 

                
            }

            return message;
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/AdminPanel/AdLogInfoView");
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void ShowAdLogInfoData()
        {
            try
            {
                AdLogInfoRT loanRt = new AdLogInfoRT();
                AdLogInfo objAdLogInfo = loanRt.GetAdLogInfoByIID(IID);
                if (objAdLogInfo != null)
                {
                    ddlDisplayOnPageID.SelectedValue = Enum.GetName(typeof(Utilities.EnumCollection.DisplayOnPage), objAdLogInfo.DisplayOnPageID);
                    txtAddress.Text = objAdLogInfo.Address.ToString();
                    txtName.Text = objAdLogInfo.Name.ToString();
                    txtBussinessDescription.Text = objAdLogInfo.BussinessDescription.ToString();
                    txtContractPhone.Text = objAdLogInfo.ContactPhoneNo.ToString();
                    txtDisplayEndDate.Text = objAdLogInfo.DisplayEndDate.ToString(); 
                    txtDisplayStartDate.Text = objAdLogInfo.DisplayStartDate.ToString();                    
                    txtPayAmount.Text = objAdLogInfo.PayAmount.ToString();
                    txtWebAddress.Text = objAdLogInfo.WebAddress.ToString();
                    txtHoldImagePath.Text = objAdLogInfo.LogoUrl.ToString();
                    chkIsRemoved.Checked = objAdLogInfo.IsRemoved;


                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        //private string BusinessLogicValidation(AdLogInfo AdLogInfo)
        //{
        //    string message = string.Empty;
        //    bool reqIDIsValid = Int32.TryParse(Request.QueryString["IID"], out IID);

        //    if (IID <= 0)
        //    {
        //        AdLogInfo objAdLogInfoName = (from tr in _AdLogInfoRT.GetAllLoanAmntYrScdle()
        //                                              where tr.CompanyInfoID == AdLogInfo.CompanyInfoID
        //                                              select tr).SingleOrDefault();
        //        if (AdLogInfo != null)
        //        {
        //            if (objAdLogInfoName.CompanyInfoID == AdLogInfo.CompanyInfoID)
        //            {
        //                message = "AdLogInfo name already exists.";
        //            }
        //        }

        //    }

        //    return message;
        //}

        private AdLogInfo CreateAdLogInfo()
        {
            Session["UserID"] = "1";
            AdLogInfo objAdLogInfo = new AdLogInfo();
            try
            {
                
                objAdLogInfo.Address = txtAddress.Text ;
                objAdLogInfo.Name = txtName.Text ;
                objAdLogInfo.BussinessDescription = txtBussinessDescription.Text;
                objAdLogInfo.ContactPhoneNo = txtContractPhone.Text ;
                objAdLogInfo.DisplayEndDate = Convert.ToDateTime( txtDisplayEndDate.Text) ;
                objAdLogInfo.DisplayStartDate = Convert.ToDateTime( txtDisplayStartDate.Text) ;
                objAdLogInfo.PayAmount = Convert.ToDecimal( txtPayAmount.Text) ;
                objAdLogInfo.WebAddress = txtWebAddress.Text ;
                objAdLogInfo.LogoUrl = txtHoldImagePath.Text ;
                objAdLogInfo.DisplayOnPageID = (Int32)Enum.Parse(typeof(Utilities.EnumCollection.DisplayOnPage), ddlDisplayOnPageID.SelectedValue.ToString());
                objAdLogInfo.IsRemoved = chkIsRemoved.Checked  ;
                
                objAdLogInfo.IsRemoved = chkIsRemoved.Checked  ;
                if (txtHoldImagePath.Text == string.Empty && FileUploadImage.HasFile == true)
                {
                    objAdLogInfo.LogoUrl = ImageUpload().ToString();
                }
                else if (txtHoldImagePath.Text != null && FileUploadImage.HasFile == true)
                {
                    objAdLogInfo.LogoUrl = ImageUpload().ToString();
                }
                else
                {
                    objAdLogInfo.LogoUrl = txtHoldImagePath.Text;
                }
                
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return objAdLogInfo;
        }

        private void ClearData()
        {
            
            
            txtAddress.Text = string.Empty;
            txtName.Text = string.Empty;
            txtBussinessDescription.Text = string.Empty;
            txtContractPhone.Text = string.Empty;
            txtDisplayEndDate.Text = string.Empty;
            ddlDisplayOnPageID.SelectedIndex = -1;
            txtDisplayStartDate.Text = string.Empty;
            txtPayAmount.Text = string.Empty;
            txtWebAddress.Text = string.Empty;
            txtHoldImagePath.Text = string.Empty;
            chkIsRemoved.Checked = false;
            
        }

    }
}