using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;
using Utilities;
using BLL.Basic;
using DAL.Basic;


namespace OMart.Web.AdminPanel
{
    public partial class CardRegionWiseFeeInsertUpdate : System.Web.UI.Page
    {
        private readonly CardRegionWiseFeeRT CardRegionFee;
        private const string sessCardRegionWiseFee = "cardsRegionWiseFee";
        private int IID = default(int);

        public CardRegionWiseFeeInsertUpdate()
        {
            this.CardRegionFee = new CardRegionWiseFeeRT();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    loadDropDownCardName(null);

                    loaddropdownRegionID();
                    btnSave.Visible = true;
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    btnCancel.Visible = false;
                    //chkUserGrpIsRemove.Visible = false;

                    var requestId = Request.QueryString["IID"];
                    //hdCardRegionWiseFeeInsertUpdateID.Value = requestId.ToString();
                    bool reqIDIsValid = Int32.TryParse(requestId, out IID);
                    if (reqIDIsValid)
                    {
                        FillCardRegionWiseFeeIntoUI();
                    }
                }
                catch (Exception ex)
                {
                    labelMessageCardRegionWiseFeeInsertUpdate.Text = "Error : " + ex.Message;
                    labelMessageCardRegionWiseFeeInsertUpdate.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        private void FillCardRegionWiseFeeIntoUI()
        {
            try
            {
                CardRegionWiseFee cardregionFee = CardRegionFee.GetCardRegionFeeByIID(IID);
                if (cardregionFee != null)
                {
                    ddCardName.SelectedValue = cardregionFee.CardInfoID.ToString();
                    ddRegionName.SelectedValue = cardregionFee.RegionID.ToString();
                    txtNote.Text = cardregionFee.Note;
                    txtUsageFeePercent.Text = cardregionFee.UsageFeePercent.ToString();
                    btnUpdate.Visible = true;
                    btnSave.Visible = false;
                    btnCancel.Visible=true;
                    Session[sessCardRegionWiseFee] = cardregionFee;
                }

            }
            catch (Exception ex)
            {
                labelMessageCardRegionWiseFeeInsertUpdate.Text = "Error : " + ex.Message;
                labelMessageCardRegionWiseFeeInsertUpdate.ForeColor = System.Drawing.Color.Red;
            }
        }

        //private void LoaddropdownCardID(Int32? cardID)
        //{
        //    try
        //    {
        //        using (CardInfoRT receiverTransfer = new CardInfoRT())
        //        {

        //            List<CardInfo> cardInfoList = new List<CardInfo>();
        //            if (cardID != null)
        //            {
        //                cardInfoList.Add(receiverTransfer.GetCardInfoByIID((Int32)cardID));
        //            }
        //            else
        //            {
        //                cardInfoList = receiverTransfer.GetCardInfoAll();
        //            }

        //            DropDownListHelper.Bind<CardInfo>(ddCardName, cardInfoList, "Name", "IID", EnumCollection.ListItemType.CardInformation);

        //        }

        //    }

        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex);
        //    }
        //}
        private int IsValid()
        {
            if (ddCardName.SelectedValue == "-1")
            {
                labelMessageCardRegionWiseFeeInsertUpdate.Text = "Please Give the Card Name";
                return 1;
            }
            else if (ddRegionName.SelectedValue == "-1")
            {
                labelMessageCardRegionWiseFeeInsertUpdate.Text = "Please Give Region Name";
                return 2;
            }
            return 100;
        }


        private void loadDropDownCardName(int? cardID)
        {
            try
            {
                using (BalanceTransferRT card = new BalanceTransferRT())
                {
                    var cardInfoList = card.GetCardName();
                    DropDownListHelper.Bind(ddCardName, cardInfoList, "CARD", "IID", EnumCollection.ListItemType.CardInfo);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        private void loaddropdownRegionID()
        {
            try
            {
                DropDownListHelper.Bind(ddRegionName, EnumHelper.EnumToList<EnumCollection.RegionType>(), EnumCollection.ListItemType.RegionTypeID);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValid() == 1)
                {
                    return;
                }
                else if (IsValid() == 2)
                {
                    return;
                }

                using (CardRegionWiseFeeRT receiverTransfer = new CardRegionWiseFeeRT())
                {
                    List<CardRegionWiseFee> cardsList = new List<CardRegionWiseFee>();

                    CardRegionWiseFee cardsRegionFee = CreateCardFeeInfo();

                    receiverTransfer.AddCardsRegionWiseFee(cardsRegionFee);
                    if (cardsRegionFee.IID > 0)
                    {
                        labelMessageCardRegionWiseFeeInsertUpdate.Text = "Data successfully saved...";
                        labelMessageCardRegionWiseFeeInsertUpdate.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        labelMessageCardRegionWiseFeeInsertUpdate.Text = "Data not saved...";
                        labelMessageCardRegionWiseFeeInsertUpdate.ForeColor = System.Drawing.Color.Red;
                    }

                }
            }

            catch (Exception ex)
            {
                labelMessageCardRegionWiseFeeInsertUpdate.Text = "Error : " + ex.Message;
                labelMessageCardRegionWiseFeeInsertUpdate.ForeColor = System.Drawing.Color.Red;
            }


        }
        private CardRegionWiseFee CreateCardFeeInfo()
        {
            Session["UserID"] = "1";
            CardRegionWiseFee cardsFee = new CardRegionWiseFee();
            try
            {
                if (hdIsEdit.Value == "true")
                {
                    cardsFee.IID = Convert.ToInt32(hdCardRegionWiseFeeInsertUpdateID.Value.ToString());
                }

                cardsFee.CardInfoID = Convert.ToInt32(ddCardName.SelectedValue.ToString());
                cardsFee.RegionID = Convert.ToInt32(ddRegionName.SelectedValue.ToString());
                cardsFee.Note = txtNote.Text;
                cardsFee.UsageFeePercent = Convert.ToDecimal(txtUsageFeePercent.Text);

                if (cardsFee.IID <= 0)
                {
                    cardsFee.CreatedBy = Convert.ToInt64(Session["UserID"]);
                    cardsFee.CreatedDate = GlobalRT.GetServerDateTime();
                }
                else
                {
                    CardRegionWiseFee member = (CardRegionWiseFee)Session[sessCardRegionWiseFee];
                    cardsFee.CreatedBy = member.CreatedBy; ;
                    cardsFee.CreatedDate = member.CreatedDate;
                    cardsFee.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                    cardsFee.ModifiedDate = GlobalRT.GetServerDateTime();
                }
                if (hdIsDelete.Value != "true")
                {
                    cardsFee.IsRemoved = false;
                }
                else
                {
                    cardsFee.IsRemoved = true;
                }
            }

            catch (Exception ex)
            {
                labelMessageCardRegionWiseFeeInsertUpdate.Text = "Error : " + ex.Message;
                labelMessageCardRegionWiseFeeInsertUpdate.ForeColor = System.Drawing.Color.Red;
            }

            return cardsFee;
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                labelMessageCardRegionWiseFeeInsertUpdate.Text = string.Empty;
                using (CardRegionWiseFeeRT receiverTransfer = new CardRegionWiseFeeRT())
                {
                    hdIsEdit.Value = "true";

                    List<CardRegionWiseFee> cardsFeeList = new List<CardRegionWiseFee>();
                    int cardsFeeID = Convert.ToInt32(hdCardRegionWiseFeeInsertUpdateID.Value.ToString());
                    int cardsName = Convert.ToInt32(ddCardName.SelectedValue.ToString());
                    int regionName = Convert.ToInt32(ddRegionName.SelectedValue.ToString());

                    cardsFeeList = receiverTransfer.GetCardsFeeInfoByCardsIDAndRegionID(cardsFeeID, cardsName, regionName);

                    if (cardsFeeList != null && cardsFeeList.Count > 0)
                    {
                        string msg = "Card Name  " + "'" + ddCardName.SelectedItem + "'" + " And\n" + " Region Name " + "'" + ddRegionName.SelectedItem + "'" + " Already Exists!";
                        labelMessageCardRegionWiseFeeInsertUpdate.Text = msg;
                        labelMessageCardRegionWiseFeeInsertUpdate.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    CardRegionWiseFee cardsRegionFee = CreateCardFeeInfo();
                    if (cardsRegionFee != null)
                    {
                        receiverTransfer.UpdateCardRegionFee(cardsRegionFee);
                        labelMessageCardRegionWiseFeeInsertUpdate.Text = "Data successfully updated...";
                        labelMessageCardRegionWiseFeeInsertUpdate.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        labelMessageCardRegionWiseFeeInsertUpdate.Text = "Data not updated...";
                        labelMessageCardRegionWiseFeeInsertUpdate.ForeColor = System.Drawing.Color.Green;

                    }

                    btnSave.Visible = true;
                    btnUpdate.Visible = false;
                    btnCancel.Visible = false;
                    btnDelete.Visible = false;
                    ClearField();
                }

            }

            catch (Exception ex)
            {
                labelMessageCardRegionWiseFeeInsertUpdate.Text = "Error : " + ex.Message;
                labelMessageCardRegionWiseFeeInsertUpdate.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void ClearField()
        {
            ddCardName.SelectedIndex = 0;
            ddRegionName.SelectedIndex = 0;
            txtNote.Text = string.Empty;
            txtUsageFeePercent.Text = String.Empty;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                labelMessageCardRegionWiseFeeInsertUpdate.Text = string.Empty;
                using (CardRegionWiseFeeRT receiverTransfer = new CardRegionWiseFeeRT())
                {
                    hdIsDelete.Value = "true";
                    hdIsEdit.Value = "true";
                    CardRegionWiseFee cardsRegionFee = CreateCardFeeInfo();
                    if (cardsRegionFee != null)
                    {
                        receiverTransfer.UpdateCardRegionFee(cardsRegionFee);
                        labelMessageCardRegionWiseFeeInsertUpdate.Text = "Data Successfully Deleted...";
                        labelMessageCardRegionWiseFeeInsertUpdate.ForeColor = System.Drawing.Color.Green;
                    }

                    else
                    {
                        labelMessageCardRegionWiseFeeInsertUpdate.Text = "Data not deleted...";
                        labelMessageCardRegionWiseFeeInsertUpdate.ForeColor = System.Drawing.Color.Red;

                    }

                    btnSave.Visible = true;
                    btnUpdate.Visible = false;
                    btnCancel.Visible = false;
                    btnDelete.Visible = false;
                    ClearField();
                }

            }
            catch (Exception ex)
            {
                labelMessageCardRegionWiseFeeInsertUpdate.Text = "Error : " + ex.Message;
                labelMessageCardRegionWiseFeeInsertUpdate.ForeColor = System.Drawing.Color.Red;
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearField();
            btnSave.Visible = true;
            btnDelete.Visible = false;
            btnCancel.Visible = false;
            btnUpdate.Visible = false;
        }
    }
}