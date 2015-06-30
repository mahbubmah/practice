using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OH.BLL.Basic;
using OH.DAL;
using OH.Utilities;

namespace OH.Web.ControlAdmin
{
    public partial class AdGiverTracingUpdateWF : System.Web.UI.Page
    {
        /// <summary>
        /// Asiful Islam
        /// </summary>
        private const string sessAddGiverTracing = "seAddGiverTracing";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    LoadAdGiverTracingUpdate();
                    btnUpdate.Visible = false;
                    btnCancel.Visible = false;
                    txtUpdateAdGiverID.Visible = false;
                    txtUpdateBrowserNameID.Visible = false;
                    txtUpdateBrowsingTime.Visible = false;
                    txtUpdateIPAddress.Visible = false;
                    txtUpdateMACAddress.Visible = false;
                    txtUpdateMaterialID.Visible = false;
                    pnlAddGiverUpdate.Visible = false;
                }
                catch (Exception ex)
                {
                    labelMessageUpdateAddGiverTracing.Text = "Error : " + ex.Message;
                    labelMessageUpdateAddGiverTracing.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        private void LoadAdGiverTracingUpdate()
        {
            try
            {
                using (AddGiverTracingRT receiverTransfer = new AddGiverTracingRT())
                {
                    lvUpdateAdGiver.DataSource = receiverTransfer.GetAdGiverTracingAllForListView();
                    lvUpdateAdGiver.DataBind();
                }
            }
            catch (Exception ex)
            {
                labelMessageUpdateAddGiverTracing.Text = "Error : " + ex.Message;
                labelMessageUpdateAddGiverTracing.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // labelMessage.Text = string.Empty;
                using (AddGiverTracingRT receiverTransfer = new AddGiverTracingRT())
                {
                    hdIsEdit.Value = "true";
                    AdGiverTracing adGiverTracing = CreateadGiverTracing();

                    if (adGiverTracing != null)
                    {
                        receiverTransfer.UpdateadGiverTracing(adGiverTracing);
                        labelMessageUpdateAddGiverTracing.Text = "Data successfully updated...";
                        labelMessageUpdateAddGiverTracing.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        labelMessageUpdateAddGiverTracing.Text = "Data not updated...";
                        labelMessageUpdateAddGiverTracing.ForeColor = System.Drawing.Color.Red;
                    }
                }
                ClearField();
                LoadAdGiverTracingUpdate();
                pnlAddGiverUpdate.Visible = false;
            }
            catch (Exception ex)
            {
                labelMessageUpdateAddGiverTracing.Text = "Error : " + ex.Message;
                labelMessageUpdateAddGiverTracing.ForeColor = System.Drawing.Color.Red;
            }
        }

 

        private void ClearField()
        {
            txtUpdateAdGiverID.Text = string.Empty;
            txtUpdateBrowserNameID.Text = string.Empty;
            txtUpdateBrowsingTime.Text = string.Empty;
            txtUpdateIPAddress.Text = string.Empty;
            txtUpdateMACAddress.Text = string.Empty;
            txtUpdateMaterialID.Text = string.Empty;
            chkAdgiverTracingActv.Checked = false;
        }

        private AdGiverTracing CreateadGiverTracing()
        {
            Session["UserID"] = "1";
            AdGiverTracing adGiverTracing = new AdGiverTracing();
            try
            {
                if (hdIsEdit.Value == "true")
                {
                    adGiverTracing.IID = Convert.ToInt32(hdUpdateAdGiverID.Value.ToString());
                }

                adGiverTracing.AdGiverID = Convert.ToInt32(txtUpdateAdGiverID.Text);
                adGiverTracing.MaterialID = Convert.ToInt32(txtUpdateMaterialID.Text);
                adGiverTracing.IPAddress = txtUpdateIPAddress.Text;
                adGiverTracing.MACAddress = txtUpdateMACAddress.Text;
                adGiverTracing.BrowserNameID = Convert.ToInt32(txtUpdateBrowserNameID.Text);
                adGiverTracing.BrowsingTimeDuration = txtUpdateBrowsingTime.Text;
                if (adGiverTracing.IID <= 0)
                {
                    adGiverTracing.CreatedBy = Convert.ToInt64(Session["UserID"]);
                    adGiverTracing.CreatedDate = GlobalRT.GetServerDateTime();
                }
                else
                {
                    AdGiverTracing adgivrtracng = (AdGiverTracing)Session[sessAddGiverTracing];
                    adGiverTracing.CreatedBy = adgivrtracng.CreatedBy; ;
                    adGiverTracing.CreatedDate = adgivrtracng.CreatedDate;
                }
                if ((hdIsEdit.Value == "true" && chkAdgiverTracingActv.Checked != true))
                {
                    adGiverTracing.IsRemoved = false;
                }
                else if ((hdIsEdit.Value == "true" && chkAdgiverTracingActv.Checked == true))
                {
                    adGiverTracing.IsRemoved = true;
                }
            }
            catch (Exception ex)
            {
                labelMessageUpdateAddGiverTracing.Text = "Error : " + ex.Message;
                labelMessageUpdateAddGiverTracing.ForeColor = System.Drawing.Color.Red;
            }
            return adGiverTracing;
        }

        protected void lvUpdateAdGiver_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "EditUpdateAdGiver")
            {
                try
                {
                    labelMessageUpdateAddGiverTracing.Text = string.Empty;
                    labelVisibility();
                    TextBoxVisibility();
                    panelVisibility();
                    btnUpdate.Visible = true;
                    
                    btnCancel.Visible = true;
                    int AddGiverTracingID = Convert.ToInt32(e.CommandArgument);
                    hdUpdateAdGiverID.Value = AddGiverTracingID.ToString();
                    using (AddGiverTracingRT receiverTransfer = new AddGiverTracingRT())
                    {
                        AdGiverTracing adgivrtracing = receiverTransfer.GetAddGiverTracingIID(AddGiverTracingID);
                        FillAddGiverTracingForEdit(adgivrtracing);
                    }
                }
                catch (Exception ex)
                {
                    labelMessageUpdateAddGiverTracing.Text = "Error : " + ex.Message;
                    labelMessageUpdateAddGiverTracing.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        private void FillAddGiverTracingForEdit(AdGiverTracing adgivrtracing)
        {
            try
            {
                if (adgivrtracing != null)
                {
                    //DropDownTypeID.SelectedValue = usergrp.TypeID.ToString();
                    txtUpdateAdGiverID.Text = adgivrtracing.AdGiverID.ToString();
                    txtUpdateMaterialID.Text = adgivrtracing.MaterialID.ToString();
                    txtUpdateIPAddress.Text = adgivrtracing.IPAddress;
                    txtUpdateMACAddress.Text = adgivrtracing.MACAddress.ToString();
                    txtUpdateBrowserNameID.Text = adgivrtracing.BrowserNameID.ToString();
                    txtUpdateBrowsingTime.Text = adgivrtracing.BrowsingTimeDuration.ToString();
                    if (adgivrtracing.IsRemoved == true)
                    {

                        chkAdgiverTracingActv.Checked = true;

                    }
                    else
                    {
                        chkAdgiverTracingActv.Checked = false;
                    }
                    Session[sessAddGiverTracing] = adgivrtracing;
                }
            }
            catch (Exception ex)
            {
                labelMessageUpdateAddGiverTracing.Text = "Error : " + ex.Message;
                labelMessageUpdateAddGiverTracing.ForeColor = System.Drawing.Color.Red;
            }
        }

        public void labelVisibility()
        {
            lblBrowserName.Text = "Browser Name";
            lblBrowsingTime.Text="Browser Start Time";
            lblForAddGiver.Text = "Add Giver ID";
            lblForLagendUpdate.Text = "Update Add Giver Tracing";
            lblForMaterial.Text = "Material ID";
            lblIPAddress.Text = "IP Address";
            lblMACAddress.Text = "MAC Address";
        }
        public void TextBoxVisibility()
        {
            txtUpdateAdGiverID.Visible = true;
            txtUpdateBrowserNameID.Visible = true;
            txtUpdateBrowsingTime.Visible = true;
            txtUpdateIPAddress.Visible = true;
            txtUpdateMACAddress.Visible = true;
            txtUpdateMaterialID.Visible = true;

        }
        public void panelVisibility()
        {
            pnlAddGiverUpdate.Visible = true;
        
        }

        int lvRowCount = 0;
        int currentPage = 0;
        protected void lvUpdateAdGiver_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void dataPagerUpdateAdGiver_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    LoadAdGiverTracingUpdate();
                }
            }
            catch (Exception ex)
            {
                labelMessageUpdateAddGiverTracing.Text = "Error : " + ex.Message;
                labelMessageUpdateAddGiverTracing.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            pnlAddGiverUpdate.Visible = false;
            ClearField();
            labelMessageUpdateAddGiverTracing.Text = "";
        }
    }
}