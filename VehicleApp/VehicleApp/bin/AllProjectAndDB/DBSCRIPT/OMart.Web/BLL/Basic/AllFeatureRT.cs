using DAL;
using DAL.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace BLL.Basic
{
    public class AllFeatureRT : IDisposable
    {
        public class AllNewsForListViewDisplay
        {
            public int IID { get; set; }
            public string TitleName { get; set; }
            public string Description { get; set; }
            public string BusinessType { get; set; }
            public string BusinessTypeBreakdown { get; set; }
            public string ImageUrl { get; set; }
            public DateTime ReleaseDate { get; set; }
        }
        private readonly OiiOMartDBDataContext dbContext;

        public AllFeatureRT()
        {
            dbContext = DatabaseHelper.GetDataModelDataContext();
        }

        public static int InsertAllFetureAndAllChildAllFeatureCartDetailsXML(string objectXML)
        {
            try
            {
                return AllFeatureDA.InsertAllFatureAndAllChildAllFeatureDetailsXML(objectXML);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public void AddAllFeature(AllFeature allFeature)
        {
            try
            {
                DatabaseHelper.Insert<AllFeature>(allFeature);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
        public void UpdateAllFeature(AllFeature allFeature)
        {
            try
            {

                AllFeature allFeatureNew = dbContext.AllFeatures.Single(d => d.IID == allFeature.IID);
                DatabaseHelper.Update<AllFeature>(dbContext, allFeature, allFeatureNew);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        #region IDisposable Members
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members

        public AllFeature GetAllFeatureById(int iid)
        {
            try
            {

                AllFeature allFeature = dbContext.AllFeatures.SingleOrDefault(d => d.IID == iid);
                return allFeature;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
        public List<AllFeature> GetAllFeatureListById(int iid)
        {
            try
            {

                List<AllFeature> allFeature = dbContext.AllFeatures.Where(d => d.IID == iid).ToList();
                return allFeature;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public List<AllFeatureDetail> GetAllFeatureDetailListByAllFeatureId(int allFeatureId)
        {
            try
            {
                List<AllFeatureDetail> allFeatureDetailList = dbContext.AllFeatureDetails.Where(x => x.AllFeatureID == allFeatureId && x.IsRemoved == false).ToList();
                return allFeatureDetailList;
            }
            catch (Exception ex)
            { throw new Exception(ex.Message, ex); }
        }
        public List<AllFeatureDetail> GetAllDetailListByFeatureIId(int allFeatureId)
        {
            try
            {
                List<AllFeatureDetail> allFeatureDetailList = dbContext.AllFeatureDetails.Where(x => x.AllFeatureID == allFeatureId && x.IsRemoved == false).ToList();
                return allFeatureDetailList;
            }
            catch (Exception ex)
            { throw new Exception(ex.Message, ex); }
        }
        public List<AllFeatureDetail> GetAllFeatureDetailListByDetailsIID(int detailsIID)
        {
            try
            {
                List<AllFeatureDetail> allFeatureDetail = dbContext.AllFeatureDetails.Where(x => x.IID == detailsIID && x.IsRemoved == false).ToList();
                return allFeatureDetail;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public void UpdateAllFeatureDetail(AllFeatureDetail allFeatureDetailNew)
        {
            try
            {

                AllFeatureDetail allFeatureDetail = dbContext.AllFeatureDetails.Single(d => d.IID == allFeatureDetailNew.IID);
                DatabaseHelper.Update<AllFeatureDetail>(dbContext, allFeatureDetailNew, allFeatureDetail);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public void AddAllFeatureDetail(AllFeatureDetail allFeatureDetail)
        {
            try
            {
                DatabaseHelper.Insert<AllFeatureDetail>(allFeatureDetail);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public object GetAllFeatureForListViewDisplay()
        {
            try
            {

                try
                {
                    var allFeatureList = dbContext.AllFeatures.Where(x => x.IsRemoved == false).ToList();
                    List<AllFeatureExtract> lst = new List<AllFeatureExtract>();
                    foreach (AllFeature sp in allFeatureList)
                    {
                        AllFeatureExtract ex = new AllFeatureExtract();
                        ex.IID = sp.IID;
                        ex.TitleName = sp.TitleName;
                        ex.ImageUrl = sp.ImageUrl;
                        ex.Description = sp.Description;
                        ex.BusinessTypeBreakdownID = sp.BusinessTypeBreakdownID;
                        // ex.BussinessTypeName= GetNameWithSpace(sp.BusinessTypeID);
                        ex.BussinessTypeName = EnumHelper.EnumToStringWithSpace<EnumCollection.BussinessType>(sp.BusinessTypeID);
                        if (sp.BusinessTypeBreakdownID != 0)
                        {
                            ex.BusinessTypeBreakdownName = ExtractEnumValue((int)sp.BusinessTypeID, (int)sp.BusinessTypeBreakdownID);
                        }
                        lst.Add(ex);
                    }
                    return lst.ToList();
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message, ex);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        public object GetAllFeature()
        {
            try
            {
                var allFeatureList = dbContext.SP_GetAllFeature();
                List<AllFeatureExtract> lst = new List<AllFeatureExtract>();
                foreach (SP_GetAllFeatureResult sp in allFeatureList)
                {
                    AllFeatureExtract ex = new AllFeatureExtract();
                    ex.IID = sp.IID;
                    ex.TitleName = sp.TitleName;
                    ex.ImageUrl = sp.ImageUrl;
                    ex.Description = sp.Description;
                    ex.BusinessTypeBreakdownID = sp.BusinessTypeBreakdownID;
                    // ex.BussinessTypeName= GetNameWithSpace(sp.BusinessTypeID);
                    ex.BussinessTypeName = EnumHelper.EnumToStringWithSpace<EnumCollection.BussinessType>(sp.BusinessTypeID);
                    if (sp.BusinessTypeBreakdownID != 0)
                    {
                        ex.BusinessTypeBreakdownName = ExtractEnumValue((int)sp.BusinessTypeID, (int)sp.BusinessTypeBreakdownID);
                    }
                    lst.Add(ex);
                }
                return lst.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
        public object GetAllFeatureDetailsByFeatureID(int featureID)
        {
            try
            {
                var allFeatureDetailsList = dbContext.SP_GetAllFeatureDetailsByFeatureID(featureID);
                return allFeatureDetailsList;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
        public bool IsExistFeature(int bussinessTypeID, int bussinessTypeBrID)
        {
            try
            {
                AllFeature feature = dbContext.AllFeatures.SingleOrDefault(x => x.BusinessTypeID == bussinessTypeID && x.BusinessTypeBreakdownID == bussinessTypeBrID);
                if (feature != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
        public object GetAllFeatureDistinctBrID()
        {
            try
            {
                var allFeatureID = dbContext.SP_GetAllFeatureMoreDetails();
                List<AllFeatureExtract> lst = new List<AllFeatureExtract>();
                foreach (SP_GetAllFeatureMoreDetailsResult sp in allFeatureID)
                {
                    AllFeatureExtract ex = new AllFeatureExtract();
                    ex.BusinessTypeID = sp.BusinessTypeID;
                    ex.BussinessTypeName = EnumHelper.EnumToStringWithSpace<EnumCollection.BussinessType>(ex.BusinessTypeID);//GetNameWithSpace(sp.BusinessTypeID);
                    lst.Add(ex);
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public object GetAllFeatureByBussiTypeID(int id)
        {
            try
            {
                var allFeature = dbContext.SP_GetAllFeatureByBussinessTypeID(id);
                List<AllFeatureExtract> lst = new List<AllFeatureExtract>();
                foreach (SP_GetAllFeatureByBussinessTypeIDResult sp in allFeature)
                {
                    AllFeatureExtract ex = new AllFeatureExtract();
                    ex.IID = sp.IID;
                    ex.TitleName = sp.TitleName;
                    ex.ImageUrl = sp.ImageUrl;
                    ex.Description = sp.Description;
                    ex.BusinessTypeBreakdownID = sp.BusinessTypeBreakdownID;
                    ex.BussinessTypeName = EnumHelper.EnumToStringWithSpace<EnumCollection.BussinessType>(sp.BusinessTypeID);//GetNameWithSpace(sp.BusinessTypeID);
                    if (sp.BusinessTypeBreakdownID != 0)
                    {
                        ex.BusinessTypeBreakdownName = ExtractEnumValue((int)sp.BusinessTypeID, (int)sp.BusinessTypeBreakdownID);
                    }
                    lst.Add(ex);
                }
                return lst.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public object GetAllFeatureByBTypeID(int id)
        {
            try
            {
                var allFeature = dbContext.SP_GetAllFeatureDetails(id);
                List<AllFeatureExtract> lst = new List<AllFeatureExtract>();
                foreach (SP_GetAllFeatureDetailsResult sp in allFeature)
                {
                    AllFeatureExtract ex = new AllFeatureExtract();
                    ex.IID = sp.IID;
                    ex.TitleName = sp.TitleName;
                    ex.ImageUrl = sp.ImageUrl;
                    ex.Description = sp.Description;
                    ex.BusinessTypeBreakdownID = sp.BusinessTypeBreakdownID;
                    ex.BussinessTypeName = EnumHelper.EnumToStringWithSpace<EnumCollection.BussinessType>(sp.BusinessTypeID);//GetNameWithSpace(sp.BusinessTypeID);
                    if (sp.BusinessTypeBreakdownID != 0)
                    {
                        ex.BusinessTypeBreakdownName = ExtractEnumValue((int)sp.BusinessTypeID, (int)sp.BusinessTypeBreakdownID);
                    }
                    lst.Add(ex);
                }
                return lst.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public object GetTopFourFeature()
        {
            try
            {
                var allFeature = dbContext.SP_GetTopFourFeature();
                List<SP_GetTopFourFeatureResult> list = new List<SP_GetTopFourFeatureResult>();

                foreach (SP_GetTopFourFeatureResult sp in allFeature)
                {
                    SP_GetTopFourFeatureResult newSP = new SP_GetTopFourFeatureResult();
                    newSP = sp;
                    newSP.BussinessTypeName = EnumHelper.EnumToStringWithSpace<EnumCollection.BussinessType>(sp.BusinessTypeID);
                    list.Add(newSP);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public class AllFeatureExtract
        {
            public int IID { get; set; }
            public int BusinessTypeID { get; set; }
            public string BussinessTypeName { get; set; }
            public int? BusinessTypeBreakdownID { get; set; }
            public string BusinessTypeBreakdownName { get; set; }
            public string TitleName { get; set; }
            public string Description { get; set; }
            public string ImageUrl { get; set; }
            public bool IsRemoved { get; set; }
        }
        public string GetNameWithSpace(int level)
        {
            try
            {
                string businessName = string.Empty;
                switch (level)
                {
                    case 1:
                        return businessName = "Energy";
                    case 2:
                        return businessName = "Banking";
                    case 3:
                        return businessName = "Travel";
                    case 4:
                        return businessName = "Insurance";
                    case 5:
                        return businessName = "Shopping";
                    case 6:
                        return businessName = "MobilePhone";
                    case 7:
                        return businessName = "Network Service Provider";
                    case 8:
                        return businessName = "Broad Band";
                    case 9:
                        return businessName = "News And Community";
                    case 10:
                        return businessName = "Construction";
                    case 11:
                        return businessName = "Medicine";
                }
                return businessName;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }
        public string ExtractEnumValue(int typeID, int brTypeID)
        {
            string name = string.Empty;
            switch (typeID)
            {

                case 1:
                    name = EnumHelper.EnumToStringWithSpace<EnumCollection.BusinessEnergyType>(brTypeID);
                    return name;
                case 2:
                    name = EnumHelper.EnumToStringWithSpace<EnumCollection.BusinessBankingType>(brTypeID);
                    return name;
                case 3:
                    name = EnumHelper.EnumToStringWithSpace<EnumCollection.BusinessTravelType>(brTypeID);
                    return name;
                case 4:
                    name = EnumHelper.EnumToStringWithSpace<EnumCollection.BusinessInsuranceType>(brTypeID);
                    return name;
                case 5:
                    name = EnumHelper.EnumToStringWithSpace<EnumCollection.BusinessShoppingType>(brTypeID);
                    return name;
                case 6:
                    name = EnumHelper.EnumToStringWithSpace<EnumCollection.BusinessMobilePhonesType>(brTypeID);
                    return name;
                case 7:
                    name = EnumHelper.EnumToStringWithSpace<EnumCollection.NetworkServiceProvider>(brTypeID);
                    return name;
                case 8:
                    name = EnumHelper.EnumToStringWithSpace<EnumCollection.BusinessBroadbandType>(brTypeID);
                    return name;
                case 9:
                    name = EnumHelper.EnumToStringWithSpace<EnumCollection.BusinessEnergyType>(brTypeID);
                    return name;
                case 10:
                    name = EnumHelper.EnumToStringWithSpace<EnumCollection.BusinessEnergyType>(brTypeID);
                    return name;
                case 11:
                    name = EnumHelper.EnumToStringWithSpace<EnumCollection.BusinessEnergyType>(brTypeID);
                    return name;
            }
            return name;
        }

    }
}
