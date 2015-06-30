using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Basic;
using Utilities;

namespace BLL.Basic
{
    public class GasRT : IDisposable
    {
        private readonly OiiOMartDBDataContext dbContext;

        public GasRT()
        {
            dbContext = DatabaseHelper.GetDataModelDataContext();
        }

        #region IDisposable Members

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members
        public static int InsertGasCylienderAndAllChildGasCylinderAndDealerInfoMappingXml(string objectXml)
        {
            try
            {
                return GasCylienderDA.InsertGasCylienderAndAllChildGasCylinderAndDealerInfoMappingXml(objectXml);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public void AddGasCyliender(GasCyliender gasCyliender)
        {
            try
            {
                DatabaseHelper.Insert<GasCyliender>(gasCyliender);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
        public void UpdateGasCylinder(GasCyliender gasCyliender)
        {
            try
            {

                GasCyliender gasCylienderNew = dbContext.GasCylienders.Single(d => d.IID == gasCyliender.IID);
                DatabaseHelper.Update<GasCyliender>(dbContext, gasCyliender, gasCylienderNew);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public List<SP_GetDealerForListViewByCompanyIidResult> GetGasDealerListByCompanyIid(int companyIid)
        {
            try
            {
                var gasDealerByCompanyIid = dbContext.SP_GetDealerForListViewByCompanyIid(companyIid).ToList();
                return gasDealerByCompanyIid;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }

        }

        public GasCyliender GetGasCylienderByIid(long gasCylienderId)
        {
            try
            {
                var gasCyliender = dbContext.GasCylienders.FirstOrDefault(x => x.IID == gasCylienderId);
                return gasCyliender;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        public List<GasCylinderAndDealerInfoMapping> GetGasDealerListByCylienderId(long gasCylienderId)
        {
            try
            {
                var gasDealerByGasCylienderIdList = dbContext.GasCylinderAndDealerInfoMappings.Where(x => x.GasCylinderID == gasCylienderId && x.IsRemoved == false);
                return gasDealerByGasCylienderIdList.ToList();
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
                if (dbContext.GasCylinderAndDealerInfoMappings.Any(x => x.GasCylinderID == gasCylienderId && x.GasDealerInfoID == gasDealerId))
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

        public void UpdateGasCylinderAndDealerInfoMapping(GasCylinderAndDealerInfoMapping aGasCylinderAndDealerInfoMapping)
        {
            try
            {
                GasCylinderAndDealerInfoMapping gasCylinderAndDealerInfoMappingNew = dbContext.GasCylinderAndDealerInfoMappings.Single(d => d.IID == aGasCylinderAndDealerInfoMapping.IID);
                DatabaseHelper.Update<GasCylinderAndDealerInfoMapping>(dbContext, aGasCylinderAndDealerInfoMapping, gasCylinderAndDealerInfoMappingNew);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public void AddGasCylinderAndDealerInfoMapping(GasCylinderAndDealerInfoMapping gasCylinderAndDealerInfoMapping)
        {
            try
            {
                DatabaseHelper.Insert<GasCylinderAndDealerInfoMapping>(gasCylinderAndDealerInfoMapping);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public GasCylinderAndDealerInfoMapping GetMappingByCylienderIdAndDealerId(long gasCylienderId, int gasDealerInfoId)
        {
            try
            {
                var mappingByCylienderIdAndDealerId = dbContext.GasCylinderAndDealerInfoMappings.FirstOrDefault(x => x.GasCylinderID == gasCylienderId && x.GasDealerInfoID == gasDealerInfoId);
                return mappingByCylienderIdAndDealerId;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        public GasCyliender GetGasCylienderLast()
        {
            try
            {
                var gasCylienderLast = dbContext.GasCylienders.OrderByDescending(x => x.IID).FirstOrDefault();
                return gasCylienderLast;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public object GetGasCyliendersForListViewDisplay()
        {
            try
            {
                var gasCylienderList = dbContext.GasCylienders.Where(x => x.IsRemoved == false);
                return gasCylienderList.ToList();
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public List<GasCylinderAndDealerInfoMapping> GetCylienderAndDealerMappingListByCylienderId(long gasCylienderId)
        {
            try
            {
                var mapList = dbContext.GasCylinderAndDealerInfoMappings.Where(x => x.GasCylinderID == gasCylienderId && x.IsRemoved == false);
                return mapList.ToList();
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }




        public object GetSearchResultForGasCyliender(int? companyIid, long? districtIid, long? policeStationIid, int? weightOfGas)
        {
            try
            {
                var gasCylienderListBySearchResult = dbContext.GetGasCylienderListBySearch(companyIid, districtIid, policeStationIid, weightOfGas).ToList();
                return gasCylienderListBySearchResult;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public object GetGuideLinesForEnergy()
        {
            try
            {


                var guideLineForEnergy = (from guideLine in dbContext.GuideLines
                                          where guideLine.BusinessTypeID == Convert.ToInt16(EnumCollection.BussinessType.Energy) && guideLine.IsRemoved == false
                                          select new
                                          {
                                              guideLine.IID,
                                              guideLine.Title,
                                              Description = guideLine.Description.Length > 51 ? guideLine.Description.Substring(0, 49) : guideLine.Description,
                                              guideLine.ImageUrl,
                                              GuideLineIid = guideLine.IID
                                          }).Take(4).ToList();


                return guideLineForEnergy;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
    }
}
