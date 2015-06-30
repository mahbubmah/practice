using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OH.BLL.Basic;

namespace OH.Web.ControlAdmin
{
    public partial class MaterialAdminListWF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadMaterial(string.Empty,string.Empty,string.Empty,string.Empty,string.Empty);
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            
        }

       
        #region Private Methods
        private void LoadMaterial(string catID, string adGiverID, string matCode, string fromDate, string toDate)
        {
            using (MaterialAdminRT receiverTransfer = new MaterialAdminRT())
            {
                Int64? categoryID;
                Int64? pstedByID;

                DateTime? fD;
                DateTime? tD;


                if (catID != string.Empty || catID != "") { categoryID = Convert.ToInt32(catID); }
                else { categoryID = null; }

                if (adGiverID != string.Empty || adGiverID != "") { pstedByID = Convert.ToInt32(adGiverID); }
                else { pstedByID = null; }

                if (matCode == string.Empty || matCode == "")
                {
                    matCode = null;
                }

                if (fromDate != string.Empty || fromDate != "") { fD = Convert.ToDateTime(fromDate); }
                else { fD = null; }

                if (toDate != string.Empty || toDate != "") { tD = Convert.ToDateTime(toDate); }
                else { tD = null; }

                var matList = receiverTransfer.GetSearchedMaterialsForListView(categoryID, pstedByID, matCode, fD, tD);
                if (matList == null) return;

                lvMaterial.DataSource = matList;
                lvMaterial.DataBind();

                var matArcList = receiverTransfer.GetSearchedArcMaterialsForListView(categoryID, pstedByID, matCode, fD, tD);
                if (matArcList == null) return;

                lvMaterialArc.DataSource = matArcList;
                lvMaterialArc.DataBind();
            }
        }

        private void ClearField()
        {
            txtAdGiverID.Text = string.Empty;
            txtAdgiver.Text = string.Empty;
            txtCategory.Text = string.Empty;
            txtCategoryID.Text = string.Empty;
            txtFromDate.Text = string.Empty;
            txtMaterialCode.Text = string.Empty;
            txtToDate.Text = string.Empty;
        }
        
        #endregion Private Methods




        #region protected Events
        protected void lvMaterial_ItemCommand(object sender, ListViewCommandEventArgs e)
        {

            if (e.CommandName == "EditMaterial")
            {
                try
                {
                    int matID = Convert.ToInt32(e.CommandArgument);

                     Response.Redirect("MaterialAdminWF.aspx?matID=" + matID);
                }
                catch (Exception ex)
                {
                    labelMessage.Text = "Error : " + ex.Message;
                    labelMessage.ForeColor = System.Drawing.Color.Red;
                }
            }

        }
        protected void lvMaterialLog_ItemCommand(object sender, ListViewCommandEventArgs e)
        {

            if (e.CommandName == "EditMaterial")
            {
                try
                {
                    int matLogID = Convert.ToInt32(e.CommandArgument);

                    Response.Redirect("MaterialAdminWF.aspx?matLogID=" + matLogID);
                }
                catch (Exception ex)
                {
                    labelMessage.Text = "Error : " + ex.Message;
                    labelMessage.ForeColor = System.Drawing.Color.Red;
                }
            }

        }
        
        
        

        protected void dataPagerMaterial_PreRender(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack)
                {

                    LoadMaterial(txtCategoryID.Text, txtAdGiverID.Text,txtMaterialCode.Text , txtFromDate.Text, txtToDate.Text);
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        
        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearField();
        }

      
        #endregion protected Events
    }
}