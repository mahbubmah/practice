using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OH.DAL;

namespace OH.BLL.Basic
{
    public class PictureRT:IDisposable
    {
        private readonly OiiOHaatDCDataContext _dbContext;
        public PictureRT()
        {
            this._dbContext = DatabaseHelper.GetDataModelDataContext();
        }

        #region Get Methods

        public void AddMaterialPicture(DAL.Picture aPicture)
        {
            try
            {

                DatabaseHelper.Insert<Picture>(aPicture);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public List<Picture> GetPictureByMaterialIID(Int64 materialId)
        {
            try
            {
                var pictureListByMatCode = _dbContext.Pictures.Where(pic => pic.MaterialID == materialId).ToList();
                return pictureListByMatCode;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message,ex);
            }
        }

        public List<Picture> GetAllPicturesAccordingToMaterialID(Int64 MaterialID) 
        {
            var objPicture = (from tr in _dbContext.Pictures
                              where tr.MaterialID == MaterialID
                              select tr).ToList();
            return objPicture;
        }
        public void DeletePictureByUrl(string imgUrl)
        {
            try
            {
                var picture = _dbContext.Pictures.FirstOrDefault(pic => pic.UrlAddress == imgUrl);

                DatabaseHelper.Delete<Picture>(_dbContext,picture);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        #endregion Get Methods

        #region IDisposable Members

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members




        //public List<Picture> GetPictureByCode(string pictureCode)
        //{
        //    try
        //    {
        //        var path = "~/Image/MatImage/" + pictureCode;
        //        var picList = _dbContext.Pictures.Where(x => x.UrlAddress.StartsWith(path)).ToList();
        //        _dbContext.Dispose();
        //        return picList;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message,ex);
        //    }
        //}



       

        public Picture getPicturebIID(int picID)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                Picture pic = new Picture();
                pic = dbContext.Pictures.Single(d => d.IID == picID);
                dbContext.Dispose();
                return pic;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
