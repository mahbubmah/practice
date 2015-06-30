using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Basic
{
    public class AdLogInfoRT : IDisposable
    {
        //private readonly OiiOMartDBDataContext _OiiOMartDBDataContext=new OiiOMartDBDataContext();
        private readonly OiiOMartDBDataContext _OiiOMartDBDataContext;
        public AdLogInfoRT()
        {
             _OiiOMartDBDataContext = DatabaseHelper.GetDataModelDataContext();
        }

       
     public void AddAdLogInfo(AdLogInfo AdLogInfoObj)
        {
            try
            {
                OiiOMartDBDataContext ob = DatabaseHelper.GetDataModelDataContext();
                DatabaseHelper.Insert<AdLogInfo>(AdLogInfoObj);
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message, ex); 
            }
        }

     public void UpdateAdLogInfo(AdLogInfo AdLogInfoObj)
        {
            try
            {
                AdLogInfo AdLogInfoObjNew = _OiiOMartDBDataContext.AdLogInfos.SingleOrDefault(d => d.IID == AdLogInfoObj.IID);

                DatabaseHelper.Update<AdLogInfo>(_OiiOMartDBDataContext, AdLogInfoObj, AdLogInfoObjNew);
                _OiiOMartDBDataContext.Dispose();

                //_OiiOMartDBDataContext.Dispose();
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message, ex); 
            }
        }

    
     public AdLogInfo GetAdLogInfoByIID(int AdLogInfoID)
     {
         try
         {
             AdLogInfo AdLogInfoObj = _OiiOMartDBDataContext.AdLogInfos.SingleOrDefault(d => d.IID == AdLogInfoID);
             //_OiiOMartDBDataContext.Dispose();
             return AdLogInfoObj;
         }
         catch (Exception ex)
         {
             throw new Exception(ex.Message, ex);
         }
     }

     public AdLogInfo GetAdLogInfoName(string conName)
     {
         try
         {
             
             var AdLogInfoObj = (from tr in _OiiOMartDBDataContext.AdLogInfos
                                   where tr.Name == conName
                                   select tr).SingleOrDefault();
             return AdLogInfoObj;
         }
         catch (Exception ex)
         {
             throw new Exception(ex.Message, ex);
         }
     }
     public List<AdLogInfo> GetAllAdLogInfo()
     {
         try
         {
             List<AdLogInfo> Countries = _OiiOMartDBDataContext.AdLogInfos.ToList();
             return Countries;
         }
         catch (Exception ex)
         {
             throw new Exception(ex.Message, ex);
         }
     }
     

     public object GetAllAdLogInfoForListView()
     {
         var lifInsurance = from obj in _OiiOMartDBDataContext.AdLogInfos
                            select new { obj.Address , obj.BussinessDescription, obj.ContactPhoneNo, obj.DisplayEndDate,obj.DisplayOnPageID, obj.DisplayStartDate, obj.IID, obj.IsRemoved, obj.LogoUrl, obj.Name, obj.PayAmount, obj.WebAddress  }; //diviionOrState.Name

         return lifInsurance;
     }
     


        #region IDisposable Members
            public void Dispose()
            {
                GC.SuppressFinalize(this);
            }

        #endregion IDisposable Members


            
    }
}


