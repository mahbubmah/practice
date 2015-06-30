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
    public partial class LIApplicableFeatureView : System.Web.UI.Page
    {
        private readonly LIApplicableFeatureRT _LIApplicableFeatureRT;

        int lvRowCount = 0;
        int currentPage = 0;
        public LIApplicableFeatureView()
        {
            this._LIApplicableFeatureRT = new LIApplicableFeatureRT();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showLiSchemaGrid();
            }
        }

        public void showLiSchemaGrid()
        {
            try
            {
                //var llll = _countryRT.GetAllLoanAmntYrScdle().ToList();
                lvLiSchema.DataSource = _LIApplicableFeatureRT.GetAllLiApplicableFeature().ToList();
                lvLiSchema.DataBind();             
                
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void dataPagerLiSchema_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    showLiSchemaGrid();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lvLiSchema_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            labelMessage.Text = string.Empty;
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("LIApplicableFeatureInsertUpdate.aspx?IID=0", false);
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
                Response.Redirect("LIApplicableFeatureInsertUpdate.aspx?IID=" + id, false);
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
                var objLiSchema = _LIApplicableFeatureRT.GetAddLiApplicableFeatureByIID(Convert.ToInt32(linkButton.CommandArgument));
                if (objLiSchema != null)
                {
                    objLiSchema.IsRemoved = true;
                    LIApplicableFeatureRT loanRT = new LIApplicableFeatureRT();
                    loanRT.UpdateLiApplicableFeature(objLiSchema);
                    showLiSchemaGrid();

                    labelMessage.Text = "LiSchema has been removed successfully.";
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