using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Basic;
using DAL;
using Utilities;


namespace OMart.Web
{
    public partial class CarInsuranceQuoteResults : System.Web.UI.Page
    {
        private string _pageLogPath;
        public CarInsuranceQuoteResults()
        {
 
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    int CarTypeID = Convert.ToInt32(Session["CarType"].ToString());
                    int CarConditionID = Convert.ToInt32((Session["CarCondition"]).ToString());
                    Int64 run = Convert.ToInt64((Session["Run"]).ToString());
                    int age = Convert.ToInt32((Session["Age"]).ToString());
                    Decimal CarValueAmount =Convert.ToDecimal( (Session["CarValueAmount"]).ToString());        
                    float PremiumTotalPercent = float.Parse((Session["PremiumTotalPercent"]).ToString());
                    int Duration = Convert.ToInt32((Session["Duration"]).ToString());

                    LoadCarInsuranceQuoteResult(CarTypeID, CarConditionID, run, age, CarValueAmount, PremiumTotalPercent, Duration);
                
                }

            }
            catch(Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }

        }

        private void LoadCarInsuranceQuoteResult(int CarTypeID, int CarConditionID, long run, int age, decimal CarValueAmount, float PremiumTotalPercent, int Duration)
        {
            try
            {
                using (CarInsuranceRT carIns = new CarInsuranceRT())
                {
                    var carInsQuote = carIns.GetAllCarInsuranceQuote(CarTypeID, CarConditionID, run, age, CarValueAmount, PremiumTotalPercent, Duration);
                    lv_CarInsuranceQuoteResults.DataSource = carInsQuote;
                    lv_CarInsuranceQuoteResults.DataBind();
                }
            }

            catch(Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
    }
}