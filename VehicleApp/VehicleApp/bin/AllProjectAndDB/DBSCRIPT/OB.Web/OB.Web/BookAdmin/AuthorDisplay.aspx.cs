using BLL.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OB.Web.BookAdmin
{
    public partial class AuthorDisplay : System.Web.UI.Page
    {
         private readonly BookAuthorRT _BookAuthorRT;

        int lvRowCount = 0;
        int currentPage = 0;
        public AuthorDisplay()
        {
            this._BookAuthorRT = new BookAuthorRT();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showAuthorGrid();
            }
        }

        private void showAuthorGrid()
        {
            try
            {
                lvAuthor.DataSource = _BookAuthorRT.GetAllBookAuthorsForShow();
                lvAuthor.DataBind();
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void dataPagerAuthor_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    showAuthorGrid();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lvAuthor_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            labelMessage.Text = string.Empty;
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("AuthorInsertUpdate.aspx?IID=0");
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
                Response.Redirect("AuthorInsertUpdate.aspx?IID=" + id);
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
                var objAuthor = _BookAuthorRT.GetBookAuthorByIID(Convert.ToInt32(linkButton.CommandArgument));
                if (objAuthor != null)
                {
                    objAuthor.IsRemoved = true;
                    _BookAuthorRT.UpdateBookAuthor(objAuthor);
                    showAuthorGrid();

                    labelMessage.Text = "Author has been removed successfully.";
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