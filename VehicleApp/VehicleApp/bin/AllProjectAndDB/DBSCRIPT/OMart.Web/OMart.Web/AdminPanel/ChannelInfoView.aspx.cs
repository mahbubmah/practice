using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Basic;
using DAL;

namespace OMart.Web.AdminPanel
{
    public partial class ChannelInfoView : System.Web.UI.Page
    {
        private readonly ChannelInfoRT _ChannelInfoRT;

        int lvRowCount = 0;
        int currentPage = 0;
        public ChannelInfoView()
        {
            this._ChannelInfoRT = new ChannelInfoRT();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showChannelInfoGrid();
            }
        }

        public void showChannelInfoGrid()
        {
            try
            {
                //var llll = _countryRT.GetAllLoanAmntYrScdle().ToList();
                lvChannelInfo.DataSource = _ChannelInfoRT.GetAllChannelInfoForListView();
                lvChannelInfo.DataBind();             
                
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void dataPagerChannelInfo_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    showChannelInfoGrid();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lvChannelInfo_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            labelMessage.Text = string.Empty;
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("ChannelInfoInsertUpdate.aspx?IID=0", false);
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
                Response.Redirect("ChannelInfoInsertUpdate.aspx?IID=" + id, false);
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
                var objChannelInfo = _ChannelInfoRT.GetChannelInfoByIID(Convert.ToInt32(linkButton.CommandArgument));
                if (objChannelInfo != null)
                {
                    objChannelInfo.IsRemoved = true;
                    ChannelInfoRT loanRT = new ChannelInfoRT();
                    loanRT.UpdateChannelInfo(objChannelInfo);
                    showChannelInfoGrid();

                    labelMessage.Text = "ChannelInfo has been removed successfully.";
                    labelMessage.ForeColor = System.Drawing.Color.Green;

                }
                
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

    }
}