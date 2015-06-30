using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OH.BLL.Basic;
using OH.DAL;
using OH.Utilities;

namespace OH.Web
{
    public partial class ManageYourAds : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadDefaultLoginLogout();
                    
                    LoadMaterial(string.Empty, (Session["UserName"].ToString()), string.Empty, string.Empty, string.Empty);
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }

        }


        #region Private Methods


        private void LoadDefaultLoginLogout()
        {
            try
            {
                if (Session["UserName"] == null)
                {
                    Response.Redirect("~/LoginPage.aspx");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        private void LoadMaterial(string catID, string userID, string matCode, string fromDate, string toDate)
        {
            using (MaterialAdGiverRT receiverTransfer = new MaterialAdGiverRT())
            {
                Int64? categoryID;

                DateTime? fD;
                DateTime? tD;


                if (catID != string.Empty || catID != "") { categoryID = Convert.ToInt32(catID); }
                else { categoryID = null; }

                if (matCode == string.Empty || matCode == "")
                {
                    matCode = null;
                }

                if (fromDate != string.Empty || fromDate != "") { fD = Convert.ToDateTime(fromDate); }
                else { fD = null; }

                if (toDate != string.Empty || toDate != "") { tD = Convert.ToDateTime(toDate); }
                else { tD = null; }

                var matList = receiverTransfer.GetSearchedMaterialsForListView(categoryID, userID, matCode, fD, tD);
                if (matList == null) return;

                using (AdGiverRT adGiverRt=new AdGiverRT())
                {
                    string name = adGiverRt.GetAdGiverIDByEmail(Session["UserName"].ToString()).Name;
                    labelAdCount.Text = " Hi "+name+", you currently have " + matList.Count + " adverts";
                    

                }

                lvMaterial.DataSource = matList;
                lvMaterial.DataBind();
      
                
            }
        }

        private void ClearField()
        {
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

                    Response.Redirect("MaterialAdGiverWF.aspx?option=" +StringCipher.Encrypt( matID.ToString().Trim()));
                }
                catch (Exception ex)
                {
                    labelMessage.Text = "Error : " + ex.Message;
                    labelMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            if (e.CommandName == "DeleteMaterial")
            {
                try
                {
                    int matID = Convert.ToInt32(e.CommandArgument);
                    using (MaterialAdminRT aMaterialAdminRt = new MaterialAdminRT())
                    {
                        aMaterialAdminRt.DeleteFromMaterialAndPicAndSaveToLog(matID);
                        labelMessage.Text = "Delete successfull";
                    }
                }
                catch (Exception ex)
                {
                    labelMessage.Text = "Error : " + ex.Message;
                    labelMessage.ForeColor = System.Drawing.Color.Red;
                }
            }

        }

        int lvRowCount = 0;
        int currentPage = 0;

        protected void dataPagerMaterial_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {

                    LoadMaterial(txtCategoryID.Text, (Session["UserName"].ToString()), txtMaterialCode.Text, txtFromDate.Text, txtToDate.Text);
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lvMaterial_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
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


        protected void btnArchive_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("MaterialAdGiverListWF.aspx");
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
            labelMessage.Text = string.Empty;
        }


        #endregion protected Events
    }
}