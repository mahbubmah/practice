using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace OH.Utilities
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
              
                case EnumCollection.ListItemType.Designation: //for Designation
                    extraItems.Add(new ListItem("Select Designation", "-1"));
                    break;

                case EnumCollection.ListItemType.District : // for District // Add hasan 10.02.2015
                    extraItems.Add(new ListItem("Select District","-1"));
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
                case EnumCollection.ListItemType.HelpSupportTypeID:// for Help Support Type 
                    extraItems.Add(new ListItem("Select Help Support Type ", "-1"));
                    break;
              
                case EnumCollection.ListItemType.None: //for None                
                    break;


            }
            return extraItems;
        }



        public static void Bind<T>(DropDownList ddl, List<T> items, string nameProperty, string valueProperty, EnumCollection.ListItemType ddltype)
        {
            //ListItemCollection extraItems = new ListItemCollection();
            //switch (ddltype)
            //{
            //    case 1: //for City
            //        extraItems.Add(new ListItem("N/A", "-2"));
            //        extraItems.Add(new ListItem("Select City", "-1"));
            //        //Bind<T>(ddl, items, nameProperty, valueProperty, extraItems);
            //        break;
            //    case 2: //for State
            //        extraItems.Add(new ListItem("N/A", "-2"));
            //        extraItems.Add(new ListItem("Select State", "-1"));
            //        //Bind<T>(ddl, items, nameProperty, valueProperty, extraItems);
            //        break;
            //    case 3: //for Country                    
            //        extraItems.Add(new ListItem("Select Country", "-1"));                    
            //        break;
            //    case 4: //for ProductType
            //        extraItems.Add(new ListItem("Select Type", "-1"));
            //        break;
            //}

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
