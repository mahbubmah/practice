using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Basic;

namespace BLL.Basic
{
    public class BICategoryRT : IDisposable
    {
        private readonly OiiOMartDBDataContext dbContext;

        public BICategoryRT()
        {
            dbContext = DatabaseHelper.GetDataModelDataContext();
        }
        public int InsertBiCategoryAndChildCategoryXml(string objectXML)
        {
            try
            {
                return BICategoryDA.InsertBICategoryAndChildCategoryXML(objectXML);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public void AddCategory(BICategory biCategory)
        {
            try
            {
                DatabaseHelper.Insert<BICategory>(biCategory);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
        public void UpdateBiCategory(BICategory biCategory)
        {
            try
            {
                BICategory biCategoryNew = dbContext.BICategory.Single(d => d.IID == biCategory.IID);
                DatabaseHelper.Update<BICategory>(dbContext, biCategory, biCategoryNew);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        #region IDisposable Members
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members

        public BICategory GetBiCategoryByIid(long biCategoryId)
        {
            try
            {
                var biCategory = dbContext.BICategory.SingleOrDefault(d => d.IID == biCategoryId && d.IsRemoved == false);
                return biCategory;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public List<BICategoryDetail> GetBiCategoryChildListByCategoryIid(long biCategoryId)
        {
            try
            {
                var childCatListByCatIid =
                dbContext.BICategoryDetail.Where(x => x.BICategoryID == biCategoryId && x.IsRemoved == false).ToList();
                return childCatListByCatIid;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }

        }

        public bool IsCategoryNameExist(string catName)
        {
            try
            {
                bool isCatNameExist = false;
                var catList = dbContext.BICategory.Where(x => x.Name == catName && x.IsRemoved == false);
                if (catList.Any())
                {
                    isCatNameExist = true;
                }
                return isCatNameExist;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public void UpdateBiCategoryDetail(BICategoryDetail biCategoryDetailNew)
        {
            try
            {
                BICategoryDetail biCategory = dbContext.BICategoryDetail.Single(d => d.IID == biCategoryDetailNew.IID);
                DatabaseHelper.Update<BICategoryDetail>(dbContext, biCategoryDetailNew, biCategory);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public void AddCategoryDetail(BICategoryDetail biCategoryDetail)
        {
            try
            {
                DatabaseHelper.Insert<BICategoryDetail>(biCategoryDetail);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public object GetAllBiCategoryList()
        {
            try
            {
                var biCategoryList = dbContext.BICategory.Where(x => x.IsRemoved == false).OrderByDescending(x=>x.IID);
                return biCategoryList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
    }
}
