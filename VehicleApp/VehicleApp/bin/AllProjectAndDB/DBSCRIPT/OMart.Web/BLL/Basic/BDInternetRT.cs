using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Basic;
namespace BLL.Basic
{
    public class BDInternetRT : IDisposable
    {
        //private readonly OiiOMartDBDataContext _OiiOMartDBDataContext=new OiiOMartDBDataContext();
        private readonly OiiOMartDBDataContext _OiiOMartDBDataContext;
        public BDInternetRT()
        {
             _OiiOMartDBDataContext = DatabaseHelper.GetDataModelDataContext();
        }
        public List<BDChannelInfo> GetAllBDChannelInfo()
        {
            try
            {
                List<BDChannelInfo> Countries = _OiiOMartDBDataContext.BDChannelInfos.ToList();
                return Countries;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
       
        public void AddLIApplicableInfoAndFeature(BDInternet loanInfo, List<BDInternetAndChannelMapping> featureList)
        {
            try
            {
                DatabaseHelper.Insert<BDInternet>(loanInfo);
                foreach (BDInternetAndChannelMapping feature in featureList)
                {
                    feature.BDInternetID = loanInfo.IID;
                    DatabaseHelper.Insert<BDInternetAndChannelMapping>(feature);
                }
            }
            catch (Exception ex)
            { throw new Exception(ex.Message, ex); }

        }
        public static int InsertBDInternetAndFeatureChildXML(string objectXML)
        {
            try
            {
                return BDInternetAndChannelMappingDA.InsertBDInternetAndChannelMappingChildXML(objectXML);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public void UpdateLoanAmntYrScdle(BDInternet loanAmntYrScdleObj)
        {
            try
            {
                BDInternet loanAmntYrScdleObjNew = _OiiOMartDBDataContext.BDInternets.SingleOrDefault(d => d.IID == loanAmntYrScdleObj.IID);

                DatabaseHelper.Update<BDInternet>(_OiiOMartDBDataContext, loanAmntYrScdleObj, loanAmntYrScdleObjNew);
                _OiiOMartDBDataContext.Dispose();

                //_OiiOMartDBDataContext.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
     public void UpdateBDInternet(BDInternet loanInfo, List<BDInternetAndChannelMapping> featureList)
     {
         try
         {
             OiiOMartDBDataContext db = DatabaseHelper.GetDataModelDataContext();
             BDInternet loanInfoNew = db.BDInternets.SingleOrDefault(d => d.IID == loanInfo.IID);
             DatabaseHelper.Update<BDInternet>(db, loanInfo, loanInfoNew);

             //OiiOMartDBDataContext db = DatabaseHelper.GetDataModelDataContext();
             db.DeleteLiFeatureByLIIID(loanInfo.IID);
             db.Dispose();
             foreach (BDInternetAndChannelMapping feature in featureList)
             {
                 feature.BDInternetID = loanInfo.IID;
                 feature.IsRemoved = false;
                 DatabaseHelper.Insert<BDInternetAndChannelMapping>(feature);
             }
             // _OiiOMartDBDataContext.Dispose();
         }
         catch (Exception ex)
         {
             throw new Exception(ex.Message, ex);
         }
     }

     public BDInternet GetAddLoanAmntYrScdleByIID(BDInternet loanAmntYrScdleID)
        {
            try
            {
                BDInternet loanAmntYrScdleObj = _OiiOMartDBDataContext.BDInternets.SingleOrDefault(d => d.IID == loanAmntYrScdleID.IID);
                //_OiiOMartDBDataContext.Dispose();
                return loanAmntYrScdleObj;
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message, ex);
            }
        }
     public BDInternet GetBDInternetByIID(long loanAmntYrScdleID)
     {
         try
         {
             BDInternet loanAmntYrScdleObj = _OiiOMartDBDataContext.BDInternets.SingleOrDefault(d => d.IID == loanAmntYrScdleID);
             //_OiiOMartDBDataContext.Dispose();
             return loanAmntYrScdleObj;
         }
         catch (Exception ex)
         {
             throw new Exception(ex.Message, ex);
         }
     }
     //public BDInternet GetLoanAmntYrScdleByNoOfYr(int loanAmntYrScdleID)
     //{
     //    try
     //    {
     //        BDInternet loanAmntYrScdleObj = _OiiOMartDBDataContext.BDInternets.SingleOrDefault(d => d.NumberOfYear == loanAmntYrScdleID);
     //        //_OiiOMartDBDataContext.Dispose();
     //        return loanAmntYrScdleObj;
     //    }
     //    catch (Exception ex)
     //    {
     //        throw new Exception(ex.Message, ex);
     //    }
     //}

     //public List<BDInternet> GetAddLoanAmntYrScdleName(string conName)
     //   {
     //       try
     //       {
     //           var loanAmntYrScdleObj = (from tr in _OiiOMartDBDataContext.BDInternets.OrderBy(x => x)
     //                            where tr.AmountStart.StartsWith(conName)
     //                            select tr).ToList();
     //           return loanAmntYrScdleObj;
     //       }
     //       catch (Exception ex)
     //       {
     //           throw new Exception(ex.Message, ex);
     //       }
     //   }

     public object GetAllLoanAmntYrScdle()
        {
            try
            {
                //var districtList = from distict in _OiiOMartDBDataContext.Districts
                //                   join country in _OiiOMartDBDataContext.Countries on distict.CountryID equals country.IID
                //                   join divisionOrState in _OiiOMartDBDataContext.DivisionOrStates on distict.DivisionOrStateID equals divisionOrState.IID
                //                   //where (country.IsRemoved == false && divisionOrState.IsRemoved == false && distict.IsRemoved == false) //
                //                   //where distict.IsRemoved == false
                //                   select new { distict.IID, distict.Code, distict.Name, DivisionOrState = divisionOrState.Name, CountryName = country.Name, distict.IsRemoved };
                var loanAmntYrScdleObj = from inter in _OiiOMartDBDataContext.BDInternets
                                         join com in _OiiOMartDBDataContext.CompanyInfos on inter.ProviderID equals com.IID
                                         select new { inter.ChargeAmount, inter.ChargeTypeID, inter.ChargeTypeNote, inter.CompanyInfo, inter.DataAmount,
                                             inter.DownloadSpeed, inter.DownloadSpeedUnitID, inter.IID, inter.IsRemoved,inter.NetGenerationID
                                             ,inter.NetSpeed, inter.NetSpeedUnitID, inter.PackageImageUrl, inter.PackageName, inter.ProviderID
                                             , inter.RedirectUrl, inter.TotalChannelNo, inter.TypeID, interCompanyName = com.Name };
                return loanAmntYrScdleObj.ToList();
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message, ex); 
            }
        }
     //public object GetAllLoanAmntYrScdleforList()
     //{
     //    var lifInsurance = from lifInsu in _OiiOMartDBDataContext.BDInternets
     //                       join com in _OiiOMartDBDataContext.BDInternetAndChannelMappings on lifInsu.IID equals com.BDInternetID
     //                       select new { lifInsu.IID, lifInsu.NumberOfYear, lifInsu.AgeMin, lifInsu.AgeMax,
     //                           lifInsu.UnitAmount, lifInsu.UnitPremiumAmount, lifInsu.UnitReturnAmount, lifInsu.IsRemoved, Description = com.Description, lifInsu.PremiumPolicyID }; //diviionOrState.Name

     //    return lifInsurance;
     //}


        #region IDisposable Members
            public void Dispose()
            {
                GC.SuppressFinalize(this);
            }

        #endregion IDisposable Members

            public BDInternet GetBDInternetLast()
            {
                try
                {
                    var BDInternetLast = _OiiOMartDBDataContext.BDInternets.OrderByDescending(x => x.IID).FirstOrDefault();
                    return BDInternetLast;
                }
                catch (Exception ex) { throw new Exception(ex.Message, ex); }
            }

            public void UpdateBDinternet(BDInternet BDInternet)
            {
                try
                {

                    BDInternet gasCylienderNew = _OiiOMartDBDataContext.BDInternets.Single(d => d.IID == BDInternet.IID);
                    DatabaseHelper.Update<BDInternet>(_OiiOMartDBDataContext, BDInternet, gasCylienderNew);
                }
                catch (Exception ex) { throw new Exception(ex.Message, ex); }
            }



            public void AddBDinternetAndChannelInfoMapping(BDInternetAndChannelMapping BDInternetAndChannelMapping)
            {
                try
                {
                    DatabaseHelper.Insert<BDInternetAndChannelMapping>(BDInternetAndChannelMapping);
                }
                catch (Exception ex) { throw new Exception(ex.Message, ex); }
            }

            public BDInternetAndChannelMapping GetMappingByBDInternetAndChannelId(long gasCylienderId, int gasDealerInfoId)
            {
                try
                {
                    var mappingByBDInternetAndChannelId = _OiiOMartDBDataContext.BDInternetAndChannelMappings.FirstOrDefault(x => x.BDInternetID == gasCylienderId && x.BDChannelInfoID == gasDealerInfoId);
                    return mappingByBDInternetAndChannelId;
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message, ex);
                }
            }
            public bool IsMappingExist(long gasCylienderId, int gasDealerId)
            {
                bool isMappingExist = false;
                try
                {
                    if (_OiiOMartDBDataContext.BDInternetAndChannelMappings.Any(x => x.BDInternetID == gasCylienderId && x.BDChannelInfoID == gasDealerId))
                    {
                        isMappingExist = true;
                    }
                    return isMappingExist;
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message, ex);
                }
            }


            public void UpdateBDInternetAndChannelMapping(BDInternetAndChannelMapping aBDInternetAndChannelMapping)
            {
                try
                {
                    BDInternetAndChannelMapping gasCylinderAndDealerInfoMappingNew = _OiiOMartDBDataContext.BDInternetAndChannelMappings.Single(d => d.IID == aBDInternetAndChannelMapping.IID);
                    DatabaseHelper.Update<BDInternetAndChannelMapping>(_OiiOMartDBDataContext, aBDInternetAndChannelMapping, gasCylinderAndDealerInfoMappingNew);
                }
                catch (Exception ex) { throw new Exception(ex.Message, ex); }
            }

            public List<BDInternetAndChannelMapping> GetBDInternetAndChannelId(long IID)
            {
                try
                {
                    var gasDealerByGasCylienderIdList = _OiiOMartDBDataContext.BDInternetAndChannelMappings.Where(x => x.BDInternetID == IID && x.IsRemoved == false);
                    return gasDealerByGasCylienderIdList.ToList();
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message, ex);
                } 
            }
        /// <summary>
        /// Hasan Add 2015.05.14
        /// </summary>
        /// <param name="typeID"></param>
        /// <returns></returns>
        public List <Sp_GetAllBroadBandInternetByTypeIDResult> GetAllBDInternetDealsByTypeID(int typeID,int startRowIndex, int maxRowNumber)
        {
            try
            {
                var bdInternetDealsResult = _OiiOMartDBDataContext.Sp_GetAllBroadBandInternetByTypeID(typeID, startRowIndex, maxRowNumber);
                return bdInternetDealsResult.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            } 
        }
        public int CountAllBDInternetDealsByTypeID(int typeID)
        {
            try
            {
                var bdInternetDeals = _OiiOMartDBDataContext.BDInternets.Where(b => b.TypeID == typeID && b.IsRemoved == false);
                return bdInternetDeals.ToList().Count;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            } 
        }
        public int GetLastIIDOfBDIngernet()
        {
            try
            {
                var result = _OiiOMartDBDataContext.SP_GetLastIIDofBDInternet();
                return Convert.ToInt32 (result.SingleOrDefault().IID.ToString());            
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
            
    }
}


