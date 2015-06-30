using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OH.DAL;

namespace OH.BLL.Basic
{
    public class VisitorRT : IDisposable
    {
        /// <summary>
        /// Created By : Asiful Islam
        /// </summary>
        public VisitorRT()
        { }

        #region IDisposable Members

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members


        public List<VisitorInfo> GetVisitorInfoIPnType(string IP,string IpType)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<VisitorInfo> VisitorInfoList = new List<VisitorInfo>();
                VisitorInfoList = dbContext.VisitorInfos.Where(d => d.IPAddress == IP && d.IPType.Contains(IpType)).ToList();

                dbContext.Dispose();
                return VisitorInfoList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public void AddVisitor(VisitorInfo visitor)
        {
            try
            {
                DatabaseHelper.Insert<VisitorInfo>(visitor);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public VisitorInfo GetVisitorID(string ip,string type)
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                VisitorInfo VisitorIDList = new VisitorInfo();
                VisitorIDList = dbContext.VisitorInfos.Single(d => d.IPAddress == ip && d.IPType==type);
                
                //var activeDesignation = usrGrpList.Where(d => d.IsActive == true).ToList();
                //dbContext.Dispose();
                return VisitorIDList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public List<VisitorInfo> GetAllVisitor()
        {
            try
            {
                OiiOHaatDCDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                List<VisitorInfo> VisitorInfoList = new List<VisitorInfo>();
                VisitorInfoList = dbContext.VisitorInfos.Where(c => c.IPAddress!=null).ToList();
                dbContext.Dispose();
                //var Countries = from countryDB in dbContext.Countries
                //                where countryDB.Name.StartsWith(conName)
                //                select new { countryDB.IID, countryDB.Name };
                return VisitorInfoList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
    }
}
