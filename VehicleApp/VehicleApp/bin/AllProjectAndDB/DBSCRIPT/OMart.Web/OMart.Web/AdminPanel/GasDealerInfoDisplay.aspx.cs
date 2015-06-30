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
    public partial class GasDealerInfoDisplay : System.Web.UI.Page
    {
        private readonly GasDealerInfoRT _GasDealerInfoRT;

        int lvRowCount = 0;
        int currentPage = 0;

        public GasDealerInfoDisplay()
        {
            _GasDealerInfoRT=new GasDealerInfoRT();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                ShowGasDealerInfoList();
            }
        }

        private void ShowGasDealerInfoList()
        {
            try
            {
                
                lvGasDealerInfo.DataSource = _GasDealerInfoRT.GetGasDealAllForListView();
                lvGasDealerInfo.DataBind();
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lvGasDealerInfo_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {

        }

        protected void dataPagerGasDealer_PreRender(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("GasDealerInfoWF.aspx");
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
                Response.Redirect("GasDealerInfoWF.aspx?IID=" + id);
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
                LinkButton linkButton = (LinkButton)sender;
                int id = Convert.ToInt32(linkButton.CommandArgument);
                var gasDeal = _GasDealerInfoRT.GetGasDealInfoByID(id);
                
                if (gasDeal != null)
                {
                    gasDeal.IsRemoved = true;
                    _GasDealerInfoRT.UpdateGasDealInfo(gasDeal);
                  
                    ShowGasDealerInfoList();

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
    }

}