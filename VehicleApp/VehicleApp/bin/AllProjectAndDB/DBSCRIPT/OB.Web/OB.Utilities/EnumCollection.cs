using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.UI.WebControls;


namespace OB.Utilities
{
    public class StringEnum
    {
        public static string GetStringValue(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
        
    }

    

    
    public class EnumCollection
    {
        public enum PageCategory
        {
            Admin =1,
            General_Setup=2
            
        }
        public enum BookStore
        {
            [Description("http://www.amazon.co.uk/")]
            Amazon = 1,
            [Description("http://www.hive.co.uk/")]
            Hive = 2,
            [Description("http://direct.asda.com/")]
            Asda = 3,
            [Description("http://www.sainsburysentertainment.co.uk/")]
            Sainsbury = 4,
            [Description("http://www.eburypublishing.co.uk")]
            Blackwell = 5,
            [Description("http://bookshop.blackwell.co.uk/")]
            Tesco = 6,
            [Description("https://www.waterstones.com/")]
            Waterstones = 7,
            [Description("http://www.bookdepository.com/")]
            Book_Depository = 8,
            [Description("http://www.foyles.co.uk/")]
            Foyles = 9,
            [Description("http://www.whsmith.co.uk/")]
            WH_Smith = 10,
        }
        public enum type
        {
            SelfEmployeed = 1,
            Employee = 2,
            Businessman = 3,
            Author=4,
            Poet=5,
            Writer=6,
            Student=7
        }
        public enum Sex
        {
            Male = 1,
            Female = 2,
            Other=3
        }
        public enum UserGroupType
        {
            Control_User = 1,
            Management = 2,
            General = 3
        }
        public enum BestBooksCatType
        {
            Recommended=1,
            Latest=2,
            Coming_Soon=3,
            Best_Offer=4,
            Best_Seller=5,
            Most_Favourite=6,
            Most_Viewed=7,
            Best_Authors=8
        }

        public enum BookWishType
        {
            eBook = 1,
            PDF = 2,
            Audio=3

        }
        /// <summary>
        /// Hasan Add Description 2015.06.01
        /// </summary>
        public enum ParentCategory
        {
            [Description("Fiction type of book plays the vital role in the social education system to develop inner sole of a person")]
            Fiction = 1,

            [Description("Non Fiction type of book also plays the vital role in the social education system to develop inner sole of a person")]
            Non_Fiction = 2,
            authListPage=3,
            bookCompetitions=4,
            booksNews=5,

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

        public enum CompititionSessionType
        {
            Spring=1,Summer=2,Winter=3
        }


        public enum ListItemType
        {
            City = 1,
            State = 2,
            Country = 3,
            Sex = 4,
            District = 5,
            PoliceStation=6,
            EducationType = 10, 
            Designation =20,
            UserGroup=25,
            ParentCategory=57,
           BookPublisher=90,
           BookWishType = 200,
            BookCategory=500,
            BookAuthor = 80,
            UrlList=30,
            UserTypeID = 21,
            Profession =22,
            None = 100,
            CMSTypeID=140,
            

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

        public enum ButtonDisplayText
        {
            Save = 1,
            Update = 2,
            Delete = 3,
            Cancel = 4
        }
        public enum CMSType
        {
            Our_Story=1,
            Contact_Us=2,
            Terms_and_Condition=3,
            Privacy_and_Cookies_Policy=4,
            Delivery_Policy=5,
            Return_Policy=6,
            Connection_Policy=7,
            FAQs=8
        }

        public enum ClientType
        {
            Personal=1, 
            OrganiztionOrCompany=2
        }
    }
    public class EnumModifier
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
    }
    
    public class EnumHelper
    {
        public EnumHelper()
        { }

        public static ListItemCollection EnumCamelSpaceToList<T>()
        {
            ListItemCollection lists = new ListItemCollection();
            foreach (string item in Enum.GetNames(typeof(T)))
            {
                int value = (int)Enum.Parse(typeof(T), item);
                string result = System.Text.RegularExpressions.Regex.Replace(item, "(\\B[A-Z])", " $1");
                ListItem listItem = new ListItem(result, value.ToString());
                lists.Add(listItem);
            }
            return lists;
        }
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
        public static string EnumToStringWithSpace<T>(int value)
        {

            ListItemCollection lists = EnumToList<T>();
            string item = lists.FindByValue(value.ToString()).Text;
            string result = System.Text.RegularExpressions.Regex.Replace(item, "(\\B[A-Z])", " $1");
            return result;
        }
        public static string EnumToStringWithSpace(string name)
        {
            string result = System.Text.RegularExpressions.Regex.Replace(name, "(\\B[A-Z])", " $1");
            return result;
        }
        public static string EnumToString<T1>(long p)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Getting Enum Description Hasan 2015.06.01
        /// </summary>
        /// <param name="en"></param>
        /// <returns></returns>
        public static string GetDescription(Enum en)
        {
            Type type = en.GetType();

            MemberInfo[] memInfo = type.GetMember(en.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return en.ToString();
        }
        /// <summary>
        /// Method to get enumeration value from string value. Hasan Add 2015.06.01
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        public static T GetEnumValue<T>(string str) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new Exception("T must be an Enumeration type.");
            }
            T val = ((T[])Enum.GetValues(typeof(T)))[0];
            if (!string.IsNullOrEmpty(str))
            {
                foreach (T enumValue in (T[])Enum.GetValues(typeof(T)))
                {
                    if (enumValue.ToString().ToUpper().Equals(str.ToUpper()))
                    {
                        val = enumValue;
                        break;
                    }
                }
            }

            return val;
        }
      
    
    }

}
