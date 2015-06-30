using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Utilities
{
    public class DropDownListHelper
    {
        public static DateTime GetDateFromText(string date)
        {
            if (!string.IsNullOrEmpty(date))
            {
                string[] _date = date.Split(new char[] { '/', '-', '.' });
                if (_date.Length >= 3)
                {
                    string year = _date[2];
                    if (year.Length == 2)
                    {
                        DateTime nowDate = DateTime.Now;
                        string yearNow = nowDate.Year.ToString();
                        string yearStr = yearNow[0].ToString();
                        yearStr += yearNow[1].ToString();
                        year = yearStr + year;
                    }
                    return new DateTime(Convert.ToInt32(year), Convert.ToInt32(_date[1]), Convert.ToInt32(_date[0]));
                }

                else
                    return DateTime.MinValue;
            }
            return DateTime.MinValue;
        }

        public static void Bind<T>(DropDownList ddl, List<T> items, string nameProperty, string valueProperty)
        {
            //DropDownList ddl = new DropDownList();
            //Edited by Imtiaz
            //items = items.AsQueryable().OrderBy(nameProperty + " " + "asc").ToList<T>();
            //end
            ddl.DataSource = items;
            ddl.DataTextField = nameProperty;
            ddl.DataValueField = valueProperty;
            ddl.DataBind();
            //return ddl;
        }

        //public static void Bind<T>(DropDownList ddl, List<T> items, string nameProperty, string valueProperty, bool sorted)
        //{
        //    //DropDownList ddl = new DropDownList();
        //    //Edited by Imtiaz
        //    if (sorted)
        //        items = items.AsQueryable().OrderBy(nameProperty + " " + "asc").ToList<T>();
        //    //end
        //    ddl.DataSource = items;
        //    ddl.DataTextField = nameProperty;
        //    ddl.DataValueField = valueProperty;
        //    ddl.DataBind();
        //    //return ddl;
        //}
        public static void Bind<T>(DropDownList ddl, List<T> items, string nameProperty, string valueProperty, ListItemCollection extraItems, int hasSelectedValue)
        {
            if (hasSelectedValue == 1)
            {
                foreach (ListItem item in extraItems)
                {
                    ddl.Items.Insert(0, item);
                }
                Bind<T>(ddl, items, nameProperty, valueProperty);
            }
            else
            {
                Bind<T>(ddl, items, nameProperty, valueProperty);
                foreach (ListItem item in extraItems)
                {
                    ddl.Items.Insert(0, item);
                }
            }
        }
        public static void Bind<T>(DropDownList ddl, List<T> items, string nameProperty, string valueProperty, ListItemCollection extraItems)
        {

            Bind<T>(ddl, items, nameProperty, valueProperty);
            foreach (ListItem item in extraItems)
            {
                ddl.Items.Insert(0, item);
            }
        }
        //public static void Bind<T>(DropDownList ddl, List<T> items, string nameProperty, string valueProperty, ListItemCollection extraItems, bool sorted)
        //{
        //    Bind<T>(ddl, items, nameProperty, valueProperty, sorted);
        //    foreach (ListItem item in extraItems)
        //    {
        //        ddl.Items.Insert(0, item);
        //    }
        //}
        public static void Bind(DropDownList ddl, ListItemCollection list)
        {
            
            foreach (ListItem item in list)
            {
                ddl.Items.Add(item);
            }


            
        }
        public static void Bind(DropDownList ddl, ListItemCollection list, EnumCollection.ListItemType ddlType)
        {
            Bind(ddl, list);
            foreach (ListItem item in GetExtraItems(ddlType))
            {
                ddl.Items.Insert(0, item);
            }
        }

        private static ListItemCollection GetExtraItems(EnumCollection.ListItemType ddltype)
        {
            ListItemCollection extraItems = new ListItemCollection();
            switch (ddltype)
            {

                case EnumCollection.ListItemType.MortgageType: // Add Mahbub 31.03.2015
                    extraItems.Add(new ListItem("Select mortgage type", "-1"));
                    break;
                case EnumCollection.ListItemType.MortgageOperationType: // Add Mahbub 31.03.2015
                    extraItems.Add(new ListItem("Select mortgage operation type", "-1"));
                    break;
                case EnumCollection.ListItemType.InterestRateType:  // Add Mahbub 31.03.2015
                    extraItems.Add(new ListItem("Select interest rate type", "-1"));
                    break;
                case EnumCollection.ListItemType.PaymentType: // Add Mahbub 31.03.2015
                    extraItems.Add(new ListItem("Select payment type", "-1"));
                    break;
                case EnumCollection.ListItemType.MortgageTermYear:// Add Mahbub 31.03.2015
                    extraItems.Add(new ListItem("Select term year", "-1"));
                    break;
                case EnumCollection.ListItemType.CompanyInfo:  // Add Mahbub 31.03.2015
                    extraItems.Add(new ListItem("Select company", "-1"));
                    break;
                case EnumCollection.ListItemType.BalanceType:  // Add Mahbub 01.04.2015
                    extraItems.Add(new ListItem("Select balance type", "-1"));
                    break;
                case EnumCollection.ListItemType.CardType: // Add Mahbub 01.04.2015
                    extraItems.Add(new ListItem("Select card type", "-1"));
                    break;
                case EnumCollection.ListItemType.CardInfo:  // Add Mahbub 01.04.2015
                    extraItems.Add(new ListItem("Select card information", "-1"));
                    break;
                case EnumCollection.ListItemType.BIAmountType:// Add Mahbub 11.05.2015
                    extraItems.Add(new ListItem("Select Amount Type", "-1"));
                    break;

                case EnumCollection.ListItemType.SmokerType: // Add Mahbub 15.04.2015
                    extraItems.Add(new ListItem("--Select--", "-1"));
                    break;
                case EnumCollection.ListItemType.WantMoreInfo: // Add Mahbub 15.04.2015
                    extraItems.Add(new ListItem("--Select--", "-1"));
                    break;
                case EnumCollection.ListItemType.Profession:  // Add Mahbub 15.04.2015
                    extraItems.Add(new ListItem("Select profession", "-1"));
                    break;
                case EnumCollection.ListItemType.Insurance:  // Add Mahbub 15.04.2015
                    extraItems.Add(new ListItem("Select insurance type", "-1"));
                    break;
                case EnumCollection.ListItemType.City: //for City
                    //extraItems.Add(new ListItem("N/A", "-2"));
                    extraItems.Add(new ListItem("Select City", "-1"));
                    //Bind<T>(ddl, items, nameProperty, valueProperty, extraItems);
                    break;
                case EnumCollection.ListItemType.State: //for State
                    extraItems.Add(new ListItem("N/A", "-2"));
                    extraItems.Add(new ListItem("Select State", "-1"));
                    //Bind<T>(ddl, items, nameProperty, valueProperty, extraItems);
                    break;
                case EnumCollection.ListItemType.Country: //for Country                    
                    extraItems.Add(new ListItem("Select Country", "-1"));
                    break;
                case EnumCollection.ListItemType.DivisionOrState: // for District // Add Mahbub 30.03.2015
                    extraItems.Add(new ListItem("Select Division or state", "-1"));
                    break;
              
                case EnumCollection.ListItemType.Designation: //for Designation
                    extraItems.Add(new ListItem("Select Designation", "-1"));
                    break;

                case EnumCollection.ListItemType.District : // for District // Add hasan 10.02.2015
                    extraItems.Add(new ListItem("Select District","-1"));
                    break;
                case EnumCollection.ListItemType.PoliceStaion: // for  PoliceStaion// Add mahbub 30.03.2015
                    extraItems.Add(new ListItem("Select police staion", "-1"));
                    break;
                case EnumCollection.ListItemType.PostOffice: // for PostOffice // Add mahbub 30.03.2015
                    extraItems.Add(new ListItem("Select post office", "-1"));
                    break;
                case EnumCollection.ListItemType.UserTypeID:// for UserType // Add a_islam 22.02.2015
                    extraItems.Add(new ListItem("Select User Type ","-1"));
                    break;
                case EnumCollection.ListItemType.UserGroup:// for User Group 
                    extraItems.Add(new ListItem("Select User Group ", "-1"));
                    break;
                case EnumCollection.ListItemType.UrlList:// for Url List 
                    extraItems.Add(new ListItem("Select Url Name ", "-1"));
                    break;
              
                // for mobile phone
                case EnumCollection.ListItemType.Company:// for mobile phone
                    extraItems.Add(new ListItem("Select Company Name", "-1"));
                    break;
                case EnumCollection.ListItemType.MPType:// for mobile phone
                    extraItems.Add(new ListItem("Select Mobile Phone Type", "-1"));
                    break;

                case EnumCollection.ListItemType.MPModel:// for mobile phone
                    extraItems.Add(new ListItem("Select Mobile Phone Model", "-1"));
                    break;

                case EnumCollection.ListItemType.NetworkServiceProvider:
                    extraItems.Add(new ListItem("Select Network Service Provider Name", "-1"));
                    break;
                case EnumCollection.ListItemType.AvailableSIM:
                    extraItems.Add(new ListItem("Select Available SIM ", "-1"));
                    break;
                case EnumCollection.ListItemType.TalkTimeUnit:
                    extraItems.Add(new ListItem("Select Talk Time Unit ", "-1"));
                    break;
                case EnumCollection.ListItemType.UsableDataUnit:
                    extraItems.Add(new ListItem("Select Usable Data Unit", "-1"));
                    break;
                case EnumCollection.ListItemType.ConnectionType:
                    extraItems.Add(new ListItem("Select Connection Type ", "-1"));
                    break;
                case EnumCollection.ListItemType.LoanAmtYearSchedule:
                    extraItems.Add(new ListItem("Select Loan Amount Year Schedule ","-1"));
                    break;
                  // for mobile phone
                case EnumCollection.ListItemType.None: //for None                
                    break;
                case EnumCollection.ListItemType.PremiumPolicy:
                    extraItems.Add(new ListItem("Select Loan Amount Year Schedule ", "-1"));
                    break;
                case EnumCollection.ListItemType.LISchema:
                    extraItems.Add(new ListItem("Select Number of Year ", "-1"));
                    break;
                case EnumCollection.ListItemType.LoanType:
                    extraItems.Add(new ListItem("Select Loan Type", "-1"));
                    break;
                case EnumCollection.ListItemType.GuideLineDetail:
                    extraItems.Add(new ListItem("Select Guide Line Detail", "-1"));
                    break;
                case EnumCollection.ListItemType.GuideLine:
                    extraItems.Add(new ListItem("Select Guide Line", "-1"));
                    break;
                case EnumCollection.ListItemType.All:
                    extraItems.Add(new ListItem("All", "-1"));
                    break;
                case EnumCollection.ListItemType.BussinessType:
                    extraItems.Add(new ListItem("Select a Bussiness Type", "-1"));
                    break;
                case EnumCollection.ListItemType.BussinessEnergyType:
                    extraItems.Add(new ListItem("Select a Bussiness Energy Type", "-1"));
                    break;
                case EnumCollection.ListItemType.CMSTypeID:
                    extraItems.Add(new ListItem("Select CMS Type From List", "-1"));
                    break;
                case EnumCollection.ListItemType.NewsType:
                    extraItems.Add(new ListItem("Select News TypeFrom List", "-1"));
                    break;
                     
            }
            return extraItems;
        }



        public static void Bind<T>(DropDownList ddl, List<T> items, string nameProperty, string valueProperty, EnumCollection.ListItemType ddltype)
        {           
            Bind<T>(ddl, items, nameProperty, valueProperty, GetExtraItems(ddltype));
        }



        public static void Bind<T>(DropDownList ddl, List<T> items, string nameProperty, string valueProperty, EnumCollection.ListItemType ddltype, bool sorted)
        {


            //Bind<T>(ddl, items, nameProperty, valueProperty, GetExtraItems(ddltype), sorted);

        }

        //ddlState.Items.Insert(0, new ListItem("N/A", "-2"));
        //ddlState.Items.Insert(0, new ListItem("Select State", "-1"));
        //public static DropDownList Bind<T>(List<T> items, string nameProperty, string valueProperty, ListItemCollection extraItems)
        //{
        //    DropDownList ddl = Bind<T>(items, nameProperty, valueProperty);
        //    foreach (ListItem item in extraItems)
        //    {
        //        ddl.Items.Insert(0,item);
        //    }
        //    return ddl;

        //}
        //public static DropDownList Bind<T>(List<T> items, string nameProperty, string valueProperty, int ddltype)
        //{
        //    DropDownList ddl = new DropDownList();
        //    if (ddltype == 1) // for city
        //    {
        //         ListItemCollection extraItems = new ListItemCollection();
        //    extraItems.Add(new ListItem("N/A", "-2"));
        //      extraItems.Add(new ListItem("Select City", "-1"));
        //       ddl = Bind<T>(items, nameProperty, valueProperty, extraItems);
        //    }
        //    return ddl;
        //}
        ////public static DropDownList Bind<T>(DropDownList ddl, List<T> items, string nameProperty, string valueProperty)
        //{
        //    //DropDownList ddl = new DropDownList();
        //    ddl.DataSource = items;
        //    ddl.DataTextField = nameProperty;
        //    ddl.DataValueField = valueProperty;
        //    ddl.DataBind();
        //    //return ddl;
        //}
        //public static void Bind(DropDownList ddl, ListItemCollection list)
        //{
        //    foreach (ListItem item in list)
        //    {
        //        ddl.Items.Add(item);
        //    }
        //}
    }
}
