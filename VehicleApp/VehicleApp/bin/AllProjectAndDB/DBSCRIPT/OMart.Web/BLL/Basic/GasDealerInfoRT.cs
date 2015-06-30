using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Basic;

namespace BLL.Basic
{
    public class GasDealerInfoRT : IDisposable
    {
       
        private readonly OiiOMartDBDataContext _OiiOMartDBDataContext;
        public GasDealerInfoRT()
        {
            _OiiOMartDBDataContext = DatabaseHelper.GetDataModelDataContext();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void AddGasDeal(GasDealerInfo aGasDeal)
        {
            try
            {
                DatabaseHelper.Insert<GasDealerInfo>(aGasDeal);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public List<spGetAllGasDealForListViewResult> GetGasDealAllForListView()
        {
            try
            {
                var gasDealList = _OiiOMartDBDataContext.spGetAllGasDealForListView().Where(x=>x.IsRemoved==false).ToList();
                return gasDealList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public GasDealerInfo GetGasDealInfoByID(int p)
        {
            try
            {
                GasDealerInfo gas = new GasDealerInfo();
                gas = _OiiOMartDBDataContext.GasDealerInfos.SingleOrDefault(d => d.IID == p);
                return gas;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public void UpdateGasDealInfo(GasDealerInfo gasDeal)
        {
            try
            {
                GasDealerInfo gas = _OiiOMartDBDataContext.GasDealerInfos.SingleOrDefault(d => d.IID == gasDeal.IID);
                DatabaseHelper.Update<GasDealerInfo>(_OiiOMartDBDataContext, gasDeal, gas);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
    }
}
