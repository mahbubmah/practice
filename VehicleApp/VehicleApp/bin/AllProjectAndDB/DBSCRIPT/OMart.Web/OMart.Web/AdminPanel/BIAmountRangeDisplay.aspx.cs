using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Basic;

namespace OMart.Web.AdminPanel
{
    public partial class BIAmountRangeDisplay : System.Web.UI.Page
    {
        private readonly BIAmountRangeRT _biAmountRangeRt;
        int lvRowCount = 0;
        int currentPage = 0;

        public BIAmountRangeDisplay()
        {
            _biAmountRangeRt = new BIAmountRangeRT();
        }

        protected void Page_Load(object sender, EventArgs e)
        {http://localhost:62592/AdminPanel/BIAmountRangeDisplay.aspx.cs
            try
            {
                if (!IsPostBack)
                {
                    LoadBusinessAmountListView();
                }
              
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void LoadBusinessAmountListView()
        {
            try
            {
                var businessAmountRangeList = _biAmountRangeRt.GetAllBusinessAmountRange();
                lvBusinessAmountRange.DataSource = businessAmountRangeList;
                lvBusinessAmountRange.DataBind();
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void dataPagerBusinessAmountRange_OnPreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    LoadBusinessAmountListView();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lvBusinessAmountRange_OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            try
            {
                labelMessage.Text = string.Empty;
                currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("BIAmountRangeInsertUpdate");
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }

        }
        protected void lnkbEdit_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton linkButton = (LinkButton)sender;
                int id = Convert.ToInt32(linkButton.CommandArgument);
                Response.Redirect("BIAmountRangeInsertUpdate?IID=" + id);
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lnkbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton linkButton = new LinkButton();
                linkButton = (LinkButton)sender;
                var objBusinessAmountRange = _biAmountRangeRt.GetBiAbmountRangeByIid(Convert.ToInt32(linkButton.CommandArgument));
                if (objBusinessAmountRange != null)
                {
                    objBusinessAmountRange.IsRemoved = true;
                    _biAmountRangeRt.UpdateAmountRange(objBusinessAmountRange);
                    LoadBusinessAmountListView();

                    labelMessage.Text = "Information has been removed successfully.";
                    labelMessage.ForeColor = System.Drawing.Color.Green;

                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                //crCardInfo reportdocument = new crCardInfo();
                //var cardInfos = _cardInfoRt.GetAllCardInfoList().ToList();
                //Session["reportForm"] = CrystalReportHelper<crCardInfo, CardInfo>.LoadCrystalReport(reportdocument, cardInfos);
                ClientScript.RegisterStartupScript(GetType(), "openwindow", "<script type=text/javascript> window.open('ShowReport'); </script>");
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }

        }

        protected void lnkbPrint_Click(object sender, EventArgs e)
        {
            try
            {
                //LinkButton linkButton = (LinkButton)sender;
                //var objCardInfo = _cardInfoRt.GetCardInfoByID(Convert.ToInt64(linkButton.CommandArgument));

                //crCardInfo reportdocument = new crCardInfo();
                //Session["reportForm"] = CrystalReportHelper<crCardInfo,CardInfo>.LoadCrystalReport(reportdocument, objCardInfo);
                ClientScript.RegisterStartupScript(GetType(), "openwindow", "<script type=text/javascript> window.open('ShowReport'); </script>");
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }


    }
}