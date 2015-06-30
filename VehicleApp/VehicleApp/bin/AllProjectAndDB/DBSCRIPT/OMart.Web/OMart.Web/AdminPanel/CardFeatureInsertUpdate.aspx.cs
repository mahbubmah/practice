using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Basic;
using DAL;
using Microsoft.Ajax.Utilities;
using Utilities;

namespace OMart.Web.AdminPanel
{
    public partial class CardFeatureInsertUpdate : System.Web.UI.Page
    {

        private readonly CardFeatureRT _cardFeatureRt;
        private long IID = default(Int64);

        public CardFeatureInsertUpdate()
        {
            _cardFeatureRt = new CardFeatureRT();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadDropDownCardInfo();
                   
                    var requestId = Request.QueryString["IID"];
                    bool reqIDIsValid = Int64.TryParse(requestId, out IID);
                    if (reqIDIsValid)
                    {
                        ShowCardFeatureData();
                    }

                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void ShowCardFeatureData()
        {
            try
            {
                CardFeature objMorgage = _cardFeatureRt.GetCardFeatureByID(IID);
                if (objMorgage != null)
                {
                    dropDownCardInfo.SelectedValue = objMorgage.CardInfoID.ToString();
                    txtDescription.Text = objMorgage.Description ?? string.Empty;
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        private string BusinessLogicValidation(CardFeature cardFeature)
        {
            string message = string.Empty;
            bool reqIDIsValid = Int64.TryParse(Request.QueryString["IID"], out IID);

            if (cardFeature.CardInfoID == -1 )
            {
                message = "Please select card informaion";
                return message;
            }
            if (dropDownCardInfo.SelectedValue==string.Empty || dropDownCardInfo.SelectedValue=="-1")
            {
                message = "Please select card informaion";
                return message;
            }

            return string.Empty;
        }


        public void LoadDropDownCardInfo()
        {
            try
            {
                using (CardFeatureRT aCardFeatureRt = new CardFeatureRT())
                {
                    var cardInfoList = aCardFeatureRt.GetAllCardInfo();
                    DropDownListHelper.Bind(dropDownCardInfo, cardInfoList, "Name", "IID", EnumCollection.ListItemType.CardInfo);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
        private CardFeature CreateCardFeature()
        {
            Session["UserID"] = "1";
            CardFeature cardFeature = new CardFeature();
            try
            {
                if (IID >= 0)
                {
                    cardFeature.IID = IID;
                }

                if (!txtDescription.Text.IsNullOrWhiteSpace())
                {
                    cardFeature.Description = txtDescription.Text;
                }

                if (dropDownCardInfo.SelectedValue != "-1")
                {
                    cardFeature.CardInfoID = Convert.ToInt64(dropDownCardInfo.SelectedValue);
                }

            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return cardFeature;
        }
        private void ClearData()
        {
            txtDescription.Text = string.Empty;
            dropDownCardInfo.SelectedValue = "-1";
           
        }

        protected void btn_CreateOrEdit_Click(object sender, EventArgs e)
        {
            try
            {
                CardFeature cardFeature = CreateCardFeature();
                bool reqIDIsValid = Int64.TryParse(Request.QueryString["IID"], out IID);
                var msg = BusinessLogicValidation(cardFeature);

                if (string.IsNullOrEmpty(msg))
                {
                    if (IID <= 0)
                    {
                        cardFeature.CreatedBy = Convert.ToInt64(Session["UserID"]);
                        cardFeature.CreatedDate = DateTime.Now;

                        _cardFeatureRt.AddCardFeature(cardFeature);
                        ClearData();

                        labelMessage.Text = "Information has been inserted successfully.";
                        labelMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        CardFeature objCardFeature = _cardFeatureRt.GetCardFeatureByID(IID);

                        if (objCardFeature != null)
                        {
                            cardFeature.CreatedBy = objCardFeature.CreatedBy; ;
                            cardFeature.CreatedDate = objCardFeature.CreatedDate;
                            cardFeature.IID = objCardFeature.IID;

                            cardFeature.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                            cardFeature.ModifiedDate = DateTime.Now;

                            _cardFeatureRt.UpdateCardFeature(cardFeature);
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
                Response.Redirect("~/AdminPanel/CardFeatureDisplay.aspx");
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}