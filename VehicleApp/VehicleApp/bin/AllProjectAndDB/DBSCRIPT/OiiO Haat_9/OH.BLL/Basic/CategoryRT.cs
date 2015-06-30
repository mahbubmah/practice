using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using OH.DAL;

namespace OH.BLL.Basic
{


    public class CategoryRT : IDisposable
    {

        #region Get Methods
        public List<Category> GetCategoryByName(string catName)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<Category> categoyList = new List<Category>();
                categoyList = dbContext.Categories.Where(d => d.IsRemoved == false && d.Name == catName).ToList();

                dbContext.Dispose();
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
                OiiOHaatDCDataContext msDC = DatabaseHelper.GetDataModelDataContext();

                Category categoryNew = msDC.Categories.Single(d => d.IID == category.IID);
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
                DatabaseHelper.Update<Category>(msDC, category, categoryNew);

                msDC.Dispose();
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
        public object GetAllCategoryForListView()
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<Category> categoyList = new List<Category>();
                categoyList = dbContext.Categories.Where(d => d.IsRemoved == false).OrderByDescending(x=>x.IID).ToList();

                dbContext.Dispose();
                return categoyList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
        public Category GetCategoryByID(long categoryID)
        {
            try
            {

                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                Category category = new Category();
                category = dbContext.Categories.Single(d => d.IID == categoryID && d.IsRemoved == false);
                dbContext.Dispose();
                return category;


            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        /// <summary>
        /// Get all categories by parent category IID
        /// </summary>
        /// <param name="parentCategoryID"></param>
        /// <returns></returns>
        public List<Category> GetAllCategoryByParentID(Int64 parentCategoryID)
        {
            try
            {

                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                var category = (from tr in dbContext.Categories
                                where tr.ParentID != null && tr.IsRemoved == false && tr.ParentID == parentCategoryID
                                select tr).OrderBy(x => x.Name).ToList();
                dbContext.Dispose();
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
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<Category> categoryList = new List<Category>();
                categoryList = dbContext.Categories.Where(d => d.IsRemoved == false && d.ParentID == null).OrderBy(x=>x.Name).ToList();
                dbContext.Dispose();
                return categoryList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        /// <summary>
        /// Hasan Add GetParentCategoryIDByName Category Date: 4 March 2015
        /// </summary>
        /// <returns></returns>
        /// 
        public int GetParentCategoryIDByName(string categoryName)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                var categoryID = dbContext.Categories.Single(d => d.IsRemoved == false && d.ParentID == null && d.Name == categoryName).IID.ToString();
                dbContext.Dispose();
                return int.Parse(categoryID);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        #endregion Get Methods


       

        #region Methods for Category Tree

        private int count = 0;
        private int subCatCounter = 0;
        private List<SP_CategoryTree_GetSearchedCategoryOrAllResult> categoryList = new List<SP_CategoryTree_GetSearchedCategoryOrAllResult>();
        public List<SP_CategoryTree_GetSearchedCategoryOrAllResult> GetAllSearchedCategory(string catName)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                var catList = new List<SP_CategoryTree_GetSearchedCategoryOrAllResult>();
                if (catName == " ")
                {
                    catList = dbContext.SP_CategoryTree_GetSearchedCategoryOrAll(null, null).ToList();
                    
                }
                else
                {
                    catList = dbContext.SP_CategoryTree_GetSearchedCategoryOrAll(catName, null).ToList();
                   

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

               
               
               // dbContext.Dispose();

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

                        GetCategoryListByParentID(categoryDb.IID);
                    }
                }

                return categoryList.ToList();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }
        }

        public void GetCategoryListByParentID(Int64 parID)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                var catListByParentID = dbContext.SP_CategoryTree_GetSearchedCategoryOrAll(null, parID).ToList();
                dbContext.Dispose();

                foreach (var category in catListByParentID)
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
                    GetCategoryListByParentID(category.IID);
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
                    OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                    var parentId = dbContext.SP_CategoryTree_GetCategoryParentID(parId).ToList().Single().ParentID;
                    dbContext.Dispose();
                    //var parent = dbContext.Categories.SingleOrDefault(parIid => parIid.IID == parId);
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
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                Category ca = new Category();
                ca = dbContext.Categories.Single(c => c.IID == CatID && c.IsRemoved == false);
                dbContext.Dispose();
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
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<Category> categoryList = new List<Category>();
                categoryList = dbContext.Categories.Where(d => d.IsRemoved == false && d.IID == CatID && d.ParentID==null).ToList();
                dbContext.Dispose();
                if (categoryList.Count > 0)
                    return true;
                else
                    return false;

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
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                
               var NavMenuList = (from catagory in dbContext.Categories
                              where catagory.IsRemoved == false && catagory.ParentID == null && (catagory.Name == "For Sell" || catagory.Name == "Property" || catagory.Name == "Motors" || catagory.Name == "Jobs" || catagory.Name == "Services" || catagory.Name == "Community")
                              select new { catagory.IID, catagoryName = catagory.Name}).ToList();
               dbContext.Dispose();
               return NavMenuList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
        public List<OH_OT_GetNavMenuResult> GetNavmenu()
        {
            OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
            var getAllNavmenu = dbContext.OH_OT_GetNavMenu().ToList();
            return getAllNavmenu;
        }
    }
}
