using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using BLL;
using BLL.Basic;
using DAL;
namespace OMart.Web.AdminPanel
{
    public partial class CardPurchaseWF : System.Web.UI.Page
    {
        private const string sessUserGrp = "seUserGroup";
        protected void Page_Load(object sender, EventArgs e)
        {
            hdCardInfoID.Value = Request.QueryString["IID"];
           // hdCardInfoID.Value = "1";
            CardInfoLoad();
            if (!IsPostBack)
            {

                try
                {
                    
                    LoadCardPurchase();
                    btnSave.Visible = true;
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    btnCancel.Visible = true;
                    chkUserGrpIsRemove.Visible = false;
                }
                catch (Exception ex)
                {
                    labelMessageUserGroup.Text = "Error : " + ex.Message;
                    labelMessageUserGroup.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        private void CardInfoLoad()
        {
            using (CardPurchaseRT cardInfo = new CardPurchaseRT())
            {
                try
                { 
                CardInfo card = new CardInfo();
                card = cardInfo.GetCardInfoByID(Convert.ToInt64(hdCardInfoID.Value));
                txtName.Text = card.Name;
                txtDescription.Text =  card.Description;
                txtCartType.Text = EnumHelper.EnumToString<EnumCollection.CardType>(card.CardTypeID);
                txtBalType.Text = EnumHelper.EnumToString<EnumCollection.BalanceType>(card.BalanceTypeID);
                 }
                catch (Exception ex)
                {
                    labelMessageUserGroup.Text = "Error : " + ex.Message;
                    labelMessageUserGroup.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
        private void LoadCardPurchase()
        {
            try
            {
                using (CardPurchaseRT receiverTransfer = new CardPurchaseRT())
                {

                    lvUserGroup.DataSource = receiverTransfer.GetCardPurchaseByCardInfoID(Convert.ToInt32(hdCardInfoID.Value)); 
                    lvUserGroup.DataBind();
                }
            }
            catch (Exception ex)
            {
                labelMessageUserGroup.Text = "Error : " + ex.Message;
                labelMessageUserGroup.ForeColor = System.Drawing.Color.Red;
            }
        }

       
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                
                    labelMessageUserGroup.Text = string.Empty;
                    using (CardPurchaseRT receiverTransfer = new CardPurchaseRT())
                    {

                        List<CardPurchase> CardPurchaseList = new List<CardPurchase>();
                        CardPurchaseList = receiverTransfer.GetCardPurchaseByCardInfoIdAndMonthNO(Convert.ToInt32(hdCardInfoID.Value), Convert.ToInt32( txtMonthNo.Text));

                        if ( CardPurchaseList.Count > 0)
                        {
                            string msg = "User Group Name  " + txtMonthNo.Text + " Already Exists in Current Card";
                            //string alertScript =
                            //String.Format("alert('{0}');", msg);
                            //Page.ClientScript.RegisterStartupScript(this.GetType(), "Key", alertScript, true);

                            labelMessageUserGroup.Text = msg;
                            labelMessageUserGroup.ForeColor = System.Drawing.Color.Red;
                            return;
                        }
                        hdSave.Value = "true";
                        CardPurchase userGrp = CreateCardPurchase();
                        receiverTransfer.AddCardPurchase(userGrp);
                        if (userGrp.IID > 0)
                        {
                            labelMessageUserGroup.Text = "Data successfully saved...";
                            labelMessageUserGroup.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            labelMessageUserGroup.Text = "Data not saved...";
                            labelMessageUserGroup.ForeColor = System.Drawing.Color.Red;
                        }
                    }

                    ClearField();
                    LoadCardPurchase();
                
                
            }
            catch (Exception ex)
            {
                labelMessageUserGroup.Text = "Error : " + ex.Message;
                labelMessageUserGroup.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lnkbEdit_Click(object sender, EventArgs e)
        {
            try
            {
                labelMessageUserGroup.Text = string.Empty;
                LinkButton linkButton = (LinkButton)sender;
                int id = Convert.ToInt32(linkButton.CommandArgument);
                btnSave.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = false;
                btnCancel.Visible = true;

                hdId.Value = id.ToString();
                using (CardPurchaseRT receiverTransfer = new CardPurchaseRT())
                {
                    CardPurchase userGroup = receiverTransfer.GetCardPurchaseByIID(id);

                    FillUserGrpForEdit(userGroup);
                }
                //LoadUserInfo()
            }
            catch (Exception ex)
            {
                labelMessageUserGroup.Text = "Error : " + ex.Message;
                labelMessageUserGroup.ForeColor = System.Drawing.Color.Red;
            }
        }

     

        private CardPurchase CreateCardPurchase()
        {
            Session["UserID"] = "1";
            CardPurchase cardPurchase = new CardPurchase();
            try
            {
                if (hdIsEdit.Value == "true")
                {
                    cardPurchase.IID = Convert.ToInt32(hdId.Value.ToString());
                }
                cardPurchase.MonthNumber = Convert.ToInt32( txtMonthNo.Text.Trim());
                cardPurchase.IsRemoved = chkUserGrpIsRemove.Checked;
                cardPurchase.RateOnPurchase = Convert.ToInt32(txtRateOnPurchase.Text.Trim());
                cardPurchase.CardInfoID = Convert.ToInt32(hdCardInfoID.Value);
                cardPurchase.Note = txtNote.Text;
                
                if (cardPurchase.IID <= 0)
                {
                    cardPurchase.CreatedBy = Convert.ToInt64(Session["UserID"]);
                    cardPurchase.CreatedDate = GlobalRT.GetServerDateTime();
                }
                else
                {
                    CardPurchase usrGrp = (CardPurchase)Session[sessUserGrp];
                    cardPurchase.CreatedBy = usrGrp.CreatedBy; ;
                    cardPurchase.CreatedDate = usrGrp.CreatedDate;
                    cardPurchase.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                    cardPurchase.ModifiedDate = GlobalRT.GetServerDateTime();
                }
                //if ((hdIsEdit.Value != "true" && chkUserGrpIsRemove.Checked!=true)||(hdSave.Value=="true" &&chkUserGrpIsRemove.Checked!=true))
                //{
                //    userGrp.IsRemoved = false;
                //}
                //else
                //{
                //    userGrp.IsRemoved = true;
                //}
            }
            catch (Exception ex)
            {
                labelMessageUserGroup.Text = "Error : " + ex.Message;
                labelMessageUserGroup.ForeColor = System.Drawing.Color.Red;
            }
            return cardPurchase;
        }



        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                labelMessageUserGroup.Text = string.Empty;
                using (CardPurchaseRT receiverTransfer = new CardPurchaseRT())
                {
                    hdIsEdit.Value = "true";
                    
                    List<CardPurchase> CardPurchaseList = new List<CardPurchase>();
                    CardPurchaseList = receiverTransfer.GetCardPurchaseByCardInfoIdAndMonthNO(Convert.ToInt32(hdCardInfoID.Value), Convert.ToInt32(txtMonthNo.Text));
                    CardPurchase usergrp = CreateCardPurchase();
                    if (CardPurchaseList.Count > 0)
                    {
                        string msg = "Month Number  " + txtMonthNo.Text + " Already Exists in Current Card";
                        //string alertScript =
                        //String.Format("alert('{0}');", msg);
                        //Page.ClientScript.RegisterStartupScript(this.GetType(), "Key", alertScript, true);

                        labelMessageUserGroup.Text = msg;
                        labelMessageUserGroup.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    
                    else if (usergrp != null)
                    {
                        receiverTransfer.UpdateCardPurchase(usergrp);
                        labelMessageUserGroup.Text = "Data successfully updated...";
                        labelMessageUserGroup.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        labelMessageUserGroup.Text = "Data not updated...";
                        labelMessageUserGroup.ForeColor = System.Drawing.Color.Red;
                    }
                }
                ClearField();
                btnVisibilityForCancel();
                LoadCardPurchase();
            }
            catch (Exception ex)
            {
                labelMessageUserGroup.Text = "Error : " + ex.Message;
                labelMessageUserGroup.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void lnkbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton linkButton = new LinkButton();
                linkButton = (LinkButton)sender;
                CardPurchaseRT receiverTransfer = new CardPurchaseRT();
                var cardPurchase = receiverTransfer.GetCardPurchaseByIID(Convert.ToInt32(linkButton.CommandArgument));
                cardPurchase.IsRemoved = true;
                if (cardPurchase != null)
                {
                    receiverTransfer.UpdateCardPurchase(cardPurchase);
                    LoadCardPurchase();
                    labelMessageUserGroup.Text = "Data has been removed successfully.";
                    labelMessageUserGroup.ForeColor = System.Drawing.Color.Green;
                }

            }
            catch (Exception ex)
            {
                labelMessageUserGroup.Text = "Error : " + ex.Message;
                labelMessageUserGroup.ForeColor = System.Drawing.Color.Red;
            }
        }

        
            
        private void btnVisibilityForCancel()
        {
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            btnDelete.Visible = false;
            chkUserGrpIsRemove.Checked = false;
            chkUserGrpIsRemove.Visible = false;

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearField();
            labelMessageUserGroup.Text = "";
            btnVisibilityForCancel();
            Response.Redirect("~/AdminPanel/CardInfoPurchase.aspx");
        }

        private void ClearField()
        {
            txtMonthNo.Text = string.Empty;
            //txtDescription.Text = string.Empty;
            //txtName.Text = string.Empty;
            txtRateOnPurchase.Text = string.Empty;
        }

        protected void lvUserGroup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void lvUserGroup_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "EditUserGroup")
            {
                try
                {
                    labelMessageUserGroup.Text = string.Empty;
                    btnSave.Visible = false;
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    btnCancel.Visible = true;
                    chkUserGrpIsRemove.Visible = true;
                    int cardPurchase = Convert.ToInt32(e.CommandArgument);
                    hdId.Value = cardPurchase.ToString();
                    using (CardPurchaseRT receiverTransfer = new CardPurchaseRT())
                    {
                        CardPurchase card = receiverTransfer.GetCardPurchaseByIID(cardPurchase);
                        FillUserGrpForEdit(card);
                    }
                }
                catch (Exception ex)
                {
                    labelMessageUserGroup.Text = "Error : " + ex.Message;
                    labelMessageUserGroup.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        private void FillUserGrpForEdit(CardPurchase card)
        {
            try
            {
                if (card != null)
                {
                    txtMonthNo.Text = card.MonthNumber.ToString();
                    txtRateOnPurchase.Text = card.RateOnPurchase.ToString();
                    txtUsergrpID.Text = card.IID.ToString();
                    txtNote.Text = card.Note.ToString();
                    if (card.IsRemoved == true)
                    {

                        chkUserGrpIsRemove.Checked = true;

                    }
                    else
                    {
                        chkUserGrpIsRemove.Checked = false;
                    }
                    Session[sessUserGrp] = card;
                }
            }
            catch (Exception ex)
            {
                labelMessageUserGroup.Text = "Error : " + ex.Message;
                labelMessageUserGroup.ForeColor = System.Drawing.Color.Red;
            }
        }

        int lvRowCount = 0;
        int currentPage = 0;
        protected void lvUserGroup_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void dataPagerUserGroup_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    LoadCardPurchase();
                }
            }
            catch (Exception ex)
            {
                labelMessageUserGroup.Text = "Error : " + ex.Message;
                labelMessageUserGroup.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}