using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;


namespace Utilities
{
    public class EnumCollection
    {
        public EnumCollection()
        {
        }

        //map to country table, string=country name, value=IID
        public enum Country
        {
            Bangladesh = 1,
            Pakistan = 2,
            India = 3,
            London = 4,
            USA = 5
        }
        public enum NewsType
        {
            Education = 1,
            Recreation = 2,
            Sports = 3,
            PopularGuide = 4
        }
        public enum BIAmountType
        {
            IndemnityAmount = 1,
            PublicLiability = 2,
            EmployerLiability = 3,
            OfficeEquipment = 4,
            PortableEquipment = 5
        }
        public enum SpaceSizeUnitType
        {
            SquareFeet = 1,
            SquareMeter = 2
        }

        public enum PowerSupplyType
        {
            Electricity = 1,
            Solar = 2,
            Generator = 3,
            ElectricityAndSolar = 4,
            ElectricityAndGenerator = 5,
            GeneratorAndSolar = 6,
            ElectricityGeneratorAndSolar = 7
        }
        public enum WaterSupplyType
        {
            CityCorporation = 1,
            SelfDeepPump = 2
        }
        public enum GasSupplyType
        {
            None=0,
            NationalGride=1, 
            Cylinder=2
        }
        public enum BusinessInsuranceType
        {
            BusinessInsurance = 1,
            LifeInsurance = 2,
            CarInsurance = 3,
            HomeInsurance = 4,
            PersonalLoan = 5,
            HouseLoan = 6
        }
        public enum BusinessEnergyType
        {
            CompareGas = 1,
            CompareElectricity = 2,
            BusinessEnergy = 3,
            PrepaymentMeters = 4
        }

        public enum CMSType
        {
            About_OiiO_Mart = 1,
            Work_With_Us = 2,
            Our_Partners = 3,
            Privacy_Policy = 4,
            Terms_of_Use = 5,
            Contact_With_Us = 6,
            OiiO_Mart_Blog = 7
        }
        public enum BusinessTravelType
        {
            Holidays = 1,
            Flights = 2,
            Hotels = 3,
            TravelExtras = 4
        }

        public enum BusinessShoppingType
        {
            HealthAndBeauty = 1,
            OfficeSupplies = 2,
            Cameras = 3,
            Televisions = 4,
            Computers = 5,
            Fashion = 6,
            Furniture = 7
        }

        public enum BusinessBankingType
        {
            CurrentAccounts = 1,
            CraditCards = 2,
            Loans = 3,
            Mortgages = 4,
            BankingNews = 5
        }

        public enum BusinessMobilePhonesType
        {
            MobilePhoneDeals = 1,
            SimOnlyDeals = 2,
            PayAsYouGoPhones = 3,
            iphoneDeals = 4,
            ipadDeals = 5

        }
        public enum BusinessBroadbandType
        {
            BroadbandDeals = 1,
            MobileBroadband = 2,
            BroadbandAndTv = 3,
            BroadbandAndPhone = 4
        }
        public enum WantMoreInfo
        {
            None = 0,
            ByAllMedia = 1,
            ByText = 2,
            ByEmail = 3,
            ByPhoneCall = 4,
            ByTextAndEmail = 5,
            ByEmailAndPhoneCall = 6,
            ByPhoneCallAndText = 7
        }
        public enum SmokerType
        {
            Never = 1,
            LeaveSixMonthAgo = 2,
            LeaveOneYearAgo = 3,
            LeaveFiveYearAgo = 4
        }

        public enum type
        {
            SelfEmployeed = 1,
            Employee = 2,
            Businessman = 3
        }

        public enum MortgageOperationType
        {
            NewClient = 1,
            Remortgage = 2
        }
        /// <summary>
        /// Synchrinize with mortgage Type Info Table IID 
        /// Md. Saad
        /// </summary>
        public enum MortgageType
        {
            Conventional = 1,
            Government = 2,
            RuralHomeFinancingProgram = 3,
            HomeOpportunitiesProgram = 4,
            NoneprimeOrSubprime = 5
        }
        public enum InterestRateType
        {
            FixedRateMortgage = 1,
            AdjustableRateMortgage = 2,
            InitialMonthlyPayment = 3
        }
        public enum PaymentType
        {
            RegularPrincipalAndInterestPayment = 1,
            InterestOnlyPayment = 2,
            BalloonPayment = 3,
            PrepaymentWithNoPenaltyOrFee = 4,
            PrepaymentWithPenaltyOrFee = 5
        }

        public enum PageCategory
        {
            Admin = 1,
            General_Setup = 2

        }
        public enum Sex
        {
            Male = 1,
            Female = 2,
            Other = 3
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


        public enum PremiumPolicy
        {
            Monthly = 1,
            Quatarly = 2,
            HalfYearly = 3,
            Yearly = 4
        }
        public enum DisplayOnPage
        {
            MainPage = 1,
            DetailPage = 2,
            MoreDetailPage = 3
        }
        public enum CarType
        {
            Bus = 1,
            Truck = 2,
            PrivateCar = 3,
            MotorCycle = 4
        }
        public enum CarCondition
        {
            New = 1,
            Recondition = 2,
            Old = 3
        }
        public enum ListItemType
        {
            All = 0,
            City = 1,
            State = 2,
            Country = 3,
            DivisionOrState = 103,
            District = 5,
            PoliceStaion = 6,
            PostOffice = 7,

            GuideLineDetail = 129,
            GuideLine = 128,
            BussinessEnergyType = 127,
            CMSTypeID = 126,

            NewsType = 999,
            CardType = 601,
            BalanceType = 602,
            CardInfo = 603,

            MortgageType = 501,
            MortgageOperationType = 502,
            InterestRateType = 503,
            PaymentType = 504,
            CompanyInfo = 505,
            MortgageTermYear = 506,
            MPModel = 199,

            Sex = 4,
            Designation = 101,
            EducationType = 10,
            BussinessType = 20,
            UserGroup = 25,
            UrlList = 30,
            UserTypeID = 21,
            Category = 32,    /* Hasan Add 2015.03.4*/
            Company = 58,
            None = 100,
            RegionTypeID = 99,    // Add By Tanvir 30.03.2015
            CardInformation = 75,  // Add By Tanvir 30.03.2015
            LoanAmtYearSchedule = 905,
            UsableDataUnit = 900,
            ConnectionType = 901,
            TalkTimeUnit = 902,
            AvailableSIM = 903,
            NetworkServiceProvider = 904,
            MPType = 90,
            PremiumPolicy = 933,
            LISchema = 934,
            LoanType = 150,

            SmokerType = 5001,
            WantMoreInfo = 5002,
            Profession = 5003,
            Insurance = 5004,
            BIAmountType = 5005,
            BroadBandType=5006,
            NetGenerationType=5007


        }
        public enum UsableDataUnit
        {
            KB = 1,
            MB = 2,
            GB = 3,
        }
        public enum ConnectionType
        {
            TwoG = 1,
            ThreeG = 2,
            ThreePointFiveG = 3,
            FourG = 4,
            FourPointFiveG = 5,
            FiveG = 6
        }
        public enum TalkTimeUnit
        {
            Minute = 1,
            Hour = 2,
            Day = 3
        }
        public enum AvailableSIM
        {
            None = 1,
            Single_SIM = 2,
            Dual_SIM = 3,
            Three_SIM = 4
        }
        public enum NetworkServiceProvider
        {
            GrameenPhone = 1,
            Airtel = 2,
            Banglalink = 3,
            Teletalk = 4,
            Robi = 5
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
        public enum BussinessType
        {

            Energy = 1,
            Banking = 2,
            Travel = 3,
            Insurance = 4,
            Shopping = 5,
            MobilePhone = 6,
            NetworkServiceProvider = 7,
            Broadband = 8,
            NewsAndCommunity = 9,
            Construction = 10,
            Medicine = 11

        }

        public enum BooleanString
        {
            True = 1,
            False = 2
        }

        public enum OperationName
        {
            AddNewData = 1,
            UpdateData = 2,
            DeleteData = 3,
            CancelData = 4
        }

        public enum Browsers
        {
            Chrome = 1,
            Firefox = 2,
            InternetExplorer = 3,
            Safari = 4,
            Opera = 5,
            Other = 6

        }

        public enum ButtonDisplayText
        {
            Save = 1,
            Update = 2,
            Delete = 3,
            Cancel = 4
        }

        public enum ClientType
        {
            Personal = 1,
            OrganiztionOrCompany = 2
        }
        public enum UserGrpType
        {
            Control_User = 1,
            Management = 2,
            Add_Giver = 3

        }

        public enum CardType
        {
            //Debit = 1,
            //Credit =2,

            Visa = 1,
            Master = 2,
            AmericanExpress = 3
        }

        public enum BalanceType
        {
            Savings = 1,
            Current = 2,
            Deposit = 3,
            Smart = 4

        }
        public enum Type
        {
            BroadbandWireConnection = 1,
            MobileBroadbandWirelessconnection = 2,
            Broadband = 3,
            TV = 4
        }

        public enum RegionType
        {
            Asia = 1,
            Europe = 2,
            America = 3,
            Africa = 4

        }

        public enum LoanType
        {
            Personal = 1,
            Car = 2,
            Marriage = 3,
            Home = 4,
            SME = 5
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
