using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL.Basic;
using System.Text;
using System.Globalization;
using System.IO;
using Utilities;

namespace OMart.Web.AdminPanel
{
    public partial class MobilePhoneInfoInsertUpdate : System.Web.UI.Page
    {
        private readonly MobilePhoneInfoRT _mobilePhoneInfoRT;
        private long IID = default(Int64);
        private const string seMPFeatureColl = "seMPFeatureColl";
        private const string sessMPFeature = "seMPFeatureColl";
        int lvRowCount = 0;
        int currentPage = 0;
        public MobilePhoneInfoInsertUpdate()
        {
            this._mobilePhoneInfoRT = new MobilePhoneInfoRT();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!IsPostBack)
                {
                    LoadDropDownCompany(null);
                    dropDownMPType(null);
                    LoadDropDownNetworkProvider();
                    LoadDropDownUsableDataUnit();
                    LoadDropDownTalkTimeUnit();
                    LoadDropDownAvailableSIM();
                    LoadDropDownConnectionType();
                   lvFeature.Visible = true;
                    var requestId = Request.QueryString["IID"];
                    bool reqIDIsValid = Int64.TryParse(requestId, out IID);
                    if (reqIDIsValid)
                    {
                        ShowMobilePhoneInfoData();
                      
                    }                 
                    
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        #region private methods

            #region load dropdown
            private void LoadDropDownCompany(int? companyID)
        {
            try
            {
                using (CompanyInfoRT receverTransfer = new CompanyInfoRT())
                {
                    List<CompanyInfo> companyInfoList = new List<CompanyInfo>();
                    if (companyID != null)
                    {                        
                        companyInfoList.Add(receverTransfer.GetCompanyInfoByIID((int)companyID));
                    }
                    else
                    {
                        companyInfoList = receverTransfer.GetAllMobileCompanyInfos();
                    }
                    DropDownListHelper.Bind<CompanyInfo>(dropdownCompany, companyInfoList, "Name", "IID", EnumCollection.ListItemType.Company);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
            private void dropDownMPType(int? mpTypeID)
        {
            try
            {
                using (MPTypeRT receverTransfer = new MPTypeRT())
                {
                    List<MPType> _MPTypeList = new List<MPType>();
                    if (mpTypeID != null)
                    {
                        _MPTypeList.Add(receverTransfer.GetMobileByIID((int)mpTypeID));
                    }
                    else
                    {
                        _MPTypeList = receverTransfer.GetAllMobiles();
                    }
                    DropDownListHelper.Bind<MPType>(dropDownMPTypeID, _MPTypeList, "TypeName", "IID", EnumCollection.ListItemType.MPType);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
            private void LoadDropDownNetworkProvider()
        {
            try
            {
                DropDownListHelper.Bind(dropDownNetworkProvider, EnumHelper.EnumToList<EnumCollection.NetworkServiceProvider>(), EnumCollection.ListItemType.NetworkServiceProvider);
              
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
            private void LoadDropDownUsableDataUnit()
        {
            try
            {
                DropDownListHelper.Bind(dropDownUsableDataUnitID, EnumHelper.EnumToList<EnumCollection.UsableDataUnit>(), EnumCollection.ListItemType.UsableDataUnit);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
            private void LoadDropDownTalkTimeUnit()
        {
            try
            {
                DropDownListHelper.Bind(dropDownTalkTimeUnitID, EnumHelper.EnumToList<EnumCollection.TalkTimeUnit>(), EnumCollection.ListItemType.TalkTimeUnit);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
            private void LoadDropDownAvailableSIM()
        {
            try
            {
                DropDownListHelper.Bind(dropdownSIMAvailable, EnumHelper.EnumToList<EnumCollection.AvailableSIM>(), EnumCollection.ListItemType.AvailableSIM);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
            private void LoadDropDownConnectionType()
            {
            
            try
            {
                List<EnumModifier> enumModifierList = new List<EnumModifier>();
                var enumMemberList = EnumHelper.EnumToList<EnumCollection.ConnectionType>();
                foreach (var enumMember in enumMemberList)
                {
                    EnumModifier aEnumModifier = new EnumModifier();
                    string enumDisplayMember = enumMember.ToString();

                    string name = string.Empty;
                    string value = string.Empty;

                    switch (enumDisplayMember)
                    {
                        case "TwoG":
                            name = "2G";
                            value = "1";
                            break;
                        case "ThreeG":
                            name = "3G";
                            value = "2";
                            break;
                        case "ThreeAndHalfG":
                            name = "3.5G";
                            value = "3";
                            break;
                        case "FourG":
                            name = "4G";
                            value = "4";
                            break;
                        case "FourAndHalfG":
                            name = "4.5G";
                            value = "5";
                            break;
                        case "FiveG":
                            name = "5G";
                            value = "5";
                            break;
                    }
                    aEnumModifier.Name = name;
                    aEnumModifier.Value = value;
                    enumModifierList.Add(aEnumModifier);
                }
                DropDownListHelper.Bind(dropDownConnectionTypeID, enumModifierList, "Name", "Value", EnumCollection.ListItemType.ConnectionType);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

            #endregion load dropdown
        private bool TextControlCheckBeforeSave()
        {
            bool mandatoryFieldHasData = true;
           

            if (txtPostVisibilityDay.Text.Trim() == string.Empty)
            {
                labelMessage.Text = " How many days Post needs to visible.";
                labelMessage.ForeColor = System.Drawing.Color.Yellow;
                labelMessage.Focus();
                mandatoryFieldHasData = false;
            }

            if (txtTotalPrice.Text.Trim() == string.Empty)
            {
                labelMessage.Text = " How Much This Phone Costs.";
                labelMessage.ForeColor = System.Drawing.Color.Yellow;
                labelMessage.Focus();
                mandatoryFieldHasData = false;
            }
        
            return mandatoryFieldHasData;
        }
      

        private void ShowMobilePhoneInfoData()
        {
            int days = 0;
            try
            {
                MobilePhoneInfo _MobilePhoneInfo = _mobilePhoneInfoRT.GetMobilePhoneInfoByIID(IID);
                if (_MobilePhoneInfo != null)
                {
                     dropdownCompany.SelectedValue= Convert.ToString(_MobilePhoneInfo.CompanyInfoID );
                     dropDownNetworkProvider.SelectedValue=Convert.ToString(_MobilePhoneInfo.NetworkProviderID);
                     dropDownMPTypeID.SelectedValue = Convert.ToString(_MobilePhoneInfo.MPTypeID);
                     dropdownSIMAvailable.SelectedValue = Convert.ToString(_MobilePhoneInfo.SIMAvailableID);
                     dropDownTalkTimeUnitID.SelectedValue = Convert.ToString(_MobilePhoneInfo.TalkTimeUnitID);
                     dropDownUsableDataUnitID.SelectedValue = Convert.ToString(_MobilePhoneInfo.UsableDataUnitID);
                     dropDownConnectionTypeID.SelectedValue = Convert.ToString(_MobilePhoneInfo.ConnectionTypeID);

                     txtModelName.Text = _MobilePhoneInfo.ModelName != null ? _MobilePhoneInfo.ModelName.ToString() : string.Empty; 
                     txtTotalTalkTime.Text = _MobilePhoneInfo.TotalTalkTime != null ? _MobilePhoneInfo.TotalTalkTime.ToString() : string.Empty;
                     txtWarrantyInfo.Text = _MobilePhoneInfo.WarrantyInfo != null ? _MobilePhoneInfo.WarrantyInfo.ToString() : string.Empty;
                     txtTotalTxtMsg.Text = _MobilePhoneInfo.TotalTextMessage != null ? _MobilePhoneInfo.TotalTextMessage.ToString() : string.Empty;
                     days = (_MobilePhoneInfo.PostLastDisplayDate - _MobilePhoneInfo.PostAdDate).Days;
                     txtPostVisibilityDay.Text = days <= 0 ? "0" : days.ToString();
                     //txtPostVisibilityDay.Text = Convert.ToString(_MobilePhoneInfo.PostLastDisplayDate) != null ? Convert.ToString(_MobilePhoneInfo.PostLastDisplayDate) : string.Empty;                
                     txtTotalUsableData.Text =_MobilePhoneInfo.TotalUsableData !=null ? _MobilePhoneInfo.TotalUsableData.ToString():string.Empty;
                     txtTotalPrice.Text = Convert.ToString(_MobilePhoneInfo.TotalPrice) != null ? Convert.ToString(_MobilePhoneInfo.TotalPrice) : string.Empty; 
                     txtContractDuration.Text = _MobilePhoneInfo.ContractDuration != null ? _MobilePhoneInfo.ContractDuration.ToString() : string.Empty;
                     txtRedirectUrl.Text = _MobilePhoneInfo.RedirectUrl != null ? _MobilePhoneInfo.RedirectUrl.ToString() : string.Empty;
                     txtMonthlyInstallmentAmt.Text = _MobilePhoneInfo.MonthlyInstallmentAmt != null ? _MobilePhoneInfo.MonthlyInstallmentAmt.ToString() : string.Empty;
                     DisplayFeature(_MobilePhoneInfo.IID);               
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private string BusinessLogicValidation(MobilePhoneInfo company)
        {
            string message = string.Empty;
            bool reqIDIsValid = Int64.TryParse(Request.QueryString["IID"], out IID);

            if (IID <= 0)
            {
                MobilePhoneInfo objCompanyName = (from tr in _mobilePhoneInfoRT.GetAllMobilePhoneInfos()
                                          where tr.ModelName == company.ModelName
                                          select tr).SingleOrDefault();
                if (objCompanyName != null)
                {
                    if (objCompanyName.ModelName == company.ModelName)
                    {
                        message = "Model name already exists.";
                    }
                }

          
            }

            return message;
        }

        private MobilePhoneInfo CreateMobilePhoneInfo()
        {
           
            MobilePhoneInfo _MobilePhoneInfo = new MobilePhoneInfo();
            try
            {
                if (string.IsNullOrEmpty(dropdownCompany.SelectedValue))
                {
                    labelMessage.Text = "Please Select Company Name";
                    return null;
                }
                if (string.IsNullOrEmpty(dropDownMPTypeID.SelectedValue))
                {
                    labelMessage.Text = "Please Select Mobile Phone Type";
                    return null;
                }
                if (string.IsNullOrEmpty(dropdownSIMAvailable.SelectedValue))
                {
                    labelMessage.Text = "Please Select Available SIM";
                    return null;
                }
                _MobilePhoneInfo.CompanyInfoID = Convert.ToInt32(dropdownCompany.SelectedValue);
                _MobilePhoneInfo.NetworkProviderID = Convert.ToInt32(dropDownNetworkProvider.SelectedValue);
                _MobilePhoneInfo.MPTypeID = Convert.ToInt32(dropDownMPTypeID.SelectedValue);
                _MobilePhoneInfo.ModelName = txtModelName.Text.Trim();
                _MobilePhoneInfo.SIMAvailableID = Convert.ToInt32(dropdownSIMAvailable.SelectedValue);
                if (txtTotalTalkTime.Text.Trim() != String.Empty)
                {
                    _MobilePhoneInfo.TotalTalkTime =Convert.ToInt32(txtTotalTalkTime.Text.Trim());
                }
                if (txtTotalTxtMsg.Text.Trim() != string.Empty)
                {
                    _MobilePhoneInfo.TotalTextMessage = Convert.ToInt32(txtTotalTxtMsg.Text.Trim());
                }
               _MobilePhoneInfo.WarrantyInfo = txtWarrantyInfo.Text.Trim();
                _MobilePhoneInfo.PostAdDate = GlobalRT.GetServerDateTime();
                DateTime date = GlobalRT.GetServerDateTime();
                if(txtPostVisibilityDay.Text.Trim() !=string.Empty)
                {
                    _MobilePhoneInfo.PostLastDisplayDate = date.AddDays(Convert.ToDouble(txtPostVisibilityDay.Text.Trim() != string.Empty ? txtPostVisibilityDay.Text.Trim() : "10"));
                }
                _MobilePhoneInfo.TalkTimeUnitID = Convert.ToInt32(dropDownTalkTimeUnitID.SelectedValue);
                if (txtTotalUsableData.Text.Trim() != string.Empty)
                {
                    _MobilePhoneInfo.TotalUsableData = Convert.ToDecimal(txtTotalUsableData.Text.Trim()); 
                }
               
                _MobilePhoneInfo.UsableDataUnitID = Convert.ToInt32(dropDownUsableDataUnitID.SelectedValue);
                _MobilePhoneInfo.ConnectionTypeID = Convert.ToInt32(dropDownConnectionTypeID.SelectedValue);
                _MobilePhoneInfo.TotalPrice = Convert.ToDecimal(txtTotalPrice.Text);
                if(txtPostVisibilityDay.Text.Trim() != string.Empty)
                {
                    _MobilePhoneInfo.ContractDuration =  Convert.ToInt32(txtContractDuration.Text.Trim());
                }
                if (txtMonthlyInstallmentAmt.Text.Trim() !=string.Empty)
                {
                    _MobilePhoneInfo.MonthlyInstallmentAmt = Convert.ToDecimal(txtMonthlyInstallmentAmt.Text.Trim());
                }
                _MobilePhoneInfo.RedirectUrl = txtRedirectUrl.Text.Trim();

               

            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return _MobilePhoneInfo;
        }

        private void ClearData()
        {
           // txtMobilePhoneInfoName.Text = string.Empty; 
            txtModelName.Text = string.Empty;
            dropdownSIMAvailable.SelectedValue ="-1";
            dropdownCompany.SelectedIndex = 0;
            dropDownNetworkProvider.SelectedIndex = 0;
            dropDownMPTypeID.SelectedIndex = 0;

            txtTotalTalkTime.Text = string.Empty;
            txtTotalTxtMsg.Text = string.Empty;
            txtWarrantyInfo.Text = string.Empty;
            dropDownTalkTimeUnitID.SelectedValue = "-1";
            txtPostVisibilityDay.Text = string.Empty;
            txtTotalUsableData.Text = string.Empty;
            dropDownUsableDataUnitID.SelectedValue = "-1";
            dropDownConnectionTypeID.SelectedValue = "-1";
            txtTotalPrice.Text = string.Empty;
            txtContractDuration.Text = string.Empty;
            txtRedirectUrl.Text = string.Empty;
            txtMonthlyInstallmentAmt.Text = string.Empty;
            Session[seMPFeatureColl] = null;
            LoadMPFeature();
   
        }
        #endregion private

        #region protected
       

        private string  Upload(string modelName)
        {
            List<ImageUrl> OthrContntPicTempFileUrlList = new List<ImageUrl>();
            ImageUrl imageUrl = new ImageUrl();
            try
            {
                  if (PictureUpload.HasFile)
                  {
                      List<ImageUrl> PicTempFileUrlList = new List<ImageUrl>();
                      foreach (var file in PictureUpload.PostedFiles)
                      {
                          
                          var tempFilename = Path.GetFileName(modelName);

                          if (Session["seTempFileName"] == null)
                          {
                              Session["seTempFileName"] = new List<ImageUrl>();
                          }
                          PicTempFileUrlList = (List<ImageUrl>)Session["seTempFileName"];//read from sess

                        //  ImageUrl imageUrl = new ImageUrl();

                          Session["seLogoTempFileName"] = PicTempFileUrlList;//write to sess

                          PictureUpload.SaveAs(Server.MapPath("~/Images/MobilePhone/") + tempFilename + Path.GetExtension(PictureUpload.FileName));

                          imageUrl.ImageUrlTemp = "~/Images/MobilePhone/" + tempFilename + Path.GetExtension(PictureUpload.FileName);
                          PicTempFileUrlList.Add(imageUrl);
                      }

                  }


            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
         return imageUrl.ImageUrlTemp.ToString();
        }

        protected void btn_CreateOrEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int mobilePhoneID = 0;
                string MobComName = string.Empty;
                //if (!TextControlCheckBeforeSave())
                //{
                //    return;
                //}
                MobilePhoneInfo mobilePhone = CreateMobilePhoneInfo();
                if (mobilePhone == null)
                {
                    return;
                }
                bool reqIDIsValid = Int64.TryParse(Request.QueryString["IID"], out IID);

                ImageUrl imageUrl = new ImageUrl();
                if (PictureUpload.HasFile)
                {
                    string permanentImagePathToSave =Upload(mobilePhone.ModelName).ToString();
                    string permanentImagePath = "~/Images/MobilePhone/" + MobComName + (Path.GetExtension(Server.MapPath(imageUrl.ImageUrlTemp))).ToString();//image path to save db
                    mobilePhone.PictureUrl = permanentImagePathToSave;
                }
                else
                {
                    if (IID>0)
                    {
                        var objMp = _mobilePhoneInfoRT.GetMobilePhoneInfoByIID(IID);
                        if (objMp!=null)
                        {
                          mobilePhone.PictureUrl=  objMp.PictureUrl;
                        }
                    }
                }
                var msg = BusinessLogicValidation(mobilePhone);

                List<MPFeature> MPFeatureColl = (List<MPFeature>)Session[seMPFeatureColl];
                if (Session[seMPFeatureColl] == null)
                {
                    MPFeatureColl = new List<MPFeature>();
                    MPFeature aMPFeature = new MPFeature();
                    aMPFeature.Description = "Feature is not Available.";
                    MPFeatureColl.Add(aMPFeature);
                }
             

               
                if (string.IsNullOrEmpty(msg))
                {

                    if (IID <= 0)
                    {
                        mobilePhone.CreatedBy = Convert.ToInt64(Session["UserID"]);
                        mobilePhone.CreatedDate = DateTime.Now;
                        mobilePhone.IsRemoved = false;

                        // _mobilePhoneInfoRT.AddMobilePhoneInfo(mobilePhone);
                        string mobilePhoneInfoAllChildXML = ConversionXML.ConvertObjectToXML<MobilePhoneInfo, MPFeature>(mobilePhone, MPFeatureColl, string.Empty);
                        mobilePhoneID = MobilePhoneInfoRT.InsertMobilePhoneInfoAndFeatureChildXML(mobilePhoneInfoAllChildXML);

                        if (mobilePhoneID == -100)
                        {
                            labelMessage.Text = "Network connection fail ... Please try again..!!";
                            labelMessage.ForeColor = System.Drawing.Color.Red;
                            labelMessage.Focus();
                        }
                        else if (mobilePhoneID == -101)
                        {
                            labelMessage.Text = "Network connection fail ... Please try again..!!";
                            labelMessage.ForeColor = System.Drawing.Color.Red;
                            labelMessage.Focus();
                        }
                        ClearData();

                        labelMessage.Text = "Information has been inserted successfully.";
                        labelMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        MobilePhoneInfo objMobilePhoneInfo = _mobilePhoneInfoRT.GetMobilePhoneInfoByIID(IID);

                        if (objMobilePhoneInfo != null)
                        {
                            if (mobilePhone.PictureUrl == null)
                            {
                                mobilePhone.PictureUrl = objMobilePhoneInfo.PictureUrl;
                            }
                            mobilePhone.CreatedBy = objMobilePhoneInfo.CreatedBy; ;
                            mobilePhone.CreatedDate = objMobilePhoneInfo.CreatedDate;
                            mobilePhone.IsRemoved = objMobilePhoneInfo.IsRemoved;
                            mobilePhone.IID = objMobilePhoneInfo.IID;

                            mobilePhone.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                            mobilePhone.ModifiedDate = DateTime.Now;

                            //////

                            List<MPFeature> listFT = new List<MPFeature>();
                            if (Session[seMPFeatureColl] != null)
                            {
                                List<MPFeature> featureList = (List<MPFeature>)Session[seMPFeatureColl];

                                foreach (MPFeature feature in featureList)
                                {
                                    MPFeature fe = new MPFeature();
                                    fe.Description = feature.Description;
                                    fe.IsRemoved = false;
                                    fe.CreatedBy = objMobilePhoneInfo.CreatedBy;
                                    fe.CreatedDate = objMobilePhoneInfo.CreatedDate;
                                    fe.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                                    fe.ModifiedDate = DateTime.Now;
                                    listFT.Add(fe);
                                }
                            }

                          
                   

                            /////

                            _mobilePhoneInfoRT.UpdateMobilePhoneInfoAndMPFeature(mobilePhone, listFT);
                            ClearData();

                            Session[seMPFeatureColl] = null;
                          
                            labelMessage.Text = "Information has been updated successfully.";
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
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("MobilePhoneInfoDisplay");
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        #region Feature
        private bool IsValidFeature()
        {
            if (txtDesFeature.Text.Trim().Length <= 0)
            {
                lblMessageFeature.Text = "Pealse give description of feature !!!";
                lblMessageFeature.ForeColor = System.Drawing.Color.Red;
                return true;
            }
            return false;
        }
        protected void btnAddFeature_Click(object sender, EventArgs e)
        {
            try
            {
                List<MPFeature> featureColl = null;
                string description = string.Empty;
                lblMessageFeature.Text = string.Empty;
                if (IsValidFeature())
                {
                    return;
                }
                if (Session[seMPFeatureColl] == null)
                {
                    featureColl = new List<MPFeature>();
                }
                else
                {
                    featureColl = (List<MPFeature>)Session[seMPFeatureColl];
                }
                foreach (MPFeature feature in featureColl)
                {
                    if (feature.Description == txtDesFeature.Text.Trim())
                    {
                        description = "Description";
                        break;
                    }
                }
                if (description == "Description")
                {
                    lblMessageFeature.Text = "Description already exists";
                    lblMessageFeature.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    MPFeature feature = CreateMPFeature();
                    featureColl.Add(feature);
                    Session[seMPFeatureColl] = featureColl;
                    LoadMPFeature();
                    txtDesFeature.Text = string.Empty;
                }
              
                ClearFeature();
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void DisplayFeature(Int64? mpID)
        {
            try
            {
                Session[seMPFeatureColl] = null;
                List<MPFeature> featureList = new List<MPFeature>();
                featureList = _mobilePhoneInfoRT.GetAllFeatureByMPIID(mpID);
                lvFeature.DataSource = featureList;
                Session[seMPFeatureColl] = featureList;
                lvFeature.DataBind();
               
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void ClearFeature()
        {
            txtDesFeature.Text = string.Empty;
        }

        private MPFeature CreateMPFeature()
        {
            Session["UserID"] = "1";
                MPFeature feature = new MPFeature();
                feature.Description = txtDesFeature.Text.Trim().Replace(Environment.NewLine, "<br/>");
                // feature.Description = txtDescription.Text.Trim().Replace(Environment.NewLine, "<br/>");
                feature.CreatedBy = Convert.ToInt64(Session["UserID"]);
                feature.CreatedDate = DateTime.Now;
                feature.IsRemoved = false;
                return feature;
           
           
        }

        private void LoadMPFeature()
        {
            try
            {
                lvFeature.DataSource = (List<MPFeature>)Session[seMPFeatureColl];
                lvFeature.DataBind();
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void lvFeature_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            try
            {
                lblMessageFeature.Text = string.Empty;
                if (e.CommandName.Equals("DeleteInfo"))
                {
                    if (Session[seMPFeatureColl] != null)
                    {
                        List<MPFeature> mpFeatureColl = (List<MPFeature>)Session[seMPFeatureColl];
                        mpFeatureColl.RemoveAll(fe => fe.Description.Equals(e.CommandArgument));
                        Session[seMPFeatureColl] = mpFeatureColl;
                        LoadMPFeature();
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
                    LoadMPFeature();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void lvFeature_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            labelMessage.Text = string.Empty;
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void lvFeature_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    LoadMPFeature();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        #endregion feature

        #endregion protected
        public class ImageUrl
        {
            public string ImageUrlPer { get; set; }
            public string ImageUrlTemp { get; set; }
        }

    }
}