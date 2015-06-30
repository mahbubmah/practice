using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Basic;
using Utilities;

namespace BLL.Basic
{
    public class AllNewsRT : IDisposable
    {
        private readonly OiiOMartDBDataContext dbContext;
        private readonly AllFeatureRT _allFeatureRT;

        public AllNewsRT()
        {
            dbContext = DatabaseHelper.GetDataModelDataContext();
        }


        public static int InsertAllNewsAndAllChildAllNewsCartDetailsXML(string objectXML)
        {
            try
            {
                return AllNewsDA.InsertAllNewsAndAllChildAllNewsCartDetailsXML(objectXML);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public void AddAllNews(AllNews allNews)
        {
            try
            {
                DatabaseHelper.Insert<AllNews>(allNews);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
        public void UpdateAllNews(AllNews allNews)
        {
            try
            {

                AllNews allnews = dbContext.AllNews.Single(d => d.IID == allNews.IID);
                DatabaseHelper.Update<AllNews>(dbContext, allNews, allnews);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        #region IDisposable Members
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Members

        public AllNews GetAllNewsByIid(int iid)
        {
            try
            {

                AllNews allnews = dbContext.AllNews.SingleOrDefault(d => d.IID == iid);
                return allnews;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public List<AllNewsDetail> GetAllNewsDetailListByAllNesIid(int allNewsIid)
        {
            try
            {
                List<AllNewsDetail> allNewsDetailList = dbContext.AllNewsDetails.Where(x => x.AllNewsID == allNewsIid && x.IsRemoved == false).ToList();
                return allNewsDetailList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public void UpdateAllNewsDetail(AllNewsDetail allNewsDetailNew)
        {
            try
            {

                AllNewsDetail allNewsDetail = dbContext.AllNewsDetails.Single(d => d.IID == allNewsDetailNew.IID);
                DatabaseHelper.Update<AllNewsDetail>(dbContext, allNewsDetailNew, allNewsDetail);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public void AddAllNewsDetail(AllNewsDetail allNewsDetail)
        {
            try
            {
                DatabaseHelper.Insert<AllNewsDetail>(allNewsDetail);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public List<AllNews> GetAllNewsForListViewDisplay()
        {
            try
            {
                var allNewsList = dbContext.AllNews.Where(x => x.IsRemoved == false).ToList();
                return allNewsList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public AllNews GetAllNewsLast()
        {
            try
            {
                var allNews= dbContext.AllNews.OrderByDescending(x => x.IID).FirstOrDefault();
                return allNews;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        /// <summary>
        /// Hasan Add 2015.04.23 
        /// </summary>
        /// <param name="businessTypeID"></param>
        /// <returns></returns>
        public List<AllNews> GetRandomNewsRowsByBusinessTypeID(int businessTypeID)
        {
            try
            {
                IEnumerable<AllNews> allNews = dbContext.ExecuteQuery<AllNews>(@"SELECT  top 4 IID,BusinessTypeID, 
                                                                                ISNULL ( SUBSTRING(TitleName, 0,30)+ '...',' ')AS TitleName , 
                                                                                ISNULL ([Description],'') AS [Description], 
                                                                                ImageUrl,
                                                                                BusinessTypeBreakdownID,
                                                                                CreatedDate
                                                                                FROM [AllNews] WHERE BusinessTypeID=" + businessTypeID + "AND IsRemoved=0" + "ORDER BY newid()");
                return allNews.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        /// <summary>
        /// Hasan Add 2015.04.23 
        /// </summary>
        /// <param name="businessTypeID"></param>
        /// <returns></returns>

//        public List<AllNews> GetRandomAllNewsRowsForAllBusinessType()
//        {
//            try
//            {
//                IEnumerable<AllNews> allNews = dbContext.ExecuteQuery<AllNews>(@"SELECT  top 4 IID,BusinessTypeID,
//                                                                                ISNULL (TitleName,' ')AS TitleName , 
//                                                                                ISNULL ([Description],'') AS [Description], 
//                                                                                ImageUrl,
//                                                                                BusinessTypeBreakdownID  
//                                                                                FROM [AllNews] WHERE IsRemoved=0 ORDER BY newid()");
//                return allNews.ToList();
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message, ex);
//            }
//        }

        /// <summary>
        /// Hasan Add 2015.04.23 From  > Utilities.EnumCollection.BussinessType
        /// </summary>
        /// <param name="businessTypeID"></param>
        /// <returns></returns>
        public string GetNewsTypeNameByBusiessType(int businessTypeID)
        {
            try
            {
                string businessName = string.Empty;
                switch (businessTypeID)
                {
                    case 1:
                        return businessName = "Energy";
                    case 2:
                        return businessName = "Banking";
                    case 3:
                        return businessName = "Travel";
                    case 4:
                        return businessName = "Insurance";
                    case 5:
                        return businessName = "Shopping";
                    case 6:
                        return businessName = "MobilePhone";
                    case 7:
                        return businessName = "NetworkServiceProvider";
                    case 8:
                        return businessName = "BroadBand";
                    case 9:
                        return businessName = "NewsAndCommunity";
                    case 10:
                        return businessName = "Construction";
                    case 11:
                        return businessName = "Medicine";
                }
                return businessName;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }
        /// <summary>
        /// Hasan Add 2015.04.23 For Counting Total Row Number Of AllNewsDetails
        /// </summary>
        /// <param name="allNewsID"></param>
        /// <returns></returns>
        public int CountAllNewsDetailsByAllNewsID(int allNewsIid)
        {
            try
            {
                var allNews = dbContext.AllNewsDetails.Where(x => x.AllNewsID == allNewsIid && x.IsRemoved == false);
                return allNews.Count();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public object GetAllNewsDetailListByAllNesIid(int allNewsIid, int startRowIndex, int maxRowNumber)
        {
            try
            {
                var allNewsDetailList = dbContext.SpGetSortedAllNewsDetailsForNewsID(allNewsIid, startRowIndex, maxRowNumber);
                return allNewsDetailList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        /// <summary>
        /// Hasan Add 2015.04.29
        /// </summary>
        /// <param name="businessTypeID"></param>
        /// <returns></returns>
        public object GetAllNewsListByBusinessTypeID(int businessTypeID)
        {
  
            try
            {
                List<Sp_GetAllNewsListByBusinessTypeIDResult> listNews = new List<Sp_GetAllNewsListByBusinessTypeIDResult>();
                Sp_GetAllNewsListByBusinessTypeIDResult objNewsEx = new Sp_GetAllNewsListByBusinessTypeIDResult();
                var newsListResult = dbContext.Sp_GetAllNewsListByBusinessTypeID(businessTypeID);

                foreach (Sp_GetAllNewsListByBusinessTypeIDResult ne in newsListResult)
                {
                    objNewsEx = ne;
                    objNewsEx.Name = ExtractEnumValue(ne.BusinessTypeID, (int)(ne.BusinessTypeBreakdownID));
                    listNews.Add(objNewsEx);
                }
                return listNews.ToList();                                    
            } 
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
        public object GetAllDistinctParentBusinessType()
        {
            try
            {
               // IEnumerable<AllNews> allNewsList = dbContext.ExecuteQuery<AllNews>(@"Select top 4 F.BusinessTypeID From(select  distinct BusinessTypeID From AllNews where IsRemoved=0)F Order by NEWID()");
                var allNewsList = (from allnews in dbContext.AllNews
                                   where allnews.IsRemoved == false
                                   select new { allnews.BusinessTypeID }).Distinct().Take(4).ToList();

                return allNewsList;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        public string ExtractEnumValue(int typeID, int brTypeID)
        {
            string name = string.Empty;
            switch (typeID)
            {

                case 1:
                    name = EnumHelper.EnumToStringWithSpace<EnumCollection.BusinessEnergyType>(brTypeID);
                    return name;
                case 2:
                    name = EnumHelper.EnumToStringWithSpace<EnumCollection.BusinessBankingType>(brTypeID);
                    return name;
                case 3:
                    name = EnumHelper.EnumToStringWithSpace<EnumCollection.BusinessTravelType>(brTypeID);
                    return name;
                case 4:
                    name = EnumHelper.EnumToStringWithSpace<EnumCollection.BusinessInsuranceType>(brTypeID);
                    return name;
                case 5:
                    name = EnumHelper.EnumToStringWithSpace<EnumCollection.BusinessShoppingType>(brTypeID);
                    return name;
                case 6:
                    name = EnumHelper.EnumToStringWithSpace<EnumCollection.BusinessMobilePhonesType>(brTypeID);
                    return name;
                case 7:
                    name = EnumHelper.EnumToStringWithSpace<EnumCollection.NetworkServiceProvider>(brTypeID);
                    return name;
                case 8:
                    name = EnumHelper.EnumToStringWithSpace<EnumCollection.BusinessBroadbandType>(brTypeID);
                    return name;
                case 9:
                    name = EnumHelper.EnumToStringWithSpace<EnumCollection.BusinessEnergyType>(brTypeID);
                    return name;
                case 10:
                    name = EnumHelper.EnumToStringWithSpace<EnumCollection.BusinessEnergyType>(brTypeID);
                    return name;
                case 11:
                    name = EnumHelper.EnumToStringWithSpace<EnumCollection.BusinessEnergyType>(brTypeID);
                    return name;
            }
            return name;
        }

        /// <summary>
        /// Hasan Add 2015.05.05
        /// </summary>
        /// <param name="businessTypeID"></param>
        /// <returns></returns>

        public List<SP_GetRandomAllNewsRowsByBusenessTypeIDResult> GetRandomAllNewsByBusinessTypeID(int businessTypeID)
        {
            try
            {
                var spListObj = new List <SP_GetRandomAllNewsRowsByBusenessTypeIDResult>();
                var spObj = new SP_GetRandomAllNewsRowsByBusenessTypeIDResult();
                var spResult= dbContext.SP_GetRandomAllNewsRowsByBusenessTypeID(businessTypeID);
                foreach(SP_GetRandomAllNewsRowsByBusenessTypeIDResult sp in spResult)
                {
                    spObj = sp;
                    spObj.Name = ExtractEnumValue(spObj.BusinessTypeID, (int)(spObj.BusinessTypeBreakdownID));
                    spListObj.Add(spObj);
                }
                return spListObj;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
     
        }

        public object GetAllShoppingNews()
        {
            try
            {
                var shoppingNews = dbContext.spGetAllShoppingNews();
                
                return shoppingNews;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
        public int GeTop1AllNewsIIDForBusinessTypeIDnBreakDownID(int businessTypeID,int businessTypeBreakDownID)
        {
            try
            {
                var iid =dbContext.AllNews.SingleOrDefault(n => n.BusinessTypeID == businessTypeID && n.BusinessTypeBreakdownID == businessTypeBreakDownID && n.IsRemoved == false);
                if (iid != null)
                    return iid.IID;
                else
                    return 0;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
    }
}
