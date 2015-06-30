using System;
using System.Collections.Generic;
using System.Linq;
using OH.DAL;

namespace OH.BLL.Basic
{
    public class ColorRT : IDisposable
    {
        #region Get Methods

        public List<Color> GetColorByName(string colorName)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<Color> colorList = new List<Color>();
                colorList = dbContext.Colors.Where(d => d.IsRemoved == false && d.Name.Contains(colorName)).ToList();

                dbContext.Dispose();
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
                OiiOHaatDCDataContext msDC = DatabaseHelper.GetDataModelDataContext();

                Color colorNew = msDC.Colors.Single(d => d.IID == color.IID);
                DatabaseHelper.Update<Color>(msDC, color, colorNew);

                msDC.Dispose();
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
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<Color> colorList = new List<Color>();
                colorList = dbContext.Colors.Where(d => d.IsRemoved == false).ToList();

                dbContext.Dispose();
                return colorList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public Color GetColorByID(int colorID)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                Color color = new Color();
                color = dbContext.Colors.Single(d => d.IID == colorID && d.IsRemoved == false);
                dbContext.Dispose();
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

                OiiOHaatDCDataContext db = DatabaseHelper.GetDataModelDataContext();
                var colorList = db.Colors.Where(x => x.Name.StartsWith(colorName) && x.IsRemoved == false).Take(10).ToList();
                List<Color> cList = new List<Color>(colorList);
                db.Dispose();
                
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
