using System;
using System.Collections.Generic;
using System.Linq;
using Tula.DAL;

namespace Tula.BLL.Basic
{


    public class CategoryRT : IDisposable
    {
        private readonly DBConnectionString _db;
        public CategoryRT()
        {
            _db = DatabaseHelper.GetDataModelDataContext();
        }

        #region Get Methods
        public List<Category> GetCategoryByName(string catName)
        {
            try
            {
                var categoyList = _db.Categories.Where(d => d.IsRemoved == false && d.Name == catName).ToList();
                return categoyList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
        public void AddCategory(Category category)
        {
            try
            {
                count = 0;
                CountCounter(category.ParentID);
                count = count - subCatCounter;
                string msg = "- ";
                string newSpaceMsg = string.Empty; //space for subcategory
                for (int spaceCount = 0; spaceCount < count; spaceCount++)
                {
                    newSpaceMsg = msg + newSpaceMsg;
                }
                category.Description = newSpaceMsg + category.Name;
                DatabaseHelper.Insert<Category>(category);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
        public void UpdateCategory(Category category)
        {
            try
            {

                Category categoryNew = _db.Categories.Single(d => d.IID == category.IID);
                count = 0;
                CountCounter(categoryNew.ParentID);
                count = count - subCatCounter;
                string msg = "- ";
                string newSpaceMsg = string.Empty; //space for subcategory
                for (int spaceCount = 0; spaceCount < count; spaceCount++)
                {
                    newSpaceMsg = msg + newSpaceMsg;
                }
                category.Description = newSpaceMsg + category.Name;
                DatabaseHelper.Update<Category>(_db, category, categoryNew);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
        public object GetAllCategoryForListView()
        {
            try
            {
                var categoyList = _db.Categories.Where(d => d.IsRemoved == false).OrderByDescending(x=>x.IID).ToList();
                return categoyList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
        public Category GetCategoryById(long categoryId)
        {
            try
            {
                var category = _db.Categories.Single(d => d.IID == categoryId && d.IsRemoved == false);
                return category;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        /// <summary>
        /// Get all categories by parent category IID
        /// </summary>
        /// <param name="parentCategoryId"></param>
        /// <returns></returns>
        public List<Category> GetAllCategoryByParentId(Int64 parentCategoryId)
        {
            try
            {

                var category = (from tr in _db.Categories
                                where tr.ParentID != null && tr.IsRemoved == false && tr.ParentID == parentCategoryId
                                select tr).OrderBy(x => x.Name).ToList();
                return category;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        /// <summary>
        /// Hasan Add GetAllParent Category Date: 4 March 2015
        /// </summary>
        /// <returns></returns>
        public List<Category> GetAllParentCategory()
        {
            try
            {
                var categoryList = _db.Categories.Where(d => d.IsRemoved == false && d.ParentID == null).OrderBy(x=>x.Name).ToList();
                return categoryList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        /// <summary>
        /// Hasan Add GetParentCategoryIDByName Category Date: 4 March 2015
        /// </summary>
        /// <returns></returns>
        /// 
        public int GetParentCategoryIdByName(string categoryName)
        {
            try
            {
                var categoryId = _db.Categories.Single(d => d.IsRemoved == false && d.ParentID == null && d.Name == categoryName).IID.ToString();
               
                return int.Parse(categoryId);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        #endregion Get Methods


       

        #region Methods for Category Tree

        private int count = 0;
        private int subCatCounter = 0;
        private List<SP_CategoryTree_GetSearchedCategoryOrAll_Result> categoryList = new List<SP_CategoryTree_GetSearchedCategoryOrAll_Result>();
        public List<SP_CategoryTree_GetSearchedCategoryOrAll_Result> GetAllSearchedCategory(string catName)
        {
            try
            {
                var catList = new List<SP_CategoryTree_GetSearchedCategoryOrAll_Result>();
                if (catName == " ")
                {
                    catList = _db.SP_CategoryTree_GetSearchedCategoryOrAll(null, null).ToList();
                    
                }
                else
                {
                    catList = _db.SP_CategoryTree_GetSearchedCategoryOrAll(catName, null).ToList();
                   

                    //var catList1 = new List<SP_CategoryTree_GetSearchedCategoryOrAllResult>();
                    //catList1.AddRange(catList);
                    //var catList2 = new List<SP_CategoryTree_GetSearchedCategoryOrAllResult>();
                    //catList2.AddRange(catList);

                    //catList = null;
                    //catList = new List<SP_CategoryTree_GetSearchedCategoryOrAllResult>();

                    //foreach (var category1 in catList1)
                    //{
                    //    foreach (var category2 in catList2)
                    //    {
                    //        if (category1.Name == category2.Name)
                    //        {
                    //            var cat = new SP_CategoryTree_GetSearchedCategoryOrAllResult();
                    //            var category = GetCategoryByID(category2.ParentID != null ? Convert.ToInt64(category2.ParentID) : 0);
                    //            cat.IID = category.IID;
                    //            cat.ParentID = category.ParentID;
                    //            cat.Description = category.Description;
                    //            cat.Name = category.Name;
                    //            catList.Add(cat);
                    //        }
                    //        else
                    //        {
                    //            catList.Add(category2);
                    //        }
                    //    }
                    //}
                }

               
               
              
                if (catList.Count > 0)
                {
                    foreach (var categoryDb in catList)
                    {
                        count = 0;
                        CountCounter(categoryDb.ParentID);
                        subCatCounter = count;
                        categoryDb.Description = categoryDb.Name;
                        if (categoryList.All(c => c.IID != categoryDb.IID))
                        {
                            categoryList.Add(categoryDb);
                        }

                        GetCategoryListByParentId(categoryDb.IID);
                    }
                }

                return categoryList.ToList();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
        }

        public void GetCategoryListByParentId(Int64 parId)
        {
            try
            {
                var catListByParentId = _db.SP_CategoryTree_GetSearchedCategoryOrAll(null, parId).ToList();

                foreach (var category in catListByParentId)
                {
                    count = 0;
                    CountCounter(category.ParentID);
                    count = count - subCatCounter;
                    string msg = "- ";
                    string newSpaceMsg = string.Empty; //space for subcategory
                    for (int spaceCount = 0; spaceCount < count; spaceCount++)
                    {
                        newSpaceMsg = msg + newSpaceMsg;
                    }
                    category.Description = newSpaceMsg + category.Name;
                    if (categoryList.All(c => c.IID != category.IID))
                    {
                        categoryList.Add(category);
                    }
                    GetCategoryListByParentId(category.IID);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public void CountCounter(Int64? parId)
        {
            try
            {
                if (parId != null)
                {
                    if (count > 25)
                    {
                        throw new Exception(("Error at parent category Id" + parId));
                    }
                    var parentId = _db.Categories.Single(x => x.ParentID==parId).ParentID;
                    count++;

                    CountCounter(parentId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        #endregion Methods for Category Tree
        


        //#region Methods for Category Tree

        //private int count = 0;
        //private int subCatCounter = 0;
        //private List<Category> categoryList = new List<Category>();
        //public dynamic GetAllSearchedCategory(string catName)
        //{
        //    try
        //    {
        //        OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
        //        if (catName == " ")
        //        {
        //            var cat = dbContext.Categories.Where(ca => ca.IsRemoved == false && ca.ParentID == null).ToList();

        //            foreach (var categoryDb in cat)
        //            {
        //                Category aCategory = new Category();
        //                aCategory.IID = categoryDb.IID;
        //                aCategory.ParentID = categoryDb.ParentID;
        //                aCategory.Description = categoryDb.Name;
        //                aCategory.Name = categoryDb.Name;

        //                count = 0;
        //                CountCounter(categoryDb.ParentID);
        //                subCatCounter = count;
        //                aCategory.Description = aCategory.Name;
        //                if (categoryList.All(c => c.IID != aCategory.IID))
        //                {
        //                    categoryList.Add(aCategory);
        //                }

        //                GetCategoryListByParentID(aCategory.IID);
        //            }
        //        }
        //        else
        //        {
        //            var catList = new List<SP_CategoryTree_GetSearchedCategoryResult>();
        //            var catList0 = dbContext.SP_CategoryTree_GetSearchedCategory(catName).ToList();

        //            var catList1 = catList0;
        //            var catList2 = catList0;

        //            foreach (var category1 in catList1)
        //            {
        //                foreach (var category2 in catList2)
        //                {
        //                    if (category1.Name == category2.Name)
        //                    {
        //                        var cat = new SP_CategoryTree_GetSearchedCategoryResult();
        //                        var category = GetCategoryByID(category2.ParentID != null ? Convert.ToInt64(category2.ParentID) : 0);
        //                        cat.IID = category.IID;
        //                        cat.ParentID = category.ParentID;
        //                        cat.Description = category.Description;
        //                        cat.Name = category.Name;
        //                        catList.Add(cat);
        //                    }
        //                    else
        //                    {
        //                        catList.Add(category2);
        //                    }
        //                }
        //            }

        //            dbContext.Dispose();
        //            foreach (var categoryDb in catList)
        //            {
        //                Category aCategory = new Category();
        //                aCategory.IID = categoryDb.IID;
        //                aCategory.ParentID = categoryDb.ParentID;
        //                aCategory.Description = categoryDb.Name;
        //                aCategory.Name = categoryDb.Name;

        //                count = 0;
        //                CountCounter(categoryDb.ParentID);
        //                subCatCounter = count;
        //                aCategory.Description = aCategory.Name;
        //                if (categoryList.All(c => c.IID != aCategory.IID))
        //                {
        //                    categoryList.Add(aCategory);
        //                }

        //                GetCategoryListByParentID(aCategory.IID);
        //            }
        //        }

        //        return categoryList.ToList();
        //    }
        //    catch (Exception exception)
        //    {
        //        throw new Exception(exception.Message, exception);
        //    }
        //}
        //public void GetCategoryListByParentID(Int64 parID)
        //{
        //    try
        //    {
        //        OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
        //        var catListByParentID = dbContext.SP_CategoryTree_GetCategoryListByParentID(parID).ToList();
        //        dbContext.Dispose();
        //        if (catListByParentID.Count > 0)
        //        {
        //            foreach (var category in catListByParentID)
        //            {
        //                count = 0;
        //                CountCounter(category.ParentID);
        //                count = count - subCatCounter;
        //                string msg = "- ";
        //                string newSpaceMsg = string.Empty; //space for subcategory
        //                for (int spaceCount = 0; spaceCount < count; spaceCount++)
        //                {
        //                    newSpaceMsg = msg + newSpaceMsg;
        //                }
        //                Category aCategory = new Category();
        //                aCategory.IID = category.IID;
        //                aCategory.ParentID = category.ParentID;
        //                aCategory.Description = newSpaceMsg + category.Name;
        //                aCategory.Name = category.Name;
        //                if (categoryList.All(c => c.IID != category.IID))
        //                {
        //                    categoryList.Add(aCategory);
        //                }
        //                GetCategoryListByParentID(category.IID);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex);
        //    }
        //}
        //public void CountCounter(Int64? parId)
        //{
        //    try
        //    {
        //        if (parId != null)
        //        {
        //            if (count > 25)
        //            {
        //                throw new Exception(("Error at parent category Id" + parId));
        //            }
        //            OiiOHaatDCDataContext dbContext = new OiiOHaatDCDataContext();
        //            dbContext = DatabaseHelper.GetDataModelDataContext();
        //            var parent = dbContext.Categories.SingleOrDefault(parIid => parIid.IID == parId);
        //            count++;
        //            CountCounter(parent.ParentID);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex);
        //    }
        //}
        //#endregion Methods for Category Tree


        #region IDisposable Members

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members

        /// <summary>
        /// Hasan add 2015.03.10  Getting Parent CategoryID for ChildID
        /// </summary>
        /// <param name="CatID"></param>
        /// <returns></returns>
        public Category GetParentCategoryIDForChildID(Int64 CatID)
        {
            try
            {
                var ca = new Category();
                ca = _db.Categories.Single(c => c.IID == CatID && c.IsRemoved == false);
                return ca;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex); 
            }
        }

        public bool IsParentCategoryID(Int64 CatID)
        {
            try
            {
                var categoryList = _db.Categories.Where(d => d.IsRemoved == false && d.IID == CatID && d.ParentID==null).ToList();

                return categoryList.Count > 0;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        public object  GetNavMenu()
        {
            try
            {
             
                
               var navMenuList = (from catagory in _db.Categories
                              where catagory.IsRemoved == false && catagory.ParentID == null && (catagory.Name == "For Sell" || catagory.Name == "Property" || catagory.Name == "Motors" || catagory.Name == "Jobs" || catagory.Name == "Services" || catagory.Name == "Community")
                              select new { catagory.IID, catagoryName = catagory.Name}).ToList();
   
               return navMenuList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
        public List<OH_OT_GetNavMenu_Result> GetNavmenu()
        {
            var getAllNavmenu = _db.OH_OT_GetNavMenu().ToList();
            return getAllNavmenu;
        }
    }
}
