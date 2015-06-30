using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
  
   public class NewsCommunityRT: IDisposable
    {

        private readonly OiiOMartDBDataContext _OiiOMartDBDataContext;
        public NewsCommunityRT()
        {
            this._OiiOMartDBDataContext = DatabaseHelper.GetDataModelDataContext();
        }

        public void AddCommunityNews(CommunityNew _CommunityNew)
        {
            try
            {
                DatabaseHelper.Insert<CommunityNew>(_CommunityNew);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message, ex); }
        }

        public void UpdateCommunityNews(CommunityNew _CommunityNew)
        {
            try
            {
                CommunityNew communityNew = _OiiOMartDBDataContext.CommunityNews.SingleOrDefault(d => d.IID == _CommunityNew.IID);

                DatabaseHelper.Update<CommunityNew>(_OiiOMartDBDataContext, _CommunityNew, communityNew);

                //_OiiOMartDBDataContext.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
     
        public CommunityNew GetCommunityNewByIID(Int64 communityID)
        {
            try
            {
                CommunityNew CommunityNewID = _OiiOMartDBDataContext.CommunityNews.SingleOrDefault(d => d.IID == communityID);
                //_OiiOMartDBDataContext.Dispose();
                return CommunityNewID;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<CommunityNew> GetAllCommunityNews()
        {
            try
            {
                List<CommunityNew> CommunityNewColl = _OiiOMartDBDataContext.CommunityNews.OrderBy(x => x.IID).ToList();
                return CommunityNewColl;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<CommunityNews> GetAllCommunityNewrmations()
        {
            try
            {
                List<CommunityNewrmation> _CommunityNewrmationDisplayList = new List<CommunityNewrmation>();
                var communityList = _OiiOMartDBDataContext.SP_GetAllcommunityInfoForListView().ToList();
                foreach (var community in communityList)
                {
                    var CommunityNewDisplay = new CommunityNewrmation();
                    CommunityNewDisplay.IID = community.IID;
                    CommunityNewDisplay.CompanyName = community.CompanyName;
                    CommunityNewDisplay.MPTypeName = community.MPTypeName;
                    CommunityNewDisplay.TotalTalkTime = community.TotalTalkTime;
                    CommunityNewDisplay.ModelName = community.ModelName;
                    CommunityNewDisplay.TotalTextMessage = community.TotalTextMessage;
                    CommunityNewDisplay.TotalUsableData = community.TotalUsableData;
                    CommunityNewDisplay.TotalPrice = community.TotalPrice;
                    CommunityNewDisplay.ContractDuration = community.ContractDuration;
                    CommunityNewDisplay.MonthlyInstallmentAmt = community.MonthlyInstallmentAmt;
                    CommunityNewDisplay.WarrantyInfo = community.WarrantyInfo;
                    CommunityNewDisplay.PictureUrl = community.PictureUrl;
                    CommunityNewDisplay.PostAdDate = community.PostAdDate;
                    CommunityNewDisplay.PostLastDisplayDate = community.PostLastDisplayDate;
                    CommunityNewDisplay.RedirectUrl = community.RedirectUrl;

                    CommunityNewDisplay.NetworkServiceProvider = ((Utilities.EnumCollection.NetworkServiceProvider)community.NetworkServiceProvider).ToString();
                    CommunityNewDisplay.UsableDataUnit = ((Utilities.EnumCollection.UsableDataUnit)community.UsableDataUnit).ToString();
                    CommunityNewDisplay.TalkTimeUnit = ((Utilities.EnumCollection.TalkTimeUnit)community.TalkTimeUnit).ToString();
                    CommunityNewDisplay.ConnectionType = ((Utilities.EnumCollection.ConnectionType)community.ConnectionType).ToString();
                    CommunityNewDisplay.SIMAvailable = ((Utilities.EnumCollection.AvailableSIM)community.SIMAvailable).ToString();

                    /*                     
                    switch (community.NetworkServiceProvider)
                    {
                        case 1:
                            CommunityNewDisplay.NetworkServiceProvider = "Grameen Phone";
                            break;
                        case 2:
                            CommunityNewDisplay.NetworkServiceProvider = "Airtel";
                            break;
                        case 3:
                            CommunityNewDisplay.NetworkServiceProvider = "Banglalink";
                            break;
                        case 4:
                            CommunityNewDisplay.NetworkServiceProvider = "Teletalk";
                            break;
                        case 5:
                            CommunityNewDisplay.NetworkServiceProvider = "Aktel";
                            break;
                    }
                    switch (community.UsableDataUnit)
                    {
                        case 1:
                            CommunityNewDisplay.UsableDataUnit = "MB";
                            break;
                        case 2:
                            CommunityNewDisplay.UsableDataUnit = "GB";
                            break;

                    }
                    switch (community.TalkTimeUnit)
                    {
                        case 1:
                            CommunityNewDisplay.TalkTimeUnit = "Minute";
                            break;
                        case 2:
                            CommunityNewDisplay.TalkTimeUnit = "Hour";
                            break;
                        case 3:
                            CommunityNewDisplay.TalkTimeUnit = "Day";
                            break;
                    }
                    switch (community.ConnectionType)
                    {
                        case 1:
                            CommunityNewDisplay.ConnectionType = "2G";
                            break;
                        case 2:
                            CommunityNewDisplay.ConnectionType = "3G";
                            break;
                        case 3:
                            CommunityNewDisplay.ConnectionType = "4G";
                            break;
                        case 4:
                            CommunityNewDisplay.ConnectionType = "3.5G";
                            break;
                        case 5:
                            CommunityNewDisplay.ConnectionType = "4.5G";
                            break;
                    }
                    switch (community.SIMAvailable)
                    {
                        case 1:
                            CommunityNewDisplay.SIMAvailable = "None";
                            break;
                        case 2:
                            CommunityNewDisplay.SIMAvailable = "Single SIM";
                            break;
                        case 3:
                            CommunityNewDisplay.SIMAvailable = "Dual SIM";
                            break;
                        case 4:
                            CommunityNewDisplay.SIMAvailable = "Three SIM";
                            break;

                    }
                    */
                    _CommunityNewrmationDisplayList.Add(CommunityNewDisplay);
                }
                return _CommunityNewrmationDisplayList;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception);
            }

        }
      
        #region IDisposable Members
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members
        public class CommunityNews
       {   
            public Int64 IID { get; set; }
            public string CompanyName { get; set; }
            public string ModelName { get; set; }          

        }
    }
}