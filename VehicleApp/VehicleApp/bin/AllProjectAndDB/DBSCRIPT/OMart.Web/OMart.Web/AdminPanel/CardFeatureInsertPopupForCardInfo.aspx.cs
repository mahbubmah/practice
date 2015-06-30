using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Providers.Entities;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Basic;
using DAL;
using Microsoft.Ajax.Utilities;
using Utilities;

namespace OMart.Web.AdminPanel
{
    public partial class CardFeatureInsertPopupForCardInfo : System.Web.UI.Page
    {

        private readonly CardFeatureRT _cardFeatureRt;
        private const string sessCardFeature = "seCardFeature";
        int lvRowCount = 0;
        int currentPage = 0;
        public CardFeatureInsertPopupForCardInfo()
        {
            _cardFeatureRt = new CardFeatureRT();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session[sessCardFeature]==null)
                {
                    Session[sessCardFeature] = new List<CardFeature>();
                }
            }
            ShowCardFeatureGrid();
        }

        private void ShowCardFeatureGrid()
        {
            try
            {
                lvCardFeature.DataSource = Session[sessCardFeature];
                lvCardFeature.DataBind();
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private string BusinessLogicValidation(CardFeature cardFeature)
        {
            string message = string.Empty;
           // bool reqIDIsValid = Int64.TryParse(Request.QueryString["IID"], out IID);

            if (txtDescription.Text.IsNullOrWhiteSpace())
            {
                message = "Please enter some description card informaion";
                return message;
            }
            return string.Empty;
        }



        private CardFeature CreateCardFeature()
        {
            Session["UserID"] = "1";
            CardFeature cardFeature = new CardFeature();
            try
            {


                if (!txtDescription.Text.IsNullOrWhiteSpace())
                {
                    cardFeature.Description = txtDescription.Text;
                }

            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
            return cardFeature;
        }
        private void ClearData()
        {
            txtDescription.Text = string.Empty;
        }

        protected void dataPagerCardFeature_PreRender(object sender, EventArgs e)
        {
            try
            {
                lvRowCount = currentPage * 10;
                if (IsPostBack)
                {
                    ShowCardFeatureGrid();
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lvCardFeature_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            labelMessage.Text = string.Empty;
            currentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }


        protected void btn_CreateOrEdit_Click(object sender, EventArgs e)
        {
            try
            {
                CardFeature cardFeature = CreateCardFeature();
              //  bool reqIDIsValid = Int64.TryParse(Request.QueryString["IID"], out IID);
                var msg = BusinessLogicValidation(cardFeature);

                if (string.IsNullOrEmpty(msg))
                {
                    List<CardFeature> cardFeaturelist = (List<CardFeature>)Session[sessCardFeature];
                   
                    cardFeaturelist.Add(cardFeature);

                    Session[sessCardFeature] = cardFeaturelist;
                    ClearData();

                    labelMessage.Text = "Information has been inserted successfully.";
                    labelMessage.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    labelMessage.Text = msg;
                    labelMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = "Error : " + ex.Message;
                labelMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                ClearData();
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
                List<CardFeature> cardFeatureList = (List<CardFeature>)Session[sessCardFeature];
                if (cardFeatureList.Count>0)
                {
                    cardFeatureList.Remove(cardFeatureList.SingleOrDefault(x => x.Description == linkButton.CommandArgument));
                    Session[sessCardFeature] = cardFeatureList;
                    ShowCardFeatureGrid();

                    labelMessage.Text = "Card feature has been removed successfully.";
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