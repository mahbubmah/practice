using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Basic
{
    public class VisitorRT : IDisposable
    {
        public VisitorRT()
        { }

        #region IDisposable Members

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members


        public List<VisitorInfo> GetVisitorInfoIPnType(string IP, string IpType)
        {
            try
            {
               OiiOMartDBDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
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

        public VisitorInfo GetVisitorID(string ip, string type)
        {
            try
            {
                OiiOMartDBDataContext dbContext = DatabaseHelper.GetDataModelDataContext();
                VisitorInfo VisitorIDList = new VisitorInfo();
                VisitorIDList = dbContext.VisitorInfos.Single(d => d.IPAddress == ip && d.IPType == type);

                //var activeDesignation = usrGrpList.Where(d => d.IsActive == true).ToList();
                //dbContext.Dispose();
                return VisitorIDList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
    }
}
