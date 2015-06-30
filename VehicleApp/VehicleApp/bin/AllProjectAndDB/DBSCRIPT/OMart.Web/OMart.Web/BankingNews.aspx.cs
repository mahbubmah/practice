using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using BLL.Basic;
using System.Web.UI.WebControls;

public partial class BankingNews : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                GettingCurrentUrl();

                LoadBankingNewsLoans();

            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    private void LoadBankingNewsLoans()
    {
        try
        {
            BankingInformationRT _BankingInformationRT = new BankingInformationRT();
            var objLoans = _BankingInformationRT.GetAllLoanType().Take(10).ToList();
            if (objLoans.Count > 0)
            {
              //  rpLoans.DataSource = objLoans;
               // rpLoans.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
    private void GettingCurrentUrl()
    {
        string currentURL = HttpContext.Current.Request.Url.AbsoluteUri;
        Session["backURL"] = currentURL;
    }

    protected void rpLoans_OnItemDataBound(object source, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {


                Literal objltrLoan = (Literal)e.Item.FindControl("lblLoanTypeID");
                objltrLoan.Text = objltrLoan.Text.Trim();
                //if (objltrLoan.Text.Length > 30)
                //{
                //    var text = objltrLoan.Text.Substring(0, 30);
                //    objltrLoan.Text = text;

                //}

            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

}