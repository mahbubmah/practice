using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Basic;

using DAL;
using Microsoft.Ajax.Utilities;
using Utilities;

namespace OMart.Web
{
    public partial class InsuranceQuotes : System.Web.UI.Page
    {
        int lvRowCount = 0;
        int currentPage = 0;
        private readonly InsuranceQuotesRT _insuranceQuotesRt;
        private const string sessSearchLiCoverMoney = "seSearchLiCoverMoney";
        private const string sessSearchNumberOfYear = "seSearchLiNumberOfYear";
        private const string sessSearchLiHaveCriticalIllness = "seSearchLiHaveCriticalIllness";
        private const string sessSeachLiApplicantIID = "sessSeachLiApplicantIID";
        private readonly string _visitorLogPath;
        private string _pageLogPath;

        public InsuranceQuotes()
        {
            this._visitorLogPath = Server.MapPath("~/Log file/VisitorlogFileWriting.txt");
            _insuranceQuotesRt = new InsuranceQuotesRT();
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
                    if (Session[sessSearchLiCoverMoney] == null || Session[sessSearchNumberOfYear] == null || Session[sessSearchLiHaveCriticalIllness] == null || Session[sessSeachLiApplicantIID] == null)
                    {
                        Response.Redirect("InsuranceCover");
                    }
                    LoadDropDownForPolicyTerm();
                    LoadResult();
                    LoadDropDownForHaveCriticalIllness();
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private void LoadDropDownForHaveCriticalIllness()
        {
            try
            {
                if ((bool)Session[sessSearchLiHaveCriticalIllness])
                {
                    dropDownHaveCriticalIllness.SelectedValue = "1";
                }
                else
                {
                    dropDownHaveCriticalIllness.SelectedValue = "0";
                }
            }
            catch (Exception ex)
            {

                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        private void LoadDropDownForPolicyTerm()
        {
            try
            {
                var liSchemaList = _insuranceQuotesRt.GetLiSchemaNoOfYearForDropDown();
                DropDownListHelper.Bind(dropDownPolicyTerm, liSchemaList, "DiplayMember", "Value");
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }

        }

        private void LoadResult()
        {
            try
            {
                txtCoverMoney.Text = Session[sessSearchLiCoverMoney].ToString();
                dropDownPolicyTerm.SelectedValue = Session[sessSearchNumberOfYear].ToString();

                bool haveCriticalIllness = (bool)Session[sessSearchLiHaveCriticalIllness];
                if (haveCriticalIllness)
                {
                    dropDownHaveCriticalIllness.SelectedValue = "1";
                    divCriticalIllnessCoverAmount.Visible = true;
                }
                else
                {
                    dropDownHaveCriticalIllness.SelectedValue = "0";
                }

                txtAppicantIID.Text = Session[sessSeachLiApplicantIID].ToString();

                List<InsuranceQuotesRT.InsuranceQuotesSearchReasultDisplay> searchedResult;

                if ((bool)Session[sessSearchLiHaveCriticalIllness])
                {
                    if (!IsPostBack || txtCriticalIllnessCoverAmount.Text.IsNullOrWhiteSpace())
                    {
                        searchedResult = _insuranceQuotesRt.SearchedResult(-1, (decimal)Session[sessSearchLiCoverMoney], (int)Session[sessSearchNumberOfYear]);
                    }
                    else
                    {
                        searchedResult = _insuranceQuotesRt.SearchedResult(Convert.ToDecimal(txtCriticalIllnessCoverAmount.Text), (decimal)Session[sessSearchLiCoverMoney], (int)Session[sessSearchNumberOfYear]);
                    }

                }
                else
                {
                    searchedResult = _insuranceQuotesRt.SearchedResult(0, (decimal)Session[sessSearchLiCoverMoney], (int)Session[sessSearchNumberOfYear]);
                }

                lvInsuranceQuotesSearchResult.DataSource = searchedResult;
                lvInsuranceQuotesSearchResult.DataBind();
                if (searchedResult.Count > 0)
                {
                    lblMessage.Text = @"<h2>" + _insuranceQuotesRt.GetApplicantByIid((long)Session[sessSeachLiApplicantIID]).FirstName + ", we have found " + searchedResult.Count + " quotes from " + Regex.Replace(searchedResult.FirstOrDefault().PremiumAmount, "<.*?>", string.Empty) + ".</h2>";
                }
                else
                {
                    lblMessage.Text = @"<h2>" + _insuranceQuotesRt.GetApplicantByIid((long)Session[sessSeachLiApplicantIID]).FirstName + ", we have found " + 0 + " quotes .</h2>";
                }
            }
            catch (Exception ex)
            {

                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }

        }

        protected void btnUpdateResult_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (!txtCoverMoney.Text.IsNullOrWhiteSpace())
                {
                    Session[sessSearchLiCoverMoney] = Convert.ToDecimal(txtCoverMoney.Text);
                }

                if (dropDownHaveCriticalIllness.SelectedValue == "1")
                {
                    Session[sessSearchLiHaveCriticalIllness] = true;
                }
                else
                {
                    Session[sessSearchLiHaveCriticalIllness] = false;
                }

                if (dropDownPolicyTerm.SelectedValue != "-1" || !dropDownPolicyTerm.SelectedValue.IsNullOrWhiteSpace())
                {
                    Session[sessSearchNumberOfYear] = Convert.ToInt32(dropDownPolicyTerm.SelectedValue);
                }

                LoadResult();
            }
            catch (Exception ex)
            {

                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }

        }


        protected void dropDownHaveCriticalIllness_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (dropDownHaveCriticalIllness.SelectedValue == "1")
                {
                    divCriticalIllnessCoverAmount.Visible = true;
                    Session[sessSearchLiHaveCriticalIllness] = true;
                }
                else
                {
                    divCriticalIllnessCoverAmount.Visible = false;
                    Session[sessSearchLiHaveCriticalIllness] = false;
                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        protected void dataPagerInsuranceQuotesSearchResult_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                LoadResult();
            }
            catch (Exception ex)
            {

                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
    }
}