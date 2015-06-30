using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OH.DAL;

namespace OH.BLL.Basic
{
   public class PictureLogRT:IDisposable
    {

          private readonly OiiOHaatDCDataContext _dbContext;
          public PictureLogRT()
        {
            this._dbContext = DatabaseHelper.GetDataModelDataContext();
        }

        #region Get Methods

        public void AddMaterialPicture(PictureLog aPicture)
        {
            try
            {

                DatabaseHelper.Insert<PictureLog>(aPicture);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public List<PictureLog> GetPictureByMaterialIID(Int64 materialId)
        {
            try
            {
                var pictureListByMatCode = _dbContext.PictureLogs.Where(pic => pic.MaterialID == materialId).ToList();
                return pictureListByMatCode;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message,ex);
            }
        }

        public List<PictureLog> GetAllPicturesAccordingToMaterialID(Int64 MaterialID) 
        {
            var objPicture = (from tr in _dbContext.PictureLogs
                              where tr.MaterialID == MaterialID
                              select tr).ToList();
            return objPicture;
        }
        public void DeletePictureByUrl(string imgUrl)
        {
            try
            {
                var picture = _dbContext.PictureLogs.FirstOrDefault(pic => pic.UrlAddress == imgUrl);

                DatabaseHelper.Delete<PictureLog>(_dbContext,picture);
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
    }
}
