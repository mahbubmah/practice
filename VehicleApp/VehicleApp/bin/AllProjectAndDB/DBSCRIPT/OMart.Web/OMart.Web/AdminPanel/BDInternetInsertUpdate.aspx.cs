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
using System.Drawing;




using Microsoft.Ajax.Utilities;
using System.Configuration;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;
using System.Data.SqlClient;
using OMart.Web.AdminPanel.CrystalReports;
using System.Collections;


namespace OMart.Web.AdminPanel
{
    public partial class BDInternetInsertUpdate : System.Web.UI.Page
    {
        private readonly BDInternetRT _BDInternetRT;
        private long IID = default(Int64);
        private bool IsUpdate = false;//for set the chkbox status in update
        public BDInternetInsertUpdate()
        {
            _BDInternetRT = new BDInternetRT();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadChannelInfoList();
                    LoadDropDownForProvider();
                    LoadDropDownForType();
                    LoadDropDownForNetSpeedID();
                    LoadDropDownForDownloadSpeedID();
                    LoadDropDownForNetGenerationID();
                    LoadDropDownForChargeType();
                    LoadddlContractChargeType();
                    var requestId = Request.QueryString["IID"];
                    bool reqIDIsValid = Int64.TryParse(requestId, out IID);
                    if (reqIDIsValid)
                    {
                        ShowBDInternetData();
                    }
                    //btnPrint.Visible = false;//
                }
            }
            catch (Exception ex)
            {

                labelMessage.Text = "Error: " + ex.Message;
                labelMessage.ForeColor = Color.Red;
            }

        }

        private void LoadDropDownForChargeType()
        {
            try
            {
                    DropDownChargeTypeID.Items.Add(new ListItem("Select Charged Type ", "-1"));
                    foreach (Utilities.EnumCollection.PremiumPolicy r in Enum.GetValues(typeof(Utilities.EnumCollection.PremiumPolicy)))
                    {
                        ListItem item = new ListItem(Enum.GetName(typeof(Utilities.EnumCollection.PremiumPolicy), r), r.ToString());
                        DropDownChargeTypeID.Items.Add(item);
                    }

                
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error: " + ex.Message;
                labelMessage.ForeColor = Color.Red;
            }
        }

        private void LoadDropDownForProvider()
        {
            try
            {
                using (CompanyInfoRT aCompanyInfoRt = new CompanyInfoRT())
                {
                    var companyList = aCompanyInfoRt.GetAllBroadBandCompanyForDropDown();
                    DropDownListHelper.Bind(DropDownProviderID, companyList, "Name", "IID", EnumCollection.ListItemType.CompanyInfo);
                }

            }
            catch (Exception ex)
            {

                labelMessage.Text = "Error: " + ex.Message;
                labelMessage.ForeColor = Color.Red;
            }
        }

        private void LoadDropDownForType()
        {

            try
            {
                var list = EnumHelper.EnumCamelSpaceToList<EnumCollection.Type>();
                DropDownListHelper.Bind(DropDownType, list, EnumCollection.ListItemType.BroadBandType);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }            
            //try
            //{
            //    {
            //        DropDownType.Items.Add(new ListItem("Select Type ", "-1"));
            //        foreach (Utilities.EnumCollection.Type r in Enum.GetValues(typeof(Utilities.EnumCollection.Type)))
            //        {
            //           ListItem item = new ListItem(Enum.GetName(typeof(Utilities.EnumCollection.Type), r), r.ToString());
            //            DropDownType.Items.Add(item);
                        
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message, ex);
            //}
        }
        private void LoadddlContractChargeType()
        {
            try
            {


                {
                    ddlContractChargeType.Items.Add(new ListItem("Select Type ", "-1"));
                    foreach (Utilities.EnumCollection.Type r in Enum.GetValues(typeof(Utilities.EnumCollection.PremiumPolicy)))
                    {
                        ListItem item = new ListItem(Enum.GetName(typeof(Utilities.EnumCollection.PremiumPolicy), r), r.ToString());
                        ddlContractChargeType.Items.Add(item);

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        private void LoadDropDownForNetSpeedID()
        {
            try
            {


                {
                    DropDownNetSpeedUnitID.Items.Add(new ListItem("Select Net Speed Unit ID ", "-1"));
                    foreach (Utilities.EnumCollection.UsableDataUnit r in Enum.GetValues(typeof(Utilities.EnumCollection.UsableDataUnit)))
                    {
                        ListItem item = new ListItem(Enum.GetName(typeof(Utilities.EnumCollection.UsableDataUnit), r), r.ToString());
                        DropDownNetSpeedUnitID.Items.Add(item);
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private void LoadDropDownForDownloadSpeedID()
        {
            try
            {


                {
                    DropDownDownloadSpeedUnitID.Items.Add(new ListItem("Select Download Speed Type ", "-1"));
                    foreach (Utilities.EnumCollection.UsableDataUnit r in Enum.GetValues(typeof(Utilities.EnumCollection.UsableDataUnit)))
                    {
                        ListItem item = new ListItem(Enum.GetName(typeof(Utilities.EnumCollection.UsableDataUnit), r), r.ToString());
                        DropDownDownloadSpeedUnitID.Items.Add(item);
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private void LoadDropDownForNetGenerationID()
        {

            try
            {
                var list = EnumHelper.EnumCamelSpaceToList<EnumCollection.ConnectionType>();
                DropDownListHelper.Bind(DropDownNetGenerationID, list, EnumCollection.ListItemType.NetGenerationType);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }   
            //try
            //{


            //    {
            //        DropDownNetGenerationID.Items.Add(new ListItem("Select Net Generation Type ", "-1"));
            //        foreach (Utilities.EnumCollection.ConnectionType r in Enum.GetValues(typeof(Utilities.EnumCollection.ConnectionType)))
            //        {
            //           ListItem item = new ListItem(Enum.GetName(typeof(Utilities.EnumCollection.ConnectionType), r), r.ToString());
            //            DropDownNetGenerationID.Items.Add(item);
            //        }

            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message, ex);
            //}
        }
        private void LoadChannelInfoList()
        {
            try
            {
                var gasDealerListByCompanyIid = _BDInternetRT.GetAllBDChannelInfo();
                lvChannel.DataSource = gasDealerListByCompanyIid;
                lvChannel.DataBind();
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error: " + ex.Message;
                labelMessage.ForeColor = Color.Red;
            }

        }
        private void ShowBDInternetData()
        {
            try
            {
                BDInternet BDInternet = _BDInternetRT.GetBDInternetByIID(IID);
                if (BDInternet != null)
                {
                    txtChargeAmount.Text = BDInternet.ChargeAmount.ToString();
                    txtChargeTypeNote.Text = BDInternet.ChargeTypeNote;
                    txtDataAmount.Text = BDInternet.DataAmount.ToString();
                    txtDownloadSpeed.Text = BDInternet.DownloadSpeed.ToString();
                    txtRedirectUrl.Text = BDInternet.RedirectUrl;
                    txtNetSpeed.Text = BDInternet.NetSpeed.ToString();
                    txtPackageName.Text = BDInternet.PackageName.ToString();
                    txtTotalChannelNo.Text = BDInternet.TotalChannelNo.ToString();
                    txtContractDuration.Text = BDInternet.ContractDuration.ToString();// Hasan Add 2015.05.12 //
                    txtContractNote.Text = BDInternet.ContractNote;//
                    ddlContractChargeType.SelectedValue = Enum.GetName(typeof(Utilities.EnumCollection.PremiumPolicy), BDInternet.ChargeTypeID);//
                    DropDownChargeTypeID.SelectedValue = Enum.GetName(typeof(Utilities.EnumCollection.PremiumPolicy), BDInternet.ChargeTypeID);
                    DropDownNetGenerationID.SelectedValue = Enum.GetName(typeof(Utilities.EnumCollection.ConnectionType), BDInternet.NetGenerationID);
                    DropDownType.SelectedValue = Enum.GetName(typeof(Utilities.EnumCollection.Type), BDInternet.TypeID);
                    DropDownNetSpeedUnitID.SelectedValue = Enum.GetName(typeof(Utilities.EnumCollection.UsableDataUnit), BDInternet.NetSpeedUnitID);
                    DropDownDownloadSpeedUnitID.SelectedValue = Enum.GetName(typeof(Utilities.EnumCollection.UsableDataUnit), BDInternet.DownloadSpeedUnitID);
                    
                    DropDownProviderID.SelectedValue = BDInternet.ProviderID.ToString();
                    IsUpdate = true;//for set the chkbox status
                    chkIsRemoved.Checked = BDInternet.IsRemoved;
                    LoadAllChannelInfo();
                }
            }
            catch (Exception ex)
            {

                labelMessage.Text = "Error: " + ex.Message;
                labelMessage.ForeColor = Color.Red;
            }
        }

        
        private void LoadAllChannelInfo()
        {
            try
            {

                var ChannelListByCompanyIid = _BDInternetRT.GetAllBDChannelInfo();
                lvChannel.DataSource = ChannelListByCompanyIid;
                lvChannel.DataBind();
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error: " + ex.Message;
                labelMessage.ForeColor = Color.Red;
            }

        }

        protected void lvlvChannel_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {

        }

        protected void dataPagerChannel_PreRender(object sender, EventArgs e)
        {

        }

       

        protected void btnCreateOrEdit_Click(object sender, EventArgs e)
        {
            try
            {
                BDInternet BDInternet = CreateBDInternet();
                bool reqIDIsValid = Int64.TryParse(Request.QueryString["IID"], out IID);
                var msg = BusinessLogicValidationForBDInternet(BDInternet);
                if (msg.IsNullOrWhiteSpace())
                {

                    string BDInternetImageName = string.Empty;
                    string path = Server.MapPath("~/All Photos/Broadband/");
                    if (IID > 0)
                    {
                        BDInternetImageName = IID.ToString();
                    }
                    else
                    {
                        var BDInternetLast = _BDInternetRT.GetBDInternetLast();
                        if (BDInternetLast != null)
                        {
                            BDInternetImageName = (BDInternetLast.IID + 1).ToString();
                        }
                        else
                            BDInternetImageName = "1" ;
                    }
                    if (FileUploadImage.HasFile)
                    {
                        BDInternet.PackageImageUrl = "~/All Photos/Broadband/" + BDInternetImageName + Path.GetExtension(FileUploadImage.FileName);
                    }

                    var BDInternetAndChannelMappingColl = new List<BDInternetAndChannelMapping>();
                    List<BDInternetAndChannelMapping> BDInternetAndChannelMappingList = CreateBDInternetAndChannelMappingList();
                    if (IID <= 0)
                    {


                        if (BDInternetAndChannelMappingList.Count > 0)
                        {
                            BDInternetAndChannelMappingColl = BDInternetAndChannelMappingList;
                        }

                        string BDInternetAndAllChildBDInternetAndChannelMappingXml = ConversionXML.ConvertObjectToXML<BDInternet, BDInternetAndChannelMapping>(BDInternet, BDInternetAndChannelMappingColl, string.Empty);

                        int BDInternetId = BDInternetRT.InsertBDInternetAndFeatureChildXML(BDInternetAndAllChildBDInternetAndChannelMappingXml);

                        if (BDInternetId > 0)
                        {
                            FileUploadHelper.BindImage(FileUploadImage, path, BDInternetImageName);
                            ClearData();
                            labelMessage.Text = "Information has been inserted successfully.";
                            labelMessage.ForeColor = System.Drawing.Color.Green;
                            hdBDInternetID.Value= _BDInternetRT.GetLastIIDOfBDIngernet().ToString() ; /* Getting the IID of BDInternet*/
                            btnPrint.Enabled = true; //

                        }
                        else if (BDInternetId == -100)
                        {
                            labelMessage.Text = "Network connection fail ... Please try again..!!";
                            labelMessage.ForeColor = System.Drawing.Color.Red;
                            labelMessage.Focus();
                        }
                        else if (BDInternetId == -101)
                        {
                            labelMessage.Text = "Network connection fail ... Please try again..!!";
                            labelMessage.ForeColor = System.Drawing.Color.Red;
                            labelMessage.Focus();
                        }
                        else
                        {
                            labelMessage.Text = "Error";
                            labelMessage.ForeColor = System.Drawing.Color.Red;
                            labelMessage.Focus();
                        }
                    }
                    else
                    {
                        try
                        {
                            bool isBDInternetExist = _BDInternetRT.GetBDInternetByIID(IID) != null;
                            if (isBDInternetExist)
                            {
                                BDInternet.IID = IID;
                                _BDInternetRT.UpdateBDinternet(BDInternet);
                                foreach (var BDInternetAndChannelMapping in BDInternetAndChannelMappingList)
                                {
                                    BDInternetAndChannelMapping.BDInternetID = IID;
                                    _BDInternetRT.AddBDinternetAndChannelInfoMapping(BDInternetAndChannelMapping);
                                }
                            }
                            ClearData();
                            labelMessage.Text = "Information has been Updated successfully.";
                            labelMessage.ForeColor = System.Drawing.Color.Green;
                        }
                        catch (Exception ex)
                        {
                            labelMessage.Text = "Error: " + ex.Message;
                            labelMessage.ForeColor = Color.Red;
                        }
                    }
                }
                else
                {
                    labelMessage.Text = msg;
                    labelMessage.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error: " + ex.Message;
                labelMessage.ForeColor = Color.Red;
            }
        }

        private void ClearData()
        {

            txtChargeAmount.Text = string.Empty;
            txtChargeTypeNote.Text = string.Empty;
            txtDataAmount.Text = string.Empty;
            txtDownloadSpeed.Text = string.Empty;
            txtRedirectUrl.Text = string.Empty;
            txtNetSpeed.Text = string.Empty;
            txtPackageName.Text = string.Empty;
            txtTotalChannelNo.Text = string.Empty;
            DropDownChargeTypeID.SelectedIndex = -1 ;
            DropDownNetGenerationID.SelectedIndex = -1;
            DropDownType.SelectedIndex = -1;
            DropDownNetSpeedUnitID.SelectedIndex =-1;
            DropDownDownloadSpeedUnitID.SelectedIndex = -1;
            DropDownProviderID.SelectedIndex = -1;
            chkIsRemoved.Checked = false;
            IsUpdate = true;//for set the chkbox status
            LoadAllChannelInfo();
            lvChannel.Items.Clear();
            lvChannel.DataBind();

            txtContractDuration.Text = string.Empty;
            txtContractNote.Text = string.Empty;
            ddlContractChargeType.SelectedIndex = -1;
        }

        private List<BDInternetAndChannelMapping> CreateBDInternetAndChannelMappingList()
        {
            try
            {
                List<BDInternetAndChannelMapping> BDInternetAndChannelMappingList = new List<BDInternetAndChannelMapping>();
                bool reqIDIsValid = Int64.TryParse(Request.QueryString["IID"], out IID);
                foreach (ListViewItem item in lvChannel.Items)
                {
                    BDInternetAndChannelMapping aBDInternetAndChannelMapping = new BDInternetAndChannelMapping();
                    HiddenField objHdChannelId = item.FindControl("hdChannelId") as HiddenField;
                    bool isMappingExist = _BDInternetRT.IsMappingExist(IID, Convert.ToInt32(objHdChannelId.Value));
                    aBDInternetAndChannelMapping.BDChannelInfoID = Convert.ToInt32(objHdChannelId.Value);
                    if (isMappingExist)
                    {
                        BDInternetAndChannelMapping mapping = _BDInternetRT.GetMappingByBDInternetAndChannelId(IID, aBDInternetAndChannelMapping.BDChannelInfoID);
                        aBDInternetAndChannelMapping.CreatedBy = mapping.CreatedBy;
                        aBDInternetAndChannelMapping.CreatedDate = mapping.CreatedDate;
                        aBDInternetAndChannelMapping.IID = mapping.IID;
                        aBDInternetAndChannelMapping.BDInternetID = IID;
                    }
                    if ((item.FindControl("chkItem") as CheckBox).Checked)
                    {
                        aBDInternetAndChannelMapping.IsRemoved = false;
                        if (isMappingExist)
                        {
                            aBDInternetAndChannelMapping.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                            aBDInternetAndChannelMapping.ModifiedDate = GlobalRT.GetServerDateTime();
                            _BDInternetRT.UpdateBDInternetAndChannelMapping(aBDInternetAndChannelMapping);
                        }
                        else
                        {
                            aBDInternetAndChannelMapping.CreatedBy = Convert.ToInt64(Session["UserID"]);
                            aBDInternetAndChannelMapping.CreatedDate = GlobalRT.GetServerDateTime();
                            BDInternetAndChannelMappingList.Add(aBDInternetAndChannelMapping);
                        }
                    }
                    else
                    {
                        if (isMappingExist)
                        {
                            aBDInternetAndChannelMapping.IsRemoved = true;
                            aBDInternetAndChannelMapping.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                            aBDInternetAndChannelMapping.ModifiedDate = GlobalRT.GetServerDateTime();
                            _BDInternetRT.UpdateBDInternetAndChannelMapping(aBDInternetAndChannelMapping);
                        }
                    }
                }
                return BDInternetAndChannelMappingList;
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error: " + ex.Message;
                labelMessage.ForeColor = Color.Red;
            }
            return null;
        }

        private string BusinessLogicValidationForBDInternet(BDInternet BDInternet)
        {
            string msg = string.Empty;
            try
            {
                //if (txtWeightOfGas.Text.IsNullOrWhiteSpace())
                //{
                //    msg = "Please enter the weight of gas";
                //    return msg;
                //}
                //if (txtWeightOfContainer.Text.IsNullOrWhiteSpace())
                //{
                //    msg = "Please enter the weight of container";
                //    return msg;
                //}
                //if (txtRetailPrice.Text.IsNullOrWhiteSpace())
                //{
                //    msg = "Please enter price";
                //}
                //if (dropDownCompanyInfo.SelectedValue.IsNullOrWhiteSpace() || dropDownCompanyInfo.SelectedValue == "-1")
                //{
                //    msg = "Please select company";
                //    return msg;
                //}

            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error: " + ex.Message;
                labelMessage.ForeColor = Color.Red;
            }
            return msg;
        }

        private BDInternet CreateBDInternet()
        {
            try
            {
                BDInternet bDInternet = new BDInternet();

                bDInternet.ChargeAmount = Convert.ToDecimal( txtChargeAmount.Text );
                bDInternet.ChargeTypeNote = txtChargeTypeNote.Text ;
                bDInternet.DataAmount = txtDataAmount.Text ;
                bDInternet.DownloadSpeed = Convert.ToInt32( txtDownloadSpeed.Text );
                bDInternet.RedirectUrl = txtRedirectUrl.Text ;
                bDInternet.NetSpeed = Convert.ToInt32( txtNetSpeed.Text );
                bDInternet.PackageName = txtPackageName.Text;
                bDInternet.TotalChannelNo = Convert.ToInt32( txtTotalChannelNo.Text );
                bDInternet.ContractDuration = Convert.ToInt32 (txtContractDuration.Text);// Hasan Add 2015.05.12
                bDInternet.ContractNote = txtContractNote.Text; //
                bDInternet.ContractTypeID = (Int32)Enum.Parse(typeof(Utilities.EnumCollection.PremiumPolicy), DropDownChargeTypeID.SelectedValue.ToString());//
                bDInternet.ChargeTypeID = (Int32)Enum.Parse(typeof(Utilities.EnumCollection.PremiumPolicy), DropDownChargeTypeID.SelectedValue.ToString());
                bDInternet.NetGenerationID = (Int32)Enum.Parse(typeof(Utilities.EnumCollection.ConnectionType), DropDownNetGenerationID.SelectedValue.ToString()); 
                bDInternet.TypeID = (Int32)Enum.Parse(typeof(Utilities.EnumCollection.Type), DropDownType.SelectedValue.ToString()); 
                bDInternet.NetSpeedUnitID = (Int32)Enum.Parse(typeof(Utilities.EnumCollection.UsableDataUnit), DropDownNetSpeedUnitID.SelectedValue.ToString()); 
                bDInternet.DownloadSpeedUnitID = (Int32)Enum.Parse(typeof(Utilities.EnumCollection.UsableDataUnit), DropDownDownloadSpeedUnitID.SelectedValue.ToString()); 
                bDInternet.ProviderID = Convert.ToInt32( DropDownProviderID.SelectedValue );
                bDInternet.IsRemoved = chkIsRemoved.Checked;
                IsUpdate = true;//for set the chkbox status
               // LoadAllChannelInfo();

                if (IID <= 0)
                {
                    bDInternet.CreatedBy = Convert.ToInt64(Session["UserID"]);
                    bDInternet.CreatedDate = GlobalRT.GetServerDateTime();
                }
                else
                {
                    bDInternet.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                    bDInternet.ModifiedDate = GlobalRT.GetServerDateTime();
                }
                return bDInternet;
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error: " + ex.Message;
                labelMessage.ForeColor = Color.Red;
            }
            return null;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/AdminPanel/BDInternetView");
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lvChannel_OnItemDataBound(object sender, ListViewItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListViewItemType.DataItem)
                {
                    CheckBox objCheckBox = e.Item.FindControl("chkItem") as CheckBox;
                    objCheckBox.InputAttributes.Add("class", "childChkBox");

                    if (IsUpdate)
                    {
                        HiddenField objHdChannelId = e.Item.FindControl("hdChannelId") as HiddenField;
                        var ChannelList = _BDInternetRT.GetBDInternetAndChannelId(IID);
                        foreach (var Channel in ChannelList)
                        {
                            if (Channel.BDChannelInfoID == Convert.ToInt32(objHdChannelId.Value))
                            {
                                objCheckBox.Checked = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                labelMessage.Text = "Error: " + ex.Message;
                labelMessage.ForeColor = Color.Red;
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {

                if(Convert.ToInt32 (!string.IsNullOrEmpty(hdBDInternetID.Value))>0)
                {
                    List<string> parameterName = new List<string>();
                    List<string> parameterValue = new List<string>();

                    string reportPathe = "\\AdminPanel\\CrystalReports\\RPTBDInternet.rpt";
                    Session["ReportPath"] = reportPathe;

                    parameterName.Add("BDInternetIID");
                    parameterValue.Add(hdBDInternetID.Value);
                    Session["ParamName"] = parameterName;
                    Session["ParamValue"] = parameterValue;
                    Response.Redirect("DefaultReportViewer.aspx", false);
                    hdBDInternetID.Value = string.Empty;
                }
                else
                {
                    string script = "alert('You do not save any BDInternet Data Currently');";
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(btnPrint, this.GetType(), "Test", script, true);                    
                }

            }
            catch (Exception ex)
            {

                labelMessage.Text = "Error: " + ex.Message;
                labelMessage.ForeColor = Color.Red;
            }
        }
    }
}