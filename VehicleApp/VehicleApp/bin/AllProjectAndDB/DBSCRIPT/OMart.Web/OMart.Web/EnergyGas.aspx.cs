using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Basic;
using Microsoft.Ajax.Utilities;
using Utilities;

namespace OMart.Web
{
    public partial class EnergyGas : System.Web.UI.Page
    {
        private readonly GasRT _gasRt;
        private readonly string _visitorLogPath;
        private string _pageLogPath;

        public EnergyGas()
        {
            this._visitorLogPath = Server.MapPath("~/Log file/VisitorlogFileWriting.txt");
            _gasRt = new GasRT();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string pageName = Path.GetFileName(Request.PhysicalPath);
                _pageLogPath = Server.MapPath("~/Log file/" + pageName + ".txt");
                if (!IsPostBack)
                {
                    LogFileHelper.VisitorLogFileWritten(_visitorLogPath);
                    LoadGuideLineForEnergy();
                    LoadRepCompanyLogoImage();
                    //select country from enum
                    int countryID = Convert.ToInt32(EnumCollection.Country.Bangladesh);//change here for change country
                    hdCountryID.Value = countryID.ToString();
                    LoadDropDownForCompany();
                    LoadDropDownForDistrict();
                    LoadGasCylienderSearchResult(string.Empty, string.Empty, string.Empty, string.Empty);
                }
            }
            catch (Exception ex)
            {

                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private void LoadGuideLineForEnergy()
        {
            try
            {
                var guideLineList = _gasRt.GetGuideLinesForEnergy();
                repEnergyGuideLine.DataSource = guideLineList;
                repEnergyGuideLine.DataBind();
            }
            catch (Exception ex)
            {

                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private void LoadRepCompanyLogoImage()
        {
            try
            {
                using (CompanyInfoRT aCompanyInfoRt=new CompanyInfoRT())
                {
                    var companyList = aCompanyInfoRt.GetAllCompanyInfos().Where(x=>x.BussinessTypeID==Convert.ToInt16(EnumCollection.BussinessType.Energy)).Take(8);
                    repEnergyCompanyLogo.DataSource = companyList;
                    repEnergyCompanyLogo.DataBind();
                }
               
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private void LoadGasCylienderSearchResult(string companyId, string districtId, string policeStationId, string amountOfGas)
        {
            try
            {
                int? companyIid = !companyId.IsNullOrWhiteSpace() && companyId != "-1" ? Convert.ToInt32(companyId) : (int?)null;
                long? districtIid = !districtId.IsNullOrWhiteSpace() && districtId != "-1" ? Convert.ToInt64(districtId) : (long?)null;
               // long? policeStationIid = !policeStationId.IsNullOrWhiteSpace() && policeStationId != "-1" ? Convert.ToInt64(policeStationId) : (long?)null;
                int? weightOfGas = !txtSearchAmountOfGas.Text.IsNullOrWhiteSpace() ? Convert.ToInt32(amountOfGas) : (int?)null;

                lvGasSearchResult.DataSource = _gasRt.GetSearchResultForGasCyliender(companyIid, districtIid, null, weightOfGas);//null policestaion id may be need later
                lvGasSearchResult.DataBind();
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
           
        }

        private void LoadDropDownForCompany()
        {
            try
            {
                using (CompanyInfoRT aCompanyInfoRt = new CompanyInfoRT())
                {
                    var companyList = aCompanyInfoRt.GetAllEnergyCompanyForDropDown();
                    DropDownListHelper.Bind(dropDownCompanyInfo, companyList, "Name", "IID", EnumCollection.ListItemType.CompanyInfo);
                }

            }
            catch (Exception ex)
            {

                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
        private void LoadDropDownForDistrict()
        {
            try
            {
                using (DistrictRT aDistrictRt = new DistrictRT())
                {
                    var districtList = aDistrictRt.GetDistrictByCountryId(Convert.ToInt32(hdCountryID.Value));
                    DropDownListHelper.Bind(dropDwonForDistrict, districtList, "Name", "IID", EnumCollection.ListItemType.District);
                }

            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
        //private void LoadDropDownForPoliceStaion()
        //{
        //    try
        //    {
        //        if (dropDwonForDistrict.SelectedValue != "-1" || !dropDwonForDistrict.SelectedValue.IsNullOrWhiteSpace())
        //        {
        //            using (PoliceStationRT aPoliceStationRt = new PoliceStationRT())
        //            {
        //                var policeStaionList = aPoliceStationRt.GetPoliceStationByCountryIdAndDistrictId(Convert.ToInt32(hdCountryID.Value), Convert.ToInt64(dropDwonForDistrict.SelectedValue));
        //                DropDownListHelper.Bind(dropDownPoliceStation, policeStaionList, "Name", "IID", EnumCollection.ListItemType.PoliceStaion);
        //            }
        //        }
        //        else
        //        {
        //            dropDownPoliceStation.Items.Clear();
        //            dropDownPoliceStation.Items.Add(new ListItem("--Select--", "-1"));
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
        //    }
        //}

        //protected void dropDwonForDistrict_OnSelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        LoadDropDownForPoliceStaion();
        //    }
        //    catch (Exception ex)
        //    {

        //        LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
        //    }
        //}
        int lvRowCount = 0;
        int currentPage = 0;
        protected void dataPagerGasSearchResult_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    LoadGasCylienderSearchResult(dropDownCompanyInfo.SelectedValue, dropDwonForDistrict.SelectedValue, "-1", txtSearchAmountOfGas.Text);
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
        protected void lvGasSearchResult_OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            labelMessage.Text = string.Empty;
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void UpdateSearchResult(object sender, EventArgs e)
        {
            try
            {
                LoadGasCylienderSearchResult(dropDownCompanyInfo.SelectedValue, dropDwonForDistrict.SelectedValue, "-1", txtSearchAmountOfGas.Text);
            }
            catch (Exception ex)
            {

                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }

        }

      
    }
}