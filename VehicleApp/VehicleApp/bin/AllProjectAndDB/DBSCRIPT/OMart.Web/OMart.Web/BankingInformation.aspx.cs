using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Basic;

namespace OMart.Web
{
    public partial class BankingInformation : System.Web.UI.Page
    {
        private Int64 IID = default(Int64);
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    GettingCurrentUrl();
                    LoadBankingNews();
                    LoadBankingNewsLoans();
                    LoadBankingNewsMortgages();
                    LoadBankingNewsCard();
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

        #region loan Repeater
        private void LoadBankingNewsLoans()
        {
            try
            {
                BankingInformationRT _BankingInformationRT = new BankingInformationRT();
                var objLoans = _BankingInformationRT.GetAllLoanType().Take(3).ToList();
                if (objLoans.Count > 0)
                {
                    rpLoans.DataSource = objLoans;
                    rpLoans.DataBind();
                  
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }      

        protected void rpLoans_OnItemDataBound(object source, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    Literal objltrLoan = (Literal)e.Item.FindControl("lblLoanTypeID");
                    objltrLoan.Text = objltrLoan.Text.Trim();
                    
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
      
        #endregion loan Repeater

        #region Mortgage Repeater
        private void LoadBankingNewsMortgages()
        {
            try
            {
                MortgageRT _MortgageRT = new MortgageRT();
                var objMortgages = _MortgageRT.GetAllMortgageForListView().Take(3).ToList();
                if (objMortgages.Count > 0)
                {
                    rpMortgages.DataSource = objMortgages;
                    rpMortgages.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        protected void rpMortgages_OnItemDataBound(object source, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {                                       
                        Literal objltrMortgage = (Literal)e.Item.FindControl("lblMortgageTypeID");
                        objltrMortgage.Text = objltrMortgage.Text.Trim();
                        if (objltrMortgage.Text.Length > 20)
                        {   var text = objltrMortgage.Text.Substring(0, 20);
                            objltrMortgage.Text = text;
                        }                 

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        #endregion Mortgage Repeater

        #region Card Repeater
        private void LoadBankingNewsCard()
        {
            try
            {
                CardInfoRT _CardInfoRT = new CardInfoRT();
                var objCard = _CardInfoRT.GetAllCardType().Take(3).ToList();
                if (objCard.Count > 0)
                {
                    rpCards.DataSource = objCard;
                    rpCards.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        protected void rpCards_OnItemDataBound(object source, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    Literal objltrCard = (Literal)e.Item.FindControl("lbCardTypeID");
                    objltrCard.Text = objltrCard.Text.Trim();                 
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        #endregion Card Repeater

         #region Upper Slide

         private void LoadBankingNews()
         {
            try
            {
                BankingInformationRT _BankingInformationRT = new BankingInformationRT();

                rpLoanName.DataSource = _BankingInformationRT.GetAllLoanType().Take(1);
                rpLoanName.DataBind();

               // rpMortgageName.DataSource = _BankingInformationRT.GetAllMortgageType().Take(1);
                rpMortgageName.DataBind();

                CardInfoRT _cardRT = new CardInfoRT();
                rpCardName.DataSource = _cardRT.GetAllCardType().Take(1);
                rpCardName.DataBind();             
                           
              }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
         }
                      
         protected void rpLoanName_OnItemDataBound(object source, RepeaterItemEventArgs e)
         {
             try
             {
                 if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                 {
                     Literal objltrLoan = (Literal)e.Item.FindControl("lblLoanTypeName");
                     objltrLoan.Text = objltrLoan.Text.Trim();
                     BankingInformationRT _BankingInformationRT = new BankingInformationRT();
                     lblLoanDes.Text = _BankingInformationRT.GetLoanDescription(_BankingInformationRT.GetLoanTypeOne(objltrLoan.Text.ToString()));
                     var loanBankingNews = _BankingInformationRT.GetLoanFeatures(_BankingInformationRT.GetLoanTypeOne(objltrLoan.Text.ToString()));
                     rpLoanFeature.DataSource = loanBankingNews;
                     rpLoanFeature.DataBind();
                 }
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message, ex);
             }
         }
         protected void rpLoanFeature_OnItemDataBound(object source, RepeaterItemEventArgs e)
         {
             try
             {

                 if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                 {
                   
                    Literal objltrLoan = (Literal)e.Item.FindControl("ltlLoanFeature");
                    objltrLoan.Text = objltrLoan.Text.Trim();
                 }
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message, ex);
             }
         }         
         protected void rpCardName_OnItemDataBound(object source, RepeaterItemEventArgs e)
         {
             try
             {
                 if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                 {
                     Literal objltrCard = (Literal)e.Item.FindControl("lblCardTypeName");
                     objltrCard.Text = objltrCard.Text.Trim();

                     BankingInformationRT _BankingInformationRT = new BankingInformationRT();

                    // lblCardDes.Text = _BankingInformationRT.GetCardDescription(_BankingInformationRT.GetCardTypeOne(objltrCard.Text.ToString()));

                     var cardNews = _BankingInformationRT.GetCardInfoDescription();
                     rpCardFeature.DataSource = cardNews;
                     rpCardFeature.DataBind();
                 }
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message, ex);
             }
         }
         protected void rpCardFeature_OnItemDataBound(object source, RepeaterItemEventArgs e)
         {
             try
             {

                 if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                 {

                     Literal objltrCard = (Literal)e.Item.FindControl("ltlCardFeature");
                     objltrCard.Text = objltrCard.Text.Trim();
                 }
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message, ex);
             }
         }
         protected void rpMortgageName_OnItemDataBound(object source, RepeaterItemEventArgs e)
         {
             try
             {
                 if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                 {
                     Literal objltrMort = (Literal)e.Item.FindControl("lblMortTypeName");
                     objltrMort.Text = objltrMort.Text.Trim();

                     BankingInformationRT _BankingInformationRT = new BankingInformationRT();
                 //    lblMortgage.Text = _BankingInformationRT.GetMortgageDescription(_BankingInformationRT.GetMortgageTypeOne(objltrMort.Text.ToString()));

                   //  var mortBankingNews = _BankingInformationRT.GetMortgageInfoDescription(_BankingInformationRT.GetMortgageTypeOne(objltrMort.Text.ToString()));
                  //   rpMortgage.DataSource = mortBankingNews;
                     rpMortgage.DataBind();
                                       
                 }
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message, ex);
             }
         }
         protected void rpMortgage_OnItemDataBound(object source, RepeaterItemEventArgs e)
         {
             try
             {

                 if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                 {

                     Literal objltrMortgage = (Literal)e.Item.FindControl("ltlmortgageAPR");
                     objltrMortgage.Text = objltrMortgage.Text.Trim();

                     Literal objltrMortgageAPR = (Literal)e.Item.FindControl("ltlmortgageFeeCharge");
                     objltrMortgageAPR.Text = objltrMortgageAPR.Text.Trim();

                     Literal objltrMortgageDes = (Literal)e.Item.FindControl("ltlmortgageDes");
                     objltrMortgageDes.Text = objltrMortgageDes.Text.Trim();
                 }
             }
             catch (Exception ex)
             {
                 throw new Exception(ex.Message, ex);
             }
         }
       
         #endregion Upper Slide
    }
}