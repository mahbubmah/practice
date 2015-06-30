using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OH.DAL;

namespace OH.BLL.Basic
{
    public class ModelRT : IDisposable
    {
        OiiOHaatDCDataContext _dbContext = null;
        public ModelRT()
        {
            _dbContext = DatabaseHelper.GetDataModelDataContext();
        }

        #region IDisposable Members

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members



        public List<GetModelNameForSearchResult> GetModelNameForSearch(string modelName, long brandID)
        {
            try
            {
                
                brandID = 1;
                return _dbContext.GetModelNameForSearch(brandID, modelName).Take(10).ToList();
                //List<Model> modList = new List<Model>();
                //if (brandID == 0)
                //{
                //    var modellist = db.Models.Where(x => x.Name.Contains(modelName)).Take(15).ToList();
                //    modList = modellist;
                //    return modList;
                //}

                //var modelList = db.Models.Where(x => x.BrandID == brandID && x.Name.Contains(modelName) && x.IsRemoved == false).Take(10).ToList();
                //modList = modelList;
                //db.Dispose();
                //return modList;


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public object GetAllModelByName(string brandName, int brandID)
        {
            try
            {
                var modelColl = from modelDB in _dbContext.Models select new { modelDB.IID, modelDB.Name };
                return modelColl;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public object GetAllModelForListView()
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                var models = from model in dbContext.Models
                             join brand in dbContext.Brands on model.BrandID equals brand.IID
                             where brand.IsRemoved == false && model.IsRemoved == false
                             select new { model.IID, model.Name, BrandName = brand.Name};
                return models;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public Model GetModelByID(int modelID)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                Model model = new Model();
                model = dbContext.Models.Single(d => d.IID == modelID && d.IsRemoved == false);
                dbContext.Dispose();
                return model;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public bool IsModelNameExists(string name, int brandID)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<Model> modelList = new List<Model>();
                modelList = dbContext.Models.Where(d => d.IsRemoved == false && d.Name == name && d.BrandID == brandID).ToList();
                dbContext.Dispose();
                if (modelList.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public bool IsModelNameExistInOterRows(long id, string modelName, long? brandID)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<Model> modelList = new List<Model>();
                modelList = dbContext.Models.Where(d => d.IsRemoved == false && d.Name == modelName && d.IID != id && d.BrandID == brandID).ToList();
                dbContext.Dispose();
                if (modelList.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public void AddModel(Model model)
        {
            try
            {
                DatabaseHelper.Insert<Model>(model);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public void UpdateModel(Model model)
        {
            try
            {
                OiiOHaatDCDataContext msDC = DatabaseHelper.GetDataModelDataContext();
                Model modelNew = msDC.Models.Single(d => d.IID == model.IID);
                DatabaseHelper.Update<Model>(msDC, model, modelNew);

                msDC.Dispose();
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

    }
}
