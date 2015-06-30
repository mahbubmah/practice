using BLL.Basic;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMart.Web.AdminPanel
{
    public partial class GuideLineWithDetails : System.Web.UI.Page
    {
         #region variable declaration
        private readonly GuideLineWithDetailsRT _GuideLineDetailRT;
        int lvRowCount = 0;
        int currentPage = 0;
        #endregion variable declaration

        #region protected mathod
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            { 
                if(!IsPostBack)
                {
                    showguideLineInListView();
                }
            }
            catch(Exception ex)
            {
            
            }
        }
        public GuideLineWithDetails()
        {
            _GuideLineDetailRT = new GuideLineWithDetailsRT();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("GuideLineWithDetailsInsertUpdate.aspx?IID=0");
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
                Response.Redirect("GuideLineWithDetailsInsertUpdate.aspx?IID=" + id);
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
                var guideLine = _GuideLineDetailRT.GetguideLineByIID(Convert.ToInt32(linkButton.CommandArgument));
                if (guideLine != null)
                {
                    guideLine.IsRemoved = true;
                    _GuideLineDetailRT.UpdateguideLine(guideLine);
                    showguideLineInListView();
                    labelMessage.Text = "GuideLine Information has been removed successfully.";
                    labelMessage.ForeColor = System.Drawing.Color.Green;

                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void dataPagerguideLine_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    showguideLineInListView();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lvguideLine_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            labelMessage.Text = string.Empty;
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void lvguideLine_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    showguideLineInListView();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
#endregion protected method


        #region private method

        private void showguideLineInListView()
        {
            try
            {
                lvGuideLine.DataSource = _GuideLineDetailRT.GetAllguideLineForDisplay();
                lvGuideLine.DataBind();
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        #endregion private method

      
    }
}