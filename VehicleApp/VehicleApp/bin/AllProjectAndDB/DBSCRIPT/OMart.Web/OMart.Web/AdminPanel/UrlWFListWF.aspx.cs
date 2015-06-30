using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;
using BLL.Basic;

namespace OMart.Web.AdminPanel
{
    public partial class UrlWFListWF : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadUrlWFList();
        }

        public void LoadUrlWFList()
        {
            
            try
            {
                UrlWFListRT reciveTransfer = new UrlWFListRT();
                lvUrlWFList.DataSource = reciveTransfer.GetUrlWFListAllForListView();
                lvUrlWFList.DataBind();
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        int lvRowCount = 0;
        int currentPage = 0;
        protected void lvUrlWFList_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void dataPagerUrlWFList_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    LoadUrlWFList();
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