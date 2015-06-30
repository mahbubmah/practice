using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;
using BLL.Basic;
using DAL.Basic;
using Utilities;


namespace OMart.Web.AdminPanel
{
    public partial class CardRegionWiseFeeDisplay : System.Web.UI.Page
    {
        private readonly CardRegionWiseFeeRT cardRegionWiseFeeRT;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadCardRegionWiseFee();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("CardRegionWiseFeeInsertUpdate.aspx?ID=0");
            }
            catch (Exception ex)
            {
                labelMessageCardRegionWiseFeeDisplay.Text = "Error : " + ex.Message;
                labelMessageCardRegionWiseFeeDisplay.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void lnkbEdit_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton linkButton = (LinkButton)sender;
                int id = Convert.ToInt32(linkButton.CommandArgument);
               
                Response.Redirect("CardRegionWiseFeeInsertUpdate.aspx?IID=" + id);

            }
            catch (Exception ex)
            {
                labelMessageCardRegionWiseFeeDisplay.Text = "Error : " + ex.Message;
                labelMessageCardRegionWiseFeeDisplay.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lnkbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton linkButton = new LinkButton();
                linkButton = (LinkButton)sender;
                var objCardRegionFee = cardRegionWiseFeeRT.GetCardRegionFeeByIID(Convert.ToInt32(linkButton.CommandArgument));
                if (objCardRegionFee != null)
                {
                    objCardRegionFee.IsRemoved = true;
                    cardRegionWiseFeeRT.UpdateCardRegionFee(objCardRegionFee);
                    LoadCardRegionWiseFee();

                    labelMessageCardRegionWiseFeeDisplay.Text = "Country has been removed successfully.";
                    labelMessageCardRegionWiseFeeDisplay.ForeColor = System.Drawing.Color.Green;

                }
            }
            catch (Exception ex)
            {
                labelMessageCardRegionWiseFeeDisplay.Text = "Error : " + ex.Message;
                labelMessageCardRegionWiseFeeDisplay.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lv_CardRegionWiseFee_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        int lvRowCount = 0;
        int currentPage = 0;
        protected void dataPagerlv_CardRegionWiseFee_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    LoadCardRegionWiseFee();
                }
            }
            catch (Exception ex)
            {
                labelMessageCardRegionWiseFeeDisplay.Text = "Error : " + ex.Message;
                labelMessageCardRegionWiseFeeDisplay.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void LoadCardRegionWiseFee()
        {
            try
            {
                using (CardRegionWiseFeeRT receiverTransfer = new CardRegionWiseFeeRT())
                {

                    lv_CardRegionWiseFee.DataSource = receiverTransfer.GetALLCardRegionWiseFeeListView(); ;
                    lv_CardRegionWiseFee.DataBind();
                }
            }
            catch (Exception ex)
            {
                labelMessageCardRegionWiseFeeDisplay.Text = "Error : " + ex.Message;
                labelMessageCardRegionWiseFeeDisplay.ForeColor = System.Drawing.Color.Red;
            }

        }

        protected void lv_CardRegionWiseFee_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            //if (e.CommandName == "EditUserInfo")
            //{
            //    labelMessageCardRegionWiseFeeDisplay .Text = string.Empty;
            //    try
            //    {
            //        btnSave.Visible = false;
            //        btnUpdate.Visible = true;
            //        btnDelete.Visible = true;
            //        btnCancel.Visible = true;
            //        int userInfoID = Convert.ToInt32(e.CommandArgument);
            //        hdUserInfoID.Value = userInfoID.ToString();
            //        using (UserInformationRT receiverTransfer = new UserInformationRT())
            //        {
            //            UserInfo userInfo = receiverTransfer.GetUserInfoByID(userInfoID);
            //            FillUserInfoForEdit(userInfo);
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        labelMessageUserInfo.Text = "Error : " + ex.Message;
            //        labelMessageUserInfo.ForeColor = System.Drawing.Color.Red;
            //    }
            //}
        }
    }
}