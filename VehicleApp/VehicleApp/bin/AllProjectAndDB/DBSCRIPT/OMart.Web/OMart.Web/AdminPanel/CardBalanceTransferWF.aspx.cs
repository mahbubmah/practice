using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Basic;
using DAL;
using Utilities;
using System.Data.SqlClient;
using OMart.Web.AdminPanel.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;




namespace OMart.Web.AdminPanel
{
    public partial class CardBalanceTransferWF : System.Web.UI.Page
    {
        private const string sessCardBalanceTransfer = "seCardBalanceTransfer";
        private readonly BalanceTransferRT receiverTransfer;

        public CardBalanceTransferWF()
        {
            receiverTransfer = new BalanceTransferRT();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    loadCardBalanceTransferInfo();
                    loadDropDownCardName(null);
                    btnSave.Visible = true;
                    btnDelete.Visible = false;
                    btnUpdate.Visible = false;
                    btnCancel.Visible = false;
                }
                catch (Exception ex)
                {
                    labelMessageBalance.Text = "Error: " + ex.Message;
                    labelMessageBalance.ForeColor = System.Drawing.Color.Red;
                }
            }        
        }

        private void loadCardBalanceTransferInfo()
        {
            try
            {
                using (BalanceTransferRT receiverTransfer = new BalanceTransferRT())
                {
                    lv_CardBalanceTransfer.DataSource = receiverTransfer.GetCardBalanceTransferAll();
                    lv_CardBalanceTransfer.DataBind();
                }
            }
            catch (Exception ex)
            {
                labelMessageBalance.Text = "Error : " + ex.Message;
                labelMessageBalance.ForeColor = System.Drawing.Color.Red;
            }
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



        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                labelMessageBalance.Text = string.Empty;
                using (BalanceTransferRT receiverTransfer = new BalanceTransferRT())
                {
                    //List<CardBalanceTransfer> cardBalanceTransfer = new List<CardBalanceTransfer>();
                    //Int32 cardID = Convert.ToInt32(ddCardName.SelectedValue);
                    //cardBalanceTransfer = receiverTransfer.GetCardBalanceTransferInfoByCardNameAndMonth(cardID, txtMonthNumber.Text);
                    //if(cardBalanceTransfer!=null && cardBalanceTransfer.Count>0)
                    //{
                    //    string msg = "Card Name "+ddCardName.SelectedItem+"&\n"+"Month Number "+txtMonthNumber.Text+"Already Exists";
                    //    labelMessageBalance.Text=msg;
                    //    labelMessageBalance.ForeColor=System.Drawing.Color.Red;
                    //    return;
                    //}

                    CardBalanceTransfer balanceTransfer = CreateCardBalanceTransfer();
                    receiverTransfer.AddCardBalanceTransefer(balanceTransfer);
                    if (balanceTransfer.IID > 0)
                    {
                        labelMessageBalance.Text = "Data successfully saved...";
                        labelMessageBalance.ForeColor = System.Drawing.Color.Green;
                    }
                }

                ClearField();
                loadCardBalanceTransferInfo();

            }
            catch (Exception ex)
            {
                labelMessageBalance.Text = "Error : " + ex.Message;
                labelMessageBalance.ForeColor = System.Drawing.Color.Red;
            }
        }

        private CardBalanceTransfer CreateCardBalanceTransfer()
        {
            Session["UserID"] = "1";
            CardBalanceTransfer cardInfo = new CardBalanceTransfer();
            try
            {
                if (hdIsEdit.Value == "true")
                {
                    cardInfo.IID = Convert.ToInt32(hdCardBalanceTransferID.Value.ToString());
                }

                cardInfo.CardInfoID = Convert.ToInt32(ddCardName.SelectedValue);
                cardInfo.MonthNumber = Convert.ToInt32(txtMonthNumber.Text);
                cardInfo.TransferFeePercent = Convert.ToDecimal(txtTransferPercentFee.Text);
                cardInfo.Note = txtNote.Text;


                //if (chkIsActive.Checked == true)
                //{
                //    userInfo.IsActiveUser = true;
                //}
                //else
                //{
                //    userInfo.IsActiveUser = false;
                //}

                if (cardInfo.IID <= 0)
                {
                    cardInfo.CreatedBy = Convert.ToInt64(Session["UserID"]);
                    cardInfo.CreatedDate = GlobalRT.GetServerDateTime();
                }
                else
                {
                    CardBalanceTransfer balance = (CardBalanceTransfer)Session[sessCardBalanceTransfer];
                    cardInfo.CreatedBy = balance.CreatedBy; ;
                    cardInfo.CreatedDate = balance.CreatedDate;
                    cardInfo.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                    cardInfo.ModifiedDate = GlobalRT.GetServerDateTime();
                }

                if (hdIsDelete.Value == "true")
                {
                    cardInfo.IsRemoved = true;
                    hdIsDelete.Value = "false";

                }
                else
                {
                    cardInfo.IsRemoved = false;
                }

            }
            catch (Exception ex)
            {
                labelMessageBalance.Text = "Error : " + ex.Message;
                labelMessageBalance.ForeColor = System.Drawing.Color.Red;
            }
            return cardInfo;
        }

        private void ClearField()
        {
            ddCardName.SelectedIndex = 0;
            txtMonthNumber.Text = string.Empty;
            txtTransferPercentFee.Text = string.Empty;
            txtNote.Text = string.Empty;
        }



        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                labelMessageBalance.Text = string.Empty;
                using (BalanceTransferRT receiverTransfer = new BalanceTransferRT())
                {
                    hdIsEdit.Value = "true";

                    List<CardBalanceTransfer> cardBalanceList = new List<CardBalanceTransfer>();
                    Int32 cardID = Convert.ToInt32(ddCardName.SelectedValue);
                    Int32 monthNumber = Convert.ToInt32(hdCardBalanceTransferID.Value.ToString());
                    Int32 balancetransferRate = Convert.ToInt32(txtTransferPercentFee.Text);
                    string note = txtNote.Text;
                    cardBalanceList = receiverTransfer.GetCardBalanceInfoByGivenCardInfo(cardID, monthNumber, balancetransferRate, note);

                    if (cardBalanceList != null && cardBalanceList.Count > 0)
                    {
                        string msg = "Card Name  " + "'" + ddCardName.SelectedItem + "'" + " And\n" + " Month Name " + "'" + txtMonthNumber.Text + "'" + " Already Exists!";
                        labelMessageBalance.Text = msg;
                        labelMessageBalance.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    CardBalanceTransfer cardbalance = CreateCardBalanceTransfer();

                    if (cardbalance != null)
                    {
                        receiverTransfer.UpdateCardBalanceTransfer(cardbalance);
                        labelMessageBalance.Text = "Data successfully updated...";
                        labelMessageBalance.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        labelMessageBalance.Text = "Data not updated...";
                        labelMessageBalance.ForeColor = System.Drawing.Color.Red;
                    }
                }
                btnSave.Visible = true;
                btnUpdate.Visible = false;
                btnCancel.Visible = false;
                btnDelete.Visible = false;
                ClearField();
                loadCardBalanceTransferInfo();
            }
            catch (Exception ex)
            {
                labelMessageBalance.Text = "Error : " + ex.Message;
                labelMessageBalance.ForeColor = System.Drawing.Color.Red;

            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                labelMessageBalance.Text = string.Empty;
                using (BalanceTransferRT receiverTransfer = new BalanceTransferRT())
                {
                    hdIsDelete.Value = "true";
                    hdIsEdit.Value = "true";
                    CardBalanceTransfer balance = CreateCardBalanceTransfer();

                    if (balance != null)
                    {

                        receiverTransfer.UpdateCardBalanceTransfer(balance);
                        labelMessageBalance.Text = "Data successfully deleted...";
                        labelMessageBalance.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        labelMessageBalance.Text = "Data not deleted...";
                        labelMessageBalance.ForeColor = System.Drawing.Color.Red;
                    }
                }
                btnSave.Visible = true;
                btnUpdate.Visible = false;
                btnCancel.Visible = false;
                btnDelete.Visible = false;
                loadCardBalanceTransferInfo();
                ClearField();
            }
            catch (Exception ex)
            {
                labelMessageBalance.Text = "Error : " + ex.Message;
                labelMessageBalance.ForeColor = System.Drawing.Color.Red;
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

        protected void lnkbEdit_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton linkButton = (LinkButton)sender;
                int id = Convert.ToInt32(linkButton.CommandArgument);
                btnSave.Visible = false;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnCancel.Visible = true;

                hdCardBalanceTransferID.Value = id.ToString();
                using (BalanceTransferRT receiverTransfer = new BalanceTransferRT())
                {
                    CardBalanceTransfer cardbalance = receiverTransfer.GetCardBalanceInfoByID(id);
                    FillCardBalanceForEdit(cardbalance);
                }
                //LoadUserInfo()
            }
            catch (Exception ex)
            {
                labelMessageBalance.Text = "Error : " + ex.Message;
                labelMessageBalance.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void FillCardBalanceForEdit(CardBalanceTransfer cardbalance)
        {
            try
            {
                if (cardbalance != null)
                {
                    ddCardName.SelectedValue = cardbalance.CardInfoID.ToString();
                    txtMonthNumber.Text = cardbalance.MonthNumber.ToString();
                    txtTransferPercentFee.Text = cardbalance.TransferFeePercent.ToString();
                    txtNote.Text = cardbalance.Note.ToString();
                    Session[sessCardBalanceTransfer] = cardbalance;
                }
            }
            catch (Exception ex)
            {
                labelMessageBalance.Text = "Error : " + ex.Message;
                labelMessageBalance.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lnkbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton linkButton = new LinkButton();
                linkButton = (LinkButton)sender;
                BalanceTransferRT receiverTransfer = new BalanceTransferRT();
                var balanceInformation = receiverTransfer.GetCardBalanceTransferInfoByID(Convert.ToInt32(linkButton.CommandArgument));
                balanceInformation.IsRemoved = true;
                if (balanceInformation != null)
                {
                    receiverTransfer.UpdateCardBalanceTransfer(balanceInformation);
                    loadCardBalanceTransferInfo();
                    labelMessageBalance.Text = "Card Balance Information has been removed successfully.";
                    labelMessageBalance.ForeColor = System.Drawing.Color.Green;
                }

            }
            catch (Exception ex)
            {
                labelMessageBalance.Text = "Error : " + ex.Message;
                labelMessageBalance.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void lv_CardBalanceTransfer_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {

        }

        protected void lv_CardBalanceTransfer_ItemCommand(object sender, ListViewCommandEventArgs e)
        {

        }

        protected void dataPagerlv_CardBalanceTransfer_PreRender(object sender, EventArgs e)
        {

        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            SqlConnection CN;
            string myConnectionstring = null;
            myConnectionstring = "Data Source=192.168.1.2; Initial Catalog=OiiOMart_Live;Persist Security Info=True;User ID=sa;Password=oIIoAdmin";
            CN = new SqlConnection(myConnectionstring);
            CN.Open();

            string list = null;

            list = receiverTransfer.GetCardBalanceTransferAllForReport().ToString();

            
           // SQL = "SELECT * FROM CardBalanceTransfer";

            SqlDataAdapter myDA = new SqlDataAdapter(list, CN);

            CN.Close();

            //DataSetCardBalanceTransfer DS = new DataSetCardBalanceTransfer();
            //myDA.Fill(DS, "CardBalanceTransfer");


            //ReportDocument myrpt = new ReportDocument();
            //myrpt.Load(Server.MapPath("~/AdminPanel/CrystalReports/CrystalReportCardBalanceTransfer.rpt"));
            //myrpt.SetDataSource(DS);

            //rptBalanceTransfer.ReportSource = myrpt;

        }


    }
}