using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;
using BLL.Basic;
using DAL.Basic;
using Microsoft.Ajax.Utilities;
using Utilities;


namespace OMart.Web
{
    public partial class GasDealerInfoWF : System.Web.UI.Page
    {
        private readonly GasDealerInfoRT _gasDealerInfoRt;
        private const string sessGasDeal = "seGasDeal";
        int lvRowCount = 0;
        int currentPage = 0;
        private int IID = default(int);
        public GasDealerInfoWF()
        {
            _gasDealerInfoRt = new GasDealerInfoRT();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {

                    loadDropDownDistrictName(null);
                    loadDropDownCompanyName(null);
                    var requestId = Request.QueryString["IID"];
                    int reqID = Convert.ToInt32(requestId);
                    bool reqIDIsValid = Int32.TryParse(requestId, out IID);
                    if (reqID != 0)
                    {
                        ShowGasDealerData();
                    }
                }

                catch (Exception ex)
                {
                    labelMessage.Text = "Error: " + ex.Message;
                    labelMessage.ForeColor = System.Drawing.Color.Red;
                }
            }

        }

        private void ShowGasDealerData()
        {
            try
            {
                var gasDealer = _gasDealerInfoRt.GetGasDealInfoByID(IID);
                if (gasDealer != null)
                {
                    txtAddress.Text = gasDealer.Address;
                    txtDealerName.Text = gasDealer.DealerName;
                    txtPhoneNo.Text = gasDealer.PhoneNo;
                    txtTradeName.Text = gasDealer.PhoneNo;
                    ddCompanyName.SelectedValue = gasDealer.CompanyInfoID.ToString();
                    ddDistrict.SelectedValue = gasDealer.DistrictID.ToString();

                }
                else
                {
                    labelMessage.Text = "Data not found";
                    labelMessage.ForeColor=Color.Red;
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error: " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void loadDropDownDistrictName(int? districtID)
        {
            using (DistrictRT aDistrict = new DistrictRT())
            {
                List<District> districtList = new List<District>();

                if (districtID != null)
                {
                    districtList.Add(aDistrict.GetDistrictByID((int)districtID));

                }
                else
                {
                    districtList = aDistrict.GetAllDistrict();
                }

                DropDownListHelper.Bind<District>(ddDistrict, districtList, "Name", "IID", EnumCollection.ListItemType.District);
            }

        }

        private void loadDropDownCompanyName(int? companyID)
        {
            using (CompanyInfoRT aCompany = new CompanyInfoRT())
            {
                List<CompanyInfo> companyList = new List<CompanyInfo>();

                if (companyID != null)
                {
                    companyList.Add(aCompany.GetCompanyInfoByIID((int)companyID));

                }
                else
                {
                    companyList = aCompany.GetCompanyInfoByBusinessTypeID(1);
                }

                DropDownListHelper.Bind<CompanyInfo>(ddCompanyName, companyList, "Name", "IID", EnumCollection.ListItemType.CompanyInfo);
            }

        }

        protected void btn_CreateOrEdit_Click(object sender, EventArgs e)
        {
            try
            {
                var requestId = Request.QueryString["IID"];
                bool reqIDIsValid = Int32.TryParse(requestId, out IID);
                GasDealerInfo gasDealer = CreateGasDealer();
                string msg = BusinessLogicValidation(gasDealer);
                if (msg.IsNullOrWhiteSpace())
                {
                    if (IID<=0)
                    {
                        _gasDealerInfoRt.AddGasDeal(gasDealer);

                        if (gasDealer.IID > 0)
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
                        var objGasDealer = _gasDealerInfoRt.GetGasDealInfoByID(IID);
                        if (objGasDealer!=null)
                        {
                            gasDealer.IID = IID;
                            _gasDealerInfoRt.UpdateGasDealInfo(gasDealer);
                            labelMessage.Text = "Data successfully Updated...";
                            labelMessage.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            labelMessage.Text = "Infomation not found...";
                            labelMessage.ForeColor = System.Drawing.Color.Red;
                        }
                   
                    }
                  
                }
                


                ClearField();
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private string BusinessLogicValidation(GasDealerInfo gasDealer)
        {
            string msg = string.Empty;
            try
            {
                if (txtAddress.Text.IsNullOrWhiteSpace())
                {
                    msg = "please enter address";
                    return msg;
                }
                if (txtDealerName.Text.IsNullOrWhiteSpace())
                {
                    msg = "please enter name";
                    return msg;
                }
                if (txtTradeName.Text.IsNullOrWhiteSpace())
                {
                    msg = "please enter trade name";
                    return msg;
                }
                if (ddCompanyName.SelectedValue.IsNullOrWhiteSpace() || ddCompanyName.SelectedValue == "-1")
                {
                    msg = "please select a company";
                    return msg;
                }
                if (ddDistrict.SelectedValue.IsNullOrWhiteSpace() || ddDistrict.SelectedValue == "-1")
                {
                    msg = "please select district";
                    return msg;
                }

            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }


            return msg;
        }

        private void ClearField()
        {
            txtTradeName.Text = string.Empty;
            txtDealerName.Text = string.Empty;
            txtPhoneNo.Text = string.Empty;
            txtAddress.Text = string.Empty;
            ddCompanyName.SelectedIndex = -1;
            ddDistrict.SelectedIndex = -1;
        }

        private GasDealerInfo CreateGasDealer()
        {

            GasDealerInfo gasDealer = new GasDealerInfo();
            try
            {
                if (btn_CreateOrEdit.Text == "Update")
                {
                    gasDealer.IID = Convert.ToInt32(hdGasDealerInfoID.Value.ToString());
                }

                gasDealer.TradeName = txtTradeName.Text.Trim();
                gasDealer.DealerName = txtDealerName.Text.Trim();
                gasDealer.CompanyInfoID = int.Parse(ddCompanyName.SelectedValue);
                gasDealer.DistrictID = Convert.ToInt32(ddDistrict.SelectedValue);
                gasDealer.PhoneNo = txtPhoneNo.Text.Trim();
                gasDealer.Address = txtAddress.Text.Trim();
                gasDealer.IsRemoved = false;
                if (gasDealer.IID <= 0)
                {
                    gasDealer.CreatedBy = Convert.ToInt64(Session["UserID"]);
                    gasDealer.CreatedDate = GlobalRT.GetServerDateTime();
                }
                else
                {
                    GasDealerInfo gas = (GasDealerInfo)Session[sessGasDeal];
                    gasDealer.CreatedBy = gas.CreatedBy; ;
                    gasDealer.CreatedDate = gas.CreatedDate;
                    gasDealer.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                    gasDealer.ModifiedDate = GlobalRT.GetServerDateTime();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return gasDealer;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("GasDealerInfoDisplay");
        }



    }
}