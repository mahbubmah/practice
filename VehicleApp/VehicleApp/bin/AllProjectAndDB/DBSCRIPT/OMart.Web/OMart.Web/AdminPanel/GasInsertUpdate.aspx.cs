using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Basic;
using DAL;
using Microsoft.Ajax.Utilities;
using Utilities;

namespace OMart.Web.AdminPanel
{
    public partial class GasInsertUpdate : System.Web.UI.Page
    {
        private readonly GasRT _gasRt;
        private long IID = default(Int64);
        private bool IsUpdate = false;//for set the chkbox status in update
        public GasInsertUpdate()
        {
            _gasRt=new GasRT();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadDropDownForCompany();
                    LoadGasDealerInfoByCompanyId(0);
                    var requestId = Request.QueryString["IID"];
                    bool reqIDIsValid = Int64.TryParse(requestId, out IID);
                    if (reqIDIsValid)
                    {
                        ShowGasCylienderData();
                    }
                }
            }
            catch (Exception ex)
            {

                labelMessage.Text = "Error: " + ex.Message;
                labelMessage.ForeColor = Color.Red;
            }
           
        }

        private void ShowGasCylienderData()
        {
            try
            {
                GasCyliender gasCyliender = _gasRt.GetGasCylienderByIid(IID);
                if (gasCyliender!=null)
                {
                    txtRetailPrice.Text = gasCyliender.RetailPrice.ToString();
                    txtAreaInfo.Text = gasCyliender.AreaInfo;
                    txtPriceNote.Text = gasCyliender.RetailPrice.ToString();
                    txtPriceNote.Text = gasCyliender.PriceNote;
                    txtRedirectUrl.Text = gasCyliender.RedirectUrl;
                    txtWeightOfContainer.Text = gasCyliender.WeightOfContainer.ToString();
                    txtWeightOfGas.Text = gasCyliender.WeightOfGas.ToString();
                    dropDownCompanyInfo.SelectedValue = gasCyliender.CompanyInfoID.ToString();
                    IsUpdate = true;//for set the chkbox status
                    LoadGasDealerInfoByCompanyId(gasCyliender.CompanyInfoID);
                }
            }
            catch (Exception ex)
            {

                labelMessage.Text = "Error: " + ex.Message;
                labelMessage.ForeColor = Color.Red;
            }
        }

        private void LoadDropDownForCompany()
        {
            try
            {
                using (CompanyInfoRT aCompanyInfoRt=new CompanyInfoRT())
                {
                    var companyList = aCompanyInfoRt.GetAllEnergyCompanyForDropDown();
                    DropDownListHelper.Bind(dropDownCompanyInfo,companyList,"Name","IID",EnumCollection.ListItemType.CompanyInfo);
                }
                
            }
            catch (Exception ex)
            {

                labelMessage.Text = "Error: " + ex.Message;
                labelMessage.ForeColor = Color.Red;
            }
        }

        private void LoadGasDealerInfoByCompanyId(int companyIid)
        {
            try
            {
                var gasDealerListByCompanyIid = _gasRt.GetGasDealerListByCompanyIid(companyIid);
                lvGasDealer.DataSource = gasDealerListByCompanyIid;
                lvGasDealer.DataBind();
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error: " + ex.Message;
                labelMessage.ForeColor=Color.Red;
            }
         
        }

        protected void lvlvGasDealer_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
                
        }

        protected void dataPagerGasDealer_PreRender(object sender, EventArgs e)
        {
                
        }

        protected void dropDownCompanyInfo_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadGasDealerInfoByCompanyId(Convert.ToInt32(dropDownCompanyInfo.SelectedValue));
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error: " + ex.Message;
                labelMessage.ForeColor = Color.Red;
            }
            
        }

        protected void btnCreateOrEdit_Click(object sender, EventArgs e)
        {
            try
            {
                bool reqIDIsValid = Int64.TryParse(Request.QueryString["IID"], out IID);
                GasCyliender gasCyliender = CreateGasCyliender();
              
                var msg = BusinessLogicValidationForGasCyliender(gasCyliender);
                if (msg.IsNullOrWhiteSpace())
                {


                    string gasCylienderImageName = string.Empty;
                    string path = Server.MapPath("~/All Photos/Energy/Gas/Cyliender/");
                    if (IID > 0)
                    {
                        gasCylienderImageName = IID.ToString();
                    }
                    else
                    {
                        var gasCylienderLast = _gasRt.GetGasCylienderLast();
                        if (gasCylienderLast != null)
                        {
                            gasCylienderImageName = (gasCylienderLast.IID + 1).ToString();
                        }
                        else
                        {
                            gasCylienderImageName = "1";
                        }
                    }
                    if (fuGasCyliender.HasFile)
                    {
                        gasCyliender.ImageUrl = "~/All Photos/Energy/Gas/Cyliender/" + gasCylienderImageName + Path.GetExtension(fuGasCyliender.FileName);
                    }

                    var gasCylinderAndDealerInfoMappingColl = new List<GasCylinderAndDealerInfoMapping>();
                    List<GasCylinderAndDealerInfoMapping> gasCylinderAndDealerInfoMappingList = CreateGasCylinderAndDealerInfoMappingList();
                    if (IID<=0)
                    {
                        

                        if (gasCylinderAndDealerInfoMappingList.Count > 0)
                        {
                            gasCylinderAndDealerInfoMappingColl = gasCylinderAndDealerInfoMappingList;
                        }

                        string gasCylienderAndAllChildGasCylinderAndDealerInfoMappingXml = ConversionXML.ConvertObjectToXML<GasCyliender, GasCylinderAndDealerInfoMapping>(gasCyliender, gasCylinderAndDealerInfoMappingColl, string.Empty);

                        int gasCylienderId = GasRT.InsertGasCylienderAndAllChildGasCylinderAndDealerInfoMappingXml(gasCylienderAndAllChildGasCylinderAndDealerInfoMappingXml);

                        if (gasCylienderId > 0)
                        {
                            if (fuGasCyliender.HasFile)
                            {
                                FileUploadHelper.BindImage(fuGasCyliender, path, gasCylienderImageName);
                            }
                           
                            ClearData();
                            labelMessage.Text = "Information has been inserted successfully.";
                            labelMessage.ForeColor = System.Drawing.Color.Green;
                        }
                        else if (gasCylienderId == -100)
                        {
                            labelMessage.Text = "Network connection fail ... Please try again..!!";
                            labelMessage.ForeColor = System.Drawing.Color.Red;
                            labelMessage.Focus();
                        }
                        else if (gasCylienderId == -101)
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
                        bool isGasCylienderExist = _gasRt.GetGasCylienderByIid(IID) != null;
                        if (isGasCylienderExist)
                        {
                            gasCyliender.IID = IID;
                            _gasRt.UpdateGasCylinder(gasCyliender);
                            if (fuGasCyliender.HasFile)
                            {
                                FileUploadHelper.BindImage(fuGasCyliender, path, gasCylienderImageName);
                            }
                            foreach (var gasCylinderAndDealerInfoMapping in gasCylinderAndDealerInfoMappingList)
                            {
                                gasCylinderAndDealerInfoMapping.GasCylinderID = IID;
                                _gasRt.AddGasCylinderAndDealerInfoMapping(gasCylinderAndDealerInfoMapping);
                            }
                            ClearData();
                            labelMessage.Text = "Information has been updated successfully.";
                            labelMessage.ForeColor = Color.Green;
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
            txtAreaInfo.Text = string.Empty;
            txtPriceNote.Text = string.Empty;
            txtRedirectUrl.Text = string.Empty;
            txtRetailPrice.Text = string.Empty;
            txtWeightOfContainer.Text = string.Empty;
            txtWeightOfGas.Text = string.Empty;
            dropDownCompanyInfo.SelectedValue = "-1";
            lvGasDealer.Items.Clear();
            lvGasDealer.DataBind();
        }

        private List<GasCylinderAndDealerInfoMapping> CreateGasCylinderAndDealerInfoMappingList()
        {
            try
            {
                List<GasCylinderAndDealerInfoMapping> gasCylinderAndDealerInfoMappingList = new List<GasCylinderAndDealerInfoMapping>();
                bool reqIDIsValid = Int64.TryParse(Request.QueryString["IID"], out IID);
                foreach (ListViewItem item in lvGasDealer.Items)
                {
                    GasCylinderAndDealerInfoMapping aGasCylinderAndDealerInfoMapping = new GasCylinderAndDealerInfoMapping();
                    HiddenField objHdGasDealerId = item.FindControl("hdGasDealerId") as HiddenField;
                    bool isMappingExist = _gasRt.IsMappingExist(IID, Convert.ToInt32(objHdGasDealerId.Value));
                    aGasCylinderAndDealerInfoMapping.GasDealerInfoID = Convert.ToInt32(objHdGasDealerId.Value);
                    if (isMappingExist)
                    {
                        GasCylinderAndDealerInfoMapping mapping = _gasRt.GetMappingByCylienderIdAndDealerId(IID,aGasCylinderAndDealerInfoMapping.GasDealerInfoID);
                        aGasCylinderAndDealerInfoMapping.CreatedBy = mapping.CreatedBy;
                        aGasCylinderAndDealerInfoMapping.CreatedDate = mapping.CreatedDate;
                        aGasCylinderAndDealerInfoMapping.IID = mapping.IID;
                        aGasCylinderAndDealerInfoMapping.GasCylinderID = IID;
                    }
                    if ((item.FindControl("chkItem") as CheckBox).Checked)
                    {
                        aGasCylinderAndDealerInfoMapping.IsRemoved = false;
                        if (isMappingExist)
                        {
                            aGasCylinderAndDealerInfoMapping.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                            aGasCylinderAndDealerInfoMapping.ModifiedDate = GlobalRT.GetServerDateTime();
                            _gasRt.UpdateGasCylinderAndDealerInfoMapping(aGasCylinderAndDealerInfoMapping);
                        }
                        else
                        {
                            aGasCylinderAndDealerInfoMapping.CreatedBy = Convert.ToInt64(Session["UserID"]);
                            aGasCylinderAndDealerInfoMapping.CreatedDate = GlobalRT.GetServerDateTime();
                            gasCylinderAndDealerInfoMappingList.Add(aGasCylinderAndDealerInfoMapping);
                        }
                    }
                    else
                    {
                        if (isMappingExist)
                        {
                            aGasCylinderAndDealerInfoMapping.IsRemoved = true;
                            aGasCylinderAndDealerInfoMapping.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                            aGasCylinderAndDealerInfoMapping.ModifiedDate = GlobalRT.GetServerDateTime();
                            _gasRt.UpdateGasCylinderAndDealerInfoMapping(aGasCylinderAndDealerInfoMapping);
                        }
                    }
                }
                return gasCylinderAndDealerInfoMappingList;
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error: " + ex.Message;
                labelMessage.ForeColor = Color.Red;
            }
            return null;
        }

        private string BusinessLogicValidationForGasCyliender(GasCyliender gasCyliender)
        {
            string msg = string.Empty;
            try
            {
                if (txtWeightOfGas.Text.IsNullOrWhiteSpace())
                {
                    msg = "Please enter the weight of gas";
                    return msg;
                }
                if (txtWeightOfContainer.Text.IsNullOrWhiteSpace())
                {
                    msg = "Please enter the weight of container";
                    return msg;
                }
                if (txtRetailPrice.Text.IsNullOrWhiteSpace())
                {
                    msg = "Please enter price";
                }
                if (dropDownCompanyInfo.SelectedValue.IsNullOrWhiteSpace()||dropDownCompanyInfo.SelectedValue=="-1")
                {
                    msg = "Please select company";
                    return msg;
                }

            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error: " + ex.Message;
                labelMessage.ForeColor = Color.Red;
            }
            return msg;
        }

        private GasCyliender CreateGasCyliender()
        {
            try
            {
               GasCyliender gasCyliender=new GasCyliender();

                if (IID>0)
                {
                    var gasCylienderByIId = _gasRt.GetGasCylienderByIid(IID);
                    if (gasCylienderByIId != null)
                    {
                        gasCyliender = gasCylienderByIId;
                    }
                }
              


                
                
             

                gasCyliender.AreaInfo = txtAreaInfo.Text;
                gasCyliender.CompanyInfoID = Convert.ToInt32(dropDownCompanyInfo.SelectedValue);
                gasCyliender.IsRemoved = false;
                gasCyliender.WeightOfGas = Convert.ToDouble(txtWeightOfGas.Text);
                gasCyliender.WeightOfContainer = Convert.ToDouble(txtWeightOfContainer.Text);
                gasCyliender.RetailPrice = Convert.ToDecimal(txtRetailPrice.Text);
                gasCyliender.PriceNote = txtPriceNote.Text;
                gasCyliender.RedirectUrl = txtRedirectUrl.Text;
                if (IID<=0)
                {
                    gasCyliender.CreatedBy = Convert.ToInt64(Session["UserID"]);
                    gasCyliender.CreatedDate = GlobalRT.GetServerDateTime();
                }
                else
                {
                    gasCyliender.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                    gasCyliender.ModifiedDate =GlobalRT.GetServerDateTime();
                }
               return gasCyliender;
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
                Response.Redirect("GasCylienderDisplay");
            }
            catch (Exception ex)
            {

                labelMessage.Text = "Error: " + ex.Message;
                labelMessage.ForeColor = Color.Red;
            }
        }

        protected void lvGasDealer_OnItemDataBound(object sender, ListViewItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListViewItemType.DataItem)
                {
                    CheckBox objCheckBox = e.Item.FindControl("chkItem") as CheckBox;
                    objCheckBox.InputAttributes.Add("class", "childChkBox");

                    if (IsUpdate)
                    {
                        HiddenField objHdGasDealerId = e.Item.FindControl("hdGasDealerId") as HiddenField;
                        var gasDealerList = _gasRt.GetGasDealerListByCylienderId(IID);
                        foreach (var gasDealer in gasDealerList)
                        {
                            if (gasDealer.GasDealerInfoID == Convert.ToInt32(objHdGasDealerId.Value))
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
    }
}