using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Basic;

namespace OMart.Web.AdminPanel
{
    public partial class BICategoryDisplay : System.Web.UI.Page
    {
        private readonly BICategoryRT _biCategoryRt;
        int lvRowCount = 0;
        int currentPage = 0;

        public BICategoryDisplay()
        {
            _biCategoryRt = new BICategoryRT();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadBiCategoryListView();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void LoadBiCategoryListView()
        {
            try
            {
                var biCategoryList = _biCategoryRt.GetAllBiCategoryList();
                lvBiCategory.DataSource = biCategoryList;
                lvBiCategory.DataBind();
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }


        protected void dataPagerBiCategory_OnPreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    LoadBiCategoryListView();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lvBiCategory_OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
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
                Response.Redirect("BICategoryInsertUpdate");
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
                long id = Convert.ToInt64(linkButton.CommandArgument);
                Response.Redirect("BICategoryInsertUpdate.aspx?IID=" + id);
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
                var objBiCategory = _biCategoryRt.GetBiCategoryByIid(Convert.ToInt64(linkButton.CommandArgument));
                if (objBiCategory != null)
                {
                    objBiCategory.IsRemoved = true;
                    _biCategoryRt.UpdateBiCategory(objBiCategory);
                    LoadBiCategoryListView();

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