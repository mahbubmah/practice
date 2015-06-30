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

    public class BIReceiverRT : IDisposable
    {
        private readonly OiiOMartDBDataContext dbContext;

        public BIReceiverRT()
        {
            dbContext = DatabaseHelper.GetDataModelDataContext();
        }
        //public void AddReceiver(AllNews allNews)
        //{
        //    try
        //    {
        //        DatabaseHelper.Insert<AllNews>(allNews);
        //    }
        //    catch (Exception ex) { throw new Exception(ex.Message, ex); }
        //}
        //public void UpdateReceiver(AllNews allNews)
        //{
        //    try
        //    {

        //        AllNews allnews = dbContext.AllNews.Single(d => d.IID == allNews.IID);
        //        DatabaseHelper.Update<AllNews>(dbContext, allNews, allnews);
        //    }
        //    catch (Exception ex) { throw new Exception(ex.Message, ex); }
        //}

        #region IDisposable Members
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members
        public List<Profession> GetProfessionsForDropDown()
        {
            try
            {
                var professionList = dbContext.Professions.OrderBy(x => x.Name).ToList();
                return professionList;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
        public int InsertBiReceiverAndBiReceiverChildXml(string objectXML)
        {
            try
            {
                return BiReceiverDA.InsertBiReceiverAndBiReceiverChildXML(objectXML);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<BIBusinessAge> GetAllBusinessAgeInterval()
        {
            try
            {
                var businesAgeList = dbContext.BIBusinessAge.Where(x => x.IsRemoved == false).ToList();
                return businesAgeList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public List<BIAmountRange> GetAllIndemnityTypeAmount()
        {
            try
            {
                var indemnityTypeAmountList =
                    dbContext.BIAmountRange.Where(
                        x =>
                            x.TypeID == Convert.ToInt32(EnumCollection.BIAmountType.IndemnityAmount) &&
                            x.IsRemoved == false).ToList();
                return indemnityTypeAmountList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
        public List<BIAmountRange> GetAllPublicLiabilityTypeAmount()
        {
            try
            {
                var publicLiablityTypeAmountList =
                    dbContext.BIAmountRange.Where(
                        x =>
                            x.TypeID == Convert.ToInt32(EnumCollection.BIAmountType.PublicLiability) &&
                            x.IsRemoved == false).ToList();
                return publicLiablityTypeAmountList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
        public List<BIAmountRange> GetAllEmployerLiabilityTypeAmount()
        {
            try
            {
                var employerLiabilityTypeAmountList =
                    dbContext.BIAmountRange.Where(
                        x =>
                            x.TypeID == Convert.ToInt32(EnumCollection.BIAmountType.EmployerLiability) &&
                            x.IsRemoved == false).ToList();
                return employerLiabilityTypeAmountList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
        public List<BIAmountRange> GetAllOfficeEquipmentTypeAmount()
        {
            try
            {
                var officeEquipmentTypeAmountList =
                    dbContext.BIAmountRange.Where(
                        x =>
                            x.TypeID == Convert.ToInt32(EnumCollection.BIAmountType.OfficeEquipment) &&
                            x.IsRemoved == false).ToList();
                return officeEquipmentTypeAmountList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
        public List<BIAmountRange> GetAllPortableEquipmentTypeAmount()
        {
            try
            {
                var portableEquipmentTypeAmountList =
                    dbContext.BIAmountRange.Where(
                        x =>
                            x.TypeID == Convert.ToInt32(EnumCollection.BIAmountType.PortableEquipment) &&
                            x.IsRemoved == false).ToList();
                return portableEquipmentTypeAmountList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public List<BICategory> GetBiCategoryList()
        {
            try
            {
                var biCategoryList = dbContext.BICategory.Where(x => x.IsRemoved == false).OrderBy(x => x.Name).ToList();
                return biCategoryList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public List<BICategoryDetail> GetBiCategoyDetailListByBiCategoryIid(long biCategoryId)
        {
            try
            {
                var biCategoryDetails = dbContext.BICategoryDetail.Where(x => x.IsRemoved == false && x.BICategoryID==biCategoryId).OrderBy(x => x.Name).ToList();
                return biCategoryDetails;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public long GetBiCategoryIidByBiCatDetailIiD(long biCategoryDetailIiD)
        {
            try
            {
                var biCategoryIid = dbContext.BICategoryDetail.SingleOrDefault(x => x.IID == biCategoryDetailIiD).BICategoryID;
                return biCategoryIid;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
    }
}
