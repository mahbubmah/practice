using DAL;
using DAL.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using Utilities;

namespace BLL.Basic
{
    public class MobilePhoneInfoRT: IDisposable
    {

        private readonly OiiOMartDBDataContext _OiiOMartDBDataContext;
        public MobilePhoneInfoRT()
        {
            this._OiiOMartDBDataContext = DatabaseHelper.GetDataModelDataContext();
        }

        public void AddMobilePhoneInfo(MobilePhoneInfo _MobilePhoneInfo)
        {
            try
            {
                DatabaseHelper.Insert<MobilePhoneInfo>(_MobilePhoneInfo);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message, ex); }
        }

        public void UpdateMobilePhoneInfo(MobilePhoneInfo _MobilePhoneInfo)
        {
            try
            {
                MobilePhoneInfo mobileNew = _OiiOMartDBDataContext.MobilePhoneInfos.SingleOrDefault(d => d.IID == _MobilePhoneInfo.IID);

                DatabaseHelper.Update<MobilePhoneInfo>(_OiiOMartDBDataContext, _MobilePhoneInfo, mobileNew);

                //_OiiOMartDBDataContext.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public void UpdateMobilePhoneInfoAndMPFeature(MobilePhoneInfo _MobilePhoneInfo, List<MPFeature> featureList)
        {
            try
            {
                MobilePhoneInfo mpInfoNew = _OiiOMartDBDataContext.MobilePhoneInfos.SingleOrDefault(d => d.IID == _MobilePhoneInfo.IID);
                DatabaseHelper.Update<MobilePhoneInfo>(_OiiOMartDBDataContext, _MobilePhoneInfo, mpInfoNew);
                OiiOMartDBDataContext db = DatabaseHelper.GetDataModelDataContext();
                db.DeleteMPFeatureByMobilePhoneInfoID(_MobilePhoneInfo.IID);

                foreach (MPFeature feature in featureList)
                {
                    feature.MobilePhoneID = _MobilePhoneInfo.IID;
                    DatabaseHelper.Insert<MPFeature>(feature);
                }
                // _OiiOMartDBDataContext.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        public MobilePhoneInfo GetMobilePhoneInfoByIID(Int64 mobileID)
        {
            try
            {
                MobilePhoneInfo mobilephoneID = _OiiOMartDBDataContext.MobilePhoneInfos.SingleOrDefault(d => d.IID == mobileID);
                //_OiiOMartDBDataContext.Dispose();
                return mobilephoneID;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<MobilePhoneInfo> GetAllMobilePhoneInfos()
        {
            try
            {
                List<MobilePhoneInfo> mobilephoneColl = _OiiOMartDBDataContext.MobilePhoneInfos.OrderBy(x => x.IID).ToList();
                return mobilephoneColl;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<MobilePhoneInfo> GetAllMobilePhoneInfoForTotalTalkTime()
        {
            try
            {
                List<MobilePhoneInfo> mobilephoneColl = _OiiOMartDBDataContext.MobilePhoneInfos.GroupBy(mpGrouping => mpGrouping.TotalTalkTime).Select(mpGroup => mpGroup.First()).ToList();

                return mobilephoneColl;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<MobilePhoneInfo> GetAllMobilePhoneInfoForTotalUsableData()
        {
            try
            {
                List<MobilePhoneInfo> mobilephoneColl = _OiiOMartDBDataContext.MobilePhoneInfos.GroupBy(mpGrouping => mpGrouping.TotalUsableData).Select(mpGroup => mpGroup.First()).ToList();

                return mobilephoneColl;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<MobilePhoneInfo> GetAllMobilePhoneInfoForTotalTextMessage()
        {
            try
            {
                List<MobilePhoneInfo> mobilephoneColl = _OiiOMartDBDataContext.MobilePhoneInfos.GroupBy(mpGrouping => mpGrouping.TotalTextMessage).Select(mpGroup => mpGroup.First()).ToList();

                return mobilephoneColl;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<MobilePhoneInfo> GetAllMobilePhoneInfoForMonthlyInstallmentAmt()
        {
            try
            {
                List<MobilePhoneInfo> mobilephoneColl = _OiiOMartDBDataContext.MobilePhoneInfos.GroupBy(mpGrouping => mpGrouping.MonthlyInstallmentAmt).Select(mpGroup => mpGroup.First()).ToList();

                return mobilephoneColl;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<CompanyInfo> GetAllBrandNames()
        {
            try
            {
                //List<CompanyInfo> mobileBrandList = _OiiOMartDBDataContext.CompanyInfos.OrderBy(x => x.IID).ToList();
                List<CompanyInfo> mobileBrandList = _OiiOMartDBDataContext.CompanyInfos.ToList();
                return mobileBrandList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        //public object GetAllMobilePhoneInformations()
        //{
        //    try
        //    {
        //        OiiOMartDBDataContext dbContext = DatabaseHelper.GetDataModelDataContext();

        //        var companies = (from mobile in dbContext.MobilePhoneInfos
        //                               join company in dbContext.CompanyInfos
        //                               on mobile.CompanyInfoID equals company.IID
        //                               join mpType in dbContext.MPTypes
        //                               on mobile.MPTypeID equals mpType.IID
        //                               where mobile.IsRemoved !=null 
        //                               select new MobilePhoneInformation
        //                               {
        //                                   CompanyName = company.Name,
        //                                   NetworkProviderID = mobile.NetworkProviderID,
        //                                   MPTypeName = mpType.TypeName,
        //                                   SIMAvailableID = mobile.SIMAvailableID,
        //                                   TalkTimeUnitID = mobile.TalkTimeUnitID,
        //                                   UsableDataUnitID = mobile.UsableDataUnitID,
        //                                   ConnectionTypeID = mobile.ConnectionTypeID,

        //                                   TotalTalkTime = mobile.TotalTalkTime,

        //                                   ModelName = mobile.ModelName,
        //                                   TotalTextMessage = mobile.TotalTextMessage,
        //                                    TotalUsableData =mobile.TotalUsableData,

        //                                    TotalPrice = mobile.TotalPrice,
        //                                   ContractDuration = mobile.ContractDuration,
        //                                    MonthlyInstallmentAmt = mobile.MonthlyInstallmentAmt,
        //                                   WarrantyInfo = mobile.WarrantyInfo,
        //                                   PictureUrl = mobile.PictureUrl,
        //                                   PostAdDate = mobile.PostAdDate,
        //                                   PostLastDisplayDate = mobile.PostLastDisplayDate,
        //                                   RedirectUrl = mobile.RedirectUrl,
        //                                   IsRemoved = mobile.IsRemoved
        //                               }).OrderBy(x => x.CompanyName).ToList();

        //        return companies;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex);
        //    }

        //}

        public List<MobilePhoneInformation> GetAllMobilePhoneInformations()
        {
            try
            {
                List<MobilePhoneInformation> _MobilePhoneInformationDisplayList = new List<MobilePhoneInformation>();
                var mobileList = _OiiOMartDBDataContext.SP_GetAllMobileInfoForListView().ToList();
                foreach (var mobile in mobileList)
                {
                    var mobilePhoneDisplay = new MobilePhoneInformation();
                    mobilePhoneDisplay.IID = mobile.IID;
                    mobilePhoneDisplay.CompanyName = mobile.CompanyName;
                    mobilePhoneDisplay.MPTypeName = mobile.MPTypeName;
                    mobilePhoneDisplay.TotalTalkTime = mobile.TotalTalkTime;
                    mobilePhoneDisplay.ModelName = mobile.ModelName;
                    mobilePhoneDisplay.TotalTextMessage = mobile.TotalTextMessage;
                    mobilePhoneDisplay.TotalUsableData = mobile.TotalUsableData;
                    mobilePhoneDisplay.TotalPrice = mobile.TotalPrice;
                    mobilePhoneDisplay.ContractDuration = mobile.ContractDuration;
                    mobilePhoneDisplay.MonthlyInstallmentAmt = mobile.MonthlyInstallmentAmt;
                    mobilePhoneDisplay.WarrantyInfo = mobile.WarrantyInfo;
                    mobilePhoneDisplay.PictureUrl = mobile.PictureUrl;
                    mobilePhoneDisplay.PostAdDate = mobile.PostAdDate;
                    mobilePhoneDisplay.PostLastDisplayDate = mobile.PostLastDisplayDate;
                    mobilePhoneDisplay.RedirectUrl = mobile.RedirectUrl;

                    mobilePhoneDisplay.NetworkServiceProvider = ((Utilities.EnumCollection.NetworkServiceProvider)mobile.NetworkServiceProvider).ToString();
                    mobilePhoneDisplay.UsableDataUnit = ((Utilities.EnumCollection.UsableDataUnit)mobile.UsableDataUnit).ToString();
                    mobilePhoneDisplay.TalkTimeUnit = ((Utilities.EnumCollection.TalkTimeUnit)mobile.TalkTimeUnit).ToString();
                    mobilePhoneDisplay.ConnectionType = ((Utilities.EnumCollection.ConnectionType)mobile.ConnectionType).ToString();
                    mobilePhoneDisplay.SIMAvailable = ((Utilities.EnumCollection.AvailableSIM)mobile.SIMAvailable).ToString();

                    /*                     
                    switch (mobile.NetworkServiceProvider)
                    {
                        case 1:
                            mobilePhoneDisplay.NetworkServiceProvider = "Grameen Phone";
                            break;
                        case 2:
                            mobilePhoneDisplay.NetworkServiceProvider = "Airtel";
                            break;
                        case 3:
                            mobilePhoneDisplay.NetworkServiceProvider = "Banglalink";
                            break;
                        case 4:
                            mobilePhoneDisplay.NetworkServiceProvider = "Teletalk";
                            break;
                        case 5:
                            mobilePhoneDisplay.NetworkServiceProvider = "Aktel";
                            break;
                    }
                    switch (mobile.UsableDataUnit)
                    {
                        case 1:
                            mobilePhoneDisplay.UsableDataUnit = "MB";
                            break;
                        case 2:
                            mobilePhoneDisplay.UsableDataUnit = "GB";
                            break;

                    }
                    switch (mobile.TalkTimeUnit)
                    {
                        case 1:
                            mobilePhoneDisplay.TalkTimeUnit = "Minute";
                            break;
                        case 2:
                            mobilePhoneDisplay.TalkTimeUnit = "Hour";
                            break;
                        case 3:
                            mobilePhoneDisplay.TalkTimeUnit = "Day";
                            break;
                    }
                    switch (mobile.ConnectionType)
                    {
                        case 1:
                            mobilePhoneDisplay.ConnectionType = "2G";
                            break;
                        case 2:
                            mobilePhoneDisplay.ConnectionType = "3G";
                            break;
                        case 3:
                            mobilePhoneDisplay.ConnectionType = "4G";
                            break;
                        case 4:
                            mobilePhoneDisplay.ConnectionType = "3.5G";
                            break;
                        case 5:
                            mobilePhoneDisplay.ConnectionType = "4.5G";
                            break;
                    }
                    switch (mobile.SIMAvailable)
                    {
                        case 1:
                            mobilePhoneDisplay.SIMAvailable = "None";
                            break;
                        case 2:
                            mobilePhoneDisplay.SIMAvailable = "Single SIM";
                            break;
                        case 3:
                            mobilePhoneDisplay.SIMAvailable = "Dual SIM";
                            break;
                        case 4:
                            mobilePhoneDisplay.SIMAvailable = "Three SIM";
                            break;

                    }
                    */
                    _MobilePhoneInformationDisplayList.Add(mobilePhoneDisplay);
                }
                return _MobilePhoneInformationDisplayList;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }

        }
        public static int InsertMobilePhoneInfoAndFeatureChildXML(string objectXML)
        {
            try
            {
                return MobilePhoneInfoDA.InsertMobilePhoneInfoAndFeatureChildXML(objectXML);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<MPFeature> GetAllFeatureByMPIID(Int64? mpIID)
        {
            List<MPFeature> featureList = new List<MPFeature>();
            try
            {
                featureList = _OiiOMartDBDataContext.MPFeatures.Where(d => d.MobilePhoneID == mpIID && d.IsRemoved==false).ToList();
                // _OiiOMartDBDataContext.Dispose();
                return featureList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }



        #region IDisposable Members
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members
        public class MobilePhoneInformation
        {
            public Int64 IID { get; set; }

            public string CompanyName { get; set; }
            public string ModelName { get; set; }

            public string NetworkServiceProvider { get; set; }
            public string MPTypeName { get; set; }
            public string SIMAvailable { get; set; }
            public int? TotalTalkTime { get; set; }
            public int? TotalTextMessage { get; set; }
            public decimal? TotalUsableData { get; set; }
            public string UsableDataUnit { get; set; }
            public string ConnectionType { get; set; }
            public string TalkTimeUnit { get; set; }
            public int? ContractDuration { get; set; }
            public string WarrantyInfo { get; set; }
            public string RedirectUrl { get; set; }
            public string PictureUrl { get; set; }
            public DateTime PostAdDate { get; set; }
            public DateTime PostLastDisplayDate { get; set; }

            public decimal? TotalPrice { get; set; }
            public decimal? MonthlyInstallmentAmt { get; set; }

            public bool IsRemoved { get; set; }


        }


        public List<spGetAllMobilePhoneInformationResult> GetMobilePhoneAllInformation()
        {
            return _OiiOMartDBDataContext.spGetAllMobilePhoneInformation().Take(10).ToList();
        }
        public List<spGetTopTenMobilePhoneInformationResult> GetTopTenMobilePhone()
        {
            // List<spGetTopOneMobilePhoneInformationResult> rr = new List<spGetTopOneMobilePhoneInformationResult>();
            var rr = _OiiOMartDBDataContext.spGetTopTenMobilePhoneInformation().OrderByDescending(x=>x.TotalPrice).ToList();
            return rr;
        }

        //public object GetAllMobileTypeAndModel()
        //{   
        //    var mobilePhoneTypeModelList = from mp in _OiiOMartDBDataContext.MPTypes
        //                                   join mb in _OiiOMartDBDataContext.MobilePhoneInfos
        //                                   on mp.IID equals mb.MPTypeID
        //                                   select new
        //                                   {
        //                                       mp.TypeName,
        //                                       mb.ModelName
        //                                   };
        //    return mobilePhoneTypeModelList;

        //}

        public object GetModelNameByCompanyID(int p)
        {
            //try
            //{
            //    OiiOMartDBDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
            //    //AdGiverTracing Registereduser = new AdGiverTracing();
            //    List<MPType> modelList = new List<MPType>();
            //    modelList = dbContext.MPTypes.Where(d => d.CompanyInfoID == p).ToList();
            //    dbContext.Dispose();
            //    return modelList;
            //}
            //catch (Exception ex) { throw new Exception(ex.Message, ex); }

            return (_OiiOMartDBDataContext.spGetModelNameByCompanyName(p));
        }

        public List<SpGetAllMobileDetailByCompanynModelResult> GetAllDataForBrandAndModelForListView(int BrandID, string ModelName)
        {
            var obj = _OiiOMartDBDataContext.SpGetAllMobileDetailByCompanynModel(BrandID, ModelName);
            return obj.ToList();

        }

        public List<spGetAllMobileTypeAndModelByCompanyInfoIDResult> GetModelByCompanyID(int companyInfoID)
        {
            var anotherobj = _OiiOMartDBDataContext.spGetAllMobileTypeAndModelByCompanyInfoID(companyInfoID);
            return anotherobj.ToList();
        }

        public List<spGetAllProductsForIndividualManufacturerResult> GetAllDataForIndividualManufacturerForListview(int manuID)
        {
            var aobj = _OiiOMartDBDataContext.spGetAllProductsForIndividualManufacturer(manuID);
            return aobj.ToList();

        }

        public List<spGetAllDataAccordingToNetworkServiceProviderResult> GetAllDataForIndividualOperatorForListView(int operatorID)
        {
            var opobj = _OiiOMartDBDataContext.spGetAllDataAccordingToNetworkServiceProvider(operatorID);
            return opobj.ToList();
        }

        public object GetAllInfoAccordingToMinute(int minuteID)
        {
            throw new NotImplementedException();
        }

        public object GettAllInfoAccordingTonNmberOfText(int textNumberID)
        {
            throw new NotImplementedException();
        }

        public object GettAllInfoAccordingToData(int dataID)
        {
            throw new NotImplementedException();
        }

        public object GettAllInfoAccordingToMonthlyCost(int monthlyCostID)
        {
            throw new NotImplementedException();
        }

        public object GettAllInfoAccordingToUpfrontCost(int upfrontCostID)
        {
            throw new NotImplementedException();
        }




        public List<GetMobileInfoListForSearchResult> GetMobilePhoneInfoSearchResultList(int? seManufactureId, int? seMpTypeId, string seModelName, int? seTalktime, int? seTalkTimeUnitId, decimal? seData, int? seDataUnitId, decimal? seMontlyAmount, int? seNetworkProviderID)
        {
            try
            {
                var mobilePhoneInfoListBySearch = _OiiOMartDBDataContext.GetMobileInfoListForSearch(seManufactureId, seMpTypeId, seModelName, seTalktime, seTalkTimeUnitId, seData, seDataUnitId, seMontlyAmount, seNetworkProviderID).ToList();

                //var listForDisplay = from mpInfo in mobilePhoneInfoListBySearch
                //    select new
                //    {
                       
                //    };
                
                return mobilePhoneInfoListBySearch;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message,ex);
            }
          
        }

        public object GetAllNetWorkProviderCompany()
        {
            try
            {
                var networkProvierCompanyList =
                    from companyInfo in
                        _OiiOMartDBDataContext.CompanyInfos.Where(
                            x =>
                                x.BussinessTypeID ==
                                Convert.ToInt16(EnumCollection.BussinessType.NetworkServiceProvider) 
                                && x.IsRemoved==false)
                    select new
                    {
                        companyInfo.IID,
                        companyInfo.LogoUrl
                    };

                return networkProvierCompanyList;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
    }
}