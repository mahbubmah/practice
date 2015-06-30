using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Utilities;

namespace BLL.Basic
{
    public class DefaultRT
    {
        public class DefaultPageModuleDisplay
        {
            public int Count { get; set; }
            public string ModuleName { get; set; }
            public string ModuleImage { get; set; }
            public List<ModuleLink> ModuleLinkList { get; set; }
        }

        public class ModuleLink
        {
            public string Url { get; set; }
            public string UrlDisplayName { get; set; }
        }

        private readonly OiiOMartDBDataContext dbContext;
        public DefaultRT ()
        {
            dbContext = DatabaseHelper.GetDataModelDataContext();
        }

        #region IDisposable Members
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members

        public List<UrlWFList> GetAllModuleList()
        {
            try
            {
                List<UrlWFList> list = new List<UrlWFList>();
                var moduleList = dbContext.UrlWFLists.ToList();
                foreach (UrlWFList url in moduleList)
                {
                    UrlWFList ur = new UrlWFList();
                    ur = url;
                    ur.ModuleName = EnumHelper.EnumToStringWithSpace(url.ModuleName);
                }
                return moduleList;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message,ex);
            }
        }
    }
}
