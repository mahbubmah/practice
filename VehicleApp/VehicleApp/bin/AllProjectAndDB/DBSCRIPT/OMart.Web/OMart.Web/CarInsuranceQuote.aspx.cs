using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;


namespace OMart.Web
{
    public partial class CarInsuranceQuote : System.Web.UI.Page
    {
        private string _pageLogPath;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    PopulateEnumToDropDown(typeof(Utilities.EnumCollection.CarType), ddlCarType);
                    //loadCarType(null);

                    //loadCarConditionType(null);
                    PopulateAnotherEnumToDropDown(typeof(Utilities.EnumCollection.CarCondition), ddlCarCondition);

                }
                catch (Exception ex)
                {
                    LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
                }
            }

        }

        private void PopulateAnotherEnumToDropDown(Type CarCondition, DropDownList ddlCarCondition)
        {
            try
            {
                Array NamesArray = System.Enum.GetValues(CarCondition);
                foreach (int iterator in NamesArray)
                {
                    string enumText = Enum.GetName(CarCondition, iterator);
                    string enumValue = ((int)iterator).ToString(); ;
                    // its better to give the value of a dropdownlist as integer. if so,
                    //string enumValue = iterator.ToString();
                    ListItem newItem = new ListItem(enumText, enumValue);
                    ddlCarCondition.Items.Add(newItem);
                }
            }

            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
           
        }

        private void PopulateEnumToDropDown(Type Cartype, DropDownList ddlCarType)
        {
            try
            {
                Array NamesArray = System.Enum.GetValues(Cartype);
                foreach (int iterator in NamesArray)
                {
                    string enumText = Enum.GetName(Cartype, iterator);
                    string enumValue = ((int)iterator).ToString(); ;
                    // its better to give the value of a dropdownlist as integer. if so,
                    //string enumValue = iterator.ToString();
                    ListItem newItem = new ListItem(enumText, enumValue);
                    ddlCarType.Items.Add(newItem);

                }
            }

            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
           
        }

        private void loadCarType(int? LIApplicableAmntYrScdleOb)
        {
            try
            {
                {
                    ddlCarType.Items.Add(new ListItem("Select Car Type ", "-1"));
                    foreach (Utilities.EnumCollection.CarType r in Enum.GetValues(typeof(Utilities.EnumCollection.CarType)))
                    {
                        ListItem item = new ListItem(Enum.GetName(typeof(Utilities.EnumCollection.CarType), r), r.ToString());
                        ddlCarType.Items.Add(item);
                    }

                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
        private void loadCarConditionType(int? LIApplicableAmntYrScdleOb)
        {
            try
            {


                {
                    ddlCarCondition.Items.Add(new ListItem("Select Car Condition Type ", "-1"));
                    foreach (Utilities.EnumCollection.CarCondition r in Enum.GetValues(typeof(Utilities.EnumCollection.CarCondition)))
                    {
                        ListItem item = new ListItem(Enum.GetName(typeof(Utilities.EnumCollection.CarCondition), r), r.ToString());
                        ddlCarCondition.Items.Add(item);
                    }

                }
            }
            catch (Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }

        protected void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                Session["CarType"] = ddlCarType.SelectedValue;
                Session["CarCondition"] = ddlCarCondition.SelectedValue;             
                Session["Run"] = txtCarRun.Text;
                Session["Age"] = txtCarAge.Text;
                Session["CarValueAmount"] = txtCarValueAmount.Text;
                Session["PremiumTotalPercent"] = txtPremiumTotalPercent.Text;
                Session["Duration"] = txtDuration.Text;

                Response.Redirect("CarInsuranceQuoteResults",false);
 
            }
            catch(Exception ex)
            {
                LogFileHelper.LogFileWritten(ex.Message, ex.StackTrace, _pageLogPath);
            }
        }
    }
}