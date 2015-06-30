using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Basic;

namespace OMart.Web.AdminPanel
{
    public partial class GasCylienderDisplay : System.Web.UI.Page
    {

        private readonly GasRT _gasRt;

        int lvRowCount = 0;
        int currentPage = 0;
        public GasCylienderDisplay()
        {
            this._gasRt = new GasRT();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowGasCylienderGrid();
            }
        }

        private void ShowGasCylienderGrid()
        {
            try
            {
                lvGasCyliender.DataSource = _gasRt.GetGasCyliendersForListViewDisplay();
                lvGasCyliender.DataBind();
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
                Response.Redirect("GasInsertUpdate");
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
                Int64 id = Convert.ToInt64(linkButton.CommandArgument);
                Response.Redirect("GasInsertUpdate.aspx?IID=" + id);
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
                var objGasCyliender = _gasRt.GetGasCylienderByIid(Convert.ToInt64(linkButton.CommandArgument));
                if (objGasCyliender != null)
                {
                    objGasCyliender.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                    objGasCyliender.ModifiedDate = GlobalRT.GetServerDateTime();
                    objGasCyliender.IsRemoved = true;
                    _gasRt.UpdateGasCylinder(objGasCyliender);

                    //delete All News detail by card info iid
                    var mappingListByCylienderId = _gasRt.GetCylienderAndDealerMappingListByCylienderId(objGasCyliender.IID);
                    foreach (var map in mappingListByCylienderId)
                    {
                        map.ModifiedBy = Convert.ToInt64(Session["UserID"]);
                        map.ModifiedDate = GlobalRT.GetServerDateTime();
                        map.IsRemoved = true;
                        _gasRt.UpdateGasCylinderAndDealerInfoMapping(map);
                    }


                    ShowGasCylienderGrid();

                    labelMessage.Text = "Inforamion has been removed successfully.";
                    labelMessage.ForeColor = System.Drawing.Color.Green;

                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void dataPagerGasCyliender_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    ShowGasCylienderGrid();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lvGasCyliender_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            labelMessage.Text = string.Empty;
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }
    }
}