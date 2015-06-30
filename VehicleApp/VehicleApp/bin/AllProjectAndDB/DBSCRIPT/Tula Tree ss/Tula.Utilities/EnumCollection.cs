using System;
using System.Web.UI.WebControls;

namespace Tula.Utilities
{
    public class EnumCollection
    {
        public EnumCollection()
        {
        }

        //map to country table, string=country name, value=IID
        public enum Country
        {
            Bangladesh=1,
            UK=2
        }



        public enum PageCategory
        {
            Admin =1,
            General_Setup=2
            
        }
        public enum Sex
        {
            Male = 1,
            Female = 2,
            Other=3
        }
        public enum EducationType
        {
            SSC = 1,
            HSC = 2,
            Honours = 3,
            Masters = 4,
            MPhile = 5,
            PHD = 6,
            Others = 7
        }
        public enum ModuleList
        {
            Setup = 1,
            MemberInformation = 2,
            EntryAndOut = 3,
            AssignTask = 4,
            DailyWork = 5,
            ProjectAssign = 6,
            LeaveRequest = 7,
        }
        
       
        public enum ListItemType
        {
            City = 1,
            State = 2,
            Country = 3,
            Sex = 4,
            District = 5,
            EducationType = 10, 
            Designation =20,
            UserGroup=25,           
            UrlList=30,
            UserTypeID = 21,
            Category =32,    /* Hasan Add 2015.03.4*/
            None = 100,
            CMSTypeID=126,
            HelpSupportTypeID=124,
        }

        public enum ReportLevel
        { 
            Level0 = 0, 
            Level1 = 1, 
            Level2 = 2 
        }
        /// <summary>
        /// Maping of [OiiOHR].[dbo].[Designation] table of database, if table value change than need enum value update.
        /// </summary>
        public enum Designation
        {
            BranchManager =1,
            SalesOffice =2            
        }

        public enum BooleanString
        {
            True=1,
            False=2
        }

        public enum OperationName
        {
            AddNewData = 1,
            UpdateData = 2,
            DeleteData=3,
            CancelData =4
        }

        public enum Browsers
        {
            Chrome = 1,
            Firefox = 2,
            InternetExplorer = 3,
            Safari = 4,
            Opera =5,
            Other=6

        }
        public enum HelpSupportType
        {
            basics=1,
            FAQs=2,
            Something_not_working=3,
            HomeTab=4
        }

        public enum ButtonDisplayText
        {
            Save = 1,
            Update = 2,
            Delete = 3,
            Cancel = 4
        }

        public enum NavMenu
        {
            For_Sell = 1,
            Jobs = 2,
            Property = 3,
            Motors = 4,
            Services=5,
            Community=6
        }

        public enum CMSType
        {
            About_OiiO_Haat = 1,
            Work_With_Us = 2,
            Contact_With_Us = 3,
            Press_Releases=4,
            OiiO_Haat_Blog=5,
            Our_Partners=6,
            For_Business=7,
            Privacy_Policy = 8,
            Cookies_Policy = 9,
            Terms_of_Use = 10,
             Safety_Tips= 11
        }

        public enum ClientType
        {
            Personal=1, 
            OrganiztionOrCompany=2
        }
        public enum UserGrpType
        {
            Control_User= 1,
            Management = 2,
            Add_Giver=3
        }
    }

    public class EnumModifier
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
    
    public class EnumHelper
    {
        public EnumHelper()
        { }

        public static ListItemCollection EnumToList<T>()
        {
            ListItemCollection lists = new ListItemCollection();
            foreach (string item in Enum.GetNames(typeof(T)))
            {
                int value = (int)Enum.Parse(typeof(T), item);
                item.Replace('_', ' ');
                ListItem listItem = new ListItem(item.Replace('_', ' '), value.ToString());

                lists.Add(listItem);

            }
            return lists;
        }

        public static string EnumToString<T>(int value)
        {
            ListItemCollection lists = EnumToList<T>();
            return lists.FindByValue(value.ToString()).Text;
        }
        public static string EnumToString<T>(T value)
        {
            ListItemCollection lists = EnumToList<T>();
            return lists.FindByValue(value.ToString()).Text;
        }

        public static string EnumToString<T1>(long p)
        {
            throw new NotImplementedException();
        }
    }

}
