using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OH.DAL;
using DAL;
namespace OH.BLL.Basic
{
   public class MappingCategoryRT : IDisposable
    {
        public MappingCategoryRT()
        {
        }

        #region Get methods
        public MappingCategory GetMappingCategoryByID(int mappingCategoryID)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                MappingCategory mappingCategory = new MappingCategory();
                mappingCategory = dbContext.MappingCategories.FirstOrDefault(d => d.CategoryID == mappingCategoryID && d.IsRemoved == false);
                //dbContext.Dispose();
                return mappingCategory;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
        public string GetMappingCategoryByName(int CategoryID)
        {
            try
            {
                string categoryName = "";
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                var mappingCategory = dbContext.Categories.Single(d => d.IID == CategoryID && d.IsRemoved == false);
                if (mappingCategory!= null)
                {
                    categoryName = mappingCategory.Name;
                }
             dbContext.Dispose();
                return categoryName;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

       public List<MappingCategory> GetMappingCategoryAll()
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<MappingCategory> mappingCategoryList = new List<MappingCategory>();
                mappingCategoryList = dbContext.MappingCategories.Where(d => d.IsRemoved == false).ToList();
                dbContext.Dispose();
                return mappingCategoryList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public List<MappingCategory> GetAllMappingCategoryForListView()
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();

                List<MappingCategory> mappingCategories = dbContext.MappingCategories.Where(C => C.IsRemoved == false).ToList();
                return mappingCategories;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }      

        public List<MappingTable> GetAllMappingTableForListView()
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();

                List<MappingTable> mappingTables = dbContext.MappingTables.Where(C => C.IsRemoved == false).ToList();
                //dbContext.Dispose();
                return mappingTables;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }  
     


        public void AddMappingCategory(MappingCategory mapCategory)
        {
            try
            {
                DatabaseHelper.Insert<MappingCategory>(mapCategory);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }


        public void UpdateMappingCategory(MappingCategory categoryID)
        {
            try
            {
                OiiOHaatDCDataContext msDC = DatabaseHelper.GetDataModelDataContext();

              //  MappingCategory mappingCategoryNew = msDC.MappingCategories.Single(d => d.CategoryID == categoryID.CategoryID );
                MappingCategory mappingCategoryNew = msDC.MappingCategories.Single(d => d.IID == categoryID.IID);
                DatabaseHelper.Update<MappingCategory>(msDC, categoryID, mappingCategoryNew);

                msDC.Dispose();
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
        public List<GetMapCategoryResult> GetCategoryMapByCategoryID(long categoryID)
        {
            OiiOHaatDCDataContext msDC = DatabaseHelper.GetDataModelDataContext();
            var mapCat = msDC.GetMapCategory(categoryID).ToList();
            return mapCat;
        }
        public object GetAllMappingCategoryTableForListView()
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();

                var mapCategoryList = (from mapCat in dbContext.MappingCategories
                                       join category in dbContext.Categories
                                       on mapCat.CategoryID equals category.IID
                                       join mappingTable in dbContext.MappingTables
                                       on mapCat.MappingTableID equals mappingTable.IID
                                       where mapCat.IsRemoved==false
                                       select new MappingTableCategories
                                       {
                                           IID = mapCat.IID,
                                           
                                           CategoryID=category.IID,
                                           CategoryName = category.Name,
                                           MappingTableName = mappingTable.Name,
                                           MappingTableDescription = mappingTable.Description
                                       }).OrderBy(x => x.CategoryName).ToList();

                return mapCategoryList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
        #endregion Get methods

       
        #region IDisposable Members

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members



        public List<MappingCategory> GetMappingAndCategoryID(int mappingCategoryID, int mappingTableID)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<MappingCategory> mappingCategoryList = new List<MappingCategory>();
                mappingCategoryList = dbContext.MappingCategories.Where(d => d.IsRemoved == false && d.CategoryID == mappingCategoryID && d.MappingTableID == mappingTableID).ToList();
                dbContext.Dispose();
                return mappingCategoryList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }



        public List<MappingCategory> GetMappingCategoryByTableID(int categoryID)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<MappingCategory> mappingCategoryList = new List<MappingCategory>();
                mappingCategoryList = (from mapCat in dbContext.MappingCategories
                                       where mapCat.IsRemoved == false && 
                                       mapCat.CategoryID==categoryID &&
                                       mapCat.MappingTableID !=null
                                       select mapCat).ToList();
                    //dbContext.MappingCategories.Where(d => d.IsRemoved == false && d.CategoryID. ).ToList();
                dbContext.Dispose();
                return mappingCategoryList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
    }
}
