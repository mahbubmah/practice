using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Basic;
using System.Data;
using Utilities;
using System.Drawing;

namespace BLL.Basic
{
    public class MortgageRT : IDisposable
    {
        private readonly OiiOMartDBDataContext _OiiOMartDBDataContext;
        public MortgageRT()
        {
            _OiiOMartDBDataContext = DatabaseHelper.GetDataModelDataContext();
        }
        public class MortgageForListView
        {
            public Int64 IID { get; set; }
            public string CompanyName { get; set; }
            public string MortageType { get; set; }
            public string InterestRateType { get; set; }
            public int? MortgageTermYear { get; set; }
            public string PaymentType { get; set; }
            public decimal? FeeOrCharge { get; set; }
            public double? APR { get; set; }
            public DateTime PostAdDate { get; set; }
            public DateTime PostLastDisplayDate { get; set; }
            public string RedirectUrl { get; set; }

        }

        #region Get Methods

        public List<MortgageForListView> GetAllMortgageForListView()
        {
            try
            {
                List<MortgageForListView> mortDisplayList = new List<MortgageForListView>();
                var mortgageList = _OiiOMartDBDataContext.SP_GetAllMortgageForListView().ToList();
                foreach (var mort in mortgageList)
                {
                    var mortDisplay = new MortgageForListView();
                    mortDisplay.IID = mort.IID;
                    mortDisplay.CompanyName = mort.CompanyName;
                    mortDisplay.MortgageTermYear = mort.MortgageTermYear;
                    mortDisplay.FeeOrCharge = mort.FeeOrCharge;
                    mortDisplay.APR = mort.APR;
                    mortDisplay.PostAdDate = mort.PostAdDate;
                    mortDisplay.PostLastDisplayDate = mort.PostLastDisplayDate;
                    mortDisplay.RedirectUrl = mort.RedirectUrl;

                    switch (mort.MortageType)
                    {
                        case 1:
                            mortDisplay.MortageType = "Conventional";
                            break;
                        case 2:
                            mortDisplay.MortageType = "Government";
                            break;
                        case 3:
                            mortDisplay.MortageType = "Rural home financing program";
                            break;
                        case 4:
                            mortDisplay.MortageType = "Home opportunities program";
                            break;
                        case 5:
                            mortDisplay.MortageType = "None prime or subprime";
                            break;
                    }
                    switch (mort.PaymentType)
                    {
                        case 1:
                            mortDisplay.PaymentType = "Regular principal and interest payment";
                            break;
                        case 2:
                            mortDisplay.PaymentType = "Interest only payment";
                            break;
                        case 3:
                            mortDisplay.PaymentType = "Balloon payment";
                            break;
                        case 4:
                            mortDisplay.PaymentType = "Prepayment with no penalty or fee";
                            break;
                        case 5:
                            mortDisplay.PaymentType = "Prepayment with a penalty or fee";
                            break;
                    }
                    //switch (mort.InterestRateType)
                    //{
                    //    case 1:
                    //        mortDisplay.InterestRateType = "Fixed rate mortgage(FRM)";
                    //        break;
                    //    case 2:
                    //        mortDisplay.InterestRateType = "Adjustable rate mortgage(ARM)";
                    //        break;
                    //    case 3:
                    //        mortDisplay.InterestRateType = "Initial Monthly Payment";
                    //        break;
                    //}
                    mortDisplayList.Add(mortDisplay);
                }
                return mortDisplayList;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }

        }

        #endregion Get Methods




        #region IDisposable Members

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members


        public MortgageTypeInfo GetMortgageTypeInfoTopOne()
        {
            try
            {
                MortgageTypeInfo type = new MortgageTypeInfo();
                type = _OiiOMartDBDataContext.MortgageTypeInfos.First();
                return type;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public List<MortgageType> GetAllMortgageTypeInfo()
        {
            try
            {
                List<MortgageTypeInfo> typeList = new List<MortgageTypeInfo>();
                typeList = _OiiOMartDBDataContext.MortgageTypeInfos.ToList();
                List<MortgageType> lst = new List<MortgageType>();
                foreach (MortgageTypeInfo type in typeList)
                {
                    MortgageType t = new MortgageType();
                    switch (type.IID)
                    {
                        case 1:
                            t.IID = type.IID;
                            t.Name = "Conventional";
                            t.Description = type.Description;
                            t.ImageUrl = type.ImageUrl;
                            break;
                        case 2:
                            t.IID = type.IID;
                            t.Name = "Government";
                            t.Description = type.Description;
                            t.ImageUrl = type.ImageUrl;
                            break;
                        case 3:
                            t.IID = type.IID;
                            t.Name = "Rural Home Financing Program";
                            t.Description = type.Description;
                            t.ImageUrl = type.ImageUrl;
                            break;

                        case 4:
                            t.IID = type.IID;
                            t.Name = "Home Opportunities Program";
                            t.Description = type.Description;
                            t.ImageUrl = type.ImageUrl;
                            break;
                        case 5:

                            t.IID = type.IID;
                            t.Name = "None prime Or Subprime";
                            t.Description = type.Description;
                            t.ImageUrl = type.ImageUrl;
                            break;
                    }
                    lst.Add(t);
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public int SelectMortgageCount(int mortgageTypeID, int rateTypeID, int paymentTypeID, int periodID)
        {
            try
            {
                var mortgageRowCount = _OiiOMartDBDataContext.SP_GetAllMorgagesCount(mortgageTypeID, paymentTypeID, rateTypeID, periodID).ToList();
                // var mortgageRowCount = _OiiOMartDBDataContext.Mortgages.ToList();
                return mortgageRowCount.Count;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        public object SelectAllList(int noOfStartRowIndex, int noOfMaximumRows, int mortgageTypeID, int paymentTypeID, int rateTypeID, int periodID)
        {
            try
            {
                var list = _OiiOMartDBDataContext.SP_GetAllMorgageWithInterestRate(noOfStartRowIndex, noOfMaximumRows, mortgageTypeID, paymentTypeID, rateTypeID, periodID);
                return list;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
        public List<MortgageType> GetFourMortgageTypeInfo()
        {
            try
            {
                var typeList = _OiiOMartDBDataContext.SP_GetFourMortgageType();
                List<MortgageType> lst = new List<MortgageType>();
                foreach (var type in typeList)
                {
                    MortgageType t = new MortgageType();
                    switch (type.IID)
                    {
                        case 1:
                            t.IID = type.IID;
                            t.Name = "Conventional";
                            t.Description = type.Description;
                            t.ImageUrl = type.ImageUrl;
                            break;
                        case 2:
                            t.IID = type.IID;
                            t.Name = "Government";
                            t.Description = type.Description;
                            t.ImageUrl = type.ImageUrl;
                            break;
                        case 3:
                            t.IID = type.IID;
                            t.Name = "Rural Home Financing Program";
                            t.Description = type.Description;
                            t.ImageUrl = type.ImageUrl;
                            break;

                        case 4:
                            t.IID = type.IID;
                            t.Name = "Home Opportunities Program";
                            t.Description = type.Description;
                            t.ImageUrl = type.ImageUrl;
                            break;
                        case 5:

                            t.IID = type.IID;
                            t.Name = "None prime Or Subprime";
                            t.Description = type.Description;
                            t.ImageUrl = type.ImageUrl;
                            break;
                    }
                    lst.Add(t);
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public object GetMortgageInterestRateByMortgageIID(Int64 MortgageID)
        {
            try
            {
                var InterestRate = _OiiOMartDBDataContext.MortgageInterestRates.Where(d => d.MortgageID == MortgageID && d.IsRemoved == false);
                return InterestRate;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
        public object GetMortgageProvider()
        {
            try
            {
                var mortgagaeProvider = _OiiOMartDBDataContext.SP_GetAllMortgageProvider();
                return mortgagaeProvider;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        public Mortgage GetMortgageById(long mortgageId)
        {
            try
            {
                var mortgagae = _OiiOMartDBDataContext.Mortgages.SingleOrDefault(mort => mort.IID == mortgageId);
                return mortgagae;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        public void UpdateMortgage(Mortgage mortgage)
        {
            try
            {
                Mortgage MortgageNew = _OiiOMartDBDataContext.Mortgages.SingleOrDefault(d => d.IID == mortgage.IID);
                DatabaseHelper.Update<Mortgage>(_OiiOMartDBDataContext, mortgage, MortgageNew);
                OiiOMartDBDataContext db = DatabaseHelper.GetDataModelDataContext();
                db.UpadateInterestRateTypeByMortgageID(mortgage.IID);
                // _OiiOMartDBDataContext.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void UpdateMortgageAndInterestRateType(Mortgage objMortgage, List<MortgageInterestRate> list)
        {
            try
            {
                Mortgage mortgage = _OiiOMartDBDataContext.Mortgages.Single(d => d.IID == objMortgage.IID);
                DatabaseHelper.Update<Mortgage>(_OiiOMartDBDataContext, objMortgage, mortgage);

                _OiiOMartDBDataContext.UpadateInterestRateTypeByMortgageID(objMortgage.IID);
                _OiiOMartDBDataContext.Dispose();

                foreach (MortgageInterestRate rate in list)
                {
                    rate.MortgageID = objMortgage.IID;
                    DatabaseHelper.Insert<MortgageInterestRate>(rate);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        public void AddMortgage(Mortgage mortgage)
        {
            try
            {
                DatabaseHelper.Insert<Mortgage>(mortgage);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
        public void AddMortageAndInterestRateType(Mortgage mortgage, List<MortgageInterestRate> list)
        {
            try
            {
                DatabaseHelper.Insert<Mortgage>(mortgage);
                foreach (MortgageInterestRate rate in list)
                {
                    rate.MortgageID = mortgage.IID;
                    DatabaseHelper.Insert<MortgageInterestRate>(rate);
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public List<MortgageInterestRate> GetAllInterestTypeByMortgageIID(Int64? mortgageID)
        {
            List<MortgageInterestRate> typeList = new List<MortgageInterestRate>();
            try
            {
                typeList = _OiiOMartDBDataContext.MortgageInterestRates.Where(d => d.MortgageID == mortgageID && d.IsRemoved == false).ToList();
                return typeList;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public object GetAllUptoYear()
        {
            try
            {
                var upToYearList = _OiiOMartDBDataContext.SP_GetAllUpToYear();
                return upToYearList.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public static int InsertMortgageAndInterestRateChildXML(string objectXML)
        {
            try
            {
                return MortgageDA.InsertMortgageAndInterestRateChildXML(objectXML);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public DataTable DisplayMortgageData()
        {
            DataTable table = new DataTable();

           // table.Columns.Add("IID");
            table.Columns.Add("CompanyName");
            table.Columns.Add("OperationType");
            table.Columns.Add("MortgageType");
            // table.Columns.Add("InterestRateType");
            table.Columns.Add("PaymentType");
            table.Columns.Add("APR");
            table.Columns.Add("Description");
            table.Columns.Add("LTV");
            table.Columns.Add("PropertyValueMinAmt");
            table.Columns.Add("PropertyValueMaxAmt");
            table.Columns.Add("MonthlyInstallmentAmt");
            table.Columns.Add("IsPostAdExtended");
            table.Columns.Add("PostAdDate");
            table.Columns.Add("PostLastDisplayDate");
            table.Columns.Add("PaymentAmt");
            table.Columns.Add("IsVerified");
            table.Columns.Add("RedirectUrl");
            table.Columns.Add("ImageUrl", System.Type.GetType("System.Byte[]"));

            SP_GetRecentlySavedResult mort = (SP_GetRecentlySavedResult)_OiiOMartDBDataContext.SP_GetRecentlySaved().Single();
           
            DataRow row = table.NewRow();
            //row["IID"] = mort.IID;
            row["CompanyName"] = mort.Name;
            row["OperationType"] = EnumHelper.EnumToStringWithSpace<EnumCollection.MortgageOperationType>(mort.OperationTypeID);
            row["MortgageType"] = EnumHelper.EnumToStringWithSpace<EnumCollection.MortgageType>(mort.TypeID);
            row["PaymentType"] = EnumHelper.EnumToStringWithSpace<EnumCollection.PaymentType>(mort.PaymentTypeID);
            //row["InterestRateType"] = EnumHelper.EnumToStringWithSpace<EnumCollection.InterestRateType>(mort.rateType);
            row["APR"] = mort.APR;
            row["Description"] = mort.Description;
            row["LTV"] = mort.LTV;
            row["PropertyValueMinAmt"] = mort.PropertyValueMinAmt;
            row["PropertyValueMaxAmt"] = mort.PropertyValueMaxAmt;
            row["MonthlyInstallmentAmt"] = mort.MonthlyInstallmentAmt;
            row["IsPostAdExtended"] = mort.IsPostAdExtended;
            row["PostAdDate"] = mort.PostAdDate;
            row["PostLastDisplayDate"] = mort.PostLastDisplayDate;
            row["PaymentAmt"] = mort.PaymentAmt;
            row["IsVerified"] = mort.IsVerified;
            row["RedirectUrl"] = mort.RedirectUrl;
          //  Image currentPicture = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory+mort.LogoUrl);
            Image currentPicture = Image.FromFile(@"E:\Project\OiiO Mart\OMart.Web\Images\Interfaces\2.png");
            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(currentPicture, typeof(byte[]));
           // Bitmap image = new Bitmap(currentPicture);
            row["ImageUrl"] = xByte;

            table.Rows.Add(row);

            return table;

        }
    }
}
