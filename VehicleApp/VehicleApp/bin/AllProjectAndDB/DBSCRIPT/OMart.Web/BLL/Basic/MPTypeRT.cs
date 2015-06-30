using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Basic
{
   public class MPTypeRT:IDisposable
    {
       private readonly OiiOMartDBDataContext _OiiOMartDBDataContext;

       public MPTypeRT()
       {
           this._OiiOMartDBDataContext = DatabaseHelper.GetDataModelDataContext();
       }

       public void AddMobile(MPType mobile)
       {
           try
           {
               DatabaseHelper.Insert<MPType>(mobile);
           }
           catch (Exception ex)
           { throw new Exception(ex.Message, ex); }
       }
       public MPType GetMobileByIID(int mobileID)
       {
           try
           {
               MPType mobile = _OiiOMartDBDataContext.MPTypes.SingleOrDefault(d => d.IID == mobileID);
               //_OiiOMartDBDataContext.Dispose();
               return mobile;
           }
           catch (Exception ex)
           {
               throw new Exception(ex.Message, ex);
           }
       }

       public void UpdateMobilePhone(MPType mobile)
       {
           try
           {
               MPType mobileNew = _OiiOMartDBDataContext.MPTypes.SingleOrDefault(d => d.IID == mobile.IID);

               DatabaseHelper.Update<MPType>(_OiiOMartDBDataContext, mobile, mobileNew);

               //_OiiOMartDBDataContext.Dispose();
           }
           catch (Exception ex)
           {
               throw new Exception(ex.Message, ex);
           }
       }

       public List<MPType> GetAllMobiles()
       {
           try
           {
               List<MPType> mobiles = _OiiOMartDBDataContext.MPTypes.OrderBy(x => x.TypeName).ToList();
               //var mobiles = from mpType in _OiiOMartDBDataContext.MPTypes
               //              join componyInfo in _OiiOMartDBDataContext.CompanyInfos on mpType.CompanyInfoID equals componyInfo.IID
               //              select new { mpType.TypeName, componyInfo.Name, mpType.IsRemoved };

               return mobiles;
           }
           catch (Exception ex)
           {
               throw new Exception(ex.Message, ex);
           }
       }

       public object GetAllMobilesForDisplay()
       {
           try
           {
              // List<MPType> mobiles = _OiiOMartDBDataContext.MPTypes.OrderBy(x => x.TypeName).ToList();
               var mobiles = from mpType in _OiiOMartDBDataContext.MPTypes
                            join componyInfo in _OiiOMartDBDataContext.CompanyInfos on mpType.CompanyInfoID equals componyInfo.IID
                             select new { mpType.IID, type=mpType.TypeName, cname=componyInfo.Name, mpType.IsRemoved };

               return mobiles;
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

       public List<MobilePhoneSlide> GetAllMobilePhonestype()
       {
           try
           {
               List<MobilePhoneSlide> _MobilePhoneSlide = new List<MobilePhoneSlide>();
               var mobileList = _OiiOMartDBDataContext.spGetAllMobilePhoneType().ToList();
               foreach (var mp in mobileList)
               {
                   var phoneTypeDisplay = new MobilePhoneSlide();
                   phoneTypeDisplay.IID = mp.IID;
                   phoneTypeDisplay.TypeName = mp.TypeName;
                 
                   _MobilePhoneSlide.Add(phoneTypeDisplay);
               }
               return _MobilePhoneSlide;
           }
           catch (Exception exception)
           {
               throw new Exception(exception.Message, exception);
           }

       }
       public class MobilePhoneSlide
       {
           public Int64 IID { get; set; }

           public string TypeName { get; set; }
           //public string LoanTypeDescription { get; set; }

           //public string LoanTypeImage { get; set; }
       }
    }
}
