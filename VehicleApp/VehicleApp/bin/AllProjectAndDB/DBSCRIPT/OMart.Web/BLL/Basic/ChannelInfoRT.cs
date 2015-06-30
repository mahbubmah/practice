using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Basic
{
    public class ChannelInfoRT :IDisposable
    {
        //private readonly OiiOMartDBDataContext _OiiOMartDBDataContext=new OiiOMartDBDataContext();
        private readonly OiiOMartDBDataContext _OiiOMartDBDataContext;
        public ChannelInfoRT()
        {
             _OiiOMartDBDataContext = DatabaseHelper.GetDataModelDataContext();
        }

       
     public void AddChannelInfo(BDChannelInfo ChannelInfoObj)
        {
            try
            {
                OiiOMartDBDataContext ob = DatabaseHelper.GetDataModelDataContext();
                DatabaseHelper.Insert<BDChannelInfo>(ChannelInfoObj);
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message, ex); 
            }
        }

     public List<BDChannelInfo> GetAllBDChannelInfo()
     {
         try
         {
             List<BDChannelInfo> Countries = _OiiOMartDBDataContext.BDChannelInfos.ToList();
             return Countries;
         }
         catch (Exception ex)
         {
             throw new Exception(ex.Message, ex);
         }
     }
     public BDChannelInfo GetChannelInfoSerialNo(int SerialNo)
     {
         try
         {

             var ChannelInfoObj = (from tr in _OiiOMartDBDataContext.BDChannelInfos
                                   where tr.SerialNo == SerialNo
                                   select tr).SingleOrDefault();
             return ChannelInfoObj;
         }
         catch (Exception ex)
         {
             throw new Exception(ex.Message, ex);
         }
     }
     public void UpdateChannelInfo(BDChannelInfo ChannelInfoObj)
        {
            try
            {
                BDChannelInfo ChannelInfoObjNew = _OiiOMartDBDataContext.BDChannelInfos.SingleOrDefault(d => d.IID == ChannelInfoObj.IID);

                DatabaseHelper.Update<BDChannelInfo>(_OiiOMartDBDataContext, ChannelInfoObj, ChannelInfoObjNew);
                _OiiOMartDBDataContext.Dispose();

                //_OiiOMartDBDataContext.Dispose();
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message, ex); 
            }
        }

     public BDChannelInfo GetChannelInfoByIID(BDChannelInfo ChannelInfoID)
        {
            try
            {
                BDChannelInfo ChannelInfoObj = _OiiOMartDBDataContext.BDChannelInfos.SingleOrDefault(d => d.IID == ChannelInfoID.IID);
                //_OiiOMartDBDataContext.Dispose();
                return ChannelInfoObj;
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message, ex);
            }
        }
     public BDChannelInfo GetChannelInfoByIID(int ChannelInfoID)
     {
         try
         {
             BDChannelInfo BDChannelInfoObj = _OiiOMartDBDataContext.BDChannelInfos.SingleOrDefault(d => d.IID == ChannelInfoID);
             //_OiiOMartDBDataContext.Dispose();
             return BDChannelInfoObj;
         }
         catch (Exception ex)
         {
             throw new Exception(ex.Message, ex);
         }
     }

     public BDChannelInfo GetChannelInfoName(string conName)
     {
         try
         {
             
             var ChannelInfoObj = (from tr in _OiiOMartDBDataContext.BDChannelInfos
                                   where tr.Name == conName
                                   select tr).SingleOrDefault();
             return ChannelInfoObj;
         }
         catch (Exception ex)
         {
             throw new Exception(ex.Message, ex);
         }
     }

     public object GetAllChannelInfoForListView()
     {
         var lifInsurance = from lifInsu in _OiiOMartDBDataContext.BDChannelInfos
                            select new { lifInsu.IID, lifInsu.IsRemoved, lifInsu.Name, lifInsu.Note, lifInsu.SerialNo, lifInsu.WebAddress, lifInsu.ContactPhone, lifInsu.Address }; //diviionOrState.Name

         return lifInsurance;
     }
     public List <BDChannelInfo> GetAllChannelInfo()
        {
            try
            {

                var ChannelInfoObj = _OiiOMartDBDataContext.BDChannelInfos.ToList();
                return ChannelInfoObj;

            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message, ex); 
            }
        }


        #region IDisposable Members
            public void Dispose()
            {
                GC.SuppressFinalize(this);
            }

        #endregion IDisposable Members


            
    }
}



