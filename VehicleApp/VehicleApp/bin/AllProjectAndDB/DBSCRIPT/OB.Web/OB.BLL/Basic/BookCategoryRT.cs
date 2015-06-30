using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using OB.DAL;


namespace OB.BLL.Basic
{


    public class BookCategoryRT:IDisposable
    {

        #region Get Methods
        public List<BooKCategory> GetBookCategoryByName(string catName)
        {
            try
            {
                OiiOBookDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<BooKCategory> categoyList = new List<BooKCategory>();
                categoyList = dbContext.BooKCategory.Where(d => d.IsRemoved == false && d.CategoryName.Contains(catName)).ToList();

                dbContext.Dispose();
                return categoyList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
        public List<BooKCategory> GetBooKCategoryAll()
        {
            try
            {
                OiiOBookDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<BooKCategory> BookCategoryList = new List<BooKCategory>();
                BookCategoryList = dbContext.BooKCategory.Where(d => d.IsRemoved == false).ToList();
                dbContext.Dispose();
                return BookCategoryList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
        public void AddBooKCategory(BooKCategory category)
        {
            try
            {

                DatabaseHelper.Insert<BooKCategory>(category);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
        public void UpdateBooKCategory(BooKCategory category)
        {
            try
            {
                OiiOBookDCDataContext msDC = DatabaseHelper.GetDataModelDataContext();

                BooKCategory categoryNew = msDC.BooKCategory.Single(d => d.IID == category.IID);
                DatabaseHelper.Update<BooKCategory>(msDC, category, categoryNew);

                msDC.Dispose();
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
        public object GetAllBooKCategoryForListView()
        {
            try
            {
                OiiOBookDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<BooKCategory> categoyList = new List<BooKCategory>();
                categoyList = dbContext.BooKCategory.Where(d => d.IsRemoved == false).ToList();

                dbContext.Dispose();
                return categoyList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
        public class BookCategoryListView
        {
            public Int64 IID { get; set; }
            public string CategoryName { get; set; }
            public string ParentCategory { get; set; }
            public string CategoryDescription { get; set; }
            public DateTime? LastUpdatedDate { get; set; }
           
            public int? DisplayOrder { get; set; }
          
        }

       

        public List<BookCategoryListView> GetAllBookCategoryForListView()
        {
            try
            {
                OiiOBookDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<BookCategoryListView> catDisplayList = new List<BookCategoryListView>();
                var catList = dbContext.SP_GetAllCategoryForListView().ToList();
                foreach (var cat in catList)
                {
                    var catDisplay = new BookCategoryListView();
                    catDisplay.IID = cat.IID;
                    catDisplay.CategoryName = cat.CategoryName;
                    catDisplay.LastUpdatedDate = cat.LastUpdatedDate;
                    catDisplay.DisplayOrder = cat.DisplayOrder;
                    catDisplay.CategoryDescription = cat.CategoryDescription;
                    switch (cat.ParentCategory)
                    {
                        case 1:
                            catDisplay.ParentCategory = "Fiction";
                            break;
                        case 2:
                            catDisplay.ParentCategory = "Non-Fiction";
                            break;
                        
                    }

                    catDisplayList.Add(catDisplay);
                }
                return catDisplayList;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }

        }
        public BooKCategory GetBookCategoryByID(int categoryID)
        {
            try
            {
                
                    OiiOBookDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                    BooKCategory category = new BooKCategory();
                    category = dbContext.BooKCategory.Single(d => d.IID == categoryID && d.IsRemoved == false);
                    dbContext.Dispose();
                    return category;
                
               
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        #endregion Get Methods

        #region Methods for Category Tree

        private int count = 0;
        private string msg = "- ";

        private List<BooKCategory> categoryList = new List<BooKCategory>();

        private List<BooKCategory> catListByParentID = new List<BooKCategory>();
        public List<BooKCategory> GetAllSearchedBookCategory(string catName)
        {
            OiiOBookDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
            List<BooKCategory> cat = new List<BooKCategory>();

            if (catName==" ")
            {
                cat = dbContext.BooKCategory.ToList();
               dbContext.Dispose();
            }
            else
            {
                cat = dbContext.BooKCategory.Where(ca => ca.CategoryName.StartsWith(catName)).ToList();
               dbContext.Dispose();
            }
            

            foreach (var category in cat)
            {
                category.CategoryDescription = category.CategoryName;//for fill description
            }

            foreach (var category in cat)
            {
                if (categoryList.All(ca => ca.IID != category.IID))
                {
                    categoryList.Add(category);
                }
                
                msg = "- ";
                count = 0;
                var chCatList = GetBookCategoryListByParentID(category.IID).ToList(); //send parent IID
                categoryList.AddRange(chCatList);

               
            }
            var chkForNotRemovedCatList = categoryList.Where(x => x.IsRemoved == false).ToList();
            return chkForNotRemovedCatList;
        }
        public List<BooKCategory> GetBookCategoryListByParentID(Int64 parID)
        {
            count++;
            OiiOBookDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();

            if (parID != null)
            {
                catListByParentID = dbContext.BooKCategory.Where(cat => cat.ParentCategoryID == parID).ToList();
                dbContext.Dispose();
               
            }

            if (catListByParentID.Count > 0)
            {
                string newSpaceMsg=string.Empty; //space for subcategory
                for (int spaceCount = 0; spaceCount < count; spaceCount++)
                {
                    newSpaceMsg = msg + newSpaceMsg;
                    
                }
                foreach (var category in catListByParentID)
                {
                    category.CategoryDescription = newSpaceMsg + category.CategoryName;
                    
                }
            }
            
            if (!catListByParentID.Any()) return catListByParentID;

            foreach (var category in catListByParentID)
            {
                var cList = categoryList.Where(ca => ca.IID == category.IID).ToList();
                if (!cList.Any())
                {
                    categoryList.Add(category);
                }
                
                GetBookCategoryListByParentID(category.IID);
            }

            return catListByParentID;
        }

        #endregion Methods for Category Tree


        #region IDisposable Members

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members



        public string GetCategoryDes(int id)
        {
            try
            {

                OiiOBookDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                string category = string.Empty;
                category = dbContext.BooKCategory.First(d => d.ParentCategoryID == id && d.IsRemoved == false).CategoryDescription.ToString();
                dbContext.Dispose();
                return category;


            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
 
        }
    }
}

