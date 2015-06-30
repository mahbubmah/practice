using BLL.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OB.Web.BookAdmin
{
    public partial class BookDisplay : System.Web.UI.Page
    {
          private readonly BookRT _BookRT;

        int lvRowCount = 0;
        int currentPage = 0;
        public BookDisplay()
        {
            this._BookRT = new BookRT();
        }

        protected void Page_Load(object sender, EventArgs e)
        {try
            {
              
            if (!IsPostBack)
            {

                showBookGrid();
            }
                 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void showBookGrid()
        {
            try
            {
                var list = _BookRT.GetAllBookInforrmations();
                lvBookDisplay.DataSource = list;
                lvBookDisplay.DataBind();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error : " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void dataPagerBookDisplay_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    showBookGrid();
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error : " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lvBookDisplay_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            lblMessage.Text = string.Empty;
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("BookInsertUpdate.aspx?IID=0",false);
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error : " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lnkbEdit_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton linkButton = (LinkButton)sender;
                int id = Convert.ToInt32(linkButton.CommandArgument);
                Response.Redirect("BookInsertUpdate.aspx?IID=" + id);
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error : " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lnkbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton linkButton = new LinkButton();
                linkButton = (LinkButton)sender;
                var objBook = _BookRT.GetBookByIID(Convert.ToInt64(linkButton.CommandArgument));
                if (objBook != null)
                {
                    objBook.IsRemoved = true;
                    _BookRT.UpdateBook(objBook);
                    showBookGrid();

                    lblMessage.Text = "Book has been removed successfully.";
                    lblMessage.ForeColor = System.Drawing.Color.Green;

                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error : " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }

    }
