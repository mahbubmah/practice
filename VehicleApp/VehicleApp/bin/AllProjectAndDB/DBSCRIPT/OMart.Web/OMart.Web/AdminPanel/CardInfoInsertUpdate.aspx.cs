using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Basic;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using DAL;
using Microsoft.Ajax.Utilities;
using OMart.Web.AdminPanel.CrystalReports;

using Utilities;

namespace OMart.Web.AdminPanel
{
    public partial class CardInfoInsertUpdate : System.Web.UI.Page
    {

        private readonly CardInfoRT _cardInfoRt;
        private const string sessCardFeature = "seCardFeature";
        private int IID = default(Int32);

        public CardInfoInsertUpdate()
        {
            _cardInfoRt = new CardInfoRT();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           

           
            try
            {
                if (!IsPostBack)
                {
                    LoadDropDownForCompanyInfo();
                    LoadDropDownForBalanceType();
                    LoadDropDownForCardType();
                    var requestId = Request.QueryString["IID"];
                    bool reqIDIsValid = Int32.TryParse(requestId, out IID);
                    if (reqIDIsValid)
                    {
                        ShowCardInfoData();
                    }
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }



        #region private methods

        private void ShowCardInfoData()
        {
            try
            {
                CardInfo objCardInfo = _cardInfoRt.GetCardInfoByID(IID);
                if (objCardInfo.IsRemoved)
                {
                    labelMessage.Text = "Error : this information has been removed.";
                    labelMessage.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                if (IID > 0)
                {
                    using (CardFeatureRT aCardFeatureRt = new CardFeatureRT())
                    {
                        Session[sessCardFeature] = aCardFeatureRt.GetAllCardFeaturesByCardInfoId(IID);
                    }
                }

                if (objCardInfo != null)
                {

                    dropDownCompanyInfo.SelectedValue = objCardInfo.CompanyInfoID.ToString();
                    dropDownCardType.SelectedValue = objCardInfo.CardTypeID.ToString();
                    dropDownBalanceType.SelectedValue = objCardInfo.BalanceTypeID.ToString();
                    txtName.Text = objCardInfo.Name;
                    txtDescription.Text = objCardInfo.Description;
                    txtPostLastDisplayDate.Text = objCardInfo.PostLastDisplayDate.ToString("dd/MM/yyyy");
                    txtAPR.Text = objCardInfo.APR.ToString();
                    // txtCardLogoUrl.Text = objCardInfo.CardLogoUrl;
                    txtRedirectUrl.Text = objCardInfo.RedirectUrl;
                    txtMinimumLimitAmt.Text = objCardInfo.MinimumLimitAmt.ToString();
                    txtMaximumLimitAmt.Text = objCardInfo.MaximumLimitAmt.ToString();
                    txtAnnualFeePayment.Text = objCardInfo.AnnualFeePayment.ToString();
                    txtRewardNote.Text = objCardInfo.RewardNote;
                    txtRewardCompanyLogoUrl.Text = objCardInfo.RewardCompanyLogoUrl;
                    txtCashbackEarnedAmt.Text = objCardInfo.CashbackEarnedAmt.ToString();
                    txtCashbackEarnedNote.Text = objCardInfo.CashbackEarnedNote;
                    chkIsPostAdExtended.Checked = objCardInfo.IsPostAdExtended != null ? (bool)objCardInfo.IsPostAdExtended : false;

                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void LoadDropDownForCompanyInfo()
        {
            try
            {
                using (CompanyInfoRT aCompanyInfoRt = new CompanyInfoRT())
                {
                    var companyInfoList = aCompanyInfoRt.GetAllCompanyInfosForCards();
                    DropDownListHelper.Bind(dropDownCompanyInfo, companyInfoList, "Name", "IID", EnumCollection.ListItemType.CompanyInfo);
                }
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message, exception);
            }
        }
        private void LoadDropDownForBalanceType()
        {
            try
            {
                dropDownBalanceType.Items.Add(new ListItem("Select Balance", "-1"));
                DropDownListHelper.Bind(dropDownBalanceType, EnumHelper.EnumCamelSpaceToList<EnumCollection.BalanceType>());
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message, exception);
            }
        }
        private void LoadDropDownForCardType()
        {
            try
            {
                dropDownCardType.Items.Add(new ListItem("Select Card", "-1"));
                DropDownListHelper.Bind(dropDownCardType, EnumHelper.EnumCamelSpaceToList<EnumCollection.CardType>());
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message, exception);
            }
        }

        private string BusinessLogicValidationCardInfo(CardInfo cardInfo)
        {
            string message = string.Empty;
            bool reqIDIsValid = Int32.TryParse(Request.QueryString["IID"], out IID);

            if (dropDownCompanyInfo.SelectedValue == "-1" || dropDownCompanyInfo.SelectedValue.IsNullOrWhiteSpace())
            {
                message = "Please select company";
                return message;
            }
            if (txtName.Text.IsNullOrWhiteSpace())
            {
                message = "Please enter name";
                return message;
            }
            if (dropDownCardType.SelectedValue == "-1" || dropDownCardType.SelectedValue.IsNullOrWhiteSpace())
            {
                message = "Please select card type";
                return message;
            }
            if (dropDownBalanceType.SelectedValue == "-1" || dropDownBalanceType.SelectedValue.IsNullOrWhiteSpace())
            {
                message = "Please select balance type";
                return message;
            }
            if (txtAPR.Text.IsNullOrWhiteSpace())
            {
                message = "Please enter APR";
                return message;
            }
            if (txtMinimumLimitAmt.Text.IsNullOrWhiteSpace())
            {
                message = "Please enter minimum limit amount";
                return message;
            }
            if (txtMaximumLimitAmt.Text.IsNullOrWhiteSpace())
            {
                message = "Please enter maximum limit amount";
                return message;
            }
            if (txtAnnualFeePayment.Text.IsNullOrWhiteSpace())
            {
                message = "Please enter annual fee payment";
                return message;
            }

            if (txtPostLastDisplayDate.Text.IsNullOrWhiteSpace())
            {
                message = "Please enter post last display date";
                return message;
            }

            return message;
        }

        private CardInfo CreateCardInfo()
        {
            // Session["UserID"] 
            CardInfo cardInfo = new CardInfo();
            try
            {
                if (IID > 0)
                {
                    cardInfo.IID = IID;
                    var cardInfoByIid = _cardInfoRt.GetCardInfoByID(IID);
                    if (cardInfoByIid != null)
                    {
                        cardInfo = cardInfoByIid;
                    }
                }
                cardInfo.PostAdDate = GlobalRT.GetServerDateTime();

                if (!txtPostLastDisplayDate.Text.IsNullOrWhiteSpace())
                {
                    cardInfo.PostLastDisplayDate = Convert.ToDateTime(txtPostLastDisplayDate.Text);
                }


                if (dropDownCompanyInfo.SelectedValue != "-1" || !dropDownCompanyInfo.SelectedValue.IsNullOrWhiteSpace())
                {
                    cardInfo.CompanyInfoID = Convert.ToInt32(dropDownCompanyInfo.SelectedValue);
                }

                if (dropDownCardType.SelectedValue != "-1" || !dropDownCardType.SelectedValue.IsNullOrWhiteSpace())
                {
                    cardInfo.CardTypeID = Convert.ToInt32(dropDownCardType.SelectedValue);
                }
                if (dropDownBalanceType.SelectedValue != "-1" || !dropDownBalanceType.SelectedValue.IsNullOrWhiteSpace())
                {
                    cardInfo.BalanceTypeID = Convert.ToInt32(dropDownBalanceType.SelectedValue);
                }

                cardInfo.Description = txtDescription.Text;
                cardInfo.Name = txtName.Text;
                cardInfo.APRDescription = txtAprDescription.Text;
                if (!txtAPR.Text.IsNullOrWhiteSpace())
                {
                    cardInfo.APR = Convert.ToDecimal(txtAPR.Text);
                }
                if (!txtMinimumLimitAmt.Text.IsNullOrWhiteSpace())
                {
                    cardInfo.MinimumLimitAmt = Convert.ToDecimal(txtMinimumLimitAmt.Text);
                }
                if (!txtMaximumLimitAmt.Text.IsNullOrWhiteSpace())
                {
                    cardInfo.MaximumLimitAmt = Convert.ToDecimal(txtMaximumLimitAmt.Text);
                }
                if (!txtAnnualFeePayment.Text.IsNullOrWhiteSpace())
                {
                    cardInfo.AnnualFeePayment = Convert.ToDecimal(txtAnnualFeePayment.Text);
                }
                // cardInfo.CardLogoUrl = txtCardLogoUrl.Text;
                cardInfo.RewardNote = txtRewardNote.Text;
                cardInfo.RewardCompanyLogoUrl = txtRewardCompanyLogoUrl.Text;

                if (!txtCashbackEarnedAmt.Text.IsNullOrWhiteSpace())
                {
                    cardInfo.CashbackEarnedAmt = Convert.ToDecimal(txtCashbackEarnedAmt.Text);
                }
                if (!txtWholeWorldUsageFeePer.Text.IsNullOrWhiteSpace())
                {
                    cardInfo.WholeWorldUsageFeePer = Convert.ToDecimal(txtWholeWorldUsageFeePer.Text);
                }
                if (!txtUsedRemarkedPoint.Text.IsNullOrWhiteSpace())
                {
                    cardInfo.UsedRemarkedPoint = Convert.ToDouble(txtUsedRemarkedPoint.Text);
                }
                if (!txtPaymentAmt.Text.IsNullOrWhiteSpace())
                {
                    cardInfo.PaymentAmt = Convert.ToDecimal(txtPaymentAmt.Text);
                }
                cardInfo.CashbackEarnedNote = txtCashbackEarnedNote.Text;
                cardInfo.IsPostAdExtended = chkIsPostAdExtended.Checked;
                cardInfo.RedirectUrl = txtRedirectUrl.Text;

                if (IID > 0)
                {
                    cardInfo.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                    cardInfo.ModifiedDate = GlobalRT.GetServerDateTime();
                }
                else
                {
                    cardInfo.CreatedBy = Convert.ToInt64(Session["UserID"]);
                    cardInfo.CreatedDate = GlobalRT.GetServerDateTime();
                }

            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return cardInfo;
        }
        private void ClearData()
        {
            txtAPR.Text = string.Empty;
            txtAnnualFeePayment.Text = string.Empty;
            txtAprDescription.Text = string.Empty;
            // txtCardLogoUrl.Text = string.Empty;
            txtCashbackEarnedAmt.Text = string.Empty;
            txtCashbackEarnedNote.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtMaximumLimitAmt.Text = string.Empty;
            txtMinimumLimitAmt.Text = string.Empty;
            txtName.Text = string.Empty;
            txtPaymentAmt.Text = string.Empty;
            txtPostLastDisplayDate.Text = string.Empty;
            txtRedirectUrl.Text = string.Empty;
            txtRewardCompanyLogoUrl.Text = string.Empty;
            txtRewardNote.Text = string.Empty;
            txtUsedRemarkedPoint.Text = string.Empty;
            txtWholeWorldUsageFeePer.Text = string.Empty;
            txtWholeWorldUsageFeePer.Text = string.Empty;

            chkIsPostAdExtended.Checked = false;

            dropDownCompanyInfo.SelectedValue = "-1";
            dropDownCardType.SelectedValue = "-1";
            dropDownBalanceType.SelectedValue = "-1";

        }


        #endregion private methods





        #region protected event

        protected void btn_CreateOrEdit_Click(object sender, EventArgs e)
        {
            try
            {
                bool reqIDIsValid = int.TryParse(Request.QueryString["IID"], out IID);
                CardInfo cardInfo = CreateCardInfo();

                var msg = BusinessLogicValidationCardInfo(cardInfo);

                if (string.IsNullOrEmpty(msg))
                {
                    string cardInfoImageName = string.Empty;
                    string path = Server.MapPath("~/All Photos/Banking/Card/CardLogo/");
                    if (IID > 0)
                    {
                        cardInfoImageName = IID.ToString();
                    }
                    else
                    {
                        var cardInfoLast = _cardInfoRt.GetCardInfoLast();
                        if (cardInfoLast != null)
                        {
                            cardInfoImageName = (cardInfoLast.IID + 1).ToString();
                        }
                        else
                        {
                            cardInfoImageName = "1";
                        }
                    }
                    if (fuCardInfo.HasFile)
                    {
                        cardInfo.CardLogoUrl = "~/All Photos/Banking/Card/CardLogo/" + cardInfoImageName + Path.GetExtension(fuCardInfo.FileName);
                    }


                    if (IID <= 0)
                    {
                        List<CardFeature> cardFeatureColl = new List<CardFeature>();
                        List<CardFeature> cardFeatureList = (List<CardFeature>)Session[sessCardFeature];
                        foreach (var cardFeature in cardFeatureList)
                        {
                            cardFeature.CreatedBy = Convert.ToInt64(Session["UserId"]);
                            cardFeature.CreatedDate = GlobalRT.GetServerDateTime();
                        }
                        if (cardFeatureList.Count > 0)
                        {
                            cardFeatureColl = cardFeatureList;
                        }

                        string cardInfoWithAllChildCardFeatureXML = ConversionXML.ConvertObjectToXML<CardInfo, CardFeature>(cardInfo, cardFeatureColl, string.Empty);

                        int cardInfoId = CardInfoRT.InsertCardInfoAndAllChildCardFeatuerXML(cardInfoWithAllChildCardFeatureXML);
                        //_cardInfoRt.AddCardInfo(cardInfo);
                        if (cardInfoId > 0)
                        {
                            if (fuCardInfo.HasFile)
                            {
                                FileUploadHelper.BindImage(fuCardInfo, path, cardInfoImageName);
                            }
                            Session[sessCardFeature] = null;
                            ClearData();
                            labelMessage.Text = "Information has been inserted successfully.";
                            labelMessage.ForeColor = System.Drawing.Color.Green;
                        }
                        else if (cardInfoId == -100)
                        {
                            labelMessage.Text = "Network connection fail ... Please try again..!!";
                            labelMessage.ForeColor = System.Drawing.Color.Red;
                            labelMessage.Focus();
                        }
                        else if (cardInfoId == -101)
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
                        CardInfo objCardInfo = _cardInfoRt.GetCardInfoByID(IID);

                        if (objCardInfo != null)
                        {
                            cardInfo.CreatedBy = objCardInfo.CreatedBy; ;
                            cardInfo.CreatedDate = objCardInfo.CreatedDate;
                            cardInfo.IID = objCardInfo.IID;

                            cardInfo.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                            cardInfo.ModifiedDate = DateTime.Now;

                            _cardInfoRt.UpdateCardInfo(cardInfo);
                            if (fuCardInfo.HasFile)
                            {
                                FileUploadHelper.BindImage(fuCardInfo, path, cardInfoImageName);
                            }

                            using (CardFeatureRT aCardFeatureRt = new CardFeatureRT())
                            {
                                var cardFeatureListToRemove = aCardFeatureRt.GetAllCardFeaturesByCardInfoId(IID);
                                foreach (var cardFeature in cardFeatureListToRemove)
                                {
                                    cardFeature.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                                    cardFeature.ModifiedDate = DateTime.Now;
                                    cardFeature.IsRemoved = true;
                                    aCardFeatureRt.UpdateCardFeature(cardFeature);
                                }

                                List<CardFeature> cardFeatureListToAdd = (List<CardFeature>)Session[sessCardFeature];
                                foreach (var cardFeature in cardFeatureListToAdd)
                                {
                                    if (cardFeature.CreatedBy == 0)
                                    {
                                        cardFeature.CreatedBy = Convert.ToInt64(Session["UserID"]);
                                        cardFeature.CreatedDate = DateTime.Now;
                                        cardFeature.CardInfoID = IID;
                                        aCardFeatureRt.AddCardFeature(cardFeature);
                                    }
                                    else
                                    {
                                        cardFeature.IsRemoved = false;
                                        cardFeature.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                                        cardFeature.ModifiedDate = DateTime.Now;
                                        aCardFeatureRt.UpdateCardFeature(cardFeature);
                                    }
                                }
                            }
                            Session[sessCardFeature] = null;
                            ClearData();

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
                Response.Redirect("~/AdminPanel/CardInfoDisplay.aspx");
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        #endregion protected event

        protected void CrystalReportViewer1_ReportRefresh(object source, ViewerEventArgs e)
        {

        }
    }
}