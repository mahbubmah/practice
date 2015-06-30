using System;
using System.Collections.Generic;
using System.Linq;
using Tula.DAL;

namespace Tula.BLL.Basic
{
    public class ColorRt : IDisposable
    {
        private readonly DBConnectionString _db;
        public ColorRt()
        {
            _db = DatabaseHelper.GetDataModelDataContext();
        }


        #region Get Methods

        public List<Color> GetColorByName(string colorName)
        {
            try
            {
                List<Color> colorList = _db.Colors.Where(d => d.IsRemoved == false && d.Name.Contains(colorName)).ToList();

                _db.Dispose();
                return colorList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void AddColor(Color color)
        {
            try
            {

                DatabaseHelper.Insert<Color>(color);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void UpdateColor(Color color)
        {
            try
            {

                Color colorNew = _db.Colors.Single(d => d.IID == color.IID);
                DatabaseHelper.Update<Color>(_db, color, colorNew);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public object GetAllColorForListView()
        {
            try
            {
                var colorList  = _db.Colors.Where(d => d.IsRemoved == false).ToList();
                return colorList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public Color GetColorById(int colorID)
        {
            try
            {
                var color = _db.Colors.Single(d => d.IID == colorID && d.IsRemoved == false);
                return color;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public List<Color> GetColorNameForSearch(string colorName)
        {
            try
            {


                var cList = _db.Colors.Where(x => x.Name.StartsWith(colorName) && x.IsRemoved == false).Take(10).ToList();
                return cList;
            }
           
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
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
